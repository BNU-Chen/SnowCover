pro SNOWCOVER_STATISTIC,IN_FILES,OUT_NAME=OUT_NAME
  COMPILE_OPT idl2
  ENVI, /RESTORE_BASE_SAVE_FILES
  ENVI_BATCH_INIT,LOG_FILE='batch.log'
  FileCount = N_ELEMENTS(IN_FILES)
  IF (FileCount EQ 0) THEN BEGIN
    ;ENVI_BATCH_EXIT
    RETURN
  ENDIF
  IN_FIDS=LONARR(FileCount)
  FOR NX =0,FileCount -1 DO BEGIN
    FileName = IN_FILES[NX]
    ;打开文件
    ENVI_OPEN_DATA_FILE, FileName, r_fid=temp_fid
    IF (temp_fid EQ -1) THEN BEGIN
      ;ENVI_BATCH_EXIT
      RETURN
    ENDIF
    IN_FIDS[NX]=temp_fid
  ENDFOR
  ENVI_FILE_QUERY,IN_FIDS[0],DIMS=out_dims
  IN_POS=lonarr(FileCount)
  OUT_EXP='b1'
  IF FileCount GT 1 THEN BEGIN
    FOR NX =1,FileCount -1 DO BEGIN
      OUT_EXP=OUT_EXP+'+b'+strtrim(string(NX+1),2)
      ENVI_FILE_QUERY,IN_FIDS[NX],DIMS=temp_dims
      IF out_dims[4] GT temp_dims[4] THEN out_dims[4]=temp_dims[4]
    ENDFOR
  ENDIF
  envi_doit, 'math_doit', fid=IN_FIDS, OUT_NAME=OUT_NAME, pos=IN_POS, dims=out_dims, exp=OUT_EXP, r_fid=out_fid
  ;移除全部打开文件
  fidss=ENVI_GET_FILE_IDS()
  FileCount = N_ELEMENTS(fidss)
  FOR NX =0,FileCount -1 DO BEGIN
    ENVI_FILE_MNG,ID=fidss[NX], /REMOVE
  ENDFOR
end