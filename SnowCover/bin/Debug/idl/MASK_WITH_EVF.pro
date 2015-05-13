PRO Mask_With_Evf,MOSAIC_FID,EVF_FileName,Out_Name=Out_Name,R_FID=R_FID
;本过程利用EVF文件实现影像裁剪功能
  COMPILE_OPT idl2
  ENVI, /RESTORE_BASE_SAVE_FILES
  ENVI_BATCH_INIT,LOG_FILE='batch.log'
  
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
  ENVI_MASK_APPLY_DOIT, FID = MOSAIC_FID, POS = INDGEN(nb), DIMS = out_dims, out_name = out_name,$
    M_FID = m_fid, M_POS = [0], VALUE = 0, R_FID = r_fid;/IN_MEMORY,
  ;掩膜文件ID移除
  ENVI_FILE_MNG, id =m_fid,/remove
END