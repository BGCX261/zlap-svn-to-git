using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml.XPath;
namespace framework.list.lang
{
    public class Clanguage
    {
        private string urlFile = "";
        private string nameFile = "";
        private Hashtable hash = new Hashtable();
        public void SetUrlFile(string url)
        {
            this.urlFile = url;
        }
        public void SetNameFile(string namefile)
        {
            this.nameFile = namefile;
        }
        public Hashtable GetHash()
        {
            return hash;
        }
        public Hashtable ReadLanguage()
        {
            try
            {
                XPathDocument XpathDoc = new XPathDocument(urlFile + nameFile);
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
                    hash.Add(key, value);
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
