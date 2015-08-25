<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ReportPrice.ascx.cs" Inherits="block_ReportPrice" %>
<table width="100%" cellpadding="0" cellspacing="0" border="0">
<tr>
  <td class="bg_b1"></td>
  <td class="bg_b2"><div class="text_bl"><%=bldownprice %></div></td>
  <td class="bg_b3"></td>
</tr>
<tr>
  <td class="bg_b4"></td>
  <td valign="top" height="250">
  <div style="padding:7px;">
      <div class="tdborder">
        <div class="text_2"><%=tmessagedown %> <a href="data/exportprice/bao_gia_laptop.xls"><%=tdownload%></a></div>
      </div>
      <div class="tdborder">
        <div class="text_2"><%=tsendpricetoemail %></div>
        <div id="divErrors" runat="server"></div>
        <table width="100%" border="0" cellpadding="2" cellspacing="0">
        <tr class="bgtrU1">
        <td width='30'></td>
        <td class="tmessage"><%=ttitle %> <u>*</u></td>
        <td><input class="tboxuser2" type="text" runat="server" id="txtTitle" value="" maxlength="64" />
        </td>
          </tr>
          <tr class="bgtrU2">
            <td></td>
            <td class="tmessage"><%=temailFrom %> <u>*</u></td>
            <td><input class="tboxuser2" type="text" runat="server" id="txtEmailFrom" value="" maxlength="128" />
            </td>
          </tr>
          <tr class="bgtrU1">
            <td></td>
            <td class="tmessage"><%=temailTo %> <u>*</u></td>
            <td><input class="tboxuser2" type="text" runat="server" id="txtEmailTo" value="" maxlength="128" />
            </td>
          </tr>
          <tr class="bgtrU2">
            <td></td>
            <td class="tmessage"><%=tinfor%></td>
            <td><textarea rows="5" runat="server" id="txtareamore" class="tboxuser2"></textarea></td>
          </tr>
		  <tr class="bgtrU1">
            <td></td>
            <td class="tmessage"><%=tcode %></td>
            <td><img src="CreateImageCode.aspx" height='26' />
            </td>
          </tr>
		  <tr class="bgtrU2">
            <td></td>
            <td class="tmessage"><%=tconfirmcode %> <u>*</u></td>
            <td><input class="tboxuser1" runat="server" id="txtcode" type="text" value="" />
            </td>
          </tr>
          <tr class="bgtrU1">
            <td></td>
            <td></td>
            <td><div style="padding-top:3px;">
                <input type="button" value="Submit" id="btsend" name="btsend" class="bcart" runat="server" onserverclick="btsend_ServerClick"/>
              </div></td>
          </tr>
        </table>
      </div>
    </div></td>
  <td class="bg_b5"></td>
</tr>
<tr>
  <td class="bg_b7" colspan="3"></td>
</tr>
</table>
<script language="javascript" type="text/javascript">
    var value="<%=tCurrentAccess %>";
    SetCurrentAccess(value);
</script>