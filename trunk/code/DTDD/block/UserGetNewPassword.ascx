<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserGetNewPassword.ascx.cs" Inherits="block_UserGetNewPassword" %>
<table width="100%" cellpadding="0" cellspacing="0" border="0">
  <tr>
	<td class="bg_b1"></td>
	<td class="bg_b2"><div class="text_bl"><%=tbl %></div></td>
	<td class="bg_b3"></td>
  </tr>
  <tr>
	<td class="bg_b4"></td>
	<td valign="middle">
	<div class="text_2"><%=tmessage%></div>
	<div id="divshow" runat="server">
	<table border="0" cellpadding="0" cellspacing="0" width="100%">
	<tr><td colspan="2" height="5"></td></tr>
	<tr><td colspan="2"><div id="divErrors" runat="server"></div></td></tr>
	<tr><td colspan="2" height="4"></td></tr>
	<tr class="bgtrU1"><td class="tmessage"><%=tpass %></td><td><input type="password" value="" class="tboxuser1" maxlength="15" id="txtpass" runat="server"/> (>=4)</td></tr>
	<tr><td colspan="2" height="4"></td></tr>
	<tr class="bgtrU2"><td class="tmessage"><%=tcomfirmpass%></td><td><input type="password" value="" runat="server" id="txtpass1"  maxlength="15" class="tboxuser1" /></td></tr>
	<tr><td colspan="2" height="4"></td></tr>
	<tr class="bgtrU1"><td></td><td><asp:Button runat="server" CssClass="bcart" ID="btsubmit" OnClick="btsubmit_Click"/></td></tr>
	<tr><td colspan="2" height="4"></td></tr>
	</table>
	</div>
	</td>
	<td class="bg_b5"></td>
  </tr>
  <tr>
	<td class="bg_b7" colspan="3"></td>
  </tr>
</table>