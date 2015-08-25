<%@ Control Language="C#" AutoEventWireup="true" CodeFile="promainpage.ascx.cs" Inherits="block_promainpage" %>
<div id="divSpecial"></div>
<table width='100%' cellpadding='0' cellspacing='0' border='0'>
<tr>
<td class='bgtl1'></td>
<td class='bgtc1' width='544'><%=titlePage %></td>
<td class='bgtr1'></td>
</tr>
<tr><td height='2'></td></tr>
<tr>
<td colspan='3' class='bgcl2'><%=strProMain %></td>
</tr>
<tr><td height='10'></td></tr>
</table>
<%=strjusthave%>
<%=str_bestview %>
<%=strListPocketpc %>
<div id="divSpec" class="div_panel" style="display:none;"></div>
<script language="javascript" type="text/javascript">
    var value="<%=currentAccess %>";
    strTitleValue=value;
    setTimeout("ControlDiv();",100);
    //setTimeout("RequestCommon(8);",500);
</script>