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
using System.Xml;
using System.Xml.XPath;
using framework.list.lang;
using framework.list.dynamicviewhelper;
public partial class admin_block_LanguageCode : System.Web.UI.UserControl
{
    XPathDocument doc;
    XPathNavigator nav;
    public bool Addmin_language_code = true;
    public bool Add_language_code = true;
    public bool Edit_language_code = true;
    public bool Delete_language_code = true;
    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(admin_block_LanguageCode));
        if (HttpContext.Current.Session["language_code_file"] == null)
        {
            HttpContext.Current.Session["language_code_file"] = Server.MapPath("../data/xml/language_code.xml");
        }
        SetApp();
        SetDynamic();
    }
    //cau hinh trang tim kiem
    public void SetDynamic_Search(string key_search)
    {
        nav = (XPathNavigator)HttpContext.Current.Application["nav_language_code"];
        XPathNodeIterator nodes = nav.Select("/language_code/code[contains(key,'" + key_search + "')]");
        CDynamicviewHelperXmlLanguageCode dynamic = new CDynamicviewHelperXmlLanguageCode();


        if (HttpContext.Current.Session["language_code_dynamic_search"] == null)
        {
            int numCode = nodes.Count;
            dynamic.SetStringSeach(key_search);
            dynamic.SetNumberRecord(numCode);
            dynamic.SetPageSize(10);
            dynamic.SetCurrentPage();
            dynamic.SetNavigator(nav);
            HttpContext.Current.Session["language_code_dynamic_search"] = dynamic;
        }
        else
        {
            dynamic = (CDynamicviewHelperXmlLanguageCode)HttpContext.Current.Session["language_code_dynamic_search"];
            int numCode = nodes.Count;
            dynamic.SetStringSeach(key_search);
            dynamic.SetNumberRecord(numCode);
            dynamic.SetNavigator(nav);
            dynamic.ReSetCurrentPage();
            HttpContext.Current.Session["language_code_dynamic_search"] = dynamic;
        }

    }
    //cau hinh trang hien thi
    public void SetDynamic()
    {
        nav = (XPathNavigator)HttpContext.Current.Application["nav_language_code"];
        XPathNodeIterator nodes = nav.Select("/language_code/code");
        CDynamicviewHelperXmlLanguageCode dynamic = new CDynamicviewHelperXmlLanguageCode();
        if (HttpContext.Current.Session["language_code_dynamic"] == null)
        {
            int numCode = nodes.Count;
            dynamic.SetNumberRecord(numCode);
            dynamic.SetPageSize(10);
            dynamic.SetCurrentPage();
            dynamic.SetNavigator(nav);
            HttpContext.Current.Session["language_code_dynamic"] = dynamic;
        }
        else
        {
            dynamic = (CDynamicviewHelperXmlLanguageCode)HttpContext.Current.Session["language_code_dynamic"];
            int numCode = nodes.Count;
            dynamic.SetNumberRecord(numCode);
            dynamic.SetNavigator(nav);
            dynamic.ReSetCurrentPage();
            HttpContext.Current.Session["language_code_dynamic"] = dynamic;
        }

    }
    //thiet dat cau hinh khi bat dau load
    public void SetApp()
    {
        if (HttpContext.Current.Application["nav_language_code"] == null)
        {

            doc = new XPathDocument(HttpContext.Current.Session["language_code_file"].ToString());
            nav = doc.CreateNavigator();
            HttpContext.Current.Application["nav_language_code"] = nav;
        }
    }
    //lay tong so ban ghi
    [AjaxPro.AjaxMethod]
    public string ShowNumberRecord()
    {
        string str = "";
        CDynamicviewHelperXmlLanguageCode dynamic = new CDynamicviewHelperXmlLanguageCode();
        dynamic = (CDynamicviewHelperXmlLanguageCode)HttpContext.Current.Session["language_code_dynamic"];
        str = str + "<span style='font-size: 14pt; color: #ff0066'><strong>" + "Đã có " + dynamic.GetNumberRecord() + " mã chuẩn." + "</strong></span>";
        return str;
    }
    [AjaxPro.AjaxMethod]
    //lay tong so ban tin tim thay
    public string ShowNumberRecord_Search()
    {
        string str = "";
        CDynamicviewHelperXmlLanguageCode dynamic = new CDynamicviewHelperXmlLanguageCode();
        dynamic = (CDynamicviewHelperXmlLanguageCode)HttpContext.Current.Session["language_code_dynamic_search"];
        str = str + "Tìm thấy " + dynamic.GetNumberRecord() + " mã chuẩn.";
        return str;
    }
    [AjaxPro.AjaxMethod]
    //hien thi du lieu tim kiem
    public string[] ShowData_Search(int action)
    {
        //cau hinh trang hien thi
        if (HttpContext.Current.Session["language_code_dynamic_search"] != null)
        {
            try
            {
                string keysearch = HttpContext.Current.Session["keysearch"].ToString();
                CDynamicviewHelperXmlLanguageCode dynamic = (CDynamicviewHelperXmlLanguageCode)HttpContext.Current.Session["language_code_dynamic_search"];
                nav = (XPathNavigator)HttpContext.Current.Application["nav_language_code"];
                XPathNodeIterator nodes = nav.Select("/language_code/code[contains(key,'" + keysearch + "')]");
                dynamic.SetNumberRecord(nodes.Count);
                dynamic.SetNavigator(nav);
                dynamic.SetStringSeach(keysearch);
            }
            catch (Exception ex) { Response.Write(ex.ToString()); }
        }

        string[] arrStr = new string[5];
        string str = "";
        if (HttpContext.Current.Session["language_code_dynamic_search"] != null)
        {
            CDynamicviewHelperXmlLanguageCode dynamic = (CDynamicviewHelperXmlLanguageCode)HttpContext.Current.Session["language_code_dynamic_search"];
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
            string page = "<span style='font-size: 14pt; color: #ff00ff'>" + "Trang:" + dynamic.GetCurrentPage().ToString() + "/" + dynamic.GetPages().ToString() + "</span>";
            arrStr[0] = page;
            arrStr[2] = dynamic.GetIsFirstPage().ToString();
            arrStr[3] = dynamic.GetIsLastPage().ToString();
            arrStr[4] = dynamic.GetNumberRecord().ToString();
            ArrayList list = dynamic.GetNodeShow(Edit_language_code);
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

        return arrStr;
    }
    //hien thi du lieu
    [AjaxPro.AjaxMethod]
    public string[] ShowData(int action)
    {
        //cau hinh hien thi trang
        if (HttpContext.Current.Session["language_code_dynamic"] != null)
        {
            try
            {
                CDynamicviewHelperXmlLanguageCode dynamic = (CDynamicviewHelperXmlLanguageCode)HttpContext.Current.Session["language_code_dynamic"];
                nav = (XPathNavigator)HttpContext.Current.Application["nav_language_code"];
                XPathNodeIterator nodes = nav.Select("/language_code/code");
                dynamic.SetNumberRecord(nodes.Count);
                dynamic.SetNavigator(nav);
            }
            catch (Exception ex) { Response.Write(ex.ToString()); }
        }

        string[] arrStr = new string[5];
        string str = "";
        if (HttpContext.Current.Session["language_code_dynamic"] != null)
        {
            CDynamicviewHelperXmlLanguageCode dynamic = (CDynamicviewHelperXmlLanguageCode)HttpContext.Current.Session["language_code_dynamic"];
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
            string page = "<span style='font-size: 14pt; color: #ff00ff'>" + "Trang:" + dynamic.GetCurrentPage().ToString() + "/" + dynamic.GetPages().ToString() + "</span>";
            arrStr[0] = page;
            arrStr[2] = dynamic.GetIsFirstPage().ToString();
            arrStr[3] = dynamic.GetIsLastPage().ToString();
            arrStr[4] = dynamic.GetNumberRecord().ToString();
            ArrayList list = dynamic.GetNodeIteratorToShow(Edit_language_code);
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

        return arrStr;
    }
    [AjaxPro.AjaxMethod]
    //xoa ban ghi
    public string Delete(string id_delete)
    {
        HttpContext.Current.Session["id_delete"] = id_delete;
        string str = "";
        string[] id = new string[50];
        if (id_delete.Length > 0)
        {
            try
            {
                string str_where = id_delete.Substring(0, id_delete.Length - 1);
                id = str_where.Split(',');

                string file_name = HttpContext.Current.Session["language_code_file"].ToString();
                XmlTextReader reader = new XmlTextReader(file_name);
                XmlDocument doc = new XmlDocument();
                doc.Load(reader);
                reader.Close();


                //Select the cd node with the matching title
                XmlNode cd;
                XmlElement root = doc.DocumentElement;
                for (int i = 0; i < id.Length; i++)
                {
                    cd = root.SelectSingleNode("/language_code/code[key='" + id[i] + "']");
                    if (cd != null)
                    {
                        root.RemoveChild(cd);
                    }
                    //save the output to a file                      
                }
                doc.Save(file_name);
                str = "";
                HttpContext.Current.Application["nav_language_code"] = null;
                SetApp();
            }
            catch (Exception ex)
            {
                //Response.Write(ex.ToString());
                str = "Quyền cập nhập file đã khóa. Không thể xóa bỏ. ";
            }
        }
        else
        {
            str = "Bạn phải chọn dữ liệu muốn xóa";
        }
        return str;
    }
    //them moi ghi
    [AjaxPro.AjaxMethod]
    public string Add(string key, string des)
    {
        string mess = "";
        string temp = HttpContext.Current.Server.HtmlEncode(des);
        Lang_code languagecode = new Lang_code();
        languagecode.SetFile(HttpContext.Current.Session["language_code_file"].ToString());
        mess = languagecode.InsertRecord(key, temp);
        if (mess.Equals(""))
        {
            HttpContext.Current.Application["nav_language_code"] = null;
            SetApp();
        }
        return mess;
    }
    //sua ban ghi
    [AjaxPro.AjaxMethod]
    public string Edit(string key, string key_edit, string des)
    {
        string mess = "";
        //string temp = HttpContext.Current.Server.HtmlEncode(des);
        Lang_code languagecode = new Lang_code();
        languagecode.SetFile(HttpContext.Current.Session["language_code_file"].ToString());
        mess = languagecode.EditRecord(key, key_edit, des);

        if (mess.Equals(""))
        {
            HttpContext.Current.Application["nav_language_code"] = null;
            SetApp();
        }
        return mess;
    }
    [AjaxPro.AjaxMethod]
    public void Search(string key_search)
    {
        HttpContext.Current.Session["keysearch"] = key_search;
        SetDynamic_Search(key_search);
    }

}
