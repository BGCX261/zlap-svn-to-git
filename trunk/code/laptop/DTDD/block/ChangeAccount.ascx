<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChangeAccount.ascx.cs" Inherits="block_ChangeAccount" %>
<table width="100%" cellpadding="0" cellspacing="0" border="0">
    <tr>
      <td class="bg_b1"></td>
      <td class="bg_b2"><div class="text_bl"><%=tblchange %></div></td>
      <td class="bg_b3"></td>
    </tr>
    <tr>
      <td class="bg_b4"></td>
      <td height="450" valign="top">
        <table border="0" cellpadding="0" cellspacing="0" width="100%" align="left">
          <tr>
            <td colspan="2" height="5"></td>
          </tr>
          <tr>
            <td colspan="2" class="treg"><%=taccount%>:</td>
          </tr>
          <tr>
            <td colspan="2" height="2"></td>
          </tr>
          <tr>
            <td colspan="2"><div class="diverror" runat="server" id="diverror1"></div></td>
          </tr>
          <tr>
            <td colspan="2" height="2"></td>
          </tr>
		  <tr class="bgtrU1">
            <td class="tmessage"><%=tusername %> <u>*</u></td>
            <td><input type="text" value=""  maxlength="64" readonly="readonly" class="tboxuser1" id="txtusername" runat="server" /></td>
          </tr>
          <tr class="bgtrU2">
            <td class="tmessage"><%=tpass1 %> <u>*</u></td>
            <td><input type="password" value=""  maxlength="15" class="tboxuser1" id="txtpass1" runat="server" />
              (>=4)</td>
          </tr>
          <tr class="bgtrU1">
            <td class="tmessage"><%=tpass2 %> <u>*</u></td>
            <td><input type="password" value=""  maxlength="15" class="tboxuser1" id="txtpass2" runat="server" /></td>
          </tr>
          <tr class="bgtrU2">
            <td></td>
            <td align="left"><input type="button" id="buttonpass" runat="server"  class="bcart" onserverclick="changepass_Click"/></td>
          </tr>
		  <tr><td colspan="2" class="td_line"></td></tr>
          <tr>
            <td colspan="2" class="treg"><%=taccountinfo %>:</td>
          </tr>
		  <tr>
            <td colspan="2"><div class="diverror" runat="Server" id="diverror2"></div></td>
          </tr>
          <tr>
            <td colspan="2" height="2"></td>
          </tr>
          <tr class="bgtrU1">
            <td class="tmessage"><%=tname %> <u>*</u></td>
            <td><input type="text" value="" maxlength="64" class="tboxuser1" runat="server" id="txtname" /></td>
          </tr>
          <tr class="bgtrU2">
            <td class="tmessage"><%=tcompany %></td>
            <td><input type="text" value=""  maxlength="128" class="tboxuser2" runat="server" id="txtcompany" /></td>
          </tr>
          <tr class="bgtrU1">
            <td class="tmessage"><%=tjob %></td>
            <td><input type="text" value=""  maxlength="128" class="tboxuser2" runat="server" id="txtjob" /></td>
          </tr>
          <tr class="bgtrU2">
            <td class="tmessage"><%=tmobile %></td>
            <td><input type="text" value=""  maxlength="20" class="tboxuser1" runat="server" id="txtmobile" /></td>
          </tr>
          <tr class="bgtrU1">
            <td class="tmessage"><%=toffice %></td>
            <td><input type="text" value=""  maxlength="20" class="tboxuser1" runat="server" id="txtoffice" /></td>
          </tr>
          <tr class="bgtrU2">
            <td class="tmessage"><%=thomephone %></td>
            <td><input type="text" value=""  maxlength="20" class="tboxuser1" runat="server" id="txthome" /></td>
          </tr>
          <tr class="bgtrU1">
            <td class="tmessage"><%=temail1 %> <u>*</u></td>
            <td><input type="text" value="" readonly="readonly"  maxlength="128" class="tboxuser2" id="txtemail1" runat="server"/></td>
          </tr>
          <tr class="bgtrU2">
            <td class="tmessage"><%=temail2 %></td>
            <td><input type="text" value=""  maxlength="128" class="tboxuser2" runat="server" id="txtemail2" /></td>
          </tr>
          <tr class="bgtrU1">
            <td class="tmessage"><%=tfax %></td>
            <td><input type="text" value=""  maxlength="20" class="tboxuser1" runat="server" id="txtfax" /></td>
          </tr>
          <tr class="bgtrU2">
            <td class="tmessage"><%=ttax %></td>
            <td><input type="text" value=""  maxlength="20" class="tboxuser1" runat="server" id="txttax" /></td>
          </tr>
          <tr class="bgtrU1">
            <td class="tmessage">Website</td>
            <td><input type="text" value="" maxlength="128" class="tboxuser2" runat="server" id="txtwebsite" /></td>
          </tr>
          <tr class="bgtrU2">
            <td></td>
            <td align="left"><input type="button" value="" class="bcart" runat="server" id="buttoninfor" onserverclick="changeinfo_Click" /></td>
          </tr>
          <tr>
            <td colspan="2" height="1" class="td_line"></td>
          </tr>
          <tr>
            <td colspan="2" class="treg"><%=tbilling %></td>
          </tr>
		  <tr>
            <td colspan="2"><div class="diverror" id="diverror3" runat="server"></div></td>
          </tr>
          <tr>
            <td colspan="2" height="2"></td>
          </tr>
          <tr class="bgtrU1">
            <td class="tmessage"><%=taddress %> <u>*</u></td>
            <td><input type="text" value=""  maxlength="255" class="tboxuser2" runat="server" id="txtaddressbill" /></td>
          </tr>
          <tr class="bgtrU2">
            <td class="tmessage"><%=tcity %> </td>
            <td><input type="text" value=""  maxlength="30" class="tboxuser1" runat="server" id="txtcitybill" /></td>
          </tr>
          <tr class="bgtrU1">
            <td class="tmessage"><%=tzipcode %></td>
            <td><input type="text" value=""  maxlength="20" class="tboxuser1" runat="server" id="txtzipcodebill" /></td>
          </tr>
          <tr class="bgtrU2">
            <td class="tmessage"><%=tcountry %> </td>
            <td><input type="text" value=""  maxlength="30" class="tboxuser1" runat="server" id="txtcountrybill" /></td>
          </tr>
          <tr class="bgtrU1">
            <td></td>
            <td align="left"><input type="button" value="" class="bcart" runat="server" id="buttonbilling" onserverclick="changeBilling_Click"/></td>
          </tr>
		  <tr>
            <td colspan="2" class="treg"><%=tshipping %></td>
          </tr>
		  <tr>
            <td colspan="2"><div class="diverror" id="diverror4" runat="server"></div></td>
          </tr>
          <tr>
            <td colspan="2" height="2"></td>
          </tr>
          <tr class="bgtrU1">
            <td class="tmessage"><%=taddress %> <u>*</u></td>
            <td><input type="text" value=""  maxlength="255" class="tboxuser2" runat="server" id="txtaddressship" /></td>
          </tr>
          <tr class="bgtrU2">
            <td class="tmessage"><%=tcity %></td>
            <td><input type="text" value=""  maxlength="30" class="tboxuser1" runat="server" id="txtcityship" /></td>
          </tr>
          <tr class="bgtrU1">
            <td class="tmessage"><%=tzipcode%></td>
            <td><input type="text" value=""  maxlength="20" class="tboxuser1" runat="server" id="txtzipcodeship" /></td>
          </tr>
          <tr class="bgtrU2">
            <td class="tmessage"><%=tcountry%></td>
            <td><input type="text" value=""  maxlength="30" class="tboxuser1" runat="server" id="txtcountryship" /></td>
          </tr>
          <tr class="bgtrU1">
            <td></td>
            <td align="left"><input type="button" value="" class="bcart" runat="server" id="buttonship" onserverclick="changeShipping_Click"/></td>
          </tr>
		  <tr><td colspan="2" height="7"></td></tr>
        </table></td>
      <td class="bg_b5"></td>
    </tr>
    <tr>
      <td class="bg_b7" colspan="3"></td>
    </tr>
  </table>
  <script language="javascript" type="text/javascript">
    var value="<%=currentAccess %>";
    SetCurrentAccess(value);
</script>