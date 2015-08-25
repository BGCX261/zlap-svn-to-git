<%@ Control Language="C#" AutoEventWireup="true" CodeFile="menu.ascx.cs" Inherits="block_menu" %>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr class="bg_menu">
  <td align="center" width="89%"><table border="0" cellpadding="0" cellspacing="0">
      <tr>
        <td class="text_menu"><a href="Default.aspx"><%=home %></a></td>
        <td class="bg_line1"></td>
        <td class="text_menu"><a href="?menu=product"><%=product %></a></td>
        <td class="bg_line1"></td>
        <td class='text_menu'><a href='?menu=nh'><%=tnewhave%> <img src='image/common/hot.gif' border='0'/></a></td>
        <td class="bg_line1"></td>
        <td class='text_menu'><a href='?menu=originalpro'><%=loriginal%> <img src='image/common/hot.gif' border='0'/></a></td>
        <td class='bg_line1'></td>
        <td class='text_menu'><a href='?menu=wh'><%=twillhave%> <img src='image/common/hot.gif' border='0'/></a></td>
        <td class='bg_line1'></td>
        <td class="text_menu"><a href="?menu=article"><%=article %></a></td>
        <td class="bg_line1"></td>
        <td class="text_menu"><a href="?menu=contact"><%=contact %></a></td>
        <td class="bg_line1"></td>
        <td class="text_menu"><a href="?menu=price"><%=download %></a></td>
        <td class="bg_line1"></td>
        <td class="text_menu"><a href="?menu=help"><%=help %></a></td>
      </tr>
    </table></td>
  <td  width="11%" class="text_lang"><%=flag %></td>
</tr>
</table>