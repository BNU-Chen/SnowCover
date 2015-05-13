PRO ENVI_AVHRR_INVERTSNOWCOVER, File_Directory, Date_Time, EVF_FileName, SNOW_FILENAME
  COMPILE_OPT idl2
  e.ENVI()
  ENVI, /RESTORE_BASE_SAVE_FILES
  ENVI_BATCH_INIT,LOG_FILE='batch.log'
  ;初始变量
  ;file_dir='E:\IDL\LYQ\AVHRR\YSJ'
  ;date ='10011'
  ;EVF_FileName ='E:\IDL\LYQ\AVHRR\YSJ\bou1_4p_.evf'
  ;SNOW_FILENAME='E:\IDL\LYQ\AVHRR\test\snow.tif'
  ;设置系统路径
  ;CD,File_Directory
  ;搜索文件
  ;Files = FILE_SEARCH("*"+Date_Time+"*.MM")
  Files = FILE_SEARCH(File_Directory,'*'+Date_Time+'*.MM')
  FileCount = N_ELEMENTS(Files)
  IF (FileCount EQ 0) THEN BEGIN
    ;ENVI_BATCH_EXIT
    RETURN
  ENDIF
  ;打开文件，记录fid
  AVHRR_FIDS=LONARR(FileCount)
  WARP_FIDS=LONARR(FileCount)
  FOR NX =0,FileCount -1 DO BEGIN
    FileName = Files[NX]
    ;打开文件
    ENVI_OPEN_DATA_FILE, FileName, r_fid=temp_fid, /AVHRR
    IF (temp_fid EQ -1) THEN BEGIN
      ;ENVI_BATCH_EXIT
      RETURN
    ENDIF
    Avhrr_Warp, temp_fid, R_Fid=warp_fid
    IF (warp_fid EQ -1) THEN BEGIN
      ;ENVI_BATCH_EXIT
      RETURN
    ENDIF
    WARP_FIDS[NX]=warp_fid
    ;移除AVHRR文件头
    ENVI_FILE_MNG,ID=temp_fid, /REMOVE;, /DELETE
  ENDFOR
  AVHRR_MOSAIC,WARP_FIDS,R_FID=temp_fid
  IF (temp_fid EQ -1) THEN BEGIN
    ;ENVI_BATCH_EXIT
    RETURN
  ENDIF
  MOSAIC_FID=temp_fid
  FOR NX =0,FileCount -1 DO BEGIN
    temp_fid=WARP_FIDS[NX]
    ;移除几何校正文件头
    ENVI_FILE_MNG,ID=temp_fid, /REMOVE;, /DELETE
  ENDFOR
  MaskAvHRRVithEvf,MOSAIC_FID,EVF_FileName,R_FID=temp_fid
  IF (temp_fid EQ -1) THEN BEGIN
    ;ENVI_BATCH_EXIT
    RETURN
  ENDIF
  MASK_FID=temp_fid
  AVHRR_BANDMATH_SNOWCOVER,MASK_FID,SNOW_FILENAME,R_FID=temp_fid
  IF (temp_fid EQ -1) THEN BEGIN
    ;ENVI_BATCH_EXIT
    RETURN
  ENDIF
