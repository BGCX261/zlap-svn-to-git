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
public partial class block_UserGetNewPassword : System.Web.UI.UserControl
{
    public string name = "";
    public string email = "";
    public string tmessage = "Chào bạn";
    public string tpass = "mật khẩu";
    public string tbtsubmit = "Đồng ý";
    public string tcomfirmpass = "Xác nhận mật khẩu";
    public string tbl = "Tạo mật khẩu cho tài khoản đăng nhập";
    public string terrpass = "Xin bạn hãy nhập đầy đủ dữ liệu";
    public string tpassleng = "Mật khẩu phải từ 4 đến 15 ký tự.";
    public string tincorrect = "Mật khẩu không giống nhau";
    public string terrUpdate = "Lỗi kết nối SQL. Xin bạn hãy thử lại.";
    public string tyestochange = "Mật khẩu đã được tạo. Xin bạn hãy đăng nhập";
    UserManagerSystem UserManager = new UserManagerSystem();
    DataSet UserDs = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btsubmit.Text = tbtsubmit;
        }
        try
        {
            string code = Request.QueryString["code"].ToString();
            if (code.Length == 32)
            {
                UserDs = UserManager.UserTestInfoGetNewPass(code);
                if (UserDs.Tables.Count > 0)
                {
                    if (UserDs.Tables[0].Rows.Count > 0)
                    {
                        email = UserDs.Tables[0].Rows[0]["email"].ToString();
                        name = UserDs.Tables[0].Rows[0]["name"].ToString();
                        tmessage += ": " + name + ". Xin bạn hãy nhập mật khẩu mới:";
                    }
                    else
                    {
                        tmessage = "Mã yêu cầu không tồn tại. Có thể yêu cầu của bạn đã quá hạn 7 ngày. Kể từ ngày bạn yêu cầu. Xin bạn hãy gửi yêu cầu lại từ chức năng quyên mật khẩu. Xin cảm ơn.";
                        divshow.Visible = false;
                    }
                }
            }
            else
            {
                Response.Redirect("Default.aspx?menu=home");
            }
        }
        catch
        {
            Response.Redirect("Default.aspx?menu=home");
        }
    }
    protected void btsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (email.Length == 0)
            {
                divshow.Visible = false;
                return;
            }
            string pass1 = txtpass.Value.Trim();
            string pass2 = txtpass1.Value.Trim();
            if (pass1.Length == 0)
            {
                divErrors.Visible = true;
                divErrors.InnerHtml = "<div class='diverror'>" + terrpass + "</div>";
                return;
            }
            else if (pass1.Length < 4)
            {
                divErrors.Visible = true;
                divErrors.InnerHtml = "<div class='diverror'>" + tpassleng + "</div>";
                return;
            }
            else if (!pass1.Equals(pass2))
            {
                divErrors.Visible = true;
                divErrors.InnerHtml = "<div class='diverror'>" + tincorrect + "</div>";
                return;
            }
            //Insertpass:
            MD5 md5=new MD5();
            string encodepass = md5.Encrypt(pass1);
            if (UserManager.UserUpdateNewPass(email, encodepass))
            {
                tmessage = tyestochange;
                divshow.Visible = false;
                return;
            }
            else
            {
                divErrors.Visible = true;
                divErrors.InnerHtml = "<div class='diverror'>" + terrUpdate + "</div>";
                return;
            }
        }
        catch
        { }
    }
}
