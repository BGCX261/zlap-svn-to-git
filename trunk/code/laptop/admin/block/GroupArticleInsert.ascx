<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GroupArticleInsert.ascx.cs" Inherits="admin_block_GroupArticleInsert" %>
<table cellpadding="0" cellspacing="0" border="0" width="400">
    <tr height='30'>
      <td colspan="2" class="title2">Nhập thông tin nhóm tin tức</td>
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
      <td><input type="text" id="txttitle" runat="server" maxlength="64" class="txtbox1" />
        (<=64)</td>
    </tr>
    <tr>
      <td colspan="2" height="5"></td>
    </tr>
    <tr>
      <td class="title3">Hiển thị</td>
      <td><input type="checkbox" id="checkshow" runat="server" checked="checked" class="check" /></td>
    </tr>
    <tr>
      <td colspan="2" height="5"></td>
    </tr>
    <tr class="bgtr">
      <td style="height: 24px"></td>
      <td style="height: 24px"><input type="button" id="btadd" runat="server" class="button" value="Thêm mới" onserverclick="btadd_ServerClick" /><input type="button" class="button" value="Quay lại" onclick="Back('grouparticle');" /></td>
    </tr>
  </table>