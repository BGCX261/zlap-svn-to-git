<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RptProductPrice.ascx.cs" Inherits="block_RptProductPrice" %>
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
  <td class="bgcl4">
  <asp:DropDownList runat="server" ID="slProductType">
  </asp:DropDownList> <asp:Button ID="tbReport" runat="server" CssClass="bt1" Text="Hiển Thị" OnClick="tbReport_click" />
  <div style="height:4px;"></div>
    <rsweb:ReportViewer ID="rptProductPrice" runat="server" Width="100%">
        </rsweb:ReportViewer>
        <div>
        <%=strError %>
        </div>
  </td>
  </tr>
  </table>