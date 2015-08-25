<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DetailCart.ascx.cs" Inherits="block_DetailCart" %>
<table width="100%" cellpadding="0" cellspacing="0" border="0">
<tr>
<td class="bg_b1"></td>
<td class="bg_b2"><div class="text_bl"><%=blCart %></div></td>
<td class="bg_b3"></td>
</tr>
<tr>
<td class="bg_b4"></td>
<td valign="top">
    <div class="text_5">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
  <tr class="text_b2">
  <td width="330"><%=tinfopro %></td>
  <td width="80"><%=tnumber %></td>
  <td width="80"><%=tTatal %></td>
  <td>&nbsp;</td>
</tr>
<tr><td height="5" colspan="4"></td></tr>
</table>
<%=tablePro %>
<div align='center' style='padding-top:10px;' id="divbutton" runat="server"><input type='button' id="btUpdate" runat="server" value='' class='bcart' onclick="setValue();" onserverclick="btUpdate_ServerClick" />
<input type='button' value='<%=bcon %>' onclick="back();" class='bcart' />
<input type='button' id="btorder" onclick="location.href='?menu=order';" value='<%=torder %>' class='bcart'/><input type="hidden" id="hdtext" name="hdtext" value="" /></div>
</div>
</td>
<td class="bg_b5"></td>
</tr>
<tr>
<td class="bg_b7" colspan="3"></td>
</tr>
</table>
<script language="javascript" type="text/javascript">
    var strNumber="<%=numberincart %>";
    function setValue()
    {
        var num=parseInt(strNumber);
        if(num>0)
        {
            var strValue="";
            for(var i=0;i<num;i++)
            {
                var ObjText=document.getElementById("procart"+i);
                var value=ObjText.value.trim();
                var subnum=parseInt(value);
                if(subnum=='NaN')
                {
                    subnum=1;
                }
                strValue+=subnum + ":";
            }
            document.getElementById("hdtext").value=strValue;
        }
    }
    var value="<%=currentAccess %>";
    SetCurrentAccess(value);
</script>