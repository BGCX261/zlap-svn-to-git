<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ManagerProSelloff.ascx.cs" Inherits="admin_block_ManagerProSelloff" %>
<table width="100%" border="0">
<tr><td width="80">Từ tìm kiếm</td><td width="124"><input type="text" value="" maxlength="20" class="txtSearch" id="txt_search"/></td><td width="140" align="right">Làm giảm giá?:</td><td width='40'><input type="checkbox" id="checkBest" /></td><td width="400"><input type="button" id="btsearchPro" value="Tìm kiếm" class="button"  onclick="searchProSellOff()"; /> <input type="button" id="Button1" class="button" value="Xem toàn bộ" onclick="location.href='?menu=proselloff';" /></td></tr>
<tr><td colspan="5">(Có thể tìm theo: mã sản phẩm, Tên hoặc nhãn hiêu)</td></tr>
<tr><td class="line" colspan="5"></td></tr>
<tr><td height="30" class="text_page" colspan="5"><%=strPage %></td></tr></table>
<%=strlist %>
<div id="divUpload" class="div_panel" style="display:none;">
<div class="tUpload" id="divTitleUpload">Nhập giá trước khi giảm của sản phẩm:</div>
<input type="text" value="" id="txtPrice" /><input type="button" value="Đồng ý" onclick="btselloff();"/>
<div class='div_message'>(Nhập giá dạng số)</div>
<div class='divclose'><input type="button" value="Đóng lại" class="button" onclick="CloseDivHere();" /></div>
</div>
<script language="javascript" type="text/javascript">
function btselloff()
{
    var Objtext=document.getElementById("txtPrice");
    if(Objtext!=null)
    {
        var inputprice=Objtext.value;
        inputprice=parseInt(inputprice);
        //alert(inputprice);
        if(isNaN(inputprice))
        {
            alert("hãy nhập giá dạng số");
        }else
        {
            commonPrice=inputprice;
            var ObjCheck=document.getElementById(idselloff);
            changeBest(ObjCheck,4);
            document.getElementById("divUpload").style.display="none";
        }
    }
}
function CloseDivHere()
{
    document.getElementById("divUpload").style.display="none";
    document.getElementById(idselloff).checked=false;
}
</script>