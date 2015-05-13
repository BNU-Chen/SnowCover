PRO EXCHANGEARR,arr,oriArr= oriArr
  tmp = DIALOG_MESSAGE(STRING(arr),/infor,$
    title ='IDL Show Dialog_Message')
  oriArr = arr
  arr = arr+3
END