<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserEdit.ascx.cs" Inherits="admin_block_UserEdit" %>
<table cellpadding="0" cellspacing="0" border="0" align="center" width="600">
    <tr>
        <td colspan="2" class="title2">
            Nhập thông User</td>
    </tr>
    <tr>
        <td colspan="2" style="height: 2px">
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <div id="diverror" runat="server">
            </div>
        </td>
    </tr>
    <tr>
        <td colspan="2" height="2">
        </td>
    </tr>
    <tr class="bgtr">
        <td width="120" class="title3">
            Tài khoản <u>*</u></td>
        <td>
            <input type="text" id="txtUserName" runat="server" maxlength="128" class="txtbox1" /></td>
    </tr>
    <tr>
        <td colspan="2" height="5">
        </td>
    </tr>
    <tr>
        <td class="bgtr">
            Mật khẩu</td>
        <td>
            <input type="password" id="txtPassword" runat="server" maxlength="128" class="txtbox1" /></td>
    </tr>
    <tr>
        <td colspan="2" height="5">
        </td>
    </tr>
    <tr>
        <td class="bgtr">
            Nhập lại mật khẩu</td>
        <td>
            <input type="password" id="txtPassword1" runat="server" maxlength="128" class="txtbox1" /></td>
    </tr>
    <tr>
        <td colspan="2" height="5">
        </td>
    </tr>
    <tr>
        <td style="height: 24px">
        </td>
        <td style="height: 24px">
            <input type="button" id="btnedit" runat="server" class="button" value="Chỉnh sửa"
                onserverclick="btnedit_Click" />
            <input type="button" id="btnback" name="btnback" class="button" runat="server" value="Quay lại"
                onserverclick="btnback_Click" /></td>
    </tr>
</table>
