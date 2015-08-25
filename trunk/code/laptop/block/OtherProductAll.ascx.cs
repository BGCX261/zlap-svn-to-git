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
public partial class block_OtherProductAll : System.Web.UI.UserControl
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
    public string tbrand = "";
    public string tspage = "";
    public string tlastp = "";
    public string tfirstp = "";
    public string tCurrentAccess = "";
    public string thome = "";
    public string tpro = "";
    public string tcompare = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            blpro = hash["blpro"].ToString();
            tprice = hash["tprice"].ToString();
            twarranty = hash["twarranty"].ToString();
            tmonth = hash["tmonth"].ToString();
            torder = hash["torder"].ToString();
            tCurrentAccess = hash["currentpage"].ToString();
            tcompare = hash["bcompare"].ToString();
            tbrand = hash["brand"].ToString();
            tpro = hash["otherpro"].ToString();
            tfirstp = hash["firstp"].ToString();
            tlastp = hash["lastp"].ToString();
            tdisplay = hash["display"].ToString();
            tspage = hash["spage"].ToString();
            thome = hash["home"].ToString();
            tCurrentAccess += ": <a href='?menu=home'>" + thome + "</a> &raquo; " + tpro;
            strProduct = ShowProductAll();
        }
        catch
        {
        }
    }
    public string ShowProductAll()
    {
        CDynamicViewProduct ViewProduct;
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
        if (Session["SSProductOther"] != null)
        {
            ViewProduct = (CDynamicViewProduct)Session["SSProductOther"];
            ViewProduct.SetPageSize(size);
            if (currentpage > 0)
            {
                ViewProduct.SetCurrentPage(currentpage);
            }
            else
            {
                ViewProduct.SetNumberOther();
                ViewProduct.SetCurrentPage();
            }
        }
        else
        {
            ViewProduct = new CDynamicViewProduct();
            string where = "WHERE producttypeid NOT In (" + Application["idtypeproduct"].ToString() +
                "," + Application["apppda"].ToString() + "," + Application["idtypemobile"].ToString() 
                + ") and Cansales = 1 AND ProductTypeId IN (SELECT Id FROM tbl_ProductType WHERE Cansales =1)";
            ViewProduct.SetWhere(where);
            ViewProduct.SetNumberOther();
            ViewProduct.SetPageSize(size);
            if (currentpage > 0)
            {
                ViewProduct.SetCurrentPage(currentpage);
            }
            else
            {
                ViewProduct.SetCurrentPage();
            }
            Session["SSProductOther"] = ViewProduct;
        }
        blpro = string.Format(blpro, "<u>" + ViewProduct.GetNumberRecord() + "</u>");
        DataSet product = ViewProduct.ProductOtherFromTo();
        DataTable table = product.Tables[0];
        int numPro = table.Rows.Count;
        if (ViewProduct.GetPages() > 1)
        {
            strpage1 = CreatePage(ViewProduct.GetCurrentPage(), ViewProduct.GetPages(), ViewProduct.GetPageSize(), 1);
            strpage2 = CreatePage(ViewProduct.GetCurrentPage(), ViewProduct.GetPages(), ViewProduct.GetPageSize(), 2);
        }
        string strProMain="";
        if (numPro > 0)
        {
            string id = "";
            string name = "";
            string url = "";
            string price = "";
            string warranty = "";
            string note = "";
            string brand = "";
            strProMain = "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
            for (int i = 0; i < numPro; i++)
            {
                id = table.Rows[i]["Id"].ToString();
                name = table.Rows[i]["Name"].ToString();
                url = table.Rows[i]["UrlImage"].ToString();
                note = table.Rows[i]["Note"].ToString();
                if (url.Length > 0)
                {
                    url = "image/img_pro/" + url;
                }
                else
                {
                    url = "image/common/notimgpro.png";
                }
                price = table.Rows[i]["SellingPrice"].ToString();
                warranty = table.Rows[i]["WarrantyMonth"].ToString();
                brand = table.Rows[i]["brand"].ToString();
                strProMain += "<tr><td width='300'>";
                strProMain += "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
                strProMain += "<tr><td rowspan='2' width='80' align='center'><a href='?menu=dother&id=" + id + "'><img class='img1' src='" + url + "'/></a></td>";
                strProMain += "<td class='text_title'><a href='?menu=dother&id=" + id + "'>" + name + "</a></td></tr>";
                strProMain += "<tr><td>" + tbrand + ": <span class='price'>" + brand + "</span><br />" + tprice + ": <span class='price'>" + price + " " + table.Rows[i]["currency"].ToString() + "</span><br />" + twarranty + ": <span class='price'>" + warranty + " " + tmonth + "</span>";
                if (table.Rows[i]["promotion"].ToString().Length > 0)
                {
                    strProMain += "<br /><img src='image/common/khuyenmai.gif' style='cursor:pointer;' onmouseover='showDivMessage(2," + id + "," + i + ",event);' onmouseout='OnMOut(event)'/>";
                }
                strProMain += "</td></tr>";
                strProMain += "<tr><td colspan='2' align='center'><div class='button3' onclick='AddCart(" + id + ",4);'>" + torder + "</div></td></tr>";
                strProMain += "</table></td>";
                strProMain += "<td>" + note + "</td></tr>";
                if (i < numPro - 1)
                {
                    strProMain += "<tr><td colspan='2' class='bg_line3'></td></tr>";
                }
            }
            strProMain += "</table>";
        }
        return strProMain;
    }
    public string CreatePage(int current, int pages, int pagesize, int index)
    {
        string str = "";
        string strSelect = "";
        if (pagesize == 20)
        {
            strSelect = "<select class='select_num' id='s" + index + "' onchange='PageAll(this," + current.ToString() + ",3);'><option value='20'>20</option><option value='30'>30</option><option value='40'>40</option></select>";
        }
        else if (pagesize == 30)
        {
            strSelect = "<select class='select_num' id='s" + index + "' onchange='PageAll(this," + current.ToString() + ",3);'><option value='20'>20</option><option value='30' selected='selected'>30</option><option value='40'>40</option></select>";
        }
        else
        {
            strSelect = "<select class='select_num' id='s" + index + "' onchange='PageAll(this," + current.ToString() + ",3);'><option value='20'>20</option><option value='30'>30</option><option value='40' selected='selected'>40</option></select>";
        }
        str = "<table border='0' cellpadding='0' cellspacing='0' width='100%' class='bg_page'>";
        str += "<tr><td width='45'>" + tdisplay + "</td><td width='40'>" + strSelect + "</td>";
        str += "<td width='100' align='right'><input type='text' id='t" + index + "' onkeydown=\"OnEnterSend(event,'u" + index + "');\" value='' class='tb_go' /><u id='u" + index + "' class='u1' onclick='GoGage(" + index + ",3);'>" + tspage + "</u></td>";
        str += "<td align='right'>";
        string strlinkPage = "";
        int num = 0;
        int currentIndex = current - 1;
        if (current > 1)
        {
            num = current - 1;
            strlinkPage += "<a href='?menu=other&page=1&size=" + pagesize.ToString() + "' class='page_previous'>" + tfirstp + "</a>";
        }
        int numLeft = 0;
        strlinkPage += "<span class='text_page'>";
        string subleft = "";
        while ((currentIndex >= 1) && ((current - currentIndex) < 3))
        {
            subleft = "<a href='?menu=other&page=" + currentIndex.ToString() + "&size=" + pagesize.ToString() + "'>" + currentIndex.ToString() + "</a>" + subleft;
            numLeft++;
            currentIndex--;
        }
        strlinkPage += subleft;
        strlinkPage += "<u>" + current.ToString() + "</u>";
        currentIndex = current + 1;
        while ((currentIndex <= pages) && ((currentIndex - current) < 6 - numLeft))
        {
            strlinkPage += "<a href='?menu=other&page=" + currentIndex.ToString() + "&size=" + pagesize.ToString() + "'>" + currentIndex.ToString() + "</a>";
            currentIndex++;
        }
        strlinkPage += "</span>";
        if (current < pages)
        {
            num = current + 1;
            strlinkPage += "<a href='?menu=other&page=" + pages.ToString() + "&size=" + pagesize.ToString() + "' class='page_next'>" + tlastp + "</a>";
        }
        str += strlinkPage;
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
