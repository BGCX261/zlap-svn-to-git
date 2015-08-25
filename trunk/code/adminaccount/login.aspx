<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <table>
        <tr><td>Ten dang nhap</td><td><input type="text" value="" id="txtusername" runat="server" /></td></tr>
        <tr><td>mat khau</td><td><input type="password" value="" id="txtpass" runat="server" /></td></tr>
        <tr><td colspan="2"><asp:Button runat="server" ID="btlogin" Text="Dang nhap" OnClick="btlogin_Click" /></td></tr>
    </table>
    </form>
</body>
</html>
