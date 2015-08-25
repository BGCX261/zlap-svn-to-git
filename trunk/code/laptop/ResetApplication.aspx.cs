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

public partial class ResetApplication : System.Web.UI.Page
{
    public string strValue = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Application["idtypeproduct"] = null;
            Application["listBrandPro"] = null;
            Application["listBrandMobile"] = null;
            Application["nav_language_code"] = null;
            Application["AppFooter"] = null;
            Application["AppMobileFooter"] = null;
            strValue = "Ok";
        }
        catch (Exception ex)
        {
            strValue = "err";
        }
        Response.Write(strValue);
    }
}
