// JScript File:
var arrayDes=new Array();
var arrayPromotion=new Array();
var arrayName=new Array();
String.prototype.trim = function () {
    return this.replace(/^\s*|\s(?=\s)|\s*$/g, "");
}
function replace(s,t1,t2)
{
    var num=s.length;
    var str="";
    if(num==0)
    return s;
    for(var i=0;i<num;i++)
    {
        if(s.charAt(i)==t1)
        {
            str+=t2;
        }else
        {
            str+=s.charAt(i);
        }
    }
    return str;
}
function OnChangeLang(Obj)
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
    else if(window.XMLHttpRequest)
    {
        
        xhr = new XMLHttpRequest();
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
                    var arrUrl=location.href.split('#');
                    location.href=arrUrl[0];
                }
            }
       }
   }
   today = new Date;
   var url="AjaxRequest.aspx?menu=lang&id="+ Obj.id + "&time=" + today.getTime();
   xhr.open("GET",url,true);
   xhr.send(null);
}
function PageAll(Obj,page,id)
{
    var url="";
    if(id==2)
    {
        url="default.html?menu=com&page="+ page+ "&size=" + Obj.value;
    }else if(id==3)
    {
        url="default.html?menu=other&page="+ page+ "&size=" + Obj.value;
    }else if(id==4)
    {
         url="default.html?menu=wh&page="+ page+ "&size=" + Obj.value;
    }
    else
    {
        url="default.html?menu=product&page="+ page+ "&size=" + Obj.value;
    }
    location.href=url;
}
function PageBrand(Obj,brand,page,id)
{
    var url="";
    if(id==1)
    {
        url="default.html?menu=pro&brand=" + brand + "&page="+ page+ "&size=" + Obj.value;
    }else
    {
        url="default.html?menu=igc&id=" + brand + "&page="+ page+ "&size=" + Obj.value;
    }
    location.href=url;
}
function SetCurrentAccess(value)
{
    document.getElementById('currentAccess').innerHTML=value;
}
function OnQuickSearch()
{
    var textSearch=new String(document.getElementById("text_quick_search").value);
    if(textSearch.length>30)
    {
        textSearch=textSearch.substring(0,30);
    }
    textSearch=textSearch.trim();
    textSearch=replace(textSearch,'"','');
    var select=document.getElementById('select_quick_search').value;
    if(textSearch.length>0)
    {
        location.href="default.html?menu="+ select +"&text="+ textSearch;
    }else
    {
        if(select=="dasp")
        {
            location.href="default.html?menu=product";
        }else if(select=="qsc")
        {
            location.href="default.html?menu=com";
        }else if(select=="qsa")
        {
            location.href="default.html?menu=article";
        }
        else if(select=="qsh")
        {
            location.href="default.html?menu=help";
        }
    }
}
function GoGage(index,id)
{
   var Objpage=document.getElementById("t"+index).value.trim();
   if(Objpage.length>8)
   {
        Objpage=Objpage.substring(0,8);
   }
   var page=parseInt(Objpage)+'';
   var ObjSize=document.getElementById("s"+ index).value.trim();
   var menu="product";
   if(id==2)
   {
        menu="com";
   }else if(id==3)
   {
        menu="other";
   }else if(id==4)
   {
        menu="wh";
   }
   else
   {
        menu="product";
   }
   if(page!='NaN')
   {
        location.href="default.html?menu="+ menu +"&page="+ page+ "&size=" + ObjSize;
   }
}
function GoGageB(brand,index,id)
{
   var Objpage=document.getElementById("t"+index).value.trim();
   if(Objpage.length>8)
   {
        Objpage=Objpage.substring(0,8);
   }
   var page=parseInt(Objpage)+'';
   var ObjSize=document.getElementById("s"+ index).value.trim();
   if(page!='NaN')
   {
        if(id==1)
        {
            location.href="default.html?menu=pro&brand="+ brand +"&page="+ page+ "&size=" + ObjSize;
        }else
        {
            location.href="default.html?menu=igc&id="+ brand +"&page="+ page+ "&size=" + ObjSize;
        }
   }
}
function PageS(Obj,page,id)
{
    var url="";
    if(id==1)
    {
        url="default.html?menu=qsp&text=" + strTextSearch + "&page="+ page+ "&size=" + Obj.value;
    }else if(id==2)
    {
        url="default.html?menu=qsc&text=" + strTextSearch + "&page="+ page+ "&size=" + Obj.value;
    }else if(id==3)
    {
        url="default.html?menu=dasp&advance=1&page="+ page+ "&size=" + Obj.value;
    }
    location.href=url;
}
function GoGageS(index,id)
{
   var Objpage=document.getElementById("t"+index).value.trim();
   if(Objpage.length>8)
   {
        Objpage=Objpage.substring(0,8);
   }
   var page=parseInt(Objpage)+'';
   var ObjSize=document.getElementById("s"+ index).value.trim();
   if(page!='NaN')
   {
        if(id==1)
        {
            location.href="default.html?menu=qsp&text=" + strTextSearch + "&page="+ page+ "&size=" + ObjSize;
        }else if(id==2)
        {
            location.href="default.html?menu=qsc&text=" + strTextSearch + "&page="+ page+ "&size=" + ObjSize;
        }else if(id==3)
        {
            location.href="default.html?menu=dasp&advance=1&page="+ page+ "&size=" + ObjSize;
        }
   }
}
function OnEnterSend(e,tbnName)
{
    //----------------------------------------------------------------
    //  Date: 23/11/2006
    //  Create By: sung_le2002@yahoo.com
    //  Used: process On Enter Of area
    //  Output  : make some things when Enter Key down 
    //  Input   : event, name of buttom for click
    //-------------------------------------------------------------
    var keycode;
    if (window.event) 
    {
        keycode = window.event.keyCode;
    }
    else 
    {
            if (e) 
            {
                keycode = e.which;
            } 
            else 
            {
                return true;
            }
     }
    if (keycode == 13)
        {
        var func="ButtonClick('" + tbnName+ "')";
        setTimeout(func,20);
    }
    else 
    {
        return true;
    }
}
function ButtonClick(tbnName)
{
    var  Objbtn=document.getElementById(tbnName);
        if(Objbtn!=null)
        {
            Objbtn.onclick();
        }
        return true;
}
function compcom()
{
}
function comp()
{
    var ArrCheck=document.getElementsByName("cp");
    var arrchoice=new Array();
    arrchoice[0]=0;
    arrchoice[1]=0;
    var count=0;
    if(ArrCheck!=null)
    {
        var num=ArrCheck.length;
        for(var i=0;i<num;i++)
        {
            if(count>1)
            {
                break;
            }
            if(ArrCheck[i].checked)
            {
                var id=ArrCheck[i].id;
                id=id.substring(1,id.length);
                arrchoice[count]=id;
                count++;
            }
        }
    }
    if(arrchoice[1]>0)
    {
       location.href="default.html?menu=compare&id=" + arrchoice[0] + "," + arrchoice[1];
    }else if(arrchoice[0]>0)
    {
        location.href="default.html?menu=compare&id=" + arrchoice[0];
    }
}
function back()
{
    history.back();
}
function gocomp(id)
{
    location.href="default.html?menu=compare&id=" + id;
}
function GotoCart()
{
    location.href="default.html?menu=shoppingcart";
}
function WaitLogin()
{
    var Objdiv=document.getElementById("divWLogin");
    if(Objdiv!=null)
    {
        Objdiv.style.display="";
        Objdiv.innerHTML="<img src='image/common/wait.gif' />";
    }
    setTimeout("UserLogin(1)",500);
}
function UserLogin(index)
{
    var user="ok";
    var pass="ok";
    if(index==1)
    {
        user=document.getElementById("textuser").value.trim();
        pass=document.getElementById("textpass").value.trim();
    }
    pass=replace(pass,"\"","");
    user=replace(user,"\"","");
    if(user.length>0 && pass.length>0)
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
        else if(window.XMLHttpRequest)
        {
            xhr = new XMLHttpRequest();
            xhr.overrideMimeType("text/xml");
        }
       if(xhr!=null)
       {
           xhr.onreadystatechange=function()
           {
                if (xhr.readyState == 4)
                {
                    if(xhr.status  == 200)
                    {
                        if(index==1)
                        {
                            document.getElementById("divWLogin").innerHTML="";
                            document.getElementById("divWLogin").style.display="none";
                            var str=xhr.responseText;
                            if(str=="ok")
                            {
                                var arrurl=location.href.split('#');
                                location.href=arrurl[0];
                            }else
                            {
                                alert(str);
                            }
                        }else
                        {
                            var str=xhr.responseText;
                            if(str=="ok")
                            {
                                var urlCurrent=location.href;
                                urlCurrent=urlCurrent.substring(0,urlCurrent.length-1);
                                location.href=urlCurrent;
                            }
                        }
                    }
                }
           }
       }
       today = new Date;
       var url="";
       if(index==1)
       {
            url="UserLoginAccount.aspx?user=" + user + "&pass="+ pass + "&time=" + today.getTime();
       }else
       {
            url="AjaxRequest.aspx?menu=logout" + "&time=" + today.getTime();
       }
       xhr.open("GET",url,true);
       xhr.send(null);
    }else
    {
        document.getElementById("divWLogin").innerHTML="";
        document.getElementById("divWLogin").style.display="none";
    }
}
function ShowSpeccom(value,e)
{
    overShow=true;
    offset_x=20;
    offset_y=-20;
	OnMOver(e);
	var ObjDiv=document.getElementById(nameObjShow);
	var strTable="<div class='td_bd1'><table border='0' cellpadding='0' cellspacing='0' bgcolor='#FFF1EA' width='100%'>";
    strTable+="<tr><td class='text_b3'>Thông tin mô tả linh kiện</td></tr>";
    strTable+="<tr><td class='qshow'>" + value + "</td></tr>";
    strTable+="<tr><td class='domain'>&nbsp;</td></tr></table></div>";
    ObjDiv.innerHTML=strTable;
}
function showDivMessage(index,id,iarray,e)
{
	overShow=true;
	OnMOver(e);
	var ObjDiv=document.getElementById(nameObjShow);
	if(ObjDiv!=null)
	{
	    if(index==1)
	    {
            offset_y=-55;
	        if(iarray>-1 && arrayDes[iarray]!=null)
	        {
	            ObjDiv.innerHTML=arrayDes[iarray];
	            return;
	        }
	    }else
	    {
	        offset_y=-40;
	        if(iarray>-1 && arrayPromotion[iarray]!=null)
	        {
	            ObjDiv.innerHTML=arrayPromotion[iarray];
	            return;
	        }
	    }
	}
	if(ObjDiv!=null)
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
        else if(window.XMLHttpRequest)// ActiveX version
        {
            
            xhr = new XMLHttpRequest();//Fire Fox
            xhr.overrideMimeType("text/xml");
        }
	    if(xhr!=null)
        {
           xhr.onreadystatechange=function()
           {
                var img="<img src='image/common/wait.gif'/>";
                ObjDiv.innerHTML=img;
                if (xhr.readyState == 4)
                {
                    if(xhr.status  == 200)
                    {
                        var str=xhr.responseText;
                        if(index==1)
                        {
                            if(str.length>0)
                            {
                                var ArrValue=str.split('<@>');
                                var strTable="<div class='td_bd1'><table border='0' cellpadding='0' cellspacing='0' bgcolor='#FFF1EA' width='100%'>";	
		                        strTable+="<tr><td class='text_b3'>"+ ArrValue[0] +"</td></tr>";
		                        var specification="";
		                        var strValue=ArrValue[1].split(',');
		                        var numSpec=strValue.length;
		                        if(numSpec>0)
		                        {
		                            for(var i=0;i<numSpec;i++)
		                            {
    		                            if(strValue[i].length>0)
    		                            {
    		                                specification+="* " + strValue[i] + "<br />";
    		                            }
		                            }
		                        }else
		                        {
		                            specification=ArrValue[1];
		                        }
		                        strTable+="<tr><td class='qshow'>" + specification + "</td></tr>";
		                        var straddress="";
		                        if(ArrValue.length==3)
		                        {
		                            straddress=ArrValue[2];
		                            if(straddress.length>0)
		                            {
		                                strTable+="<tr><td class='bg_line3'></td></tr>";
		                                strTable+="<tr><td class='text_3' align='left'>Sản phẩm có bán tại:</td></tr>";
		                                strTable+="<tr><td class='qshow'>" + straddress + "</td></tr>";
		                            }
		                        }
		                        
		                        strTable+="<tr><td class='domain'>&nbsp;</td></tr></table></div>";
		                        arrayDes[iarray]=strTable;
		                        ObjDiv.innerHTML=strTable;
		                    }else
		                    {
		                        ObjDiv.innerHTML="...";
		                    }
		                  }else
		                  {
		                    //promotion show:
		                    arrayPromotion[iarray]=str;
		                    ObjDiv.innerHTML=str;
		                  }
                    }
                }
           }
        }
       var url="";
       if(index==1)
       {
            url="AjaxRequest.aspx?menu=specpro&id="+ id;
       }else
       {
           url="AjaxRequest.aspx?menu=promotion&id="+ id;
       }
       xhr.open("GET",url,true);
       xhr.send(null);
	}
}
function AddCart(id,type)
{
    var url="default.html?menu=addpro&id=" + id  + "&type=" + type;
    location.href=url;
}
function RequestCommon(index,array,id)
{
    var xhr=null;
    if(index==10)
    {
        if(arrayName[array]!=null)
        {
            if(document.getElementById("dListName")!=null && arrayName[array].length>0)
            {
                document.getElementById("dListName").innerHTML=arrayName[array];
                return;
            }
        }
    } 
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
    else if(window.XMLHttpRequest)
    {
        xhr = new XMLHttpRequest();
        xhr.overrideMimeType("text/xml");
    }
   if(xhr!=null)
   {
       xhr.onreadystatechange=function()
       {
            if (xhr.readyState == 4)
            {
                if(xhr.status  == 200)
                {
                    var strreturn=xhr.responseText;
                    if(index==1)
                    {
                        document.getElementById("divbestsell").innerHTML=strreturn;
                    }else if(index==2)
                    {
                        document.getElementById("divsupportonline").innerHTML=strreturn;
                    }else if(index==3)
                    {
                        document.getElementById("divadvertise").innerHTML=strreturn;
                    }else if(index==4)
                    {
                        document.getElementById("divlistbrand").innerHTML=strreturn;
                    }else if(index==5)
                    {
                        document.getElementById("divstatistic").innerHTML=strreturn;
                    }else if(index==6)
                    {
                        document.getElementById("divjusthave").innerHTML=strreturn;
                    }else if(index==7)
                    {
                        document.getElementById("divquicksearch").innerHTML=strreturn;
                    }else if(index==8)
                    {
                        //divSpecial:
                        document.getElementById("divSpecial").innerHTML=strreturn;
                    }else if (index==9)
                    {
                        document.getElementById("divoriginalpro").innerHTML=strreturn;
                    }else if(index==10)
                    {
                        if(document.getElementById("dListName")!=null)
                        {
                            arrayName[array]=strreturn;
                            document.getElementById("dListName").innerHTML=strreturn;
                        }
                    }else if(index==11)
                    {
                        if(document.getElementById("dListName")!=null)
                        {
                            //arrayName[array]=strreturn;
                            document.getElementById("dListName").innerHTML=strreturn;
                        }
                    }
                }
            }
       }
   }
   var url="";
   if(index==1)
   {
        var time=new Date();
        url="AjaxRequest.aspx?menu=bestsell";
   }else if(index==2)
   {
        //url="AjaxRequest.aspx?menu=online";
        return;
   }else if(index==3)
   {
        url="AjaxRequest.aspx?menu=advertise";
   }else if(index==4)
   {
        //url="AjaxRequest.aspx?menu=brand";
   }else if(index==5)
   {
        url="AjaxRequest.aspx?menu=statistic";
   }else if(index==6)
   {
    //projust have
    url="AjaxRequest.aspx?menu=justhave";
   }else if(index==7)
   {
        //page search:
        url="AjaxRequest.aspx?menu=quicksearch";
   }else if(index==8)
   {
        url="AjaxRequest.aspx?menu=aspecial";
   }else if(index==9)
   {
        url="AjaxRequest.aspx?menu=originaltop";
   }else if(index==10)
   {
        url="AjaxRequest.aspx?menu=listName&idbrand=" + id;
   }
   else if(index==11)
   {
        url="AjaxRequest.aspx?menu=stateproduct&id=" + id;
   }
   xhr.open("GET",url,true);
   xhr.send(null);
}
function OnClickSearch()
{
    var urlSearch="default.html?menu=dasp";
    var idbrand=document.getElementById("slbrandq").value;
    if(idbrand>0)
    {
        urlSearch+="&brand=" + idbrand;
    }
    var price=document.getElementById("slpriceq").value;
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
    var cpu=document.getElementById("slcpuq").value;
    if(cpu!='0')
    {
        urlSearch+="&cpu=" + cpu;
    }
    var screen=document.getElementById("slscreenq").value;
    if(screen!='0')
    {
        urlSearch+="&screen=" + screen;
    }
    var color=document.getElementById("slcolorq").value;
    if(color!='0')
    {
        urlSearch+="&color=" + color;
    }
    var txtsearch=document.getElementById("txtsearchq").value;
    txtsearch=txtsearch.trim();
    if(txtsearch.length>0)
    {
        urlSearch +="&text=" + txtsearch;
    }
    if(urlSearch=="default.html?menu=dasp")
    {
        location.href="default.html?menu=product";
    }else
    {
        location.href=urlSearch;
    }
}
function ShowLogin()
{
    var Obj=document.getElementById("divfrmLogin");
    if(Obj!=null)
    {
        if(Obj.style.display=='')
        {
            Obj.style.display='none';
        }else
        {
            Obj.style.display='';
        }
    }
}