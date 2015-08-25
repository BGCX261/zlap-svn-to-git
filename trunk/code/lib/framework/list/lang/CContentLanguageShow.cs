using System;
using System.Text;
using System.Collections;
using System.Xml;
using System.Xml.XPath;
using System.Web;

namespace framework.list.lang
{
    public class CContentLanguageShow
    {
        
        //All Attribute:
        Hashtable hashLangShow = new Hashtable();
        string nameFileXmlLanguage = "";
        string urlFileXml = "";
        //All Method:
        //method Create:
        public CContentLanguageShow()
        {
            //ReadKeytoHashLangShow();
        }
        public void SetNameFileXmlLanguage(string nameFile)
        {
            this.nameFileXmlLanguage = nameFile;
        }
        public string GetNameFileXmlLanguage()
        {
            return this.nameFileXmlLanguage;
        }
        public void SetUrlFileXml(string url)
        {
            this.urlFileXml = url;
        }
        public string GetUrlFileXml()
        {
            return this.urlFileXml;
        }
        public void ReadKeytoHashLangShow()
        {
            try
            {
                string urlXmlLang = urlFileXml + nameFileXmlLanguage;
                XPathDocument XpathDoc = new XPathDocument(urlXmlLang);
                XPathNavigator nav = XpathDoc.CreateNavigator();
                XPathNodeIterator noteIters = nav.Select("langs/lang");
                while (noteIters.MoveNext())
                {
                    string key = "";
                    string value = "";
                    noteIters.Current.MoveToFirstChild();
                    key = noteIters.Current.ToString();
                    noteIters.Current.MoveToNext();
                    value = noteIters.Current.Value;
                    //value = HttpContext.Current.Server.HtmlEncode(value);
                    hashLangShow.Add(key, value);
                }
            }catch(Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }
        public Hashtable GetHashLangShow()
        {
            return this.hashLangShow;
        }
        public string GetValueLangShowWithKey(string key)
        {
            string value = "";
            try 
            {
                value = hashLangShow[key].ToString();
            }catch(Exception ex)
            {
                //No exist Key in file xml Language:
                Console.Write(ex.ToString());
            }
            return value;
        }
        public CContentLanguageShow GetContentLanguageCurrent()
        {
            if (HttpContext.Current.Session["content_lang_current"] == null)
            {
                return (CContentLanguageShow)HttpContext.Current.Application["content_lang_default"];
            }
            else
            {
                return (CContentLanguageShow)HttpContext.Current.Session["content_lang_current"];
            }
        }
    }
}
