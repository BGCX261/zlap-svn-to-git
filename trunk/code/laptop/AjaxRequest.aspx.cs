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
    private string strMVAT = "";
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
                    string Specification = new ProductSystem().ProductDesandStock(id);
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
                        DataSet ds = new ProductSystem().ProductSelectNameWithBrand(id1, id2, int.Parse(Application["idtypeproduct"].ToString()));
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
                        string currency = "USD";
                        currency = Application["currency"].ToString();
                        Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
                        blBestSell = hash["blbestsell"].ToString();
                        tprice = hash["tprice"].ToString();
                        strMVAT = hash["msvat"].ToString();
                        strbest = "<div class='td_bd1'>";
                        strbest += "<table border='0' cellpadding='0' cellspacing='0' width='100%' bgcolor='#FFF1EA'>";
                        strbest+="<tr><td class='text_b3'>"+ blBestSell +"</td></tr>";
                        strbest += GetProBestSell(tprice, currency);
                        strbest += "</table>";
                        strbest += "</div>&nbsp;";
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
                        string currency = "USD";
                        currency = Application["currency"].ToString();
                        Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
                        bloriginal = hash["loriginal"].ToString();
                        tprice = hash["tprice"].ToString();
                        seeall = hash["saoriginal"].ToString();
                        strMVAT = hash["msvat"].ToString();
                        stroriginal = "<div class='td_bd1'>";
                        stroriginal += "<table border='0' cellpadding='0' cellspacing='0' width='100%' bgcolor='#FFF1EA'>";
                        stroriginal += "<tr><td class='text_b3'>" + bloriginal + "</td></tr>";
                        stroriginal += GetProOriginal(tprice, currency);
                        stroriginal += "<tr><td class='text_title' align='center'><a href='default.html?menu=originalpro'>" + seeall + "</a></td></tr>";
                        stroriginal += "</table>";
                        stroriginal += "</div>&nbsp;";
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
                        string currency = "USD";
                        currency = Application["currency"].ToString();
                        Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
                        bljusthave = hash["justh"].ToString();
                        tprice = hash["tprice"].ToString();
                        strMVAT = hash["msvat"].ToString();
                        strjusthave = "<div class='td_bd1'>";
                        strjusthave += "<table border='0' cellpadding='0' cellspacing='0' width='100%' bgcolor='#FFF1EA'>";
                        strjusthave += "<tr><td class='text_b3'>" + bljusthave + " <img src='image/common/hot.gif'/></td></tr>";
                        strjusthave += GetJustHave(tprice, currency);
                        strjusthave += "</table>";
                        strjusthave += "</div>&nbsp;";
                    }
                    catch
                    {

                    }
                    Response.Write(strjusthave);
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
                case ("listName"):
                    Response.Write(GetListName());
                    break;
                case ("stateproduct"):
                    id = Request.QueryString["id"].ToString();
                    Response.Write(BrandNameWithStateId(id));
                    break;
            }
        }
        catch { }
   }
    public string GetProBestSell(string tprice,string currency)
    {
        string strBestSell = "";
        try
        {
            DataTable table = new DataTable();
            ProductMainPage_data ds = new ProductBestSellSystem().ProductBestSellAll();
            table = ds.Tables[ProductMainPage_data._table];
            int num = table.Rows.Count;
            string id = "";
            string name = "";
            string price = "";
            string img = "";
            float rate = (float)Application["ratepromain"];
            float price1 = 1;
            string price2 = "";
            for (int i = 0; i < num; i++)
            {
                id = table.Rows[i][ProductMainPage_data._id].ToString();
                name = table.Rows[i][ProductMainPage_data._name].ToString() + " " + table.Rows[i][ProductMainPage_data._state].ToString(); ;
                price2 = table.Rows[i][ProductMainPage_data._price].ToString();
                price1 = float.Parse(table.Rows[i][ProductMainPage_data._price].ToString());
                price1 = price1 * rate;
                price = price1.ToString("N").Split('.')[0];
                string namepro = table.Rows[i][ProductMainPage_data._name].ToString();
                namepro = namepro.Replace("/", "");
                namepro = namepro.Replace("#", "");
                namepro = namepro.Replace(":", "");
                namepro = namepro.Replace("\"", "");
                if (price.Equals("0"))
                {
                    price = "";
                    price2 = "";
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
                strBestSell += "<tr><td class='div1'><a href='" + namepro + "-dp-" + id + ".html'>" + name + "</a><br />";
                strBestSell += "<a href='" + namepro + "-dp-" + id + ".html'><img src='" + img + "' class='img2' /></a>";
                if (currency.Equals("$"))
                {
                    strBestSell += "<span class='price1'>" + price2 + "<br />(" + price + " VND)</span></td></tr>";
                }
                else if (currency.Equals("$$"))
                {
                    strBestSell += "<span class='price1'>" + price2 + " USD<br />(" + price + " VND)</span></td></tr>";
                }
                else
                {
                    strBestSell += "<span class='price1'>" + price + " " + currency + "</span></td></tr>";
                }
                strBestSell += "<tr><td class='tvat' align='center'>" + strMVAT + "</td></tr>";
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
    public string GetProOriginal(string tprice, string currency)
    {
        string strBestSell = "";
        try
        {
            DataTable table = new DataTable();
            DataSet ds = new ProductMainPageSystem().OriginalSelectTop4();
            table = ds.Tables[0];
            int num = table.Rows.Count;
            string id = "";
            string name = "";
            string price = "";
            string img = "";
            float rate = (float)Application["ratepromain"];
            float price1 = 1;
            string price2 = "";
            for (int i = 0; i < num; i++)
            {
                id = table.Rows[i][ProductMainPage_data._id].ToString();
                name = table.Rows[i][ProductMainPage_data._name].ToString() + " " + table.Rows[i][ProductMainPage_data._state].ToString(); ;
                price2 = table.Rows[i][ProductMainPage_data._price].ToString();
                price1 = float.Parse(table.Rows[i][ProductMainPage_data._price].ToString());
                price1 = price1 * rate;
                price = price1.ToString("N").Split('.')[0];
                if (price.Equals("0"))
                {
                    price = "";
                    price2 = "";
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
                string namepro = table.Rows[i][ProductMainPage_data._name].ToString();
                namepro = namepro.Replace("/", "");
                namepro = namepro.Replace("#", "");
                namepro = namepro.Replace(":", "");
                namepro = namepro.Replace("\"", "");
                strBestSell += "<tr><td class='div1'><a href='" + namepro + "-dp-" + id + ".html'>" + name + "</a><br />";
                strBestSell += "<a href='" + namepro + "-dp-" + id + ".html'><img src='" + img + "' class='img2' /></a>";
                if (currency.Equals("$"))
                {
                    strBestSell += "<span class='price1'>" + price2 + "<br />(" + price + " VND)</span></td></tr>";
                }
                else if (currency.Equals("$$"))
                {
                    strBestSell += "<span class='price1'>" + price2 + " USD<br />(" + price + " VND)</span></td></tr>";
                }
                else
                {
                    strBestSell += "<span class='price1'>" + price + " " + currency + "</span></td></tr>";
                }
                strBestSell += "<tr><td class='tvat' align='center'>" + strMVAT + "</td></tr>";
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
    public string GetJustHave(string tprice, string currency)
    {
        string strBestSell = "";
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
            float rate = (float)Application["ratepromain"];
            float price1 = 1;
            string price2 = "";
            for (int i = 0; i < num; i++)
            {
                id = table.Rows[i][ProductMainPage_data._id].ToString();
                name = table.Rows[i][ProductMainPage_data._name].ToString() + " " + table.Rows[i][ProductMainPage_data._state].ToString();
                price2 = table.Rows[i][ProductMainPage_data._price].ToString();
                price1 = float.Parse(table.Rows[i][ProductMainPage_data._price].ToString());
                price1 = price1 * rate;
                price = price1.ToString("N").Split('.')[0];
                string namepro = table.Rows[i][ProductMainPage_data._name].ToString();
                namepro = namepro.Replace("/", "");
                namepro = namepro.Replace("#", "");
                namepro = namepro.Replace(":", "");
                namepro = namepro.Replace("\"", "");
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
                strBestSell += "<tr><td class='div1'><a href='" + namepro + "-dp-" + id + ".html'>" + name + "</a><br />";
                strBestSell += "<a href='" + namepro + "-dp-" + id + ".html'><img src='" + img + "' class='img2' /></a>";
                if(currency.Equals("$"))
                {
                    strBestSell += "<span class='price1'>" + price2 + "<br />(" + price + " VND)</span></td></tr>";
                }
                else if (currency.Equals("$$"))
                {
                    strBestSell += "<span class='price1'>" + price2 + " USD<br />(" + price + " VND)</span></td></tr>";
                }
                else
                {
                    strBestSell += "<span class='price1'>" + price + " " + currency + "</span></td></tr>";
                }
                strBestSell += "<tr><td class='tvat' align='center'>" + strMVAT + "</td></tr>";
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
    public string GetAdvertiseSpecial()
    {
        string advertise = "";
        try
        {
            DataSet dsAdvertise = new AdvertiseSystem().SpecialSelectWhere("where idBrand=0 and type=1");
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
                            advertise += "<object width='574' height='90'><embed src='image/advertise/" + img2 + "' width='574' height='90' quality='high' scale='noscale' wmode='transparent' type='application/x-shockwave-flash' pluginspage='http://www.macromedia.com/go/getflashplayer'></embed></object>";
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
            if (Application["appAdvertiset"] == null)
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
                            list_Advertise += "<object width='175'><embed src='image/advertise/" + image + "' width='160' height='86' type='application/x-shockwave-flash' pluginspage='http://www.macromedia.com/go/getflashplayer'></embed></object><br />";
                        }
                        else
                        {
                            list_Advertise += "<a href='" + ds.Tables[0].Rows[i]["link"].ToString() + "' title='" + ds.Tables[0].Rows[i]["title"].ToString() + "' target='_blank'><img src='image/advertise/" + image + "' class='imga'/></a><br />";
                        }
                    }
                    Application["appAdvertiset"] = list_Advertise;
                }
            }
            else
            {
                list_Advertise = Application["appAdvertiset"].ToString();
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
            BrandProduct_data ds = new BrandProductSystem().BrandProAllType((int)Application["idtypeproduct"]);
            DataTable table = ds.Tables[BrandProduct_data._table];
            int numBrand = table.Rows.Count;
            for (int i = 0; i < numBrand; i++)
            {
                string id = table.Rows[i][BrandProduct_data._id].ToString();
                string name = table.Rows[i][BrandProduct_data._name].ToString();
                arrBrand += "<a href='default.html?menu=pro&brand=" + id + "'>" + name + "</a><br />";
            }
            if (arrBrand.Length > 0)
            {
                Application["listBrandPro"] = arrBrand;
            }
            listbrand = "<a href='default.html?menu=product'>" + seeAll + "</a><br />" + arrBrand;
        }
        else
        {
            listbrand = "<a href='default.html?menu=product'>" + seeAll + "</a><br />";
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
            str = "<table width='100%' cellpadding='0' cellspacing='0' border='0'>";
            str += "<tr><td class='td_border'><span class='text_3'>"+ blstatistic +"</span><br />";
            str += tnumaccess + ": <span class='text_visited'>" + Application["numvisited"].ToString() + "</span><br />";
            str += tnumonline + ": <span class='text_visited'>";
            if (Application["numberonline"] != null)
            {
                str += Application["numberonline"].ToString();
            }
            str += "</span></td></tr><tr><td height='8'></td></tr></table>";
        }
        catch
        { }
        return str;
    }
    // For listname:
    private string GetListName()
    {
        string str = "";
        try
        {
            int id = int.Parse(Request.QueryString["idbrand"].ToString());
            DataSet ds = new ProductSystem().ListNamePro((int)Application["idtypeproduct"], id);
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            string strhave = hash["thname"].ToString();
            string strnothave = hash["tnothname"].ToString();
            if (ds.Tables.Count > 0)
            {
                string nameBrand = "";
                string noteBrand = "";
                if (ds.Tables[1].Rows.Count > 0)
                {
                    nameBrand = ds.Tables[1].Rows[0]["name"].ToString();
                    noteBrand = ds.Tables[1].Rows[0]["Note"].ToString();
                }
                string number = "0";
                if (ds.Tables[2].Rows.Count > 0)
                {
                    number = ds.Tables[2].Rows[0]["number"].ToString();
                }
                int numName = ds.Tables[0].Rows.Count;
                if (numName > 7)
                {
                    str += "<table width='620' border='0' cellpadding='0' cellspacing='0' bgcolor='#FFF1EA'>";
                }
                else
                {
                    str += "<table width='310' border='0' cellpadding='0' cellspacing='0' bgcolor='#FFF1EA'>";
                }
                str += "<tr><td colspan='3' class='text_b3'>";
                if (number.Equals("0"))
                {
                    str += string.Format(strnothave, "<span class='text_3'>" + nameBrand + "</span>");
                    if (noteBrand.Length > 0)
                    {
                        str += "<div class='nbrand'>" + noteBrand + "</div>";
                    }
                    str += "</td></tr>";
                }
                else
                {
                    str += string.Format(strhave, "<span class='text_3'>" + nameBrand + "</span>","<span class='text_3'>" + number + "</span>");
                    if (noteBrand.Length > 0)
                    {
                        str += "<div class='nbrand'>" + noteBrand + "</div>";
                    }
                    str += "</td></tr>";
                    //Cộng thêm mô tả nhãn hiệu ở đây:
                    str += "<tr><td height='4'></td></tr>";
                    if (numName > 7)
                    {
                        int middle = numName / 2;
                        str += "<tr class='text_title' style='line-height:20px;' align='left'><td style='padding:3px;' valign='top'>";
                        for (int i = 0; i < middle; i++)
                        {
                            str += "<a href='default.html?menu=dasp&text=" + ds.Tables[0].Rows[i]["name"].ToString() + "'>" + ds.Tables[0].Rows[i]["name"].ToString() + " (" + ds.Tables[0].Rows[i]["number"].ToString() + ")</a><br />";
                        }
                        str += "</td><td class='bg_line4'></td><td style='padding:3px;' valign='top'>";
                        for (int i = middle; i < numName; i++)
                        {
                            str += "<a href='default.html?menu=dasp&text=" + ds.Tables[0].Rows[i]["name"].ToString() + "'>" + ds.Tables[0].Rows[i]["name"].ToString() + " (" + ds.Tables[0].Rows[i]["number"].ToString() + ")</a><br />";
                        }
                        str += "</tr>";
                        str += "<tr><td height='4'></td></tr>";
                    }
                    else
                    {
                        str += "<tr><td height='4'></td></tr>";
                        for (int i = 0; i < numName; i++)
                        {
                            str += "<tr class='text_title'><td align='left' style='padding:3px;'>";
                            str += "<a href='default.html?menu=dasp&text=" + ds.Tables[0].Rows[i]["name"].ToString() + "'>" + ds.Tables[0].Rows[i]["name"].ToString() + " (" + ds.Tables[0].Rows[i]["number"].ToString() + ")</a>";
                            str += "</td></tr>";
                        }
                        str += "<tr><td height='4'></td></tr>";
                    }
                }
                str += "</table>";
            }
            
        }
        catch
        {
            str = "";
        }
        return str;
    }
    private string BrandNameWithStateId(string StateId)
    {
        string str = "";
        try
        {
            string where = "";
            string typeproductid = Application["idtypeproduct"].ToString();

            DataSet ds = new DataSet();

            if (StateId.Equals("0"))
            {
                //Select All Brand Of laptop:
                ds = new BrandProductSystem().BrandProAllType(int.Parse(typeproductid));
                //where = "Where Id in(select id from v_web_producttype_brand where ProducttypeId=" + typeproductid + " group by id) order by Name";
            }
            else
            {
                where = "Where Id in(select BrandId from tbl_product where Producttypeid=" + typeproductid + " and cansales=1 and StateId in (" + StateId + ")  group by brandid) order by Name";
                ds = new BrandProductSystem().BrandNameWhere(where);
            }
            
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            string strBrand = "Nhãn hiệu máy tính xách tay";
            int num = 0;
            if (ds.Tables[0].Rows.Count> 0)
            {
                num = ds.Tables[0].Rows.Count;
                str += "<table width='220' border='0' cellpadding='0' cellspacing='0' bgcolor='#FFF1EA'>";
                str += "<tr><td colspan='3' class='text_b3'>";
                str += strBrand;
                str += "</td></tr>";
                str += "<tr><td height='4'></td></tr>";
                str += "<tr class='text_title'><td align='left'>";
                for (int i = 0; i < num; i++)
                {

                    if (StateId.Equals("0"))
                    {
                        str += "<div style='padding:3px;'><a href='default.html?menu=dasp&brand=" + ds.Tables[0].Rows[i]["Id"].ToString() + "'>" + ds.Tables[0].Rows[i]["name"].ToString() + "</a></div>";
                    }
                    else
                    {
                        str += "<div style='padding:3px;'><a href='default.html?menu=dasp&state=" + StateId + "&brand=" + ds.Tables[0].Rows[i]["Id"].ToString() + "'>" + ds.Tables[0].Rows[i]["name"].ToString() + "</a></div>"; ;
                    }
                   
                }
                 str += "</td></tr>";
                str += "<tr><td height='4'></td></tr>";
            }
                str += "</table>";
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
        string str_search = "";
        string tadvance = "";
        string tcolor = "";
        string tlocation = "";
        try
        {
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            tsearch = hash["tsearch"].ToString();
            tPrice = hash["slprice"].ToString();
            tBrand = hash["slbrand"].ToString();
            tCpu = hash["slcpu"].ToString();
            tScreen = hash["slscreen"].ToString();
            tlocation = hash["sllocation"].ToString();
            tbl_search = hash["blsearch"].ToString();
            tadvance = hash["avsearch"].ToString();
            tcolor = hash["tcolor"].ToString();
        }
        catch
        { }
        string[] values = GetValueSearch(tsearch, tPrice, tBrand, tCpu, tScreen, tcolor);
        str = "<table width='100%' cellpadding='0' cellspacing='0'>";
        str += "<tr><td class='bg_b1'></td><td class='bg_b2'><div class='text_bl'>" + tlocation + "</div></td><td class='bg_b3'></td></tr>";
        str += "<tr><td class='bg_b4'></td><td class='text_2'>";
        str += "<div class='divaddress'>" + values[5] + "</div>";
        str += "</td><td class='bg_b5'></td></tr>";
        str += "<tr><td class='bg_b7' colspan='3'></td></tr>";
        str += "<tr><td height='8'></td></tr></table>";  
        str += "<table width='100%' cellpadding='0' cellspacing='0'>";
        str += "<tr><td class='bg_b1'></td><td class='bg_b2'><div class='text_bl'>" + tbl_search + "</div></td><td class='bg_b3'></td></tr>";
        str += "<tr><td class='bg_b4'></td><td>";
        str_search = "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
        str_search += " <tr><td height='5'></td></tr>";
        str_search += " <tr><td height='2'></td><td></td></tr>";
        str_search += "<tr align='center'><td>" + values[1] + "</td></tr>";
        str_search += " <tr><td height='2'></td><td></td></tr>";
        str_search += "<tr align='center'><td>" + values[0] + "</td></tr>";
        str_search += " <tr><td height='2'></td><td></td></tr>";
        str_search += "<tr align='center'><td>" + values[2] + "</td></tr>";
        str_search += " <tr><td height='2'></td><td></td></tr>";
        str_search += "<tr align='center'><td>" + values[3] + "</td></tr>";
        str_search += " <tr><td height='2'></td></tr>";
        str_search += "<tr align='center'><td>" + values[4] + "</td></tr>";
        str_search += " <tr><td height='2'></td></tr>";
        str_search += "<tr align='center'><td><input type='text' style='width:144px;' id='txtsearchq' onkeydown=\"OnEnterSend(event,'btSearchMain');\" /></td></tr>";
        str_search += "<tr align='center'><td class='text_5'><input type='button' class='button3' id='btSearchMain' onclick=\"OnClickSearch();\" value='" + tsearch + "'/></td></tr>";
        str_search += "<tr align='center'><td class='text_title'><a href='default.html?menu=asp'>" + tadvance + "</a></td></tr>";
        str_search += "</table>";
        str += str_search;
        str += "</td><td class='bg_b5'></td></tr>";
        str += "<tr><td class='bg_b7' colspan='3'></td></tr>";
        str += "<tr><td height='8'></td></tr></table>";
        return str;
    }
    public string[] GetValueSearch(string tsearch, string tPrice, string tBrand, string tCpu, string tScreen, string tcolor)
    {
        string[] values = new string[8] { "", "", "", "", "", "", "", "" };
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
            str = "<select class='text_box2' id='slpriceq'>";
            str += "<option value='0'>" + tPrice + "</option>";
            for (int i = 0; i < numNode; i++)
            {
                string value = nodes[i].ChildNodes[1].InnerText + "," + nodes[i].ChildNodes[2].InnerText;
                str += "<option value='" + value + "'>" + nodes[i].ChildNodes[0].InnerText + "</option>";
            }
            str += "</select>";
            values[0] = str;
            //Get Brand:
            DataSet ds = new BrandProductSystem().BrandProAllType((int)Application["idtypeproduct"]);
            numNode = ds.Tables[0].Rows.Count;
            str = "<select class='text_box2' id='slbrandq'>";
            str += "<option value='0'>" + tBrand + "</option>";
            for (int i = 0; i < numNode; i++)
            {
                str += "<option value='" + ds.Tables[0].Rows[i]["id"].ToString() + "'>" + ds.Tables[0].Rows[i]["name"].ToString() + "</option>";
            }
            str += "</select>";
            values[1] = str;
            //Get Cpu:
            reader = new XmlTextReader(path + "cpusearch.xml");
            doc.Load(reader);
            reader.Close();
            nodes = doc.SelectNodes("/root/search");
            numNode = nodes.Count;
            str = "<select class='text_box2' id='slcpuq'>";
            str += "<option value='0'>" + tCpu + "</option>";
            for (int i = 0; i < numNode; i++)
            {
                str += "<option value='" + nodes[i].ChildNodes[1].InnerText + "'>" + nodes[i].ChildNodes[0].InnerText + "</option>";
            }
            str += "</select>";
            values[2] = str;
            //Get Screen Size:
            reader = new XmlTextReader(path + "screensize.xml");
            doc.Load(reader);
            reader.Close();
            nodes = doc.SelectNodes("/root/search");
            numNode = nodes.Count;
            str = "<select class='text_box2' id='slscreenq'>";
            str += "<option value='0'>" + tScreen + "</option>";
            for (int i = 0; i < numNode; i++)
            {
                str += "<option value='" + nodes[i].ChildNodes[1].InnerText + "'>" + nodes[i].ChildNodes[0].InnerText + "</option>";
            }
            str += "</select>";
            values[3] = str;

            //Get Color product:
            reader = new XmlTextReader(path + "colorsearch.xml");
            doc.Load(reader);
            reader.Close();
            nodes = doc.SelectNodes("/root/search");
            numNode = nodes.Count;
            str = "<select class='text_box2' id='slcolorq'>";
            str += "<option value='0'>" + tcolor + "</option>";
            for (int i = 0; i < numNode; i++)
            {
                str += "<option value='" + nodes[i].ChildNodes[1].InnerText + "'>" + nodes[i].ChildNodes[0].InnerText + "</option>";
            }
            str += "</select>";
            values[4] = str;
            //Get Location:
            reader = new XmlTextReader(path + "location.xml");
            doc.Load(reader);
            reader.Close();
            nodes = doc.SelectNodes("/root/search");
            numNode = nodes.Count;
            str = "";
            //Chỗ này có phân cấp note:
            XmlNodeList subNode;
            string alert = "";
            for (int i = 0; i < numNode; i++)
            {
                alert = "";
                if (nodes[i].ChildNodes[0].Attributes["alert"] != null)
                {
                    alert = "title='" + nodes[i].ChildNodes[0].Attributes["alert"].InnerText + "'";
                }
                str += "&raquo;<a " + alert + " href='default.html?menu=dasp&address=" + nodes[i].ChildNodes[1].InnerText + "'>" + nodes[i].ChildNodes[0].InnerText + "</a><br />";
                if (nodes[i].ChildNodes.Count >2)
                {
                    //subNode = nodes[i].ChildNodes;
                    subNode = nodes[i].ChildNodes[2].ChildNodes;
                    int numsub = subNode.Count;
                    for (int j = 0; j < numsub; j++)
                    {
                        str += "&nbsp;&nbsp; &#8226; <a href='default.html?menu=dasp&address=" + subNode[j].InnerText + "'>" + subNode[j].Attributes["text"].InnerText + "</a><br />";
                    }
                }
            }
            values[5] = str;
        }
        catch
        {

        }
        return values;
    }
}