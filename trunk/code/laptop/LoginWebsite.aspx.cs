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

public partial class LoginWebsite : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btlogin_Click(object sender, EventArgs e)
    {
        try
        {
            string user = txtUserName.Value;
            string pass = txtPass.Value;
            if(user.Equals("adminweb") &&(pass.Equals("maytinhxachtay")))
            {
                Session["IsLoginWeb"] = true;
                Response.Redirect("Default.aspx");
            }
        }
        catch
        { 
        
        }
    }
}
