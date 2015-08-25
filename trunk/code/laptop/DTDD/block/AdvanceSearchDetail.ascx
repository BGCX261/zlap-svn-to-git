<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdvanceSearchDetail.ascx.cs" Inherits="block_AdvanceSearchDetail" %>
<table width="100%" cellpadding="0" cellspacing="0" border="0">
<tr>
<td class="bgtl1"></td>
<td class="bgtc1" width="544"><%=blSearchPro%></td>
<td class="bgtr1"></td>
</tr>
<tr>
  <td height="2"></td>
</tr>
<tr>
<td colspan="3" class="bgcl1">
<%=strpage1 %>
<%=strProMain%>
<%=strpage2 %>
</td>
</tr>
<tr>
  <td height="10"></td>
</tr>
</table>
<div id="divSpec" class="div_panel" style="display:none;"></div>
<script language="javascript" type="text/javascript">
    var strTextSearch="<%=text %>";
    var value="<%=tCurrentAccess %>";
    SetCurrentAccess(value);
</script>