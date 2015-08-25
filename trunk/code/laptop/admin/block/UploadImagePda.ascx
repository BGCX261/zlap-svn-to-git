<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UploadImagePda.ascx.cs" Inherits="admin_block_UploadImagePda" %>
<%@ Register Assembly="WebControls" Namespace="WebControls" TagPrefix="cc1" %>
<table width="100%" border="0">
<tr><td width="60">Từ tìm kiếm</td><td width="124"><input type="text" value="" maxlength="20" class="txtSearch" id="txt_search"/></td><td width="50">Có ảnh : </td><td width='40'><input type="checkbox" id="checkImage" /></td><td width="400"><input type="button" id="btsearchPro" value="Tìm kiếm" class="button"  onclick="searchPda()"; /> <input type="button" id="Button1" class="button" value="Xem toàn bộ" onclick="viewAllPda();" /></td></tr>
<tr><td colspan="5">(Có thể tìm theo: mã sản phẩm, Tên hoặc nhãn hiêu)</td></tr>
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