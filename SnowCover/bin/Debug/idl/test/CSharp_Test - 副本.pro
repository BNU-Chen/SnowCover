PRO CSharp_Test, File_Directory, Date_Time, Search_Result=Search_Result
  COMPILE_OPT idl2
  CATCH,Error_status
  IF Error_status NE 0 THEN BEGIN
    Void=DIALOG_MESSAGE(!ERROR_STSTE.MSG,title='错误信息！',/error)
    CATCH,/CANCEL
    RETURN
  ENDIF
  ENVI, /RESTORE_BASE_SAVE_FILES
  ENVI_BATCH_INIT,LOG_FILE='batch.log'
  
  CD,File_Directory
  ;搜索文件
  Search_Result = FILE_SEARCH("*"+Date_Time+"*.MM")
  
  void=DIALOG_MESSAGE(!ERROR_STSTE.MSG,/infor,title='错误原因')
END