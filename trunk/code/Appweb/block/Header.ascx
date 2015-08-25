<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="block_Header" %>
<table width="100%" border="0"><tr><td> Xin chào: <span class='txt2'><%=nameUser %></span> (<a href='LoginWebsite.aspx'>Logout</a>) , <span class='td1' id="divNewMessage" onclick="GotoSeeMessage();" title="Click để xem...">Không có tin nhắn mới</span>, Time <span class='txt2'><%=strtime %></span> , địa chỉ IP: <span class='txt2'><%=strIP %></span>
</td></tr></table>
<script language="javascript" type="text/javascript">
var IsRequest=true;
function TestRequest()
{
    var obj=document.getElementById("divNewMessage");
    if(obj!=null)
    {
        if(obj.innerHTML=="Không có tin nhắn mới")
        {
            IsRequest=true;
            ReMessage();
        }else
        {
            IsRequest=false;
        }
        if(IsRequest)
        {
            setTimeout("TestRequest()",30000);
        }
    }
}
setTimeout("TestRequest()",5000);
function GotoSeeMessage()
{
    location.href="Default.aspx?key=ManageSystemMessage";
}
</script>