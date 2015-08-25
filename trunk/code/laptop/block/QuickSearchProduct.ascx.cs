using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using framework.list.dynamicviewhelper;
using framework.list.common;
using common.list;
public partial class block_QuickSearchProduct : System.Web.UI.UserControl
{
    public string text = "";
    public string blpro = "";
    public string strProduct = "";
    public string strpage1 = "";
    public string strpage2 = "";
    public string tprice = "";
    public string torder = "";
    public string tmonth = "";
    public string twarranty = "";
    public string tdisplay = "";
    public string tspage = "";
    public string tlastp = "";
    public string tfirstp = "";
    public string tCurrentAccess = "";
    public string thome = "";
    public string tpro = "";
    public string tcompare = "";
    public string unitPrice = "";
    public string tnotpro = "";
    public string tsearch = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            unitPrice = Application["currency"].ToString();
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            blpro = hash["blpro"].ToString();
            tprice = hash["tprice"].ToString();
            twarranty = hash["twarranty"].ToString();
            tmonth = hash["tmonth"].ToString();
            torder = hash["torder"].ToString();
            tCurrentAccess = hash["currentpage"].ToString();
            tcompare = hash["bcompare"].ToString();
            tpro = hash["product"].ToString();
            tfirstp = hash["firstp"].ToString();
            tlastp = hash["lastp"].ToString();
            tdisplay = hash["display"].ToString();
            tspage = hash["spage"].ToString();
            thome = hash["home"].ToString();
            tnotpro = hash["mnothave"].ToString();
            tsearch = hash["tsearch"].ToString();
            tCurrentAccess += ": <a href='?menu=home'>" + thome + "</a> &raquo; <a href='?menu=product'>" + tpro + "</a> &raquo; " + tsearch + ": " + text;
            strProduct = ShowProductSearch();
        }
        catch
        {
        }
    }
    public string ShowProductSearch()
    {
        CDynamicViewProduct ViewSearch;
        int currentpage = 0;
        int size = 20;
        try
        {
            currentpage = int.Parse(Request.QueryString["page"].ToString());
            size = int.Parse(Request.QueryString["size"].ToString());
            if (size > 40 || size < 10)
            {
                size = 20;
            }
        }
        catch
        {
        }
        try
        {
            text = Request.QueryString["text"].ToString();
            text = text.Replace('"', ' ');
            text = text.Trim();
            if (text.Length > 0)
            {
                if (text.Length > 30)
                {
                    text = text.Substring(0, 30);
                }
            }
        }
        catch
        {
            Response.Redirect("?menu=product");
        }
        if (Session["SSQSProduct"] == null)
        {
            ViewSearch = new CDynamicViewProduct();
            ViewSearch.SetTextSearch(text);
            ViewSearch.SetIdType((int)Application["idtypeproduct"]);
            ViewSearch.BuildWhere();
            ViewSearch.SetNumQuickSearch();
            ViewSearch.SetPageSize(size);
            if (currentpage > 0)
            {
                ViewSearch.SetCurrentPage(currentpage);
            }
            else
            {
                ViewSearch.SetCurrentPage();
            }
            Session["SSQSProduct"] = ViewSearch;
        }
        else
        {
            ViewSearch = (CDynamicViewProduct)Session["SSQSProduct"];
            ViewSearch.SetPageSize(size);
            if(!text.Equals(ViewSearch.GetTextSearch()))
            {
                ViewSearch.SetTextSearch(text);
                ViewSearch.BuildWhere();
                ViewSearch.SetNumQuickSearch();
            }
            if (currentpage > 0)
            {
                ViewSearch.SetCurrentPage(currentpage);
            }
            else
            {
                ViewSearch.SetCurrentPage();
            }
        }
        blpro = string.Format(blpro, ViewSearch.GetNumberRecord());
        Product_data product = ViewSearch.ProductQuickSearchFromTo();
        DataTable table = product.Tables[Product_data._table];
        int numPro = table.Rows.Count;
        Boolean iseven = true;
        if (ViewSearch.GetPages() > 1)
        {
            strpage1 = CreatePage(ViewSearch.GetCurrentPage(), ViewSearch.GetPages(), ViewSearch.GetPageSize(), 1);
            strpage2 = CreatePage(ViewSearch.GetCurrentPage(), ViewSearch.GetPages(), ViewSearch.GetPageSize(), 2);
        }
        else if (ViewSearch.GetPages() == 1)
        {
            strpage1 = ButtonCompare(true);
            strpage2 = ButtonCompare(false);
        }
        string strProMain = "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
        strProMain += "<tr height='5'><td colspan='3'></td></tr>";
        string id = "";
        string name = "";
        string url = "";
        string price = "";
        string warranty = "";
        for (int i = 0; i < numPro; i++)
        {
            id = table.Rows[i][Product_data._id].ToString();
            name = table.Rows[i][Product_data._name].ToString();
            url = table.Rows[i][Product_data._urlImage].ToString();
            if (url.Length > 0)
            {
                url = "image/img_pro/" + url;
            }
            else
            {
                url = "image/common/notimgpro.png";
            }
            price = table.Rows[i][Product_data._price].ToString();
            warranty = table.Rows[i][Product_data._WarrantyMonth].ToString();
            if (iseven)
            {
                strProMain += "<tr><td width='272'>";
                strProMain += "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
                strProMain += "<tr><td rowspan='2' width='100' height='90' align='center'>";
                if (table.Rows[i][Product_data._ispromotion].ToString().Length > 0)
                {
                    strProMain += "<img src='image/common/khuyenmai.gif' style='cursor:pointer;' onmouseover='showDivMessage(2," + id + "," + i + ",event);' onmouseout='OnMOut(event)'/><br />";
                }
                strProMain += "<a href='?menu=dp&id=" + id + "'><img class='border_img' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)' src='" + url + "'/></a></td>";
                strProMain += "<td colspan='2' valign='top' class='text_title'><a href='?menu=dp&id=" + id + "' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)'>" + name + "</a></td></tr>";
                strProMain += "<tr><td>" + tprice + ": <span class='price'>" + price + " " + unitPrice + "</span><br />" + twarranty + ": <span class='price'>" + warranty + " " + tmonth + "</span>";
                strProMain += "</td><td><input type='checkbox' id='c" + id + "' name='cp'/></td></tr>";
                strProMain += "<tr><td colspan='3' height='32' align='center'><div class='button3' onclick='AddCart(" + id + ",1);'>" + torder + "</div></td></tr>";
                strProMain += "</table></td>";
                iseven = false;
                if (i + 1 == numPro)
                {
                    strProMain += "<td class='bg_line4' width='11'></td>";
                    strProMain += "<td width='272'>&nbsp;</td>";
                    strProMain += "</tr>";
                }
            }
            else
            {
                strProMain += "<td class='bg_line4' width='11'></td>";
                strProMain += "<td width='272'>";
                strProMain += "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
                strProMain += "<tr><td rowspan='2' width='100' height='90' align='center'>";
                if (table.Rows[i][Product_data._ispromotion].ToString().Length > 0)
                {
                    strProMain += "<img src='image/common/khuyenmai.gif' style='cursor:pointer;' onmouseover='showDivMessage(2," + id + "," + i + ",event);' onmouseout='OnMOut(event)'/><br />";
                }
                strProMain += "<a href='?menu=dp&id=" + id + "'><img class='border_img' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)' src='" + url + "'/></a></td>";
                strProMain += "<td colspan='2' valign='top' class='text_title'><a href='?menu=dp&id=" + id + "' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)'>" + name + "</a></td></tr>";
                strProMain += "<tr><td>" + tprice + ": <span class='price'>" + price + " " + unitPrice + "</span><br />" + twarranty + ": <span class='price'>" + warranty + " " + tmonth + "</span>";
                strProMain += "</td><td><input type='checkbox' id='c" + id + "' name='cp'/></td></tr>";
                strProMain += "<tr><td colspan='3' height='32' align='center'><div class='button3' onclick='AddCart(" + id + ",1);'>" + torder + "</div></td></tr>";
                strProMain += "</table></td></tr>";
                if (i + 1 < numPro)
                {
                    strProMain += "<tr><td class='bg_line3'></td><td></td><td class='bg_line3'></td></tr>";
                }
                iseven = true;
            }
        }
        if (numPro == 0)
        {
            strProMain += "<tr><td colspan='3' align='center'>" + tnotpro + "</td></tr>";
        }
        strProMain += "<tr height='5'><td colspan='3'></td></tr>";
        strProMain += "</table>";
        return strProMain;
    }
    public string CreatePage(int current, int pages, int pagesize, int index)
    {
        string str = "";
        string strSelect = "";
        if (pagesize == 20)
        {
            strSelect = "<select class='select_num' id='s" + index + "' onchange='PageS(this," + current.ToString() + ",1);'><option value='20'>20</option><option value='30'>30</option><option value='40'>40</option></select>";
        }
        else if (pagesize == 30)
        {
            strSelect = "<select class='select_num' id='s" + index + "' onchange='PageS(this," + current.ToString() + ",1);'><option value='20'>20</option><option value='30' selected='selected'>30</option><option value='40'>40</option></select>";
        }
        else
        {
            strSelect = "<select class='select_num' id='s" + index + "' onchange='PageS(this," + current.ToString() + ",1);'><option value='20'>20</option><option value='30'>30</option><option value='40' selected='selected'>40</option></select>";
        }
        str = "<table border='0' cellpadding='0' cellspacing='0' width='100%' class='bg_page'>";
        str += "<tr><td width='45'>" + tdisplay + "</td><td width='40'>" + strSelect + "</td>";
        str += "<td width='100' align='right'><input type='text' id='t" + index + "' onkeydown=\"OnEnterSend(event,'u" + index + "');\" value='' class='tb_go' /><u class='u1' id='u" + index + "' onclick='GoGageS(" + index + ",1);'>" + tspage + "</u></td>";
        str += "<td align='right'>";
        if (index == 2)
        {
            str += "<div class='dcomparet' onclick='comp();'>" + tcompare + "</div>";
        }
        string strlinkPage = "";
        int num = 0;
        int currentIndex = current - 1;
        if (current > 1)
        {
            num = current - 1;
            strlinkPage += "<a href='?menu=qsp&text=" + text +"&page=1&size=" + pagesize.ToString() + "' class='page_previous'>" + tfirstp + "</a>";
        }
        int numLeft = 0;
        strlinkPage += "<span class='text_page'>";
        string subleft = "";
        while ((currentIndex >= 1) && ((current - currentIndex) < 3))
        {
            subleft = "<a href='?menu=qsp&text=" + text + "&page=" + currentIndex.ToString() + "&size=" + pagesize.ToString() + "'>" + currentIndex.ToString() + "</a>" + subleft;
            numLeft++;
            currentIndex--;
        }
        strlinkPage += subleft;
        strlinkPage += "<u>" + current.ToString() + "</u>";
        currentIndex = current + 1;
        while ((currentIndex <= pages) && ((currentIndex - current) < 6 - numLeft))
        {
            strlinkPage += "<a href='?menu=qsp&text=" + text + "&page=" + currentIndex.ToString() + "&size=" + pagesize.ToString() + "'>" + currentIndex.ToString() + "</a>";
            currentIndex++;
        }
        strlinkPage += "</span>";
        if (current < pages)
        {
            num = current + 1;
            strlinkPage += "<a href='?menu=qsp&text=" + text + "&page=" + pages.ToString() + "&size=" + pagesize.ToString() + "' class='page_next'>" + tlastp + "</a>";
        }
        str += strlinkPage;
        if (index == 1)
        {
            str += "<div class='dcompared' onclick='comp();'>" + tcompare + "</div>";
        }
        str += "</td></tr></table>";
        return str;
    }
    public string ButtonCompare(Boolean istop)
    {
        string str = "";
        str = "<table border='0' cellpadding='0' cellspacing='0' width='100%' class='bg_page'>";
        if (istop)
        {
            str += "<tr><td align='right' width='255'><div class='dcompared' onclick='comp();'>" + tcompare + "</div></td><td>&nbsp;</td></tr></table>";
        }
        else
        {
            str += "<tr><td align='right' width='255'><div class='dcomparet' onclick='comp();'>" + tcompare + "</div></td><td>&nbsp;</td></tr></table>";
        }
        return str;
    }
}