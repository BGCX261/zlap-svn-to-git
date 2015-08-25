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