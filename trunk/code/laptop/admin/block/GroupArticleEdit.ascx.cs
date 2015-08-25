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
public partial class admin_block_GroupArticleEdit : System.Web.UI.UserControl
{
    ArticleManagerSystem Articles = new ArticleManagerSystem();
    int id = 0;
    public string message = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            id = int.Parse(Request.QueryString["id"].ToString());
            diverror.Visible = false;
            if (!IsPostBack)
            {
                DataSet dsGroup = Articles.AdminGroupSelectId(id, "AdminGroupSelectId");
                if (dsGroup.Tables.Count > 0)
                {
                    if (dsGroup.Tables[0].Rows.Count > 0)
                    {
                        txttitle.Value = dsGroup.Tables[0].Rows[0]["name"].ToString();
                        if (dsGroup.Tables[0].Rows[0]["ishow"].ToString().Equals("1"))
                        {
                            checkshow.Checked = true;
                        }
                    }
                    else
                    {
                        Response.Redirect("AdminWebsite.aspx?menu=grouparticle");
                    }
                }
                else
                {
                    Response.Redirect("AdminWebsite.aspx?menu=grouparticle");
                }
            }
        }
        catch
        {
            Response.Redirect("AdminWebsite.aspx?menu=grouparticle");
        }
    }
    protected void btedit_ServerClick(object sender, EventArgs e)
    {
        try
        {
            string titlegroup = txttitle.Value.Trim();
            Boolean ishow = checkshow.Checked;
            string show = "0";
            if (ishow)
            {
                show = "1";
            }
            if (titlegroup.Length == 0)
            {
                //error:
            }
            else
            { 
                DataSet dsArticle=Articles.AdminGroupSelectId(id,titlegroup);
                if (dsArticle.Tables.Count > 0)
                {
                    if (dsArticle.Tables[0].Rows.Count > 0)
                    {
                        if (dsArticle.Tables[1].Rows.Count>0)
                        {
                            if (dsArticle.Tables[0].Rows[0]["id"].ToString().Equals(dsArticle.Tables[1].Rows[0]["id"].ToString()))
                            {
                                //update:
                                if (Articles.AdminGroupUpdateId(id, titlegroup, show))
                                {
                                    message = "Nhóm tin đã được chỉnh sửa";
                                    diverror.Visible = true;
                                    diverror.InnerHtml = "<div class='diverror'>" + message + "</div>";
                                    return;
                                }
                                else
                                {
                                    message = "Lỗi kết nối SQL. Xin bạn hãy thử lại.";
                                    diverror.Visible = true;
                                    diverror.InnerHtml = "<div class='diverror'>" + message + "</div>";
                                    return;
                                }

                            }
                            else
                            {
                                //title exsit:
                                message = "Tiêu đề đã tồn tại, xin hãy nhập tiêu đề khác";
                                diverror.Visible = true;
                                diverror.InnerHtml = "<div class='diverror'>" + message + "</div>";
                                return;
                            }
                        }
                        else
                        {
                            //update:
                            if (Articles.AdminGroupUpdateId(id, titlegroup, show))
                            {
                                message = "Nhóm tin đã được chỉnh sửa";
                                diverror.Visible = true;
                                diverror.InnerHtml = "<div class='diverror'>" + message + "</div>";
                                return;
                            }
                            else
                            {
                                message = "Lỗi kết nối SQL. Xin bạn hãy thử lại.";
                                diverror.Visible = true;
                                diverror.InnerHtml = "<div class='diverror'>" + message + "</div>";
                                return;
                            }
                        }
                    }
                    else
                    {
                        //deleted
                        message = "Tin đã bị xóa bỏ.";
                        Response.Redirect("AdminWebsite.aspx?menu=grouparticle");
                    }
                }
                else
                { 
                    //Err
                    Response.Redirect("AdminWebsite.aspx?menu=grouparticle");
                }
            }
        }
        catch
        {
            Response.Redirect("AdminWebsite.aspx?menu=grouparticle");
        }
    }
}
