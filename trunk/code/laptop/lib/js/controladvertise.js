// Js for control advertise left and right....[SungLE]
function ObjAdvertise(id_Obj,top,left,width,height)
{
	this.id_div=id_Obj;
	this.id_change=null;
	this.Obj=null;
	this.top_screen=top;
	this.left_screen=left;
	this.width=width;
	this.height=height;
	this.N=(document.all) ? 0 : 1; 
	this.fnOnStart=function()
	{
		this.Obj=document.getElementById(this.id_div);
		{
			if(this.Obj!=null)
			{
				//this.Obj.style.display="";
				if(this.N)
				{
					this.Obj.style.top=(this.top_screen + 50) + "px";
					this.Obj.style.left=this.left_screen + "px";
				}
				else
				{
					this.Obj.style.pixelLeft=this.left_screen;
					this.Obj.style.pixelTop=this.top_screen + 50;
				}
			}
		}
	}
	this.fnRepeat=function()
	{
		ChangeDiv(this.id_div,this.width,this.height);
	}
	ChangeDiv=function(id,width,height)
    {
	    var fnname="ChangeDiv('" + id + "'," + width+ "," + height + ")";
	    var index_top= document.documentElement.scrollTop;
	    this.Obj=document.getElementById(id);
	    if(this.Obj==null)
	    {
	        return;
	    }
	    if(this.N)
	    {
		    var widthW=window.innerWidth - width;
		    var clientHeight=window.innerHeight - height;
		    index_top=index_top + clientHeight;
		    this.Obj.style.top=index_top + "px";
		    this.Obj.style.left=widthW + "px";
	    }else
	    {
		    var widthW=document.body.offsetWidth - width;
		    var clientHeight=document.documentElement.clientHeight - height;
		    this.Obj.style.pixelLeft=widthW;
		    this.Obj.style.pixelTop=index_top + clientHeight;
	    }
	    setTimeout(fnname,150);
    }
}
var isContentLink=false;
var timeOutLink=null;
function ShowValue1()
{
    var len=document.getElementById("divLink").innerHTML.length;
    if(len<100)
    {
        document.getElementById("divLink").innerHTML="<div class='dlink'><table><tr><td><a href='DTDD/Default.aspx'><img src='image/common/mobile.png' border='0' /></a></td><td><a href='Default.aspx'><img src='image/common/linklaptop.jpg' border='0' /></a></td></tr><tr align='center' class='text_title'><td><a href='DTDD/Default.aspx'>Điện thoại di động</a></td><td><a href='Default.aspx'>Máy Tính xách tay</a></td></tr></table></div>";
    }
    isContentLink=true;
}
function isOutLink()
{
    isContentLink=false;
    clearTimeout(timeOutLink);
    timeOutLink=setTimeout("ClearValue()",500);
}
function ClearValue()
{
    if(isContentLink==false)
    {
        document.getElementById("divLink").innerHTML="<img src='image/common/linkmenu1.png' />";
    }
}


// Create By SungLE for Online:
var dOnlineOld="";
function OnMOverDOnline(id)
{
	if(dOnlineOld.length==0)
	{
		dOnlineOld="donline"+ id;
	}else
	{
		CShowD(0);
		dOnlineOld="donline"+ id;
	}
	var Obj=document.getElementById("donline"+ id);
	if(Obj!=null)
	{
		scripShowD(Obj);
	}
	}
function scripShowD(Obj)
{
	if(Obj!=null)
	{
		Obj.style.display="";
	}
}
function CShowD(id)
{
	var Obj=document.getElementById(dOnlineOld);
	if(Obj!=null)
	{
		if(id==1)
		{
			Obj.style.display="";
		}else
		{
			Obj.style.display="none";
		}
	}
}