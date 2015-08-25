//Copy right: Vu Duc Dat
//Email     : luidmangranh@yahoo.com
// JScript File
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

function isEmpty(s)
{   
	return ((s == null) || (s.length == 0));
}

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
//Ham kiem tra ki tu la so
function isNuber(c)
{
	var str_temp='0123456789';
	var boo=false;
	if(str_temp.indexOf(c)==-1)
	   boo=false;
	else
	   boo=true;

	return boo;
}
function isNubers(str)
{
var isOK=true;
for(var i=0;i<str.length;i++)
	{
		if(!isNuber(str.charAt(i)))
			{
				isOK=false;
				break;
			}
	}
	return isOK;	
}
function isDouble(sString)
{
  var boo=false;
  var str=trimAll(sString);
  var temp=str.split(".");
  if(temp.length==2)
  {
  	if(temp[0]=="" || temp[1]=="")
  	    boo=false;
  	else if(isNubers(temp[0]) && isNubers(temp[1]))
	    boo=true;
	else
		boo=false;
  }
  else if(isNubers(str))
  {
		boo=true;
  }
  else
  		boo=false;		
 return boo;
}
//Ham ve du lieu len cac combox
 function MakeSelect(obj_id,arr_text,arr_value)
 {
		var ln=arr_text.length>arr_value.length?arr_value.length:arr_text.length;
		document.getElementById(obj_id).style.visibility="visible";
		var x=document.getElementById(obj_id);
		var y;
		if(x.length==0)
		{
			for( var i=0;i<ln;i++)
			{
			//insert_Option(obj_id,arr_text[i],arr_value[i]);
			  y=document.createElement('option');
  				y.text=arr_text[i];
 			 	y.value=arr_value[i];
  			
 			 try
    			 {
    				x.add(y,null); // standards compliant
   				 }
			  catch(ex)
   				 {
   					 x.add(y); // IE only
   				 }
			}
		}
 }
 
 function insertOption(id,_text,_value)
  {
  var y=document.createElement('option');
  y.text=_text;
  y.value=_value;
  var x=document.getElementById(id);
  try
    {
    x.add(y,null); // standards compliant
    }
  catch(ex)
    {
    x.add(y); // IE only
    }
   }
 //Xoa toan bo du lieu trong the Select
function ClearSelect(id)
{
  var x=document.getElementById(id);
  while(x.length>0)
  {
  	x.remove(x.options[x.length-1]);
  }
}
 
//Ham thiet dat gia tri cho the Select

 function SelectIndexByValue(select_id,_value)
{
    var Obj_Select=document.getElementById(select_id);
    var len=Obj_Select.length;
    for(var i=0;i<len;i++)
    {
        if(Obj_Select.options[i].value==_value)
        {
            Obj_Select.options[i].selected=true;
        }
    } 
}
function SelectIndexByText(select_id,_text)
{
    var Obj_Select=document.getElementById(select_id);
    var len=Obj_Select.length;
    for(var i=0;i<len;i++)
    {
        if(Obj_Select.options[i].text==_text)
        {
            Obj_Select.options[i].selected=true;
        }
    } 
}

//Ham kiem tra tinh hop le cua str chi duoc phep gom cac ki tu [a-z][A-Z],[0-9] and '_'
function TestString(str)
{
    var bool = true;
    var str_temp="abcdefghikjlmnopqrstuvwxyzABCDEFGHIKJLMNOPQRSTUVWXYZ0123456789_";
    for(i=0;i<str.length;i++)
    {
		if(str_temp.indexOf(str.substring(i,i+1))==-1)
        bool=false;
    }
    return bool;
}

function Check_Select(select_id)
{
	var Obj_Select=document.getElementById(select_id);
	
	var boo=false;
	
    for(var i=1;i<Obj_Select.options.length;i++)
	{
        
        if(Obj_Select.options[i].selected==true)
            boo=true;       
    }
    return boo;
}
function HtmlEnCode(str)
{
	var test=String(str);
	var i=0;
	while(i<test.length)
	{
		test=test.replace("<","&lt;");
		test=test.replace(">","&gt;");
		i++;
	}
	return test;
}
function HtmlDecode(str)
{
    var test=String(str);
	var i=0;
	while(i<test.length)
	{
		test=test.replace("&lt;","<");
		test=test.replace("&gt;",">");
		i++;
	}
	return test;
}