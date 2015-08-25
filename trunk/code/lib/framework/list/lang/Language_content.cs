using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using framework.list.common;
using System.IO;

namespace framework.list.lang
{
    public class Language_content
    {
        string langs_file;
        XPathNavigator nav;
        XPathExpression expr;
        XPathNodeIterator iterator;  
        #region Ham khoi dung doi tuong
        public void SetFile(string filename)
        {
            this.langs_file = filename;
        }
        #endregion
        //ham kiem tra ton tai file hay khong
        public bool IsExitsFile()
        {
            if (File.Exists(langs_file))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #region Ham thuc hien viec insert mot ban ghi

        public string InsertRecord(string key,string content)
        {
            string test = "";           
            string inner = "";
            if (IsExitsFile())
            {
                XmlTextReader reader = new XmlTextReader(this.langs_file);
                XmlDocument doc1 = new XmlDocument();
                doc1.Load(reader);
                reader.Close();

                try
                {
                    XmlNode currentNode;
                    XmlDocumentFragment docfrag = doc1.CreateDocumentFragment();
                    //kiem tra xem tu khoa da ton tai hay chua                
                    nav = doc1.CreateNavigator();
                    expr = nav.Compile("/langs/lang[key='" + key + "']");
                    iterator = nav.Select(expr);
                    if (iterator.Count != 0)
                    {
                        test = " Từ khóa đã tồn tại. Không thể thêm mới. !";
                    }
                    else
                    {
                        inner = "<lang>" +
                                "<key>" + key + "</key>" +
                                "<value>" + content + "</value>";
                        inner = inner + "</lang>";
                        docfrag.InnerXml = inner;
                        currentNode = doc1.DocumentElement;
                        currentNode.InsertAfter(docfrag, currentNode.LastChild);
                        doc1.Save(this.langs_file);
                        test = "";
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                    test = "Quyền cập nhập file đã khóa. Không thể thêm mới!";
                }
            }
            else
            {
                test = "FileNoEixts";
            }

            return test;
        }

        #endregion

        #region Ham thuc hien Edit mot ban ghi
        public string EditRecord(string key, string key_edit, string content)
        {
            string test = "";
            //string inner = "";
            if (IsExitsFile())
            {
                try
                {
                    XmlTextReader reader = new XmlTextReader(this.langs_file);
                    XmlDocument doc = new XmlDocument();
                    doc.Load(reader);
                    reader.Close();
                    //Khai bao nut Threshold cu

                    //kiem tra key trung lap
                    if (key.Equals(key_edit))
                    {
                        nav = doc.CreateNavigator();
                        expr = nav.Compile("/langs/lang[key='" + key_edit + "']");
                        iterator = nav.Select(expr);
                        if (iterator.Count == 0)
                        {
                            test = "Từ khóa đã bị xóa. Không thể chỉnh sửa nội dung.";
                        }
                        else
                        {
                            if (iterator.MoveNext())
                            {
                                XPathNavigator nav2 = iterator.Current.Clone();
                                nav2.MoveToFirstChild();
                                nav2.SetValue(key_edit);
                                nav2.MoveToNext();                                
                                //gan content
                                nav2.SetValue(content.ToString());
                            }
                            //Lui lai file XML
                            doc.Save(this.langs_file);
                            test = "";
                        }                      

                    }
                    else
                    {
                        nav = doc.CreateNavigator();
                        expr = nav.Compile("/langs/lang[key='" + key_edit + "']");
                        iterator = nav.Select(expr);
                        if (iterator.Count > 0)
                        {
                            test = "Từ khóa này đã tồn tại với mã khác. Không thể chỉnh sửa.";
                        }
                        else
                        {
                            expr = nav.Compile("/langs/lang[key='" + key + "']");
                            iterator = nav.Select(expr);
                            if (iterator.Count == 0)
                            {
                                test = "Từ khóa đã bị xóa. Không thể chỉnh sửa nội dung.";
                            }
                            else
                            {
                                if (iterator.MoveNext())
                                {
                                    XPathNavigator nav2 = iterator.Current.Clone();
                                    nav2.MoveToFirstChild();
                                    nav2.SetValue(key_edit);
                                    nav2.MoveToNext();
                                    //gan content
                                    nav2.SetValue(content.ToString());
                                }
                                //Lui lai file XML
                                doc.Save(this.langs_file);
                                test = "";
                            }
                        }                                                                     
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                    test = "Quyền cập nhật file đã khóa. Không thể chỉnh sửa nội dung!";
                }
            }
            else
            {
                test = "FileNoEixts";
            }
            return test;
        }
        #endregion

        //#region select all languagecode
        //public XPathNodeIterator GetLanguageCode()
        //{
        //    XPathDocument doc = new XPathDocument(this.language_code_file);
        //    nav = doc.CreateNavigator();
        //    XPathNodeIterator nodes = nav.Select("/language_code/code");
        //    return nodes;
        //}
        //#endregion
    }    
}
