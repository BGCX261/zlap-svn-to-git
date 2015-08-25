<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MobileMainPage.ascx.cs" Inherits="admin_block_MobileMainPage" %>
<table width="100%" border="0">
<tr><td width="60">Từ tìm kiếm</td><td width="124"><input type="text" value="" maxlength="20" class="txtSearch" id="txt_search"/> </td><td width="140">Đã hiển thị ở trang chính: </td><td width='40'><input type="checkbox" id="checkBest" /></td><td width="400"><input type="button" id="btsearchPro" value="Tìm kiếm" class="button"  onclick="searchMobile1(1)"; /> <input type="button" id="Button1" class="button" value="Xem toàn bộ chưa chọn" onclick="viewAllMobile1(1);" /></td></tr>
<tr><td colspan="5">(Có thể tìm theo: mã sản phẩm, Tên hoặc nhãn hiêu)</td></tr>
<tr><td class="line" colspan="5"></td></tr>
<tr><td height="30" class="text_page" colspan="5"><%=strPage %></td></tr></table>
<%=strlist %>