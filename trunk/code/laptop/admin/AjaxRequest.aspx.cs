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
using framework.list.common;
public partial class admin_AjaxRequest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string menu=Request.QueryString["menu"].ToString();
            string strmobile="";
            switch (menu)
            {
                case ("imgpro"):
                    {
                        try
                        {
                            string id = Request.QueryString["id"].ToString();
                            string name = Request.QueryString["name"].ToString();
                            string namepro = Request.QueryString["namepro"].ToString();
                            string subName = "";
                            int leng = namepro.Length;
                            for (int i = 0; i < leng; i++)
                            { 
                                if(namepro[i].Equals('('))
                                    break;
                                if(!namepro[i].Equals(','))
                                {
                                    subName += namepro[i];
                                }
                            }
                            subName = subName.Trim();
                            Session["SSIdProUpload"] = id + "," + name + "," + subName;
                        }
                        catch
                        { 
                        
                        }
                        Response.Write("ok");
                        break;
                    }
                case ("bestsell"):
                    {
                        string strreturn = "";
                        try
                        {
                            string type=Request.QueryString["type"].ToString();
                            string id = Request.QueryString["id"].ToString();
                            ProductBestSellSystem products = new ProductBestSellSystem();
                            Boolean test = products.ProductBestUpdate(int.Parse(id), int.Parse(type));
                            if (!test)
                            {
                                strreturn = "err";
                            }
                            else
                            {
                                //ProductMainPage_data ds = new ProductBestSellSystem().ProductBestSellAll();
                                //Application["appProductBestsell"] = ds.Tables[ProductMainPage_data._table];
                            }
                        }
                        catch
                        {
                            strreturn = "err";
                        }
                        Response.Write(strreturn);
                    }
                    break;
                case ("justhave"):
                    {
                        string strreturn = "";
                        try
                        {
                            string type = Request.QueryString["type"].ToString();
                            string id = Request.QueryString["id"].ToString();
                            ProductBestSellSystem products = new ProductBestSellSystem();
                            Boolean test = products.ProductJustHaveUpdate(int.Parse(id), int.Parse(type));
                            if (!test)
                            {
                                strreturn = "err";
                            }
                            else
                            {
                                //ProductMainPage_data ds = new ProductBestSellSystem().ProductBestSellAll();
                                //Application["appProductBestsell"] = ds.Tables[ProductMainPage_data._table];
                            }
                        }
                        catch
                        {
                            strreturn = "err";
                        }
                        Response.Write(strreturn);
                    }
                    break;
                    //prepare out:
                case ("prepareout"):
                    {
                        string PrepareStr = "";
                        try
                        {
                            string type = Request.QueryString["type"].ToString();
                            string id = Request.QueryString["id"].ToString();
                            ProductBestSellSystem products = new ProductBestSellSystem();
                            Boolean test = products.ProductPrepareoutUpdate(int.Parse(id), int.Parse(type));
                            if (!test)
                            {
                                PrepareStr = "err";
                            }
                            else
                            {
                                //ProductMainPage_data ds = new ProductBestSellSystem().ProductBestSellAll();
                                //Application["appProductBestsell"] = ds.Tables[ProductMainPage_data._table];
                            }
                        }
                        catch
                        {
                            PrepareStr = "err";
                        }
                        Response.Write(PrepareStr);
                    }
                    break;
                //proselloff:
                case ("proselloff"):
                    {
                        string strselloff = "";
                        try
                        {
                            string type = Request.QueryString["type"].ToString();
                            string id = Request.QueryString["id"].ToString();
                            float price = float.Parse(Request.QueryString["price"].ToString());
                            ProductBestSellSystem products = new ProductBestSellSystem();
                            Boolean test = products.ProductSelloffUpdate(int.Parse(id), int.Parse(type),price);
                            if (!test)
                            {
                                strselloff = "err";
                            }
                            else
                            {
                                //ProductMainPage_data ds = new ProductBestSellSystem().ProductBestSellAll();
                                //Application["appProductBestsell"] = ds.Tables[ProductMainPage_data._table];
                            }
                        }
                        catch
                        {
                            strselloff = "err";
                        }
                        Response.Write(strselloff);
                    }
                    break;
                case ("mainpage"):
                    string strmain = "";
                    try
                    {
                        string type = Request.QueryString["type"].ToString();
                        string id = Request.QueryString["id"].ToString();
                        string sort = Request.QueryString["sort"].ToString();
                        ProductMainPageSystem products = new ProductMainPageSystem();
                        Boolean test = products.ProductMainpageUpdate(int.Parse(id), int.Parse(type),int.Parse(sort));
                        if (!test)
                        {
                            strmain = "err";
                        }
                    }
                    catch
                    {
                        strmain = "err";
                    }
                    Response.Write(strmain);
                    break;
                case ("original"):
                string stroriginal = "";
                try
                {
                    string type = Request.QueryString["type"].ToString();
                    string id = Request.QueryString["id"].ToString();
                    string sort = Request.QueryString["sort"].ToString();
                    ProductMainPageSystem products = new ProductMainPageSystem();
                    Boolean test = products.ProductOriginalUpdate(int.Parse(id), int.Parse(type), int.Parse(sort));
                    if (!test)
                    {
                        stroriginal = "err";
                    }
                }
                catch
                {
                    strmain = "err";
                }
                Response.Write(stroriginal);
                break;
                case ("dgroup"):
                    string strdelete = "";
                    try
                    { 
                        string id=Request.QueryString["id"].ToString();
                        ArticleManagerSystem Articles = new ArticleManagerSystem();
                        
                        if (Articles.AdminGroupDeleteId(id))
                        {
                            strdelete = "1";
                        }
                        else
                        {
                            strdelete = "0";
                        }   
                    }catch
                    {
                        strdelete = "0";
                    }
                    Response.Write(strdelete);
                    break;
                case ("dgcontact"):
                    string strdcontact = "";
                    try
                    {
                        string id = Request.QueryString["id"].ToString();
                        ContacstSystem Contacts = new ContacstSystem();

                        if (Contacts.GroupContactDeleteId(id))
                        {
                            strdcontact = "1";
                        }
                        else
                        {
                            strdcontact = "0";
                        }
                    }
                    catch
                    {
                        strdcontact = "0";
                    }
                    Response.Write(strdcontact);
                    break;
                case ("dglocation"):
                    string strdlocation = "";
                    try
                    {
                        string id = Request.QueryString["id"].ToString();
                        ContacstSystem Contacts = new ContacstSystem();

                        if (Contacts.LocationContactDelete(id))
                        {
                            strdlocation = "1";
                        }
                        else
                        {
                            strdlocation = "0";
                        }
                    }
                    catch
                    {
                        strdlocation = "0";
                    }
                    Response.Write(strdlocation);
                    break;
                case ("dhelp"):
                    string strdhelp = "0";
                    try
                    {
                        string id = Request.QueryString["id"].ToString();
                        HelpsSystem helps = new HelpsSystem();

                        if (helps.HelpsDelete(id))
                        {
                            strdhelp = "1";
                        }
                    }
                    catch
                    {
                        strdhelp = "0";
                    }
                    Response.Write(strdhelp);
                    break;
                case ("donline"):
                    string stronline = "0";
                    try
                    {
                        string id = Request.QueryString["id"].ToString();
                        SupportOnlineSystem Support = new SupportOnlineSystem();
                        if (Support.OnlineDelete(id))
                        {
                            stronline = "1";
                            Application["appOnline"] = null;
                        }
                    }
                    catch
                    {
                        stronline = "0";
                    }
                    Response.Write(stronline);
                    break;
                case ("dadvertise"):
                    string strdadvertise = "0";
                    try
                    {
                        string id = Request.QueryString["id"].ToString();
                        AdvertiseSystem advertise = new AdvertiseSystem();
                        DataSet ds = advertise.AdvertiseSelectId(id);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            string url1 = ds.Tables[0].Rows[0]["urlimage"].ToString();
                            string path = Server.MapPath("../image/advertise/");
                            CvalidateImageForPost manageImage = new CvalidateImageForPost();
                            if (url1.Length > 0)
                            {
                                manageImage.DeleteFile(path + url1);
                            }
                        }
                        if (advertise.AdvertiseDelete(id))
                        {
                            strdadvertise = "1";
                            Application["appAdvertiset"] = null;
                        }
                    }
                    catch
                    {
                        strdadvertise = "0";
                    }
                    Response.Write(strdadvertise);
                    break;
                case ("dadvertisespecial"):
                    string strspecial = "0";
                    try
                    {
                        string id = Request.QueryString["id"].ToString();
                        AdvertiseSystem advertise = new AdvertiseSystem();
                        DataSet ds = advertise.SpecialSelectId(int.Parse(id));
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            string url1 = ds.Tables[0].Rows[0]["urlimage1"].ToString();
                            string url2 = ds.Tables[0].Rows[0]["urlimage2"].ToString();
                            string path = Server.MapPath("../image/advertise/");
                            CvalidateImageForPost manageImage = new CvalidateImageForPost();
                            if (url1.Length > 0)
                            {
                                manageImage.DeleteFile(path + url1);
                            }
                            if (url2.Length > 0)
                            {
                                manageImage.DeleteFile(path + url2);
                            }
                        }
                        if (advertise.SpecialDelete(id))
                        {
                            strspecial = "1";
                        }
                    }
                    catch
                    {
                        strspecial = "0";
                    }
                    Response.Write(strspecial);
                    break;
                case "darticle":
                    string strdarticle = "0";
                    try
                    {
                        string id = Request.QueryString["id"].ToString();
                        ArticleManagerSystem article = new ArticleManagerSystem();
                        DataSet ds = article.ArticleSelectDetail(int.Parse(id));
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            string url1 = ds.Tables[0].Rows[0]["urlimage"].ToString();
                            string path = Server.MapPath("../image/img_article/");
                            CvalidateImageForPost manageImage = new CvalidateImageForPost();
                            if (url1.Length > 0)
                            {
                                manageImage.DeleteFile(path + url1);
                            }
                        }
                        if (article.AdminArticleDelete(id))
                        {
                            strdarticle = "1";
                        }
                    }
                    catch
                    {
                        strdarticle = "0";
                    }
                    Response.Write(strdarticle);
                    break;
                    //for mobile:
                case "mobile1":
                    try
                    {
                        string type = Request.QueryString["type"].ToString();
                        string id = Request.QueryString["id"].ToString();
                        string sort = Request.QueryString["sort"].ToString();
                        string insert = Request.QueryString["insert"].ToString();
                        Mobilesystem Mobile = new Mobilesystem();
                        Boolean test = Mobile.MobileUpdate(int.Parse(id), int.Parse(insert), int.Parse(type), int.Parse(sort));
                        if (!test)
                        {
                            strmobile= "err";
                        }
                    }
                    catch
                    {
                        strmobile = "err";
                    }
                    Response.Write(strmobile);
                    break;
            }
        }
        catch
        {
        
        }
    }
}