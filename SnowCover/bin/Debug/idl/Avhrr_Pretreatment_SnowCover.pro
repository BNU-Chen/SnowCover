PRO Avhrr_Pretreatment_SnowCover,AVHRR_FID,Out_Name=Out_Name,R_Fid=R_Fid
;本过程实现AVHRR原始数据的几何校正与波段运算处理，并返回积雪数据文件号
  COMPILE_OPT idl2
  ENVI, /RESTORE_BASE_SAVE_FILES
  ENVI_BATCH_INIT,LOG_FILE='batch.log'
  ;坐标系设置
  units = envi_proj_units_translate('Degrees')
  proj = envi_proj_create(/geographic, unit=units)
  point_size = [0.01229091,0.00991261]
  envi_file_query, AVHRR_FID, dims=dims, nb=nb
  pos = lindgen(nb)
  result_outname=Out_Name+'.tif'
  envi_doit, 'envi_avhrr_warp_doit', fid=AVHRR_FID, $
    avhrr_fid=AVHRR_FID, dims=dims, pos=pos, OUT_NAME=result_outname,$
    method=6, degree=1, background=0, grid=[50,50], proj=proj, $
    pixel_size=point_size, r_fid=Warp_Fid ; /IN_MEMORY,
  ;波段运算
  envi_file_query, Warp_Fid, dims=dims, nb=nb
  b6_fid=[Warp_Fid,Warp_Fid]
  b6_pos=[0,1]
  b6_outname=Out_Name+'_b6.tif'
  exp_b6='fix(((b2-b1) / float(b2+b1) + 1)/2*255)'
  envi_doit, 'math_doit', fid=b6_fid, OUT_NAME=b6_outname, pos=b6_pos, dims=dims, exp=exp_b6, r_fid=b6_out_fid;/in_memory,
  b7_fid=[Warp_Fid,Warp_Fid]
  b7_pos=[0,2]
  b7_outname=Out_Name+'_b7.tif'
  exp_b7='fix((b1 / float(b3) + 1)/2*255)'
  envi_doit, 'math_doit', fid=b7_fid, OUT_NAME=b7_outname, pos=b7_pos, dims=dims, exp=exp_b7, r_fid=b7_out_fid; /in_memory,
  b8_fid=[Warp_Fid,Warp_Fid]
  b8_pos=[2,3]
  b8_outname=Out_Name+'_b8.tif'
  exp_b8='b4-b3'
  envi_doit, 'math_doit', fid=b8_fid, OUT_NAME=b8_outname, pos=b8_pos, dims=dims, exp=exp_b8, r_fid=b8_out_fid ;/in_memory,
  ;积雪提取
  snowin_fid=[Warp_Fid,Warp_Fid,b7_out_fid,b8_out_fid]
  snowin_pos=[0,2,0,0]
  sc_outname=Out_Name+'_sc.tif'
  exp_snow='(b1 gt 140)and(b3 lt 330)and(b7 gt 280)and(b8 gt 11)'
  envi_doit, 'math_doit', fid=snowin_fid, OUT_NAME=sc_outname, $
    pos=snowin_pos, dims=dims, exp=exp_snow, r_fid=snow_fid
  R_FID=snow_fid
  ;移除无用文件头
  re_fid=[Warp_Fid,b6_out_fid,b7_out_fid,b8_out_fid]
  FOR NX =0,N_ELEMENTS(re_fid)-1 DO BEGIN
    temp_fid=re_fid[NX]
    ENVI_FILE_MNG,ID=temp_fid, /REMOVE;, /DELETE
  ENDFOR
END