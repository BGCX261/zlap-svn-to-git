<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditAdvertiseSpecial.ascx.cs" Inherits="admin_block_EditAdvertiseSpecial" %>
<table cellpadding="0" cellspacing="0" border="0" align="center">
    <tr height='30'>
      <td colspan="2" class="title2">Nhập nội dung quảng cáo đặc biệt</td>
    </tr>
    <tr>
  <td colspan="2" height="2"></td>
</tr>
<tr>
  <td colspan="2"><div id="diverror" runat="server" style="color:Red;"></div></td>
</tr>
<tr>
  <td colspan="2" height="2"></td>
</tr>
    <tr class="bgtr">
      <td width="100" class="title3">Tiêu đề</td>
      <td><input type="text" id="txttitle" runat="server" maxlength="128" class="txtbox2" /></td>
    </tr>
    <tr>
      <td colspan="2" height="5"></td>
    </tr>
    <tr>
      <td width="100" class="title3">Nhãn hiệu</td>
      <td><select id="slBrand" class="txtbox1" runat="server"></select></td>
    </tr>
    <tr>
      <td colspan="2" height="5"></td>
    </tr>
    <tr class="bgtr">
      <td width="100" class="title3">Nội dung</td>
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
      <td width="100" class="title3">Ảnh nhỏ</td>
      <td><input type="file" runat="server" id="ImageArticle1"/>
      <br />
      <img src="<%=urlOld1 %>" />
      </td>
    </tr>
    <tr>
      <td colspan="2" height="5"></td>
    </tr>
    <tr>
      <td width="100" class="title3">Ảnh to</td>
      <td><input type="file" runat="server" id="ImageArticle2"/>
      <br />
      <img src="<%=urlOld2 %>" />
      </td>
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
      <td width="100" class="title3">Ưu tiên</td>
      <td><select id="slsort" runat="server"></select>
      </td>
    </tr>
    <tr>
      <td colspan="2" height="5"></td>
    </tr>
    <tr class="bgtr">
      <td style="height: 24px"></td>
      <td style="height: 24px"><input type="button" id="btadd" runat="server" class="button" value="Chỉnh sửa" onserverclick="btadd_ServerClick" /><input type="button" class="button" value="Quay lại" onclick="Back('advertisespecial');" /></td>
    </tr>
  </table>