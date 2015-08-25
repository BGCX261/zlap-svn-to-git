<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContactEdit.ascx.cs" Inherits="admin_block_ContactEdit" %>
<table cellpadding="0" cellspacing="0" border="0" align="center" width="600">
    <tr height='30'>
      <td colspan="2" class="title2">Nhập thông tin liên hệ</td>
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
      <td width="120" class="title3">Tiêu đề liên hệ <u>*</u></td>
      <td><input type="text" id="txttitle" runat="server" maxlength="128" class="txtbox1" /></td>
    </tr>
    <tr>
      <td colspan="2" height="5"></td>
    </tr>
    <tr>
      <td class="title3">Nhóm liên hệ <u>*</u></td>
      <td><select id="slgroup" class="txtbox1" runat="server"></select></td>
    </tr>
    <tr>
      <td colspan="2" height="5"></td>
    </tr>
    <tr class="bgtr">
      <td class="title3">Khu vực liên hệ <u>*</u></td>
      <td><select id="sllocation" class="txtbox1" runat="server"></select></td>
    </tr>
    <tr>
      <td colspan="2" height="5"></td>
    </tr>
    <tr>
      <td class="title3">Mô tả</td>
      <td><textarea rows="5" runat="server" id="txtdes" class="txtbox2"></textarea></td>
    </tr>
    <tr>
      <td colspan="2" height="5"></td>
    </tr>
    <tr class="bgtr">
      <td class="title3">Địa chỉ <u>*</u></td>
      <td><input type="text" id="txtaddress" runat="server" maxlength="128" class="txtbox2" /></td>
    </tr>
    <tr>
      <td colspan="2" height="5"></td>
    </tr>
    <tr>
      <td class="title3">Ảnh kèm theo</td>
      <td><input type="file" runat="server" id="ImageArticle"/></td>
    </tr>
    <tr>
      <td colspan="2" height="5"></td>
    </tr>
    <tr class="bgtr">
      <td class="title3">Thời gian phục vụ</td>
      <td><input type="text" maxlength="255" runat="server" id="txttimeservice" class="txtbox2"/></td>
    </tr>
    <tr>
      <td colspan="2" height="5"></td>
    </tr>
    <tr>
      <td width="100" class="title3">Điện thoại</td>
      <td><input type="text" maxlength="255" runat="server" id="txtphone" class="txtbox2"/></td>
    </tr>
    <tr>
      <td colspan="2" height="5"></td>
    </tr>
    <tr class="bgtr">
      <td class="title3">Người đại diện</td>
      <td><input type="text" maxlength="128" runat="server" id="txtdelegate" class="txtbox1"/></td>
    </tr>
    <tr>
      <td colspan="2" height="5"></td>
    </tr>
    <tr>
      <td class="title3">Email</td>
      <td><input type="text" maxlength="128" runat="server" id="txtemail" class="txtbox1"/></td>
    </tr>
    <tr>
      <td colspan="2" height="5"></td>
    </tr>
    <tr class="bgtr">
      <td class="title3">Fax</td>
      <td><input type="text" maxlength="128" runat="server" id="txtfax" class="txtbox1"/></td>
    </tr>
    <tr>
      <td colspan="2" height="5"></td>
    </tr>
    <tr>
      <td style="height: 24px"></td>
      <td style="height: 24px"><input type="button" id="btedit" runat="server" class="button" value="Chỉnh sửa" onserverclick="btedit_ServerClick" /><input type="button" class="button" value="Quay lại" onclick="Back('contact');" /></td>
    </tr>
  </table>