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
using framework.list.common;
public partial class admin_block_ArticleUpdate : System.Web.UI.UserControl
{
    ArticleManagerSystem Articles = new ArticleManagerSystem();
    public int id = 0;
    public string content = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            id = int.Parse(Request.QueryString["id"].ToString());
            diverror.Visible = false;
            if (!IsPostBack)
            {
                //InsertCheck
                DataSet dsgroup = Articles.AdminGroupAll();
                DataSet dsArticle = Articles.AdminArticleTestExsit(id, "Administrator");
                if (dsArticle.Tables.Count > 0)
                {
                    if (dsArticle.Tables[0].Rows.Count > 0)
                    {
                        txttitle.Value = dsArticle.Tables[0].Rows[0]["title"].ToString();
                        txtsumcontent.Value = dsArticle.Tables[0].Rows[0]["sumarticle"].ToString();
                        content = dsArticle.Tables[0].Rows[0]["content"].ToString();
                        txtsource.Value = dsArticle.Tables[0].Rows[0]["source"].ToString();
                        txtlink.Value = dsArticle.Tables[0].Rows[0]["link"].ToString();
                        if (dsArticle.Tables[0].Rows[0]["ishow"].ToString().Equals("1"))
                        {
                            checkshow.Checked = true;
                        }
                        string idgroup = dsArticle.Tables[0].Rows[0]["idgroup"].ToString();
                        if (dsgroup.Tables.Count > 0)
                        {
                            int numGroup = dsgroup.Tables[0].Rows.Count;

                            for (int i = 0; i < numGroup; i++)
                            {
                                ListItem Item = new ListItem(dsgroup.Tables[0].Rows[i]["name"].ToString(), dsgroup.Tables[0].Rows[i]["id"].ToString());
                                slGroup.Items.Add(Item);
                                if(dsgroup.Tables[0].Rows[i]["id"].ToString().Equals(idgroup))
                                {
                                    slGroup.Items[i].Selected = true;
                                }
                            }
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
            string title = txttitle.Value.Trim();
            string sum = txtsumcontent.Value.Trim();
            content = Request.Form["txtContent"].ToString();
            string source = txtsource.Value.Trim();
            string link = txtlink.Value.Trim();
            int idgroup=int.Parse(slGroup.Value);
            string ishow = "0";
            if (checkshow.Checked)
            {
                ishow = "1";
            }
            if (title.Length == 0)
            {
                diverror.Visible = true;
                diverror.InnerHtml = "<div class='diverror'>Xin bạn hãy nhập tiêu đề tin</div>";
                return;
            }
            else if (sum.Length == 0)
            {
                diverror.Visible = true;
                diverror.InnerHtml = "<div class='diverror'>Xin hãy nhập mô tả ngắn gọn tin tức</div>";
                return;
            }
            else
            {
                DataSet dsArticle = Articles.AdminArticleTestExsit(id, title);
                if (dsArticle.Tables.Count > 0)
                {
                    if (dsArticle.Tables[0].Rows.Count > 0)
                    {
                        Boolean isUpdate = false;
                        if (dsArticle.Tables[1].Rows.Count > 0)
                        {
                            if (dsArticle.Tables[1].Rows[0]["id"].ToString() == id.ToString())
                            {
                                //Update:
                                isUpdate = true;
                            }
                            else
                            {
                                diverror.Visible = true;
                                diverror.InnerHtml = "<div class='diverror'>Tiêu đề tin đã tồn tại, xin hãy nhập tiêu đề khác</div>";
                                return;
                            }
                        }
                        else
                        { 
                            //Update:
                            isUpdate = true;
                        }
                        string nameImage="";
                        DateTime time=new DateTime();
                        time=DateTime.Now;
                        CvalidateImageForPost manageImage = new CvalidateImageForPost();
                        nameImage=dsArticle.Tables[0].Rows[0]["urlImage"].ToString();
                        if(ImageArticle.PostedFile.FileName.Length>0)
                        {
                            nameImage = "article_image_" + id + "." + manageImage.GetExtension(ImageArticle.PostedFile.FileName);
                        }
                        if (isUpdate)
                        { 
                            if(Articles.AdminArticleUpdate(id,idgroup,title,sum,content,nameImage,time,source,link,ishow))
                            {
                                diverror.Visible = true;
                                diverror.InnerHtml = "<div class='diverror'>Tin tức đã được chỉnh sửa</div>";
                                //UpdateArticle:
                                if (ImageArticle.PostedFile.FileName.Length > 0)
                                {
                                    string path = Server.MapPath("../image/img_article/");
                                    if (dsArticle.Tables[0].Rows[0]["urlImage"].ToString().Length > 0)
                                    {
                                        manageImage.DeleteFile(path + dsArticle.Tables[0].Rows[0]["urlImage"].ToString().Length);
                                    }
                                    if (manageImage.TestMaxSizeImage(ImageArticle, 71680))
                                    {
                                        diverror.InnerHtml += "<div class='diverror'>Ảnh không quá 70 KB</div>";
                                    }
                                    else
                                    {
                                        
                                        manageImage.UploadFile_server(ImageArticle, path + nameImage);
                                    }
                                }
                                return;
                            }else
                            {
                                diverror.Visible = true;
                                diverror.InnerHtml = "<div class='diverror'>Lỗi kết nối, không thể thêm mới tin tức</div>";
                                return;
                            }
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
        { }
    }
}
