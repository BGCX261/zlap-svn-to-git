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

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btlogin_Click(object sender, EventArgs e)
    {
        try
        {
            string username=txtusername.Value.Trim();
            string pass=txtpass.Value.Trim();
            DataSet dsuser = new CmanagerAdmin().AdminSelectUsernamePass(username, pass);
            if (dsuser.Tables.Count > 0)
            {
                if (dsuser.Tables[0].Rows.Count>0)
                {
                    Session["UserLogin"] = dsuser.Tables[0];
                    Response.Redirect("Mainpage.aspx");
                }
            }
        }
        catch
        { }
    }
}
