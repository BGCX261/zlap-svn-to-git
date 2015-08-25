<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LocationContactEdit.ascx.cs" Inherits="admin_block_LocationContactEdit" %>
<table cellpadding="0" cellspacing="0" border="0" width="400" align="center">
    <tr height='30'>
      <td colspan="2" class="title2">Nhập khu vực liên hệ (Sài Gòn, Hà Nội...)</td>
    </tr>
    <tr>
  <td colspan="2" height="2"></td>
</tr>
<tr>
  <td colspan="2"><div id="diverror" runat="server"></div></td>
</tr>
<tr>
  <td colspan="2" height="2"></td>
</tr>
    <tr class="bgtr">
      <td width="100" class="title3">Khu vực</td>
      <td><input type="text" id="txttitle" runat="server" maxlength="128" class="txtbox1" /></td>
    </tr>
    <tr>
      <td colspan="2" height="5"></td>
    </tr>
    <tr class="bgtr">
      <td style="height: 24px"></td>
      <td style="height: 24px"><input type="button" id="btadd" runat="server" class="button" value="Chỉnh sửa" onserverclick="btedit_ServerClick" /><input type="button" class="button" value="Quay lại" onclick="Back('locationcontact');" /></td>
    </tr>
  </table>