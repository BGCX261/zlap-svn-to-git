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
using System.Xml;
public partial class AjaxRequest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string func = Request.QueryString["menu"].ToString();
            string id="0";
            switch (func)
            {
                case ("lang"):
                    string flag = "";
                    id = Request.QueryString["id"].ToString();
                    Session["langcurrent"] = id;
                    ArrayList _list = (ArrayList)Application["langsupport"];
                    int numLang = _list.Count;
                    for (int i = 0; i < numLang; i++)
                    {
                        string[] arrstr = (string[])_list[i];
                        if (Session["langcurrent"].ToString().Equals(arrstr[1]))
                        {
                            flag += "<img id='" + arrstr[1] + "' src='image/flag/" + arrstr[2] + "' class='img_flag2' title='" + arrstr[0] + "'/>";
                        }
                        else
                        {
                            flag += "<img id='" + arrstr[1] + "' src='image/flag/" + arrstr[2] + "' class='img_flag1' title='" + arrstr[0] + "' onclick='OnChangeLang(this);'/>";
                        }
                    }
                    Session["strlangsupport"] = flag;
                    Response.Write("ok");
                    break;
                case("specpro"):
                    id = Request.QueryString["id"].ToString();
                    string Specification = new ProductSystem().ProductShortNote(id);
                    Response.Write(Specification);
                    break;
                case("promotion"):
                    id = Request.QueryString["id"].ToString();
                    string promotion = new ProductSystem().PromotionSelectId(id);
                    Response.Write(promotion);
                    break;
                case("logout"):
                    Session["infoUser"] = null;
                    Response.Write("ok");
                    break;
                case("compare"):
                    string sl1 = "0";
                    string sl2 = "0";
                    try
                    {
                        string[] arr = Request.QueryString["id"].ToString().Split(',');
                        int id1 = int.Parse(arr[0]);
                        int id2 = int.Parse(arr[1]);
                        DataSet ds = new ProductSystem().ProductSelectNameWithBrand(id1, id2, int.Parse(Application["idtypemobile"].ToString()));
                        int num = ds.Tables[0].Rows.Count;
                        if (num > 0)
                        {
                            num = num - 1;
                            sl1 = "";
                            for (int i = 0; i < num; i++)
                            {
                                sl1 +=ds.Tables[0].Rows[i]["id"].ToString() + ":" + ds.Tables[0].Rows[i]["name"].ToString() + ";";
                            }
                            sl1 += ds.Tables[0].Rows[num]["id"].ToString() + ":" + ds.Tables[0].Rows[num]["name"].ToString();
                        }
                        num = ds.Tables[1].Rows.Count;
                        if (num > 0)
                        {
                            num = num - 1;
                            sl2 = "";
                            for (int i = 0; i < num; i++)
                            {
                                sl2 += ds.Tables[1].Rows[i]["id"].ToString() + ":" + ds.Tables[1].Rows[i]["name"].ToString() + ";";
                            }
                            sl2 += ds.Tables[1].Rows[num]["id"].ToString() + ":" + ds.Tables[1].Rows[num]["name"].ToString();
                        }
                    }
                    catch
                    { }
                    Response.Write(sl1 + "<>" + sl2);
                    break;
                case "bestsell":
                    string strbest = "";
                    try
                    {
                        string blBestSell = "";
                        string tprice = "";
                        string currencymobile = "USD";
                        currencymobile = Application["currencymobile"].ToString();
                        Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
                        blBestSell = hash["blbestsell"].ToString();
                        tprice = hash["tprice"].ToString();
                        strbest += "<table border='0' cellpadding='0' cellspacing='0' width='100%'>";
                        strbest += "<tr><td class='bgcl9'>" + blBestSell + "</td></tr>";
                        strbest += "<tr><td class='bgcl1'><table border='0' cellpadding='0' cellspacing='0' width='100%'>";
                        strbest += GetProBestSell(tprice, currencymobile);
                        strbest += "</table></td></tr><tr><td height='10'></td></tr></table>";
                    }
                    catch
                    { 
                    
                    }
                    Response.Write(strbest);
                    break;
                //originaltop
                case "originaltop":
                    string stroriginal = "";
                    try
                    {
                        string bloriginal = "";
                        string tprice = "";
                        string seeall = "";
                        string currencymobile = "USD";
                        currencymobile = Application["currencymobile"].ToString();
                        Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
                        bloriginal = hash["loriginal"].ToString();
                        tprice = hash["tprice"].ToString();
                        seeall = hash["saoriginal"].ToString();
                        stroriginal += "<table border='0' cellpadding='0' cellspacing='0' width='100%'>";
                        stroriginal += "<tr><td class='bgcl9'>" + bloriginal + "</td></tr>";
                        stroriginal += "<tr><td class='bgcl1'><table border='0' cellpadding='0' cellspacing='0' width='100%'>";
                        stroriginal += GetProOriginal(tprice, currencymobile);
                        stroriginal += "</table></td></tr><tr><td height='10'></td></tr></table>";
                    }
                    catch
                    {

                    }
                    Response.Write(stroriginal);
                    break;
                case "justhave":
                    string strjusthave = "";
                    try
                    {
                        string bljusthave = "";
                        string tprice = "";
                        string currencymobile = "USD";
                        currencymobile = Application["currencymobile"].ToString();
                        Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
                        bljusthave = hash["justhmobi"].ToString();
                        tprice = hash["tprice"].ToString();
                        strjusthave = "<div class='td_bd1'>";
                        strjusthave += "<table border='0' cellpadding='0' cellspacing='0' width='100%' bgcolor='#FFF1EA'>";
                        strjusthave += "<tr><td class='text_b3'>" + bljusthave + " <img src='image/common/hot.gif'/></td></tr>";
                        strjusthave += GetJustHave(tprice, currencymobile);
                        strjusthave += "</table>";
                        strjusthave += "</div>&nbsp;";
                    }
                    catch
                    {

                    }
                    Response.Write(strjusthave);
                    break;
                case "online":
                    Response.Write(SupportOnline());
                    break;
                case "advertise":
                    Response.Write(Advertise());
                    break;
                case "brand":
                    Response.Write(ListBrand());
                    break;
                case"statistic":
                    Response.Write(GetStatistic());
                    break;
                case ("quicksearch"):
                    Response.Write(BuildPageSearch());
                    break;
                case ("aspecial"):
                    Response.Write(GetAdvertiseSpecial());
                    break;
            }
        }
        catch { }
   }
    public string GetProBestSell(string tprice,string currencymobile)
    {
        string strBestSell = "";
        try
        {
            DataTable table = new DataTable();
            ProductMainPage_data ds = new Mobilesystem().MobileforShow("Select * from v_web_mobile_show_all where type=2 order by Sellingprice");
            table = ds.Tables[ProductMainPage_data._table];
            int num = table.Rows.Count;
            string id = "";
            string name = "";
            string price = "";
            string img = "";
            float rate = (float)Application["ratepromobi"];
            float price1 = 1;
            for (int i = 0; i < num; i++)
            {
                id = table.Rows[i][ProductMainPage_data._id].ToString();
                name = table.Rows[i][ProductMainPage_data._name].ToString() + " " + table.Rows[i][ProductMainPage_data._state].ToString(); ;
                //price = table.Rows[i][ProductMainPage_data._price].ToString();
                price1 = float.Parse(table.Rows[i][ProductMainPage_data._price].ToString());
                price1 = price1 * rate;
                price = price1.ToString("N").Split('.')[0];
                if (price.Equals("0"))
                {
                    price = "-"; 
                }
                img = table.Rows[i][ProductMainPage_data._urlImage].ToString();
                if (img.Length > 0)
                {
                    img = "image/img_pro/" + img;
                }
                else
                {
                    img = "image/common/notimgpro.png";
                }
                strBestSell += "<tr><td width='65'>";
                strBestSell += "<a href='?menu=dp&id=" + id + "'><img src='" + img + "' class='img4' /></a></td><td>";
                strBestSell += "<a href='?menu=dp&id=" + id + "'>" + name + "</a><br />";
                strBestSell += "<span class='txt4'>" + price + " " + currencymobile + "</span></td></tr>";
                if (i + 1 < num)
                {
                    strBestSell += "<tr><td colspan='2' class='line1'></td></tr>";
                }
            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.ToString());
        }
        return strBestSell;
    }
    public string GetProOriginal(string tprice, string currencymobile)
    {
        string strBestSell = "";
        try
        {
            DataTable table = new DataTable();
            ProductMainPage_data ds = new Mobilesystem().MobileforShow("Select top 6 * from v_web_mobile_show_all where type=3 order by Sellingprice");
            table = ds.Tables[0];
            int num = table.Rows.Count;
            string id = "";
            string name = "";
            string price = "";
            string img = "";
            float rate = (float)Application["ratepromobi"];
            float price1 = 1;
            for (int i = 0; i < num; i++)
            {
                id = table.Rows[i][ProductMainPage_data._id].ToString();
                name = table.Rows[i][ProductMainPage_data._name].ToString() + " " + table.Rows[i][ProductMainPage_data._state].ToString(); ;
                //price = table.Rows[i][ProductMainPage_data._price].ToString();
                price1 = float.Parse(table.Rows[i][ProductMainPage_data._price].ToString());
                price1 = price1 * rate;
                price = price1.ToString("N").Split('.')[0];
                if (price.Equals("0"))
                {
                    price = "-";
                }
                img = table.Rows[i][ProductMainPage_data._urlImage].ToString();
                if (img.Length > 0)
                {
                    img = "image/img_pro/" + img;
                }
                else
                {
                    img = "image/common/notimgpro.png";
                }
                strBestSell += "<tr><td width='65'>";
                strBestSell += "<a href='?menu=dp&id=" + id + "'><img src='" + img + "' class='img4' /></a></td><td>";
                strBestSell += "<a href='?menu=dp&id=" + id + "'>" + name + "</a><br />";
                strBestSell += "<span class='txt4'>" + price + " " + currencymobile + "</span></td></tr>";
                if (i + 1 < num)
                {
                    strBestSell += "<tr><td colspan='2' class='line1'></td></tr>";
                }
            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.ToString());
        }
        return strBestSell;
    }
    public string GetJustHave(string tprice, string currencymobile)
    {
        string strBestSell = "";
        return strBestSell;
        try
        {
            DataTable table = new DataTable();
            ProductMainPage_data ds = new ProductBestSellSystem().ProductJustHaveTop();
            table = ds.Tables[ProductMainPage_data._table];
            int num = table.Rows.Count;
            string id = "";
            string name = "";
            string price = "";
            string img = "";
            float rate = (float)Application["ratepromobi"];
            float price1 = 1;
            for (int i = 0; i < num; i++)
            {
                id = table.Rows[i][ProductMainPage_data._id].ToString();
                name = table.Rows[i][ProductMainPage_data._name].ToString() + " " + table.Rows[i][ProductMainPage_data._state].ToString();
                //price = table.Rows[i][ProductMainPage_data._price].ToString();
                price1 = float.Parse(table.Rows[i][ProductMainPage_data._price].ToString());
                price1 = price1 * rate;
                price = price1.ToString("N").Split('.')[0];
                if (price.Equals("0"))
                {
                    price = "-";
                }
                img = table.Rows[i][ProductMainPage_data._urlImage].ToString();
                if (img.Length > 0)
                {
                    img = "image/img_pro/" + img;
                }
                else
                {
                    img = "image/common/notimgpro.png";
                }
                strBestSell += "<tr><td class='div1'><a href='?menu=dp&id=" + id + "'>" + name + "</a><br />";
                strBestSell += "<a href='?menu=dp&id=" + id + "'><img src='" + img + "' class='img2' /></a>";
                strBestSell += "<span class='price1'>" + price + " " + currencymobile + "</span></td></tr>";
                if (i + 1 < num)
                {
                    strBestSell += "<tr><td class='bg_line2'></td></tr>";
                }
            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.ToString());
        }
        return strBestSell;
    }
    public string SupportOnline()
    {
        string strOnline = "";
        try
        {
            if (Application["appOnlineMobi"] == null)
            {
                DataSet dsOnline = new SupportOnlineSystem().OnlineSelectAll("2");
                int numOnline = dsOnline.Tables[0].Rows.Count;
                if (numOnline > 0)
                {
                    strOnline = "<table border='0' cellpadding='0' cellspacing='0' width='100%'>";
                    string idgroup1 = dsOnline.Tables[0].Rows[0]["idgroup"].ToString();
                    strOnline += "<tr><td class='text_b2'>" + dsOnline.Tables[0].Rows[0]["namegroup"].ToString() + "</td></tr>";
                    for (int i = 0; i < numOnline; i++)
                    {
                        if (idgroup1 != dsOnline.Tables[0].Rows[i]["idgroup"].ToString())
                        {
                            strOnline += "<tr><td class='text_b2'>" + dsOnline.Tables[0].Rows[i]["namegroup"].ToString() + "</td></tr>";
                            idgroup1 = dsOnline.Tables[0].Rows[i]["idgroup"].ToString();
                        }
                        string name = dsOnline.Tables[0].Rows[i]["name"].ToString();
                        if (dsOnline.Tables[0].Rows[i]["title"].ToString().Length > 0)
                        {
                            name = "<br /><span class='text_5'>" + dsOnline.Tables[0].Rows[i]["title"].ToString() + ":</span> " + name;
                        }
                        strOnline += "<tr height='26'><td class='text_title' align='left'>";
                        strOnline += "&nbsp;&nbsp;<a href ='ymsgr:sendim?" + dsOnline.Tables[0].Rows[i]["nickname"].ToString() + "'><img src='http://opi.yahoo.com/online?u=" + dsOnline.Tables[0].Rows[i]["nickname"].ToString() + "&m=g&t=1' border='0' style='vertical-align:middle'/></a> " + name + "</td></tr>";
                        if (i < numOnline - 1 && idgroup1 == dsOnline.Tables[0].Rows[i + 1]["idgroup"].ToString())
                        {
                            strOnline += "<tr><td class='bg_line2'></td></tr>";
                        }
                        else if (i == numOnline - 1)
                        {
                            strOnline += "<tr><td height='2'></td></tr>";
                        }
                    }
                    strOnline += "</table>";
                    Application["appOnlineMobi"] = strOnline;
                }
            }
            else
            {
                strOnline = Application["appOnlineMobi"].ToString();
            }
        }
        catch
        { }
        return strOnline;
    }
    public string GetAdvertiseSpecial()
    {
        string advertise = "";
        try
        {
            DataSet dsAdvertise = new AdvertiseSystem().SpecialSelectWhere("where idBrand=0");
            int num = dsAdvertise.Tables[0].Rows.Count;
            if (num > 0)
            {
                advertise = "<table border=0 width='100%' cellpadding='0' cellspacing='0'>";
                for (int i = 0; i < num; i++)
                {
                    advertise += "<tr><td align='center' width='574'>";
                    string img2 = dsAdvertise.Tables[0].Rows[i]["UrlImage2"].ToString();
                    if (img2.Length > 0)
                    {
                        string[] extension = img2.Split('.');
                        if (extension[1].Equals("swf"))
                        {
                            advertise += "<object width='574' height='90'><embed src='image/advertise/" + img2 + "' width='574' height='90' type='application/x-shockwave-flash' pluginspage='http://www.macromedia.com/go/getflashplayer'></embed></object>";
                        }
                        else
                        {
                            advertise += "<a href='" + dsAdvertise.Tables[0].Rows[i]["link"].ToString() + "'><img src='image/advertise/" + img2 + "' border='0'/></a>";
                        }
                    }
                    advertise += "</td></tr>";
                    advertise += "<tr><td height='7'></td></tr>";
                }
                advertise += "<tr><td height='7'></td></tr>";
                advertise += "</table>";
            }
        }
        catch
        {
            advertise = "";
        }
        return advertise;
    } 
    public string Advertise()
    {
        string list_Advertise = "";
        try
        {
            if (Application["MobiMobiappAdvertiset"] == null)
            {
                DataSet ds = new AdvertiseSystem().AdvertiseSelectAllShow();
                if (ds.Tables.Count > 0)
                {
                    int num = ds.Tables[0].Rows.Count;
                    for (int i = 0; i < num; i++)
                    {
                        string image = ds.Tables[0].Rows[i]["urlImage"].ToString();
                        string[] array = image.Split('.');
                        if (array[1].Equals("swf"))
                        {
                            list_Advertise += "<object width='175'><embed src='../image/advertise/" + image + "' width='160' height='86' type='application/x-shockwave-flash' pluginspage='http://www.macromedia.com/go/getflashplayer'></embed></object><br />";
                        }
                        else
                        {
                            list_Advertise += "<a href='" + ds.Tables[0].Rows[i]["link"].ToString() + "' title='" + ds.Tables[0].Rows[i]["title"].ToString() + "' target='_blank'><img src='../image/advertise/" + image + "' class='imga'/></a><br />";
                        }
                    }
                    Application["MobiappAdvertiset"] = list_Advertise;
                }
            }
            else
            {
                list_Advertise = Application["MobiappAdvertiset"].ToString();
            }
        }
        catch
        {
            list_Advertise="";
        }
        return list_Advertise;
    }
    public string ListBrand()
    {
        string bl_brand = "";
        string seeAll = "";
        string listbrand = "";
        string strreturn = "";
        try
        {
            Hashtable hashLang = (Hashtable)Application[Session["langcurrent"].ToString()];
            bl_brand = hashLang["blbrand"].ToString();
            seeAll = hashLang["sapro"].ToString();
        }
        catch (Exception ex)
        {
            Console.Write(ex.ToString());
        }
        if (Application["listBrandPro"] == null)
        {
            string arrBrand = "";
            //Read brand:
            BrandProduct_data ds = new BrandProductSystem().BrandProAllType((int)Application["idtypemobile"]);
            DataTable table = ds.Tables[BrandProduct_data._table];
            int numBrand = table.Rows.Count;
            for (int i = 0; i < numBrand; i++)
            {
                string id = table.Rows[i][BrandProduct_data._id].ToString();
                string name = table.Rows[i][BrandProduct_data._name].ToString();
                arrBrand += "<a href='?menu=pro&brand=" + id + "'>" + name + "</a><br />";
            }
            if (arrBrand.Length > 0)
            {
                Application["listBrandPro"] = arrBrand;
            }
            listbrand = "<a href='?menu=product'>" + seeAll + "</a><br />" + arrBrand;
        }
        else
        {
            listbrand = "<a href='?menu=product'>" + seeAll + "</a><br />";
            if (Application["listBrandPro"] != null)
            {
                listbrand += Application["listBrandPro"].ToString();
            }
        }
        strreturn = "<table width='100%' cellpadding='0' cellspacing='0'>";
        strreturn += "<tr><td class='bg_b1'></td><td class='bg_b2'><div class='text_bl'>" + bl_brand + "</div></td><td class='bg_b3'></td></tr>";
        strreturn += "<tr><td class='bg_b4'></td><td><div class='text_2'>" + listbrand + "</div></td><td class='bg_b5'></td></tr>";
        strreturn +="<tr><td class='bg_b7' colspan='3'></td></tr>";
        strreturn += "<tr><td height='8'></td></tr></table>";
        return strreturn;
    }
    public string GetStatistic()
    {
        string str = "";
        try
        {
            string blstatistic = "";
            string tnumaccess = "";
            string tnumonline = "";
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            blstatistic = hash["blstatistical"].ToString();
            tnumaccess = hash["mnuma"].ToString();
            tnumonline = hash["monline"].ToString();
            str = "<div class='bgcl1'>";
            str += "<span class='txt8'>" + blstatistic + ":</span><br />";
            str += tnumaccess + ": <span class='txt7'>" + Application["numvisited"].ToString() + "</span><br />";
            str += tnumonline + ": <span class='txt7'>";
            if (Application["numberonline"] != null)
            {
                str += Application["numberonline"].ToString();
            }
            str += "</span></div>";
        }
        catch
        {
            str = "";
        }
        return str;
    }
    //For search:
    public string BuildPageSearch()
    {
        string str = "";
        string tbl_search = "";
        string tsearch = "";
        string tPrice = "";
        string tBrand = "";
        string tCpu = "";
        string tScreen = "";
        string tadvance = "";
        string tcolor = "";
        try
        {
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            tsearch = hash["tsearch"].ToString();
            tPrice = hash["slprice"].ToString();
            tBrand = hash["slbrand"].ToString();
            //tCpu = hash["slcpu"].ToString();
            //tScreen = hash["slscreen"].ToString();
            tbl_search = tsearch;
            //tadvance = hash["avsearch"].ToString();
            tcolor = hash["tcolor"].ToString();
        }
        catch
        { }
        str = "<table cellpadding='0' cellspacing='0'>";
        str += "<tr><td class='bgtl1'></td><td class='bgtc1' width='145'>" + tbl_search + "</td><td class='bgtr1'></td></tr>";
        string[] values = GetValueSearch(tsearch, tPrice, tBrand,tcolor);
        str += "<tr><td height='2'></td><td></tr>";
        str += "<tr><td colspan='3' width='175' class='bgcl1' align='center'>";
        str += values[1];
        str += "<div class='h1'></div>";
        str += values[0];
        str += "<div class='h1'></div>";
        str += values[2];
        str += "<div class='h1'></div>";
        str += "<input type='text' class='tb1' id='txtsearchq' onkeydown=\"OnEnterSend(event,'btSearchMain');\" />";
        str += "<div class='h1'></div>";
        str += "<input type='button' class='bt2' id='btSearchMain' onclick=\"OnClickSearch();\" value='" + tsearch + "'/>";
        str += "<div class='h1'></div>";
        str += "<a href='?menu=asp'>" + tadvance + "</a>";
        str += "</td></tr>";
        str += "<tr><td height='10'></td></tr></table>";
        return str;
    }
    public string[] GetValueSearch(string tsearch, string tPrice, string tBrand,string tcolor)
    {
        string[] values = new string[3] { "", "", ""};
        string str = "";
        string path = Server.MapPath("data/xml/");
        XmlDocument doc = new XmlDocument();
        int numNode = 0;
        try
        {
            XmlTextReader reader = new XmlTextReader(path + "price.xml");
            //Get Price:
            doc.Load(reader);
            reader.Close();
            XmlNodeList nodes = doc.SelectNodes("/root/search");
            numNode = nodes.Count;
            //GetPrice:
            str = "<select class='sl1' id='slpriceq'>";
            str += "<option value='0'>" + tPrice + "</option>";
            for (int i = 0; i < numNode; i++)
            {
                string value = nodes[i].ChildNodes[1].InnerText + "," + nodes[i].ChildNodes[2].InnerText;
                str += "<option value='" + value + "'>" + nodes[i].ChildNodes[0].InnerText + "</option>";
            }
            str += "</select>";
            values[0] = str;
            //Get Brand:
            DataSet ds = new BrandProductSystem().BrandProAllType((int)Application["idtypemobile"]);
            numNode = ds.Tables[0].Rows.Count;
            str = "<select class='sl1' id='slbrandq'>";
            str += "<option value='0'>" + tBrand + "</option>";
            for (int i = 0; i < numNode; i++)
            {
                str += "<option value='" + ds.Tables[0].Rows[i]["id"].ToString() + "'>- " + ds.Tables[0].Rows[i]["name"].ToString() + "</option>";
            }
            str += "</select>";
            values[1] = str;
            //Get Color product:
            reader = new XmlTextReader(path + "colorsearch.xml");
            doc.Load(reader);
            reader.Close();
            nodes = doc.SelectNodes("/root/search");
            numNode = nodes.Count;
            str = "<select class='sl1' id='slcolorq'>";
            str += "<option value='0'>" + tcolor + "</option>";
            for (int i = 0; i < numNode; i++)
            {
                str += "<option value='" + nodes[i].ChildNodes[1].InnerText + "'>" + nodes[i].ChildNodes[0].InnerText + "</option>";
            }
            str += "</select>";
            values[2] = str;
        }
        catch
        {

        }
        return values;
    }
}