END
;波段运算
pro AVHRR_BANDMATH_SNOWCOVER,MASK_FID,SNOW_FILENAME,R_FID=R_FID
  ENVI_FILE_QUERY,MASK_FID,DIMS=dims,NS=ns,NL=nl,NB=nb
  b6_fid=[MASK_FID,MASK_FID]
  b6_pos=[0,1]
  ;out_name_b6='E:\IDL\LYQ\AVHRR\test\b6_t.tif'
  exp_b6='fix(((b2-b1) / float(b2+b1) + 1)/2*255)'
  envi_doit, 'math_doit', fid=b6_fid, /in_memory, pos=b6_pos, dims=dims, exp=exp_b6, r_fid=b6_out_fid ;OUT_NAME=out_name_b6,
  b7_fid=[MASK_FID,MASK_FID]
  b7_pos=[0,2]
  ;out_name_b7='E:\IDL\LYQ\AVHRR\test\b7_t.tif'
  exp_b7='fix((b1 / float(b3) + 1)/2*255)'
  envi_doit, 'math_doit', fid=b7_fid, /in_memory, pos=b7_pos, dims=dims, exp=exp_b7, r_fid=b7_out_fid ;OUT_NAME=out_name_b7,
  b8_fid=[MASK_FID,MASK_FID]
  b8_pos=[2,3]
  ;out_name_b8='E:\IDL\LYQ\AVHRR\test\b8_t.tif'
  exp_b8='b4-b3'
  envi_doit, 'math_doit', fid=b8_fid, /in_memory, pos=b8_pos, dims=dims, exp=exp_b8, r_fid=b8_out_fid ;OUT_NAME=out_name_b8,
  snowin_fid=[MASK_FID,MASK_FID,b7_out_fid,b8_out_fid]
  snowin_pos=[0,2,0,0]
  ;SNOW_FILENAME='E:\IDL\LYQ\AVHRR\test\snow_tt.tif'
  exp_snow='(b1 gt 140)and(b3 lt 330)and(b7 gt 280)and(b8 gt 11)'
  envi_doit, 'math_doit', fid=snowin_fid, OUT_NAME=SNOW_FILENAME, pos=snowin_pos, dims=dims, exp=exp_snow, r_fid=snow_fid
  R_FID=snow_fid
  re_fid=[b6_out_fid,b7_out_fid,b8_out_fid]
  FOR NX =0,2 DO BEGIN
    temp_fid=re_fid[NX]
    ;移除几何校正文件头
    ENVI_FILE_MNG,ID=temp_fid, /REMOVE;, /DELETE
  ENDFOR
end
;影像裁剪
PRO MaskAvHRRVithEvf,MOSAIC_FID,EVF_FileName,R_FID=R_FID
  ENVI_FILE_QUERY,MOSAIC_FID,DIMS=dims,NS=ns,NL=nl,NB=nb
  evf_id=ENVI_EVF_OPEN(EVF_FileName)

  ;获取相关信息
  ENVI_EVF_INFO, evf_id, num_recs=num_recs, $
    data_type=data_type, projection=projection, $
    layer_name=layer_name
  roi_ids = LONARR(num_recs)
  ;读取各个记录的点数
  FOR i=0,num_recs-1 DO BEGIN
    record = ENVI_EVF_READ_RECORD(evf_id, i)
    ;转换为文件坐标
    ENVI_CONVERT_FILE_COORDINATES,MOSAIC_FID,xmap,ymap,record[0,*],record[1,*]
    ;创建ROI
    roi_id = ENVI_CREATE_ROI(color=4, ns = ns, nl = nl)
    ENVI_DEFINE_ROI, roi_id, /polygon, xpts=REFORM(xMap), ypts=REFORM(yMap)
    roi_ids[i] = roi_id
    ;记录XY的区间，裁剪用
    IF i EQ 0 THEN BEGIN
      xmin = ROUND(MIN(xMap,max = xMax))
      yMin = ROUND(MIN(yMap,max = yMax))
    ENDIF ELSE BEGIN
      xmin = xMin < ROUND(MIN(xMap))
      xMax = xMax > ROUND(MAX(xMap))
      yMin = yMin < ROUND(MIN(yMap))
      yMax = yMax > ROUND(MAX(yMap))
    ENDELSE
  ENDFOR
  xMin = xMin >0
  xmax = xMax < ns-1
  yMin = yMin >0
  yMin=yMin-3
  ymax = yMax < nl-1
  ymax=ymax+5
  ;创建掩膜，裁剪后掩
  ENVI_MASK_DOIT, AND_OR =1, /IN_MEMORY, ROI_IDS= roi_ids, $ ;ROI的ID
    ns = ns, nl = nl, /inside, r_fid = m_fid
  out_dims = [-1,xMin,xMax,yMin,dims[4]]
  ;out_name='E:\IDL\LYQ\AVHRR\test\mask3.tif'
  ENVI_MASK_APPLY_DOIT, FID = MOSAIC_FID, POS = INDGEN(nb), DIMS = out_dims, /IN_MEMORY, $
    M_FID = m_fid, M_POS = [0], VALUE = 0, R_FID = r_fid;out_name = out_name,
  ;掩膜文件ID移除
  ENVI_FILE_MNG, id =m_fid,/remove
