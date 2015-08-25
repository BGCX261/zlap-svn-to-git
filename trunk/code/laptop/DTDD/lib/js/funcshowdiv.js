var N = (document.all) ? 0 : 1; 
var ObjView;
var X=0;
var Y=0;
var overShow = false;
var offset_x=20;
var offset_y=-70;
var nameObjShow="divSpec";
function OnMOver(e)
{
	if (overShow)
	{
		if (N) {
			ObjView = document.getElementById(nameObjShow);
			if(ObjView!=null)
			{
				var _y=parseInt(e.pageY);
			    var _x=parseInt(e.pageX) + offset_x;
			    if(e.pageY-document.documentElement.scrollTop>390)
		        {
		            _y=_y - document.getElementById(nameObjShow).clientHeight;
		        }else if(e.pageY-document.documentElement.scrollTop>170)
		        {
		            _y=_y - document.getElementById(nameObjShow).clientHeight/2;
		        }
			    _y=_y + "px";
			    _x=_x + "px";
			    ObjView.style.top = _y;
			    ObjView.style.left =_x;
				ObjView.style.display="";
				return false;
			}
		}else
		{
			ObjView = document.getElementById(nameObjShow);
			if(ObjView!=null)
			{
				
				ObjView.style.display="";
				ObjView = ObjView.style;
				var extra=0;
		        if(event.clientY>420)
		        {
		            extra=document.getElementById(nameObjShow).clientHeight;
		        }else if(event.clientY>190)
		        {
		            extra=document.getElementById(nameObjShow).clientHeight/2;
		        }
				ObjView.pixelLeft = event.clientX + document.documentElement.scrollLeft + offset_x;	
			    ObjView.pixelTop = event.clientY + document.documentElement.scrollTop - extra;
				return false;
			}
		}
	}
}
function OnMM(e)
{
	if(overShow)
	{
        if (ObjView!=null)
        {
		    if(N)
		    {
		        var _y=parseInt(e.pageY);
		        var _x=parseInt(e.pageX) + offset_x;
		        if(e.pageY-document.documentElement.scrollTop>390)
		        {
		            _y=_y - document.getElementById(nameObjShow).clientHeight;
		        }else if(e.pageY-document.documentElement.scrollTop>170)
		        {
		            _y=_y - document.getElementById(nameObjShow).clientHeight/2;
		        }
		        _y=_y + "px";
		        _x=_x + "px";
		        ObjView.style.top = _y;
		        ObjView.style.left =_x;
		        
		    }	
		    else 
		    {	
		        var extra=0;
		        if(event.clientY>420)
		        {
		            extra=document.getElementById(nameObjShow).clientHeight;
		        }else if(event.clientY>170)
		        {
		            extra=document.getElementById(nameObjShow).clientHeight/2;
		        }
		        ObjView.pixelLeft = event.clientX + document.documentElement.scrollLeft + offset_x;	
		        ObjView.pixelTop = event.clientY + document.documentElement.scrollTop - extra;
		        return false;
	        }
        }
	}
}
function OnMOut(e)
{
	ObjView = document.getElementById(nameObjShow);
	if(ObjView!=null)
	{
		if(N)
		{
		    ObjView.style.display="none";
		    //ObjView.style.top ="0px";
		    //ObjView.style.left ="0px";
		}
		else
		{
            ObjView.style.display="none";
            ObjView = ObjView.style;
            ObjView.pixelLeft=0;
		}
	}
	overShow=false;
}
//document.onmouseover = OnMOver;
document.onmousemove = OnMM;
//document.onmouseout =OnMOut;

var strTitleValue="";
var stopDiv=0;
var arrayMessage=new Array();
var countMessage=-1;
var indextext=0;
var maxlange=0;
function ControlDiv()
{
	var ObjDiv=document.getElementById("currentAccess");
	if(ObjDiv==null)
	{
	    return;
	}
	if(countMessage==-1)
	{
		//strTitleValue=ObjDiv.innerHTML;
		arrayMessage=strTitleValue.split("@@@");
		strTitleValue=arrayMessage[0];
		maxlange=strTitleValue.length;
		ObjDiv.innerHTML="";
		countMessage=0;
	}
	if(countMessage==0)
	{
		if(stopDiv==0)
		{
		    ObjDiv.innerHTML=ObjDiv.innerHTML + strTitleValue.charAt(indextext);
		}
	}else if(countMessage==1)
	{
	    if(arrayMessage.length==2)
	    {
	        ObjDiv.innerHTML="<marquee scrolldelay='150' onmouseout='start();' width='590' onmouseover='stop();'>" + arrayMessage[1] + ", " + arrayMessage[1] + "</marquee>";
	    }else
	    {
	        ObjDiv.innerHTML="<marquee scrolldelay='150' onmouseout='start();' width='590' onmouseover='stop();'>" + arrayMessage[0] + "</marquee>";
	    }
	    countMessage=2;
	}
	if(countMessage==0 && (indextext<maxlange-1))
	{
		indextext++;
	}else if(countMessage==0)
	{
	    stopDiv++;
	    if(stopDiv>=15)
	    {
	        countMessage=1;
	        indextext=0;
	        stopDiv=0;
	    }
	}else if(countMessage==2)
	{
	    indextext++;
	    if(indextext>=280)
	    {
	        countMessage=0;
	        indextext=0;
	        ObjDiv.innerHTML="";
	    }
	}
	setTimeout("ControlDiv();",100);
}