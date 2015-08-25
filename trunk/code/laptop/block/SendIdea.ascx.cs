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
public partial class block_SendIdea : System.Web.UI.UserControl
{
    public string tblFeedback = "Đóng góp ý kiến với chúng tôi";
    public string tmessageInfo = "Bạn chưa đăng nhập. Xin hãy đăng ký để đóng góp ý kiến";
    public string tminputvalue = "Xin bạn hãy nhập các thông tin cần thiết để đóng góp ý kiến với chúng tôi";
    public string ttile = "Tiêu đề";
    public string tcontent = "Nội dung";
    public string tname = "Họ và tên";
    public string tphone = "Điện thoại";
    public string temail = "Địa chỉ email";
    public string errors = "Xin hãy nhập đầy đủ thông tin cần thiết";
    public string currentAccess = "";
    public string thome = "";
    string feedback = "";
    UserManagerSystem UserManager = new UserManagerSystem();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            currentAccess = hash["currentpage"].ToString();
            thome = hash["home"].ToString();
            feedback = hash["feedback"].ToString();
            currentAccess += ": <a href='?menu=home'>" + thome + "</a> &raquo; " + feedback;
            if (Session["infoUser"] != null)
            {
                tmessageInfo = tminputvalue;
            }
            if (!IsPostBack)
            {
                divErrors.Disabled = true;
                if (Session["infoUser"] != null)
                {
                    string[] arrInfo = (string[])Session["infoUser"];
                    DataSet ds=UserManager.UserGetInforFeedBack(arrInfo[0]);
                    if (ds.Tables.Count > 0)
                    {
                        txtName.Value = ds.Tables[0].Rows[0]["ContactName"].ToString();
                        txtEmail.Value = ds.Tables[0].Rows[0]["Email1"].ToString();

                        string strPhone="";
                        if (ds.Tables[0].Rows[0]["MobilePhone"].ToString().Length > 0)
                        {
                            strPhone += ds.Tables[0].Rows[0]["MobilePhone"].ToString() + " ; ";
                        }
                        if (ds.Tables[0].Rows[0]["OfficePhone"].ToString().Length > 0)
                        {
                            strPhone += ds.Tables[0].Rows[0]["OfficePhone"].ToString() + " ; ";
                        }
                        if (ds.Tables[0].Rows[0]["HomePhone"].ToString().Length > 0)
                        {
                            strPhone += ds.Tables[0].Rows[0]["HomePhone"].ToString();
                        }

                        txtPhone.Value = strPhone;
                    }
                }
            }
        }
        catch
        { 
        
        }
    }
    protected void btfeedback_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if (Session["infoUser"] != null)
            {
                string title = txtTitle.Value.Trim();
                string content = txtcontent.Value.Trim();
                if ((title.Length == 0) || (content.Length == 0))
                {
                    divErrors.Disabled = false;
                    divErrors.InnerHtml = "<br /><div class='diverror'>" + errors + "</div>";
                }
                else
                {
                    string[] arrInfo = (string[])Session["infoUser"];
                    DateTime time = new DateTime();
                    time = DateTime.Now;
                    Boolean test = UserManager.UserSendFeedback(int.Parse(arrInfo[0]), title, content, time, 2);
                    if (test)
                    {
                        Response.Redirect("Default.aspx?menu=successfeedback");
                    }
                    else
                    {
                        divErrors.Disabled = false;
                        divErrors.InnerHtml = "<br /><div class='diverror'>" + tmessageInfo + "</div>";
                    }
                }
            }
            else
            {
                divErrors.Disabled = false;
                divErrors.InnerHtml = "<br /><div class='diverror'>" + tmessageInfo + "</div>";
            }
        }
        catch
        { 
        
        }
    }
}
