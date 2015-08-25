<%@ Control Language="C#" AutoEventWireup="true" CodeFile="promainpage.ascx.cs" Inherits="block_promainpage" %>
<div id="divSpecial"></div>
<table width="100%" cellpadding="0" cellspacing="0" border="0">
<tr>
<td class="bg_b1"></td>
<td class="bg_b2"><div class="text_bl"><%=titlePage %></div></td>
<td class="bg_b3"></td>
</tr>
<tr>
<td class="bg_b4"></td>
<td height="450" valign="top">
<div class="text_5">
    <%=strProMain %>
</div></td>
<td class="bg_b5"></td>
</tr>
<tr>
<td class="bg_b7" colspan="3"></td>
</tr>
<tr><td height="10"></td></tr>
</table>
<%=str_bestview %>
<div id="divSpec" class="div_panel" style="display:none;"></div>
<script language="javascript" type="text/javascript">
    var value="<%=currentAccess %>";
    strTitleValue=value;
    setTimeout("ControlDiv();",100);
    setTimeout("RequestCommon(8);",500);
</script>