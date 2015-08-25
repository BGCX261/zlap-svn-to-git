<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Contacts.ascx.cs" Inherits="block_Contacts" %>
<table width="100%" cellpadding="0" cellspacing="0" border="0">
<tr>
<td class="bgtl1"></td>
<td class="bgtc1" width="544"><%=tblContact%></td>
<td class="bgtr1"></td>
</tr>
<tr>
  <td height="2"></td>
</tr>
<tr>
<td valign="top" height="250" colspan="3" class="bgcl1">
	<div class="text_2">Trang web <span class="text_title"><a href="http://www.maytinhxachtay.com">www.MayTinhXachTay.com</a></span> là sự hợp tác và hỗ trợ lẫn nhau nhằm đảm bảo cung cấp chất lượng dịch vụ tốt nhất tới khách hàng của các đơn vị sau đây:</div>
	<%=tableContacts%></td>
  </tr>
  <tr>
	<td height="10" colspan="3"></td>
  </tr>
</table>
<script language="javascript" type="text/javascript">
    var value="<%=currentAccess %>";
    SetCurrentAccess(value);
</script>