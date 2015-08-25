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
    public string torder = "";
    public string tpro = "";
    public string strProduct = "";
    public string tbrand = "";
    private string unitPrice = "USD";

    public string tupdate = "";
    private string strMVAT = "";
    ProductSystem Products = new ProductSystem();
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
            tpro = hash["pocketpc"].ToString();
            thome = hash["home"].ToString();
            tbrand = hash["brand"].ToString();

            tupdate = hash["tupdate"].ToString();
            strMVAT = hash["msvat"].ToString();

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
                string price = "0";
                string price2 = "";
                float rate = (float)Application["ratepromain"];
                float price1 = 1;
                string warranty = "";
                string note = "";
                string brand = "";
                strProMain = "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
                for(int i=0;i<num;i++)
                {
                    id = table.Rows[i]["Id"].ToString();
                    name = table.Rows[i]["Name"].ToString();
                    url = table.Rows[i]["UrlImage"].ToString();
                    note = table.Rows[i]["Note"].ToString();

                    string namepro = table.Rows[i]["Name"].ToString();
                    namepro = namepro.Replace("/", "");
                    namepro = namepro.Replace("#", "");

                    if (url.Length > 0)
                    {
                        url = "image/img_pro/" + url;
                    }
                    else
                    {
                        url = "image/common/notimgpro.png";
                    }

                    price2 = table.Rows[i]["SellingPrice"].ToString();
                    price1 = float.Parse(table.Rows[i]["SellingPrice"].ToString());
                    price1 = price1 * rate;
                    price = price1.ToString("N").Split('.')[0];

                    warranty = table.Rows[i]["WarrantyMonth"].ToString();
                    brand = table.Rows[i]["brand"].ToString();
                    strProMain += "<tr><td width='300'>";
                    strProMain += "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
                    strProMain += "<tr><td rowspan='2' width='77'><a href='" + namepro + "-dpda-" + id + ".html'><img class='img1' src='" + url + "'/></a></td>";
                    strProMain += "<td class='text_title'><a href='" + namepro + "-dpda-" + id + ".html'>" + name + "</a></td></tr>";
                    strProMain += "<tr><td height='110'>" + tbrand + ": <span class='price'>" + brand + "</span><br />";

                    strProMain += tprice + ": <span class='price'>";
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
                        strProMain += "<span class='tvat'>" + strMVAT + "</span><br />";
                    }
                    strProMain += twarranty + ": <span class='price'>" + warranty + " " + tmonth + "</span>";
                    if (table.Rows[i]["promotion"].ToString().Length > 0)
                    {
                        strProMain += "<br /><img src='image/common/khuyenmai.gif' style='cursor:pointer;' onmouseover='showDivMessage(2," + id + "," + i + ",event);' onmouseout='OnMOut(event)'/>";
                    }
                    strProMain += "</td></tr>";
                    //strProMain += "<tr><td colspan='2' align='center'><div class='button3' onclick='AddCart(" + id + ",3);'>" + torder + "</div></td></tr>";
                    strProMain += "</table></td>";
                    strProMain += "<td>"+ note +"</td></tr>";
                    if (i < num - 1)
                    {
                        strProMain += "<tr><td colspan='2' class='bg_line3'></td></tr>";
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
