<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ClassifyProduct.ascx.cs" Inherits="block_ClassifyProduct" %>

<table width='100%' cellpadding='0' cellspacing='0'>
<tr><td class='bg_b1'></td><td class='bg_b2'><div class='text_bl'><%=bl_pro %></div></td><td class='bg_b3'></td></tr>
<tr><td class='bg_b4'></td><td class='text_2'>
<br />
<a href='default.html?menu=dasp&state=6' onmouseover='OnMOMenu(6,1,11,event);' onmouseout='TimeHidden();'><%=strphanphoi%></a> <br /><br />
<a href='default.html?menu=dasp&state=1,2,3,5' onmouseover="OnMOMenu('1,2,3,5',1,11,event);" onmouseout='TimeHidden();'><%=strnhapkhau%></a> <br /><br />
<a href='default.html?menu=product' onmouseover='OnMOMenu(0,1,11,event);' onmouseout='TimeHidden();'><%=strall%></a>
</td><td class='bg_b5'></td></tr>
<tr><td class='bg_b7' colspan='3'></td></tr>
<tr><td height='8'></td></tr></table>