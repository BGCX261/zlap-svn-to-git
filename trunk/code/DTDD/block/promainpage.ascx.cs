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
using common.list;
public partial class block_promainpage : System.Web.UI.UserControl
{
    public string titlePage = "";
    private string torder = "";
    private string tprice = "";
    private string twarranty = "";
    private string tmonth = "";
    public string strProMain = "";
    public string currentAccess = "";
    private string unitPrice = "USD";
    private string thavejust = "";
    public string strjusthave="";
    private string strSellOff = "";
    private string tselloff = "";
    private string desselloff = "";
    private string tbl_bestview = "";
    public string str_bestview = "";
    private string tnview = "";
    private string tupdate = "";
    private string blpocketpc = "";
    public string strListPocketpc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            unitPrice=Application["currencymobile"].ToString();
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            currentAccess = hash["mmainpage"].ToString();
            currentAccess =string.Format(currentAccess,Application["numvisited"].ToString());
            titlePage = hash["blmain"].ToString();
            tprice = hash["tprice"].ToString();
            twarranty = hash["twarranty"].ToString();
            tmonth = hash["tmonth"].ToString();
            torder = hash["torder"].ToString();
            thavejust = hash["tjusth"].ToString();
            tselloff = hash["blselloff"].ToString();
            desselloff = hash["mselloff"].ToString();
            tbl_bestview = hash["blbestv"].ToString();
            tnview = hash["tnview"].ToString();
            tupdate = hash["tupdate"].ToString();
            blpocketpc = hash["pocketpc"].ToString();
        }
        catch (Exception ex)
        {
            Console.Write(ex.ToString());
        }
        GetProductMainPage();
        //GetSellOff();
    }
    private void GetProductMainPage()
    {
        try
        {
            DataSet ds = new Mobilesystem().MobileMainpage();
            DataTable table = ds.Tables[0];
            int numPro = table.Rows.Count;
            if (numPro > 0)
            {
                GetJustHave(ds.Tables[1]);
                GetBestView(ds.Tables[2]);
                //currentAccess += GetListMessage(ds.Tables[3]);
                //currentAccess = "<marquee scrolldelay='120' width='580' onmouseout='start();' onmouseover='stop();'>" + currentAccess + ", " + currentAccess + "</marquee>";
                strProMain = "<table cellpadding='0' cellspacing='0' border='0' width='100%' bgcolor='#FFFFFF'>";
                strProMain += "<tr><td width='25%'></td><td width='25%'></td><td width='25%'></td><td width='25%'></td></tr>";
                string id="";
                string name="";
                string url="";
                string price="";
                string warranty="";
                float rate = (float)Application["ratepromain"];
                float price1 = 1;
                string madein = "";
                string isSpec = "";
                int count = 0;
                for (int i = 0; i < numPro; i++)
                {
                    count++;
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
                    price1 = float.Parse(table.Rows[i][ProductMainPage_data._price].ToString());
                    price1 = price1 * rate;
                    price = price1.ToString("N").Split('.')[0];
                    warranty = table.Rows[i][ProductMainPage_data._WarrantyMonth].ToString();
                    madein = table.Rows[i][ProductMainPage_data._shortnote].ToString();
                    isSpec = table.Rows[i][ProductMainPage_data._isspec].ToString();
                    if (count == 1)
                    {
                        strProMain += "<tr align='center' class='txt2' valign='top'>";
                    }
                    strProMain += "<td>";
                    strProMain += "<a href='?menu=dp&id=" + id + "'><img class='img1' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)' src='" + url + "'/></a><span class='txt5'>" + (i + 1) + "</span> <br />";
                    strProMain += "<span class='txt4'>";
                    if (price.Equals("0"))
                    {
                        strProMain += tupdate + "</span><br />";
                    }
                    else
                    {
                        strProMain += price + " " + unitPrice + "</span><br />";
                    }
                    //strProMain += twarranty + ": <span class='txt4'>" + warranty + " " + tmonth + "</span><br />";
                    strProMain += "<a href='?menu=dp&id=" + id + "' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)'>" + name + "</a><br />";
                    if (table.Rows[i][ProductMainPage_data._ispromotion].ToString().Length > 0)
                    {
                        strProMain += "<img src='image/common/khuyenmai.gif' style='cursor:pointer;' onmouseover='showDivMessage(2," + id + "," + i + ",event);' onmouseout='OnMOut(event)'/><br />";
                    }
                    strProMain += "</td>";
                    if (count == 4)
                    {
                        strProMain += "</tr>";
                        if (i + 1 < numPro)
                        {
                            strProMain += "<tr><td colspan='4' class='line1'></td></tr>";
                        }
                        count = 0;
                    }
                    else
                    {
                        if (i + 1 == numPro)
                        {
                            strProMain += "</tr>";
                        }
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
    private void GetJustHave(DataTable table)
    {
        string strProMain = "";
        try
        {
            int numPro = table.Rows.Count;
            if (numPro > 0)
            {
                Boolean iseven = true;
                strProMain = "<table cellpadding='0' cellspacing='0' border='0' width='100%' bgcolor='#FFFFFF'>";
                strProMain += "<tr><td width='25%'></td><td width='25%'></td><td width='25%'></td><td width='25%'></td></tr>";
                string id = "";
                string name = "";
                string url = "";
                string price = "";
                string warranty = "";
                float rate = (float)Application["ratepromain"];
                float price1 = 1;
                string madein = "";
                string isSpec = "";
                int count = 0;
                for (int i = 0; i < numPro; i++)
                {
                    count++;
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
                    price1 = float.Parse(table.Rows[i][ProductMainPage_data._price].ToString());
                    price1 = price1 * rate;
                    price = price1.ToString("N").Split('.')[0];
                    warranty = table.Rows[i][ProductMainPage_data._WarrantyMonth].ToString();
                    madein = table.Rows[i][ProductMainPage_data._shortnote].ToString();
                    isSpec = table.Rows[i][ProductMainPage_data._isspec].ToString();
                    if (count == 1)
                    {
                        strProMain += "<tr align='center' class='txt2' valign='top'>";
                    }
                    strProMain += "<td>";
                    strProMain += "<a href='?menu=dp&id=" + id + "'><img class='img1' onmouseover='showDivMessage(1," + id + "," + (i + 40) + ",event);' onmouseout='OnMOut(event)' src='" + url + "'/></a><span class='txt5'>" + (i + 1) + "</span> <br />";
                    strProMain += "<span class='txt4'>";
                    if (price.Equals("0"))
                    {
                        strProMain += tupdate + "</span><br />";
                    }
                    else
                    {
                        strProMain += price + " " + unitPrice + "</span><br />";
                    }
                    //strProMain += twarranty + ": <span class='txt4'>" + warranty + " " + tmonth + "</span><br />";
                    strProMain += "<a href='?menu=dp&id=" + id + "' onmouseover='showDivMessage(1," + id + "," + (i + 40) + ",event);' onmouseout='OnMOut(event)'>" + name + "</a><br />";
                    if (table.Rows[i][ProductMainPage_data._ispromotion].ToString().Length > 0)
                    {
                        strProMain += "<img src='image/common/khuyenmai.gif' style='cursor:pointer;' onmouseover='showDivMessage(2," + id + "," + (i + 40) + ",event);' onmouseout='OnMOut(event)'/><br />";
                    }
                    strProMain += "</td>";
                    if (count == 4)
                    {
                        strProMain += "</tr>";
                        if (i + 1 < numPro)
                        {
                            strProMain += "<tr><td colspan='4' class='line1'></td></tr>";
                        }
                        count = 0;
                    }
                    else
                    {
                        if (i + 1 == numPro)
                        {
                            strProMain += "</tr>";
                        }
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
        if (strProMain.Length == 0)
        {
            return;
        }
        strjusthave = "<table width='100%' cellpadding='0' cellspacing='0' border='0'>";
        strjusthave += "<tr><td class='bgtl1'></td>";
        strjusthave += "<td class='bgtc1' width='544'>" + thavejust + "</td>";
        strjusthave += "<td class='bgtr1'></td></tr>";
        strjusthave += "<tr><td height='2'></td></tr>";
        strjusthave += "<tr><td colspan='3' class='bgcl2'>" + strProMain + "</td></tr>";
        strjusthave += "<tr><td height='10'></td></tr></table>";
    }
    private void GetSellOff()
    {
        string str = "";
        try
        {

            DataSet ds = new ProductBestSellSystem().ProductSelloffAll();
            DataTable table = ds.Tables[0];
            int numPro = table.Rows.Count;
            if (numPro > 0)
            {
                Boolean iseven = true;
                str = "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
                if (desselloff.Length > 0)
                {
                    str += "<tr height='35'><td colspan='3' align='center' class='text_title'>" + desselloff + "</td></tr>";
                    str += "<tr><td colspan='3' class='line1'></td></tr>";
                }
                string id = "";
                string name = "";
                string url = "";
                string price = "";
                string oldprice = "";
                string warranty = "";
                for (int i = 0; i < numPro; i++)
                {
                    id = table.Rows[i]["idproduct"].ToString();
                    name = table.Rows[i]["Name"].ToString() + " " + table.Rows[i]["state"].ToString();
                    url = table.Rows[i]["UrlImage"].ToString();
                    if (url.Length > 0)
                    {
                        url = "image/img_pro/" + url;
                    }
                    else
                    {
                        url = "image/common/notimgpro.png";
                    }
                    price = table.Rows[i]["SellingPrice"].ToString();
                    oldprice = table.Rows[i]["price"].ToString();
                    warranty = table.Rows[i]["WarrantyMonth"].ToString();
                    if (iseven)
                    {
                        str += "<tr><td width='278'>";
                        str += "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
                        str += "<tr><td rowspan='2' width='88' align='center'>";
                        if (table.Rows[i]["promotion"].ToString().Length > 0)
                        {
                            str += "<img src='image/common/khuyenmai.gif' style='cursor:pointer;' onmouseover='showDivMessage(2," + id + ",-1,event);' onmouseout='OnMOut(event)'/><br />";
                        }
                        str += "<a href='?menu=dp&id=" + id + "'><img class='img2' onmouseover='showDivMessage(1," + id + "," + (i + 50) + ",event);' onmouseout='OnMOut(event)' src='" + url + "'/></a></td>";
                        str += "<td class='text_title' valign='top'><a href='?menu=dp&id=" + id + "' onmouseover='showDivMessage(1," + id + "," + (i + 50) + ",event);' onmouseout='OnMOut(event)'>" + name + "</a></td></tr>";
                        str += "<tr><td height='48'>" + tprice + ": ";
                        if (!oldprice.Equals("0"))
                        {
                            str += "<span style='text-decoration:line-through;'>" + oldprice + "</span> &raquo; ";
                        }
                        str += "<span class='txt4'>" + price + " " + unitPrice + "</span><br />" + twarranty + ": <span class='txt4'>" + warranty + " " + tmonth + "</span>";
                        str += "</td></tr>";
                        //str += "<tr><td colspan='2' height='32' align='center'><div class='button3' onclick='AddCart(" + id + ",1);'>" + torder + "</div></td></tr>";
                        str += "</table></td>";
                        str += "<td class='line2'></td>";
                        iseven = false;
                        if (i + 1 == numPro)
                        {
                            str += "<td width='278'>&nbsp;</td></tr>";
                        }
                    }
                    else
                    {
                        str += "<td width='278'>";
                        str += "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
                        str += "<tr><td rowspan='2' width='88' align='center'>";
                        if (table.Rows[i]["promotion"].ToString().Length > 0)
                        {
                            str += "<img src='image/common/khuyenmai.gif' style='cursor:pointer;' onmouseover='showDivMessage(2," + id + "," + (i + 50) + ",event);' onmouseout='OnMOut(event)'/><br />";
                        }
                        str += "<a href='?menu=dp&id=" + id + "'><img class='img2' onmouseover='showDivMessage(1," + id + "," + (i + 50) + ",event);' onmouseout='OnMOut(event)' src='" + url + "'/></a></td>";
                        str += "<td class='text_title' valign='top'><a href='?menu=dp&id=" + id + "' onmouseover='showDivMessage(1," + id + "," + (i+ 50) + ",event);' onmouseout='OnMOut(event)'>" + name + "</a></td></tr>";
                        str += "<tr><td height='48'>" + tprice + ": ";
                        if (!oldprice.Equals("0"))
                        {
                            str += "<span style='text-decoration:line-through;'>" + oldprice + "</span> &raquo; ";
                        }
                        str += "<span class='txt4'>" + price + " " + unitPrice + "</span><br />" + twarranty + ": <span class='txt4'>" + warranty + " " + tmonth + "</span>";
                        str += "</td></tr>";
                        //str += "<tr><td colspan='2' height='32' align='center'><div class='button3' onclick='AddCart(" + id + ",1);'>" + torder + "</div></td></tr>";
                        str += "</table></td></tr>";
                        if (i + 1 < numPro)
                        {
                            str += "<tr><td class='line1'></td><td></td><td class='line1'></td></tr>";
                        }
                        iseven = true;
                    }
                }
                str += "</table>";
            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.ToString());
            str = "";
        }
        if (str.Length == 0)
        {
            return;
        }
        strSellOff = "<table width='100%' cellpadding='0' cellspacing='0' border='0'>";
        strSellOff += "<tr><td class='bg_b1'></td>";
        strSellOff += "<td class='bg_b2'><div class='text_bl'>" + tselloff + "</div></td>";
        strSellOff += "<td class='bg_b3'></td></tr>";
        strSellOff += "<tr><td class='bg_b4'></td>";
        strSellOff += "<td valign='top'><div class='text_5'>" + str + "</div></td>";
        strSellOff += "<td class='bg_b5'></td>";
        strSellOff += "</tr><tr><td class='bg_b7' colspan='3'></td></tr><tr><td height='7'></td></tr></table>";
    }
    private void GetBestView(DataTable table)
    {
        string str = "";
        try
        {
            int numPro = table.Rows.Count;
            if (numPro > 0)
            {
                Boolean iseven = true;
                tbl_bestview = string.Format(tbl_bestview, "<u>" + numPro + "</u>");
                str = "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
                string id = "";
                string name = "";
                string url = "";
                string price = "";
                string numview = "";
                DateTime time = new DateTime();
                string warranty = "";
                float rate = (float)Application["ratepromain"];
                float price1 = 1;
                string madein = "";
                string isSpec = "";
                for (int i = 0; i < numPro; i++)
                {
                    id = table.Rows[i]["idpro"].ToString();
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
                    price1 = float.Parse(table.Rows[i]["SellingPrice"].ToString());
                    price1 = price1 * rate;
                    price = price1.ToString("N").Split('.')[0];
                    numview = table.Rows[i]["view"].ToString();
                    time = (DateTime)table.Rows[i]["date"];
                    warranty = table.Rows[i]["WarrantyMonth"].ToString();
                    madein = table.Rows[i]["ShortNote"].ToString();
                    isSpec = table.Rows[i]["isSpec"].ToString();
                    if (iseven)
                    {
                        if (isSpec.Equals("1"))
                        {
                            str += "<tr><td width='279' class='bgcl8'>";
                        }
                        else
                        {
                            str += "<tr><td width='279'>";
                        }
                        str += "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
                        str += "<tr><td rowspan='2' width='95' align='center'>";
                        str += "<a href='?menu=dp&id=" + id + "'><img class='img2' onmouseover='showDivMessage(1," + id + "," + (i + 80) + ",event);' onmouseout='OnMOut(event)' src='" + url + "'/></a></td>";
                        str += "<td class='txt2' colspan='2'><a href='?menu=dp&id=" + id + "' onmouseover='showDivMessage(1," + id + "," + (i + 80) + ",event);' onmouseout='OnMOut(event)'>" + name + "</a></td></tr>";
                        str += "<tr><td valign='top'>" + tnview + ": <span style='color:red;'>" + numview + "</span> (" + time.ToString("dd/MM/yyyy") + ")<br />";
                        if (price.Equals("0"))
                        {
                            str += tprice + ": <span class='txt4'>" + tupdate + "</span><br />";
                        }else
                        {
                            str += tprice + ": <span class='txt4'>" + price + " " + unitPrice + "</span><br />";
                        }
                        str += twarranty + ": <span class='txt4'>" + warranty + " " + tmonth + "</span><br />";
                        if (madein.Length > 0)
                        {
                            strProMain += "<span class='text_title'>" + madein + "</span><br />";
                        }
                        if (table.Rows[i]["promotion"].ToString().Length > 0)
                        {
                            str += "<img src='image/common/khuyenmai.gif' style='cursor:pointer;' onmouseover='showDivMessage(2," + id + ",-1,event);' onmouseout='OnMOut(event)'/><br />";
                        }
                        str += "</td></tr>";
                        //str += "<tr><td colspan='2' height='32' align='center'><div class='button3' onclick='AddCart(" + id + ",1);'>" + torder + "</div></td></tr>";
                        str += "</table></td>";
                        str += "<td class='line2'></td>";
                        iseven = false;
                        if (i + 1 == numPro)
                        {
                            str += "<td width='279'>&nbsp;</td></tr>";
                        }
                    }
                    else
                    {
                        if (isSpec.Equals("1"))
                        {
                            str += "<td width='279' class='bgcl8'>";
                        }
                        else
                        {
                            str += "<td width='279'>";
                        }
                        str += "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
                        str += "<tr><td rowspan='2' width='95' align='center'>";
                        str += "<a href='?menu=dp&id=" + id + "'><img class='img2' onmouseover='showDivMessage(1," + id + "," + (i + 80) + ",event);' onmouseout='OnMOut(event)' src='" + url + "'/></a></td>";
                        str += "<td class='txt2' colspan='2'><a href='?menu=dp&id=" + id + "' onmouseover='showDivMessage(1," + id + "," + (i + 80) + ",event);' onmouseout='OnMOut(event)'>" + name + "</a></td></tr>";
                        str += "<tr><td valign='top'>" + tnview + ": <span style='color:red;'>" + numview + "</span> (" + time.ToString("dd/MM/yyyy") + ")<br />";
                        if (price.Equals("0"))
                        {
                            str += tprice + ": <span class='txt4'>" + tupdate + "</span><br />";
                        }
                        else
                        {
                            str += tprice + ": <span class='txt4'>" + price + " " + unitPrice + "</span><br />";
                        }
                        str += twarranty + ": <span class='txt4'>" + warranty + " " + tmonth + "</span><br />";
                        if (madein.Length > 0)
                        {
                            strProMain += "<span class='text_title'>" + madein + "</span><br />";
                        }
                        if (table.Rows[i]["promotion"].ToString().Length > 0)
                        {
                            str += "<img src='image/common/khuyenmai.gif' style='cursor:pointer;' onmouseover='showDivMessage(2," + id + ",-1,event);' onmouseout='OnMOut(event)'/><br />";
                        }
                        str += "</td></tr>";
                        //str += "<tr><td colspan='2' height='32' align='center'><div class='button3' onclick='AddCart(" + id + ",1);'>" + torder + "</div></td></tr>";
                        str += "</table></td></tr>";
                        if (i + 1 < numPro)
                        {
                            str += "<tr><td class='line1'></td><td></td><td class='line1'></td></tr>";
                        }
                        iseven = true;
                    }
                }
                str += "</table>";
            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.ToString());
            str = "";
        }
        if (str.Length == 0)
        {
            return;
        }
        str_bestview = "<table width='100%' cellpadding='0' cellspacing='0' border='0'>";
        str_bestview += "<tr><td class='bgtl1'></td>";
        str_bestview += "<td class='bgtc1' width='544'>" + tbl_bestview + "</td>";
        str_bestview += "<td class='bgtr1'></td></tr>";
        str_bestview += "<tr><td height='2'></td></tr>";
        str_bestview += "<tr><td colspan='3' class='bgcl1'>" + str + "</td></tr>";
        str_bestview += "<tr><td height='10'></td></tr></table>";
    }
    private void GetmainpocketPc(DataTable table)
    {
        try
        {
            if (table.Rows.Count > 0)
            {
                int num = table.Rows.Count;
                if (num > 0)
                {
                    strListPocketpc = "<div class='divpda'><a href='?menu=pda'>" + blpocketpc + "</a></div>";
                    strListPocketpc += "<div class='td_border' style='background:#FFFFFF'>";
                    strListPocketpc += "<table border='0' cellpadding='0' cellspacing='0' align='center'><tr>";
                    string url = "";
                    string price = "";
                    float rate = (float)Application["ratepromain"];
                    float price1 = 1;
                    for (int i = 0; i < num; i++)
                    {
                        strListPocketpc += "<td class='text_title' align='center' width='120' valign='top'>";
                        url = table.Rows[i]["UrlImage"].ToString();
                        //price = table.Rows[i]["SellingPrice"].ToString();
                        price1 = float.Parse(table.Rows[i]["SellingPrice"].ToString());
                        price1 = price1 * rate;
                        price = price1.ToString("N").Split('.')[0];
                        if (price.Equals("0"))
                        {
                            price = tupdate;
                        }
                        else
                        {
                            //price += " " + table.Rows[i]["unit"].ToString();
                            price += " " + unitPrice;
                        }
                        if (url.Length == 0)
                        {
                            url = "image/common/notimgpro.png";
                        }
                        else
                        {
                            url = "image/img_pro/" + url;
                        }
                        strListPocketpc += "<a href='Default.aspx?menu=dpda&id=" + table.Rows[i]["idproduct"].ToString() + "'>";
                        strListPocketpc += "<img src='" + url + "' class='img2' border='0'/></a><br />";
                        strListPocketpc += tprice + ": <span class='txt4'>" + price + "</span><br />";
                        strListPocketpc += "<a href='Default.aspx?menu=dpda&id=" + table.Rows[i]["idproduct"].ToString() + "'>";
                        strListPocketpc += table.Rows[i]["name"].ToString() + "</a>";
                        strListPocketpc += "</td>";
                    }
                    strListPocketpc += "</tr></table>";
                }
            }
        }
        catch
        {
            strListPocketpc = "";
        }
    }
    private string GetListMessage(DataTable table)
    {
        string str = "";
        try
        {
            if (table.Rows.Count > 0)
            {
                int num = table.Rows.Count;
                str += "@@@";
                for (int i = 0; i < num-1; i++)
                {
                    str += " &raquo; <a href='" + table.Rows[i]["Link"].ToString() + "'>" + table.Rows[i]["Title"].ToString() + "</a>, ";
                }
                str += " &raquo; <a href='" + table.Rows[num - 1]["Link"].ToString() + "'>" + table.Rows[num - 1]["Title"].ToString() + "</a>";
            }
        }
        catch
        { }
        return str;
    }
}
