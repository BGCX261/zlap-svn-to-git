// JScript File
function searchMobile1(index)//Main page
{
    var ObjtextSearch=document.getElementById("txt_search");
    if(ObjtextSearch!=null)
    {
        var text=ObjtextSearch.value;
        text=text.trim();
        var isbest=document.getElementById("checkBest").checked;
        if(index==1)//mobile mainpage:
        {
            if(isbest)
            {
                location.href="?menu=mobile1&search="+ text + "&main=1";
            }else
            {
                location.href="?menu=mobile1&search="+ text + "&main=0";
            }
        }else if(index==2)//Mobile bestsell:
        {
            if(isbest)
            {
                location.href="?menu=mobile2&search="+ text + "&main=1";
            }else
            {
                location.href="?menu=mobile2&search="+ text + "&main=0";
            }
        }
        else if(index==3)//Mobile original:
        {
            if(isbest)
            {
                location.href="?menu=mobile3&search="+ text + "&main=1";
            }else
            {
                location.href="?menu=mobile3&search="+ text + "&main=0";
            }
        }
    }
}
function viewAllMobile1(index)
{
    if(index==1)
    {
        location.href="?menu=mobile1&viewall=all";
    }
    if(index==2)
    {
        location.href="?menu=mobile2&viewall=all";
    }
    if(index==3)
    {
        location.href="?menu=mobile3&viewall=all";
    }
}
//changeMain
function ChangeMobile(Obj,index,type)
{
    var xhr=null;
    var sort=1;
    var value=1;
    if(Obj.checked)
    {
        if(index==1)//mobile mainpage:
        {
            value=prompt("Nhập thứ tự ưu tiên hiển thị:", "1");
            if(value!=null)
            {
                value=parseInt(value);
                if(value!='NaN')
                {
                    sort=value;
                }else
                {
                    alert('Nhập thứ tự ưu tiên hiển thị');
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
                        alert("Lỗi kết nối SQL. Không thể cập nhật. Xin hãy thử lại");
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
           url="AjaxRequest.aspx?menu=mobile1&type=1&insert=1&id=" + Obj.id + "&sort=" + sort  + "&time=" + time;
       }else
       {
           url="AjaxRequest.aspx?menu=mobile1&type=1&insert=0&id=" + Obj.id + "&sort=" + sort +"&time=" + time;
       }
   }
   if(index==2)
   {
       if(Obj.checked)
       {
           url="AjaxRequest.aspx?menu=mobile1&type=2&insert=1&id=" + Obj.id + "&sort=" + sort  + "&time=" + time;
       }else
       {
           url="AjaxRequest.aspx?menu=mobile1&type=2&insert=0&id=" + Obj.id + "&sort=" + sort +"&time=" + time;
       }
   }
   if(index==3)
   {
       if(Obj.checked)
       {
           url="AjaxRequest.aspx?menu=mobile1&type=3&insert=1&id=" + Obj.id + "&sort=" + sort  + "&time=" + time;
       }else
       {
           url="AjaxRequest.aspx?menu=mobile1&type=3&insert=0&id=" + Obj.id + "&sort=" + sort +"&time=" + time;
       }
   }
   xhr.open("GET",url,true);
   xhr.send(null);
}