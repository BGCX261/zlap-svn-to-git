<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LanguageContent.ascx.cs" Inherits="admin_block_LanguageContent" %>
<div style="text-align: left">
<div id="ShowMess" style="display:none;" class="textsmall"></div>
<table border="0" width="100%" style="background: #EFF5FF">
<tr>
<td width="40%" style="text-align: left" class="txtbold">
    <span style="color: #000099"><strong>
    Từ khóa</strong></span> <span style="color: #ff0066">
        *</span>
    <select id="textkey" style="width: 120px">
    </select>
</td>
<td width="60%" align=left style="text-align: center" class="txtbold">
    <span style="color: #000099"><strong>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    Nội dung hiển thị </strong></span>&nbsp; &nbsp;
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
        <input  type=button class="button_white" value="Hiện toàn bộ" onclick="ShowAll();" id="Button4"/>
    </td>
    <td align=right style="width: 767px; height: 31px; text-align: right">
        <span style="color: #000099"><strong>
        Tìm từ khoá </strong></span>
        <input  type=text id="TextSearch" style="width: 120px"/> 
    </td>
    <td style="height: 31px">
        <input  type=button class="button_white" value="Tìm kiếm" onclick='Search();'/>
    </td>
</tr>
</table>  
<table id="Table1" style="background: #EFF5FF" cellpadding="0" width="100%">
<tr class='titletbl'><td align="left"><strong>Nhập nội dung ngôn ngữ : &nbsp;&nbsp;</strong></span><span style="color: #6600ff; text-decoration: underline"><strong><%Response.Write(Name_language);%></strong></td>
</tr></table>       
<div id="Page"></div>
<div class="div_bottom_page">
<table border="0" width="100%" style="background: #EFF5FF;">
<tr>
    <td  align="left" width="10%" style="height: 26px">
        <div id="ShowSizePage"></div>
    </td>
    <td width="10%" align="left" style=" height: 26px">
        <input type="button" class="button_white"  id="Button5"  value="|<" onclick="ChangePage(1);"/><input type="button" class="button_white"  id="Button6" value="<" onclick="ChangePage(2);"/><input type="button" class="button_white"  id="Button7" value=">" onclick="ChangePage(3);"/><input type="button" class="button_white"  id="Button8" value=">|" onclick="ChangePage(4);"/>
    </td>
    <td width="80%" align="right" style="height: 26px">   
       <div id="ShowNumberRecord"></div>
    </td>