END
;影像拼接
PRO AVHRR_MOSAIC,WARP_FIDS,R_FID=R_FID
  FileCount = N_ELEMENTS(WARP_FIDS)
  ;拼接参数
  mosaic_dimss=lonarr(5, FileCount)
  mosaic_poss = lonarr(5,FileCount)
  ;mosaic_x0=lonarr(FileCount)
  ;mosaic_y0=lonarr(FileCount)
  see_throuth_files = lonarr(FileCount) + 1L
  see_throuth_value = lonarr(FileCount)
  left_up=dblarr(2);输出左上点坐标
  right_down=dblarr(2);输出右下点坐标
  map_info = envi_get_map_info(fid=WARP_FIDS[0])
  left_up=[map_info.mc[2],map_info.mc[3]]
  right_down=[map_info.mc[2],map_info.mc[3]]
  le_up_ps=dblarr(2,FileCount)
  FOR NX =0,FileCount -1 DO BEGIN
    ;记录拼接信息
    ENVI_FILE_QUERY,WARP_FIDS[NX],DIMS=dims,NS=ns,NL=nl,NB=nb;, BNAMES= BNAMES
    mosaic_dimss[*,NX]=dims
    mosaic_poss[*,NX]=LINDGEN(nb)
    map_info = envi_get_map_info(fid=WARP_FIDS[NX])
    ;确定输出范围
    le_up_ps[0,NX]=map_info.mc[2]
    le_up_ps[1,NX]=map_info.mc[3]
    rd_temp=dblarr(2)
    point_size=map_info.ps
    rd_temp=[map_info.mc[2]+ns*point_size[0],map_info.mc[3]-nl*point_size[1]]
    if map_info.mc[2] lt left_up[0] then left_up[0]=map_info.mc[2]
    if map_info.mc[3] gt left_up[1] then left_up[1]=map_info.mc[3]
    if rd_temp[0] gt right_down[0] then right_down[0]=rd_temp[0]
    if rd_temp[1] lt right_down[1] then right_down[1]=rd_temp[1]
  ENDFOR
  ;计算起始位置
  mosaic_x0=intarr(FileCount)
  mosaic_y0=intarr(FileCount)
  FOR NX =0,FileCount -1 DO BEGIN
    mosaic_x0[NX]=ceil((le_up_ps[0,NX]-left_up[0])/point_size[0])+1
    mosaic_y0[NX]=ceil((left_up[1]-le_up_ps[1,NX])/point_size[1])+1
  ENDFOR
  ;拼接坐标系统信息
  units = envi_proj_units_translate('Degrees')
  mosaic_mc=[0D,0D,left_up]
  mosaic_ps=point_size
  mosaic_datum='WGS-84'
  mosaic_map_info=envi_map_info_create(/geographic, units=units, ps=mosaic_ps, mc=mosaic_mc, datum=mosaic_datum)
  mosaic_xrange=right_down[0]-left_up[0]
  mosaic_yrange=left_up[1]-right_down[1]
  ;mosaic_fid=-1l
  ENVI_DOIT, 'MOSAIC_DOIT' , BACKGROUND=0, FID=warp_fids, /GEOREF, /IN_MEMORY,$;
    DIMS=mosaic_dimss, MAP_INFO=mosaic_map_info, OUT_DT=2, $;OUT_NAME=out_name,
    PIXEL_SIZE=point_size, POS=mosaic_poss, R_FID=R_FID,$
    see_through_val=see_throuth_value, use_see_through=see_throuth_files, $
    XSIZE=mosaic_xrange, X0=mosaic_x0, YSIZE=mosaic_yrange, Y0=mosaic_y0
  ;RETURN R_FID
END
;几何校正
PRO Avhrr_Warp,AVHRR_FID,R_Fid=R_Fid
  units = envi_proj_units_translate('Degrees')
  proj = envi_proj_create(/geographic, unit=units)
  point_size = [0.01229091,0.00991261]
  envi_file_query, AVHRR_FID, dims=dims, nb=nb
  pos = lindgen(nb)
  ;temp_fid=-1l
  envi_doit, 'envi_avhrr_warp_doit', fid=AVHRR_FID, $
    avhrr_fid=AVHRR_FID, dims=dims, pos=pos,  /IN_MEMORY,$
    method=6, degree=1, background=0, grid=[50,50], proj=proj, $
    pixel_size=point_size, r_fid=R_Fid
  ;RETURN temp_fid
END