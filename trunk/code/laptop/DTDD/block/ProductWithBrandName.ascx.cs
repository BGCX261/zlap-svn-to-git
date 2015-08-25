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
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            unitPrice = Application["currencymobile"].ToString();
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            blpro = hash["blpro"].ToString();
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
            tupdate = hash["tupdate"].ToString();
            tCurrentAccess += ": <a href='?menu=home'>" + thome + "</a> &raquo; <a href='?menu=product'>" + tpro + "</a>";
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
        if (Session["SSMobileBrand"] != null)
        {
            ViewProduct = (CDynamicViewProduct)Session["SSMobileBrand"];
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
            ViewProduct.SetIdType((int)Application["idtypemobile"]);
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
            Session["SSMobileBrand"] = ViewProduct;
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
            string id = "";
            string name = "";
            string url = "";
            string price = "";
            string warranty = "";
            float rate = (float)Application["ratepromobi"];
            float price1 = 1;
            Boolean istest = false;
            ArrayList list = new ArrayList();
            string substring = "";
            string madein = "";
            string isSpec = "";
            if (ViewProduct.GetCurrentPage() == 1)
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
                price1 = float.Parse(table.Rows[i][Product_data._price].ToString());
                price1 = price1 * rate;
                price = price1.ToString("N").Split('.')[0];
                warranty = table.Rows[i][Product_data._WarrantyMonth].ToString();
                madein = table.Rows[i][Product_data._shortnote].ToString();
                isSpec = table.Rows[i][Product_data._ispec].ToString();
                if (istest == true && price.Equals("0"))
                {
                    substring = "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
                    substring += "<tr><td rowspan='2' width='95' align='center'>";
                    substring += "<a href='?menu=dp&id=" + id + "'><img class='img2' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)' src='" + url + "'/></a></td>";
                    substring += "<td class='txt2' colspan='2'><a href='?menu=dp&id=" + id + "' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)'>" + name + "</a></td></tr>";
                    substring += "<tr valign='top'><td width='159'>" + tprice + ": <span class='txt4'>";
                    substring += tupdate + "</span><br />";
                    substring += twarranty + ": <span class='txt4'>" + warranty + " " + tmonth + "</span><br />";
                    if (table.Rows[i][Product_data._ispromotion].ToString().Length > 0)
                    {
                        substring += "<img src='image/common/khuyenmai.gif' style='cursor:pointer;' onmouseover='showDivMessage(2," + id + "," + i + ",event);' onmouseout='OnMOut(event)'/><br />";
                    }
                    substring += "</td><td width='25'><input type='checkbox' id='c" + id + "' name='cp'/></td></tr>";
                    substring += "</table>";
                    list.Add(substring);
                    continue;
                }
                if (iseven)
                {
                    if (isSpec.Equals("1"))
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
                    if (isSpec.Equals("1"))
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
        if (pagesize == 20)
        {
            strSelect = "<select class='sl2' id='s" + index + "' onchange='PageBrand(this," + idbrand + "," + current.ToString() + ",1);'><option value='20'>20</option><option value='30'>30</option><option value='40'>40</option></select>";
        }
        else if (pagesize == 30)
        {
            strSelect = "<select class='sl2' id='s" + index + "' onchange='PageBrand(this," + idbrand + "," + current.ToString() + ",1);'><option value='20'>20</option><option value='30' selected='selected'>30</option><option value='40'>40</option></select>";
        }
        else
        {
            strSelect = "<select class='sl2' id='s" + index + "' onchange='PageBrand(this," + idbrand + "," + current.ToString() + ",1);'><option value='20'>20</option><option value='30'>30</option><option value='40' selected='selected'>40</option></select>";
        }
        str = "<table border='0' cellpadding='0' cellspacing='0' width='100%' class='bgcl6'>";
        str += "<tr><td width='200'>" + tdisplay + " " + strSelect;
        str += " " + "<input type='text' id='t" + index + "' onkeydown=\"OnEnterSend(event,'u" + index + "');\" value='' class='tb3' /> <a id='u" + index + "' href='#' onclick='GoGageB(" + idbrand + "," + index + ",1);'>" + tspage + "</u></td>";
        str += "<td align='center'>";
        string strlinkPage = "";
        if (current == 1)
        {
            strlinkPage += "<input type='button' class='arrow2' onclick=\"OnCPage('pro'," + pages + "," + pagesize + "," + idbrand + ")\" />";
            strlinkPage += " <span class='txt3'>" + current + "/" + pages + "</span> ";
            strlinkPage += "<input type='button' class='arrow1' onclick=\"OnCPage('pro',2," + pagesize + "," + idbrand + ")\" />";
        }
        else if (current == pages)
        {
            strlinkPage += "<input type='button' class='arrow2' onclick=\"OnCPage('pro'," + (current - 1) + "," + pagesize + "," + idbrand + ")\" />";
            strlinkPage += " <span class='txt3'>" + current + "/" + pages + "</span> ";
            strlinkPage += "<input type='button' class='arrow1' onclick=\"OnCPage('pro',1," + pagesize + "," + idbrand + ");\" />";
        }
        else
        {
            strlinkPage += "<input type='button' class='arrow2' onclick=\"OnCPage('pro'," + (current - 1) + "," + pagesize + "," + idbrand + ")\" />";
            strlinkPage += " <span class='txt3'>" + current + "/" + pages + "</span> ";
            strlinkPage += "<input type='button' class='arrow1' onclick=\"OnCPage('pro'," + (current + 1) + "," + pagesize + "," + idbrand + ")\" />";
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
    private string GetAdvertiseWithBrand(string idBrand)
    {
        string str = "";
        try
        {
            DataSet dsAdvertise = new AdvertiseSystem().SpecialIdbrandTop(idBrand,2);
            int num = dsAdvertise.Tables[0].Rows.Count;
            if (num > 0)
            {
                for (int i = 0; i < num; i++)
                {
                    string img2 = dsAdvertise.Tables[0].Rows[i]["UrlImage1"].ToString();
                    if (img2.Length > 0)
                    {
                        string[] extension = img2.Split('.');
                        if (extension[1].Equals("swf"))
                        {
                            str += "<object width='574' height='90'><embed src='image/advertise/" + img2 + "' width='574' height='90' type='application/x-shockwave-flash' pluginspage='http://www.macromedia.com/go/getflashplayer'></embed></object><br /><br />";
                        }
                        else
                        {
                            str += "<a href='" + dsAdvertise.Tables[0].Rows[0]["link"].ToString() + "'><img src='image/advertise/" + img2 + "' width='574' height='90' border='0'/></a><br />";
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
