<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DetailProduct.ascx.cs" Inherits="block_DetailProduct" %>
<table width="100%" cellpadding="0" cellspacing="0" border="0">
<tr>
<td class="bgtl3"></td>
<td class="bgtc3" width="558"><%=bldetail %></td>
<td class="bgtr3"></td>
</tr>
<tr>
<td valign="top" colspan="3" class="bgcl4" width="574">
<%=strpro%>
<%=strspec%>
<%=strlist%>
</td>
</tr>
<tr>
<td height="10" colspan="3"></td>
</tr>
</table>
<div id="divSpec" class="div_panel" style="display:none;"></div>
<script language="javascript" type="text/javascript">
    var value="<%=tcurrentAccess %>";
    SetCurrentAccess(value);
</script>