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
    public string strproduct = "";
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
    private string strMVAT = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            unitPrice = Application["currency"].ToString();
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            blSearchPro = hash["blpro"].ToString();
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
            tsearch = hash["tsearch"].ToString();
            tupdate = hash["tupdate"].ToString();
            strMVAT = hash["msvat"].ToString();
            tCurrentAccess += ": <a href='?menu=home'>" + thome + "</a> &raquo; <a href='?menu=product' onmouseover='OnMOMenu(0,1,11,event);' onmouseout='TimeHidden();'>" + tpro + "</a> &raquo; <a href='?menu=asp'>" + tsearch + "</a>";
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
                if (Session["ssadvancesearchpro"] == null)
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
                Products = (CDynamicViewProduct)Session["ssadvancesearchpro"];
                Products.SetPageSize(size);
                Products.SetCurrentPage(page);
            }
            else
            {
                string where = "";
                string location = "";
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
                string proState = "";
                if (Request.QueryString["address"] != null)
                {
                    location = Request.QueryString["address"].ToString();
                    if (location.Length > 0)
                    {
                        where += " and Id in (select ProductId from v_web_product_warehouse where WareHouseId in (" + location + ") Group By ProductId)";
                    }
                }
                if (Request.QueryString["state"] != null)
                {
                    proState = Request.QueryString["state"].ToString();
                    if (proState.Length > 0)
                    {
                        where += " and StateId in (" + proState + ")";
                    }
                }
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
                        if (Application["currency"].Equals("VND") || Application["currency"].Equals("$"))
                        {
                            price1 = price1 * 1000000;
                            price1 = price1 / (float)Application["ratepromain"];
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
                        if (Application["currency"].Equals("VND") || Application["currency"].Equals("$"))
                        {
                            price2 = price2 * 1000000;
                            price2 = price2 / (float)Application["ratepromain"];
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
                //strProduct = where;
                Products.SetPageSize(size);
                Products.SetIdType((int)Application["idtypeproduct"]);
                Products.SetAdvance(where);
                Products.SetWhere();
                Products.SetNumAdvanceSearch();
                Products.SetCurrentPage();
                Session["ssadvancesearchpro"] = Products;
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
            strproduct = "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
            strproduct += "<tr height='5'><td colspan='3'></td></tr>";
            string id = "";
            string name = "";
            string url = "";
            string price = "";
            string warranty = "";
            Boolean istest = false;
            ArrayList list = new ArrayList();
            float rate = (float)Application["ratepromain"];
            float price11 = 1;
            string price22 = "";
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
                string namepro = table.Rows[i][Product_data._name].ToString();
                namepro = namepro.Replace("/", "");
                namepro = namepro.Replace("#", "");
                namepro = namepro.Replace(":", "");
                namepro = namepro.Replace("\"", "");
                if (url.Length > 0)
                {
                    url = "image/img_pro/" + url;
                }
                else
                {
                    url = "image/common/notimgpro.png";
                }
                price22 = table.Rows[i][Product_data._price].ToString();
                price11 = float.Parse(table.Rows[i][Product_data._price].ToString());
                price11 = price11 * rate;
                price = price11.ToString("N").Split('.')[0];
                warranty = table.Rows[i][Product_data._WarrantyMonth].ToString();
                madein = table.Rows[i][Product_data._shortnote].ToString();
                isspec = table.Rows[i][Product_data._ispec].ToString();
                if (istest == true && price.Equals("0"))
                {
                    substring = "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
                    substring += "<tr><td rowspan='2' width='88' align='center' valign='top'>";
                    if (table.Rows[i][Product_data._ispromotion].ToString().Length > 0)
                    {
                        substring += "<img src='image/common/khuyenmai.gif' style='cursor:pointer;' onmouseover='showDivMessage(2," + id + "," + i + ",event);' onmouseout='OnMOut(event)'/><br />";
                    }
                    substring += "<a href='" + namepro + "-dp-" + id + ".html'><img class='img1' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)' src='" + url + "'/></a></td>";
                    substring += "<td colspan='2' valign='top' class='text_title'><a href='" + namepro + "-dp-" + id + ".html' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)'>" + name + "</a></td></tr>";
                    substring += "<tr><td valign='middle' width='165' height='48'>" + tprice + ": <span class='price'>";
                    substring += tupdate + "</span><br />";
                    substring += twarranty + ": <span class='price'>" + warranty + " " + tmonth + "</span>";
                    //if (madein.Length > 0)
                    //{
                    //    substring += "<br /><span class='text_title'>" + madein + "</span>";
                    //}
                    substring += "</td><td width='25' align='right'><input type='checkbox' id='c" + id + "' name='cp'/></td></tr>";

                    if (madein.Length > 0)
                    {
                        substring += "<tr><td colspan='3' class='text_title' align='center'>" + madein + "</td></tr>";
                    }
                    //strProMain += "<tr><td colspan='3' align='center' height='32'><div class='button3' onclick='AddCart(" + id + ",1);'>" + torder + "</div></td></tr>";
                    substring += "</table>";
                    list.Add(substring);
                    continue;
                }
                if (iseven)
                {
                    if (isspec.Equals("1"))
                    {
                        strproduct += "<tr><td width='278' class='cl1'>";
                    }
                    else
                    {
                        strproduct += "<tr><td width='278'>";
                    }
                    strproduct += "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
                    strproduct += "<tr><td rowspan='2' width='88' align='center' valign='top'>";
                    if (table.Rows[i][Product_data._ispromotion].ToString().Length > 0)
                    {
                        strproduct += "<img src='image/common/khuyenmai.gif' style='cursor:pointer;' onmouseover='showDivMessage(2," + id + "," + i + ",event);' onmouseout='OnMOut(event)'/><br />";
                    }
                    strproduct += "<a href='" + namepro + "-dp-" + id + ".html'><img class='img1' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)' src='" + url + "'/></a></td>";
                    strproduct += "<td colspan='2' valign='top' class='text_title'><a href='" + namepro + "-dp-" + id + ".html' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)'>" + name + "</a></td></tr>";
                    strproduct += "<tr><td valign='middle' width='165' height='48'>" + tprice + ": <span class='price'>";
                    if (price.Equals("0"))
                    {
                        strproduct += tupdate + "</span><br />";
                    }
                    else
                    {
                        if (unitPrice.Equals("$"))
                        {
                            strproduct += price + " VND</span><br />";
                            strproduct += "<font color='#FFFFFF'>" + tprice + ": </font><span class='price'>" + price22 + "</span><br />";
                        }
                        else if (unitPrice.Equals("$$"))
                        {
                            strproduct += price + " VND</span><br />";
                            strproduct += "<font color='#FFFFFF'>" + tprice + ": </font><span class='price'>" + price22 + " USD</span><br />";
                        }
                        else
                        {
                            strproduct += price + " " + unitPrice + "</span><br />";
                        }
                    }
                    strproduct += "<span class='tvat'>" + strMVAT + "</span><br />";
                    strproduct += twarranty + ": <span class='price'>" + warranty + " " + tmonth + "</span>";
                    //if (madein.Length > 0)
                    //{
                    //    strproduct += "<br /><span class='text_title'>" + madein + "</span>";
                    //}
                    strproduct += "</td><td width='25' align='right'><input type='checkbox' id='c" + id + "' name='cp'/></td></tr>";
                    //strproduct += "<tr><td colspan='3' height='32' align='center'><div class='button3' onclick='AddCart(" + id + ",1);'>" + torder + "</div></td></tr>";
                    if (madein.Length > 0)
                    {
                        strproduct += "<tr><td colspan='3' class='text_title' align='center'>" + madein + "</td></tr>";
                    }
                    
                    strproduct += "</table></td>";
                    strproduct += "<td class='bg_line4'></td>";
                    iseven = false;
                    if (i + 1 == numPro)
                    {

                        if (list.Count == 0)
                        {
                            strproduct += "<td width='278'>&nbsp;</td>";
                            strproduct += "</tr>";
                        }
                    }
                }
                else
                {
                    if (isspec.Equals("1"))
                    {
                        strproduct += "<td width='278' class='cl1'>";
                    }
                    else
                    {
                        strproduct += "<td width='278'>";
                    }
                    strproduct += "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
                    strproduct += "<tr><td rowspan='2' width='88' align='center' valign='top'>";
                    if (table.Rows[i][Product_data._ispromotion].ToString().Length > 0)
                    {
                        strproduct += "<img src='image/common/khuyenmai.gif' style='cursor:pointer;' onmouseover='showDivMessage(2," + id + "," + i + ",event);' onmouseout='OnMOut(event)'/><br />";
                    }
                    strproduct += "<a href='" + namepro + "-dp-" + id + ".html'><img class='img1' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)' src='" + url + "'/></a></td>";
                    strproduct += "<td colspan='2' valign='top' class='text_title'><a href='" + namepro + "-dp-" + id + ".html' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)'>" + name + "</a></td></tr>";
                    strproduct += "<tr><td valign='middle' width='165' height='48'>" + tprice + ": <span class='price'>";
                    if (price.Equals("0"))
                    {
                        strproduct += tupdate + "</span><br />";
                    }
                    else
                    {
                        if (unitPrice.Equals("$"))
                        {
                            strproduct += price + " VND</span><br />";
                            strproduct += "<font color='#FFFFFF'>" + tprice + ": </font><span class='price'>" + price22 + "</span><br />";
                        }
                        else if (unitPrice.Equals("$$"))
                        {
                            strproduct += price + " VND</span><br />";
                            strproduct += "<font color='#FFFFFF'>" + tprice + ": </font><span class='price'>" + price22 + " USD</span><br />";
                        }
                        else
                        {
                            strproduct += price + " " + unitPrice + "</span><br />";
                        }
                    }
                    strproduct += "<span class='tvat'>" + strMVAT + "</span><br />";
                    strproduct += twarranty + ": <span class='price'>" + warranty + " " + tmonth + "</span>";
                    //if (madein.Length > 0)
                    //{
                    //    strproduct += "<br /><span class='text_title'>" + madein + "</span>";
                    //}
                    strproduct += "</td><td width='25' align='right'><input type='checkbox' id='c" + id + "' name='cp'/></td></tr>";
                    //strproduct += "<tr><td colspan='3' height='32' align='center'><div class='button3' onclick='AddCart(" + id + ",1);'>" + torder + "</div></td></tr>";

                    if (madein.Length > 0)
                    {
                        strproduct += "<tr><td colspan='3' class='text_title' align='center'>" + madein + "</td></tr>";
                    }
                    
                    strproduct += "</table></td></tr>";
                    if (i + 1 < numPro)
                    {
                        strproduct += "<tr><td class='bg_line3'></td><td></td><td class='bg_line3'></td></tr>";
                    }
                    iseven = true;
                }
            }
            int numpro = list.Count;
            for (int i = 0; i < numpro; i++)
            {
                if (iseven)
                {
                    strproduct += "<tr><td width='278'>";
                    strproduct += list[i].ToString();
                    strproduct += "</td><td class='bg_line4'></td>";
                    iseven = false;
                    if (i + 1 == numpro)
                    {
                        strproduct += "<td width='278'>&nbsp;</td>";
                        strproduct += "</tr>";
                    }
                }
                else
                {
                    strproduct += "<td width='278'>";
                    strproduct += list[i].ToString();
                    strproduct += "</td></tr>";
                    if (i + 1 < numPro)
                    {
                        strproduct += "<tr><td class='bg_line3'></td><td></td><td class='bg_line3'></td></tr>";
                    }
                    iseven = true;
                }
            }
            strproduct += "<tr height='5'><td colspan='3'></td></tr>";
            strproduct += "</table>";
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
            strSelect = "<select class='select_num' id='s" + index + "' onchange='PageS(this," + current.ToString() + ",3);'><option value='20'>20</option><option value='30'>30</option><option value='40'>40</option></select>";
        }
        else if (pagesize == 30)
        {
            strSelect = "<select class='select_num' id='s" + index + "' onchange='PageS(this," + current.ToString() + ",3);'><option value='20'>20</option><option value='30' selected='selected'>30</option><option value='40'>40</option></select>";
        }
        else
        {
            strSelect = "<select class='select_num' id='s" + index + "' onchange='PageS(this," + current.ToString() + ",3);'><option value='20'>20</option><option value='30'>30</option><option value='40' selected='selected'>40</option></select>";
        }
        str = "<table border='0' cellpadding='0' cellspacing='0' width='100%' class='bg_page'>";
        str += "<tr><td width='45'>" + tdisplay + "</td><td width='40'>" + strSelect + "</td>";
        str += "<td width='100' align='right'><input type='text' id='t" + index + "' onkeydown=\"OnEnterSend(event,'u" + index + "');\" value='' class='tb_go' /><u class='u1' id='u" + index + "' onclick='GoGageS(" + index + ",3);'>" + tspage + "</u></td>";
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
            strlinkPage += "<a href='?menu=dasp&advance=1&page=1&size=" + pagesize.ToString() + "' class='page_previous'>" + tfirstp + "</a>";
        }
        int numLeft = 0;
        strlinkPage += "<span class='text_page'>";
        string subleft = "";
        while ((currentIndex >= 1) && ((current - currentIndex) < 3))
        {
            subleft = "<a href='?menu=dasp&advance=1&page=" + currentIndex.ToString() + "&size=" + pagesize.ToString() + "'>" + currentIndex.ToString() + "</a>" + subleft;
            numLeft++;
            currentIndex--;
        }
        strlinkPage += subleft;
        strlinkPage += "<u>" + current.ToString() + "</u>";
        currentIndex = current + 1;
        while ((currentIndex <= pages) && ((currentIndex - current) < 6 - numLeft))
        {
            strlinkPage += "<a href='?menu=dasp&advance=1&page=" + currentIndex.ToString() + "&size=" + pagesize.ToString() + "'>" + currentIndex.ToString() + "</a>";
            currentIndex++;
        }
        strlinkPage += "</span>";
        if (current < pages)
        {
            num = current + 1;
            strlinkPage += "<a href='?menu=dasp&advance=1&page=" + pages.ToString() + "&size=" + pagesize.ToString() + "' class='page_next'>" + tlastp + "</a>";
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
            str += "<tr><td align='right' width='265'><div class='dcompared' onclick='comp();'>" + tcompare + "</div></td><td>&nbsp;</td></tr></table>";
        }
        else
        {
            str += "<tr><td align='right' width='265'><div class='dcomparet' onclick='comp();'>" + tcompare + "</div></td><td>&nbsp;</td></tr></table>";
        }
        return str;
    }
}
