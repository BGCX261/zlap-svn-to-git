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

public partial class block_right : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            
            plhright.Controls.Add(Page.LoadControl("block/SupportOnline.ascx"));
            if (Session["infoUser"] == null)
            {
                //plhright.Controls.Add(Page.LoadControl("block/userlogin.ascx"));
            }
            else
            {
                //plhright.Controls.Add(Page.LoadControl("block/FuncUser.ascx"));
            }
            //plhright.Controls.Add(Page.LoadControl("block/shoppingcart.ascx"));
            plhright.Controls.Add(Page.LoadControl("block/probestsell.ascx"));
            plhright.Controls.Add(Page.LoadControl("block/ProductNewHave.ascx"));
        }
        catch (Exception ex)
        {
            Console.Write(ex.ToString());
        }
    }
}
