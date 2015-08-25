<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>MayTinhXachTay.com, điện thoại di động</title>
    <meta name="description" content="dien thoai di dong, dien thoai, the gioi di dong, the gioi dien thoai, điện thoại di động, điện thoại, thế giới di động, thế giới điện thoại." />
  	<meta name="keywords" content="dien thoai di dong, dien thoai, the gioi di dong, the gioi dien thoai, điện thoại di động, điện thoại, thế giới di động, thế giới điện thoại." />
	<meta content="Nguyen ngọc, Dien Tu Sai Gon, Vietnam, Hanoi, Sai gon, May tinh xach tay, laptop, PDA, 270 dao duy anh, 236 cao thang, 97 kim nguu, 270 dào duy anh, 236 cao thắng, 97 kim ngưu" name="page-topic"/>
	<meta name="author" content="Nguyen Ngoc Ltd , HA NOI, VIET NAM" />
	<meta name="copyright" content="Nguyen Ngoc, Dien Tu Sai Gon Ltd , HA NOI, VIET NAM" />
	<meta name="EMail" content="maytinhxachtay@maytinhxachtay.com"/>
    <link rel="stylesheet" type="text/css" href="template/blue/main.css" />
    <link rel="stylesheet" type="text/css" href="template/blue/forUser.css" />
    <script src="lib/js/funccommon.js" type="text/javascript"></script>
    <script src="lib/js/funcshowdiv.js" type="text/javascript"></script>
    <script src="lib/js/controladvertise.js" type="text/javascript"></script>
</head>
<body>
<form id="frmmain" runat="server" method="post">
<asp:PlaceHolder ID="plhheader" runat="server"></asp:PlaceHolder>
<table border="0" cellpadding="0" cellspacing="0" width="940" align="center">
<tr><td height="29" align="center"><div class="txt6" id="currentAccess"></div></td></tr>
</table>
  <table border="0" cellpadding="0" cellspacing="0" width="940" align="center">
    <tr>
      <td width="175" valign="top"><asp:PlaceHolder ID="plhleft" runat="server"></asp:PlaceHolder></td>
      <td width="8"></td>
      <td width="574" valign="top"><asp:PlaceHolder ID="plhcenter" runat="server"></asp:PlaceHolder></td>
      <td width="8"></td>
      <td width="175" valign="top"><asp:PlaceHolder ID="plhright" runat="server"></asp:PlaceHolder></td>
    </tr></table>
  <%=footer%>
<div class="divol" style="cursor:pointer;" id="divLink" onmouseover="ShowValue1();" onmouseout="isOutLink();"><img src="image/common/linkmenu1.png" /></div>
<script language="javascript" type="text/javascript">
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
var isContentLink=false;
var timeOutLink=null;
function ShowValue1()
{
    var len=document.getElementById("divLink").innerHTML.length;
    if(len<100)
    {
        document.getElementById("divLink").innerHTML="<div class='dlink'><table><tr><td><a href='Default.aspx'><img src='image/common/mobile.png' border='0' /></a></td><td><a href='../Default.aspx'><img src='image/common/linklaptop.jpg' border='0' /></a></td></tr><tr align='center' class='txt2'><td><a href='Default.aspx'>Điện thoại di động</a></td><td><a href='../Default.aspx'>Máy Tính xách tay</a></td></tr></table></div>";
    }
    isContentLink=true;
}
function isOutLink()
{
    isContentLink=false;
    clearTimeout(timeOutLink);
    timeOutLink=setTimeout("ClearValue()",400);
}
function ClearValue()
{
    if(isContentLink==false)
    {
        document.getElementById("divLink").innerHTML="<img src='image/common/linkmenu1.png' />";
    }
}
</script>
</form>
</body>
</html>