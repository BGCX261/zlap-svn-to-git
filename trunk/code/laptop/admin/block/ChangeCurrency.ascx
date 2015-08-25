<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChangeCurrency.ascx.cs" Inherits="admin_block_ChangeCurrency" %>
<table width="400">
<tr><td><div style="color:Red;" runat="server" id="diverr"></div></td></tr>
<tr>
<td align="center">Hãy chọn loại tiền muốn hiển thị trên website:<select id="idChoice" runat="server">
<option value="$$">$$</option>
<option value="$">$</option>
<option value="USD">USD</option>
<option value="VND">VND</option>
</select>
</td>
</tr>
<tr><td align="center" height="40"><input type="button" value="Đồng ý" runat="server" id="Button1" onserverclick="Button1_ServerClick" /></td></tr>
</table>