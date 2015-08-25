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

using common.list;
using framework.list.dynamicviewhelper;
public partial class block_AdvanceSearchDetail : System.Web.UI.UserControl
{
    public string blSearchPro="";
    public string strpage1 = "";
    public string strpage2 = "";
    public string strProMain = "";
    public string text = "";
    public string tprice = "";
    public string torder = "";
    public string tmonth = "";
    public string twarranty = "";
    public string tCurrentAccess = "";
    public string thome = "";
    public string tpro = "";
    public string tcompare = "";
    public string unitPrice = "";
    public string tfirstp = "";
    public string tlastp = "";
    public string tdisplay = "";
    public string tspage = "";
    public string tsearch = "";
    public string tupdate = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            unitPrice = Application["currencymobile"].ToString();
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            blSearchPro = hash["blpro"].ToString();
            tprice = hash["tprice"].ToString();
            twarranty = hash["twarranty"].ToString();
            tmonth = hash["tmonth"].ToString();
            torder = hash["torder"].ToString();
            tCurrentAccess = hash["currentpage"].ToString();
            tcompare = hash["bcompare"].ToString();
            tpro = hash["promobi"].ToString();
            tfirstp = hash["firstp"].ToString();
            tlastp = hash["lastp"].ToString();
            tdisplay = hash["display"].ToString();
            tspage = hash["spage"].ToString();
            thome = hash["home"].ToString();
            tsearch = hash["tsearch"].ToString();
            tupdate = hash["tupdate"].ToString();
            tCurrentAccess += ": <a href='?menu=home'>" + thome + "</a> &raquo; <a href='?menu=product'>" + tpro + "</a> &raquo; <a href='#'>" + tsearch + "</a>";
        }
        catch
        {
        }
        ViewPage();
    }
    public void ViewPage()
    {
        try
        {
            int page = 1;
            int size = 30;
            CDynamicViewProduct Products = new CDynamicViewProduct();
            if (Request.QueryString["advance"] != null)
            {
                if (Session["ssadvancesearchMobile"] == null)
                {
                    Response.Redirect("Default.aspx?menu=asp");
                }
                try
                {
                    if (Request.QueryString["page"] != null)
                    {
                        page = int.Parse(Request.QueryString["page"].ToString());
                        if (page < 1)
                        {
                            page = 1;
                        }
                    }
                    if (Request.QueryString["size"] != null)
                    {
                        size = int.Parse(Request.QueryString["size"].ToString());
                        if (size > 40 || size < 10)
                        {
                            size = 30;
                        }
                    }
                }
                catch
                {

                }
                Products = (CDynamicViewProduct)Session["ssadvancesearchMobile"];
                Products.SetPageSize(size);
                Products.SetCurrentPage(page);
            }
            else
            {
                string where = "";
                string brand = "";
                float price1 = 0;
                float price2 = 0;
                string cpu = "";
                string hdd = "";
                string ram = "";
                string screen = "";
                string color = "";
                string txtsearch = "";
                string urlPage = Request.RawUrl;
                if (Request.QueryString["brand"] != null)
                {
                    brand = Request.QueryString["brand"].ToString();
                    if (brand.Length > 0)
                    {
                        where += " and idbrand=" + brand;
                    }
                }
                if (Request.QueryString["price1"] != null)
                {
                    try
                    {
                        price1 = float.Parse(Request.QueryString["price1"].ToString());
                        if (Application["currencymobile"].Equals("VND"))
                        {
                            price1 = price1 * 1000000;
                            price1 = price1 / (float)Application["ratepromobi"];
                        }
                    }
                    catch
                    {

                    }
                    if (price1 > 0)
                    {
                        where += " and SellingPrice>=" + price1;
                    }
                }
                if (Request.QueryString["price2"] != null)
                {
                    try
                    {
                        price2 = float.Parse(Request.QueryString["price2"].ToString());
                        if (Application["currencymobile"].Equals("VND"))
                        {
                            price2 = price2 * 1000000;
                            price2 = price2 / (float)Application["ratepromobi"];
                        }
                    }
                    catch
                    { }
                    if (price2 > 0)
                    {
                        where += " and SellingPrice<=" + price2;
                    }
                }
                if (Request.QueryString["cpu"] != null)
                {
                    cpu = Request.QueryString["cpu"].ToString();
                    string[] arrvalue = cpu.Split(',');
                    int num = arrvalue.Length;
                    if (num > 7)
                    {
                        num = 7;
                    }
                    string sub = "";
                    for (int i = 0; i < num - 1; i++)
                    {
                        if (arrvalue[i].Length > 0)
                        {
                            sub += "note like '%" + arrvalue[i] + " ghz%' or ";
                        }
                    }
                    if (arrvalue[num - 1].Length > 0)
                    {
                        sub += "note like '%" + arrvalue[num - 1] + " ghz%'";
                    }
                    if (sub.Length > 0)
                    {
                        where += " and (" + sub + ")";
                    }
                }
                if (Request.QueryString["hdd"] != null)
                {
                    hdd = Request.QueryString["hdd"].ToString();
                    string[] arrvalue = hdd.Split(',');
                    int num = arrvalue.Length;
                    if (num > 7)
                    {
                        num = 7;
                    }
                    string sub = "";
                    for (int i = 0; i < num - 1; i++)
                    {
                        if (arrvalue[i].Length > 0)
                        {
                            sub += "note like '%" + arrvalue[i] + " gb%' or ";
                        }
                    }
                    if (arrvalue[num - 1].Length > 0)
                    {
                        sub += "note like '%" + arrvalue[num - 1] + " gb%'";
                    }
                    if (sub.Length > 0)
                    {
                        where += " and (" + sub + ")";
                    }
                }
                if (Request.QueryString["ram"] != null)
                {
                    ram = Request.QueryString["ram"].ToString();
                    string[] arrvalue = ram.Split(',');
                    int num = arrvalue.Length;
                    if (num > 7)
                    {
                        num = 7;
                    }
                    string sub = "";
                    for (int i = 0; i < num - 1; i++)
                    {
                        if (arrvalue[i].Length > 0)
                        {
                            sub += "note like '%, " + arrvalue[i] + " mb%' or ";
                        }
                    }
                    if (arrvalue[num - 1].Length > 0)
                    {
                        sub += "note like '%, " + arrvalue[num - 1] + " mb%'";
                    }
                    if (sub.Length > 0)
                    {
                        where += " and (" + sub + ")";
                    }
                }
                if (Request.QueryString["screen"] != null)
                {
                    screen = Request.QueryString["screen"].ToString();
                    string[] arrvalue = screen.Split(',');
                    int num = arrvalue.Length;
                    if (num > 7)
                    {
                        num = 7;
                    }
                    string sub = "";
                    for (int i = 0; i < num - 1; i++)
                    {
                        if (arrvalue[i].Length > 0)
                        {
                            sub += "note like '%" + arrvalue[i] + "\"%' or ";
                        }
                    }
                    if (arrvalue[num - 1].Length > 0)
                    {
                        sub += "note like '%" + arrvalue[num - 1] + "\"%'";
                    }
                    if (sub.Length > 0)
                    {
                        where += " and (" + sub + ")";
                    }
                }
                if (Request.QueryString["color"] != null)
                {
                    color = Request.QueryString["color"].ToString();
                    string[] arrvalue = color.Split(',');
                    int num = arrvalue.Length;
                    if (num > 7)
                    {
                        num = 7;
                    }
                    string sub = "";
                    for (int i = 0; i < num - 1; i++)
                    {
                        if (arrvalue[i].Length > 0)
                        {
                            sub += "note like N'%" + arrvalue[i] + "%' or ";
                        }
                    }
                    if (arrvalue[num - 1].Length > 0)
                    {
                        sub += "note like N'%" + arrvalue[num - 1] + "%'";
                    }
                    if (sub.Length > 0)
                    {
                        where += " and (" + sub + ")";
                    }
                }
                if (Request.QueryString["text"] != null)
                {
                    txtsearch = Request.QueryString["text"].ToString();
                    txtsearch = txtsearch.Replace("\"", "");
                    txtsearch = txtsearch.Replace("'", "");
                    if (txtsearch.Length > 0)
                    {
                        if (brand.Length > 0)
                        {
                            where += " and (Name like N'%" + txtsearch + "%' or note like N'%" + txtsearch + "%')";
                        }
                        else
                        {
                            where += " and (Name like N'%" + txtsearch + "%' or brand like N'%" + txtsearch + "%' or note like N'%" + txtsearch + "%')";
                        }
                    }
                }
                //strProMain = where;
                Products.SetPageSize(size);
                Products.SetIdType((int)Application["idtypemobile"]);
                Products.SetAdvance(where);
                Products.SetWhere();
                Products.SetNumAdvanceSearch();
                Products.SetCurrentPage();
                Session["ssadvancesearchMobile"] = Products;
            }
            blSearchPro = string.Format(blSearchPro, "<u>" + Products.GetNumberRecord() + "</u>");
            Product_data product = Products.ProductAdvanceSearchFromTo();
            DataTable table = product.Tables[Product_data._table];
            int numPro = table.Rows.Count;
            Boolean iseven = true;
            if (Products.GetPages() > 1)
            {
                strpage1 = CreatePage(Products.GetCurrentPage(), Products.GetPages(), Products.GetPageSize(), 1);
                strpage2 = CreatePage(Products.GetCurrentPage(), Products.GetPages(), Products.GetPageSize(), 2);
            }
            else if (Products.GetPages() == 1)
            {
                strpage1 = ButtonCompare(true);
                strpage2 = ButtonCompare(false);
            }
            strProMain = "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
            strProMain += "<tr height='5'><td colspan='3'></td></tr>";
            string id = "";
            string name = "";
            string url = "";
            string price = "";
            string warranty = "";
            Boolean istest = false;
            ArrayList list = new ArrayList();
            float rate = (float)Application["ratepromobi"];
            float price11 = 1;
            string substring = "";
            string madein = "";
            string isspec = "";
            if (Products.GetCurrentPage() == 1)
            {
                istest = true;
            }
            for (int i = 0; i < numPro; i++)
            {
                id = table.Rows[i][Product_data._id].ToString();
                name = table.Rows[i][Product_data._name].ToString() + " " + table.Rows[i][Product_data._state].ToString();
                url = table.Rows[i][Product_data._urlImage].ToString();
                if (url.Length > 0)
                {
                    url = "image/img_pro/" + url;
                }
                else
                {
                    url = "image/common/notimgpro.png";
                }
                //price = table.Rows[i][Product_data._price].ToString();
                price11 = float.Parse(table.Rows[i][Product_data._price].ToString());
                price11 = price11 * rate;
                price = price11.ToString("N").Split('.')[0];
                warranty = table.Rows[i][Product_data._WarrantyMonth].ToString();
                madein = table.Rows[i][Product_data._shortnote].ToString();
                isspec = table.Rows[i][Product_data._ispec].ToString();
                if (istest == true && price.Equals("0"))
                {
                    substring = "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
                    substring += "<tr><td rowspan='2' width='95' align='center'>";
                    substring += "<a href='?menu=dp&id=" + id + "'><img class='img2' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)' src='" + url + "'/></a></td>";
                    substring += "<td colspan='2' class='txt2'><a href='?menu=dp&id=" + id + "' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)'>" + name + "</a></td></tr>";
                    substring += "<tr valign='top'><td width='159'>" + tprice + ": <span class='txt4'>";
                    substring += tupdate + "</span><br />";
                    substring += twarranty + ": <span class='txt4'>" + warranty + " " + tmonth + "</span><br />";
                    if (table.Rows[i][Product_data._ispromotion].ToString().Length > 0)
                    {
                        substring += "<img src='image/common/khuyenmai.gif' style='cursor:pointer;' onmouseover='showDivMessage(2," + id + "," + i + ",event);' onmouseout='OnMOut(event)'/><br />";
                    }
                    substring += "</td><td width='25'><input type='checkbox' id='c" + id + "' name='cp'/></td></tr>";
                    //strProMain += "<tr><td colspan='3' align='center' height='32'><div class='button3' onclick='AddCart(" + id + ",1);'>" + torder + "</div></td></tr>";
                    substring += "</table>";
                    list.Add(substring);
                    continue;
                }
                if (iseven)
                {
                    if (isspec.Equals("1"))
                    {
                        strProMain += "<tr><td width='279' class='bgcl8'>";
                    }
                    else
                    {
                        strProMain += "<tr><td width='279'>";
                    }
                    strProMain += "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
                    strProMain += "<tr><td rowspan='2' width='95' align='center'>";
                    strProMain += "<a href='?menu=dp&id=" + id + "'><img class='img2' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)' src='" + url + "'/></a></td>";
                    strProMain += "<td class='txt2' colspan='2'><a href='?menu=dp&id=" + id + "' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)'>" + name + "</a></td></tr>";
                    strProMain += "<tr valign='top'><td width='159'>" + tprice + ": <span class='txt4'>";
                    if (price.Equals("0"))
                    {
                        strProMain += tupdate + "</span><br />";
                    }
                    else
                    {
                        strProMain += price + " " + unitPrice + "</span><br />";
                    }
                    strProMain += twarranty + ": <span class='txt4'>" + warranty + " " + tmonth + "</span><br />";
                    if (table.Rows[i][Product_data._ispromotion].ToString().Length > 0)
                    {
                        strProMain += "<img src='image/common/khuyenmai.gif' style='cursor:pointer;' onmouseover='showDivMessage(2," + id + "," + i + ",event);' onmouseout='OnMOut(event)'/><br />";
                    }
                    strProMain += "</td><td width='25'><input type='checkbox' id='c" + id + "' name='cp'/></td></tr>";
                    //strProMain += "<tr><td colspan='3' align='center' height='32'><div class='button3' onclick='AddCart(" + id + ",1);'>" + torder + "</div></td></tr>";
                    strProMain += "</table></td>";
                    strProMain += "<td class='line2'></td>";
                    iseven = false;
                    if (i + 1 == numPro)
                    {
                        if (list.Count == 0)
                        {
                            strProMain += "<td width='279'>&nbsp;</td>";
                            strProMain += "</tr>";
                        }
                    }
                }
                else
                {
                    if (isspec.Equals("1"))
                    {
                        strProMain += "<td width='279' class='bgcl8'>";
                    }
                    else
                    {
                        strProMain += "<td width='279'>";
                    }
                    strProMain += "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
                    strProMain += "<tr><td rowspan='2' width='95' align='center'>";
                    strProMain += "<a href='?menu=dp&id=" + id + "'><img class='img2' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)' src='" + url + "'/></a></td>";
                    strProMain += "<td class='txt2' colspan='2'><a href='?menu=dp&id=" + id + "' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)'>" + name + "</a></td></tr>";
                    strProMain += "<tr valign='top'><td width='159'>" + tprice + ": <span class='txt4'>";
                    if (price.Equals("0"))
                    {
                        strProMain += tupdate + "</span><br />";
                    }
                    else
                    {
                        strProMain += price + " " + unitPrice + "</span><br />";
                    }
                    strProMain += twarranty + ": <span class='txt4'>" + warranty + " " + tmonth + "</span><br />";
                    if (table.Rows[i][Product_data._ispromotion].ToString().Length > 0)
                    {
                        strProMain += "<img src='image/common/khuyenmai.gif' style='cursor:pointer;' onmouseover='showDivMessage(2," + id + "," + i + ",event);' onmouseout='OnMOut(event)'/><br />";
                    }
                    strProMain += "</td><td width='25'><input type='checkbox' id='c" + id + "' name='cp'/></td></tr>";
                    //strProMain += "<tr><td colspan='3' align='center' height='32'><div class='button3' onclick='AddCart(" + id + ",1);'>" + torder + "</div></td></tr>";
                    strProMain += "</table></td></tr>";
                    if (i + 1 < numPro)
                    {
                        strProMain += "<tr><td class='line1'></td><td></td><td class='line1'></td></tr>";
                    }
                    iseven = true;
                }
            }
            int numpro = list.Count;
            for (int i = 0; i < numpro; i++)
            {
                if (iseven)
                {
                    strProMain += "<tr><td width='279'>";
                    strProMain += list[i].ToString();
                    strProMain += "</td><td class='line2'></td>";
                    iseven = false;
                    if (i + 1 == numpro)
                    {
                        strProMain += "<td width='279'>&nbsp;</td>";
                        strProMain += "</tr>";
                    }
                }
                else
                {
                    strProMain += "<td width='279'>";
                    strProMain += list[i].ToString();
                    strProMain += "</td></tr>";
                    if (i + 1 < numPro)
                    {
                        strProMain += "<tr><td class='line1'></td><td></td><td class='line1'></td></tr>";
                    }
                    iseven = true;
                }
            }
            strProMain += "<tr height='5'><td colspan='3'></td></tr>";
            strProMain += "</table>";
        }
        catch
        { 
            
        }
    }
    public string CreatePage(int current, int pages, int pagesize, int index)
    {
        string str = "";
        string strSelect = "";
        if (pagesize == 20)
        {
            strSelect = "<select class='sl2' id='s" + index + "' onchange='PageS(this," + current.ToString() + ",3);'><option value='20'>20</option><option value='30'>30</option><option value='40'>40</option></select>";
        }
        else if (pagesize == 30)
        {
            strSelect = "<select class='sl2' id='s" + index + "' onchange='PageS(this," + current.ToString() + ",3);'><option value='20'>20</option><option value='30' selected='selected'>30</option><option value='40'>40</option></select>";
        }
        else
        {
            strSelect = "<select class='sl2' id='s" + index + "' onchange='PageS(this," + current.ToString() + ",3);'><option value='20'>20</option><option value='30'>30</option><option value='40' selected='selected'>40</option></select>";
        }
        str = "<table border='0' cellpadding='0' cellspacing='0' width='100%' class='bgcl6'>";
        str += "<tr><td width='200'>" + tdisplay + " " + strSelect;
        str += " " + "<input type='text' id='t" + index + "' onkeydown=\"OnEnterSend(event,'u" + index + "');\" value='' class='tb3' /> <a id='u" + index + "' href='#' onclick='GoGageS(" + index + ",3);'>" + tspage + "</a></td>";
        str += "<td align='center'>";
        string strlinkPage = "";
        if (current == 1)
        {
            strlinkPage += "<input type='button' class='arrow2' onclick=\"OnCPage('dasp&advance=1'," + pages + "," + pagesize + ")\" />";
            strlinkPage += " <span class='txt3'>" + current + "/" + pages + "</span> ";
            strlinkPage += "<input type='button' class='arrow1' onclick=\"OnCPage('dasp&advance=1',2," + pagesize + ")\" />";
        }
        else if (current == pages)
        {
            strlinkPage += "<input type='button' class='arrow2' onclick=\"OnCPage('dasp&advance=1'," + (current - 1) + "," + pagesize + ")\" />";
            strlinkPage += " <span class='txt3'>" + current + "/" + pages + "</span> ";
            strlinkPage += "<input type='button' class='arrow1' onclick=\"OnCPage('dasp&advance=1',1," + pagesize + ");\" />";
        }
        else
        {
            strlinkPage += "<input type='button' class='arrow2' onclick=\"OnCPage('dasp&advance=1'," + (current - 1) + "," + pagesize + ")\" />";
            strlinkPage += " <span class='txt3'>" + current + "/" + pages + "</span> ";
            strlinkPage += "<input type='button' class='arrow1' onclick=\"OnCPage('dasp&advance=1'," + (current + 1) + "," + pagesize + ")\" />";
        }
        str += strlinkPage;
        str += "</td><td width='200' align='right'>";
        if (index == 1)
        {
            str += "<div class='arrow3' onclick='comp();'>" + tcompare + "</div>";
        }
        if (index == 2)
        {
            str += "<div class='arrow4' onclick='comp();'>" + tcompare + "</div>";
        }
        str += "</td></tr></table>";
        return str;
    }
    public string ButtonCompare(Boolean istop)
    {
        string str = "";
        str = "<div style='padding-right:289px;text-align:right;'>";
        if (istop)
        {
            str += "<div class='arrow3' onclick='comp();'>" + tcompare + "</div>";
        }
        else
        {
            str += "<div class='arrow4' onclick='comp();'>" + tcompare + "</div>";
        }
        str += "</div>";
        return str;
    }
}
