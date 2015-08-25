<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GroupContactEdit.ascx.cs" Inherits="admin_block_GroupContactEdit" %>
<table cellpadding="0" cellspacing="0" border="0" width="400" align="center">
    <tr height='30'>
      <td colspan="2" class="title2">Nhập thông tin nhóm liên hệ</td>
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
      <td width="100" class="title3">Tiêu đề nhóm</td>
      <td><input type="text" id="txttitle" runat="server" maxlength="128" class="txtbox1" /></td>
    </tr>
    <tr>
      <td colspan="2" height="5"></td>
    </tr>
    <tr>
      <td class="title3">Thứ tự hiển thị</td>
      <td><select runat="server" id="slsort">
      <option value="1">1</option>
      <option value="2">2</option>
      <option value="3">3</option>
      <option value="4">4</option>
      <option value="5">5</option>
      <option value="6">6</option>
      <option value="7">7</option>
      </select></td>
    </tr>
    <tr>
      <td colspan="2" height="5"></td>
    </tr>
    <tr class="bgtr">
      <td style="height: 24px"></td>
      <td style="height: 24px"><input type="button" id="btadd" runat="server" class="button" value="Chỉnh sửa" onserverclick="btedit_ServerClick" /><input type="button" class="button" value="Quay lại" onclick="Back('groupcontact');" /></td>
    </tr>
  </table>