// JavaScript Document
function ObjStar(id_Obj,top,left,width,height)
{
	this.id_div=id_Obj;
	this.leftmax=900;
	this.maxtop=500;
	this.id_change=null;
	this.Obj=null;
	this.top_screen=top;
	this.changetop=3;
	this.changeleft=2;
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
				var divstar=8-7*Math.random();
				divstar=parseInt(divstar);
				if(divstar==0)
				{
					divstar=1;	
				}else if(divstar>6)
				{
					divstar=6;
				}
				this.Obj.innerHTML="<div class='star"+ divstar +"'>*</div>";
				if(this.N)
				{
					var onstarttop=-500*Math.random();
					onstarttop=parseInt(onstarttop);
					this.Obj.style.top=onstarttop + "px";
					var numleft=100 + this.leftmax*Math.random();
					numleft=parseInt(numleft);
					this.Obj.style.left=numleft +"px";
				}
				else
				{
					var onstarttop=-500*Math.random();
					onstarttop=parseInt(onstarttop);
					this.Obj.style.pixelTop=onstarttop;
					var numleft=100+ this.leftmax*Math.random();
					numleft=parseInt(numleft);
					this.Obj.style.pixelLeft=numleft;
				}
			}
		}
	}
	this.fnRepeat=function()
	{
		//var index_top= document.documentElement.scrollTop;
		//index_top=index_top+60;
		if(this.N)
		{
			var current_top=parseInt(this.Obj.style.top);
			var current_left=parseInt(this.Obj.style.left);
			var changetop=this.changetop*Math.random();
			changetop=parseInt(changetop);
			var changeleft=this.changeleft-this.changeleft*2*Math.random();
			changeleft=parseInt(changeleft);
			current_top=current_top+changetop;
			current_left=current_left+changeleft;
			this.Obj.style.top=current_top + "px";
			this.Obj.style.left=current_left + "px";
		}else
		{
			var current_top=parseInt(this.Obj.style.pixelTop);
			var current_left=parseInt(this.Obj.style.pixelLeft);
			var changetop=this.changetop*Math.random();
			changetop=parseInt(changetop);
			current_top=current_top+changetop;
			var changeleft=this.changeleft-this.changeleft*2*Math.random();
			changeleft=parseInt(changeleft);
			current_left=current_left+changeleft;
			this.Obj.style.pixelTop=current_top;
			this.Obj.style.pixelLeft=current_left;
		}
		var name="ChangeDiv('" + this.id_div + "');";
		setTimeout(name,50);
		//var nameFunction=this.fnRepeat();
	}
}
function ChangeDiv(id)
{
	var fnname="ChangeDiv('" + id + "')";
	this.N=(document.all) ? 0 : 1;
	this.Obj=document.getElementById(id);
	this.changetop=4;
	this.changeleft=3;
	this.maxtop=500;
	if(this.N)
	{
		var current_top=parseInt(this.Obj.style.top);
		var current_left=parseInt(this.Obj.style.left);
		var changetop=this.changetop*Math.random();
		changetop=parseInt(changetop);
		var changeleft=this.changeleft-this.changeleft*2*Math.random();
		changeleft=parseInt(changeleft);
		current_top=current_top+changetop;
		current_left=current_left+changeleft;
		if(current_top>this.maxtop)
		{
			var onstarttop=-300*Math.random();
			onstarttop=parseInt(onstarttop);
			current_top=onstarttop;
			var divstar=8-7*Math.random();
			divstar=parseInt(divstar);
			if(divstar==0)
			{
				divstar=1;	
			}else if(divstar>6)
			{
				divstar=6;
			}
			this.Obj.innerHTML="<div class='star"+ divstar +"'>*</div>";
		}
		this.Obj.style.top=current_top + "px";
		this.Obj.style.left=current_left + "px";
	
	}else
	{
		var current_top=parseInt(this.Obj.style.pixelTop);
		var current_left=parseInt(this.Obj.style.pixelLeft);
		var changetop=this.changetop*Math.random();
		changetop=parseInt(changetop);
		current_top=current_top+changetop;
		var changeleft=this.changeleft-this.changeleft*2*Math.random();
		changeleft=parseInt(changeleft);
		current_left=current_left+changeleft;
		if(current_top>this.maxtop)
		{
			var onstarttop=-300*Math.random();
			onstarttop=parseInt(onstarttop);
			current_top=onstarttop;
			var divstar=8-7*Math.random();
			divstar=parseInt(divstar);
			if(divstar==0)
			{
				divstar=1;	
			}else if(divstar>6)
			{
				divstar=6;
			}
			this.Obj.innerHTML="<div class='star"+ divstar +"'>*</div>";
		}
		this.Obj.style.pixelTop=current_top;
		this.Obj.style.pixelLeft=current_left;
	}
	setTimeout(fnname,30);
}
function InitStart()
{
	for (var i=1;i<=40;i++)
	{
		var  nameDiv="divstar"+ i;
		var ObjDiv=new ObjStar(nameDiv,0,0,0,0);
		ObjDiv.fnOnStart();
		ObjDiv.fnRepeat();
	}
}
InitStart();