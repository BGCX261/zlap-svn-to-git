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
public partial class block_OriginalPro : System.Web.UI.UserControl
{
    public string titlePage = "";
    public string torder = "";
    public string tprice = "";
    public string twarranty = "";
    public string tmonth = "";
    public string strProMain = "";
    public string currentAccess = "";
    public string thome = "";
    public string tpro = "";
    public string tjusthave = "";
    public string unitPrice = "USD";
    public string tupdate = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            unitPrice = Application["currency"].ToString();
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            titlePage = hash["bloriginal"].ToString();
            tprice = hash["tprice"].ToString();
            twarranty = hash["twarranty"].ToString();
            tmonth = hash["tmonth"].ToString();
            torder = hash["torder"].ToString();
            currentAccess = hash["currentpage"].ToString();
            thome = hash["home"].ToString();
            tpro = hash["product"].ToString();
            tjusthave = hash["loriginal"].ToString();
            tupdate = hash["tupdate"].ToString();
            currentAccess += ": <a href='?menu=home'>" + thome + "</a> &raquo; <a href='?menu=product'>" + tpro + "</a> &raquo; " + tjusthave;
            GetNewHaveAll();
        }
        catch (Exception ex)
        {
            Console.Write(ex.ToString());
        }
    }
    public void GetNewHaveAll()
    {
        try
        {
            DataSet ds = new ProductMainPageSystem().OriginalSelectTop();
            DataTable table = ds.Tables[0];
            int numPro = table.Rows.Count;
            titlePage = string.Format(titlePage, "<u>" + numPro + "</u>");
            if (numPro > 0)
            {
                Boolean iseven = true;
                strProMain = "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
                string id = "";
                string name = "";
                string url = "";
                string price = "";
                string warranty = "";
                float rate = (float)Application["ratepromain"];
                float price1 = 1;
                for (int i = 0; i < numPro; i++)
                {
                    id = table.Rows[i][ProductMainPage_data._id].ToString();
                    name = table.Rows[i][ProductMainPage_data._name].ToString() + " " + table.Rows[i][ProductMainPage_data._state].ToString();
                    url = table.Rows[i][ProductMainPage_data._urlImage].ToString();
                    if (url.Length > 0)
                    {
                        url = "image/img_pro/" + url;
                    }
                    else
                    {
                        url = "image/common/notimgpro.png";
                    }
                    //price = table.Rows[i][ProductMainPage_data._price].ToString();
                    price1 = float.Parse(table.Rows[i][ProductMainPage_data._price].ToString());
                    price1 = price1 * rate;
                    price = price1.ToString("N").Split('.')[0];
                    warranty = table.Rows[i][ProductMainPage_data._WarrantyMonth].ToString();
                    if (iseven)
                    {
                        strProMain += "<tr><td width='278'>";
                        strProMain += "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
                        strProMain += "<tr><td rowspan='2' width='88' align='center' valign='top'>";
                        if (table.Rows[i][ProductMainPage_data._ispromotion].ToString().Length > 0)
                        {
                            strProMain += "<img src='image/common/khuyenmai.gif' style='cursor:pointer;' onmouseover='showDivMessage(2," + id + "," + i + ",event);' onmouseout='OnMOut(event)'/><br />";
                        }
                        strProMain += "<a href='?menu=dp&id=" + id + "'><img class='img1' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)' src='" + url + "'/></a></td>";
                        strProMain += "<td class='text_title' valign='top'><a href='?menu=dp&id=" + id + "' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)'>" + name + "</a></td></tr>";
                        strProMain += "<tr><td valign='middle' width='190' height='48'>" + tprice + ": <span class='price'>";
                        if (price.Equals("0"))
                        {
                            strProMain += tupdate + "</span><br />";
                        }
                        else
                        {
                            strProMain += price + " " + unitPrice + "</span><br />";
                        }
                        strProMain += twarranty + ": <span class='price'>" + warranty + " " + tmonth + "</span>";
                        strProMain += "</td></tr>";
                        //strProMain += "<tr><td colspan='2' height='32' align='center'><div class='button3' onclick='AddCart(" + id + ",1);'>" + torder + "</div></td></tr>";
                        strProMain += "</table></td>";
                        strProMain += "<td class='bg_line4'></td>";
                        iseven = false;
                        if (i + 1 == numPro)
                        {
                            strProMain += "<td></td></tr>";
                        }
                    }
                    else
                    {
                        strProMain += "<td width='278'>";
                        strProMain += "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
                        strProMain += "<tr><td rowspan='2' width='88' align='center' valign='top'>";
                        if (table.Rows[i][ProductMainPage_data._ispromotion].ToString().Length > 0)
                        {
                            strProMain += "<img src='image/common/khuyenmai.gif' style='cursor:pointer;' onmouseover='showDivMessage(2," + id + "," + i + ",event);' onmouseout='OnMOut(event)'/><br />";
                        }
                        strProMain += "<a href='?menu=dp&id=" + id + "'><img class='img1' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)' src='" + url + "'/></a></td>";
                        strProMain += "<td class='text_title' valign='top'><a href='?menu=dp&id=" + id + "' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)'>" + name + "</a></td></tr>";
                        strProMain += "<tr><td valign='middle' width='190' height='48'>" + tprice + ": <span class='price'>";
                        if (price.Equals("0"))
                        {
                            strProMain += tupdate + "</span><br />";
                        }
                        else
                        {
                            strProMain += price + " " + unitPrice + "</span><br />";
                        }
                        strProMain += twarranty + ": <span class='price'>" + warranty + " " + tmonth + "</span>";
                        strProMain += "</td></tr>";
                        //strProMain += "<tr><td colspan='2' height='32' align='center'><div class='button3' onclick='AddCart(" + id + ",1);'>" + torder + "</div></td></tr>";
                        strProMain += "</table></td></tr>";
                        if (i + 1 < numPro)
                        {
                            strProMain += "<tr><td class='bg_line3'></td><td></td><td class='bg_line3'></td></tr>";
                        }
                        iseven = true;
                    }
                }
                strProMain += "</table>";
            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.ToString());
            strProMain = "";
        }
    }
}