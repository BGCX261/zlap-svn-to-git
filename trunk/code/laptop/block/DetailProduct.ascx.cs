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
    public string tnview = "";
    public string tupdate = "";
    private string strMVAT = "";
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
            unitPrice = Application["currency"].ToString();
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            bldetail = hash["detail"].ToString();
            thome = hash["home"].ToString();
            tpro = hash["product"].ToString();
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
            strMVAT = hash["msvat"].ToString();
            tcurrentAccess = tcurrentAccess + ": <a href='default.aspx?menu=home'>" + thome + "</a> &raquo; <a href='default.aspx?menu=product' onmouseover='OnMOMenu(0,1,11,event);' onmouseout='TimeHidden();'>" + tpro + "</a> &raquo; ";
        }catch{}
        try
        {
            DataSet ds = new ProductSystem().GetDetailProductTypeNew(id, (int)Application["idtypeproduct"]);
            GetDetailProduct(ds.Tables[0], ds.Tables[1], ds.Tables[4], ds.Tables[6], ds.Tables[7]);
            if (strpro.Length > 0)
            {
                GetSpecification(ds.Tables[2], ds.Tables[3]);
                GetGroupProduct(ds.Tables[5]);
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
    public void GetDetailProduct(DataTable table,DataTable add,DataTable promotion,DataTable viewpro,DataTable MultiImg)
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
                string strdes = table.Rows[0]["des"].ToString();
                string isspec = table.Rows[0]["Isspec"].ToString(); ;
                tcurrentAccess += "<a href='default.aspx?menu=pro&brand=" + stridbrand + "' onmouseover='OnMOMenu(" + stridbrand + ",0,10,event);' onmouseout='TimeHidden();'>" + strBrand + "</a> &raquo; " + strname;
                //strpro = "<div id='divVideo' class='dvideo' style='display:none;'><object width='335' height='360'><param name='movie' value='http://www.cnet.com/av/video/flv/newPlayers/universal.swf' /><param name='wmode' value='transparent' /><param name='allowFullScreen' value='true' /><param name='FlashVars' value='playerType=embedded&value=29433' /><embed src='http://www.cnet.com/av/video/flv/newPlayers/universal.swf' type='application/x-shockwave-flash' wmode='transparent' width='335' height='360' allowFullScreen='true' FlashVars='playerType=embedded&value=29433' /></object>";
                //strpro += "<div style='width:100px' class='text_title' onclick='Openvideo(0);'><a href='#'>Đóng lại</a></div></div>";
                if (isspec.Equals("1"))
                {
                    strpro += "<table width='100%' cellpadding='0' cellspacing='0' border='0' class='cl1'>";
                }
                else
                {
                    strpro += "<table width='100%' cellpadding='0' cellspacing='0' border='0'>";
                }
                string imgAd = "";
                string seeMore = "";
                string divseeMore = "";
                string listImg = "";
                if (MultiImg.Rows.Count > 0)
                {
                    imgAd = MultiImg.Rows[0]["img7"].ToString();
                    if (MultiImg.Rows[0]["img1"].ToString().Length > 0)
                    {
                        listImg += MultiImg.Rows[0]["img1"].ToString() + "@";
                    }
                    if (MultiImg.Rows[0]["img2"].ToString().Length > 0)
                    {
                        listImg += MultiImg.Rows[0]["img2"].ToString() + "@";
                    }
                    if (MultiImg.Rows[0]["img3"].ToString().Length > 0)
                    {
                        listImg += MultiImg.Rows[0]["img3"].ToString() + "@";
                    } 
                    if (MultiImg.Rows[0]["img4"].ToString().Length > 0)
                    {
                        listImg += MultiImg.Rows[0]["img4"].ToString() + "@";
                    }
                    if (MultiImg.Rows[0]["img5"].ToString().Length > 0)
                    {
                        listImg += MultiImg.Rows[0]["img5"].ToString() + "@";
                    }
                    if (listImg.Length > 0)
                    {
                        seeMore = "<div id='LinkShow' style='text-align:center;'><a href='#LinkShow' onclick='OpenDivMulti(1);'><img src='image/common/seemore.gif' border='0'/></a></div>";
                        divseeMore = "<div id='divShowMore' style='text-align:center;display:none'>";
                        divseeMore += "<object width='562' height='370'><embed src='image/common/ShowImg.swf?vl=" + listImg + "' wmode='transparent' type='application/x-shockwave-flash' pluginspage='http://www.macromedia.com/go/getflashplayer' width='562' height='370'></embed></object>";
                        divseeMore += "<div style='width:100px' class='text_title' onclick='OpenDivMulti(0);'><a href='#'>Đóng lại</a></div>";
                        divseeMore += "</div>";
                    }
                    //Test width file Img:
                    if (imgAd.Length > 0)
                    {
                        try
                        {
                            string path = Server.MapPath("image/multiimg/" + imgAd);
                            System.Drawing.Image CheckSize = System.Drawing.Image.FromFile(path);
                            if (CheckSize != null)
                            {
                                if (CheckSize.PhysicalDimension.Width > 562)
                                {
                                    imgAd = "<img src='image/multiimg/" + imgAd + "' border='0' width='562'/>";
                                }
                                else
                                {
                                    imgAd = "<img src='image/multiimg/" + imgAd + "' border='0'/>";
                                }
                            }
                        }
                        catch
                        {
                            imgAd = "";
                        }
                    }
                }
                strpro += "<tr><td colspan='3' height='5'></td></tr><tr>";
                strpro += "<td valign='top' width='195'>";
                strpro += "<img width='190' height='162' src='" + strurl + "'/>";
                strpro += seeMore + "</td>";
                strpro += "<td valign='top'><table border='0' width='100%' cellpadding='0' cellspacing='0'>";
                strpro += "<tr><td width='70'>" + tname + ":</td><td class='text_title'>" + strname + "</td></tr>";
                strpro += "<tr><td colspan='2' class='bg_line2'></td></tr>";
                strpro += "<tr><td>" + tbrand + ":</td><td class='text_title'><a href='default.html?menu=pro&brand=" + stridbrand + "' onmouseover='OnMOMenu(" + stridbrand + ",0,10,event);' onmouseout='TimeHidden();'>" + strBrand + "</a></td></tr>";
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
                strpro += "<tr><td colspan='3' class='bg_line2'></td></tr>";
                if (viewpro.Rows.Count > 0)
                {
                    DateTime time = new DateTime();
                    time = (DateTime)viewpro.Rows[0]["date"];
                    strpro += "<tr><td>" + tnview + ":</td><td><span style='color:red'>" + viewpro.Rows[0]["view"].ToString() + "</span> (" + time.ToString("dd/MM/yyyy") + ")</td></tr>";
                    strpro += "<tr><td colspan='3' class='bg_line2'></td></tr>";
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
                    strpro += "<tr><td class='price1'>" + twhere + ":</td><td colspan='2' class='text_2'>" + strAdd + "</td></tr>";
                }
                else
                {
                    strpro += "<tr><td>" + tstate + ":</td><td class='price' colspan='2'>" + tnothave + "</td></tr>";
                }
                strpro += "<tr><td colspan='3' class='bg_line2'></td></tr>";
                strpro += "<tr><td colspan='3' height='30' align='center'><input type='button' class='button3' value='" + tback + "' onclick='back();'/><input type='button' class='button3' value='" + tcompare + "' onclick='gocomp(" + strid + ")'/><input type='button' class='button3' value='" + torder + "' onclick='AddCart(" + strid + ",1);'/></td></tr>";
                strpro += "<tr><td height='4'></td></tr></table></td>";
                strpro += "</tr></table>";
                strpro += divseeMore;
                if (imgAd.Length > 0)
                {
                    strpro += "<div style='text-align:center;'>" + imgAd + "</div>";
                    strpro += "<div style='height:7px'></div>";
                }
                if (promotion.Rows.Count > 0)
                {
                    strpro += "<table border='0' cellpadding='0' cellspacing='0' width='100%' bgcolor='#FFF1EA'>";
                    strpro += "<tr><td class='title_1' align='center'>Sản phẩm đi kèm theo máy</td></tr>";
                    strpro += "<tr><td class='tavt'>";
                    try
                    {
                        //DateTime time = (DateTime)promotion.Rows[0]["StartDate"];
                        //strpro += "Từ ngày(Start): <span class='price'>" + time.ToString("dd/MM/yyyy") + "</span>";
                        //time = (DateTime)promotion.Rows[0]["EndDate"];
                        //strpro += ", Đến ngày(End): <span class='price'>" + time.ToString("dd/MM/yyyy") + "</span><br />";
                    }
                    catch
                    { }
                    strpro += promotion.Rows[0]["Note"].ToString() + "</td></tr>";
                    if (promotion.Rows[0]["UrlImage"].ToString().Length > 0)
                    {
                        strpro += "<tr><td align='center'><img class='imgpms' src='image/img_promotion/" + promotion.Rows[0]["UrlImage"].ToString() + "'/></td></tr>";
                        //strpro += "<tr><td align='center'><img class='imgpms' src='image/img_promotion/promotion_13_1282010104418.jpg'/></td></tr>";
                        strpro += "<tr><td align='center'>(Ảnh sản phẩm đi kèm theo máy)</td></tr>";
                    }
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
                strspec += "<tr class='bgtr1'><td class='td1'>" + table.Rows[0]["name"].ToString() + "</td>";
                strspec += "<td>" + table.Rows[0]["component"].ToString() + "</td></tr>";
                for (int i = 0; i < numCom; i++)
                {

                    if (idtype.Equals(table.Rows[i]["componenttypeid"].ToString()))
                    {
                        if (table.Rows[i]["propertyvalue"].ToString().Length > 0)
                        {
                            strspec += "<tr class='bgtr2'><td class='td2'>" + table.Rows[i]["property"].ToString() + "</td>";
                            strspec += "<td>" + table.Rows[i]["propertyvalue"].ToString() + " " + table.Rows[i]["unit"].ToString() + "</td></tr>";
                        }
                    }
                    else
                    {
                        idtype = table.Rows[i]["componenttypeid"].ToString();
                        strspec += "<tr class='bgtr1'><td class='td1'>" + table.Rows[i]["name"].ToString() + "</td>";
                        strspec += "<td>" + table.Rows[i]["component"].ToString() + "</td></tr>";
                        if (table.Rows[i]["propertyvalue"].ToString().Length > 0)
                        {
                            strspec += "<tr class='bgtr2'><td class='td2'>" + table.Rows[i]["property"].ToString() + "</td>";
                            strspec += "<td>" + table.Rows[i]["propertyvalue"].ToString() + " " + table.Rows[i]["unit"].ToString() + "</td></tr>";
                        }
                    }
                }
                strspec += "<tr class='bgtr1'><td class='td1'>Các thông tin khác</td>";
                strspec += "<td></td></tr>";
                for (int i = 0; i < numproperty; i++)
                {
                    if (property.Rows[i]["PropertyValue"].ToString().Length > 0)
                    {
                        strspec += "<tr class='bgtr2'><td class='td2'>" + property.Rows[i]["Name"].ToString() + "</td>";
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
                price2 = table.Rows[i]["SellingPrice"].ToString();
                price1 = float.Parse(table.Rows[i]["SellingPrice"].ToString());
                price1 = price1 * rate;
                price = price1.ToString("N").Split('.')[0];
                warranty = table.Rows[i]["WarrantyMonth"].ToString();
                madein = table.Rows[i]["ShortNote"].ToString();
                isspec = table.Rows[i]["Isspec"].ToString();
                string namepro = "";
                namepro = table.Rows[i]["Name"].ToString();
                namepro = namepro.Replace("/", "");
                namepro = namepro.Replace("#", "");
                namepro = namepro.Replace(":", "");
                namepro = namepro.Replace("\"", "");
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
                    strProMain += "<tr><td rowspan='2' width='88' align='center' valign='top'>";
                    if (table.Rows[i]["promotion"].ToString().Length > 0)
                    {
                        strProMain += "<img src='image/common/khuyenmai.gif' style='cursor:pointer;' onmouseover='showDivMessage(2," + id + "," + i + ",event);' onmouseout='OnMOut(event)'/><br />";
                    }
                    strProMain += "<a href='" + namepro + "-dp-" + id + ".html'><img class='img1' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)' src='" + url + "'/></a></td>";
                    strProMain += "<td valign='top' class='text_title'><a href='" + namepro + "-dp-" + id + ".html' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)'>" + name + "</a></td></tr>";
                    strProMain += "<tr><td valign='middle' width='190' height='48'>" + tprice + ": <span class='price'>";
                    
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
                    strProMain += "</td></tr>";

                    if (madein.Length > 0)
                    {
                        strProMain += "<tr><td colspan='2' class='text_title' align='center'>" + madein + "</td></tr>";
                    }
                    //strProMain += "<tr><td colspan='2' height='32' align='center'><div class='button3' onclick='AddCart(" + id + ",1);'>" + torder + "</div></td></tr>";
                    strProMain += "</table></td>";
                    strProMain += "<td class='bg_line4'></td>";
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
                    strProMain += "<tr><td rowspan='2' width='88' align='center' valign='top'>";
                    if (table.Rows[i]["promotion"].ToString().Length > 0)
                    {
                        strProMain += "<img src='image/common/khuyenmai.gif' style='cursor:pointer;' onmouseover='showDivMessage(2," + id + "," + i + ",event);' onmouseout='OnMOut(event)'/><br />";
                    }
                    strProMain += "<a href='" + namepro + "-dp-" + id + ".html'><img class='img1' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)' src='" + url + "'/></a></td>";
                    strProMain += "<td valign='top' class='text_title'><a href='" + namepro + "-dp-" + id + ".html' onmouseover='showDivMessage(1," + id + "," + i + ",event);' onmouseout='OnMOut(event)'>" + name + "</a></td></tr>";
                    strProMain += "<tr><td valign='middle' width='190' height='48'>" + tprice + ": <span class='price'>";
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
                    strProMain += "</td></tr>";

                    if (madein.Length > 0)
                    {
                        strProMain += "<tr><td colspan='2' class='text_title' align='center'>" + madein + "</td></tr>";
                    }
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
            strlist += strProMain;
        }
    }
}