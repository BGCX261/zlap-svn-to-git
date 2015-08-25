<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LanguageManager.ascx.cs" Inherits="admin_block_LanguageManager" %>
<div style="text-align: left">
<div id="dvMsg" style="color:Red; display: none" class="textsmall"></div>
<table border=0 width="100%" style="background: #EFF5FF">
    <tr>
    <td align="left">
        <input type="button" id="Back" class="button_white" value="Quay lại" language="javascript" onclick="return Back_onclick()" />
     </td>
    </tr>
    <tr>
        <td class="titletbl" align="left">
            Danh sách ngôn ngữ sử dụng
        </td>
    </tr>
    
    <tr>
        <td><div id="divLanguage"></div>
        </td>
    </tr>
</table>
</div>
<script type="text/javascript">
//Phan quyen
function SetRight()
{
    var RightDel="<% Response.Write(right_delete);%>";
    var RightAdd="<% Response.Write(right_addnew);%>";
    if((RightDel=="False")|(RightDel=="false"))
    {
        document.getElementById("btnDelete").disabled=true;
    }
    if((RightAdd=="False")|(RightAdd=="false"))
    {
        document.getElementById("addnew").disabled=true;
    }
    
}
SetRight();
//Dieu huong den trang quan tri rieng tung ngon ngu
function NavigatorToLang(url,name)
{
    var bool;
    bool=admin_block_LanguageManager.SetAdminLanguage(url,name);
    if(bool)
    {
        location.href="AdminWebsite.aspx?menu=langcontent";
    }
    
}

//Load du lieu trinh bay
function LoadLanguage()
{
    var obj = admin_block_LanguageManager.LoadLanguage().value;
    if(obj[1]=="0")
    {
        document.getElementById("divLanguage").innerHTML = obj[0]+"<br><div style='color:Red;'>Không tìm thấy file ngôn ngữ nào!</div>";
    }
    else
    {
        document.getElementById("divLanguage").innerHTML = obj[0];
    }
}
LoadLanguage();


function OnchoiceAll(id_Choice)
{
    var ObjChoice=document.getElementById(id_Choice);
    var ObjGroup=document.getElementsByName("CheckGroup"); 
    var i;
    
    if (ObjChoice!=null)
    {
        if (ObjChoice.checked)
        {
            if (ObjGroup!=null)
            {
              for (i=0;i<ObjGroup.length;i++)
              {
                 ObjGroup[i].checked=true;
              }   
            }
        }else
        {
            if (ObjGroup!=null)
            {
              for (i=0;i<ObjGroup.length;i++)
              {
                ObjGroup[i].checked=false;
              }   
            }
        }
    } 
}

function CheckOne()
{     
    //Kiem tra neu co item nao khong check thi bat loai bo checkAll
    var boo=true;
    var i;
    var ObjChoice=document.getElementById('chkAll');
    var ObjGroup=document.getElementsByName('CheckGroup'); 
    for (i=0;i<ObjGroup.length;i++)
    {
        if(ObjGroup[i].checked==false)
           ObjChoice.checked=false;
    }
    
    //Kiem tra cac Item deu check thi bat CheckAll
    for (i=0;i<ObjGroup.length;i++)
    {
        if(ObjGroup[i].checked==false)
          boo=false;
    }
    
    if(boo)
    {
        ObjChoice.checked=true;
    }
}

  function GetChoiceDelete()
   {
        var ObjChoice=document.getElementsByName("CheckGroup"); 
        var num_Check_Group,i;
        var str="";
        if (ObjChoice!=null)
        {
            num_Check_Group=ObjChoice.length;
            for (i=0;i<num_Check_Group;i++)  
            {
                if (ObjChoice[i].checked)
                {
                    str= str + ObjChoice[i].id + ",";  
                }
            }
        }
        Delete(str);
   }
   function Delete(str_id)
   {
    var message="Bạn có chắc chắn muốn xóa những ngôn ngữ đã chọn không ?"; 
    if (str_id.length>0)
    {
         var boo=confirm(message);
         if (boo)
         {
            var Obj= admin_block_LanguageManager.DeleteLanguage(str_id);
            if(Obj.value == "")
            {
                LoadLanguage();
                document.getElementById("dvMsg").innerHTML="Những ngôn ngữ bạn chọn đã được xóa!";
                document.getElementById("dvMsg").style.display="block";
                
            }
            else
            {
                document.getElementById("dvMsg").innerHTML=Obj.value;
                document.getElementById("dvMsg").style.display="block";
            }
         }
    }  
    else
    {
        document.getElementById("dvMsg").innerHTML="Bạn phải chọn ngôn ngữ muốn xóa !";
        document.getElementById("dvMsg").style.display="block";
    }
   }
function addnew_onclick() 
{
    location.href="AdminWebsite.aspx?menu=lang_add";
}

function Back_onclick() 
{
    location.href="AdminWebsite.aspx";
}

</script>