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

public partial class block_left : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            plhleft.Controls.Add(Page.LoadControl("block/brandproduct.ascx"));
            plhleft.Controls.Add(Page.LoadControl("block/quicksearch.ascx"));
            plhleft.Controls.Add(Page.LoadControl("block/OriginalProTop.ascx"));
            plhleft.Controls.Add(Page.LoadControl("block/advertise.ascx"));
            plhleft.Controls.Add(Page.LoadControl("block/statistics.ascx"));
        }
        catch (Exception ex)
        {
            Console.Write(ex.ToString());
        }
    }
}
