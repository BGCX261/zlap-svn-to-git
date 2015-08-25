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
using framework.list.common;
using framework.list.lang;
using System.IO;
public partial class admin_block_LanguageManager : System.Web.UI.UserControl
{
    public bool admin_Language = true;
    public bool right_addnew = true;
    public bool right_edit = true;
    public bool right_delete = true;
    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(admin_block_LanguageManager));
        Session["path_data"] = Server.MapPath("../data/xml/");
        //Luu duong dan file
        if (Session["language_support"] == null)
        {
            Session["language_support"] = Server.MapPath("../data/xml/language_support.xml");
        }
    }
    [AjaxPro.AjaxMethod]
    public string[] LoadLanguage()
    {
        XPathNodeIterator nodes;
        string[] arr = new string[2];
        string str = "";
        str = str + "<table width='100%' border='1' cellpadding='3' cellspacing='0' style='background: #EFF5FF; border-collapse:collapse'>";
        str = str + " <colgroup> ";
        str = str + " <col width='5%' align='center'/> ";
        str = str + " <col width='3%' align='center'/> ";
        str = str + " <col width='20%' align='center'/> ";
        str = str + " <col width='10%' align='center'/> ";
        str = str + " <col width='20%' align='center'/> ";
        str = str + " <col width='10%' align='center'/> ";
        str = str + " <col width='20%' align='center'/> ";
        str = str + " <col width='5%' align='center'/> ";
        str = str + " </colgroup>";

        str = str + "<TR class='titletbl' >";
        str = str + "<TH height='20' align='center'>Số TT</TH>";
        str = str + "<TH height='20' align='center'><input type = 'checkbox' id = 'chkAll' onclick=\"OnchoiceAll('chkAll');return true;\"/></TH>";
        str = str + "<TH height='20' align='center'>Ngôn ngữ</TH>";
        str = str + "<TH height='20' align='center'>Viết tắt</TH>";
        str = str + "<TH height='20' align='center'>Tên File</TH>";
        str = str + "<TH height='20' align='center'>Cờ</TH>";
        str = str + "<TH height='20' align='center'>Trạng thái</TH>";
        str = str + "<TH height='20' align='center'>Sửa</TH>";
        str = str + "</TR>";

        Language language_support = new Language();
        language_support.SetFile(HttpContext.Current.Session["language_support"].ToString());
        nodes = language_support.GetLanguage();
        if (nodes == null)
        {
            arr[1] = "0";
        }
        else
        {
            arr[1] = nodes.Count.ToString();
        }
        if (int.Parse(arr[1]) > 0)
        {

            string id = "";
            string _name = "";
            string _abb = "";
            string _url = "";
            string _flag = "";
            string status = "";
            int i = 1;
            while (nodes.MoveNext())
            {
                nodes.Current.MoveToFirstChild();
                id = nodes.Current.ToString();
                //string str_edit = "";
                nodes.Current.MoveToNext();
                _name = HttpContext.Current.Server.HtmlEncode(nodes.Current.Value);

                nodes.Current.MoveToNext();
                _abb = nodes.Current.InnerXml;

                nodes.Current.MoveToNext();
                _url = nodes.Current.InnerXml;

                nodes.Current.MoveToNext();
                _flag = nodes.Current.InnerXml;

                nodes.Current.MoveToNext();
                if (nodes.Current.ToString() == "2")
                {
                    status = "Đang sử dụng";
                }
                if (nodes.Current.ToString() == "1")
                {
                    status = "Đang sẵn sàng";
                }
                if (nodes.Current.ToString() == "0")
                {
                    status = "Chưa sẵn sàng";
                }
                //Trinh bay lai
                str = str + "<tr><td>" + (i++) + "</td>";
                str = str + "<td><input type='checkbox' id='" + id + "' name='CheckGroup' onclick='CheckOne();' /></td> ";
                str = str + "<td><a href = '#' onclick = \"NavigatorToLang('" + _url + "','" + _name + "');\">" + _name + "</a></td>";
                str = str + "<td>" + _abb + "</td>";
                str = str + "<td>" + _url + "</td>";
                str = str + "<td><img width='30' height='20' src='../image/flag/" + _flag + "'/></td>";
                str = str + "<td>" + status + "</td>";
                if (right_edit)
                {
                    str = str + "<td><a href='../administrator/Default.aspx?menu=lang_edit&id=" + id.ToString() + "'>Sửa</td>";
                }
                else
                {
                    str = str + "<td>Sửa</td>";
                }
                str = str + "</tr>";
            }
        }
        str = str + "</table>";
        arr[0] = str;
        return arr;
    }

    [AjaxPro.AjaxMethod]
    public string DeleteLanguage(string id_delete)
    {
        XPathNodeIterator nodes;
        Language language_support = new Language();
        language_support.SetFile(HttpContext.Current.Session["language_support"].ToString());
        string files_language = "";

        HttpContext.Current.Session["id_lang_delete"] = id_delete;
        string str = "";
        string[] id = new string[50];
        if (id_delete.Length > 0)
        {
            try
            {
                //if (DeleteFile())
                //{

                string str_where = id_delete.Substring(0, id_delete.Length - 1);
                id = str_where.Split(',');

                string file_name = HttpContext.Current.Session["language_support"].ToString();
                XmlTextReader reader = new XmlTextReader(file_name);
                XmlDocument doc = new XmlDocument();
                doc.Load(reader);
                reader.Close();


                //Select the cd node with id
                XmlNode cd;
                XmlElement root = doc.DocumentElement;
                XPathNavigator nav = doc.CreateNavigator();
                XPathNodeIterator iterator;
                for (int i = 0; i < id.Length; i++)
                {

                    iterator = nav.Select("/lang_support/lang[id=" + id[i].ToString() + "]/url");
                    iterator.MoveNext();
                    files_language = iterator.Current.Value;
                    //nodes = language_support.GetLanguageById(id[i].ToString());
                    //while (nodes.MoveNext())
                    //{
                    //    nodes.Current.MoveToFirstChild();
                    //    nodes.Current.MoveToNext();
                    //    nodes.Current.MoveToNext();
                    //    nodes.Current.MoveToNext();
                    //    files_language =nodes.Current.ToString(); //+ ",";
                    //}

                    cd = root.SelectSingleNode("/lang_support/lang[id='" + id[i] + "']");
                    if (cd != null)
                    {
                        root.RemoveChild(cd);
                        File.Delete(HttpContext.Current.Session["path_data"].ToString() + files_language);
                        //save the output to a file 
                        doc.Save(file_name);
                        str = "";
                    }
                }
                //HttpContext.Current.Session["file_language"] = files_language;
                //}
            }
            catch (Exception)
            {
                str = "Quyền cập nhật file bị khóa. Không thể xóa bỏ.";
                //Response.Write(ex.ToString());

            }
        }
        else
        {
            str = "Bạn phải chọn dữ liệu muốn xóa !";
        }
        return str;
    }
    [AjaxPro.AjaxMethod]
    public bool SetAdminLanguage(string url, string name)
    {
        bool test = false;
        if (!url.Equals("") || !name.Equals(""))
        {
            string[] arr = new string[2];
            arr[0] = url;
            arr[1] = name;
            HttpContext.Current.Session["Language_Content"] = arr;
            test = true;
        }
        return test;
    }
}