<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Articles.ascx.cs" Inherits="block_Articles" %>
<table width="100%" cellpadding="0" cellspacing="0" border="0">
  <tr>
	<td class="bg_b1"></td>
	<td class="bg_b2"><div class="text_bl"><%=tblArticle %></div></td>
	<td class="bg_b3"></td>
  </tr>
  <tr>
	<td class="bg_b4"></td>
	<td valign="top" class="text_5">
  <div style="text-align:center"><%=lgroup %></div>
  <table width="100%" border="0" cellpadding="0" cellspacing="0">
  <tr><td height="3"></td><td></td></tr>
  <tr style="background-color:#EEEEEE"><td class="text_title">&nbsp;<span  class='agroup'><%=tspecial%></span></td><td class="text_page" align="right"><%=tpage %></td></tr>
  </table>
  <%=strArticles %>
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