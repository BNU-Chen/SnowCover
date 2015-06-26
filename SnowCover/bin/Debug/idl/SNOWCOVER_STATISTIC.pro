pro SNOWCOVER_STATISTIC,IN_FILES,OUT_NAME
  COMPILE_OPT idl2
  ENVI, /RESTORE_BASE_SAVE_FILES
  ENVI_BATCH_INIT,LOG_FILE='batch.log'
  FileCount = N_ELEMENTS(IN_FILES)
  IF (FileCount LE 1) THEN BEGIN
    ;ENVI_BATCH_EXIT
    RETURN
  ENDIF
  ENVI_OPEN_DATA_FILE, IN_FILES[0], r_fid=first_fid
  ENVI_FILE_QUERY,first_fid,DIMS=out_dims
  fids=LONARR(1)
  fids[0]=first_fid
  poss=LONARR(1)
  expp='b1'
  envi_doit, 'math_doit', fid=fids, /IN_MEMORY, pos=poss, dims=out_dims, exp=expp, r_fid=cur_fid
  envi_doit, 'math_doit', fid=fids, /IN_MEMORY, pos=poss, dims=out_dims, exp=expp, r_fid=max_fid
  OUT_EXP1='b1*b2+b1'
  OUT_EXP2='b1>b2'
  IN_FIDS=LONARR(FileCount)
  FOR NX =1,FileCount -1 DO BEGIN
    FileName = IN_FILES[NX]
    ;打开文件
    ENVI_OPEN_DATA_FILE, FileName, r_fid=temp_fid
    ENVI_FILE_QUERY,temp_fid,DIMS=temp_dims
    IF (temp_fid EQ -1) THEN BEGIN
      ;ENVI_BATCH_EXIT
      RETURN
    ENDIF
    IF out_dims[4] GT temp_dims[4] THEN out_dims[4]=temp_dims[4]
    remove_fid1=cur_fid
    remove_fid2=max_fid
    envi_doit, 'math_doit', fid=[temp_fid,cur_fid], /IN_MEMORY, pos=[0,0], dims=out_dims, exp=OUT_EXP1, r_fid=cur_fid
    envi_doit, 'math_doit', fid=[cur_fid,max_fid], /IN_MEMORY, pos=[0,0], dims=out_dims, exp=OUT_EXP2, r_fid=max_fid
    ENVI_FILE_MNG,ID=remove_fid1, /REMOVE
    ENVI_FILE_MNG,ID=remove_fid2, /REMOVE
  ENDFOR
  envi_doit, 'math_doit', fid=[max_fid], OUT_NAME=OUT_NAME, pos=[0], dims=out_dims, exp='b1', r_fid=out_fid
  ;移除全部打开文件
  fidss=ENVI_GET_FILE_IDS()
  FileCount = N_ELEMENTS(fidss)
  FOR NX =0,FileCount -1 DO BEGIN
    ENVI_FILE_MNG,ID=fidss[NX], /REMOVE
  ENDFOR
end