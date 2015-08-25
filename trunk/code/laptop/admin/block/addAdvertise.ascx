<%@ Control Language="C#" AutoEventWireup="true" CodeFile="addAdvertise.ascx.cs" Inherits="admin_block_addAdvertise" %>
<table cellpadding="0" cellspacing="0" border="0" align="center">
    <tr height='30'>
      <td colspan="2" class="title2">Nhập thông tin liên kết</td>
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
      <td width="100" class="title3">Tiêu đề</td>
      <td><input type="text" id="txttitle" runat="server" maxlength="64" class="txtbox2" /></td>
    </tr>
    <tr>
      <td width="100" class="title3">Ưu tiên</td>
      <td><select id="slsort" runat="server">
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
  <td colspan="2" height="2"></td>
</tr>
    <tr class="bgtr">
      <td width="100" class="title3">Link</td>
      <td><input type="text" id="txtlink" runat="server" maxlength="128" class="txtbox2" /></td>
    </tr>
    <tr>
      <td colspan="2" height="5"></td>
    </tr>
    <tr class="bgtr">
      <td width="100" class="title3">Ảnh kèm theo</td>
      <td><input type="file" runat="server" id="ImageArticle"/></td>
    </tr>
    <tr>
      <td colspan="2" height="5"></td>
    </tr>
    <tr>
      <td class="title3">Hiển thị</td>
      <td><input type="checkbox" id="checkshow" runat="server" class="check" /></td>
    </tr>
    <tr>
      <td colspan="2" height="5"></td>
    </tr>
    <tr>
      <td width="100" class="title3">Mô tả</td>
      <td><textarea rows="5" runat="server" id="txtnote" class="txtbox2"></textarea></td>
    </tr>
    <tr>
      <td colspan="2" height="5"></td>
    </tr>
    <tr class="bgtr">
      <td style="height: 24px"></td>
      <td style="height: 24px"><input type="button" id="btadd" runat="server" class="button" value="Thêm mới" onserverclick="btadd_ServerClick" /><input type="button" class="button" value="Quay lại" onclick="Back('linkweb');" /></td>
    </tr>
  </table>