<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SupportOnlineEdit.ascx.cs" Inherits="admin_block_SupportOnlineEdit" %>
<table cellpadding="0" cellspacing="0" border="0" width="400" align="center">
    <tr height='30'>
      <td colspan="2" class="title2">Nhập thông tin nick name</td>
    </tr>
    <tr>
  <td colspan="2" height="2"></td>
</tr>
<tr>
  <td colspan="2"><div id="diverror" runat="server"></div></td>
</tr>
<tr>
      <td colspan="2" height="5"></td>
</tr>
    <tr  class="bgtr">
      <td class="title3">Mã nhóm</td>
      <td><select runat="server" id="slgroup">
      <option value="1">1</option>
      <option value="2">2</option>
      <option value="3">3</option>
      <option value="4">4</option>
      <option value="5">5</option>
      <option value="6">6</option>
      <option value="7">7</option>
      <option value="8">8</option>
      <option value="9">9</option>
      <option value="10">10</option>
      <option value="11">11</option>
      <option value="12">12</option>
      <option value="13">13</option>
      <option value="14">14</option>
      </select></td>
    </tr>
    <tr>
<td colspan="2" height="2"></td>
</tr>
<tr>
  <td width="100" class="title3">Tên nhóm</td>
  <td><input type="text" id="txtgroup" runat="server" maxlength="128" class="txtbox1" /></td>
</tr>
<tr>
<td colspan="2" height="2"></td>
</tr>
<tr class="bgtr">
  <td width="100" class="title3">Tên nhân viên</td>
  <td><input type="text" id="txtname" runat="server" maxlength="128" class="txtbox1" /></td>
</tr>
<tr>
  <td colspan="2" height="2"></td>
</tr>
<tr>
  <td width="100" class="title3">Nick name</td>
  <td><input type="text" id="txtnickname" runat="server" maxlength="128" class="txtbox1" /></td>
</tr>
<tr>
  <td colspan="2" height="2"></td>
</tr>
<tr class="bgtr">
  <td width="100" class="title3">Tiêu đề</td>
  <td><input type="text" id="txttitle" runat="server" maxlength="128" class="txtbox1" /></td>
</tr>
<tr>
  <td colspan="2" height="2"></td>
</tr>
<tr>
  <td class="title3">Thứ tự ưu tiên</td>
  <td><select runat="server" id="slsort">
  <option value="1">1</option>
  <option value="2">2</option>
  <option value="3">3</option>
  <option value="4">4</option>
  <option value="5">5</option>
  <option value="6">6</option>
  <option value="7">7</option>
  <option value="8">8</option>
  <option value="9">9</option>
  <option value="10">10</option>
  </select></td>
</tr>
<tr>
  <td colspan="2" height="5"></td>
</tr>
<tr class="bgtr">
  <td style="height: 24px"></td>
  <td style="height: 24px"><input type="button" id="btadd" runat="server" class="button" value="Chỉnh sửa" onserverclick="btedit_ServerClick" /><input type="button" class="button" value="Quay lại" onclick="Back('onlinesupport');" /></td>
</tr>
</table>