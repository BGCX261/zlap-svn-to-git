<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UploadImageOrtherPro.ascx.cs" Inherits="admin_block_UploadImageOrtherPro" %>
<%@ Register Assembly="WebControls" Namespace="WebControls" TagPrefix="cc1" %>
<table width="100%" border="0">
<tr><td class="line" colspan="5"></td></tr>
<tr><td height="30" class="text_page" colspan="5"><%=strPage %></td></tr></table>
<%=strlist %>
<div id="divUpload" class="div_panel" style="display:none;">
<div class="tUpload" id="divTitleUpload">Cập nhật ảnh sản phẩm</div>
<asp:FileUpload ID='FileUpload' runat='server' CssClass="file_upload" Height="22" /><cc1:UploadButton ID='ButtonUpload' runat='server'  RelatedFileUploadControlId='FileUpload' Text='Tải lên' OnStartScript='OnStartUpload' OnCompleteScript='ComplateUpload' CssClass="button" OnUploadClick="ButtonUpload_UploadClick" />
<div class='div_img' id='div_name_image'></div>
<div class='div_message'>Chỉ hỗ trợ file dạng : (*.gif,*.ipeg,*.png,*.bmp <=20 KB)</div>
<div class='divclose'><input type="button" value="Đóng lại" class="button" onclick="CloseDiv();" /></div>
</div>