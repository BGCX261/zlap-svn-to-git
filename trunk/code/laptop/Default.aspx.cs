using System;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using framework.list.lang;
using facade.list;
using System.IO;
using System.Data.SqlClient;
using facade.list;
/*
 *Create by : sunglb
 *Datetime  : 06/11/2007
 *Used      : mainpage.... 
 */
public partial class _Default : System.Web.UI.Page 
{
    public string footer = "";
    string TitleDefault = "may tinh xach tay,máy tính xách tay,maytinhxachtay.com";
    public string myTitle = "";
    string KeyDefault = "máy tính xách tay,may tinh xach tay, maytinhxachtay,may tinh, may tinh laptop, may tinh xach tay, maytinhxachtay, may tinh notbook, laptop xach tay, xach tay laptop, may tinh xach tay tra gop, máy tính xách tay trả góp, laptop tra gop, laptop trả góp, máy tính nguyên ngọc, may tinh nguyen ngoc, nguyên ngọc laptop, nguyen ngoc laptop, 236-Cao Thắng nối dài, Dien Tu Sai Gon Ltd";
    public string myKey = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //SetOnline:
            myTitle = TitleDefault;
            myKey = KeyDefault;
            if (Session["online"] == null)
            {
                Session["online"] = true;
                SetVisited();
            }
            if (Application["idtypeproduct"] == null)
            {
                //Application["ratepromain"] = 1;
                SetAppTypeProduct();
            }
            Application["ratepromain"] = SetRateProduct(Application["idtypeproduct"].ToString());
            //For language support:
            if(Application["langsupport"] == null)
            { 
                //Read Languagesupport:
                string _fileSupport = Server.MapPath("data/xml/language_support.xml");
                XmlDocument _docfile = new XmlDocument();
                XmlTextReader _reader = new XmlTextReader(_fileSupport);
                _docfile.Load(_reader);
                _reader.Close();
                XmlNodeList _listNode = _docfile.SelectNodes("/lang_support/lang");
                int numSupport = _listNode.Count;
                ArrayList _list = new ArrayList();
                string _urlFileLang=Server.MapPath("data/xml/");
                for (int i = 0; i < numSupport; i++)
                {
                    XmlNodeList _subList = _listNode[i].ChildNodes;
                    string[] arrvalue = new string[3] { "", "", "" };
                    arrvalue[0] = _subList[1].InnerText;
                    arrvalue[1] = _subList[3].InnerText;
                    arrvalue[2] = _subList[4].InnerText;
                    _list.Add(arrvalue);
                    GetApplication(arrvalue[1],_urlFileLang);
                }
                Application["langsupport"] = _list;
            }
            //for Session language current:
            if (Session["langcurrent"] == null)
            {
                ArrayList _list =(ArrayList)Application["langsupport"];
                string[] arrvalue = (string[])_list[0];
                Session["langcurrent"] = arrvalue[1];
            }
            if (Application["AppDownloadPrice"] == null)
            {
                StreamReader myFile1 = new StreamReader(Server.MapPath("data/file/Downloadprice.txt"));
                Application["AppDownloadPrice"] = myFile1.ReadToEnd();
                myFile1.Close();
            }
            plhheader.Controls.Add(Page.LoadControl("block/header.ascx"));
            plhmenu.Controls.Add(Page.LoadControl("block/menu.ascx"));
            plhsearchmenu.Controls.Add(Page.LoadControl("block/searchheader.ascx"));
            plhleft.Controls.Add(Page.LoadControl("block/left.ascx"));
            plhright.Controls.Add(Page.LoadControl("block/right.ascx"));
            plhcenter.Controls.Add(Page.LoadControl("block/center.ascx"));
            if (Application["AppFooter"] == null)
            {
                StreamReader myFile = new StreamReader(Server.MapPath("data/file/footer.txt"));
                footer = myFile.ReadToEnd();
                Application["AppFooter"] = footer;
                myFile.Close();
            }
            else
            {
                footer = Application["AppFooter"].ToString();
            }
            //Create title:
            string menu = "";
            if (Request.QueryString["menu"] != null)
            {
                menu = Request.QueryString["menu"].ToString();
                if (menu == "product")
                {
                    myTitle = "may tinh xach tay,máy tính xách tay,maytinhxachtay.com";
                    myKey = "may tinh xach tay - máy tính xách tay";
                }
                else if (menu == "com")
                {
                    myTitle = "linh kien may tinh, maytinhxachtay.com";
                    myKey = "linh kien may tinh";
                }
                else if (menu == "pro")
                {
                    if (Request.QueryString["brand"] != null)
                    {
                        string brandid = Request.QueryString["brand"];
                        DataSet dsbrand = new BrandProductSystem().BrandNameWhere("where id=" + brandid);
                        if (dsbrand.Tables.Count > 0 && dsbrand.Tables[0].Rows.Count > 0)
                        {
                            myTitle = "may tinh xach tay - " + dsbrand.Tables[0].Rows[0]["Name"] + ", maytinhxachtay.com";
                            myKey = "may tinh xach tay - " + dsbrand.Tables[0].Rows[0]["Name"];
                        }
                    }
                }
                else if (menu == "dc")
                {
                    if (Request.QueryString["id"] != null)
                    {
                        string id = Request.QueryString["id"];
                        DataSet dspro = new ComponentProductSystem().ComponentNameId(id);
                        if (dspro.Tables.Count > 0 && dspro.Tables[0].Rows.Count > 0)
                        {
                            myTitle = dspro.Tables[0].Rows[0]["Name"] + ", maytinhxachtay.com";
                            myKey = dspro.Tables[0].Rows[0]["Name"] + " - may tinh xach tay";
                        }
                    }
                }
                else if (menu == "dp" || menu == "dpda")
                {
                    if (Request.QueryString["id"] != null)
                    {
                        string id = Request.QueryString["id"];
                        DataSet dspro = new ProductSystem().ProductNameId(id);
                        if (dspro.Tables.Count > 0 && dspro.Tables[0].Rows.Count > 0)
                        {
                            myTitle = dspro.Tables[0].Rows[0]["Name"] + ", maytinhxachtay.com";
                            myKey = dspro.Tables[0].Rows[0]["Name"] + " - may tinh xach tay";
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.ToString());
        }
    }
    private void SetVisited()
    {
        try
        {
            if (Application["numvisited"] == null)
            {
                string fileVisit = Server.MapPath("data/xml/visited.xml");
                XmlDocument doc = new XmlDocument();
                XmlTextReader read = new XmlTextReader(fileVisit);
                doc.Load(read);
                read.Close();
                XmlNode node = doc.SelectSingleNode("/visited");
                long numbervisit = long.Parse(node.InnerXml);
                numbervisit++;
                Application["numvisited"] = numbervisit;
                XmlElement element = doc.DocumentElement;
                element.InnerXml = numbervisit.ToString();
                doc.Save(fileVisit);
            }
            else
            {
                string fileVisit = Server.MapPath("data/xml/visited.xml");
                XmlDocument doc = new XmlDocument();
                XmlTextReader read = new XmlTextReader(fileVisit);
                doc.Load(read);
                read.Close();
                XmlNode node = doc.SelectSingleNode("/visited");
                long numbervisit = long.Parse(Application["numvisited"].ToString());
                numbervisit++;
                Application["numvisited"] = numbervisit;
                XmlElement element = doc.DocumentElement;
                element.InnerXml = numbervisit.ToString();
                doc.Save(fileVisit);
            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.ToString());
        }
    }
    private void GetApplication(string namefile,string url)
    {
        if (Application[namefile] == null)
        {
            try
            {
                Clanguage lang = new Clanguage();
                lang.SetNameFile(namefile);
                lang.SetUrlFile(url);
                Application[namefile] = lang.ReadLanguage();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }
    }
    private void SetAppTypeProduct()
    {
        try
        {
            XmlDocument doc = new XmlDocument();
            string xpath = Server.MapPath("data/xml/configproduct.xml");
            XmlTextReader reader = new XmlTextReader(xpath);
            doc.Load(reader);
            reader.Close();
            XmlNodeList nodes = doc.SelectNodes("/root/product");
            int numnodes = nodes.Count;
            for (int i = 0; i < numnodes; i++)
            {
                string nameapp = nodes.Item(i).ChildNodes[0].InnerText;
                string idtype = nodes.Item(i).ChildNodes[1].InnerText;
                string appunit = nodes.Item(i).ChildNodes[2].InnerText;
                string unit = nodes.Item(i).ChildNodes[3].InnerText;
                if (nameapp.Length > 0 && idtype.Length > 0)
                {
                    Application[nameapp] = int.Parse(idtype);
                }
                if (appunit.Length > 0 && unit.Length > 0)
                {
                    Application[appunit] = unit;
                }
            }
        }
        catch
        { 
            
        }
    }
    private float SetRateProduct(string idtype)
    {
        if (Application["currency"] != null)
        {
            if (Application["currency"].Equals("USD"))
            {
                return 1;
            }
            else
            {
                return new ProductSystem().GetCurrencyProductType(idtype);
            }
        }
        else
        {
            return 1;
        }
    }
}
