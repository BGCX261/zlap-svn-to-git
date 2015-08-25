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

public partial class admin_AdminWebsite : System.Web.UI.Page
{
    public string tblcenter = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserLoginAdmin"] == null)
        {
            Response.Redirect("LoginAdmin.aspx");
        }
        if (Application["idtypeproduct"] == null)
        {
            SetAppTypeProduct();
        }
        try
        {
            string menu = Request.QueryString["menu"].ToString();
            switch (menu)
            {
                case ("imgpro"):
                    tblcenter = "Cập nhật thông tin sản phẩm";
                    plhFunc.Controls.Add(Page.LoadControl("block/UploadImgProduct.ascx"));
                    break;
                case ("imgpromotion"):
                    tblcenter = "Cập nhật ảnh khuyến mãi !";
                    plhFunc.Controls.Add(Page.LoadControl("block/UploadImagePromation.ascx"));
                    break;
                case ("imgpromulti"):
                    tblcenter = "Tập hợp ảnh sản phẩm";
                    plhFunc.Controls.Add(Page.LoadControl("block/UploadmultiImgProduct.ascx"));
                    break;
                case ("updateDes"):
                    tblcenter = "Cập nhật thông tin mô tả sản phẩm";
                    plhFunc.Controls.Add(Page.LoadControl("block/ProductDesUpdate.ascx"));
                    break;
                case ("imgcom"):
                    tblcenter = "Cập nhật ảnh linh kiện";
                    plhFunc.Controls.Add(Page.LoadControl("block/UPdateImageComponent.ascx"));
                    break;
                case ("probestsell"):
                    tblcenter = "Sản phẩm bán chạy nhất";
                    plhFunc.Controls.Add(Page.LoadControl("block/ManageProBestSell.ascx"));
                    break;
                case ("projusthave"):
                    tblcenter = "Hàng mới về";
                    plhFunc.Controls.Add(Page.LoadControl("block/ManagerJustHave.ascx"));
                    break;
                //proselloff:
                case ("proselloff"):
                    tblcenter = "Hàng giảm giá";
                    plhFunc.Controls.Add(Page.LoadControl("block/ManagerProSelloff.ascx"));
                    break;
                case ("promainpage"):
                    tblcenter = "Sản phẩm hiển thị ở trang chính";
                    plhFunc.Controls.Add(Page.LoadControl("block/ManageProMainpage.ascx"));
                    break;
                case ("article"):
                    tblcenter = "Quản lý tin tức";
                    plhFunc.Controls.Add(Page.LoadControl("block/ManageArticles.ascx"));
                    break;
                case ("grouparticle"):
                    tblcenter = "Quản lý nhóm tin tức";
                    plhFunc.Controls.Add(Page.LoadControl("block/ManageGroupArticle.ascx"));
                    break;
                case ("addgroup"):
                    tblcenter = "Thêm mới nhóm tin tức";
                    plhFunc.Controls.Add(Page.LoadControl("block/GroupArticleInsert.ascx"));
                    break;
                case ("editga"):
                    tblcenter = "Chỉnh sửa nhóm tim tức";
                    plhFunc.Controls.Add(Page.LoadControl("block/GroupArticleEdit.ascx"));
                    break;
                case ("addarticle"):
                    tblcenter = "Thêm mới tin tức";
                    plhFunc.Controls.Add(Page.LoadControl("block/ArticleInsert.ascx"));
                    break;
                case ("edita"):
                    tblcenter = "Chỉnh sửa tin tức";
                    plhFunc.Controls.Add(Page.LoadControl("block/ArticleUpdate.ascx"));
                    break;
                    //contact:
                case ("contact"):
                    tblcenter = "Quản lý địa chỉ liên hệ";
                    plhFunc.Controls.Add(Page.LoadControl("block/Contacts.ascx"));
                    break;
                case ("addcontact"):
                    tblcenter = "Thêm mới địa chỉ liên hệ";
                    plhFunc.Controls.Add(Page.LoadControl("block/ContactAdd.ascx"));
                    break;
                case ("editcontact"):
                    tblcenter = "Chỉnh sửa địa chỉ liên hệ";
                    plhFunc.Controls.Add(Page.LoadControl("block/ContactEdit.ascx"));
                    break;
                    //groupcontact
                case ("groupcontact"):
                    tblcenter = "Quản lý nhóm liên hệ";
                    plhFunc.Controls.Add(Page.LoadControl("block/GroupContacts.ascx"));
                    break;
                //GroupContactAdd.ascx
                case ("addgroupcontact"):
                    tblcenter = "Thêm mới nhóm liên hệ";
                    plhFunc.Controls.Add(Page.LoadControl("block/GroupContactAdd.ascx"));
                    break;
                //GroupContactEdit.ascx
                case ("editgroupcontact"):
                    tblcenter = "Chỉnh sửa nhóm liên hệ";
                    plhFunc.Controls.Add(Page.LoadControl("block/GroupContactEdit.ascx"));
                    break;
                //Locationcontacts.ascx
                case ("locationcontact"):
                    tblcenter = "Khu vực liên hệ";
                    plhFunc.Controls.Add(Page.LoadControl("block/LocationContacts.ascx"));
                    break;
                case ("addlocationcontact"):
                    tblcenter = "Thêm mới khu vực liên hệ";
                    plhFunc.Controls.Add(Page.LoadControl("block/LocationContactAdd.ascx"));
                    break;
                case ("editlocationcontact"):
                    tblcenter = "Chỉnh sửa khu vực liên hệ";
                    plhFunc.Controls.Add(Page.LoadControl("block/LocationContactEdit.ascx"));
                    break;
                    //Helps:
                case ("help"):
                    tblcenter = "Trợ giúp trên website";
                    plhFunc.Controls.Add(Page.LoadControl("block/Helps.ascx"));
                    break;
                case ("addhelp"):
                    tblcenter = "Thêm mới trợ giúp";
                    plhFunc.Controls.Add(Page.LoadControl("block/HelpAdd.ascx"));
                    break;
                case ("edithelp"):
                    tblcenter = "Chỉnh sửa trợ giúp";
                    plhFunc.Controls.Add(Page.LoadControl("block/HelpEdit.ascx"));
                    break;
                case ("onlinesupport"):
                    tblcenter = "Hỗ trợ trực tuyến";
                    plhFunc.Controls.Add(Page.LoadControl("block/SupportOnline.ascx"));
                    break;
                case ("onlinesupportadd"):
                    tblcenter = "Thêm mới hỗ trợ trực tuyến";
                    plhFunc.Controls.Add(Page.LoadControl("block/SupportOnlineAdd.ascx"));
                    break;
                case ("onlinesupportedit"):
                    tblcenter = "Chỉnh sửa hỗ trợ trực tuyến";
                    plhFunc.Controls.Add(Page.LoadControl("block/SupportOnlineEdit.ascx"));
                    break;
                case ("langcode"):
                    tblcenter = "Quản lý từ khóa chuẩn";
                    plhFunc.Controls.Add(Page.LoadControl("block/LanguageCode.ascx"));
                    break;
                case ("langcontent"):
                    tblcenter = "Nội dung ngôn ngữ";
                    plhFunc.Controls.Add(Page.LoadControl("block/LanguageContent.ascx"));
                    break;
                case ("langsupport"):
                    tblcenter = "Ngôn ngữ hỡ trợ";
                    plhFunc.Controls.Add(Page.LoadControl("block/LanguageManager.ascx"));
                    break;
                //advertisespecial
                case ("advertisespecial"):
                    tblcenter = "Quảng cáo đặc biệt";
                    plhFunc.Controls.Add(Page.LoadControl("block/AdvertiseSpecialManager.ascx"));
                    break;
                //add advertise special
                case ("addadvertisespecial"):
                    tblcenter = "Thêm mới quảng cáo đặc biệt";
                    plhFunc.Controls.Add(Page.LoadControl("block/AddAdvertiseSpecial.ascx"));
                    break;
                //editadspecial
                case ("editadspecial"):
                    tblcenter = "Chỉnh sửa quảng cáo đặc biệt";
                    plhFunc.Controls.Add(Page.LoadControl("block/EditAdvertiseSpecial.ascx"));
                    break;
                case ("linkweb"):
                    tblcenter = "Danh liên kết website";
                    plhFunc.Controls.Add(Page.LoadControl("block/AdvertiseManager.ascx"));
                    break;
                case ("addlinkweb"):
                    tblcenter = "Thêm mới liên kết website";
                    plhFunc.Controls.Add(Page.LoadControl("block/addAdvertise.ascx"));
                    break;
                case ("editadvertise"):
                    tblcenter = "Chỉnh sửa liên kết website";
                    plhFunc.Controls.Add(Page.LoadControl("block/editAdvertise.ascx"));
                    break;
                case ("pda"):
                    tblcenter = "Cập nhật ảnh cho pocket pc, PDA";
                    plhFunc.Controls.Add(Page.LoadControl("block/UploadImagePda.ascx"));
                    break;
                case ("otherpro"):
                    tblcenter = "Ảnh các sản phẩm khác";
                    plhFunc.Controls.Add(Page.LoadControl("block/UploadImageOrtherPro.ascx"));
                    break;
                case ("currency"):
                    tblcenter = "Thay đổi tiền tệ hiển thị";
                    plhFunc.Controls.Add(Page.LoadControl("block/ChangeCurrency.ascx"));
                    break;
                case ("updateUSD"):
                    tblcenter = "Cập nhật tỷ giá USD";
                    plhFunc.Controls.Add(Page.LoadControl("block/UpdateUSD.ascx"));
                    break;
                //managerUser
                case ("UserManage"):
                    tblcenter = "Quản lý tài khoản đăng nhập";
                    plhFunc.Controls.Add(Page.LoadControl("block/UserManage.ascx"));
                    break;
                case ("editUser"):
                    tblcenter = "Sửa tài khoản đăng nhập";
                    plhFunc.Controls.Add(Page.LoadControl("block/UserEdit.ascx"));
                    break;
                case ("addUser"):
                    tblcenter = "Thêm mới tài khoản đăng nhập";
                    plhFunc.Controls.Add(Page.LoadControl("block/UserAdd.ascx"));
                    break;
                case ("Editbottom"):
                    tblcenter = "Sửa chân trang";
                    plhFunc.Controls.Add(Page.LoadControl("block/EditBottom.ascx"));
                    break;
                case ("original"):
                    tblcenter = "Danh sách hàng độc";
                    plhFunc.Controls.Add(Page.LoadControl("block/ManagerOriginal.ascx"));
                    break;
                case ("prepareout"):
                    tblcenter = "Quản lý sản phẩm sắp hết hàng";
                    plhFunc.Controls.Add(Page.LoadControl("block/managerPrepareout.ascx"));
                    break;
                //UploadImageMobile:
                case ("imgmobile"):
                    tblcenter = "Cập nhật ảnh điện thoại";
                    plhFunc.Controls.Add(Page.LoadControl("block/UploadImageMobile.ascx"));
                    break;
                case ("mobile1"):
                    tblcenter = "Quản lý điện thoại ở trang chính";
                    plhFunc.Controls.Add(Page.LoadControl("block/MobileMainPage.ascx"));
                    break;
                case ("mobile2"):
                    tblcenter = "Quản lý điện thoại bán chạy nhất";
                    plhFunc.Controls.Add(Page.LoadControl("block/MobileBestSell.ascx"));
                    break;
                case ("mobile3"):
                    tblcenter = "Quản lý điện thoại độc đáo";
                    plhFunc.Controls.Add(Page.LoadControl("block/MobileOriginal.ascx"));
                    break;
                case ("downloadprice"):
                    tblcenter = "Quản lý tải báo giá";
                    plhFunc.Controls.Add(Page.LoadControl("block/Downloadprice.ascx"));
                    break;
                    
                default:
                    //plhFunc.Controls.Add(Page.LoadControl("block/UploadImgProduct.ascx"));
                    break;
            }

        }
        catch
        { 
        
        }
    }
    public void SetAppTypeProduct()
    {
        try
        {
            XmlDocument doc = new XmlDocument();
            string xpath = Server.MapPath("../data/xml/configproduct.xml");
            XmlTextReader reader = new XmlTextReader(xpath);
            doc.Load(reader);
            reader.Close();
            XmlNodeList nodes = doc.SelectNodes("/root/product");
            int numnodes = nodes.Count;
            for (int i = 0; i < numnodes; i++)
            {
                string nameapp = nodes.Item(i).ChildNodes[0].InnerText;
                string idtype = nodes.Item(i).ChildNodes[1].InnerText;
                string appunit = nodes.Item(i).ChildNodes[2].InnerText;
                string unit = nodes.Item(i).ChildNodes[3].InnerText;
                if (nameapp.Length > 0 && idtype.Length > 0)
                {
                    Application[nameapp] = int.Parse(idtype);
                }
                if (appunit.Length > 0 && unit.Length > 0)
                {
                    Application[appunit] = unit;
                }
            }
        }
        catch
        {

        }
    }
}
