using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;
namespace framework.list.lang
{
    public class Lang_code
    {
        string language_code_file;
        XPathNavigator nav;
        XPathExpression expr;
        XPathNodeIterator iterator;

        #region Ham khoi dung doi tuong
        public void SetFile(string filename)
        {
            this.language_code_file = filename;
        }
        #endregion

        #region Ham thuc hien viec insert mot ban ghi

        public string InsertRecord(string key,string des)
        {
            string test = "";           
            string inner = "";

            XmlTextReader reader = new XmlTextReader(this.language_code_file);
            XmlDocument doc1 = new XmlDocument();
            doc1.Load(reader);
            reader.Close();

            try
            {
                XmlNode currentNode;
                XmlDocumentFragment docfrag = doc1.CreateDocumentFragment();
                //kiem tra xem tu khoa da ton tai hay chua                
                nav = doc1.CreateNavigator();
                expr = nav.Compile("/language_code/code[key='"+key+"']");
                iterator = nav.Select(expr);
                if(iterator.Count!=0)
                {
                    test = "Từ khóa này đã tồn tại. Không thể thêm mới !";
                }
                else
                {
                    inner = "<code>" +
                            "<key>" + key + "</key>" +
                            "<des>" + des + "</des>";
                    inner=inner+"</code>";                                
                    docfrag.InnerXml = inner;
                    currentNode = doc1.DocumentElement;
                    currentNode.InsertAfter(docfrag, currentNode.LastChild);
                    doc1.Save(this.language_code_file);
                    test = "";
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                test = "Quyền cập nhập file đã khóa. Không thể thêm mới!";
            }

            return test;
        }

        #endregion

        #region Ham thuc hien Edit mot ban ghi
        public string EditRecord(string key,string key_edit,string des)
        {
            string test = "";
            //string inner = "";
            try
            {
                XmlTextReader reader = new XmlTextReader(language_code_file);
                XmlDocument doc = new XmlDocument();
                doc.Load(reader);
                reader.Close();
                //Khai bao nut Threshold cu
                
                //kiem tra key trung lap
                if (key.Equals(key_edit))
                {
                    nav = doc.CreateNavigator();
                    expr = nav.Compile("/language_code/code[key='" + key_edit + "']");
                    iterator = nav.Select(expr);                    
                    if (iterator.Count==0)
                    {
                        test = "Từ khóa không còn tồn tại. Không thể chỉnh sửa.";
                    }
                    else
                    {
                        if (iterator.MoveNext())
                        {
                            XPathNavigator nav2 = iterator.Current.Clone();
                            nav2.MoveToFirstChild();
                            nav2.SetValue(key_edit); 
                            nav2.MoveToNext();                                                                                
                            //gan des
                            nav2.SetValue(des.ToString());    
                            doc.Save(language_code_file);
                            test = "";
                        }
                      }                                         
                }
                else
                {
                    nav = doc.CreateNavigator();
                    expr = nav.Compile("/language_code/code[key='" + key_edit  + "']");
                    iterator = nav.Select(expr);
                    if (iterator.Count > 0)
                    {
                        test = "Từ khóa này đã tồn tại với mã khác. Không thể chỉnh sửa.";
                    }
                    else
                    {
                        expr = nav.Compile("/language_code/code[key='" + key + "']");
                        iterator = nav.Select(expr);
                        if (iterator.Count == 0)
                        {
                            test = "Từ khóa không còn tồn tại. Không thể chỉnh sửa.";
                        }
                        else
                        {
                            if (iterator.MoveNext())
                            {
                                XPathNavigator nav2 = iterator.Current.Clone();
                                nav2.MoveToFirstChild();
                                nav2.SetValue(key_edit);
                                nav2.MoveToNext();                                
                                //gan des
                                nav2.SetValue(des.ToString());
                                //Lui lai file XML
                                doc.Save(language_code_file);
                                test = "";   
                            }
                        }
                      }                                                             
                }                                                                                               
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                test = "Quyền cập nhập file đã khóa. Không thể chỉnh sửa!";
            }
            return test;
        }
        #endregion

        #region select all languagecode
        public XPathNodeIterator GetLanguageCode()
        {
            XPathDocument doc = new XPathDocument(this.language_code_file);
            nav = doc.CreateNavigator();
            XPathNodeIterator nodes = nav.Select("/language_code/code");
            return nodes;
        }
        #endregion
    }
}
