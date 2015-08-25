// JavaScript Document
var isHidden=false;
var idDivShow="dListName";
var Nclient = (document.all) ? 0 : 1;
function EffectShowDiv(id)
{
	var ObjDiv=document.getElementById(idDivShow);
	if(ObjDiv!=null)
	{
		if(Nclient)
		{
			var intwidth=parseInt(ObjDiv.style.width);
			if(intwidth<140)
			{
				intwidth=intwidth + 10;
				if(intwidth>140)
				{
					//intwidth=140;
					//Getdate...
					RequestCommon(10,id);
				}
				ObjDiv.style.width=intwidth + "px";
				var Func="EffectShowDiv("+id+")";
				setTimeout(Func,50);
			}
		}else
		{
			var intwidth=parseInt(ObjDiv.style.width);
			if(intwidth<=140)
			{
				intwidth=intwidth + 10;
				if(intwidth>140)
				{
					//intwidth=140;
					RequestCommon(10,id);
				}
				ObjDiv.style.width=intwidth;
				var Func="EffectShowDiv("+id+")";
				setTimeout(Func,50);
			}
		}
	}
}
function OnOverDiv()
{
	isHidden=false;
}
function OnMOMenu(id,array,type,e)
{
	isHidden=false;
	var ObjDiv=document.getElementById(idDivShow);
	if(ObjDiv!=null)
	{
		ObjDiv.style.display="";
		ObjDiv.innerHTML="<img src='image/common/wait.gif' />";
		//ObjDiv.style.width="5px";
		RequestCommon(type,array,id);
		var divheight=parseInt(ObjDiv.clientHeight/2);
		if(Nclient)
		{
		    var _y=parseInt(e.pageY) - divheight;
            var _x=parseInt(e.pageX) + 30;
            _y=_y + "px";
            _x=_x + "px";
            ObjDiv.style.top = _y;
            ObjDiv.style.left =_x;
        }else
        {  
            ObjDiv.style.pixelLeft = event.clientX + document.documentElement.scrollLeft + 30;	
		    ObjDiv.style.pixelTop = event.clientY + document.documentElement.scrollTop - divheight;
        }
		//EffectShowDiv(id);
		//var nFunc="GetBCom("+ index +"," + type + "," + arrayValue[1] + ");";
		//setTimeout(nFunc,500);
	}
}
function TimeHidden()
{
	isHidden=true;
	var Func="FuncHidden()";
	setTimeout(Func,800);
}
function FuncHidden()
{
	if(!isHidden)
	{
		return;
	}
	var ObjDiv=document.getElementById(idDivShow);
		if(ObjDiv!=null)
		{
			//ObjDiv.innerHTML="";
			ObjDiv.style.display="none";
		}
}