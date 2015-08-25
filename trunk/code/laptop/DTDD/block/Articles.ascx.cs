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
using facade.list;
using framework.list.dynamicviewhelper;
public partial class block_Articles : System.Web.UI.UserControl
{
    public string tblArticle = "Mục tin tức";
    public string tgroup = "Nhóm tin tức";
    public string tspecial = "Tin tức nổi bật";
    public string currentAccess = "Bạn đang truy cập đến";
    public string thome = "Trang chủ";
    public string lgroup = "";
    public string tpage = "Trang";
    public string strArticles = "";
    ArticleManagerSystem Articles = new ArticleManagerSystem();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            currentAccess = hash["currentpage"].ToString();
            thome=hash["home"].ToString();
            tblArticle = hash["blarticle"].ToString();
            currentAccess += ": <a href='?menu=home'>" + thome + "</a> &raquo; " + tblArticle;
            //strProduct = ShowProductAll();
        }
        catch
        {
        }
        DataSet dsGroup = Articles.ArticleGroupSelectAll();
        if (dsGroup.Tables.Count > 0)
        {
            int numGroup = dsGroup.Tables[0].Rows.Count;
            lgroup += "<table align='center'>";
            for (int i = 0; i < numGroup; i++)
            {
                lgroup += "<tr><td align='left'><span  class='agroup'><a href='?menu=ga&id=" + dsGroup.Tables[0].Rows[i]["Id"].ToString() + "'>" + dsGroup.Tables[0].Rows[i]["Name"].ToString() + "</a></span></td></tr>";
            }
            lgroup += "</table>";
        }
        strArticles=ShowArticles();
    }
    public string ShowArticles()
    {
        string tbarticle = "";
        CDymanicviewArticles ArticleView = new CDymanicviewArticles();
        try
        {
            int page = 1;
            try
            {
                page=int.Parse(Request.QueryString["page"].ToString());
            }
            catch
            { 
            
            }
            if (Session["SSArticleAll"] != null)
            {
                ArticleView = (CDymanicviewArticles)Session["SSArticleAll"];
                ArticleView.SetNumberArticleAll();
                ArticleView.SetCurrentPage(page);
            }
            else
            {
                ArticleView.SetPageSize(20);
                ArticleView.SetNumberArticleAll();
                ArticleView.SetCurrentPage(page);
                Session["SSArticleAll"] = ArticleView;
            }
            DataSet dsArticle = ArticleView.ArticleSelectAllFromTo();
            int numArticle=0;
            if(dsArticle.Tables.Count>0)
            {
                numArticle = dsArticle.Tables[0].Rows.Count;
            }
            string id="";
            string title = "";
            string url = "";
            string sum = "";
            if (ArticleView.GetPages() > 1)
            {
                tpage += ": " + BuildPage(ArticleView.GetCurrentPage(), ArticleView.GetPages());
            }
            else
            {
                tpage = "";
            }
            tbarticle="<table border='0' cellpadding='0' cellspacing='0' width='100%' align='left'>";
            tbarticle += "<tr><td height='5' width='120'></td><td></td></tr>";
            for (int i = 0; i < numArticle; i++)
            {
                id = dsArticle.Tables[0].Rows[i]["id"].ToString();
                title = dsArticle.Tables[0].Rows[i]["title"].ToString();
                sum = dsArticle.Tables[0].Rows[i]["sumarticle"].ToString();
                url = dsArticle.Tables[0].Rows[i]["urlimage"].ToString();
                if (url.Length > 0)
                {
                    url = "image/img_article/" + url;
                }
                tbarticle += "<tr>";
                if (url.Length > 0)
                {
                    tbarticle += "<td height='95' align='center'><img src='" + url + "' width='110' height='85' /></td>";
                    tbarticle += "<td valign='top'>";
                    tbarticle += "<span class='text_2'><a href='?menu=da&id=" + id + "'>" + title + "</a></span>";
                    tbarticle += "<div>" + sum + " ...</div>";
                    tbarticle += "</td>";
                }
                else
                {
                    tbarticle += "<td valign='top' height='95' colspan='2'>";
                    tbarticle += "<span class='text_2'><a href='?menu=da&id=" + id + "'>" + title + "</a></span>";
                    tbarticle += "<div>" + sum + " ...</div>";
                    tbarticle += "</td>";
                }
                tbarticle += "</tr>";
                if (i + 1 < numArticle)
                {
                    tbarticle += "<tr><td colspan='2' class='bg_line2'></td></tr>";
                }
            }
            tbarticle += "</table>";
        }
        catch
        {}
        return tbarticle;
    }
    public string BuildPage(int current, int pages)
    {
        string strLink = "";
        for (int i = 1; i <= pages; i++)
        {
            if (i == current)
            {
                strLink += "<u>" + i + "</u>";
            }
            else
            {
                strLink += "<a href='?menu=article&page=" + i + "'>" + i + "</a>";
            }
        }
        return strLink;
    }
}
