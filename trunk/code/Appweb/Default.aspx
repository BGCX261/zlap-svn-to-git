<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Playing Games 1.0 ( update: 31/08/2009 )</title>
    <link rel="stylesheet" type="text/css" href="template/main.css" />
    <link rel='stylesheet' type='text/css' href='template/csslich/csslich.css' />
    <script src="lib/js/funccommon.js" type="text/javascript"></script>
    <script src="lib/js/funcMenu.js" type="text/javascript"></script>
    <script src="lib/js/TimeChoice.js" type="text/javascript"></script>
</head>
<body>
    <form id="formmain" runat="server">
    <asp:ScriptManager ID="ScriptDefault" runat="server" />
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
    <td class="bgcolor1" colspan="3" height="30">
        <asp:PlaceHolder ID="plhHeader" runat="server"></asp:PlaceHolder>
    </td>
    </tr>
    <tr><td height="2" colspan="3"></td></tr>
    <tr>
        <td width="190" valign="top" class="bgcolor2" height="570">
        <asp:PlaceHolder ID="plhLeft" runat="server"></asp:PlaceHolder>
        </td>
        <td width="1"></td>
        <td valign="top" class="bgcolor3" align="left">
        <asp:PlaceHolder ID="plhCenter" runat="server"></asp:PlaceHolder>
        </td>
    </tr>
    <tr>
    <td colspan="3" class="bgcolor4" align="center">***</td>
    </tr>
    </table>
    </form>
</body>
</html>