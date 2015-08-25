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
/*
 *Create by : sunglb
 *Datetime  : 06/11/2007
 *Used      : mainpage.... 
 */
public partial class _Default : System.Web.UI.Page 
{
    public string footer = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //SetOnline:
            if (Session["online"] == null)
            {
                Session["online"] = true;
                SetVisited();
            }
            if (Application["idtypemobile"] == null)
            {
                //Application["ratepromain"] = 1;
                SetAppTypeProduct();
            }
            Application["ratepromobi"] = SetRateProduct(Application["idtypemobile"].ToString());
            //For language support:
            if(Application["langsupport"] == null)
            { 
                //Read Languagesupport:
                string _fileSupport = Server.MapPath("../data/xml/language_support.xml");
                XmlDocument _docfile = new XmlDocument();
                XmlTextReader _reader = new XmlTextReader(_fileSupport);
                _docfile.Load(_reader);
                _reader.Close();
                XmlNodeList _listNode = _docfile.SelectNodes("/lang_support/lang");
                int numSupport = _listNode.Count;
                ArrayList _list = new ArrayList();
                string _urlFileLang=Server.MapPath("../data/xml/");
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
            SupportOnline();
            plhheader.Controls.Add(Page.LoadControl("block/header.ascx"));
            plhleft.Controls.Add(Page.LoadControl("block/left.ascx"));
            plhright.Controls.Add(Page.LoadControl("block/right.ascx"));
            plhcenter.Controls.Add(Page.LoadControl("block/center.ascx"));
            if (Application["AppMobileFooter"] == null)
            {
                StreamReader myFile = new StreamReader(Server.MapPath("data/file/footer.txt"));
                footer = myFile.ReadToEnd();
                Application["AppMobileFooter"] = footer;
                myFile.Close();
            }
            else
            {
                footer = Application["AppMobileFooter"].ToString();
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
                string fileVisit = Server.MapPath("../data/xml/visited.xml");
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
                string fileVisit = Server.MapPath("../data/xml/visited.xml");
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
            string xpath = Server.MapPath("../data/xml/configproduct.xml");
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
        if (Application["currencymobile"] != null)
        {
            if (Application["currencymobile"].Equals("USD"))
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
    private void SupportOnline()
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
                        strOnline += "&nbsp;<a href ='ymsgr:sendim?" + dsOnline.Tables[0].Rows[i]["nickname"].ToString() + "'><img src='http://opi.yahoo.com/online?u=" + dsOnline.Tables[0].Rows[i]["nickname"].ToString() + "' border='0' style='vertical-align:middle'/> " + name + "</a></td></tr>";
                        if (i < numOnline - 1 && idgroup1 == dsOnline.Tables[0].Rows[i + 1]["idgroup"].ToString())
                        {
                            strOnline += "<tr><td class='line1'></td></tr>";
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
        }
        catch
        { }
    }
}
