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

public partial class admin_block_AddAdvertiseSpecial : System.Web.UI.UserControl
{
    public string content = "";
    protected void Page_Load(object sender, EventArgs e)
    {
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
                    }
                }
                Item = new ListItem("1", "1");
                slsort.Items.Add(Item);
                for (int i = 2; i <= 14; i++)
                {
                    Item = new ListItem(i + "", i + "");
                    slsort.Items.Add(Item);
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
            string Url1 = "";
            string Url2 = "";
            int sort = int.Parse(slsort.Value.ToString().Trim());
            int type = int.Parse(SlType.Text.ToString().Trim());
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
                Boolean test = Advertise.SpecialInsert(idBrand, title, content, Url1, Url2, link, sort, type);
                if (test)
                {
                    diverror.Visible = true;
                    diverror.InnerHtml = "Quảng cáo đặc biệt đã được thêm mới";
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

                            }
                        }
                        else
                        {
                            diverror.InnerHtml += "<br />Chỉ hỗ trợ file dạng: gif, png, jpg, bmp, swf";
                        }
                    }
                    //Update Image:
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
    protected void Onchange_ServerClick(object sender, EventArgs e)
    {
        try
        {
            int idtype = 1;
            if (SlType.Text.Equals("1"))
            {
                idtype = int.Parse(Application["idtypeproduct"].ToString());
            }
            else if (SlType.Text.Equals("2"))
            {
                idtype = int.Parse(Application["idtypemobile"].ToString());
            }
            BrandProduct_data dsBrand = new BrandProductSystem().BrandProAllType(idtype);
            ListItem Item = new ListItem("Chọn nhãn hiệu", "0");
            slBrand.Items.Clear();
            slBrand.Items.Add(Item);
            if (dsBrand.Tables.Count > 0 && dsBrand.Tables[0].Rows.Count > 0)
            {
                int num = dsBrand.Tables[0].Rows.Count;
                for (int i = 0; i < num; i++)
                {
                    Item = new ListItem(dsBrand.Tables[0].Rows[i]["name"].ToString(), dsBrand.Tables[0].Rows[i]["id"].ToString());
                    slBrand.Items.Add(Item);
                }
            }
        }
        catch
        {

        }
    }
}
