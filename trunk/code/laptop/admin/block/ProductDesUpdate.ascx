<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductDesUpdate.ascx.cs" Inherits="admin_block_ProductDesUpdate" %>
<table cellpadding="0" cellspacing="0" border="0" align="center" width="640">
    <tr height='30'>
      <td colspan="2">Nhập mô tả cho sản phẩm: <span class="title2" style="color:Red;"><%=title %></span></td>
    </tr>
    <tr>
  <td colspan="2" height="2"></td>
</tr>
<tr>
  <td colspan="2"><div id="diverror" runat="server"></div></td>
</tr>
<tr>
<td>Tên nhóm sản phẩm</td><td><input type="text" value="" maxlength="128" runat="server" id='txtName' name='txtName' /></td>
</tr>
<tr>
  <td colspan="2" height="2"></td>
</tr>
<tr>
  <td>Mô tả ngắn gọn ( Sẽ hiển thị ở trang chủ)</td><td>
  <textarea id="txtShortDes" rows="4" style="width:520px;" runat="server"></textarea>
  </td>
</tr>
<tr>
  <td colspan="2" height="2"></td>
</tr>
    <tr class="bgtr">
      <td width="100" class="title3">Nội dung mô tả</td>
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
    <tr>
      <td>Thông tin cấu hình:</td><td><%=specification %></td>
    </tr>
    <tr>
      <td colspan="2" height="5"></td>
    </tr>
    <tr class="bgtr">
      <td></td>
      <td style="height: 24px"><input type="button" id="btedit" runat="server" class="button" value="Chỉnh sửa" onserverclick="btedit_ServerClick" /><input type="button" class="button" value="Quay lại" onclick="Back('<%=srtback %>');" /></td>
    </tr>
  </table>