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
using framework.list.dynamicviewhelper;
using System.Xml;
using System.Xml.XPath;
using framework.list.lang;

public partial class admin_block_LanguageContent : System.Web.UI.UserControl
{
    XPathDocument doc;
    XPathNavigator nav;
    public bool Addmin_language_content = true;
    public bool Add_language_content = true;
    public bool Edit_language_content = true;
    public bool Delete_language_content = true;
    public string Name_language = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["Language_Content"] == null || Addmin_language_content == false)
        {
            Response.Redirect("AdminWebsite.aspx?menu=langsupport");
        }
        else
        {
            string[] arrStr = new string[2];
            arrStr = (string[])HttpContext.Current.Session["Language_Content"];

            //chac an thi gan lai session 

            HttpContext.Current.Session["file_language_content"] = arrStr[0];

            HttpContext.Current.Session["namePath_file_language_content"] = Server.MapPath("../data/xml/" + HttpContext.Current.Session["file_language_content"].ToString());
            string t = HttpContext.Current.Session["namePath_file_language_content"].ToString();
            //dat session cho file language_code
            if (HttpContext.Current.Session["language_code_file"] == null)
            {
                HttpContext.Current.Session["language_code_file"] = Server.MapPath("../data/xml/language_code.xml");
            }
            if (HttpContext.Current.Session["lang_support_file"] == null)
            {
                HttpContext.Current.Session["lang_support_file"] = Server.MapPath("../data/xml/language_support.xml");
            }
            Name_language = GetLanguageName();
            if (!SetApp())
            {
                Response.Redirect("AdminWebsite.aspx?menu=langsupport");
            }
            if (HttpContext.Current.Application["nav_language_code"] == null)
            {

                doc = new XPathDocument(HttpContext.Current.Session["language_code_file"].ToString());
                nav = doc.CreateNavigator();
                HttpContext.Current.Application["nav_language_code"] = nav;
            }
            SetDynamic();
        }
        AjaxPro.Utility.RegisterTypeForAjax(typeof(admin_block_LanguageContent));
    }
    //ham lay ve ten ngon ngu khi truyen ten file
    public string GetLanguageName()
    {
        string LanguageName = "";
        doc = new XPathDocument(HttpContext.Current.Session["lang_support_file"].ToString());
        nav = doc.CreateNavigator();
        XPathNodeIterator nodes = nav.Select("/lang_support/lang[url='" + HttpContext.Current.Session["file_language_content"].ToString() + "']");
        if (nodes.MoveNext())
        {
            nodes.Current.MoveToFirstChild();
            nodes.Current.MoveToNext();
            LanguageName = nodes.Current.Value;
        }
        return LanguageName;
    }

    //thiet dat cau hinh Application cho da nguoi dung
    public bool SetApp()
    {
        bool test = true;
        //if (HttpContext.Current.Application[HttpContext.Current.Session["namePath_file_language_content"].ToString()] == null)         
        try
        {
            doc = new XPathDocument(HttpContext.Current.Session["namePath_file_language_content"].ToString());
            nav = doc.CreateNavigator();
            HttpContext.Current.Application[HttpContext.Current.Session["namePath_file_language_content"].ToString()] = nav;
        }
        catch (Exception ex)
        {
            test = false;
        }

        return test;
        //if (HttpContext.Current.Application["doc_language_code_search"] == null)
        //{
        //    doc = new XPathDocument(HttpContext.Current.Session["language_code_file"].ToString());
        //    HttpContext.Current.Application["doc_language_code_search"] = doc;
        //}
    }

    //cau hinh trang tim kiem
    public void SetDynamic_Search(string key_search)
    {
        nav = (XPathNavigator)HttpContext.Current.Application[HttpContext.Current.Session["namePath_file_language_content"].ToString()];
        XPathNodeIterator nodes = nav.Select("/langs/lang[contains(key,'" + key_search + "')]");
        CDynamicviewHelperXmlLanguageContent dynamic = new CDynamicviewHelperXmlLanguageContent();

        if (HttpContext.Current.Session["language_content_dynamic_search"] == null)
        {
            int numCode = nodes.Count;
            dynamic.SetStringSeach(key_search);
            dynamic.SetNumberRecord(numCode);
            dynamic.SetPageSize(10);
            dynamic.SetCurrentPage();
            dynamic.SetNavigator(nav);
            HttpContext.Current.Session["language_content_dynamic_search"] = dynamic;
        }
        else
        {
            dynamic = (CDynamicviewHelperXmlLanguageContent)HttpContext.Current.Session["language_content_dynamic_search"];
            int numCode = nodes.Count;
            dynamic.SetStringSeach(key_search);
            dynamic.SetNumberRecord(numCode);
            dynamic.SetNavigator(nav);
            dynamic.ReSetCurrentPage();
            HttpContext.Current.Session["language_content_dynamic_search"] = dynamic;
        }
    }

    //cau hinh trang hien thi
    public void SetDynamic()
    {
        nav = (XPathNavigator)HttpContext.Current.Application[HttpContext.Current.Session["namePath_file_language_content"].ToString()];
        XPathNodeIterator nodes = nav.Select("/langs/lang");
        CDynamicviewHelperXmlLanguageContent dynamic = new CDynamicviewHelperXmlLanguageContent();
        if (HttpContext.Current.Session["language_content_dynamic"] == null)
        {
            int numCode = nodes.Count;
            dynamic.SetNumberRecord(numCode);
            dynamic.SetPageSize(10);
            dynamic.SetCurrentPage();
            dynamic.SetNavigator(nav);
            HttpContext.Current.Session["language_content_dynamic"] = dynamic;
        }
        else
        {
            dynamic = (CDynamicviewHelperXmlLanguageContent)HttpContext.Current.Session["language_content_dynamic"];
            int numCode = nodes.Count;
            dynamic.SetNumberRecord(numCode);
            dynamic.SetNavigator(nav);
            dynamic.ReSetCurrentPage();
            HttpContext.Current.Session["language_content_dynamic"] = dynamic;
        }

    }

    //hien thi du lieu
    [AjaxPro.AjaxMethod]
    public string[] ShowData(int action)
    {
        string[] arrStr = new string[6];
        string str = "";
        string err = "";
        //cau hinh hien thi trang
        Language_content language_content = new Language_content();
        language_content.SetFile(HttpContext.Current.Session["namePath_file_language_content"].ToString());
        if (language_content.IsExitsFile())
        {
            if (HttpContext.Current.Session["language_content_dynamic"] != null)
            {
                try
                {
                    CDynamicviewHelperXmlLanguageContent dynamic = (CDynamicviewHelperXmlLanguageContent)HttpContext.Current.Session["language_content_dynamic"];
                    nav = (XPathNavigator)HttpContext.Current.Application[HttpContext.Current.Session["namePath_file_language_content"].ToString()];
                    XPathNodeIterator nodes = nav.Select("/langs/lang");
                    dynamic.SetNumberRecord(nodes.Count);
                    dynamic.SetNavigator(nav);
                }
                catch (Exception ex) { Response.Write(ex.ToString()); }
            }
            else
            {
                CDynamicviewHelperXmlLanguageContent dynamic = new CDynamicviewHelperXmlLanguageContent();
                dynamic.SetNumberRecord(0);
                dynamic.ReSetCurrentPage();
                HttpContext.Current.Session["language_content_dynamic"] = dynamic;
            }
        }
        else
        {
            CDynamicviewHelperXmlLanguageContent dynamic = new CDynamicviewHelperXmlLanguageContent();
            dynamic.SetNumberRecord(0);
            dynamic.ReSetCurrentPage();
            HttpContext.Current.Session["language_content_dynamic"] = dynamic;
            err = "File ngôn ngữ đã bị xóa. không thể hiển thị";
        }

        if (HttpContext.Current.Session["language_content_dynamic"] != null)
        {
            CDynamicviewHelperXmlLanguageContent dynamic = (CDynamicviewHelperXmlLanguageContent)HttpContext.Current.Session["language_content_dynamic"];
            if (action == 1)
            {
                dynamic.FirstPage();
            }
            else if (action == 2)
            {
                dynamic.PreviousPage();
            }
            else if (action == 3)
            {
                dynamic.NextPage();
            }
            else if (action == 4)
            {
                dynamic.LastPage();
            }
            else
            {
                dynamic.ReSetCurrentPage();
            }
            string page = "Trang:" + dynamic.GetCurrentPage().ToString() + "/" + dynamic.GetPages().ToString();
            arrStr[0] = page;
            arrStr[2] = dynamic.GetIsFirstPage().ToString();
            arrStr[3] = dynamic.GetIsLastPage().ToString();
            arrStr[4] = dynamic.GetNumberRecord().ToString();
            ArrayList list = dynamic.GetNodeIteratorToShow(Edit_language_content);
            int count = list.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    str = list[i].ToString();
                }
            }
        }
        arrStr[1] = str;
        arrStr[5] = err;
        return arrStr;
    }

    //kiem tra fileExits
    [AjaxPro.AjaxMethod]
    public string FileExits(string Path)
    {
        string err = "";
        Language_content language_content = new Language_content();
        language_content.SetFile(Path);
        if (language_content.IsExitsFile())
        {
            err = "";
        }
        else
        {
            err = "File ngôn ngữ đã bị xóa. Không tìm kiếm nội dung.";
        }
        return err;
    }
    //hien thi du lieu tim kiem
    [AjaxPro.AjaxMethod]
    public string[] ShowData_Search(int action)
    {
        //cau hinh trang hien thi
        string err = "";
        Language_content language_content = new Language_content();
        language_content.SetFile(HttpContext.Current.Session["namePath_file_language_content"].ToString());
        if (language_content.IsExitsFile())
        {
            if (HttpContext.Current.Session["language_content_dynamic_search"] != null)
            {
                try
                {
                    string keysearch = HttpContext.Current.Session["keysearch"].ToString();
                    CDynamicviewHelperXmlLanguageContent dynamic = (CDynamicviewHelperXmlLanguageContent)HttpContext.Current.Session["language_content_dynamic_search"];
                    nav = (XPathNavigator)HttpContext.Current.Application[HttpContext.Current.Session["namePath_file_language_content"].ToString()];
                    XPathNodeIterator nodes = nav.Select("/langs/lang[contains(key,'" + keysearch + "')]");
                    dynamic.SetNumberRecord(nodes.Count);
                    dynamic.SetNavigator(nav);
                    dynamic.SetStringSeach(keysearch);
                }
                catch (Exception ex) { Response.Write(ex.ToString()); }
            }
        }
        else
        {
            CDynamicviewHelperXmlLanguageContent dynamic = new CDynamicviewHelperXmlLanguageContent();
            dynamic.SetNumberRecord(0);
            dynamic.SetStringSeach("");
            dynamic.ReSetCurrentPage();
            HttpContext.Current.Session["language_content_dynamic_search"] = dynamic;
            err = "File ngôn ngữ đã bị xóa. Không tìm kiếm nội dung.";
        }

        string[] arrStr = new string[6];
        string str = "";
        if (HttpContext.Current.Session["language_content_dynamic_search"] != null)
        {
            CDynamicviewHelperXmlLanguageContent dynamic = (CDynamicviewHelperXmlLanguageContent)HttpContext.Current.Session["language_content_dynamic_search"];
            if (action == 1)
            {
                dynamic.FirstPage();
            }
            else if (action == 2)
            {
                dynamic.PreviousPage();
            }
            else if (action == 3)
            {
                dynamic.NextPage();
            }
            else if (action == 4)
            {
                dynamic.LastPage();
            }
            else
            {
                dynamic.ReSetCurrentPage();
            }
            string page = "Trang:" + dynamic.GetCurrentPage().ToString() + "/" + dynamic.GetPages().ToString();
            arrStr[0] = page;
            arrStr[2] = dynamic.GetIsFirstPage().ToString();
            arrStr[3] = dynamic.GetIsLastPage().ToString();
            arrStr[4] = dynamic.GetNumberRecord().ToString();
            ArrayList list = dynamic.GetNodeShow(Edit_language_content);
            int count = list.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    str = list[i].ToString();
                }
            }
        }
        arrStr[1] = str;
        arrStr[5] = err;
        return arrStr;
    }
    //ham tra lai so tu khoa chua dien du lieu hien thi
    [AjaxPro.AjaxMethod]
    public string[] GetNumberKeyNotContent()
    {
        string[] arrStrKey1 = new string[1];
        if (HttpContext.Current.Application[HttpContext.Current.Session["namePath_file_language_content"].ToString()] != null)
        {
            ArrayList List = new ArrayList();
            //XPathDocument doc_language_code = new XPathDocument(HttpContext.Current.Session["language_code_file"].ToString());
            //XPathNavigator nav_language_code = doc_language_code.CreateNavigator();
            XPathNavigator nav_language_code = (XPathNavigator)HttpContext.Current.Application["nav_language_code"];
            XPathNodeIterator nodes_language_code = nav_language_code.Select("/language_code/code");
            XPathNavigator nav_langs = (XPathNavigator)HttpContext.Current.Application[HttpContext.Current.Session["namePath_file_language_content"].ToString()];
            XPathNodeIterator nodes_key_content;
            //tim kiem va add vao danh sach bang bam chua tat ca cac key chua them noi dung hien thi

            while (nodes_language_code.MoveNext())
            {
                nodes_language_code.Current.MoveToFirstChild();
                string key_content = nodes_language_code.Current.Value;
                nodes_key_content = nav_langs.Select("/langs/lang[key='" + key_content + "']");
                if (nodes_key_content.Count == 0)
                {
                    List.Add(key_content);
                }
            }
            string[] arrStrKey = new string[List.Count];
            for (int i = 0; i < List.Count; i++)
            {
                arrStrKey[i] = List[i].ToString();
            }
            int number_language_code = (int)nodes_language_code.Count;
            int number_langs_no_content = number_language_code - (int)List.Count;
            HttpContext.Current.Session["SumKeyNoContent"] = "Đã nhập " + number_langs_no_content.ToString() + "/" + number_language_code.ToString() + " nội dung.";
            return arrStrKey;
        }
        else
        {
            HttpContext.Current.Session["SumKeyNoContent"] = "File ngôn ngữ đã bị xóa ";
            arrStrKey1[0] = "";
            return arrStrKey1;
        }

    }
    [AjaxPro.AjaxMethod]
    //xoa ban ghi
    public string Delete(string id_delete)
    {
        string str = "";
        HttpContext.Current.Session["id_delete"] = id_delete;
        string file_name = HttpContext.Current.Session["namePath_file_language_content"].ToString();
        Language_content language_content = new Language_content();
        language_content.SetFile(file_name);
        if (language_content.IsExitsFile())
        {

            string[] id = new string[50];
            if (id_delete.Length > 0)
            {
                try
                {
                    string str_where = id_delete.Substring(0, id_delete.Length - 1);
                    id = str_where.Split(',');
                    XmlTextReader reader = new XmlTextReader(file_name);
                    XmlDocument doc = new XmlDocument();
                    doc.Load(reader);
                    reader.Close();


                    //Select the cd node with the matching title
                    XmlNode cd;
                    XmlElement root = doc.DocumentElement;
                    for (int i = 0; i < id.Length; i++)
                    {
                        cd = root.SelectSingleNode("/langs/lang[key='" + id[i] + "']");
                        if (cd != null)
                        {
                            root.RemoveChild(cd);
                        }
                        //save the output to a file                      
                    }
                    doc.Save(file_name);
                    str = "";
                    ResetLanguageShow();
                    HttpContext.Current.Application[HttpContext.Current.Session["namePath_file_language_content"].ToString()] = null;
                    if (!SetApp())
                    {
                        Response.Redirect("Default.aspx");
                    }
                }
                catch (Exception ex)
                {
                    //Response.Write(ex.ToString());
                    str = "Quyền cập nhật file đã khóa. Không thể xóa bỏ nội dung.. ";
                }
            }
            else
            {
                str = "Bạn phải chọn nội dung muốn xóa";
            }
            return str;
        }
        else
        {
            str = "File ngôn ngữ đã bị xóa. Không thể xóa bỏ nội dung.";
            HttpContext.Current.Session["language_content_dynamic"] = null;
            HttpContext.Current.Application[HttpContext.Current.Session["namePath_file_language_content"].ToString()] = null;
            return str;
        }
    }

    //them moi ghi
    [AjaxPro.AjaxMethod]
    public string Add(string key, string content)
    {
        string mess = "";
        string temp = HttpContext.Current.Server.HtmlEncode(content);
        Language_content languagecontent = new Language_content();
        languagecontent.SetFile(HttpContext.Current.Session["namePath_file_language_content"].ToString());
        mess = languagecontent.InsertRecord(key, temp);
        ResetLanguageShow();
        if (mess.Equals(""))
        {
            HttpContext.Current.Application[HttpContext.Current.Session["namePath_file_language_content"].ToString()] = null;
            if (!SetApp())
            {
                Response.Redirect("Default.aspx?menu=lang");
            }
        }
        else
            if (mess.Equals("FileNoEixts"))
            {
                mess = "File ngôn ngữ đã bị xóa. Không thể thêm mới nội dung.";
                HttpContext.Current.Session["language_content_dynamic"] = null;
                HttpContext.Current.Application[HttpContext.Current.Session["namePath_file_language_content"].ToString()] = null;
            }
        return mess;
    }

    //sua ban ghi
    [AjaxPro.AjaxMethod]
    public string Edit(string key, string key_edit, string content)
    {
        string mess = "";
        //string temp = HttpContext.Current.Server.HtmlEncode(des);
        Language_content languageconten = new Language_content();
        languageconten.SetFile(HttpContext.Current.Session["namePath_file_language_content"].ToString());
        mess = languageconten.EditRecord(key, key_edit, content);
        ResetLanguageShow();
        if (mess.Equals(""))
        {
            HttpContext.Current.Application[HttpContext.Current.Session["namePath_file_language_content"].ToString()] = null;
            if (!SetApp())
            {
                Response.Redirect("Default.aspx?menu=lang");
            }
        }
        else
            if (mess.Equals("FileNoEixts"))
            {
                mess = "File ngôn ngữ đã bị xóa. Không thể chỉnh sửa nội dung.";
                HttpContext.Current.Session["language_content_dynamic"] = null;
                HttpContext.Current.Application[HttpContext.Current.Session["namePath_file_language_content"].ToString()] = null;
            }
        return mess;
    }

    [AjaxPro.AjaxMethod]
    public string GetNumberKeyNoContent()
    {
        string Number = HttpContext.Current.Session["SumKeyNoContent"].ToString();
        return Number;
    }

    [AjaxPro.AjaxMethod]
    public void Search(string key_search)
    {
        //string mess = "";
        HttpContext.Current.Session["keysearch"] = key_search;
        SetDynamic_Search(key_search);
        //return mess;
    }

    [AjaxPro.AjaxMethod]
    //lay tong so ban tin tim thay
    public string ShowNumberRecord_Search()
    {
        string str = "";
        CDynamicviewHelperXmlLanguageContent dynamic = new CDynamicviewHelperXmlLanguageContent();
        dynamic = (CDynamicviewHelperXmlLanguageContent)HttpContext.Current.Session["language_content_dynamic_search"];
        str = str + "Tìm thấy " + dynamic.GetNumberRecord() + " mã chuẩn.";
        return str;
    }
    public void ResetLanguageShow()
    {
        string _fileSupport = HttpContext.Current.Server.MapPath("../data/xml/language_support.xml");
        XmlDocument _docfile = new XmlDocument();
        XmlTextReader _reader = new XmlTextReader(_fileSupport);
        _docfile.Load(_reader);
        _reader.Close();
        XmlNodeList _listNode = _docfile.SelectNodes("/lang_support/lang");
        int numSupport = _listNode.Count;
        ArrayList _list = new ArrayList();
        string _urlFileLang = HttpContext.Current.Server.MapPath("../data/xml/");
        for (int i = 0; i < numSupport; i++)
        {
            XmlNodeList _subList = _listNode[i].ChildNodes;
            string[] arrvalue = new string[3] { "", "", "" };
            arrvalue[0] = _subList[1].InnerText;
            arrvalue[1] = _subList[3].InnerText;
            arrvalue[2] = _subList[4].InnerText;
            _list.Add(arrvalue);
            GetApplication(arrvalue[1], _urlFileLang);
        }
    }
    public void GetApplication(string namefile, string url)
    {
        try
        {
            Clanguage lang = new Clanguage();
            lang.SetNameFile(namefile);
            lang.SetUrlFile(url);
            HttpContext.Current.Application[namefile] = lang.ReadLanguage();
        }
        catch (Exception ex)
        {
            Console.Write(ex.ToString());
        }
    }
}

