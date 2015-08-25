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
public partial class admin_block_ManageArticles : System.Web.UI.UserControl
{

    public string strPage = "Trang: ";
    public string strTable = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ShowListArticle();
        }
        catch
        {
            strTable = "Lỗi kết nối SQL. Không thể hiển thị dữ liệu";
        }
    }
    public void ShowListArticle()
    {
        int idgroup = 0;
        int page = 0;
        try
        {
            idgroup = int.Parse(Request.QueryString["idgroup"].ToString());
        }
        catch
        { }
        try
        {
            page = int.Parse(Request.QueryString["page"].ToString());
        }
        catch
        { 
        
        }
        CDymanicviewArticles articleList = new CDymanicviewArticles();
        if (Session["SSAdminArticle"] == null)
        {
            articleList.SetPageSize(20);
            if (idgroup > 0)
            {
                articleList.SetIdGroup(idgroup);
                articleList.BuildWhere();
            }
            articleList.AdminSetNumarticle();
            if (page > 0)
            {
                articleList.SetCurrentPage(page);
            }
            else
            {
                articleList.SetCurrentPage(1);
            }
            Session["SSAdminArticle"] = articleList;
        }
        else
        {
            articleList = (CDymanicviewArticles)Session["SSAdminArticle"];
            if (idgroup > 0)
            {
                articleList.SetIdGroup(idgroup);
                articleList.BuildWhere();
            }
            articleList.AdminSetNumarticle();
            if (page > 0)
            {
                articleList.SetCurrentPage(page);
            }
            else
            {
                articleList.ReSetCurrentPage();
            }
        }
        DataSet dsarticle = articleList.AdminArticleFromTo();
        int numarticle = 0;
        if (dsarticle.Tables.Count > 0)
        {
            numarticle = dsarticle.Tables[0].Rows.Count;
        }
        if (articleList.GetPages() > 1)
        {
            BuildPage(articleList.GetCurrentPage(), articleList.GetPages());
        }
        if (numarticle > 0)
        {
            strTable = "<table border='1' cellpadding='2' cellspacing='0' bordercolor='#DFDFDF' style='border-collapse:collapse;' width='730'>";
            strTable += "<tr class='tlist'><td width='30'>STT</td><td width='200'>Tiêu đề tin đăng</td><td width='400'>Mô tả ngắn gọn</td><td width='50'>Hiển thị</td><td width='50'>Xóa bỏ</td></tr>";
            for (int i = 1; i <= numarticle; i++)
            {
                string id = dsarticle.Tables[0].Rows[i - 1]["id"].ToString();
                string check = "";
                if (dsarticle.Tables[0].Rows[i - 1]["ishow"].ToString().Equals("1"))
                {
                    check = "<input type='checkbox' checked='checked' DISABLED />";
                }
                else
                {
                    check = "<input type='checkbox' DISABLED />";
                }
                strTable += "<tr><td align='center'>" + i.ToString() + "</td><td class='title1' width='200'><a href='?menu=edita&id=" + id + "'>" + dsarticle.Tables[0].Rows[i - 1]["title"].ToString() + "</a></td>";
                strTable += "<td>" + dsarticle.Tables[0].Rows[i - 1]["sumarticle"].ToString() + "</td>";
                strTable += "<td align='center'>" + check + "</td><td align='center'><span class='spanbt' onclick='Dfunction(" + id + ",7);'>Xóa</span></td></tr>";
            }
            strTable += "</table>";
        }
        else
        {
            strTable = "Chưa có tin nào";
        }
    }
    public void BuildPage(int currentpage, int pages)
    {
        for (int i = 1; i <= pages; i++)
        {
            if (i == currentpage)
            {
                strPage += "<u>" + i + "</u>";
            }
            else
            {
                strPage += "<a href='?menu=article&page=" + i + "'>" + i + "</a>";
            }
        }
    }
}
