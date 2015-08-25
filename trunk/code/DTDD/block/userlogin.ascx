<%@ Control Language="C#" AutoEventWireup="true" CodeFile="userlogin.ascx.cs" Inherits="block_userlogin" %>
<table width="100%" cellpadding="0" cellspacing="0">
  <tr>
    <td class="bgtl1"></td>
    <td class="bgtc1" width="149" style="cursor:pointer;" onclick="ShowLogin();"><%=blUser %></td>
    <td class="bgtr1"></td>
  </tr>
  <tr>
  <td height="2"></td>
</tr>
  <tr>
    <td align="center" class="bgcl1" colspan="3">
    <div id="divfrmLogin" style="display:none;">
        <div class="divw" id="divWLogin" style="display:none;"></div>
        <input type="text" id="textuser" value="" class="tb1" onfocus="this.value='';" />
        <div class="h1"></div>
        <input type="password" id="textpass" value=""  class="tb1" onkeydown="OnEnterSend(event,'divlogin');" onfocus="this.value='';" />
        <div class="h1"></div>
        <div class="bt2" id="divlogin" onclick="WaitLogin();"><%=tbutton %></div>
        <div class="h1"></div>
        <div align="left">
        - <a href="?menu=forgotPass"><%=tforgotpass %></a><br />
        - <a href="?menu=register"><%=tnewmember %></a>
        </div>
    </div></td>
  </tr>
  <tr>
    <td height="8"></td>
  </tr>
</table>