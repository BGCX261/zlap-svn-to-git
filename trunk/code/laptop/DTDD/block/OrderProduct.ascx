<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OrderProduct.ascx.cs" Inherits="block_OrderProduct" %>
<asp:PlaceHolder ID="plhTop" runat="server"></asp:PlaceHolder>
<div class="text_3"><%=tmessageinfo %></div>
<div id="divErrors" runat="server"></div>
<div class="tdborder">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr><td colspan="2" height="3"></td></tr>
<tr><td class="tmessage"><%=tname %> <u>*</u></td><td><input type="text" value="" runat="server" id="txtname" class="tboxuser1"/></td></tr>
<tr><td colspan="2" height="4"></td></tr>
<tr><td class="tmessage"><%=taddress %> <u>*</u></td><td><input type="text" runat="server" value="" id="txtaddess" class="tboxuser2"/></td></tr>
<tr><td colspan="2" height="4"></td></tr>
<tr><td class="tmessage"><%=temail %> <u>*</u></td><td><input type="text" runat="server" value="" id="txtemail" class="tboxuser2"/></td></tr>
<tr><td colspan="2" height="4"></td></tr>
<tr><td class="tmessage"><%=tmobile %> <u>*</u></td><td><input type="text" runat="server" value="" id="txtmobile" class="tboxuser1"/></td></tr>
<tr><td colspan="2" height="4"></td></tr>
<tr><td class="tmessage"><%=thome %></td><td><input type="text" runat="server" value="" id="txthome" class="tboxuser1"/></td></tr>
<tr><td colspan="2" height="4"></td></tr>
<tr><td class="tmessage"><%=tdayRequest %></td><td><select class="tsnumber" id="slNumberDay" runat="server">
<option value='1'>1</option>
<option value='2' selected="selected">2</option>
<option value='3'>3</option>
<option value='4'>4</option>
<option value='5'>5</option>
<option value='6'>6</option>
<option value='7'>7</option>
<option value='14'>14</option>
<option value='21'>21</option>
<option value='30'>30</option>
</select>
</td></tr>
<tr><td colspan="2" height="4"></td></tr>
<tr><td class="tmessage"><%=tWhereOrder%> <u>*</u></td><td>
<select class="tboxuser2" runat="server" id="slPos">
</select>
</td></tr>
<tr><td colspan="2" height="4"></td></tr>
<tr><td class="tmessage"><%=tmoreinfo %></td><td><textarea rows="5" runat="server" id="txtareamore" class="tboxuser2"></textarea></td></tr>
<tr><td colspan="2" height="4"></td></tr>
</table>
<div align="center" style="padding-top:10px;"><input type="button" runat="server" id="btorder" value="Đồng ý" class="bcart" onserverclick="btorder_ServerClick"/></div>
</div>
<script language="javascript" type="text/javascript">
    var value="<%=currentAccess %>";
    SetCurrentAccess(value);
</script>