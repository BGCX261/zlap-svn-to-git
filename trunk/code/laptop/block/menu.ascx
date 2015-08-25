<%@ Control Language="C#" AutoEventWireup="true" CodeFile="menu.ascx.cs" Inherits="block_menu" %>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr class="bg_menu">
  <td align="center" width="91%"><table border="0" cellpadding="0" cellspacing="0">
      <tr>
        <td class="text_menu"><a href="default.html"><%=home %></a></td>
        <td class="bg_line1"></td>
        <%--<td class="text_menu"><a href="/DTDD"><%=tmobile %></a></td>
        <td class="bg_line1"></td>--%>
        <td class="text_menu"><a href="default.html?menu=product"><%=product %></a></td>
        <td class="bg_line1"></td>
        <td class='text_menu'><a href='default.html?menu=nh'><%=tnewhave%> <img src='image/common/hot.gif' border='0'/></a></td>
        <td class="bg_line1"></td>
        <td class='text_menu'><a href='default.html?menu=originalpro'><%=loriginal%> <img src='image/common/hot.gif' border='0'/></a></td>
        <td class='bg_line1'></td>
        <td class='text_menu'><a href='default.html?menu=wh'><%=twillhave%> <img src='image/common/hot.gif' border='0'/></a></td>
        <td class='bg_line1'></td>
        <td class="text_menu"><a href="default.html?menu=article"><%=article %></a></td>
        <td class="bg_line1"></td>
        <td class='text_menu'><a href="default.html?menu=contact"><%=contact %></a></td>
        <td class='bg_line1'></td>
        <%=download %>
        <td class="text_menu"><a href="default.html?menu=help"><%=help %></a></td>
      </tr>
    </table></td>
  <td  width="9%" class="text_lang"><%=flag %></td>
</tr>
</table>