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

using facade.list;
public partial class block_PocketPcAll : System.Web.UI.UserControl
{
    public string blpro = "";
    public string tCurrentAccess = "";
    public string tprice = "";
    public string thome = "";
    public string twarranty = "";
    public string tmonth = "";
    public string tpro = "";
    public string strProduct = "";
    public string tbrand = "";
    private string unitPrice = "USD";
    ProductSystem Products = new ProductSystem();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            unitPrice = Application["currency"].ToString();
            if (unitPrice.Equals("$"))
            {
                unitPrice = "VND";
            }
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            blpro = hash["blpro"].ToString();
            tprice = hash["tprice"].ToString();
            twarranty = hash["twarranty"].ToString();
            tmonth = hash["tmonth"].ToString();
            tCurrentAccess = hash["currentpage"].ToString();
            tpro = hash["pocketpc"].ToString();
            thome = hash["home"].ToString();
            tbrand = hash["brand"].ToString();
            tCurrentAccess += ": <a href='?menu=home'>" + thome + "</a> &raquo; " + tpro;
            strProduct = ShowProductAll();
        }
        catch
        {
        }
    }
    public string ShowProductAll()
    {
        string strProMain = "";
        try
        {
            if (Application["apppda"] == null)
            { 
                //Create app:
                Application["apppda"] = 1;
            }
            string where="where producttypeid=" + Application["apppda"].ToString() + " and Cansales=1";
            DataSet dsPda = Products.ProductSelectAllIdType(where);
            DataTable table = dsPda.Tables[0];
            int num = table.Rows.Count;
            blpro = string.Format(blpro, "<u>" + num + "</u>");
            if (num > 0)
            {
                string id = "";
                string name = "";
                string url = "";
                string price = "";
                string warranty = "";
                string note = "";
                string brand = "";
                float rate = (float)Application["ratepromain"];
                float price1 = 1;
                strProMain = "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
                for(int i=0;i<num;i++)
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
                    //price = table.Rows[i]["SellingPrice"].ToString();
                    price1 = float.Parse(table.Rows[i]["SellingPrice"].ToString());
                    price1 = price1 * rate;
                    price = price1.ToString("N").Split('.')[0];
                    warranty = table.Rows[i]["WarrantyMonth"].ToString();
                    brand = table.Rows[i]["brand"].ToString();
                    strProMain += "<tr><td width='300'>";
                    strProMain += "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
                    strProMain += "<tr><td rowspan='2' width='77'><a href='?menu=dpda&id=" + id + "'><img class='img2' src='" + url + "'/></a></td>";
                    strProMain += "<td class='txt2'><a href='?menu=dpda&id=" + id + "'>" + name + "</a></td></tr>";
                    strProMain += "<tr><td>" + tbrand + ": <span class='txt4'>" + brand + "</span><br />" + tprice + ": <span class='txt4'>" + price + " " + unitPrice + "</span><br />" + twarranty + ": <span class='txt4'>" + warranty + " " + tmonth + "</span>";
                    //if (table.Rows[i]["promotion"].ToString().Length > 0)
                    //{
                    //    strProMain += "<br /><img src='image/common/khuyenmai.gif' style='cursor:pointer;' onmouseover='showDivMessage(2," + id + "," + i + ",event);' onmouseout='OnMOut(event)'/>";
                    //}
                    strProMain += "</td></tr>";
                    strProMain += "</table></td>";
                    strProMain += "<td>"+ note +"</td></tr>";
                    if (i < num - 1)
                    {
                        strProMain += "<tr><td colspan='2' class='line1'></td></tr>";
                    }
                }
                strProMain += "</table>";
            }
        }
        catch
        { 
            
        }
        return strProMain;
    }
}
