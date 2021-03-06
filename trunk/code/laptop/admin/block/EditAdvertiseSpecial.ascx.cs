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
using common.list;
using facade.list;
using framework.list.common;
public partial class admin_block_EditAdvertiseSpecial : System.Web.UI.UserControl
{
    public string content = "";
    public int id = 0;
    public string idbrand = "";
    public string urlOld1 = "";
    public string urlOld2 = "";
    public string nameurl1 = "";
    public string nameurl2 = "";
    public string link = "";
    public string sort = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            try
            {
                id = int.Parse(Request.QueryString["id"].ToString());
                DataSet dsAdvertise = new AdvertiseSystem().SpecialSelectId(id);
                if (dsAdvertise.Tables.Count > 0 && dsAdvertise.Tables[0].Rows.Count > 0)
                {
                    txttitle.Value = dsAdvertise.Tables[0].Rows[0]["title"].ToString();
                    content = dsAdvertise.Tables[0].Rows[0]["content"].ToString();
                    txtlink.Value = dsAdvertise.Tables[0].Rows[0]["link"].ToString();
                    idbrand = dsAdvertise.Tables[0].Rows[0]["idbrand"].ToString();
                    sort = dsAdvertise.Tables[0].Rows[0]["sort"].ToString();
                    nameurl1 = dsAdvertise.Tables[0].Rows[0]["urlimage1"].ToString();
                    nameurl2 = dsAdvertise.Tables[0].Rows[0]["urlimage2"].ToString();
                    if (nameurl1.Length > 0)
                    {
                        urlOld1 = "../image/advertise/" + nameurl1;

                    }
                    else
                    {
                        urlOld1 = "../image/common/notimgpro.png";
                    }
                    if (nameurl2.Length > 0)
                    {
                        urlOld2 = "../image/advertise/" + nameurl2;
                    }
                    else
                    {
                        urlOld2 = "../image/common/notimgpro.png";
                    }
                }
            }
            catch
            {
                Response.Redirect("?menu=advertisespecial");
            }
        }
        if (!IsPostBack)
        {
            //Adbrand:
            try
            {
                BrandProduct_data dsBrand = new BrandProductSystem().BrandProAllType(int.Parse(Application["idtypeproduct"].ToString()));
                ListItem Item = new ListItem("Chọn nhãn hiệu", "0");
                slBrand.Items.Add(Item);
                if (dsBrand.Tables.Count > 0 && dsBrand.Tables[0].Rows.Count > 0)
                {
                    int num = dsBrand.Tables[0].Rows.Count;
                    for (int i = 0; i < num; i++)
                    {
                        Item = new ListItem(dsBrand.Tables[0].Rows[i]["name"].ToString(), dsBrand.Tables[0].Rows[i]["id"].ToString());
                        slBrand.Items.Add(Item);
                        if (idbrand == dsBrand.Tables[0].Rows[i]["id"].ToString())
                        {
                            slBrand.Items[i + 1].Selected = true;
                        }
                    }
                }
                Item = new ListItem("1", "1");
                slsort.Items.Add(Item);
                for (int i = 2; i <= 14; i++)
                {
                    Item = new ListItem(i + "", i + "");
                    slsort.Items.Add(Item);
                    if (i + "" == sort)
                    {
                        slsort.Items[i - 1].Selected = true;
                    }
                }
            }
            catch
            { }
        }
    }
    protected void btadd_ServerClick(object sender, EventArgs e)
    {
        try
        {
            string title = txttitle.Value.Trim();
            int idBrand = int.Parse(slBrand.Value);
            content = Request.Form["txtContent"].ToString().Trim();
            string link = txtlink.Value.Trim();
            string Url1 = nameurl1;
            string Url2 = nameurl2;
            int sort = int.Parse(slsort.Value.ToString().Trim());
            if (title.Length > 0)
            {
                DateTime time = new DateTime();
                time = DateTime.Now;
                CvalidateImageForPost manageImage = new CvalidateImageForPost();
                AdvertiseSystem Advertise = new AdvertiseSystem();
                if (ImageArticle1.PostedFile.FileName.Length > 0)
                {
                    Url1 = "special_1" + time.Ticks + "." + manageImage.GetExtension(ImageArticle1.PostedFile.FileName);
                }
                if (ImageArticle2.PostedFile.FileName.Length > 0)
                {
                    Url2 = "special_2" + time.Ticks + "." + manageImage.GetExtension(ImageArticle2.PostedFile.FileName);
                }
                Boolean test = Advertise.SpecialUpdate(id, idBrand, title, content, Url1, Url2, link, sort);
                if (test)
                {
                    diverror.Visible = true;
                    diverror.InnerHtml = "Quảng cáo đặc biệt đã được chỉnh sửa";
                    string path = Server.MapPath("../image/advertise/");
                    if (ImageArticle1.PostedFile.FileName.Length > 0)
                    {
                        if (manageImage.TestTypeFile(ImageArticle1))
                        {
                            if (manageImage.TestMaxSizeImage(ImageArticle1, 84280))
                            {
                                diverror.InnerHtml += "<br />Ảnh nhỏ không quá 70KB";
                            }
                            else
                            {
                                manageImage.UploadFile_server(ImageArticle1, path + Url1);
                                manageImage.DeleteFile(path + nameurl1);
                                urlOld1 = "../image/advertise/" + Url1;
                            }
                        }
                        else
                        {
                            diverror.InnerHtml += "<br />Chỉ hỗ trợ file dạng: gif, png, jpg, bmp, swf";
                        }
                    }

                    if (ImageArticle2.PostedFile.FileName.Length > 0)
                    {
                        if (manageImage.TestTypeFile(ImageArticle2))
                        {
                            if (manageImage.TestMaxSizeImage(ImageArticle2, 122880))
                            {
                                diverror.InnerHtml += "<br />Ảnh to không quá 120KB";
                            }
                            else
                            {
                                manageImage.UploadFile_server(ImageArticle2, path + Url2);
                                manageImage.DeleteFile(path + nameurl2);
                                urlOld2 = "../image/advertise/" + Url2;
                            }
                        }
                        else
                        {
                            diverror.InnerHtml += "<br />Chỉ hỗ trợ file dạng: gif, png, jpg, bmp, swf";
                        }
                    }
                    
                }
                else
                {
                    diverror.Visible = true;
                    diverror.InnerHtml = "Lỗi kết nối, xin hãy thử lại";
                }
            }
            else
            {
                diverror.Visible = true;
                diverror.InnerHtml = "Xin hãy nhập tiêu đề";
            }
        }
        catch
        {
            diverror.Visible = true;
            diverror.InnerHtml = "Xin hãy nhập tiêu đề";
        }
    }
}
