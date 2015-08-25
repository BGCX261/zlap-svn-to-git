// JScript File:
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
function doInput(Obj,index)
{
	var objInput=document.getElementById("txtInvoicePrice" + index);
	if(objInput!=null)
	{
		objInput.value=Obj.value;
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
function RequestCommon(index,array,id)
{
    var xhr=null;
    if(index==1)
    {
        if(arrayName[array]!=null)
        {
            if(document.getElementById("dListNameForm")!=null && arrayName[array].length>0)
            {
                document.getElementById("dListNameForm").innerHTML=arrayName[array];
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
                        if(document.getElementById("dListNameForm")!=null)
                        {
                            arrayName[array]=strreturn;
                            document.getElementById("dListNameForm").innerHTML=strreturn;
                        }
                    }
                }
            }
       }
   }
   var url="";
   today = new Date;
   if(index==1)
   {
        url="AjaxRequest.aspx?menu=listNameForm&idrole=" + id + "&time=" + today.getTime();
   }
   xhr.open("GET",url,true);
   xhr.send(null);
}
function ReAction(action,key,id)
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
                    var strreturn=xhr.responseText;
                    if(strreturn=="-1")
                    {
                        location.href="LoginWebsite.aspx";
                        return;
                    }
                    if(action=="UpdateActForm" || action=="UpdateFormOfRole")
                    {
                        if(strreturn=="1")
                        {
                            if(action=="UpdateFormOfRole")
                            {
                                ReAction("divFormOfRole",key,id.split('_')[0]);
                            }
                        }else{
                            alert(strreturn);
                            ReAction("divFormOfRole",key,id.split('_')[0]);
                        }
                        return;
                    }
                    if(action=="UpdateRoleOfUser")
                    {
                        if(strreturn=="1")
                        {
                        }else {
                            alert(strreturn);
                        }
                        ReAction("divRoleOfUser",key,id.split('_')[0]);
                        return;
                    }
                    if(action=="FormandActOfRole")
                    {
                        var ObjDiv=document.getElementById("DRole" + id);
                        if(ObjDiv!=null)
                        {
                            ObjDiv.innerHTML=strreturn;
                        }
                        return;
                    }
                    if(action=="UpdateIPOfUser")
                    {
                        if(strreturn=="1")
                        {
                        }else {
                            alert(strreturn);
                        }
                        ReAction("divIPOfUser",key,id.split('_')[0]);
                        return;
                    }
                    if(action=="ActOfForm")
                    {
                        //
                        var ObjTd=document.getElementById("td2t1." + id);
                        if(ObjTd!=null)
                        {
                            ObjTd.innerHTML=strreturn;
                        }
                        return;
                    }
                    if(action=="CActMax")
                    {
                        //Process:
                        var arr=id.split('_');
                        var ObjCheck=document.getElementById(arr[0] + "_" + arr[1]);
                        if(strreturn=="1")
                        {
                            strreturn="<div class='txterr1' style='width:250px;'>Bạn đã bị khóa quyền hiển thị Form này.</div>";
                            if(ObjCheck!=null)
                            {
                                ObjCheck.checked=!ObjCheck.checked;
                            }
                        }else if(strreturn=="2")
                        {
                            strreturn="<div class='txterr1' style='width:250px;'>Bạn đã bị khóa quyền thêm mới.</div>";
                            if(ObjCheck!=null)
                            {
                                ObjCheck.checked=!ObjCheck.checked;
                            }
                        }
                        else if(strreturn=="4")
                        {
                            strreturn="<div class='txterr1' style='width:250px;'>Bạn đã bị khóa quyền xóa.</div>";
                            if(ObjCheck!=null)
                            {
                                ObjCheck.checked=!ObjCheck.checked;
                            }
                        }else if(strreturn=="5")
                        {
                            strreturn="<div class='txterr1' style='width:250px;'>Quyền này đã được dùng, không thể xóa.</div>";
                            if(ObjCheck!=null)
                            {
                                ObjCheck.checked=!ObjCheck.checked;
                            }
                        }
                        document.getElementById("divMessage").innerHTML=strreturn;
                        return;
                    }
                    //duyet:
                    if(action=="duyetphieuchi" || action=="duyetphieuthu" || action=="duyetbanknhap" || action=="duyetbankxuat" || action=="duyetdonhang" || action=="ketthucdonhang")
                    {
                        
                        if(action=="duyetdonhang" && strreturn=="2")
                        {
                            alert("Sản phẩm trong đơn hàng chưa được duyệt !");
                            return;
                        }
                        if(action=="ketthucdonhang")
                        {
                            if(strreturn=="2")
                            {
                                alert("Đơn hàng chưa thu đủ tiền. Không thể kết thúc !");
                                return;
                            }else if(strreturn=="0")
                            {
                                alert("Lỗi kết nối CSDL. Không thể kết thúc !");
                                return;
                            }
                        }
                        if(strreturn=="0")
                        {
                            alert("Bạn đã bị khóa quyền duyệt !");
                            return;
                        }
                        document.getElementById("dsdetail").innerHTML=strreturn;
                        return;
                    }
                    if(document.getElementById(action)!=null)
                    {
                        document.getElementById(action).innerHTML=strreturn;
                        return;
                    }
                    return;
                }else
                {
                    location.href="LoginWebsite.aspx";
                    return;
                }
            }
       }
   }
   var url="";
   today = new Date;
   url="AjaxAction.aspx?action=" + action + "&key=" + key + "&id=" + id + "&time=" + today.getTime();
   xhr.open("POST",url,true);
   xhr.send(null);
}
function rqseedetail(action,key,id)
{
    var ObjDiv=document.getElementById("dsdetail");
    if(ObjDiv!=null)
    {
        ObjDiv.style.display="";
    }
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
                    var strreturn=xhr.responseText;
                    if(strreturn=="-1")
                    {
                        location.href="LoginWebsite.aspx";
                        return;
                    }
                    //xu ly:
                    var nameD="dsdetail";
                    if(action=="slseripro")
                    {
                        nameD="dsdseri";
                    }
                    var ObjDiv=document.getElementById(nameD);
                    if(ObjDiv!=null)
                    {
                        ObjDiv.innerHTML=strreturn;
                    }
                    return;
                }
            }
       }
   }
   var url="";
   today = new Date;
   url="AjaxAction.aspx?action=" + action + "&key=" + key + "&id=" + id + "&time=" + today.getTime();
   xhr.open("POST",url,true);
   xhr.send(null);
}

function ReMessage()
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
                    var strreturn=xhr.responseText;
                    var obj=document.getElementById("divNewMessage");
                    if(obj!=null)
                    {
                        obj.innerHTML=strreturn;
                    }
                    if(strreturn!="Không có tin nhắn mới")
                    {
                        alert("Bạn có tin nhắn mới !");
                    }
                }
            }
       }
   }
   var url="";
   today = new Date;
   url="AjaxRequest.aspx?menu=NewMessage&time=" + today.getTime();
   xhr.open("GET",url,true);
   xhr.send(null);
}
function closed()
{
    var obj=document.getElementById("dsdetail");
    if(obj!=null)
    {
        obj.style.display='none';
    }
}