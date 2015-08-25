<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PocketPcAll.ascx.cs" Inherits="block_PocketPcAll" %>
<table width="100%" cellpadding="0" cellspacing="0" border="0">
<tr>
<td class="bgtl1"></td>
<td class="bgtc1" width="544"><%=blpro%></td>
<td class="bgtr1"></td>
</tr>
<tr>
  <td height="2"></td>
</tr>
<tr>
<td colspan="3" class="bgcl1">
<%=strProduct %></td>
</tr>
<tr>
  <td height="10"></td>
</tr>
</table>
<div id="divSpec" class="div_panel" style="display:none;"></div>
<script language="javascript" type="text/javascript">
    var value="<%=tCurrentAccess %>";
    SetCurrentAccess(value);
</script>