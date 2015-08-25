<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Helps.ascx.cs" Inherits="block_Helps" %>
<table width="100%" cellpadding="0" cellspacing="0">
<tr>
<td class='bg_b1'></td>
<td class='bg_b2'><div class='text_bl'><%=tblHelps %></div></td>
<td class='bg_b3'></td>
</tr>
<tr>
<td class='bg_b4'></td>
<td class='text_5'><div style='padding-left:20px;line-height:20px;'><%=listHelps %></div>
<%=tableHelps %>
</td>
<td class='bg_b5'></td>
</tr>
<tr>
<td class='bg_b7' colspan='3'></td>
</tr>
<tr>
<td height='8'></td>
</tr>
</table>
<script language="javascript" type="text/javascript">
    var value="<%=currentAccess %>";
    SetCurrentAccess(value);
</script>