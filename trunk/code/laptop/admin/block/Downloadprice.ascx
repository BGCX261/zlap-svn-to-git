<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Downloadprice.ascx.cs" Inherits="admin_block_Downloadprice" %>
<table cellpadding="0" cellspacing="0" border="0" align="left">
    <tr height='30'>
      <td class="title2">Hãy lựa chọn:</td>
    </tr>
    <tr>
  <td height="2"></td>
</tr>
<tr>
  <td><div id="diverror" runat="server" style="color:Red;"></div></td>
</tr>
<tr><td><asp:DropDownList ID="slvalue" runat="server">
<asp:ListItem Value="0">Không được tải báo giá</asp:ListItem>
<asp:ListItem Value="1">Cho phép tải bái giá</asp:ListItem>
</asp:DropDownList></td></tr>
<tr>
  <td><asp:Button runat="server" ID="btEdit" Text="Cập nhật" OnClick="btEdit_Click" /></td>
</tr>
</table>