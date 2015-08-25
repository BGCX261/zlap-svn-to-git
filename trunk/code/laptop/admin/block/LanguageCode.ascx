<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LanguageCode.ascx.cs" Inherits="admin_block_LanguageCode" %>
<div style="text-align: left">
<div id="ShowMess" style="display:none;" class="textsmall"></div>
<table border="0" width="100%" style="background: #EFF5FF">
<tr>
<td width="40%" style="text-align: left" class="txtbold">
    <span style="color: #000099"><strong>
    Từ khóa</strong></span> <span style="color: #ff0066">
        *</span>
    <input  type="text" id="textkey" maxlength="20" style="width: 120px"/>
</td>
<td width="60%" align=left style="text-align: center" class="txtbold">
    <span style="color: #000099"><strong>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    Mô tả </strong></span>&nbsp; &nbsp;
    <input  type="text" id="textdes" maxlength="200" style="width:60%"/>
</td>
</tr>
<tr><td colspan="2">
<input  type="button" class="button_white" value="Thêm mới" id ="Add" onclick="AddRe();" />&nbsp;
<input  type="button" class="button_white" value="Chỉnh sửa" id="Edit" onclick="EditRecord();" />
</td></tr>
</table>
<table border=0 width="100%" style="background: #EFF5FF">
<tr>
    <td align=left nowrap="nowrap">
        <input id="btnDelete" type="button" class="button_white" class="button_white" value="Xóa bỏ" onclick='GetChoiceDelete(); return true;'/>&nbsp;
        <input  type=button class="button_white" value="Hiện toàn bộ" onclick="ShowAll();" id="Button1"/>
    </td>
    <td align=right style="width: 767px; height: 31px; text-align: right">
        <span style="color: #000099"><strong>
        Tìm từ khoá </strong></span>
        <input  type=text id="TextSerach" style="width: 120px"/> 
    </td>
    <td style="height: 31px">
        <input  type=button class="button_white" value="Tìm kiếm" onclick='Search();'/>
    </td>
</tr>
</table>
<table id="Table1" style="background: #EFF5FF" cellpadding="0" width="100%">
<tr class='titletbl'><td align="left">Những từ khóa chuẩn của ngôn ngữ</td>
</tr></table>       
<div id="Page"></div>
<div class="div_bottom_page">
<table border="0" width="100%" style="background: #EFF5FF;">
<tr>
    <td  align="left" width="10%" style="height: 26px">
        <div id="ShowSizePage"></div>
    </td>
    <td width="10%" align="left" style=" height: 26px">
        <input type="button" class="button_white"  id="Button2"  value="|<" onclick="ChangePage(1);"/><input type="button" class="button_white"  id="Button4" value="<" onclick="ChangePage(2);"/><input type="button" class="button_white"  id="Button5" value=">" onclick="ChangePage(3);"/><input type="button" class="button_white"  id="Button6" value=">|" onclick="ChangePage(4);"/>
    </td>
    <td width="80%" align="right" style="height: 26px">   
       <div id="ShowNumberRecord"></div>
    </td>
</tr>
</table>
</div>
</div>
<script type="text/javascript" language="javascript">
//Ham cat xau co khoang trang dau cuoi
function trimAll(sString)
{
	while (sString.substring(0,1) == ' ')
	{
		sString = sString.substring(1, sString.length);
	}
	while (sString.substring(sString.length-1, sString.length) == ' ')
	{
		sString = sString.substring(0,sString.length-1);
	}
	return sString;
}
//Ham kiem tra xau rong	
function isEmpty(s)
{   
	return ((s == null) || (s.length == 0));
}
//kiem tra khoang trang
function isWhitespace(s)
{   
	var whitespace = " \t\n\r";
	var i;

  if (isEmpty(s)) return true;
  for (i = 0; i < s.length; i++)
  {   
    var c = s.charAt(i);
    if (whitespace.indexOf(c) == -1) return false;
  }
  return true;
}

    // kiem tra key khong duoc phep (trong, co khoang trang, khong co ki tu la, ki tu khong la so)
	function Check_Key(Key)
	{        
        var str_key=new String(Key);
        var str_temp="abcdefghikjlmnopqrstuvwxyzABCDEFGHIKJLMNOPQRSTUVWXYZ_";       
        var i,j;
		var bool=true;		
		
        if(isEmpty(str_key))
		{
//            alert("Key Name Khong duoc phep trong!");
			return "Từ khóa không được phép trống!";
        }
        else
        {
            //Kiem tra khoang trang
            if(str_key.indexOf(" ")!= -1)
            {
//                alert("key không được có dấu cách !");
				return "Từ khóa không được có dấu cách!";
            }
            else
            {
            //Kiem tra cac ki tu trong xau thuoc cac ki tu cua mang mau
		      for(i=0;i<str_temp.length;i++)
		      {		          
				  if(str_temp.indexOf(str_key.substring(i,i+1))==-1)
                     bool=false;
              }
              if(bool==false)
              {
                //alert("Key khong duoc co dau!");
				return "Từ khóa chuẩn không đúng định dạng. Phải là chữ cái (a-z, A-Z) hoặc dấu '_'.!!";
              } 
              else if(str_key.length>20)
              {
                alert("Độ dài không quá 20 ký tự  !");
				return " Độ dài không quá 20 ký tự !";              
              }
              else
			  {
				return "";
			  }  
		   }
        }
	}	

