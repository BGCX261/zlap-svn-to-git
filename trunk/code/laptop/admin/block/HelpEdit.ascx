<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HelpEdit.ascx.cs" Inherits="admin_block_HelpEdit" %>
<table cellpadding="0" cellspacing="0" border="0" width="600" align="center">
    <tr height='30'>
      <td colspan="2" class="title2">Nhập thông tin trợ giúp</td>
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
      <td width="100" class="title3">Tiêu đề <u>*</u></td>
      <td><input type="text" id="txttitle" runat="server" maxlength="128" class="txtbox1" /></td>
    </tr>
    <tr>
      <td colspan="2" height="5"></td>
    </tr>
    <tr>
      <td width="100" class="title3">Nội dung <u>*</u></ul></td>
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
      <td class="title3">Ưu tiên</td>
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
    <tr>
      <td style="height: 24px"></td>
      <td style="height: 24px"><input type="button" id="btadd" runat="server" class="button" value="Chỉnh sửa" onserverclick="btedit_ServerClick" /><input type="button" class="button" value="Quay lại" onclick="Back('help');" /></td>
    </tr>
  </table>