//Time choice:
function ControlTime(ObjShow,CurrentTime,Nametb)
{
	var DivShow=document.getElementById(ObjShow);
	var cDate=new Date(CurrentTime);
	var cYear=cDate.getFullYear();
	var cMonth=cDate.getMonth();
	var cDay=cDate.getDate();
	var cHour=cDate.getHours();
	var cMinute=cDate.getMinutes();
	this.getTableTime=function(txtTime)
	{
		if(txtTime.length>0)
		{
			cDate=new Date(txtTime);
			cYear=cDate.getFullYear();
			cMonth=cDate.getMonth();
			cDay=cDate.getDate();
			cHour=cDate.getHours();
			cMinute=cDate.getMinutes();
		}
		return getTableDay(ObjShow,Nametb,cDay,cMonth,cYear,cHour,cMinute);
	}
	this.ShowTime=function(txtTime)
	{
		if(DivShow!=null)
		{
			if(DivShow.style.display=="none")
			{
				DivShow.style.display="";
				DivShow.innerHTML=this.getTableTime(txtTime);
			}else
			{
				DivShow.innerHTML="";
				DivShow.style.display="none";
			}
			
		}
	}
}
function getTableDay(ObjShow,Nametb,cDay,cMonth,cYear,cHour,cMinute)
{
	var str="<table border='0' cellpadding='0' cellspacing='0' width='231' class='lichtitle'>";
	str+="<tr height='25'><td>Lịch tháng "+ getSlMonth(cMonth,ObjShow,Nametb,cDay,cYear,cHour,cMinute);
	str+=" Năm "+ getSlYear(cYear,ObjShow,Nametb,cDay,cMonth,cHour,cMinute) +"</td><td class='lichClose' onclick=\"ChangeState('"+ ObjShow +"',0);\">&nbsp;</td></tr>";
	str+="<tr><td colspan='2'>";
	str+="<table border='0' cellpadding='0' cellspacing='0' width='231'>";
	var count=0;
	str+="<tr class='lichtrtday'><td class='licktd1' width='33'>CN</td><td>T2</td><td>T3</td><td>T4</td><td>T5</td><td>T6</td><td>T7</td></tr>";
	var numdays=getDays(cMonth, cYear);
	var cDate=new Date(cYear,cMonth,1);
	var dayofweek=cDate.getDay();
	var preMonth=cMonth-1;
	if(preMonth<0)
	{
		preMonth=11;
	}	
	var prenumdays=getDays(preMonth,cYear);
	prenumdays=prenumdays-dayofweek;
	if(dayofweek>0)
	{
		str+="<tr class='lichtrday'>";
		for(var i=0;i<dayofweek;i++)
		{
			str+="<td class='licktd2'>"+ (prenumdays + i + 1) +"</td>";
			count++;
		}
	}
	var strmonth=parseInt(cMonth) + 1;
	if(strmonth<10)
	{
		strmonth='0'+ strmonth;
	}
	for(var i=1;i<=numdays;i++)
	{
		if(count==0)
		{
			str+="<tr class='lichtrday'>";
		}
		var strday=i;
		if(i<10)
		{
			strday='0'+ i;
		}
		var strday=strmonth + "/" + strday + "/"+ cYear;
		var func="onclick=\"gettime('"+ strday +"','" + ObjShow + "', '"+ Nametb +"');\"";
		if(i==cDay)
		{
			str+="<td class='lichtoday' "+ func +">" + i + "</td>";
		}
		else
		{
			if(count>0)
			{
				str+="<td "+ func +">" + i + "</td>";
			}else
			{
				str+="<td class='licktd1' "+ func +">" + i + "</td>";
			}
		}
		count++;
		if(count==7)
		{
			count=0;
			str+="</tr>";
		}else
		{
			if(i==numdays)
			{
				for(var j=7;j>count;j--)
				{
					str+="<td class='licktd2'>"+ (7-j + 1) +"</td>";
				}
				str+="</tr>";
			}
		}
	}
	str+="</table>";
	str+="</td></tr>";
	str+="<tr class='lictrbt'><td colspan='2' align='center'>Giờ <input type='textbox' id='tblichhour' class='lichgio' value='"+ cHour +"' maxlength='2'/> phút <input type='textbox' id='tblichminute' class='lichgio' value='"+ cMinute +"' maxlength='2'/> (tính 24 giờ)</td></tr>";
	str+="</table>";
	return str;
}
function getSlYear(year,ObjShow,Nametb,cDay,cMonth,cHour,cMinute)
{
	var str="";
	var minYear=2005;
	var maxYear=2020;
	str="<select class='lichslyear' onChange=\"onCslYear(this,'"+ ObjShow +"','"+ Nametb +"'," + cDay + ","+ cMonth +"," + cHour + "," + cMinute + ");\">";
	for(var i=minYear;i<=maxYear;i++)
	{
			if(i==year)
			{
				str+="<option value='" + i + "' selected='selected'>" + i + "</option>";
			}else
			{
				str+="<option value='" + i +"'>" + i + "</option>";
			}
	}
	str+="</select>";
	return str;
}
function getSlMonth(month,ObjShow,Nametb,cDay,cYear,cHour,cMinute)
{
	var str="";
	var arrMonth=new Array("1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12");
	str="<select class='lichslmonth' onChange=\"onCslMonth(this,'" + ObjShow+"','"+ Nametb +"',"+ cDay +","+ cYear + "," + cHour +"," + cMinute +");\">";
	for(var i=0;i<=11;i++)
	{
		if(i==month)
		{
			str+="<option value='" + i + "' selected='selected'>" + arrMonth[i] + "</option>";
		}else
		{
			str+="<option value='" + i +"'>" + arrMonth[i] + "</option>";
		}
	}
	str+="</select>";
	return str;
}
function ChangeState(name,state)
{
	var Obj=document.getElementById(name);
	if(Obj!=null)
	{
			if(state==0)
			{
				Obj.style.display="none";
				Obj.innerHTML="";
			}else
			{
				Obj.style.display="";
			}
	}
}
function getDays(month, year)
{	
	var daysInMonth = new Array(31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31);
	if (1 == month)
	{
		return ((0 == year % 4) && (0 != (year % 100))) || (0 == year % 400) ? 29 : 28;
	}
	else
	return daysInMonth[month];
}
function gettime(value,namediv,nametxt)
{
	var ObjTxt=document.getElementById(nametxt);
	if(ObjTxt!=null)
	{
		var hour=0;
		var minute=0;
		if(document.getElementById("tblichhour")!=null)
		{
			hour=parseInt(document.getElementById("tblichhour").value);
			if(isNaN(hour))
			{
				hour=0;
			}
			if(hour>23 || hour<0)
			{
				hour=0;
			}
		}
		if(document.getElementById("tblichminute")!=null)
		{
			minute=parseInt(document.getElementById("tblichminute").value);
			if(isNaN(minute))
			{
				minute=0;
			}
			if(minute>59 || minute<0)
			{
				minute=0;
				}
		}
		value=value + " " + hour + ":" + minute;
		ObjTxt.value=value;
	}
	ChangeState(namediv,0);
}
function onCslYear(Obj,ObjShow,Nametb,cDay,cMonth,cHour,cMinute)
{
	var DivShow=document.getElementById(ObjShow);
	if(DivShow!=null)
	{
		DivShow.innerHTML=getTableDay(ObjShow,Nametb,cDay,cMonth,Obj.value,cHour,cMinute);
	}
}
function onCslMonth(Obj,ObjShow,Nametb,cDay,cYear,cHour,cMinute)
{
	var DivShow=document.getElementById(ObjShow);
	if(DivShow!=null)
	{
		DivShow.innerHTML=getTableDay(ObjShow,Nametb,cDay,Obj.value,cYear,cHour,cMinute);
	}
}