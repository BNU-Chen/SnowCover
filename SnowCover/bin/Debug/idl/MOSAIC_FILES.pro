PRO MOSAIC_Files,IN_FIDS,R_FID=R_FID
;本过程实现影像的拼接功能
  COMPILE_OPT idl2
  ENVI, /RESTORE_BASE_SAVE_FILES
  ENVI_BATCH_INIT,LOG_FILE='batch.log'
  
  FileCount = N_ELEMENTS(IN_FIDS)
  ;拼接参数
  ENVI_FILE_QUERY,IN_FIDS[0],DIMS=dims,NS=ns,NL=nl,NB=nb
  mosaic_dimss=lonarr(5, FileCount)
  mosaic_poss = lonarr(nb,FileCount)
  ;mosaic_x0=lonarr(FileCount)
  ;mosaic_y0=lonarr(FileCount)
  see_throuth_files = lonarr(FileCount) + 1L
  see_throuth_value = lonarr(FileCount)
  left_up=dblarr(2);输出左上点坐标
  right_down=dblarr(2);输出右下点坐标
  map_info = envi_get_map_info(fid=IN_FIDS[0])
  left_up=[map_info.mc[2],map_info.mc[3]]
  right_down=[map_info.mc[2],map_info.mc[3]]
  le_up_ps=dblarr(2,FileCount)
  FOR NX =0,FileCount -1 DO BEGIN
    ;记录拼接信息
    ENVI_FILE_QUERY,IN_FIDS[NX],DIMS=dims,NS=ns,NL=nl,NB=nb;, BNAMES= BNAMES
    mosaic_dimss[*,NX]=dims
    mosaic_poss[*,NX]=LINDGEN(nb)
    map_info = envi_get_map_info(fid=IN_FIDS[NX])
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
  ENVI_DOIT, 'MOSAIC_DOIT' , BACKGROUND=0, FID=IN_FIDS, /GEOREF, /IN_MEMORY,$;
    DIMS=mosaic_dimss, MAP_INFO=mosaic_map_info, OUT_DT=2, $;OUT_NAME=out_name,
    PIXEL_SIZE=point_size, POS=mosaic_poss, R_FID=R_FID,$
    see_through_val=see_throuth_value, use_see_through=see_throuth_files, $
    XSIZE=mosaic_xrange, X0=mosaic_x0, YSIZE=mosaic_yrange, Y0=mosaic_y0
END