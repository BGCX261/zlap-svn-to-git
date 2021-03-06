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
using common.list.WebUser;
using facade.list;
using framework.list.common;

public partial class admin_block_UserAdd : System.Web.UI.UserControl
{
    public int id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        diverror.Visible = false;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.txtUserName.Value.Trim().Length == 0)
            {
                diverror.InnerHtml = "<div class='diverror'>Xin hãy nhập tài khoản</div>";
                diverror.Visible = true;
                this.txtPassword1.Focus();
                return;
            }
            if (this.txtPassword.Value.Trim().Length == 0)
            {
                diverror.InnerHtml = "<div class='diverror'>Xin hãy nhập mật khẩu</div>";
                diverror.Visible = true;
                this.txtPassword.Focus();
                return;
            }
            if (this.txtPassword1.Value.Trim().Length == 0)
            {
                diverror.InnerHtml = "<div class='diverror'>Xin hãy nhập lại mật khẩu</div>";
                diverror.Visible = true;
                this.txtPassword1.Focus();
                return;
            }
            if (!this.txtPassword1.Value.Trim().Equals(this.txtPassword.Value.Trim()))
            {
                diverror.InnerHtml = "<div class='diverror'>Mật khẩu không khớp</div>";
                diverror.Visible = true;
                this.txtPassword1.Focus();
                return;
            }

            WebUser wu = new WebUser();
            wu.Id = this.id;
            wu.UserName = this.txtUserName.Value.Trim();
            wu.Password = new MD5().Encrypt(this.txtPassword.Value.Trim());
            if (new WebUserFC().CheckExist(wu))
            {
                diverror.InnerHtml = "<div class='diverror'>Tài khoản bạn nhập đã tồn tại</div>";
                diverror.Visible = true;
                this.txtUserName.Focus();
                return;
            }
            this.id = new WebUserFC().Insert(wu);
            if (this.id > 0)
            {
                diverror.InnerHtml = "<div class='diverror'>Thông tin đã được cập nhật</div>";
                diverror.Visible = true;
                this.id = 0;
                this.txtUserName.Value = "";
                this.txtPassword.Value = "";
                this.txtPassword1.Value = "";
                this.txtUserName.Focus();
                //Response.Redirect("AdminWebsite.aspx?menu=addUser");
            }
        }
        catch (Exception ex)
        {
            diverror.InnerHtml = "<div class='diverror'>" + ex.Message + "</div>";
            diverror.Visible = true;
            this.txtUserName.Focus();
            return;
        }
    }

    protected void btnback_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("AdminWebsite.aspx?menu=UserManage");
        }
        catch (Exception ex)
        {
            diverror.InnerHtml = "<div class='diverror'>" + ex.Message + "</div>";
            diverror.Visible = true;
            this.txtUserName.Focus();
            return;
        }
    }
}
