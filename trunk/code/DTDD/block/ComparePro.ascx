<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ComparePro.ascx.cs" Inherits="block_ComparePro" %>
<table width="100%" cellpadding="0" cellspacing="0" border="0">
<tr>
  <td class="bg_b1"></td>
  <td class="bg_b2"><div class="text_bl"><%=tblcompare %></div></td>
  <td class="bg_b3"></td>
</tr>
<tr>
  <td class="bg_b4"></td>
  <td valign="top"><div class="text_5">
  <%=selectBrand %>
  <%=strInfoPro%>
  <%=strComponent %>
    </div>
    <div style="text-align:center;height:28px;"><input type="button" value="<%=tback %>" onclick="back();" class="bcart" /></div>
    </td>
  <td class="bg_b5"></td>
</tr>
<tr>
  <td class="bg_b7" colspan="3"></td>
</tr>
</table>
<script language="javascript" type="text/javascript">
var value="<%=currentAccess %>";
SetCurrentAccess(value);
var idcompare1="<%=idcompare1 %>";
var idcompare2="<%=idcompare2 %>";
function GetListName(id1,id2)
{
    var xhr=null; 
    if(window.ActiveXObject)
    { 
        try{
            xhr = new ActiveXObject("Msxml2.XMLHTTP");
        }catch (e) 
        {
            try{
                xhr = new ActiveXObject("Microsoft.XMLHTTP");
            }catch(e)
            {
                alert("set ActiveX to Visible");
            }
        }
    }
    else if(window.XMLHttpRequest) // ActiveX version
    {
        
        xhr = new XMLHttpRequest();//Fire Fox
        xhr.overrideMimeType("text/xml");
    }
   if(xhr!=null)
   {
       xhr.onreadystatechange=function()
       {
            if (xhr.readyState == 4)
            {
                if(xhr.status == 200)
                {
                    var str=xhr.responseText;
                    var arr=str.split('<>');
                    var num=0;
                    if(arr[0].length>1)
                    {
                        var sl1="<select class='text_box2' style='width:210px;' id='slname1' onchange='changename();'>";
                        sl1+="<option value='0'>Choice Model</option>";
                        var arrsl1=arr[0].split(';');
                        num=arrsl1.length;
                        if(num>0)
                        {
                            for(var i=0;i<num;i++)
                            {
                                var subvalue=arrsl1[i].split(':');
                                if(subvalue[0]==idcompare1)
                                {
                                    sl1+="<option value='" + subvalue[0] + "' selected='selected'>"+ subvalue[1] +"</option>";
                                }else
                                {
                                    sl1+="<option value='" + subvalue[0] + "'>"+ subvalue[1] +"</option>";
                                }
                            }
                        }
                        sl1+="</select>";
                        document.getElementById("divslName1").innerHTML=sl1;
                    }
                    if(arr[1].length>1)
                    {
                        var sl2="<select class='text_box2' style='width:210px;' id='slname2' onchange='changename();'>";
                        sl2 +="<option value='0'>Choice Model</option>";
                        var arrsl2=arr[1].split(';');
                        num=arrsl2.length;
                        if(num>0)
                        {
                            for(var i=0;i<num;i++)
                            {
                                var subvalue=arrsl2[i].split(':');
                                if(subvalue[0]==idcompare2)
                                {
                                    
                                    sl2+="<option value='" + subvalue[0] + "' selected='selected'>"+ subvalue[1] +"</option>";
                                }else
                                {
                                    sl2+="<option value='" + subvalue[0] + "'>"+ subvalue[1] +"</option>";
                                }
                            }
                        }
                        sl2+="</select>";
                        document.getElementById("divslName2").innerHTML=sl2;
                    }
                }
            }
       }
   }
   today = new Date;
   var url="AjaxRequest.aspx?menu=compare&id="+ id1 + "," + id2;
   xhr.open("GET",url,true);
   xhr.send(null);
}
function onstartCompare()
{
    var id1=document.getElementById("divslName1").innerHTML;
    var id2=document.getElementById("divslName2").innerHTML;
    GetListName(id1,id2);
}
function ChangeBrand(Obj,id)
{
    if(id==1)
    {
        GetListName(Obj.value,0);
    }else
    {
        GetListName(0,Obj.value);
    }
}
function changename()
{
    var id1=document.getElementById("slname1").value;
    var id2=document.getElementById("slname2").value;
    if((id1==0)||(id2==0))
    {
        
    }else
    {
        location.href="?menu=compare&id=" + id1 + "," + id2;
    }
}
onstartCompare();
</script>