// Javascript for Administrator:
var idCurrentPro=0;
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
function OnChoicePro(id,even,nameImage,namepro)
{
    var xhr=null;
    ShowDivPro(id,even);
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
                    //alert(id);
                }
            }
       }
   }
   var today=new Date;
   var time=0;
   if(id!=idCurrentPro)
   {
        time=today.getTime();
        //Chang changNamePro:
        var strstand="abcdefghijklmnopqrtsuvwxyz0123456789- ";
        var change=namepro.toLowerCase();
        var subname="";
        var leng=change.length;
        for(var i=0;i<leng;i++)
        {
            if(strstand.indexOf(change.charAt(i))>-1)
            {
                subname =subname + change.charAt(i);
            }else
            {
                break;
            }
        }
        var subarr=subname.split(' ');
        var numleng=subarr.length;
        if(numleng>5)
        {
            numleng=5;
        }
        subname="";
        for(var i=0;i<numleng-1;i++)
        {
            subarr[i]=subarr[i].trim();
            if(subarr[i].length>0)
            {
                subname +=subarr[i] + " ";
            }
        }
        subname +=subarr[numleng-1];
        var url="AjaxRequest.aspx?menu=imgpro&id=" + id + "&name=" + nameImage + "&namepro=" + subname + "&time=" + time;
        xhr.open("GET",url,true);
        xhr.send(null);
   }
   idCurrentPro=id;
}
function ShowDivPro(id,e)
{
    var N = (document.all) ? 0 : 1;
    document.getElementById("divTitleUpload").innerHTML="Cập nhật ảnh sản phẩm với mã: " + id;
    var offset_y=-60;
    var offset_x=40;
    var ObjView = document.getElementById("divUpload");
    if(ObjView!=null)
    {
        if (N){
			var _y=parseInt(e.pageY)  + offset_y;
		    var _x=parseInt(e.pageX) + offset_x;
		    _y=_y + "px";
		    _x=_x + "px";
		    ObjView.style.top = _y;
		    ObjView.style.left =_x;
			ObjView.style.display="";
			//ObjView.innerHTML="Duyet tren firefox";
			return false;
		}else
		{
			ObjView.style.display="";
			//ObjView.innerHTML="Duyet tren Internet Explore";
			ObjView = ObjView.style;
			ObjView.pixelLeft = event.clientX + document.documentElement.scrollLeft + offset_x;
		    ObjView.pixelTop = event.clientY + document.documentElement.scrollTop + offset_y;
			return false;
		}
    }
}
function OnStartUpload()
{
    document.getElementById("div_name_image").innerHTML="<img src='../image/common/wait.gif'/>";
}
function ComplateUpload(response)
{
    if(response.length>400)
    {
        document.getElementById("div_name_image").innerHTML="<u>Lỗi đường truyền, xin bạn hãy thử lại</u>";
        
    }else
    {
        if(response.length==0)
        {
            document.getElementById("div_name_image").innerHTML="<u>Ảnh đã được cập nhật.</u>";
            location.href=location.href;
        }else
        {
            document.getElementById("div_name_image").innerHTML=response;
        }
    }
}
function CloseDiv()
{
    document.getElementById("divUpload").style.display="none";
}
function searchProduct(index)
{
    var ObjtextSearch=document.getElementById("txt_search");
    if(ObjtextSearch!=null)
    {
        var text=ObjtextSearch.value;
        text=text.trim();
        var state=document.getElementById("choicestate");
        if(index==1)
        {
            location.href="?menu=imgpro&search="+ text + "&state="+ state.value;
        }else if(index==2)
        {
            location.href="?menu=imgmobile&search="+ text + "&state="+ state.value;
        }else if(index==3)
        {
            location.href="?menu=imgpromulti&search="+ text + "&state="+ state.value;
        }
    }
}
function searchPda()
{
    var ObjtextSearch=document.getElementById("txt_search");
    if(ObjtextSearch!=null)
    {
        var text=ObjtextSearch.value;
        text=text.trim();
        var hasImg=document.getElementById("checkImage").checked;
        if(hasImg)
        {
            location.href="?menu=pda&search="+ text + "&img=1";
        }else
        {
            location.href="?menu=pda&search="+ text + "&img=0";
        }
    }
}
function searchProMainpage()
{
    var ObjtextSearch=document.getElementById("txt_search");
    if(ObjtextSearch!=null)
    {
        var text=ObjtextSearch.value;
        text=text.trim();
        var isbest=document.getElementById("checkBest").checked;
        if(isbest)
        {
            location.href="?menu=promainpage&search="+ text + "&main=1";
        }else
        {
            location.href="?menu=promainpage&search="+ text + "&main=0";
        }
    }
}

