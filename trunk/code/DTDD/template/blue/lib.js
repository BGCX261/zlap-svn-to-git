// Create by SungLE:

/**/
function OnChang1(id,len)
{
	var str="";
	for(var i=1;i<=len;i++)
	{
		if(i==id)
		{
			str+=" <a>" + i +"</a> ";
		}else
		{
			str+="<a href='#' onclick=\"OnChang1("+ i + "," + len + ");\">"+ i +"</a>";
		}
	}
	document.getElementById("spanbestsale").innerHTML=str;
}