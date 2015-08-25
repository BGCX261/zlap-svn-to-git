<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RegistUser.ascx.cs" Inherits="block_RegistUser" %>
<table width="100%" cellpadding="0" cellspacing="0" border="0">
    <tr>
      <td class="bg_b1"></td>
      <td class="bg_b2"><div class="text_bl"><%=tblregister %></div></td>
      <td class="bg_b3"></td>
    </tr>
    <tr>
      <td class="bg_b4"></td>
      <td valign="top">
        <table border="0" cellpadding="0" cellspacing="0" width="100%" align="left">
          <tr>
            <td colspan="2" height="5"></td>
          </tr>
          <tr>
            <td colspan="2" class="treg"><%=mtitle %></td>
          </tr>
          <tr>
            <td colspan="2" height="3"></td>
          </tr>
		  <tr>
            <td colspan="2"><div id="divErrors" runat="server"></div></td>
          </tr>
		  <tr>
            <td colspan="2" height="2"></td>
          </tr>
          <tr class="bgtrU1">
            <td class="tmessage"><%=tusername %> <u>*</u></td>
            <td><input type="text" value="" runat="server" id="txtusername"  maxlength="20" class="tboxuser1" /> (a-z and A-Z)</td>
          </tr>
          <tr class="bgtrU2">
            <td class="tmessage"><%=tpass1 %> <u>*</u></td>
            <td><input type="password" value="" runat="server" id="txtpass"  maxlength="15" class="tboxuser1" /> (>=4)</td>
          </tr>
          <tr class="bgtrU1">
            <td class="tmessage"><%=tpass2 %> <u>*</u></td>
            <td><input type="password" value="" id="txtpass1"  runat="server" maxlength="15" class="tboxuser1" /></td>
          </tr>
          <tr class="bgtrU2">
            <td class="tmessage"><%=tname %> <u>*</u></td>
            <td><input type="text" value="" runat="server" id="txtname" maxlength="30" class="tboxuser1" /></td>
          </tr>
          <tr class="bgtrU1">
            <td class="tmessage"><%=tjob %></td>
            <td><input type="text" value="" runat="server" id="txtjobtitle"  maxlength="100" class="tboxuser2" /></td>
          </tr>
          <tr class="bgtrU2">
            <td class="tmessage"><%=temail %> <u>*</u></td>
            <td><input type="text" value="" runat="server" id="txtemail" maxlength="50" class="tboxuser2" /></td>
          </tr>
          <tr class="bgtrU1">
            <td class="tmessage"><%=tmobile %></td>
            <td><input type="text" value="" runat="server" id="txtmobile"  maxlength="20" class="tboxuser1" /></td>
          </tr>
          <tr class="bgtrU2">
            <td class="tmessage"><%=thome %></td>
            <td><input type="text" value="" runat="server" id="txthomephone" maxlength="20" class="tboxuser1" /></td>
          </tr>
          <tr class="bgtrU1">
            <td class="tmessage"><%=taddress %> <u>*</u></td>
            <td><input type="text" value="" runat="server" id="txtaddress" maxlength="100" class="tboxuser2" /></td>
          </tr>
          <tr class="bgtrU2">
            <td class="tmessage"><%=tcode1 %></td>
            <td><img src="CreateImageCode.aspx" height="22" width="90" /></td>
          </tr>
          <tr class="bgtrU1">
            <td class="tmessage"><%=tcode2 %> <u>*</u></td>
            <td><input type="text" value="" runat="server" id="txtcoderegister"  maxlength="20" class="tboxuser1" /></td>
          </tr>
		  <tr>
            <td colspan="2"  height="32" align="center" class="text_2"><input type="button" value="Submit" id="register" runat="server" onserverclick="register_Click"></td>
          </tr>
        </table></td>
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
