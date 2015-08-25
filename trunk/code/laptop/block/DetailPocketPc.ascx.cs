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
public partial class block_DetailPocketPc : System.Web.UI.UserControl
{
    public string bldetail = "";
    public string thome = "";
    public string tpro = "";
    public string tname = "";
    public string tprice = "";
    public string twarranty = "";
    public string twhere = "";
    public string tbrand = "";
    public string torder = "";
    public string tmonth = "";
    public string tstate = "";
    public string tback = "";
    public string ttechnology = "";
    public string tcurrentAccess = "";
    public string strpro = "";
    public string strspec = "";
    public string strlist = "";
    public string tlistpro = "";
    public string tnothave = "";
    public string tdes = "";
    private string unitPrice = "USD";
    public string tupdate = "";
    private string strMVAT = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        try
        {
            id = int.Parse(Request.QueryString["id"].ToString());
        }
        catch
        {
            Response.Redirect("Default.aspx?menu=pda");
        }
        try
        {
            unitPrice = Application["currency"].ToString();
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            bldetail = hash["detail"].ToString();
            thome = hash["home"].ToString();
            tpro = hash["pocketpc"].ToString();
            tname = hash["name"].ToString();
            tbrand = hash["brand"].ToString();
            tprice = hash["tprice"].ToString();
            twarranty = hash["twarranty"].ToString();
            twhere = hash["warehouse"].ToString();
            tstate = hash["state"].ToString();
            tnothave = hash["outstore"].ToString();
            tmonth = hash["tmonth"].ToString();
            torder = hash["torder"].ToString();
            tback = hash["bback"].ToString();
            tdes = hash["des"].ToString();
            ttechnology = hash["specification"].ToString();
            tcurrentAccess = hash["currentpage"].ToString();
            tlistpro = hash["similar"].ToString();

            tupdate = hash["tupdate"].ToString();
            strMVAT = hash["msvat"].ToString();
            tcurrentAccess = tcurrentAccess + ": <a href='Default.aspx?menu=home'>" + thome + "</a> &raquo; <a href='Default.aspx?menu=pda'>" + tpro + "</a> &raquo; ";
        }
        catch { }
        try
        {
            DataSet ds = new ProductSystem().ProductDetailTypeAll(id, (int)Application["apppda"]);
            GetDetailProduct(ds.Tables[0], ds.Tables[1], ds.Tables[4]);
            if (strpro.Length > 0)
            {
                GetSpecification(ds.Tables[2], ds.Tables[3]);
                GetGroupProduct(ds.Tables[5]);
            }
            else
            {
                Response.Redirect("Default.aspx?menu=pda");
            }
        }
        catch
        {
            Response.Redirect("Default.aspx?menu=pda");
        }
    }
    public void GetDetailProduct(DataTable table, DataTable add, DataTable promotion)
    {
        try
        {
            if (table.Rows.Count > 0)
            {
                string strid = table.Rows[0]["Id"].ToString();
                string strname = table.Rows[0]["Name"].ToString();
                strname = strname.Replace("\"","'");
                string strurl = table.Rows[0]["UrlImage"].ToString();
                if (strurl.Length > 0)
                {
                    strurl = "image/img_pro/" + strurl;
                }
                else
                {
                    strurl = "image/common/notimgpro.png";
                }
                float rate = (float)Application["ratepromain"];
                float price1 = 1;
                string price2 = table.Rows[0]["SellingPrice"].ToString();
                price1 = float.Parse(table.Rows[0]["SellingPrice"].ToString());
                price1 = price1 * rate;
                string strprice = price1.ToString("N").Split('.')[0];
                string strwarranty = table.Rows[0]["WarrantyMonth"].ToString();
                string strBrand = table.Rows[0]["Brand"].ToString();
                string stridbrand = table.Rows[0]["idbrand"].ToString();
                string strnote = table.Rows[0]["Note"].ToString();
                tcurrentAccess += strname;
                strpro = "<table width='100%' cellpadding='0' cellspacing='0' border='0'>";
                strpro += "<tr><td colspan='3' height='5'></td></tr><tr>";
                strpro += "<td valign='top' width='160'><img width='155' height='132' src='" + strurl + "'/></td>";
                strpro += "<td valign='top'><table border='0' width='100%' cellpadding='0' cellspacing='0'>";
                strpro += "<tr><td width='80'>" + tname + ":</td><td class='text_title' width='227'>" + strname + "</td></tr>";
                //strpro += "<td align='center' rowspan='7'><div class='button3' onclick='back();'>" + tback + "</div><div class='button3' onclick='AddCart(" + strid + ",3);'>" + torder + "</div></td></tr>";
                strpro += "<tr><td colspan='2' class='bg_line2'></td></tr>";
                strpro += "<tr><td>" + tbrand + ":</td><td class='price'>" + strBrand + "</td></tr>";
                strpro += "<tr><td colspan='2' class='bg_line2'></td></tr>";


                if (strprice.Equals("0"))
                {
                    strpro += "<tr><td>" + tprice + ":</td><td class='price'>" + tupdate + "</td></tr>";
                }
                else
                {
                    if (unitPrice.Equals("$"))
                    {
                        strpro += "<tr><td>" + tprice + ":</td><td class='price'>" + strprice + " VND (" + price2 + ") <span class='tvat'>" + strMVAT + "</span></td></tr>";
                    }
                    else if (unitPrice.Equals("$$"))
                    {
                        strpro += "<tr><td>" + tprice + ":</td><td class='price'>" + strprice + " VND (" + price2 + " USD) <span class='tvat'>" + strMVAT + "</span></td></tr>";
                    }
                    else
                    {
                        strpro += "<tr><td>" + tprice + ":</td><td class='price'>" + strprice + " " + unitPrice + " <span class='tvat'>" + strMVAT + "</span></td></tr>";
                    }
                }
                
                
                strpro += "<tr><td colspan='2' class='bg_line2'></td></tr>";
                strpro += "<tr><td>" + twarranty + ":</td><td class='price'>" + strwarranty + " " + tmonth + "</td></tr>";
                strpro += "<tr><td colspan='2' class='bg_line2'></td></tr>";
                int numAdress = add.Rows.Count;
                if (numAdress > 0)
                {
                    string strAdd = "";
                    for (int i = 0; i < numAdress; i++)
                    {
                        strAdd += "- " + add.Rows[i]["address"].ToString() + "<br />";
                    }
                    strpro += "<tr><td class='price1'>" + twhere + ":</td><td class='text_2'>" + strAdd + "</td></tr>";
                }
                else
                {
                    strpro += "<tr><td>" + tstate + ":</td><td class='price'>" + tnothave + "</td></tr>";
                }
                strpro += "<tr><td colspan='2' class='bg_line2'></td></tr>";
                strpro += "<tr><td height='4'></td></tr></table></td>";
                strpro += "</tr></table>";
                if (promotion.Rows.Count > 0)
                {
                    strpro += "<table border='0' cellpadding='0' cellspacing='0' width='100%'>";
                    strpro += "<tr><td colspan='2' class='text_title' align='center'>" + promotion.Rows[0]["Name"].ToString() + "</td></tr>";
                    strpro += "<tr><td class='qshow'>";
                    try
                    {
                        DateTime time = (DateTime)promotion.Rows[0]["StartDate"];
                        strpro += "Bắt đầu: <span class='price'>" + time.ToString("dd/MM/yyyy") + "</span>";
                        time = (DateTime)promotion.Rows[0]["EndDate"];
                        strpro += ", Kết thúc: <span class='price'>" + time.ToString("dd/MM/yyyy") + "</span><br />";
                    }
                    catch
                    { }
                    strpro += promotion.Rows[0]["Note"].ToString() + "</td></tr>";
                    strpro += "</table>";
                }
                if (strnote.Length > 0)
                {
                    strpro += "<div class='title_1'>" + tdes + "</div>";
                    strpro += "<div class='tdes'>" + strnote + "</div>";
                }
            }
        }
        catch { }
    }
    public void GetSpecification(DataTable table, DataTable property)
    {
        try
        {
            int numCom = table.Rows.Count;
            int numproperty = property.Rows.Count;
            if ((numCom > 0) || (numproperty > 0))
            {
                strspec = "<table border='0' cellpadding='0' cellspacing='0' width='100%'>";
                strspec += "<tr><td colspan='2' height='4'></td></tr>";
                strspec += "<tr><td colspan='2' class='title_1'>" + ttechnology + "</td></tr>";
                strspec += "<tr><td width='155' height='5'></td><td></td></tr>";
                bool isround = true;
                for (int i = 0; i < numCom; i++)
                {
                    if (isround)
                    {
                        isround = false;
                        strspec += "<tr class='bgtr1'><td class='td1'>" + table.Rows[i]["name"].ToString() + "</td>";
                        strspec += "<td>" + table.Rows[i]["detail"].ToString() + "</td></tr>";
                    }
                    else
                    {
                        isround = true;
                        strspec += "<tr class='bgtr2'><td class='td1'>" + table.Rows[i]["name"].ToString() + "</td>";
                        strspec += "<td>" + table.Rows[i]["detail"].ToString() + "</td></tr>";
                    }
                }
                for (int i = 0; i < numproperty; i++)
                {
                    if (isround)
                    {
                        isround = false;
                        strspec += "<tr class='bgtr1'><td class='td1'>" + property.Rows[i]["Name"].ToString() + "</td>";
                        strspec += "<td>" + property.Rows[i]["PropertyValue"].ToString() + " " + property.Rows[i]["Unit"].ToString() + "</td></tr>";
                    }
                    else
                    {
                        isround = true;
                        strspec += "<tr class='bgtr2'><td class='td1'>" + property.Rows[i]["Name"].ToString() + "</td>";
                        strspec += "<td>" + property.Rows[i]["PropertyValue"].ToString() + " " + property.Rows[i]["Unit"].ToString() + "</td></tr>";
                    }
                }
                strspec += "</table>";
            }
        }
        catch { }
    }
    public void GetGroupProduct(DataTable table)
    {
        strlist += "<div class='title_1' style='padding-top:5px;'>" + tlistpro + "</div>";
        int numPro = table.Rows.Count;
        if (numPro > 0)
        {
            Boolean iseven = true;
            string strProMain = "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
            string id = "";
            string name = "";
            string url = "";
            string price = "";
            string warranty = "";
            float rate = (float)Application["ratepromain"];
            float price1 = 1;
            string price2 = "";
            for (int i = 0; i < numPro; i++)
            {
                id = table.Rows[i]["Id"].ToString();
                name = table.Rows[i]["Name"].ToString();
                url = table.Rows[i]["UrlImage"].ToString();
                if (url.Length > 0)
                {
                    url = "image/img_pro/" + url;
                }
                else
                {
                    url = "image/common/notimgpro.png";
                }
                //price = table.Rows[i]["SellingPrice"].ToString();
                price2 = table.Rows[i]["SellingPrice"].ToString();
                price1 = float.Parse(table.Rows[i]["SellingPrice"].ToString());
                price1 = price1 * rate;
                price = price1.ToString("N").Split('.')[0];
                warranty = table.Rows[i]["WarrantyMonth"].ToString();

                string namepro = table.Rows[i]["Name"].ToString();
                namepro = namepro.Replace("/", "");
                namepro = namepro.Replace("#", "");


                if (iseven)
                {
                    strProMain += "<tr><td width='272'>";
                    strProMain += "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
                    strProMain += "<tr><td rowspan='2' width='80' align='center'><a href='" + namepro + "-dpda-" + id + ".html'><img class='img1' src='" + url + "'/></a></td>";
                    strProMain += "<td valign='top' class='text_title'><a href='" + namepro + "-dpda-" + id + ".html' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)'>" + name + "</a></td></tr>";


                    strProMain += "<tr><td height='80'>" + tprice + ": <span class='price'>";

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
                    
                    
                    if (table.Rows[i]["promotion"].ToString().Length > 0)
                    {
                        strProMain += "<br /><img src='image/common/khuyenmai.gif' style='cursor:pointer;' onmouseover='showDivMessage(2," + id + "," + i + ",event);' onmouseout='OnMOut(event)'/>";
                    }
                    strProMain += "</td></tr>";
                    //strProMain += "<tr><td colspan='2' height='32' align='center'><div class='button3' onclick='AddCart(" + id + ",3);'>" + torder + "</div></td></tr>";
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
                    strProMain += "<tr><td rowspan='2' width='80' align='center'><a href='" + namepro + "-dpda-" + id + ".html'><img class='img1' src='" + url + "'/></a></td>";
                    strProMain += "<td valign='top' class='text_title'><a href='" + namepro + "-dpda-" + id + ".html' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)'>" + name + "</a></td></tr>";


                    strProMain += "<tr><td height='80'>" + tprice + ": <span class='price'>";

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
                    if (table.Rows[i]["promotion"].ToString().Length > 0)
                    {
                        strProMain += "<br /><img src='image/common/khuyenmai.gif' style='cursor:pointer;' onmouseover='showDivMessage(2," + id + "," + i + ",event);' onmouseout='OnMOut(event)'/>";
                    }
                    strProMain += "</td></tr>";
                    //strProMain += "<tr><td colspan='2' height='32' align='center'><div class='button3' onclick='AddCart(" + id + ",3);'>" + torder + "</div></td></tr>";
                    strProMain += "</table></td></tr>";
                    if (i + 1 < numPro)
                    {
                        strProMain += "<tr><td class='bg_line3'></td><td></td><td class='bg_line3'></td></tr>";
                    }
                    iseven = true;
                }
            }
            strProMain += "</table>";
            strlist += strProMain;
        }
    }
}
