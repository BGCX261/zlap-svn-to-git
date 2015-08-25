<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleDetail.ascx.cs" Inherits="block_ArticleDetail" %>
<table width='100%' cellpadding='0' cellspacing='0' border='0'>
<tr>
  <td class='bg_b1'></td>
  <td class='bg_b2'><div class='text_bl'><%=tblArticle %></div></td>
  <td class='bg_b3'></td>
</tr>
<tr>
  <td class='bg_b4'></td>
  <td valign='top'><div class='text_5'>
	  <table width='100%' cellpadding='0' cellspacing='0' border='0'>
		<tr>
		  <td colspan='2' height='5'></td>
		</tr>
		<tr>
		  <td colspan='2' class='text_title'><%=title %></td>
		</tr>
		<tr>
		  <td valign='middle' width='150'><img width='140' height='90' src='<%=urlImage %>'/></td>
		  <td class='text_2' align="justify"><%=sumarticle %></td>
		</tr>
		<tr><td colspan='2' height='7'></td></tr>
		<tr><td colspan='2' align="justify"><%=content %></td></tr>
		<tr><td height='10'></td></tr>
		<tr><td height='24' colspan='2' align='right' class='text_2'><a href="#" onclick='back();'>Quay lại</a></td></tr>
		<tr><td colspan='2' class='bg_line2'></td></tr>
		<tr><td height='5'></td></tr>
	  </table>
	  </div>
	  <div  class='agroup'><%=groupName%></div>
	  <div style='padding-left:40px;line-height:20px;'><% =listTitle%></div>
	  </td>
  <td class='bg_b5'></td>
</tr>
<tr>
  <td class='bg_b7' colspan='3'></td>
</tr>
</table>
<script language="javascript" type="text/javascript">
    var value="<%=currentAccess %>";
    SetCurrentAccess(value);
</script>