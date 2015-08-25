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

public partial class block_Center : System.Web.UI.UserControl
{
    public string strError = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string key = "";
            if (Request.QueryString["key"] != null)
            {
                key = Request.QueryString["key"].ToString();
                plhCenter.Controls.Add(Page.LoadControl("block/"+ key + ".ascx"));
            }
            string menu = "";
            if (Request.QueryString["menu"] != null)
            {
                menu = Request.QueryString["menu"].ToString();
                switch (menu)
                {
                    case "MessageLock":
                        plhCenter.Controls.Add(Page.LoadControl("block/MessageLock.ascx"));
                        break;
                    default:
                        plhCenter.Controls.Add(Page.LoadControl("block/MessageLock.ascx"));
                        break;
                }  
            }
        }
        catch (Exception ex)
        {

            strError = ex.ToString();
            //plhCenter.Controls.Add(Page.LoadControl("block/MessageLock.ascx"));
        }
    }
}
