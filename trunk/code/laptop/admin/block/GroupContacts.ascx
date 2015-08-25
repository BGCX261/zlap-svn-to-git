<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GroupContacts.ascx.cs" Inherits="admin_block_GroupContacts" %>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
<tr><td><input type="button" id="addnewgroup" class="button" value="Thêm nhóm" onclick="location.href='?menu=addgroupcontact';" /></td></tr>
<tr><td height="5"></td></tr>
<tr><td class="line" colspan="5"></td></tr>
<tr><td height="7"></td></tr>
</table>
<%=tableListGroup%>
