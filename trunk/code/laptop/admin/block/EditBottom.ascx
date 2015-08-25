<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditBottom.ascx.cs" Inherits="admin_block_EditBottom" %>
<table cellpadding="0" cellspacing="0" border="0" align="center">
    <tr height='30'>
      <td class="title2">Nhập nội dung:</td>
    </tr>
    <tr>
  <td height="2"></td>
</tr>
<tr>
  <td><div id="diverror" runat="server" style="color:Red;"></div></td>
</tr>
<tr><td><textarea style="width:650px; height:350px;" id="txtContent" name="txtContent"><% =content%></textarea></td></tr>
<tr>
  <td><asp:Button runat="server" ID="btEdit" Text="Sửa" OnClick="btEdit_Click" /></td>
</tr>
</table>