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
using facade.list;
using framework.list.dynamicviewhelper;
public partial class block_ProductWithBrandName : System.Web.UI.UserControl
{
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
    public string tupdate = "";
    public string strAdvertise = "";
    private string strMVAT = "";
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
            tupdate = hash["tupdate"].ToString();
            strMVAT = hash["msvat"].ToString();
            tCurrentAccess += ": <a href='?menu=home'>" + thome + "</a> &raquo; <a href='?menu=product' onmouseover='OnMOMenu(0,1,11,event);' onmouseout='TimeHidden();'>" + tpro + "</a>";
            strProduct = ShowProductWithBrand();
        }
        catch
        {
        }
    }
    public string ShowProductWithBrand()
    {
        CDynamicViewProduct ViewProduct;
        int currentpage = 0;
        int size = 30;
        int idBrand = 0;
        string nameBrand = "";
        try
        {
            idBrand=int.Parse(Request.QueryString["brand"].ToString());
            currentpage = int.Parse(Request.QueryString["page"].ToString());
            size = int.Parse(Request.QueryString["size"].ToString());
            if (size > 40 || size < 10)
            {
                size = 30;
            }
        }
        catch
        {

        }
        if (Session["SSProductBrand"] != null)
        {
            ViewProduct = (CDynamicViewProduct)Session["SSProductBrand"];
            ViewProduct.SetPageSize(size);
            if (idBrand != ViewProduct.GetIdBrand())
            {
                ViewProduct.SetIdBrand(idBrand);
                ViewProduct.SetNumProductWithBrand();
            }
            if (currentpage > 0)
            {
                ViewProduct.SetCurrentPage(currentpage);
            }
            else
            {
                ViewProduct.SetNumProductWithBrand();
                ViewProduct.SetCurrentPage();
            }
        }
        else
        {
            ViewProduct = new CDynamicViewProduct();
            ViewProduct.SetIdType((int)Application["idtypeproduct"]);
            ViewProduct.SetIdBrand(idBrand);
            ViewProduct.SetNumProductWithBrand();
            ViewProduct.SetPageSize(size);
            if (currentpage > 0)
            {
                ViewProduct.SetCurrentPage(currentpage);
            }
            else
            {
                ViewProduct.SetCurrentPage();
            }
            Session["SSProductBrand"] = ViewProduct;
        }
        nameBrand = ViewProduct.GetNameBrand();
        if (nameBrand.Length > 0)
        {
            tCurrentAccess += " &raquo; " + nameBrand;
        }
        blpro = string.Format(blpro, "<u>" + ViewProduct.GetNumberRecord() + "</u>");
        Product_data product = ViewProduct.ProductWithBrandFromTo();
        DataTable table = product.Tables[Product_data._table];
        int numPro = table.Rows.Count;
        Boolean iseven = true;
        if (ViewProduct.GetPages() > 1)
        {
            strpage1 = CreatePage(idBrand, ViewProduct.GetCurrentPage(), ViewProduct.GetPages(), ViewProduct.GetPageSize(),1);
            strpage2 = CreatePage(idBrand, ViewProduct.GetCurrentPage(), ViewProduct.GetPages(), ViewProduct.GetPageSize(),2);
        }
        else if (ViewProduct.GetPages() == 1)
        {
            strpage1 = ButtonCompare(true);
            strpage2 = ButtonCompare(false);
        }
        string strProMain="";
        if (numPro > 0)
        {
            strAdvertise = GetAdvertiseWithBrand(idBrand.ToString());
            strProMain = "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
            strProMain += "<tr height='5'><td colspan='3'></td></tr>";
            string id = "";
            string name = "";
            string url = "";
            string price = "";
            string warranty = "";
            float rate = (float)Application["ratepromain"];
            float price1 = 1;
            string price2 = "";
            Boolean istest = false;
            ArrayList list = new ArrayList();
            string substring = "";
            string madein = "";
            string isSpec = "";
            if (ViewProduct.GetCurrentPage() <= 2)
            {
                istest = true;
            }
            string StateId = "1";
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
                price2 = table.Rows[i][Product_data._price].ToString();
                price1 = float.Parse(table.Rows[i][Product_data._price].ToString());
                price1 = price1 * rate;
                price = price1.ToString("N").Split('.')[0];
                warranty = table.Rows[i][Product_data._WarrantyMonth].ToString();
                madein = table.Rows[i][Product_data._shortnote].ToString();
                isSpec = table.Rows[i][Product_data._ispec].ToString();
                StateId = table.Rows[i][Product_data._stateid].ToString();
                if (StateId.Equals("2") || StateId.Equals("3") || StateId.Equals("5"))
                {
                    StateId = "2";
                }
                if (istest == true && (price.Equals("0") || StateId.Equals("2")))
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


                    if (price.Equals("0"))
                    {
                        substring += tupdate + "</span><br />";
                    }
                    else
                    {
                        if (unitPrice.Equals("$"))
                        {
                            substring += price + " VND</span><br />";
                            substring += "<font color='#FFFFFF'>" + tprice + ": </font><span class='price'>" + price2 + "</span><br />";
                        }
                        else if (unitPrice.Equals("$$"))
                        {
                            substring += price + " VND</span><br />";
                            substring += "<font color='#FFFFFF'>" + tprice + ": </font><span class='price'>" + price2 + " USD</span><br />";
                        }
                        else
                        {
                            substring += price + " " + unitPrice + "</span><br />";
                        }
                        substring += "<span class='tvat'>" + strMVAT + "</span><br />";
                    }
                    
                    
                    
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
                    if (isSpec.Equals("1"))
                    {
                        strProMain += "<tr><td width='278' class='cl1'>";
                    }
                    else
                    {
                        strProMain += "<tr><td width='278'>";
                    }
                    strProMain += "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
                    strProMain += "<tr><td rowspan='2' width='88' align='center' valign='top'>";
                    if (table.Rows[i][Product_data._ispromotion].ToString().Length > 0)
                    {
                        strProMain += "<img src='image/common/khuyenmai.gif' style='cursor:pointer;' onmouseover='showDivMessage(2," + id + "," + i + ",event);' onmouseout='OnMOut(event)'/><br />";
                    }
                    strProMain += "<a href='" + namepro + "-dp-" + id + ".html'><img class='img1' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)' src='" + url + "'/></a></td>";
                    strProMain += "<td colspan='2' valign='top' class='text_title'><a href='" + namepro + "-dp-" + id + ".html' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)'>" + name + "</a></td></tr>";
                    strProMain += "<tr><td valign='middle' width='165' height='48'>" + tprice + ": <span class='price'>";
                    if (price.Equals("0"))
                    {
                        strProMain += tupdate + "</span><br />";
                    }
                    else
                    {
                        if (unitPrice.Equals("$"))
                        {
                            strProMain += price + " VND</span><br />";
                            strProMain += "<font color='#FFFFFF'>" + tprice + ": </font><span class='price'>" + price2 + "</span><br />";
                        }
                        else if (unitPrice.Equals("$$"))
                        {
                            strProMain += price + " VND</span><br />";
                            strProMain += "<font color='#FFFFFF'>" + tprice + ": </font><span class='price'>" + price2 + " USD</span><br />";
                        }
                        else
                        {
                            strProMain += price + " " + unitPrice + "</span><br />";
                        }
                    }
                    strProMain += "<span class='tvat'>" + strMVAT + "</span><br />";
                    strProMain += twarranty + ": <span class='price'>" + warranty + " " + tmonth + "</span>";
                    //if (madein.Length > 0)
                    //{
                    //    strProMain += "<br /><span class='text_title'>" + madein + "</span>";
                    //}
                    strProMain += "</td><td width='25' align='right'><input type='checkbox' id='c" + id + "' name='cp'/></td></tr>";
                    //strProMain += "<tr><td colspan='3' height='32' align='center'><div class='button3' onclick='AddCart(" + id + ",1);'>" + torder + "</div></td></tr>";

                    if (madein.Length > 0)
                    {
                        strProMain += "<tr><td colspan='3' class='text_title' align='center'>" + madein + "</td></tr>";
                    }

                    strProMain += "</table></td>";
                    strProMain += "<td class='bg_line4'></td>";
                    iseven = false;
                    if (i + 1 == numPro)
                    {
                        if (list.Count == 0)
                        {
                            strProMain += "<td width='278'>&nbsp;</td>";
                            strProMain += "</tr>";
                        }
                    }
                }
                else
                {
                    if (isSpec.Equals("1"))
                    {
                        strProMain += "<td width='278' class='cl1'>";
                    }
                    else
                    {
                        strProMain += "<td width='278'>";
                    }
                    strProMain += "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
                    strProMain += "<tr><td rowspan='2' width='88' align='center' valign='top'>";
                    if (table.Rows[i][Product_data._ispromotion].ToString().Length > 0)
                    {
                        strProMain += "<img src='image/common/khuyenmai.gif' style='cursor:pointer;' onmouseover='showDivMessage(2," + id + "," + i + ",event);' onmouseout='OnMOut(event)'/><br />";
                    }
                    strProMain += "<a href='" + namepro + "-dp-" + id + ".html'><img class='img1' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)' src='" + url + "'/></a></td>";
                    strProMain += "<td colspan='2' valign='top' class='text_title'><a href='" + namepro + "-dp-" + id + ".html' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)'>" + name + "</a></td></tr>";
                    strProMain += "<tr><td valign='middle' width='165' height='48'>" + tprice + ": <span class='price'>";
                    if (price.Equals("0"))
                    {
                        strProMain += tupdate + "</span><br />";
                    }
                    else
                    {
                        if (unitPrice.Equals("$"))
                        {
                            strProMain += price + " VND</span><br />";
                            strProMain += "<font color='#FFFFFF'>" + tprice + ": </font><span class='price'>" + price2 + "</span><br />";
                        }
                        else if (unitPrice.Equals("$$"))
                        {
                            strProMain += price + " VND</span><br />";
                            strProMain += "<font color='#FFFFFF'>" + tprice + ": </font><span class='price'>" + price2 + " USD</span><br />";
                        }
                        else
                        {
                            strProMain += price + " " + unitPrice + "</span><br />";
                        }
                    }
                    strProMain += "<span class='tvat'>" + strMVAT + "</span><br />";
                    strProMain += twarranty + ": <span class='price'>" + warranty + " " + tmonth + "</span>";
                    //if (madein.Length > 0)
                    //{
                    //    strProMain += "<br /><span class='text_title'>" + madein + "</span>";
                    //}
                    strProMain += "</td><td width='25' align='right'><input type='checkbox' id='c" + id + "' name='cp'/></td></tr>";
                    //strProMain += "<tr><td colspan='3' height='32' align='center'><div class='button3' onclick='AddCart(" + id + ",1);'>" + torder + "</div></td></tr>";
                    if (madein.Length > 0)
                    {
                        strProMain += "<tr><td colspan='3' class='text_title' align='center'>" + madein + "</td></tr>";
                    }
                    
                    strProMain += "</table></td></tr>";
                    if (i + 1 < numPro)
                    {
                        strProMain += "<tr><td class='bg_line3'></td><td></td><td class='bg_line3'></td></tr>";
                    }
                    iseven = true;
                }
            }
            int numpro = list.Count;
            for (int i = numpro-1; i >=0; i--)
            {
                if (iseven)
                {
                    strProMain += "<tr><td width='278'>";
                    strProMain += list[i].ToString();
                    strProMain += "</td><td class='bg_line4'></td>";
                    iseven = false;
                    if (i == 0)
                    {
                        strProMain += "<td width='278'>&nbsp;</td>";
                        strProMain += "</tr>";
                    }
                }
                else
                {
                    strProMain += "<td width='278'>";
                    strProMain += list[i].ToString();
                    strProMain += "</td></tr>";
                    if (i > 0)
                    {
                        strProMain += "<tr><td class='bg_line3'></td><td></td><td class='bg_line3'></td></tr>";
                    }
                    iseven = true;
                }
            }
            strProMain += "<tr height='5'><td colspan='3'></td></tr>";
            strProMain += "</table>";
        }
        else
        {
            strProMain = tnotpro; 
        }
        return strProMain;
    }
    public string CreatePage(int idbrand,int current, int pages, int pagesize,int index)
    {
        string str = "";
        string strSelect = "";
        str="<table border='0' cellpadding='0' cellspacing='0' width='100%' class='bg_page'><tr>";
        if (pagesize == 20)
        {
            strSelect = "<select class='select_num' id='s" + index + "' onchange='PageBrand(this," + idbrand + "," + current.ToString() + ",1);'><option value='20'>20</option><option value='30'>30</option><option value='40'>40</option></select>";
        }
        else if (pagesize == 30)
        {
            strSelect = "<select class='select_num' id='s" + index + "' onchange='PageBrand(this," + idbrand + "," + current.ToString() + ",1);'><option value='20'>20</option><option value='30' selected='selected'>30</option><option value='40'>40</option></select>";
        }
        else
        {
            strSelect = "<select class='select_num' id='s" + index + "' onchange='PageBrand(this," + idbrand + "," + current.ToString() + ",1);'><option value='20'>20</option><option value='30'>30</option><option value='40' selected='selected'>40</option></select>";
        }
        str += "<td width='45'>" + tdisplay + "</td><td width='45'>" + strSelect + "</td>";
        str += "<td width='100' align='right'><input type='text' id='t" + index + "' onkeydown=\"OnEnterSend(event,'u" + index + "');\" value='' class='tb_go' /><u class='u1' id='u" + index + "' onclick='GoGageB(" + idbrand + "," + index + ",1);'>" + tspage + "</u></td>";
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
            strlinkPage += "<a href='?menu=pro&brand=" + idbrand + "&page=1&size=" + pagesize.ToString() + "' class='page_previous'>" + tfirstp + "</a>";
        }
        int numLeft = 0;
        strlinkPage += "<span class='text_page'>";
        string subleft = "";
        while ((currentIndex >= 1) && ((current - currentIndex) < 3))
        {
            subleft = "<a href='?menu=pro&brand=" + idbrand + "&page=" + currentIndex.ToString() + "&size=" + pagesize.ToString() + "'>" + currentIndex.ToString() + "</a>" + subleft;
            numLeft++;
            currentIndex--;
        }
        strlinkPage += subleft;
        strlinkPage += "<u>" + current.ToString() + "</u>";
        currentIndex = current + 1;
        while ((currentIndex <= pages) && ((currentIndex - current) < 6 - numLeft))
        {
            strlinkPage += "<a href='?menu=pro&brand=" + idbrand + "&page=" + currentIndex.ToString() + "&size=" + pagesize.ToString() + "'>" + currentIndex.ToString() + "</a>";
            currentIndex++;
        }
        strlinkPage += "</span>";
        if (current < pages)
        {
            num = current + 1;
            strlinkPage += "<a href='?menu=pro&brand=" + idbrand + "&page=" + pages.ToString() + "&size=" + pagesize.ToString() + "' class='page_next'>" + tlastp + "</a>";
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
    private string GetAdvertiseWithBrand(string idBrand)
    {
        string str = "";
        try
        {
            DataSet dsAdvertise = new AdvertiseSystem().SpecialIdbrandTop(idBrand,1);
            int num = dsAdvertise.Tables[0].Rows.Count;
            if (num > 0)
            {
                for (int i = 0; i < num; i++)
                {
                    string img1 = dsAdvertise.Tables[0].Rows[i]["UrlImage1"].ToString();
                    if (img1.Length > 0)
                    {
                        string[] extension = img1.Split('.');
                        if (extension[1].Equals("swf"))
                        {
                            str += "<object width='574' height='90'><embed src='image/advertise/" + img1 + "' width='574' height='90' quality='high' scale='noscale' wmode='transparent' type='application/x-shockwave-flash' pluginspage='http://www.macromedia.com/go/getflashplayer'></embed></object><br /><br />";
                        }
                        else
                        {
                            str += "<a href='" + dsAdvertise.Tables[0].Rows[0]["link"].ToString() + "'><img src='image/advertise/" + img1 + "' width='574' height='90' border='0'/></a><br />";
                        }
                    }
                }
            }
        }
        catch
        { }
        return str;
    }
}
