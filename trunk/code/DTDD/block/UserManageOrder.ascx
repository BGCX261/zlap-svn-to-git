<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserManageOrder.ascx.cs" Inherits="block_UserManageOrder" %>
<table width="100%" cellpadding="0" cellspacing="0" border="0">
<tr>
  <td class="bg_b1"></td>
  <td class="bg_b2"><div class="text_bl"><%=tbl_listorder %></div></td>
  <td class="bg_b3"></td>
</tr>
<tr>
  <td class="bg_b4"></td>
  <td valign="top" class="text_5">
  <table border="0" cellpadding="1" cellspacing="0" width="100%">
  <tr class="text_b2">
          <td width="92"><%=tcodeorder %></td>
          <td width="75"><%=tshipdate %></td>
          <td width="100"><%=tshippingname %></td>
          <td width="200"><%=tshippingaddress %></td>
		  <td align="right"><%=tstate %></td>
        </tr>
  </table>
  <%=strorder %>
  <%=tpage %>
	  </td>
  <td class='bg_b5'></td>
</tr>
<tr>
  <td class='bg_b7' colspan='3'></td>
</tr>
</table>
<script language="javascript" type="text/javascript">
    var value="<%=currentAccess %>";
    SetCurrentAccess(value);
</script>