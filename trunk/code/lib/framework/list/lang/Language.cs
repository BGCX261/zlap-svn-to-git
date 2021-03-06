using System;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using framework.list.common;
namespace framework.list.lang
{
    public class Language
    {
        string language_support_file;
        XPathNavigator nav;
        XPathExpression expr;
        XPathNodeIterator iterator;
        CGetDataCommon data_common = new CGetDataCommon();

        #region Ham khoi dung doi tuong
        public void SetFile(string filename)
        {
            this.language_support_file = filename;
        }
        #endregion

        #region select all language
        public XPathNodeIterator GetLanguage()
        {
            XPathDocument doc = new XPathDocument(this.language_support_file);
            nav = doc.CreateNavigator();
            XPathNodeIterator nodes = nav.Select("/lang_support/lang");
            return nodes;
        }
        #endregion

        #region select language by id
        public XPathNodeIterator GetLanguageById(string id)
        {
            XPathDocument doc = new XPathDocument(this.language_support_file);
            nav = doc.CreateNavigator();
            XPathNodeIterator nodes = nav.Select("/lang_support/lang[id='" + id +"']");
            return nodes;
        }
        #endregion
        #region select language by file name
        public XPathNodeIterator GetLanguageByFileName(string file_name)
        {
            XPathDocument doc = new XPathDocument(this.language_support_file);
            nav = doc.CreateNavigator();
            XPathNodeIterator nodes = nav.Select("/lang_support/lang[url='" + file_name + ".xml" + "']");
            return nodes;
        }
        #endregion
        #region select language by language name
        public XPathNodeIterator GetLanguageByName(string name)
        {
            XPathDocument doc = new XPathDocument(this.language_support_file);
            nav = doc.CreateNavigator();
            XPathNodeIterator nodes = nav.Select("/lang_support/lang[name='" + name + "']");
            return nodes;
        }
        #endregion
        #region select language by Abbreviate
        public XPathNodeIterator GetLanguageByAbbreviate(string Abbreviate)
        {
            XPathDocument doc = new XPathDocument(this.language_support_file);
            nav = doc.CreateNavigator();
            XPathNodeIterator nodes = nav.Select("/lang_support/lang[abbreviate='" + Abbreviate + "']");
            return nodes;
        }
        #endregion

        #region Insert Language
        public bool LanguageInsert(string name, string abbreviate, string url, string flag)
        {
            bool result = true;
            bool test = false;
            int id = 0;
            XmlTextReader reader = new XmlTextReader(language_support_file);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            reader.Close();

            try
            {
                XmlNode currentNode;
                XmlDocumentFragment docfrag = doc.CreateDocumentFragment();

                while (!test)
                {
                    id = data_common.CreateNumRandom();
                    nav = doc.CreateNavigator();
                    expr = nav.Compile("/lang_support/lang[id='" + id.ToString() + "']");
                    iterator = nav.Select(expr);
                    if (iterator.Count > 0)
                    {
                        test = false;
                    }
                    else
                    {
                        test = true;
                    }
                }

                if (test == true)
                {
                    docfrag.InnerXml = "<lang>" +
                                       "<id>" + id.ToString() + "</id>" +
                                       "<name>" + name + "</name>" +
                                       "<abbreviate>" + abbreviate + "</abbreviate>" +
                                       "<url>" + url + ".xml" + "</url>" +
                                       "<flag>" + flag + "</flag>" +
                                       "<active>0</active>" +
                                       "</lang>";

                    currentNode = doc.DocumentElement;
                    currentNode.InsertAfter(docfrag, currentNode.LastChild);
                    doc.Save(language_support_file);
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                result = false;
                Console.Write(ex.ToString());
            }
            return result;
        }
        #endregion

        #region Ham thuc hien Edit mot ban ghi
        public string LanguageEdit(string id, string name, string abbreviate, string url, string flag,string active)
        {
            string test = "";
            try
            {
                XmlTextReader reader = new XmlTextReader(language_support_file);
                XmlDocument doc = new XmlDocument();
                doc.Load(reader);
                reader.Close();
                XmlElement root = doc.DocumentElement;
                //Thuc hien 
                if (active.Equals("2"))
                {
                    //XmlNode lang1 = root.SelectSingleNode("/lang_support/lang[active='2']");
                    XmlNode lang = root.SelectSingleNode("/lang_support/lang[active='2']");
                    XmlNode oldActive;
                    oldActive = root.SelectSingleNode("/lang_support/lang[active='2']/active");
                    if (oldActive != null)
                    {
                        XmlElement newActive = doc.CreateElement("active");

                        newActive.InnerXml = "1";
                        //Thay the nut hien tai bang nut moi
                        lang.ReplaceChild(newActive, oldActive);
                    }
                    //root.ReplaceChild(lang2,lang1);
                }
                //Khai bao nut Lang cu
                XmlNode oldLang;
                
                oldLang = root.SelectSingleNode("/lang_support/lang[id='" + id + "']");
                if (oldLang != null)
                {
                    XmlElement newLang= doc.CreateElement("lang");

                    newLang.InnerXml =
                                       "<id>" + id.ToString() + "</id>" +
                                       "<name>" + name + "</name>" +
                                       "<abbreviate>" + abbreviate + "</abbreviate>" +
                                       "<url>" + url + ".xml" + "</url>" +
                                       "<flag>" + flag + "</flag>" +
                                       "<active>" + active + "</active>";
                    //Thay the nut hien tai bang nut moi
                    root.ReplaceChild(newLang, oldLang);
                    //Lui lai file XML
                    doc.Save(language_support_file);
                    test = "";
                }
                else
                    test = "Mã ngôn ngữ không còn tồn tại, không thể chỉnh sửa !";
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                test = "Quyền cập nhật file bị khóa. Không thể chỉnh sửa!";
            }
            return test;
        }
        #endregion
    }
}
