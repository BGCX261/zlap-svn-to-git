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

public partial class IP : System.Web.UI.Page
{
    public string strIP = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        strIP = Request.ServerVariables["REMOTE_ADDR"] + ", " + Request.UserHostAddress;
    }
}
