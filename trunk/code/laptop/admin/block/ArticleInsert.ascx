<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleInsert.ascx.cs" Inherits="admin_block_ArticleInsert" %>
<table cellpadding="0" cellspacing="0" border="0" align="center">
    <tr height='30'>
      <td colspan="2" class="title2">Nhập nội dung tin tức</td>
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
      <td width="100" class="title3">Tiêu đề tin</td>
      <td><input type="text" id="txttitle" runat="server" maxlength="128" class="txtbox2" /></td>
    </tr>
    <tr>
      <td width="100" class="title3">Nhóm tin</td>
      <td><select id="slGroup" class="txtbox2" runat="server"></select></td>
    </tr>
    <tr>
      <td colspan="2" height="5"></td>
    </tr>
    <tr class="bgtr">
      <td width="100" class="title3">Mô tả ngắn gọn</td>
      <td><textarea rows="5" runat="server" id="txtsumcontent" class="txtbox2"></textarea></td>
    </tr>
    <tr>
      <td colspan="2" height="5"></td>
    </tr>
    <tr>
      <td width="100" class="title3">Nội dung tin tức</td>
      <td><textarea id="txtContent" name="txtContent"><% =content%></textarea>
      <script> 
		var oEdit1 = new InnovaEditor("oEdit1");
		oEdit1.width="520";
		oEdit1.height="250";
		oEdit1.REPLACE("txtContent");
		</script></td>
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
      <td width="100" class="title3">Nguồn tin</td>
      <td><input type="text" maxlength="128" runat="server" id="txtsource" class="txtbox1"/></td>
    </tr>
    <tr>
      <td colspan="2" height="5"></td>
    </tr>
    <tr class="bgtr">
      <td width="100" class="title3">Đường dẫn(Link)</td>
      <td><input type="text" maxlength="128" runat="server" id="txtlink" class="txtbox1"/></td>
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
    <tr class="bgtr">
      <td style="height: 24px"></td>
      <td style="height: 24px"><input type="button" id="btadd" runat="server" class="button" value="Thêm mới" onserverclick="btadd_ServerClick" /><input type="button" class="button" value="Quay lại" onclick="Back('article');" /></td>
    </tr>
  </table>