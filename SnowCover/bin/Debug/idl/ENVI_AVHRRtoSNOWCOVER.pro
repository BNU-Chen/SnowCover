PRO ENVI_AVHRRtoSNOWCOVER, In_Directory, Date_Time, EVF_FileName, Out_Directory, SNOW_Directory,SNOWCOVER = SNOWCOVER
;  输入变量：
;  In_Directory--原始文件路径
;  Date_Time--筛选数据日期
;  EVF_FileName--裁剪用矢量数据路径
;  Out_Directory--输出文件路径
;  SNOW_FILENAME--输出积雪覆盖文件路径
  ;系统环境设置
  COMPILE_OPT idl2
;  ;启动ENVI
;  e=ENVI()
  ;ENVI模式初始化设置
  ENVI, /RESTORE_BASE_SAVE_FILES
  ENVI_BATCH_INIT,LOG_FILE='batch.log'
  ;搜索文件
  Files = FILE_SEARCH(In_Directory,'*'+Date_Time+'*.MM')
  FileCount = N_ELEMENTS(Files)
  IF (FileCount EQ 0) THEN BEGIN
    RETURN
  ENDIF
  ;设置变量，记录文件号
  SnowCover_FIDS=LONARR(FileCount);几何校正文件号
  ;打开文件，记录文件号
  FOR NX =0,FileCount -1 DO BEGIN
    FileName = Files[NX]
    ;打开文件
    ENVI_OPEN_DATA_FILE, FileName, r_fid=temp_fid, /AVHRR
    IF (temp_fid EQ -1) THEN BEGIN
      RETURN
    ENDIF
    ;执行几何校正
    basename=file_basename(FileName)
    Out_Name=Out_Directory+'\'+strmid(basename,12,strlen(basename)-15);+'.tif'
    ;SNOW_FILENAME=SNOW_Directory+'\'+strmid(basename,12,strlen(basename)-15)+'_sc.tif'
    Avhrr_Pretreatment_SnowCover, temp_fid, Out_Name=Out_Name,  R_Fid=sc_fid;SNOW_FILENAME=SNOW_FILENAME,
    IF (sc_fid EQ -1) THEN BEGIN
      RETURN
    ENDIF
    SnowCover_FIDS[NX]=sc_fid
    ;移除AVHRR文件头
    ENVI_FILE_MNG,ID=temp_fid, /REMOVE;, /DELETE
  ENDFOR
  
  ;积雪文件拼接
  MOSAIC_Files,SnowCover_FIDS,R_FID=mosaic_fid
  IF (mosaic_fid EQ -1) THEN BEGIN
    RETURN
  ENDIF
  
  ;积雪文件裁剪
  SNOWCOVER=SNOW_Directory+'\D'+Date_Time+'_sc.tif'
  Mask_With_Evf,mosaic_fid,EVF_FileName,Out_Name=SNOWCOVER,R_FID=mask_fid
  IF (mask_fid EQ -1) THEN BEGIN
    RETURN
  ENDIF
  
  ;移除全部打开文件
  fidss=ENVI_GET_FILE_IDS()
  FileCount = N_ELEMENTS(fidss)
  FOR NX =0,FileCount -1 DO BEGIN
    ENVI_FILE_MNG,ID=fidss[NX], /REMOVE
  ENDFOR
END