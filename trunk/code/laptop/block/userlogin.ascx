<%@ Control Language="C#" AutoEventWireup="true" CodeFile="userlogin.ascx.cs" Inherits="block_userlogin" %>
<table width="100%" cellpadding="0" cellspacing="0">
  <tr>
    <td class="bg_b1"></td>
    <td class="bg_b2"><div class="text_bl" style="cursor:pointer;" onclick="ShowLogin();"><%=blUser %></div></td>
    <td class="bg_b3"></td>
  </tr>
  <tr>
    <td class="bg_b4"></td>
    <td align="center"><div id="divfrmLogin" style="display:none;"><table border="0" cellpadding="0" cellspacing="0">
        <tr>
          <td height="3"></td>
        </tr>
        <tr>
          <td align="left"><div class="divw" id="divWLogin" style="display:none;"></div></td>
        </tr>
        <tr>
          <td><input type="text" id="textuser" value="" class="text_box2" onfocus="this.value='';" />
          </td>
        </tr>
        <tr>
          <td height="3"></td>
        </tr>
        <tr>
          <td><input type="password" id="textpass" value=""  class="text_box2" onkeydown="OnEnterSend(event,'divlogin');" onfocus="this.value='';" />
          </td>
        </tr>
        <tr>
          <td align="right" class="text_5"><div class="button3" id="divlogin" onclick="WaitLogin();"><%=tbutton %></div></td>
        </tr>
        <tr>
          <td class="text_4" align="left"><a href="?menu=forgotPass"><%=tforgotpass %></a></td>
        </tr>
        <tr>
          <td height="3"></td>
        </tr>
        <tr>
          <td class="text_4" align="left"><a href="?menu=register"><%=tnewmember %></a></td>
        </tr>
        <tr>
          <td height="4"></td>
        </tr>
      </table></div></td>
    <td class="bg_b5"></td>
  </tr>
  <tr>
    <td class="bg_b7" colspan="3"></td>
  </tr>
  <tr>
    <td height="8"></td>
  </tr>
</table>