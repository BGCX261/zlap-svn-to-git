<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginWebsite.aspx.cs" Inherits="LoginWebsite" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Login Website</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table height="100" align="center">
    <tr><td>Website đang được phát triển. Để vào xem, xin hãy đăng nhập</td></tr>
    <tr><td height="24"><input type="text" id="txtUserName" runat="server" value="" maxlength="30" style="width:160px;"/></td></tr>
    <tr><td height="24"><input type="password" id="txtPass" runat="server" value="" maxlength="30" style="width:160px;" /></td></tr>
    <tr><td height="24"><asp:Button ID="btlogin" runat="server" Text="Đăng nhập" OnClick="btlogin_Click" /></td></tr>
    </table>
    </div>
    </form>
</body>
</html>
