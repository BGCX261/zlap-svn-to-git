<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginAdmin.aspx.cs" Inherits="admin_LoginAdmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="template/css/main.css" />
    <title>Administrator Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <table align="center">
            <tr>
                <td height="150">
                </td>
            </tr>
            <tr>
                <td class="btdlogin">
                    <table border="0" cellpadding="0" cellspacing="0" width="300" align="center">
                        <tr>
                            <td colspan="2" align="center" class="tlogin">
                                Đăng nhập quản trị website
                            </td>
                        </tr>
                        <tr>
                            <td height="3">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="diverror" runat="server">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td height="3">
                            </td>
                        </tr>
                        <tr>
                            <td width="90" height="28">
                                Tên đăng nhập</td>
                            <td>
                                <input type="text" value="" maxlength="20" runat="server" id="txtUserName" /></td>
                        </tr>
                        <tr>
                            <td height="28">
                                Mật khẩu</td>
                            <td>
                                <input type="password" value="" maxlength="20" runat="server" id="txtPassword" /></td>
                        </tr>
                        <tr>
                            <td height="28">
                            </td>
                            <td>
                                <asp:Button ID="btLogin" runat="server" Text="Đăng nhập" OnClick="btlogin_Click" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
