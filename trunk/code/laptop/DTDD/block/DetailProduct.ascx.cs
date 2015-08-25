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
public partial class block_DetailProduct : System.Web.UI.UserControl
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
    public string tcompare = "";
    public string ttechnology = "";
    public string tcurrentAccess = "";
    public string strpro = "";
    public string strspec = "";
    public string strlist = "";
    public string tlistpro = "";
    public string unitPrice = "USD";
    public string tnothave = "";
    public string tdes = "";
    public string ttimestart = "Bắt đầu";
    public string ttimeend = "Kết thúc";
    //public string strad = "";
    public string tnview = "";
    public string tupdate = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        int id=0;
        try
        {
            id = int.Parse(Request.QueryString["id"].ToString());
        }
        catch{
            Response.Redirect("Default.aspx?menu=home");
        }
        try
        {
            unitPrice = Application["currencymobile"].ToString();
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            bldetail = hash["detail"].ToString();
            thome = hash["home"].ToString();
            tpro = hash["promobi"].ToString();
            tname = hash["name"].ToString();
            tbrand = hash["brand"].ToString();
            tprice = hash["tprice"].ToString();
            twarranty = hash["twarranty"].ToString();
            tnview = hash["tnview"].ToString();
            twhere = hash["warehouse"].ToString();
            tstate = hash["state"].ToString();
            tnothave = hash["outstore"].ToString();
            tmonth = hash["tmonth"].ToString();
            torder = hash["torder"].ToString();
            tback = hash["bback"].ToString();
            tcompare = hash["bcompare"].ToString();
            tdes=hash["des"].ToString();
            ttechnology = hash["specification"].ToString();
            tcurrentAccess = hash["currentpage"].ToString();
            tlistpro = hash["similar"].ToString();
            tupdate = hash["tupdate"].ToString();
            tcurrentAccess = tcurrentAccess + ": <a href='?menu=home'>" + thome + "</a> &raquo; <a href='?menu=product'>" + tpro + "</a> &raquo; ";
        }catch{}
        try
        {
            DataSet ds = new ProductSystem().GetDetailProductTypeNew(id, (int)Application["idtypemobile"]);
            GetDetailProduct(ds.Tables[0], ds.Tables[1], ds.Tables[4],ds.Tables[7]);
            if (strpro.Length > 0)
            {
                GetSpecification(ds.Tables[2], ds.Tables[3]);
                GetGroupProduct(ds.Tables[5]);
                //strad=GetAdvertise(ds.Tables[6]);
            }
            else
            {
                Response.Redirect("Default.aspx?menu=home");
            }
        }
        catch 
        {
            Response.Redirect("Default.aspx?menu=home");
        }
    }
    public void GetDetailProduct(DataTable table,DataTable add,DataTable promotion,DataTable viewpro)
    {
        try
        {
            if (table.Rows.Count > 0)
            {
                string strid = table.Rows[0]["Id"].ToString();
                string strname = table.Rows[0]["Name"].ToString() + " " + table.Rows[0]["state"].ToString();
                string strurl = table.Rows[0]["UrlImage"].ToString();
                if (strurl.Length > 0)
                {
                    strurl = "image/img_pro/" + strurl;
                }
                else
                {
                    strurl = "image/common/notimgpro.png";
                }
                float rate = (float)Application["ratepromobi"];
                float price1 = 1;
                //string strprice = table.Rows[0]["SellingPrice"].ToString();
                price1 = float.Parse(table.Rows[0]["SellingPrice"].ToString());
                price1 = price1 * rate;
                string strprice = price1.ToString("N").Split('.')[0];
                string strwarranty = table.Rows[0]["WarrantyMonth"].ToString();
                string strBrand = table.Rows[0]["Brand"].ToString();
                string stridbrand = table.Rows[0]["idbrand"].ToString();
                string strnote = table.Rows[0]["Note"].ToString();
                string strdes = table.Rows[0]["des"].ToString();
                string isspec = table.Rows[0]["Isspec"].ToString(); ;
                tcurrentAccess += "<a href='?menu=pro&brand=" + stridbrand + "'>" + strBrand + "</a> &raquo; " + strname;
                if (isspec.Equals("1"))
                {
                    strpro = "<table width='100%' cellpadding='0' cellspacing='0' border='0' class='cl1'>";
                }
                else
                {
                    strpro = "<table width='100%' cellpadding='0' cellspacing='0' border='0'>";
                }
                strpro += "<tr><td colspan='2' height='5'></td></tr><tr>";
                strpro += "<td valign='top' width='160'><img width='150' height='200' src='" + strurl + "'/></td>";
                strpro += "<td valign='top'><table border='0' width='100%' cellpadding='0' cellspacing='0'>";
                strpro += "<tr><td width='70'>" + tname + ":</td><td width='270' class='text_title'>" + strname + "</td></tr>";
                strpro += "<tr><td colspan='2' class='line1'></td></tr>";
                strpro += "<tr><td>" + tbrand + ":</td><td class='txt4'>" + strBrand + "</td></tr>";
                strpro += "<tr><td colspan='2' class='line1'></td></tr>";
                if (strprice.Equals("0"))
                {
                    strpro += "<tr><td>" + tprice + ":</td><td class='txt4'>" + tupdate + "</td></tr>";
                }
                else
                {
                    strpro += "<tr><td>" + tprice + ":</td><td class='txt4'>" + strprice + " " + unitPrice + "</td></tr>";
                }
                strpro += "<tr><td colspan='2' class='line1'></td></tr>";
                strpro += "<tr><td>" + twarranty + ":</td><td class='txt4'>" + strwarranty + " " + tmonth + "</td></tr>";
                strpro += "<tr><td colspan='2' class='line1'></td></tr>";
                if (viewpro.Rows.Count > 0)
                {
                    try
                    {
                        DateTime time = new DateTime();
                        time = (DateTime)viewpro.Rows[0]["date"];
                        strpro += "<tr><td>" + tnview + ":</td><td><span style='color:red'>" + viewpro.Rows[0]["view"].ToString() + "</span> (" + time.ToString("dd/MM/yyyy") + ")</td></tr>";
                        strpro += "<tr><td colspan='2' class='line1'></td></tr>";
                    }
                    catch
                    { }

                }
                int numAdress = add.Rows.Count;
                if (numAdress > 0)
                {
                    string strAdd = "";
                    string DisContinued = "";
                    DateTime time = new DateTime();
                    for (int i = 0; i < numAdress; i++)
                    {
                        int idstate = int.Parse(add.Rows[i]["id"].ToString());
                        if (idstate <= 5)
                        {
                            strAdd += "&raquo; " + add.Rows[i]["address"].ToString() + " (Đang có hàng)<br />";
                        }
                        else
                        {
                            time = DateTime.Now.ToUniversalTime();
                            time = time.AddHours(7);
                            if(idstate==6)
                            {
                                time = time.AddHours(24);
                            }
                            else if (idstate == 7)
                            {
                                time = time.AddHours(24);
                            }
                            else if (idstate == 8)
                            {
                                time = time.AddHours(48);
                            }
                            else if (idstate == 9)
                            {
                                DisContinued = add.Rows[i]["DisContinued"].ToString();
                                if (DisContinued.Equals("7"))
                                {
                                    time = (DateTime)add.Rows[i]["FirstImportDate"];
                                    strAdd += "&raquo; " + add.Rows[i]["address"].ToString() + " (Đợt hàng mới sẽ có ngày <font color='red'>" + time.ToString("dd/MM/yy") + "</font>)<br />";
                                    continue;
                                }else
                                {
                                    time = time.AddHours(72);
                                }
                            }
                            else
                            {
                                continue;
                            }
                            strAdd += "&raquo; " + add.Rows[i]["address"].ToString() + " (Sẽ có thêm hàng ngày <font color='red'>" + time.ToString("dd/MM/yy") + "</font>)<br />";
                        }
                    }
                    strpro += "<tr><td class='price1'>" + twhere + ":</td><td class='text_title'>" + strAdd + "</td></tr>";
                }
                else
                {
                    strpro += "<tr><td>" + tstate + ":</td><td class='text_title'>" + tnothave + "</td></tr>";
                }
                strpro += "<tr><td colspan='2' class='line1'></td></tr>";
                strpro += "<tr><td colspan='2' height='30' align='center'><input type='button' class='bt3' value='" + tback + "' onclick='back();'/> <input type='button' class='bt2' value='" + tcompare + "' onclick='gocomp(" + strid + ")'/> <input type='button' class='bt2' value='" + torder + "' onclick='AddCart(" + strid + ",1);'/></td></tr>";
                strpro += "<tr><td colspan='2' class='line1'></td></tr>";
                strpro += "<tr><td height='4' colspan='2'></td></tr></table></td>";
                strpro += "</tr></table>";
                if (promotion.Rows.Count > 0)
                {
                    strpro += "<table border='0' cellpadding='0' cellspacing='0' width='100%'>";
                    strpro += "<tr><td class='text_title' align='center'>" + promotion.Rows[0]["Name"].ToString() + "</td></tr>";
                    strpro += "<tr><td class='qshow'>";
                    try
                    {
                        DateTime time = (DateTime)promotion.Rows[0]["StartDate"];
                        strpro += "Từ ngày(Start): <span class='txt4'>" + time.ToString("dd/MM/yyyy") + "</span>";
                        time = (DateTime)promotion.Rows[0]["EndDate"];
                        strpro += ", Đến ngày(End): <span class='txt4'>" + time.ToString("dd/MM/yyyy") + "</span><br />";
                    }
                    catch
                    { }
                    strpro += promotion.Rows[0]["Note"].ToString() + "</td></tr>";
                    strpro += "<tr><td height='7'></td></tr>";
                    strpro += "</table>";
                }
                if (strnote.Length > 0)
                {
                    strpro += "<div class='title_1'>"+ tdes +"</div>";
                    strpro += "<div class='tdes'>" + strnote + "<br />" + strdes + "</div><br />";
                }

            }
        }
        catch { }
    }
    public void GetSpecification(DataTable table,DataTable property)
    {
        try
        {
            int numCom = table.Rows.Count;
            int numproperty = property.Rows.Count;
            if ((numCom > 0)||(numproperty>0))
            {
                strspec += "<div class='title_1'>" + ttechnology + "</div>";
                strspec += "<table border='1' cellpadding='1' cellspacing='0' bordercolor='#E5E5E5' style='border-collapse:collapse;' width='100%'>";
                string idtype = table.Rows[0]["componenttypeid"].ToString();
                strspec += "<tr class='bgttr1'><td class='td1'>" + table.Rows[0]["name"].ToString() + "</td>";
                strspec += "<td>" + table.Rows[0]["component"].ToString() + "</td></tr>";
                for (int i = 0; i < numCom; i++)
                {

                    if (idtype.Equals(table.Rows[i]["componenttypeid"].ToString()))
                    {
                        if (table.Rows[i]["propertyvalue"].ToString().Length > 0)
                        {
                            strspec += "<tr class='bgttr2'><td class='td2'>" + table.Rows[i]["property"].ToString() + "</td>";
                            strspec += "<td>" + table.Rows[i]["propertyvalue"].ToString() + " " + table.Rows[i]["unit"].ToString() + "</td></tr>";
                        }
                    }
                    else
                    {
                        idtype = table.Rows[i]["componenttypeid"].ToString();
                        strspec += "<tr class='bgttr1'><td class='td1'>" + table.Rows[i]["name"].ToString() + "</td>";
                        strspec += "<td>" + table.Rows[i]["component"].ToString() + "</td></tr>";
                        if (table.Rows[i]["propertyvalue"].ToString().Length > 0)
                        {
                            strspec += "<tr class='bgttr2'><td class='td2'>" + table.Rows[i]["property"].ToString() + "</td>";
                            strspec += "<td>" + table.Rows[i]["propertyvalue"].ToString() + " " + table.Rows[i]["unit"].ToString() + "</td></tr>";
                        }
                    }
                }
                strspec += "<tr class='bgttr1'><td class='td1'>Các thông tin khác</td>";
                strspec += "<td></td></tr>";
                for (int i = 0; i < numproperty; i++)
                {
                    if (property.Rows[i]["PropertyValue"].ToString().Length > 0)
                    {
                        strspec += "<tr class='bgttr2'><td class='td2'>" + property.Rows[i]["Name"].ToString() + "</td>";
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
            float rate = (float)Application["ratepromobi"];
            float price1 = 1;
            string madein = "";
            string isspec = "";
            for (int i = 0; i < numPro; i++)
            {
                id = table.Rows[i]["Id"].ToString();
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
                //price = table.Rows[i]["SellingPrice"].ToString();
                price1 = float.Parse(table.Rows[i]["SellingPrice"].ToString());
                price1 = price1 * rate;
                price = price1.ToString("N").Split('.')[0];
                warranty = table.Rows[i]["WarrantyMonth"].ToString();
                madein = table.Rows[i]["ShortNote"].ToString();
                isspec = table.Rows[i]["Isspec"].ToString();
                if (iseven)
                {
                    if (isspec.Equals("1"))
                    {
                        strProMain += "<tr><td width='278' class='cl1'>";
                    }
                    else
                    {
                        strProMain += "<tr><td width='278'>";
                    }
                    strProMain += "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
                    strProMain += "<tr><td rowspan='2' width='95' align='center' valign='top'>";
                    strProMain += "<a href='?menu=dp&id=" + id + "'><img class='img2' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)' src='" + url + "'/></a></td>";
                    strProMain += "<td valign='top' class='txt2'><a href='?menu=dp&id=" + id + "' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)'>" + name + "</a></td></tr>";
                    strProMain += "<tr><td valign='top' width='190'>" + tprice + ": <span class='txt4'>";
                    if (price.Equals("0"))
                    {
                        strProMain += tupdate + "</span><br />";
                    }
                    else
                    {
                        strProMain += price + " " + unitPrice + "</span><br />";
                    }
                    strProMain += twarranty + ": <span class='txt4'>" + warranty + " " + tmonth + "</span>";
                    if (table.Rows[i]["promotion"].ToString().Length > 0)
                    {
                        strProMain += "<br /><img src='image/common/khuyenmai.gif' style='cursor:pointer;' onmouseover='showDivMessage(2," + id + "," + i + ",event);' onmouseout='OnMOut(event)'/>";
                    }
                    strProMain += "</td></tr>";
                    //strProMain += "<tr><td colspan='2' height='32' align='center'><div class='button3' onclick='AddCart(" + id + ",1);'>" + torder + "</div></td></tr>";
                    strProMain += "</table></td>";
                    strProMain += "<td class='line2'></td>";
                    iseven = false;
                    if (i + 1 == numPro)
                    {
                        strProMain += "<td width='278'>&nbsp;</td>";
                        strProMain += "</tr>";
                    }
                }
                else
                {
                    if (isspec.Equals("1"))
                    {
                        strProMain += "<td width='278' class='cl1'>";
                    }
                    else
                    {
                        strProMain += "<td width='278'>";
                    }
                    strProMain += "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
                    strProMain += "<tr><td rowspan='2' width='95' align='center' valign='top'>";
                    strProMain += "<a href='?menu=dp&id=" + id + "'><img class='img2' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)' src='" + url + "'/></a></td>";
                    strProMain += "<td valign='top' class='txt2'><a href='?menu=dp&id=" + id + "' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)'>" + name + "</a></td></tr>";
                    strProMain += "<tr><td valign='top' width='190'>" + tprice + ": <span class='txt4'>";
                    if (price.Equals("0"))
                    {
                        strProMain += tupdate + "</span><br />";
                    }
                    else
                    {
                        strProMain += price + " " + unitPrice + "</span><br />";
                    }
                    strProMain += twarranty + ": <span class='txt4'>" + warranty + " " + tmonth + "</span>";
                    if (table.Rows[i]["promotion"].ToString().Length > 0)
                    {
                        strProMain += "<br /><img src='image/common/khuyenmai.gif' style='cursor:pointer;' onmouseover='showDivMessage(2," + id + "," + i + ",event);' onmouseout='OnMOut(event)'/>";
                    }
                    strProMain += "</td></tr>";
                    //strProMain += "<tr><td colspan='2' height='32' align='center'><div class='button3' onclick='AddCart(" + id + ",1);'>" + torder + "</div></td></tr>";
                    strProMain += "</table></td></tr>";
                    if (i + 1 < numPro)
                    {
                        strProMain += "<tr><td class='line1'></td><td></td><td class='line1'></td></tr>";
                    }
                    iseven = true;
                }
            }
            strProMain += "</table>";
            strlist += strProMain;
        }
    }
    public string GetAdvertise(DataTable advertise)
    {
        string show = "";
        try
        {
            if (advertise.Rows.Count > 0)
            {
                string img2 = advertise.Rows[0]["UrlImage2"].ToString();
                if (img2.Length > 0)
                {
                    string[] extension = img2.Split('.');
                    if (extension[1].Equals("swf"))
                    {
                        show = "<object height='116' width='470'><embed src='image/advertise/" + img2 + "' width='470' height='116' type='application/x-shockwave-flash' pluginspage='http://www.macromedia.com/go/getflashplayer'></embed></object>";
                    }
                    else
                    {
                        show = "<a href='" + advertise.Rows[0]["link"].ToString() + "'><img src='image/advertise/" + img2 + "' width='470' height='116' border='0'/></a>";
                    }
                }
            }
        }
        catch
        {
            show = "";
        }
        return show;
    }
}
