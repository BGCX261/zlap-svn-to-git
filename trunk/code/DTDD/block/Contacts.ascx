<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Contacts.ascx.cs" Inherits="block_Contacts" %>
<table width="100%" cellpadding="0" cellspacing="0" border="0">
  <tr>
	<td class="bg_b1"></td>
	<td class="bg_b2"><div class="text_bl"><%=tblContact %></div></td>
	<td class="bg_b3"></td>
  </tr>
  <tr>
	<td class="bg_b4"></td>
	<td valign="top" class="text_5" style="padding:7px;">
	<div class="text_2">Trang web <span class="text_title"><a href="http://www.maytinhxachtay.com">www.MayTinhXachTay.com</a></span> là sự hợp tác và hỗ trợ lẫn nhau nhằm đảm bảo cung cấp chất lượng dịch vụ tốt nhất tới khách hàng của các đơn vị sau đây:</div>
	<%=tableContacts%></td>
	<td class="bg_b5"></td>
  </tr>
  <tr>
	<td class="bg_b7" colspan="3"></td>
  </tr>
</table>
<script language="javascript" type="text/javascript">
    var value="<%=currentAccess %>";
    SetCurrentAccess(value);
</script>