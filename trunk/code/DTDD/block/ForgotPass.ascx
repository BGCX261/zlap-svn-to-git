<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ForgotPass.ascx.cs" Inherits="block_ForgotPass" %>
<table width="100%" cellpadding="0" cellspacing="0" border="0">
  <tr>
	<td class="bg_b1"></td>
	<td class="bg_b2"><div class="text_bl"><%=tblforgetpass%></div></td>
	<td class="bg_b3"></td>
  </tr>
  <tr>
	<td class="bg_b4"></td>
	<td height="180" valign="middle">
	<div class="text_2"><%=titlemessage %></div>
	<table border="0" cellpadding="0" cellspacing="0" width="100%">
	<tr><td colspan="2" height="5"></td></tr>
	<tr><td colspan="2"><div id="divErrors" runat="server"></div></td></tr>
	<tr><td colspan="2" height="4"></td></tr>
	<tr class="bgtrU1"><td class="tmessage"><%=temail %></td><td><input type="text" value="" class="tboxuser2" maxlength="128" id="txtemail" runat="server"/></td></tr>
	<tr><td colspan="2" height="4"></td></tr>
	<tr class="bgtrU2"><td class="tmessage"><%=tcode%></td><td><img src="CreateImageCode.aspx" height="22" width="90" /></td></tr>
	<tr><td colspan="2" height="4"></td></tr>
	<tr class="bgtrU1"><td class="tmessage"><%=tcode2 %> <u>*</u></td>
    <td><input type="text" value="" runat="server" id="txtcode"  maxlength="20" class="tboxuser1" /></td>
  </tr>
	<tr><td colspan="2" height="4"></td></tr>
	<tr><td></td><td><asp:Button runat="server" CssClass="bcart" ID="btgetpass" OnClick="getpass_Click" /></td></tr>
	<tr><td colspan="2" height="4"></td></tr>
	</table>
	</td>
	<td class="bg_b5"></td>
  </tr>
  <tr>
	<td class="bg_b7" colspan="3"></td>
  </tr>
</table>
<script language="javascript" type="text/javascript">
    var value="<%=tCurrentAccess %>";
    SetCurrentAccess(value);
</script>
