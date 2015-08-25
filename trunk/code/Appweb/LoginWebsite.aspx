<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginWebsite.aspx.cs" Inherits="LoginWebsite" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Login Web Application</title>
    <link rel="stylesheet" type="text/css" href="template/main.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptLogin" runat="server" />
    <table border="0" cellpadding="0" cellspacing="0" width="400" align="center">
      <tr>
        <td height="160"></td>
      </tr>
      <tr>
        <td>
        <asp:UpdatePanel ID="updateLogin" runat="server">
        <ContentTemplate>
        <table border="0" cellpadding="0" cellspacing="0" width="400" align="center" class="bgcolor5">
            <tr>
              <td colspan="2" height="30" class="txt1" align="center">Xin mời đăng nhập ( IP: <span class='txtred'><%=strIP%> </span> )</td>
            </tr>
            <tr><td colspan="2">
            <div id="divErrors" class="txterr1" runat="server"></div>
            </td></tr>
            <tr height="27">
              <td width="110">Tên đăng nhập</td>
              <td><input type="text" id="txtUser" class="tb1" runat="server" /></td>
            </tr>
            <tr height="27">
              <td>Mật khẩu</td>
              <td><input type="password" id="txtPass" class="tb1" runat="server" /></td>
            </tr>
            <tr height="32">
              <td></td>
              <td><asp:Button ID="btLogin" runat="server" Text="Đăng nhập" OnClick="btLogin_Click" /></td>
            </tr>
          </table>
          </ContentTemplate>
          </asp:UpdatePanel>
        </td>
      </tr>
    </table>
    </form>
</body>
</html>
