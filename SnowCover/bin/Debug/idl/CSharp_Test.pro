PRO CSharp_Test, File_Directory, Date_Time, OUT_NAME,Search_Result=Search_Result
  COMPILE_OPT idl2
;  CATCH,Error_status
;  IF Error_status NE 0 THEN BEGIN
;    Void=DIALOG_MESSAGE(!ERROR_STSTE.MSG,title='错误信息！',/error)
;    CATCH,/CANCEL
;    RETURN
;  ENDIF
  e=ENVI()
  ENVI, /RESTORE_BASE_SAVE_FILES
  ENVI_BATCH_INIT,LOG_FILE='batch.log'
  
;  CD,File_Directory
  ;搜索文件
  Search_Result = FILE_SEARCH(File_Directory,'*'+Date_Time+'*.MM')
  FileName = Search_Result[0]
  ENVI_OPEN_DATA_FILE, FileName, r_fid=temp_fid, /AVHRR
  
  units = envi_proj_units_translate('Degrees')
  proj = envi_proj_create(/geographic, unit=units)
  point_size = [0.01229091,0.00991261]
  envi_file_query, temp_fid, dims=dims, nb=nb
  pos = lindgen(nb)
  ;temp_fid=-1l
  envi_doit, 'envi_avhrr_warp_doit', fid=temp_fid, $
    avhrr_fid=temp_fid, dims=dims, pos=pos,$; /IN_MEMORY,
    method=6, degree=1, background=0, grid=[50,50], proj=proj, $
    OUT_NAME=OUT_NAME, pixel_size=point_size, r_fid=R_Fid
  
  ENVI_BATCH_EXIT
;  void=DIALOG_MESSAGE(!ERROR_STSTE.MSG,/infor,title='错误原因')
END