function searchProOriginal()
{
    var ObjtextSearch=document.getElementById("txt_search");
    if(ObjtextSearch!=null)
    {
        var text=ObjtextSearch.value;
        text=text.trim();
        var isbest=document.getElementById("checkBest").checked;
        if(isbest)
        {
            location.href="?menu=original&search="+ text + "&original=1";
        }else
        {
            location.href="?menu=original&search="+ text + "&original=0";
        }
    }
}

function searchProJustHave()
{
    var ObjtextSearch=document.getElementById("txt_search");
    if(ObjtextSearch!=null)
    {
        var text=ObjtextSearch.value;
        text=text.trim();
        var isbest=document.getElementById("checkBest").checked;
        if(isbest)
        {
            location.href="?menu=projusthave&search="+ text + "&justhave=1";
        }else
        {
            location.href="?menu=projusthave&search="+ text + "&justhave=0";
        }
    }
}
function searchPrepareout()
{
    var ObjtextSearch=document.getElementById("txt_search");
    if(ObjtextSearch!=null)
    {
        var text=ObjtextSearch.value;
        text=text.trim();
        var isbest=document.getElementById("checkBest").checked;
        if(isbest)
        {
            location.href="?menu=prepareout&search="+ text + "&prepareout=1";
        }else
        {
            location.href="?menu=prepareout&search="+ text + "&prepareout=0";
        }
    }
}
function searchProSellOff()
{
    var ObjtextSearch=document.getElementById("txt_search");
    if(ObjtextSearch!=null)
    {
        var text=ObjtextSearch.value;
        text=text.trim();
        var isbest=document.getElementById("checkBest").checked;
        if(isbest)
        {
            location.href="?menu=proselloff&search="+ text + "&selloff=1";
        }else
        {
            location.href="?menu=proselloff&search="+ text + "&selloff=0";
        }
    }
}
function searchProChoiceBest()
{
    var ObjtextSearch=document.getElementById("txt_search");
    if(ObjtextSearch!=null)
    {
        var text=ObjtextSearch.value;
        text=text.trim();
        var isbest=document.getElementById("checkBest").checked;
        if(isbest)
        {
            location.href="?menu=probestsell&search="+ text + "&best=1";
        }else
        {
            location.href="?menu=probestsell&search="+ text + "&best=0";
        }
    }
}
//viewAllProChoieMainpage
function viewAllProChoieMainpage()
{
    location.href="?menu=promainpage&viewall=all";
}
function viewAllProChoiceBest()
{
    location.href="?menu=probestsell&viewall=all";
}
function viewAllPro(index)
{
    if(index==1)
    {
        location.href="?menu=imgpro&viewall=all";
    }else if(index==2)
    {
        location.href="?menu=imgmobile&viewall=all";
    }else if(index==3)
    {
        location.href="?menu=imgpromulti&viewall=all";
    }
}
function viewAllPda()
{
    location.href="?menu=pda&viewall=all";
}
function searchCom()
{
    var ObjtextSearch=document.getElementById("txt_search");
    if(ObjtextSearch!=null)
    {
        var text=ObjtextSearch.value;
        text=text.trim();
        var hasImg=document.getElementById("checkImage").checked;
        if(hasImg)
        {
            location.href="?menu=imgcom&search="+ text + "&img=1";
        }else
        {
            location.href="?menu=imgcom&search="+ text + "&img=0";
        }
    }
}
function viewAllCom()
{
    location.href="?menu=imgcom&viewall=all";
}
var commonPrice=0;
var idselloff=0;
function changeSellOff(Obj,index,even)
{
    if(Obj.checked)
    {
        idselloff=Obj.id;
        var N = (document.all) ? 0 : 1;
        var offset_y=-60;
        var offset_x=40;
        var ObjView = document.getElementById("divUpload");
        if(ObjView!=null)
        {
            if (N){
			    var _y=parseInt(e.pageY)  + offset_y;
		        var _x=parseInt(e.pageX) + offset_x;
		        _y=_y + "px";
		        _x=_x + "px";
		        ObjView.style.top = _y;
		        ObjView.style.left =_x;
			    ObjView.style.display="";
			    //ObjView.innerHTML="Duyet tren firefox";
			    return false;
		    }else
		    {
			    ObjView.style.display="";
			    //ObjView.innerHTML="Duyet tren Internet Explore";
			    ObjView = ObjView.style;
			    ObjView.pixelLeft = event.clientX + document.documentElement.scrollLeft + offset_x;
		        ObjView.pixelTop = event.clientY + document.documentElement.scrollTop + offset_y;
			    return false;
		    }
        }
    }else
    {
        changeBest(Obj,index);
    }
}
function changeBest(Obj,index)
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
                    if(str.length>0)
                    {
                        alert("Lỗi kết nối SQl. Không thể cập nhật. Xin hãy thử lại");
                    }
                }
            }
       }
   }
   var today=new Date;
   var time=0;
   time=today.getTime();
   var url="";
   if(index==1)
   {
       if(Obj.checked)
       {
           url="AjaxRequest.aspx?menu=bestsell&type=1&id=" + Obj.id + "&time=" + time;
       }else
       {
           url="AjaxRequest.aspx?menu=bestsell&type=0&id=" + Obj.id + "&time=" + time;
       }
   }else if(index==2)
   {
       if(Obj.checked)
       {
           url="AjaxRequest.aspx?menu=justhave&type=1&id=" + Obj.id + "&time=" + time;
       }else
       {
           url="AjaxRequest.aspx?menu=justhave&type=0&id=" + Obj.id + "&time=" + time;
       }
   }else if(index==3)
   {
       if(Obj.checked)
       {
           url="AjaxRequest.aspx?menu=specialpromotion&type=1&id=" + Obj.id + "&time=" + time;
       }else
       {
           url="AjaxRequest.aspx?menu=specialpromotion&type=0&id=" + Obj.id + "&time=" + time;
       }
   }else if(index==4)
   {
       if(Obj.checked)
       {
           url="AjaxRequest.aspx?menu=proselloff&type=1&id=" + Obj.id + "&price="+ commonPrice +"&time=" + time;
       }else
       {
           url="AjaxRequest.aspx?menu=proselloff&type=0&id=" + Obj.id + "&price="+ commonPrice +"&time=" + time;
       }
   }else if(index==5)
   {
       if(Obj.checked)
       {
           url="AjaxRequest.aspx?menu=prepareout&type=1&id=" + Obj.id + "&time=" + time;
       }else
       {
           url="AjaxRequest.aspx?menu=prepareout&type=0&id=" + Obj.id + "&time=" + time;
       }
   }
   xhr.open("GET",url,true);
   xhr.send(null);
}
//changeMain
function changeMain(Obj)
{
    var xhr=null;
    var sort=1;
    var value=1;
    if(Obj.checked)
    {
        value=prompt("Hãy nhập thứ tự ưu tiên hiển thị:", "1");
        if(value!=null)
        {
            value=parseInt(value);
            if(value!='NaN')
            {
                sort=value;
            }else
            {
                alert('Hãy nhập thứ tự ưu tiên');
                Obj.checked=false;
                return;
            }
        }else
        {
            alert('Chưa được cập nhật');
            Obj.checked=false;
            return;
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
                    if(str.length>0)
                    {
                        alert("Lỗi kết nối SQl. Không thể cập nhật. Xin hãy thử lại");
                    }
                }
            }
       }
   }
   var today=new Date;
   var time=0;
   time=today.getTime();
   var url="";
   if(Obj.checked)
   {
       url="AjaxRequest.aspx?menu=mainpage&type=1&id=" + Obj.id + "&sort=" + sort  + "&time=" + time;
   }else
   {
       url="AjaxRequest.aspx?menu=mainpage&type=0&id=" + Obj.id + "&sort=" + sort +"&time=" + time;
   }
   xhr.open("GET",url,true);
   xhr.send(null);
}
function Back(menu)
{
    location.href="AdminWebsite.aspx?menu="+ menu;
}
function DeleteGroup(id)
{
    var isdelete=window.confirm("Bạn có chắc chắng muốn xóa bỏ nhóm tin này không ?");
    if(isdelete)
    {
        //alert("Nhóm tin bạn chọn đã được xóa bỏ");
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
                        if(str.length>0)
                        {
                            if(str=="0")
                            {
                                alert("Còn tồn tại tin trong nhóm này. Không thể xóa bỏ nhóm.");
                            }else
                            {
                                alert("Nhóm tin bạn chọn đã được xóa bỏ");
                                location.href=location.href;
                            }
                        }
                    }
                }
           }
       }
       var url="AjaxRequest.aspx?menu=dgroup&&id=" + id;
       xhr.open("GET",url,true);
       xhr.send(null);
    }
}
function Dfunction(id,type)
{
    var isdelete=window.confirm("Bạn có chắc chắn muốn xóa bỏ không ?");
    if(isdelete)
    {
        //alert("Nhóm tin bạn chọn đã được xóa bỏ");
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
                        if(str.length>0)
                        {
                            if(type==1)
                            {
                                if(str=="0")
                                {
                                    alert("Còn tồn tại địa chỉ liên hệ  trong nhóm này. Không thể xóa bỏ nhóm");
                                }else
                                {
                                    alert("Nhóm liên hệ đã được xóa bỏ");
                                    location.href=location.href;
                                }
                            }else if(type==2)
                            {
                                if(str=="0")
                                {
                                    alert("Còn tồn tại đại chỉ liên hệ trong khu vực này. Không thể xóa bỏ.");
                                }else
                                {
                                    alert("Khu vực liên hệ đã được xóa bỏ.");
                                    location.href=location.href;
                                }
                            }else if(type==3)
                            {
                                if(str=="0")
                                {
                                    alert("Lỗi kết nối SQL. Không thể xóa bỏ.");
                                }else
                                {
                                    alert("Mục trợ giúp đã được xóa bỏ.");
                                    location.href=location.href;
                                }
                            }else if(type==4)
                            {
                                if(str=="0")
                                {
                                    alert("Lỗi kết nối SQL. Không thể xóa bỏ.");
                                }else
                                {
                                    alert("Hỗ trợ trực tuyến đã được xóa bỏ.");
                                    location.href=location.href;
                                }
                            }else if(type==5)
                            {
                                alert("Liên kết webiste đã được xóa bỏ.");
                                    location.href=location.href;
                            }else if(type==6)
                            {
                                if(str=="0")
                                {
                                    alert("Lỗi kết nối SQL. Không thể xóa bỏ.");
                                }else
                                {
                                    alert("Quảng cáo đặc biệt đã đưỡc xóa bỏ.");
                                    location.href=location.href;
                                }
                            }else if(type==7)
                            {
                                if(str=="0")
                                {
                                    alert("Lỗi kết nối SQL. Không thể xóa bỏ.");
                                }else
                                {
                                    alert("Tin tức đã được xóa bỏ.");
                                    location.href=location.href;
                                }
                            }
                        }
                    }
                }
           }
       }
       var url="";
       if(type==1)
       {
            url="AjaxRequest.aspx?menu=dgcontact&id=" + id;
       }else if(type==2)
       {
            url="AjaxRequest.aspx?menu=dglocation&id=" + id;
       }else if(type==3)
       {
            url="AjaxRequest.aspx?menu=dhelp&&id=" + id;
       }else if(type==4)
       {
            url="AjaxRequest.aspx?menu=donline&id=" + id;
       }else if(type==5)
       {
            //Delete: advertisement:
            url="AjaxRequest.aspx?menu=dadvertise&id=" + id;
       }else if(type==6)
       {
            url="AjaxRequest.aspx?menu=dadvertisespecial&id=" + id;
       }else if(type==7)
       {
            //delete article:
            url="AjaxRequest.aspx?menu=darticle&id=" + id;
       }
       xhr.open("GET",url,true);
       xhr.send(null);
    }
}

//change Original:
function changeOriginal(Obj)
{
    var xhr=null;
    var sort=1;
    var value=1;
    if(Obj.checked)
    {
        value=prompt("Hãy nhập thứ tự ưu tiên hiển thị:", "1");
        if(value!=null)
        {
            value=parseInt(value);
            if(value!='NaN')
            {
                sort=value;
            }else
            {
                alert('Hãy nhập thứ tự ưu tiên');
                Obj.checked=false;
                return;
            }
        }else
        {
            alert('Chưa được cập nhật');
            Obj.checked=false;
            return;
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
                    if(str.length>0)
                    {
                        alert("Lỗi kết nối SQl. Không thể cập nhật. Xin hãy thử lại");
                    }
                }
            }
       }
   }
   var today=new Date;
   var time=0;
   time=today.getTime();
   var url="";
   if(Obj.checked)
   {
       url="AjaxRequest.aspx?menu=original&type=1&id=" + Obj.id + "&sort=" + sort  + "&time=" + time;
   }else
   {
       url="AjaxRequest.aspx?menu=original&type=0&id=" + Obj.id + "&sort=" + sort +"&time=" + time;
   }
   xhr.open("GET",url,true);
   xhr.send(null);
}