<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title><%=myTitle %></title>
  	<meta name="keywords" content="<%=myKey %>" />
	<meta name="description" content="<%=myKey %>" />
	<meta content="Dien Tu Sai Gon, Vietnam, Hanoi, Sai gon, May tinh xach tay, laptop, PDA, 270 dao duy anh, 236 cao thang, 270 dào duy anh, 236 cao thắng" name="page-topic"/>
	<meta name="author" content="may tinh xach tay , HA NOI, VIET NAM" />
	<meta name="copyright" content="Dien Tu Sai Gon Ltd , HA NOI, VIET NAM" />
	<meta name="EMail" content="maytinhxachtay@maytinhxachtay.com"/>
    <link rel="stylesheet" type="text/css" href="template/default/css/main.css" />
    <link rel="stylesheet" type="text/css" href="template/default/css/forUser.css" />
    <script src="lib/js/funccommon.js" type="text/javascript"></script>
    <script src="lib/js/funcshowdiv.js" type="text/javascript"></script>
    <script src="lib/js/controladvertise.js" type="text/javascript"></script>
    <script src="lib/js/funcMenu.js" type="text/javascript"></script>
</head>
<body>
<form id="frmmain" runat="server" method="post">
<table border="0" cellpadding="0" cellspacing="0" width="940" align="center" bgcolor="#FFFFFF">
  <tr><td height='7'></td></tr>
  <tr>
  <td height='127' valign="top">
    <asp:PlaceHolder ID="plhheader" runat="server"></asp:PlaceHolder>
  </td>  
  </tr>
  <tr>
  <td>
    <asp:PlaceHolder ID="plhmenu" runat="server"></asp:PlaceHolder>
  </td>  
  </tr>
  <tr>
    <td height="2" bgcolor="#E1E1E1"></td>
  </tr>
  <tr>
  <td>
  <asp:PlaceHolder ID="plhsearchmenu" runat="server"></asp:PlaceHolder>
  </td>  
  </tr>
    <tr>
    <td height="12"></td>
  </tr>
  </table>
<table border="0" cellpadding="0" cellspacing="0" width="940" align="center" bgcolor="#FFFFFF">
    <tr>
      <td width="175" valign="top"><asp:PlaceHolder ID="plhleft" runat="server"></asp:PlaceHolder></td>
      <td width="8"></td>
      <td width="574" valign="top"><asp:PlaceHolder ID="plhcenter" runat="server"></asp:PlaceHolder></td>
      <td width="8"></td>
      <td width="175" valign="top"><asp:PlaceHolder ID="plhright" runat="server"></asp:PlaceHolder></td>
    </tr>
  </table>
    <%=footer%>
<div class="divonline" id="divonline"><a href="#online"><img alt="Xin Click vào đây để được tư vấn mua hàng" src="image/common/online.png" style="border:0px;" /></a></div>
<%--<div class="divonline" style="cursor:pointer;" id="divLink" onmouseover="ShowValue1();" onmouseout="isOutLink();"><img alt="" src="image/common/linkmenu1.png" /></div>--%>
<script language="javascript" type="text/javascript">
var ObjDiv=new ObjAdvertise('divonline',900,1000,135,70);
ObjDiv.fnOnStart();
ObjDiv.fnRepeat();
var N=(document.all) ? 0 : 1;
var width=0;
var height=0;
if(N)
{
    var widthW=window.innerWidth;
    width=widthW-1;
    var clientHeight=window.innerHeight;
    height=clientHeight/2 + 45;
}
else
{
    var widthW=document.body.offsetWidth;
    width=widthW-1;
    var clientHeight=document.documentElement.clientHeight;
    height=clientHeight/2 + 45;
}
var ObjLink=new ObjAdvertise('divLink',0,0,width,height);
ObjLink.fnOnStart();
ObjLink.fnRepeat();
</script>
</form>
<script type="text/javascript">
var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
</script>
<script type="text/javascript">
var pageTracker = _gat._getTracker("UA-4409064-1");
pageTracker._initData();
pageTracker._trackPageview();
</script>
</body>
</html>