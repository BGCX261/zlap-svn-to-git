<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FuncUser.ascx.cs" Inherits="block_FuncUser" %>
<table width="100%" cellpadding="0" cellspacing="0">
  <tr>
    <td class="bg_b1"></td>
    <td class="bg_b2"><div class="text_bl"><%=thello%></div></td>
    <td class="bg_b3"></td>
  </tr>
  <tr>
    <td class="bg_b4"></td>
    <td align="left">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
	<tr><td class="tname"><%=name %></td></tr>
	<tr><td class="text_b2"><%=functions %></td></tr>
	<tr><td class="func">
	<a href="?menu=changeaccount"><%=tminformation %></a><br />
	<a href="?menu=manageorder"><%=tmorder %></a><br />
	<a href="?menu=sendemail"><%=tsendcontact %></a><br />
	<a href="?menu=feedback"><%=tfeedback %></a><br />
	<a href="#" onclick="UserLogin(2);"><%=tlogout %></a>
	</td></tr>
	</table>
    </td>
    <td class="bg_b5"></td>
  </tr>
  <tr>
    <td class="bg_b7" colspan="3"></td>
  </tr>
  <tr>
    <td height="7"></td>
  </tr>
</table>