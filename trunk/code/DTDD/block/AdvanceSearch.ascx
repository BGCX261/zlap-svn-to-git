<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdvanceSearch.ascx.cs" Inherits="block_AdvanceSearch" %>
<table width="100%" cellpadding="0" cellspacing="0" border="0">
<tr>
  <td class="bg_b1"></td>
  <td class="bg_b2"><div class="text_bl"><%=tbl_search%></div></td>
  <td class="bg_b3"></td>
</tr>
<tr>
  <td class="bg_b4"></td>
  <td valign="middle" height="240">
  <%=str_search %></td>
  <td class="bg_b5"></td>
</tr>
<tr>
  <td class="bg_b7" colspan="3"></td>
</tr>
</table>
<script language="javascript" type="text/javascript">
    var value="<%=tCurrentAccess %>";
    SetCurrentAccess(value);
    function advancesearch()
    {
        var urlSearch="?menu=dasp";
        var idbrand=document.getElementById("slbrand").value;
        if(idbrand>0)
        {
            urlSearch+="&brand=" + idbrand;
        }
        var price=document.getElementById("slprice").value;
        if(price!='0')
        {
            var values=price.split(',');
            if(values.length==2)
            {
                if(values[0].length>0)
                {
                    urlSearch+="&price1=" + values[0];
                }
                if(values[1].length>0)
                {
                    urlSearch+="&price2=" + values[1];
                }
            }
        }
        var cpu=document.getElementById("slcpu").value;
        if(cpu!='0')
        {
            urlSearch+="&cpu=" + cpu;
        }
        var hdd=document.getElementById("slhdd").value;
        if(hdd!='0')
        {
            urlSearch+="&hdd=" + hdd;
        }
        var ram=document.getElementById("slram").value;
        if(ram!='0')
        {
            urlSearch+="&ram=" + ram;
        }
        var screen=document.getElementById("slscreen").value;
        if(screen!='0')
        {
            urlSearch+="&screen=" + screen;
        }
////    var cardvideo=document.getElementById("slgraphic").value;
////    if(cardvideo!='0')
////    {
////        urlSearch+="&videocard=" + cardvideo;
////    }
////    var weight=document.getElementById("slweight").value;
////    if(weight!='0')
////    {
////        urlSearch+="&weight=" + weight;
////    }
        var color=document.getElementById("slcolor").value;
        if(color!='0')
        {
            urlSearch +="&color=" + color;
        }
        var txtsearch=document.getElementById("txtadvancesearch").value;
        txtsearch=txtsearch.trim();
        if(txtsearch.length>0)
        {
            urlSearch +="&text=" + txtsearch;
        }
        if(urlSearch=="?menu=dasp")
        {
            location.href="?menu=product";
        }else
        {
            location.href=urlSearch;
        }
    }
</script>