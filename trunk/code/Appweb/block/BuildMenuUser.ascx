<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BuildMenuUser.ascx.cs" Inherits="block_BuildMenuUser" %>
<div id="dListNameForm" class="dlist1"  style="display:none;" onmouseover="OnOverDiv();" onmouseout="TimeHidden();"></div>
<table border="0" cellpadding="0" cellspacing="0">
<tr>
  <td class="bgtl1"></td>
  <td class="bgtc1" width="164"><%=titleBlock %></td>
  <td class="bgtr1"></td>
</tr>
<tr>
  <td height="2"></td>
</tr>
<tr>
  <td colspan="3" class="bgcl1"><%=ListRoleUser %>
  </td>
</tr>
</table>