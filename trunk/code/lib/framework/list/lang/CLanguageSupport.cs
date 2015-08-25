using System;
using System.Text;
using System.Collections;
using System.Xml;
using System.Xml.XPath;
using System.Web;

namespace framework.list.lang
{
    public class CLanguageSupport
    {
        //All Mothod:
        public Hashtable ReadLangSupport(string urlFileLangSupport)
        {
            Hashtable hash = new Hashtable();
            try
            {
                XPathDocument XpathDoc = new XPathDocument(urlFileLangSupport);
                XPathNavigator nav = XpathDoc.CreateNavigator();
                XPathNodeIterator noteIters = nav.Select("lang_support/lang[active!=0]");
                while (noteIters.MoveNext())
                {
                    string id = "";
                    string name = "";
                    string abbreviate = "";
                    string url = "";
                    string nameFlag = "";
                    string active = "";
                    string[] arrLangSupport;
                    noteIters.Current.MoveToFirstChild();
                    id = noteIters.Current.ToString();

                    noteIters.Current.MoveToNext();
                    name = noteIters.Current.Value;

                    noteIters.Current.MoveToNext();
                    abbreviate = noteIters.Current.Value;

                    noteIters.Current.MoveToNext();
                    url = noteIters.Current.Value;

                    noteIters.Current.MoveToNext();
                    nameFlag = noteIters.Current.Value;

                    noteIters.Current.MoveToNext();
                    active = noteIters.Current.Value;
                    if (active == "2")
                    {
                        arrLangSupport = new string[] { "default", name, abbreviate, url, nameFlag, active };
                    }
                    else
                    {
                        arrLangSupport = new string[] { id, name, abbreviate, url, nameFlag, active };
                    }
                    //value = HttpContext.Current.Server.HtmlEncode(value);
                    try
                    {
                        if (active == "2")
                        {
                            hash.Add("default", arrLangSupport);
                        }
                        else
                        {
                            hash.Add(id, arrLangSupport);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return hash;
        }
    }
}