</tr>
</table>
</div>
</div>
<script type="text/javascript" src="lib/js/ultility.js"></script>
<script type="text/javascript" language="javascript">
//phan quyen
var ShowEdit=false;
function SetRight()
{
    var Ad="<%Response.Write(Add_language_content);%>";
    var De="<%Response.Write(Delete_language_content);%>";
    var Edit="<%Response.Write(Edit_language_content);%>";
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
    if((Edit=="true" ||Edit=="True") && (ShowEdit==true))
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
    document.getElementById("ShowMess").style.display="none";
    var message="Bạn có chắc chắn muốn xóa những từ khóa đã chọn không ?"; 
    if (str_id.length>0)
    {
         var boo=confirm(message);
         if (boo)
         {
            var Obj= admin_block_LanguageContent.Delete(str_id);
            if(Obj.value == "")
            {               
                ChangePage(0);
                document.getElementById("ShowMess").innerHTML="Những nội dung bạn chọn đã được xóa bỏ !"; 
                document.getElementById("ShowMess").style.display="block";
                
            }
            else
            {
                ChangePage(0);
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
        document.getElementById("ShowMess").innerHTML="Hãy chọn nội dung muốn xóa bỏ. !";
        document.getElementById("ShowMess").style.display="block";
    }
   }
   
   //ham lay ve so key chua co noi dung
function LoadDataToCombox()
{  
   ClearSelect("textkey"); 
   document.getElementById("textkey").value="";
   var ArrReturn=admin_block_LanguageContent.GetNumberKeyNotContent().value;
   var len=ArrReturn.length;  
   if(len>0)
   {
      MakeSelect('textkey',ArrReturn,ArrReturn)
   } 
}
LoadDataToCombox();
   
var ChangPage_Seach = false;
function ChangePage(action)
{
    LoadDataToCombox();  
    document.getElementById("ShowMess").innerHTML="";
    var Obj;
    var NumberRecord;
    var NumberRecord_Search;   
    if(ChangPage_Seach==true)
    {
        Obj=admin_block_LanguageContent.ShowData_Search(action);
        NumberRecord_Search  = admin_block_LanguageContent.ShowNumberRecord_Search();        
    }
    else
    {
        Obj=admin_block_LanguageContent.ShowData(action);
        NumberRecord  = admin_block_LanguageContent.GetNumberKeyNoContent();  
    }

    if(Obj!=null)
    {
        var value=Obj.value;
        var ObjDiv=document.getElementById("Page");
        var ObjShowNumberRecord=document.getElementById("ShowNumberRecord");       
        if(ObjDiv!=null)
        {
            ObjDiv.innerHTML=value[1];
            if(value[5]=="")
            {
                if(NumberRecord==null)
                {                   
                    document.getElementById("ShowNumberRecord").innerHTML="";
                    document.getElementById("ShowMess").style.display="none";    
                    document.getElementById("ShowMess").innerHTML=NumberRecord_Search.value;
                    document.getElementById("ShowMess").style.display="block";    
                }
                else
                { 
                    ObjShowNumberRecord.innerHTML=NumberRecord.value; 
                }
            }
            else
            {
                ObjShowNumberRecord.innerHTML=value[5];
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
//kiem tra content
function Check_Infor(content,key)
{      
    var err="";
    if((key==null)||(key.length==0))
    {
        err="Hết từ khóa để bạn chọn lựa.";
    }
    if((content == null) || (content.length == 0))
    {
        err="</br>Hãy nhập nội dung hiển thị của từ khóa.";
    }    
    if(( content.length>200))
    {
            err="</br>Nội dung hiển thị không quá 200 ký tự.";
    }
    return err;
}

function AddRe()
{
    var key,content,mess;
    document.getElementById("ShowMess").style.display="none";    
//    key=document.getElementById("textkey").options[document.getElementById("textkey").selectedIndex].value;    
    key= document.getElementById("textkey").value;  
    content=document.getElementById("textdes").value; 
    key=trimAll(key);
    content=trimAll(content);
    mess=Check_Infor(content,key);
    if(mess=="")
    {
        mess=admin_block_LanguageContent.Add(key,content).value;
        if(mess=="")
        {            
            ChangePage(0);            
            cleanText();
            document.getElementById("ShowMess").innerHTML="Nội dung hiển thị đã được thêm mới. !";
            document.getElementById("ShowMess").style.display="block";    
        }
        else
        {     
              ChangePage(0);           
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
        LoadDataToCombox();
        document.getElementById("Edit").disabled=false;
        document.getElementById("ShowMess").innerHTML="";
        var x=document.getElementById("textkey");
		var y=document.createElement("option");
		y.text=Obj.id;
 	    y.value=Obj.id;  			
 			 try
    			 {
    				x.add(y,null); // standards compliant
   				 }
			  catch(ex)
   				 {
   					 x.add(y); // IE only
   				 }   	   
     	x.selectedIndex=x.length-1;
        odl_key=Obj.id;
        document.getElementById("textdes").value=Obj.title;       
    }
}
//sua ban ghi
function EditRecord()
{
     var key,content,mess;
    document.getElementById("ShowMess").style.display="none";    
//    key=document.getElementById("textkey").options[document.getElementById("textkey").selectedIndex].value;    
    key= document.getElementById("textkey").value;  
    content=document.getElementById("textdes").value; 
    key=trimAll(key);
    content=trimAll(content);
    mess=Check_Infor(content,key);
          
    if(odl_key=="")
    {
        document.getElementById("ShowMess").innerHTML=" Mời bạn chọn từ khóa muốn chỉnh sửa !";
        document.getElementById("ShowMess").style.display="block";
    }
    else
    {
        if(mess=="")
        {
            mess=admin_block_LanguageContent.Edit(odl_key,key,content).value;
            if(mess=="")
            {
                odl_key="";
                ChangePage(0);
                document.getElementById("ShowMess").innerHTML="Từ khóa đã được cập nhật !";
                document.getElementById("ShowMess").style.display="block";
                cleanText();
            }
            else
            {
                  ChangePage(0);  
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
  
}

function cleanText()
{
    document.getElementById("textdes").value="";
//    document.getElementById("TextSearch").value="";
}
////tim kiem tu khoa
function Search()
{
    document.getElementById("ShowMess").style.display="none";
    var keysearch=document.getElementById("TextSearch").value;
    
    if(document.getElementById("TextSearch").value!="")
    {   
        admin_block_LanguageContent.Search(keysearch);     
        ChangPage_Seach = true;
        ChangePage(0); 
    }
    else
    {               
        document.getElementById("ShowMess").innerHTML="Vui lòng nhập từ khóa tìm kiếm.";
        document.getElementById("ShowMess").style.display="block";

    }  
}

//hien thi tat ca
function ShowAll()
{
    ChangPage_Seach = false;
     document.getElementById("TextSearch").value="";
    ChangePage(0);
}
function DisButton()
{
    document.getElementById("Add").disabled=true;
    document.getElementById("Edit").disabled=true;
    document.getElementById("Search").disabled=true;
}
ChangePage(0);
function Back() 
{
    location.href="AdminWebsite.aspx?menu=langsupport";
}

</script>