//phan quyen
function SetRight()
{
    var Ad="<%Response.Write(Add_language_code);%>";
    var De="<%Response.Write(Delete_language_code);%>";
    var Edit="<%Response.Write(Edit_language_code);%>";
    if(Ad=="true" ||Ad=="True" )
    {        
        document.getElementById("Add").disabled=false;
    }
    else
    {
         document.getElementById("Add").disabled=true;
    }
    if(De=="true" ||De=="True" )
    {            
        document.getElementById("btnDelete").disabled=false;
    }
    else
    {
        document.getElementById("btnDelete").disabled=true;
    }
    if(Edit=="true" ||Edit=="True" )
    {            
        document.getElementById("Edit").disabled=false;
    }
    else
    {
        document.getElementById("Edit").disabled=true;
    }
}
SetRight();
function OnchoiceAll(id_Choice)
   {
        document.getElementById("ShowMess").innerHTML="";
        document.getElementById("ShowMess").style.display="none";
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
   
    function GetChoiceDelete()
   {
        document.getElementById("ShowMess").innerHTML="";
        document.getElementById("ShowMess").style.display="none";
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
    var message="Bạn có chắc chắn muốn xóa những từ khóa đã chọn không ?"; 
    if (str_id.length>0)
    {
         var boo=confirm(message);
         if (boo)
         {
            var Obj= admin_block_LanguageCode.Delete(str_id);
            if(Obj.value == "")
            {               
                ChangePage(0);
                document.getElementById("ShowMess").innerHTML="Những từ khóa bạn chọn đã được xóa bỏ !"; 
                document.getElementById("ShowMess").style.display="block";
            }
            else
            {
                document.getElementById("ShowMess").innerHTML=Obj.value;
                document.getElementById("ShowMess").style.display="block";
            }
         }
         else
         {
            document.getElementById("ShowMess").innerHTML="";
            document.getElementById("ShowMess").style.display="block";
         }
    }  
    else
    {
        document.getElementById("ShowMess").innerHTML="Hãy chọn từ khóa muốn xóa bỏ. !";
        document.getElementById("ShowMess").style.display="block";
    }
   }
   
var ChangPage_Seach = false;
function ChangePage(action)
{
    document.getElementById("ShowMess").innerHTML="";
    var Obj;
    var NumberRecord;
    var NumberRecord_Serach;
    if(ChangPage_Seach==true)
    {
        Obj=admin_block_LanguageCode.ShowData_Search(action);
        NumberRecord_Serach  = admin_block_LanguageCode.ShowNumberRecord_Search();
    }
    else
    {
        Obj=admin_block_LanguageCode.ShowData(action);
        NumberRecord  = admin_block_LanguageCode.ShowNumberRecord();
    }
    if(Obj!=null)
    {
        var value=Obj.value;
        var ObjDiv=document.getElementById("Page");
        var ObjShowNumberRecord=document.getElementById("ShowNumberRecord");
        if(ObjDiv!=null)
        {
            ObjDiv.innerHTML=value[1];
            if(NumberRecord==null)
            {
                document.getElementById("ShowMess").style.display="none";               
                document.getElementById("ShowMess").innerHTML=NumberRecord_Serach.value; 
                document.getElementById("ShowMess").style.display="block"; 
                ObjShowNumberRecord.innerHTML="";               
            }
            else
            {
                ObjShowNumberRecord.innerHTML=NumberRecord.value;
            }
            var Number=value[4];
            if(Number==0)
            {               
                document.getElementById("btnDelete").disabled=true;
            }
            else
            {
                document.getElementById("btnDelete").disabled=false;                                     
                SetRight();              
            }
        }
        ObjDiv=document.getElementById("ShowSizePage");
        if(ObjDiv!=null)
        {
            ObjDiv.innerHTML=value[0];
        }
        var isFirst=value[2];
        var isLast=value[3];
        Disablebutton(isFirst,isLast);
    }
}
function Disablebutton(isFirst,isLast)
{
    var Objbutton;
    if((isFirst=="True")|(isFirst=="true"))
    {
        
        Objbutton=document.getElementById("first");
        if(Objbutton!=null)
        {
            Objbutton.disabled=true;           
        }
        Objbutton=document.getElementById("previous");
        if(Objbutton!=null)
        {
            Objbutton.disabled=true;          
        }
    }else
    {
        Objbutton=document.getElementById("first");
        if(Objbutton!=null)
        {
            Objbutton.disabled=false;           
        }
        Objbutton=document.getElementById("previous");
        if(Objbutton!=null)
        {
            Objbutton.disabled=false;           
        }
    }
    if((isLast=="True") | (isLast=="true"))
    {
        Objbutton=document.getElementById("next");
        if(Objbutton!=null)
        {
            Objbutton.disabled=true;            
        }
        Objbutton=document.getElementById("last");
        if(Objbutton!=null)
        {
            Objbutton.disabled=true;         
        }
    }else
    {
        Objbutton=document.getElementById("next");
        if(Objbutton!=null)
        {
            Objbutton.disabled=false;            
        }
        Objbutton=document.getElementById("last");
        if(Objbutton!=null)
        {
            Objbutton.disabled=false;           
        }
    }
}

function AddRe()
{    
    var key,des,mess;
    document.getElementById("ShowMess").style.display="none";
    key=document.getElementById("textkey").value;
    des=document.getElementById("textdes").value; 
    key=trimAll(key);
    des=trimAll(des);
    mess=Check_Key(key);
    if(mess=="")
    {
        mess=admin_block_LanguageCode.Add(key,des).value;
        if(mess=="")
        {
            ChangePage(0);
            document.getElementById("ShowMess").innerHTML="Từ khóa chuẩn đã được thêm. !";
            document.getElementById("ShowMess").style.display="block";
            ClernText();
        }
        else
        {
              document.getElementById("ShowMess").innerHTML=mess;
              document.getElementById("ShowMess").style.display="block";
        }
    } 
    else
    {  
        document.getElementById("ShowMess").innerHTML=mess;
        document.getElementById("ShowMess").style.display="block";
    }       
}
var odl_key="";
function ShowInfor(Obj)
{   
    if(Obj!=null)
    {
        odl_key=Obj.id;
        document.getElementById("ShowMess").innerHTML="";
        document.getElementById("textkey").value=Obj.id;
        document.getElementById("textdes").value=Obj.title;       
    }
}
//sua ban ghi
function EditRecord()
{
    var key,des,mess;
    document.getElementById("ShowMess").style.display="none";
    key=document.getElementById("textkey").value;
    des=document.getElementById("textdes").value; 
    key=trimAll(key);
    des=trimAll(des);
    mess=Check_Key(key);      
    if(odl_key=="")
    {
        document.getElementById("ShowMess").innerHTML=" Mời bạn chọn giữ liệu muốn chỉnh sửa !";
        document.getElementById("ShowMess").style.display="block";
    }
    else
    {
        if(mess=="")
        {
            mess=admin_block_LanguageCode.Edit(odl_key,key,des).value;
            if(mess=="")
            {
                odl_key="";
                ChangePage(0);
                document.getElementById("ShowMess").innerHTML="Từ khóa đã được cập nhật !";
                document.getElementById("ShowMess").style.display="block";
                ClernText();
            }
            else
            {     ChangePage(0); 
                  document.getElementById("ShowMess").innerHTML=mess;
                  document.getElementById("ShowMess").style.display="block";
                  ClernText();
            }
        } 
        else
        {  
            document.getElementById("ShowMess").innerHTML=mess;
            document.getElementById("ShowMess").style.display="block";
        } 
   }
  
}

function ClernText()
{
    document.getElementById("textkey").value="";
    document.getElementById("textdes").value="";
//    document.getElementById("TextSerach").value="";
}
//tim kiem tu khoa
function Search()
{
    document.getElementById("ShowMess").style.display="none";
    var keysearch=document.getElementById("TextSerach").value;
    admin_block_LanguageCode.Search(keysearch);
    if(document.getElementById("TextSerach").value!="")
    {        
        ChangPage_Seach = true;
        ChangePage(0); 
    }
    else
    {                //alert("Vui lòng nhập từ khóa tìm kiếm");
        document.getElementById("ShowMess").innerHTML="Vui lòng nhập từ khóa tìm kiếm.";
        document.getElementById("ShowMess").style.display="block";
//        alert("Vui lòng nhập từ khóa tìm kiếm");
//        ChangPage_Seach = false; 
    }
//    ChangePage(0);   
}

//hien thi tat ca
function ShowAll()
{
    ChangPage_Seach = false;
    document.getElementById("TextSerach").value="";
    ChangePage(0);
}


//hien thi cac button
//function ShowButton()
//{
//    var NumberRecord  = admin_block_LanguageCode.ShowNumberRecord_Search()
//    var NumberRecord  = admin_block_LanguageCode.ShowNumberRecord()
//}

ChangePage(0);
function Back() 
{
    location.href="AdminWebsite.aspx";
}

</script>