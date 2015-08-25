<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SendIdea.ascx.cs" Inherits="block_SendIdea" %>
<table width="100%" cellpadding="0" cellspacing="0" border="0">
<tr>
  <td class="bg_b1"></td>
  <td class="bg_b2"><div class="text_bl"><%=tblFeedback%></div></td>
  <td class="bg_b3"></td>
</tr>
<tr>
  <td class="bg_b4"></td>
  <td valign="top" height="250" style="padding:7px;">
  <link rel="stylesheet" type="text/css" href="template/default/css/forUser.css" />
  <div class="text_3"><%=tmessageInfo %></div>
  <div id="divErrors" runat="server"></div>
<div class="tdborder">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr><td colspan="2" height="3"></td></tr>
<tr class="bgtrU1"><td class="tmessage"><%=ttile %> <u>*</u></td><td><input type="text" id="txtTitle" runat="server" maxlength="80" value="" class="tboxuser2"/></td></tr>
<tr><td colspan="2" height="4"></td></tr>
<tr class="bgtrU2"><td class="tmessage"><%=tcontent%> <u>*</u></td><td><textarea rows="7" id="txtcontent" runat="server" class="tboxuser2"></textarea></td></tr>
<tr><td colspan="2" height="4"></td></tr>
<tr class="bgtrU1"><td class="tmessage"><%=tname %></td><td><input type="text" readonly="readonly" value="" id="txtName" runat="server" class="tboxuser1"/></td></tr>
<tr><td colspan="2" height="4"></td></tr>
<tr class="bgtrU2"><td class="tmessage"><%=tphone %></td><td><input type="text" readonly="readonly" value="" id="txtPhone" runat="server" class="tboxuser2"/></td></tr>
<tr><td colspan="2" height="4"></td></tr>
<tr class="bgtrU1"><td class="tmessage"><%=temail%></td><td><input type="text" value="" readonly="readonly" id="txtEmail" runat="server" class="tboxuser2"/></td></tr>
<tr><td colspan="2" height="4"></td></tr>
<tr class="bgtrU2"><td class="tmessage"></td><td><input type="button" runat="server" id="btfeedback" value="Đồng ý" class="bcart" onserverclick="btfeedback_ServerClick"/></td></tr>
</table>
</div>
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