<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminWebsite.aspx.cs" Inherits="admin_AdminWebsite" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Administrator Website</title>
    <link rel="stylesheet" type="text/css" href="template/css/main.css" />
    <script src="lib/js/jscommon.js" type="text/javascript"></script>
    <script src="lib/js/jsmobile.js" type="text/javascript"></script>
    <script language="javascript" src="lib/scripts/innovaeditor.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <table align="center" width="940" cellpadding="0" cellspacing="0" border="0" height="70">
  <tr>
    <td height="5"></td>
  </tr>
  <tr>
    <td align="center" class="btdlogin"><span class="theader">Khu vực dành cho quản trị thông tin trên website</span></td>
  </tr>
</table>
<table align="center" width="940" cellpadding="0" cellspacing="0" border="0">
  <tr>
    <td width="175" height="7"></td>
    <td width="7"></td>
    <td width="758"></td>
  </tr>
  <tr>
    <td width="175" valign="top" height="500"><table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
          <td class="tbl">Quản trị thông tin sản phẩm</td>
        </tr>
        <tr>
          <td class="btdbl" valign="top">
          <span class="tfunc"><a href="?menu=imgpro">Cập nhật ảnh sản phẩm</a></span><br />
          <span class="tfunc"><a href="?menu=imgpromulti">Ảnh laptop ở góc độ khác</a></span><br />
		  <span class="tfunc"><a href="?menu=imgcom">Cập nhật ảnh linh kiên</a></span><br />
		  <span class="tfunc"><a href="?menu=pda">Cập nhật ảnh pocket pc,PDA</a></span><br />
		  <span class="tfunc"><a href="?menu=otherpro">Ảnh các sản phẩm khác</a></span><br />
		  <span class="tfunc"><a href="?menu=imgpromotion">Ảnh khuyến mãi !</a></span><br />		  
		  <span class="tfunc"><a href="?menu=promainpage">Sản phẩm ở trang chính</a></span><br />
		  <span class="tfunc"><a href="?menu=probestsell">Sản phẩm bán chạy</a></span><br />
		  <span class="tfunc"><a href="?menu=projusthave">Hàng mới về</a></span><br />
		  <span class="tfunc"><a href="?menu=original">Danh sách hàng độc</a></span><br />
		  <span class="tfunc"><a href="?menu=prepareout">Sản phẩm sắp hết hàng</a></span><br />
		  <span class="tfunc"><a href="?menu=proselloff">Hàng giảm giá</a></span><br />
		  <span class="tfunc"><a href="?menu=imgmobile">Cập nhật ảnh điện thoại</a></span><br />
		  <span class="tfunc"><a href="?menu=mobile1">Điện thoại ở trang chính</a></span><br />
		  <span class="tfunc"><a href="?menu=mobile2">Điện thoại bán chạy nhất</a></span><br />
		  <span class="tfunc"><a href="?menu=mobile3">Điện thoại độc đáo</a></span><br />
		  </td>
        </tr>
		<tr><td height="7"></td></tr>
		<tr>
          <td class="tbl">Quản trị Tin tức</td>
        </tr>
        <tr>
          <td class="btdbl" valign="top"><span class="tfunc"><a href="?menu=article">Tin tức</a></span><br /><span class="tfunc"><a href="?menu=grouparticle">Nhóm tin tức</a></span>
		  </td>
        </tr>
        <tr><td height="7"></td></tr>
		<tr>
          <td class="tbl">Quản lý thông tin liên hệ</td>
        </tr>
        <tr>
          <td class="btdbl" valign="top"><span class="tfunc"><a href="?menu=contact">Thông tin liên hệ</a></span><br /><span class="tfunc"><a href="?menu=groupcontact">Nhóm liên hệ</a></span><br />
          <span class="tfunc"><a href="?menu=locationcontact">Khu vực liên hệ</a></span>
		  </td>
        </tr>
        <tr><td height="7"></td></tr>
		<tr>
          <td class="tbl">Quản lý ngôn ngữ</td>
        </tr>
        <tr>
          <td class="btdbl" valign="top"><span class="tfunc"><a href="?menu=langcode">Từ khóa</a></span><br /><span class="tfunc"><a href="?menu=langsupport">Ngôn ngữ hỗ trợ</a></span>
		  </td>
        </tr>
        <tr><td height="7"></td></tr>
		<tr>
          <td class="tbl">Các thông tin khác</td>
        </tr>
        <tr>
          <td class="btdbl" valign="top"><span class="tfunc"><a href="?menu=advertisespecial">Quảng cáo đặc biệt</a></span><br /><span class="tfunc"><a href="?menu=help">Trợ giúp trên website</a></span><br /><span class="tfunc"><a href="?menu=linkweb">Liên kết website</a></span><br /><span class="tfunc"><a href="?menu=onlinesupport">Hỗ trợ trực tuyến</a></span><br />
          <span class="tfunc"><a href="?menu=UserManage">Cập nhật User</a></span><br />
          <span class="tfunc"><a href="?menu=currency">Thay đổi tiền tệ hiển thị</a></span><br />
          <span class="tfunc"><a href="?menu=updateUSD">Cập nhật tỷ giá USD</a></span><br />
          <span class="tfunc"><a href="?menu=downloadprice">Quản lý tải báo giá</a></span><br />
          <span class="tfunc"><a href="?menu=Editbottom">Sửa Bottom</a></span><br />
          <%--<span class="tfunc"><a href="?menu=introduce">Giới thiệu công ty</a></span>--%>
		  </td>
        </tr>
      </table></td>
    <td width="7"></td>
    <td width="758" valign="top"><table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
          <td class="tbl"><%=tblcenter %></td>
        </tr>
        <tr>
          <td class="btdbl1" height="450" valign="top"><asp:PlaceHolder runat="server" ID="plhFunc"></asp:PlaceHolder></td>
        </tr>
      </table></td>
  </tr>
</table>
</form>
</body>
</html>
