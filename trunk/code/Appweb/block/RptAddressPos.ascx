<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RptAddressPos.ascx.cs" Inherits="block_RptAddressPos" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
  <td class="bgtl3"></td>
  <td class="bgtc3"><%=titleBlock %></td>
  <td class="bgtr3"></td>
</tr>
</table>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
  <td class="bgcl4" height="520" valign="top">
  Chọn điểm bán hàng: <asp:DropDownList runat="server" ID="slPos">
  </asp:DropDownList> <asp:Button ID="tbReport" runat="server" CssClass="bt1" Text="Hiển Thị" OnClick="tbReport_click" />
  <div style="height:4px;"></div>
    <rsweb:ReportViewer ID="rptView" runat="server" Width="100%">
        </rsweb:ReportViewer>
  </td>
  </tr>
  </table>