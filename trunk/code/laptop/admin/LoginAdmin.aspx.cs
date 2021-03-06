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
using common.list.WebUser;
using framework.list.common;

public partial class admin_LoginAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.diverror.Visible = false;
        if (!IsPostBack)
        {
            Session["UserLoginAdmin"] = null;
        }
        if (Session["UserLoginAdmin"] != null)
        {
            Response.Redirect("AdminWebsite.aspx");
        }
    }
    protected void btlogin_Click(object sender, EventArgs e)
    {
        try
        {
            string userName = txtUserName.Value.Trim();
            string pass = txtPassword.Value.Trim();
            DataTable tbl = new WebUserFC().Select("Select * from " + WebUserCM.TABLE_NAME + " Where " + WebUserCM.FLD_USERNAME + "='" + userName + "'");
            //Session["UserLoginAdmin"] = userName;
            //Response.Redirect("AdminWebsite.aspx");
            if (tbl.Rows.Count != 1)
            {
                this.diverror.Visible = true;
                this.diverror.InnerHtml = "<div class='diverror'>Người dùng không tồn tại</div>";
                this.txtUserName.Focus();
                return;
            }
            else
            {
                DataRow dr = tbl.Rows[0];
                string dbpass = dr[WebUserCM.FLD_PASSWORD].ToString();
                MD5 md5 = new MD5();
                if (!md5.Verify(pass, dbpass)) 
                {
                    this.diverror.Visible = true;
                    this.diverror.InnerHtml = "<div class='diverror'>Mật khẩu không chính xác</div>";
                    this.txtUserName.Focus();
                    return;
                }
                else
                {
                    Session["UserLoginAdmin"] = userName;
                    Response.Redirect("AdminWebsite.aspx");
                }
            }
        }
        catch
        {

        }
    }
}
