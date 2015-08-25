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

public partial class admin_block_editAdvertise : System.Web.UI.UserControl
{
    AdvertiseSystem advertise = new AdvertiseSystem();
    DataSet dsadvertise = new DataSet();
    public string id = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        diverror.Visible = false;
        
        try
        {
            id = Request.QueryString["id"].ToString();
            dsadvertise = advertise.AdvertiseSelectId(id);
            if (dsadvertise.Tables[0].Rows.Count > 0)
            {
                if (!IsPostBack)
                {
                    slsort.Items[int.Parse(dsadvertise.Tables[0].Rows[0]["sort"].ToString()) - 1].Selected = true;
                    txttitle.Value = dsadvertise.Tables[0].Rows[0]["title"].ToString();
                    txtlink.Value = dsadvertise.Tables[0].Rows[0]["link"].ToString();
                    txtnote.Value = dsadvertise.Tables[0].Rows[0]["note"].ToString();
                    if (dsadvertise.Tables[0].Rows[0]["show"].ToString().Equals("1"))
                    {
                        checkshow.Checked = true;
                    }
                }
            }
        }
        catch
        {
            Response.Redirect("AdminWebsite.aspx?menu=linkweb");
        }
    }
    protected void btadd_ServerClick(object sender, EventArgs e)
    {
        try
        {
            string title = txttitle.Value.Trim();
            string link = txtlink.Value.Trim();
            int sort = int.Parse(slsort.Value);
            string ishow = "0";
            if (checkshow.Checked)
            {
                ishow = "1";
            }
            string note = txtnote.Value.Trim();
            if (title.Length == 0)
            {
                diverror.Visible = true;
                diverror.InnerHtml = "<div class='diverror'>Xin hãy nhập tiêu đề liên kết</div>";
                return;
            }
            else if (link.Length == 0)
            {
                diverror.Visible = true;
                diverror.InnerHtml = "<div class='diverror'>Xin hãy nhập Link liên kết</div>";
                return;
            }
            else
            {
                string nameImage = "";
                DateTime time = new DateTime();
                time = DateTime.Now;
                CvalidateImageForPost manageImage = new CvalidateImageForPost();
                string imageold = dsadvertise.Tables[0].Rows[0]["urlImage"].ToString();
                nameImage = imageold;
                if (ImageArticle.PostedFile.FileName.Length > 0)
                {
                    nameImage = "advertise" + time.Ticks + "." + manageImage.GetExtension(ImageArticle.PostedFile.FileName);
                }
                if (advertise.AdvertiseUpdate(int.Parse(id), title, sort, link, nameImage, ishow, note))
                {
                    diverror.Visible = true;
                    diverror.InnerHtml = "<div class='diverror'>Liên kết đã được chỉnh sửa</div>";
                    Application["appAdvertiset"] = null;
                    SetAdvertise();
                    if (ImageArticle.PostedFile.FileName.Length > 0)
                    {
                        string path = Server.MapPath("../image/advertise/");
                        if (manageImage.TestTypeFile(ImageArticle))
                        {
                            if (manageImage.TestMaxSizeImage(ImageArticle, 102400))
                            {
                                diverror.InnerHtml += "<div class='diverror'>Ảnh không quá 100KB</div>";
                            }
                            else
                            {
                                
                                manageImage.UploadFile_server(ImageArticle, path + nameImage);
                            }
                        }
                        else
                        {
                            diverror.InnerHtml += "<div class='diverror'>Chỉ hỗ trợ file dạng: gif, png, jpg, bmp, swf</div>";
                        }
                        if (imageold.Length > 0)
                        {
                            manageImage.DeleteFile(path + imageold);
                        }
                    }
                    return;
                }
                else
                {
                    diverror.Visible = true;
                    diverror.InnerHtml = "<div class='diverror'>Lỗi kết nối, không thể thêm mới liên kết</div>";
                    return;
                }
            }
        }
        catch
        { }
    }
    public string SetAdvertise()
    {
        string list_Advertise = "";
        try
        {
            if (Application["appAdvertiset"] == null)
            {
                DataSet ds = new AdvertiseSystem().AdvertiseSelectAllShow();
                if (ds.Tables.Count > 0)
                {
                    int num = ds.Tables[0].Rows.Count;
                    for (int i = 0; i < num; i++)
                    {
                        string image = ds.Tables[0].Rows[i]["urlImage"].ToString();
                        string[] array = image.Split('.');
                        if (array[1].Equals("swf"))
                        {
                            list_Advertise += "<object width='175'><embed src='image/advertise/" + image + "' width='160' height='86' type='application/x-shockwave-flash' pluginspage='http://www.macromedia.com/go/getflashplayer'></embed></object><br />";
                        }
                        else
                        {
                            list_Advertise += "<a href='" + ds.Tables[0].Rows[i]["link"].ToString() + "' title='" + ds.Tables[0].Rows[i]["title"].ToString() + "' target='_blank'><img src='image/advertise/" + image + "' class='imga'/></a><br />";
                        }
                    }
                    Application["appAdvertiset"] = list_Advertise;
                }
            }
            else
            {
                list_Advertise = Application["appAdvertiset"].ToString();
            }
        }
        catch
        {
            list_Advertise = "";
        }
        return list_Advertise;
    }
}