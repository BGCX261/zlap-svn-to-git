<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SendContactEmail.ascx.cs" Inherits="block_SendContactEmail" %>
<table width="100%" cellpadding="0" cellspacing="0" border="0">
<tr>
  <td class="bg_b1"></td>
  <td class="bg_b2"><div class="text_bl"><%=tblsendmail %></div></td>
  <td class="bg_b3"></td>
</tr>
<tr>
  <td class="bg_b4"></td>
  <td valign="top" height="250">
  <link rel="stylesheet" type="text/css" href="template/default/css/forUser.css" />
<table width="100%" border="0" cellpadding="2" cellspacing="0">
<tr><td colspan="3" height="5"></td></tr>
<tr><td colspan="3"><div id="divErrors" runat="server"></div></td></tr>
<tr><td colspan="3" height="2"></td></tr>
<tr class="bgtrU1">
<td width='30'></td>
<td class="tmessage"><%=ttitle %> <u>*</u></td>
<td><input class="tboxuser2" type="text" runat="server" id="txtTitle" value="" maxlength="64" />
</td>
  </tr>
  <tr class="bgtrU2">
    <td></td>
    <td class="tmessage"><%=tname%> <u>*</u></td>
    <td><input class="tboxuser1" type="text" runat="server" readonly="readonly" id="txtName" value="" maxlength="128" />
    </td>
  </tr>
  <tr class="bgtrU1">
    <td></td>
    <td class="tmessage"><%=tfrom%> <u>*</u></td>
    <td><input class="tboxuser2" type="text" runat="server" readonly="readonly" id="txtEmailFrom" value="" maxlength="128" />
    </td>
  </tr>
  <tr class="bgtrU2">
    <td></td>
    <td class="tmessage"><%=tcontent%> <u>*</u></td>
    <td><textarea rows="5" runat="server" id="txtcontent" class="tboxuser2"></textarea> (>=50)</td>
  </tr>
  <tr class="bgtrU1">
    <td></td>
    <td class="tmessage"><%=tcode %></td>
    <td><img src="CreateImageCode.aspx" height='22' />
    </td>
  </tr>
  <tr class="bgtrU2">
    <td></td>
    <td class="tmessage"><%=tcode%> <u>*</u></td>
    <td><input class="tboxuser1" runat="server" id="txtcode" type="text" value="" />
    </td>
  </tr>
  <tr class="bgtrU1">
    <td></td>
    <td></td>
    <td><input type="button" id="btsend" name="btsend" class="bcart" runat="server" onserverclick="btsend_ServerClick"/></td>
  </tr>
  <tr><td colspan="3" height="5"></td></tr>
</table>
</td>
  <td class="bg_b5"></td>
</tr>
<tr>
  <td class="bg_b7" colspan="3"></td>
</tr>
</table>
<script language="javascript" type="text/javascript">
    var value="<%=currentAccess %>";
    SetCurrentAccess(value);
</script>