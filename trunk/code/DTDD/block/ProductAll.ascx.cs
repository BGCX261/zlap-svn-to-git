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
public partial class block_ProductAll : System.Web.UI.UserControl
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
    public string tupdate = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            unitPrice=Application["currencymobile"].ToString();
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
            tCurrentAccess += ": <a href='?menu=home'>" + thome + "</a> &raquo; " + tpro;
            strProduct=ShowProductAll();
        }
        catch
        {
        }
    }
    public string ShowProductAll()
    {
        CDynamicViewProduct ViewProduct;
        int currentpage=0;
        int size = 30;
        try
        {
            currentpage =int.Parse(Request.QueryString["page"].ToString());
            size = int.Parse(Request.QueryString["size"].ToString());
            if (size > 40 || size < 10)
            {
                size = 30;
            }
        }
        catch
        {
        }
        if (Session["SSMobileAll"] != null)
        {
            ViewProduct = (CDynamicViewProduct)Session["SSMobileAll"];
            ViewProduct.SetPageSize(size);
            if (currentpage > 0)
            {
                ViewProduct.SetCurrentPage(currentpage);
            }
            else
            {
                ViewProduct.SetNumProduct();
                ViewProduct.SetCurrentPage();
            }
        }
        else
        {
            ViewProduct = new CDynamicViewProduct();
            ViewProduct.SetIdType((int)Application["idtypemobile"]);
            ViewProduct.SetNumProduct();
            ViewProduct.SetPageSize(size);
            if (currentpage > 0)
            {
                ViewProduct.SetCurrentPage(currentpage);
            }
            else
            {
                ViewProduct.SetCurrentPage();
            }
            Session["SSMobileAll"] = ViewProduct;
        }
        blpro = string.Format(blpro, "<u>" + ViewProduct.GetNumberRecord() + "</u>");
        Product_data product = ViewProduct.ProductIdTypeFromTo();
        DataTable table = product.Tables[Product_data._table];
        int numPro = table.Rows.Count;
        Boolean iseven = true;
        if (ViewProduct.GetPages() > 1)
        {
            strpage1 = CreatePage(ViewProduct.GetCurrentPage(), ViewProduct.GetPages(), ViewProduct.GetPageSize(), 1);
            strpage2 = CreatePage(ViewProduct.GetCurrentPage(), ViewProduct.GetPages(), ViewProduct.GetPageSize(), 2);
        }
        else if(ViewProduct.GetPages() == 1)
        {
            strpage1 = ButtonCompare(true);
            strpage2 = ButtonCompare(false);
        }
        string strProMain = "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
        string id = "";
        string name = "";
        string url = "";
        string price = "0";
        float rate =(float)Application["ratepromain"];
        float price1 = 1;
        string warranty = "";
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
            isSpec = table.Rows[i][Product_data._ispec].ToString();
            if (url.Length > 0)
            {
                url = "image/img_pro/" + url;
            }
            else
            {
                url = "image/common/notimgpro.png";
            }
            price1 = float.Parse(table.Rows[i][Product_data._price].ToString());
            price1 = price1 * rate;
            price = price1.ToString("N").Split('.')[0];
            warranty = table.Rows[i][Product_data._WarrantyMonth].ToString();
            madein = table.Rows[i][Product_data._shortnote].ToString();
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
                //strProMain += "<tr><td colspan='3' align='center' height='32'><div class='button3' onclick='AddCart(" + id + ",1);'>" + torder + "</div></td></tr>";
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
                if(price.Equals("0"))
                {
                    strProMain += tupdate + "</span><br />";
                }else
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
        return strProMain;
    }
    public string CreatePage(int current,int pages,int pagesize,int index)
    {
        string str = "";
        string strSelect = "";
        if (pagesize == 20)
        {
            strSelect = "<select class='sl2' id='s" + index + "' onchange='PageAll(this," + current.ToString() + ",1);'><option value='20'>20</option><option value='30'>30</option><option value='40'>40</option></select>";
        }
        else if (pagesize == 30)
        {
            strSelect = "<select class='sl2' id='s" + index + "' onchange='PageAll(this," + current.ToString() + ",1);'><option value='20'>20</option><option value='30' selected='selected'>30</option><option value='40'>40</option></select>";
        }else
        {
            strSelect = "<select class='sl2' id='s" + index + "' onchange='PageAll(this," + current.ToString() + ",1);'><option value='20'>20</option><option value='30'>30</option><option value='40' selected='selected'>40</option></select>";
        }
        str = "<table border='0' cellpadding='0' cellspacing='0' width='100%' class='bgcl6'>";
        str += "<tr><td width='200'>" + tdisplay + " " + strSelect;
        str += " " + "<input type='text' id='t" + index + "' onkeydown=\"OnEnterSend(event,'u" + index + "');\" value='' class='tb3' /> <a id='u" + index + "' href='#' onclick='GoGage(" + index + ",1);'>" + tspage + "</a></td>";
        str += "<td align='center'>";
        string strlinkPage = "";
        if (current == 1)
        {
            strlinkPage += "<input type='button' class='arrow2' onclick=\"OnCPage('product'," + pages + "," + pagesize + ")\" />";
            strlinkPage += " <span class='txt3'>" + current + "/" + pages + "</span> ";
            strlinkPage += "<input type='button' class='arrow1' onclick=\"OnCPage('product',2," + pagesize + ")\" />";
        }
        else if (current == pages)
        {
            strlinkPage += "<input type='button' class='arrow2' onclick=\"OnCPage('product'," + (current - 1) + "," + pagesize + ")\" />";
            strlinkPage += " <span class='txt3'>" + current + "/" + pages + "</span> ";
            strlinkPage += "<input type='button' class='arrow1' onclick=\"OnCPage('product',1," + pagesize + ");\" />";
        }
        else
        {
            strlinkPage += "<input type='button' class='arrow2' onclick=\"OnCPage('product'," + (current - 1) + "," + pagesize + ")\" />";
            strlinkPage += " <span class='txt3'>" + current + "/" + pages + "</span> ";
            strlinkPage += "<input type='button' class='arrow1' onclick=\"OnCPage('product'," + (current + 1) + "," + pagesize + ")\" />";
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
