using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        try
        {
            //test user Login:
            if (Session["UserLogin"] == null)
            {
                //Response.Redirect("LoginWebsite.aspx");
            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.ToString());
        }
        try
        {
            plhHeader.Controls.Add(Page.LoadControl("block/Header.ascx"));
            plhLeft.Controls.Add(Page.LoadControl("block/Left.ascx"));
            plhCenter.Controls.Add(Page.LoadControl("block/Center.ascx"));
        }
        catch
        {

        }
    }
}