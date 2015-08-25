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
public partial class block_ArticleDetail : System.Web.UI.UserControl
{
    public int id = 0;
    public string tblArticle = "";
    public string title = "";
    public string sumarticle = "";
    public string urlImage = "";
    public string content = "";
    public string groupName = "";
    public string source = "";
    public string link = "";
    public string listTitle = "";
    public string currentAccess = "";
    string thome = "";
    string tarticle = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Boolean isok = true;
        try
        {
            id = int.Parse(Request.QueryString["id"].ToString());
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            currentAccess = hash["currentpage"].ToString();
            thome = hash["home"].ToString();
            tblArticle = hash["darticle"].ToString();
            tarticle = hash["blarticle"].ToString();
            currentAccess += ": <a href='?menu=home'>" + thome + "</a> &raquo; <a href='?menu=article'>" + tarticle + "</a> &raquo; ";
            DataSet dsArticle = new ArticleManagerSystem().ArticleSelectDetail(id);
            if (dsArticle.Tables.Count > 0)
            {
                if (dsArticle.Tables[0].Rows.Count > 0)
                {
                    title = dsArticle.Tables[0].Rows[0]["title"].ToString();
                    sumarticle = dsArticle.Tables[0].Rows[0]["sumarticle"].ToString();
                    urlImage = dsArticle.Tables[0].Rows[0]["urlImage"].ToString();
                    if (urlImage.Length > 0)
                    {
                        urlImage = "image/img_article/" + urlImage;
                    }
                    DateTime time= (DateTime)dsArticle.Tables[0].Rows[0]["timeUpdate"];
                    title += " <i style='color:black;'>(" + time.ToString("dd-MM-yyyy") + ")</i>";
                    content = dsArticle.Tables[0].Rows[0]["content"].ToString();
                    source = dsArticle.Tables[0].Rows[0]["source"].ToString();
                    link = dsArticle.Tables[0].Rows[0]["link"].ToString();
                    if (dsArticle.Tables[1].Rows.Count > 0)
                    {
                        groupName = "<a href='?menu=ga&id=" + dsArticle.Tables[1].Rows[0]["id"].ToString() + "'>" + dsArticle.Tables[1].Rows[0]["Name"].ToString() +"</a>";
                        currentAccess += "<a href='?menu=ga&id=" + dsArticle.Tables[1].Rows[0]["id"].ToString() + "'>" + dsArticle.Tables[1].Rows[0]["Name"].ToString() + "</a> &raquo; ";
                    }
                    currentAccess += title;
                    int num=dsArticle.Tables[2].Rows.Count;
                    if (num>0)
                    {
                        for (int i = 1; i <= num; i++)
                        {
                            time = (DateTime)dsArticle.Tables[2].Rows[i-1]["timeUpdate"];
                            listTitle += "<span  class='text_2'><a href='?menu=da&id=" + dsArticle.Tables[2].Rows[i-1]["id"].ToString() + "'>";
                            listTitle += i + ". " + dsArticle.Tables[2].Rows[i - 1]["title"].ToString() + "</a></span> <i style='color:black;'>(" + time.ToString("dd-MM-yyyy") + ")</i><br />";
                        }
                    }
                }
                else
                {
                    isok = false;
                }
            }
        }
        catch
        {
            isok = false;
        }
        if (!isok)
        {
            Response.Redirect("Default.aspx?menu=article");
        }
    }
}
