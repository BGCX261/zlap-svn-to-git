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
            string url = "";
            ////plhleft.Controls.Add(Page.LoadControl("block/quicksearch.ascx"));
            plhleft.Controls.Add(Page.LoadControl("block/CatalogueProduct.ascx"));
            //try
            //{
            //    if (Request.QueryString["menu"] != null)
            //    {
            //        url = Request.QueryString["menu"].ToString();
            //    }
            //    switch (url)
            //    {
            //        case ("com"):
            //            plhleft.Controls.Add(Page.LoadControl("block/GroupComponent.ascx"));
            //            break;
            //        case ("igc"):
            //            plhleft.Controls.Add(Page.LoadControl("block/GroupComponent.ascx"));
            //            break;
            //        case ("qsc"):
            //            plhleft.Controls.Add(Page.LoadControl("block/GroupComponent.ascx"));
            //            break;
            //        case ("dc"):
            //            plhleft.Controls.Add(Page.LoadControl("block/DetailComponent.ascx"));
            //            plhleft.Controls.Add(Page.LoadControl("block/GroupComponent.ascx"));
            //            break;
            //        case ("pda"):
            //            plhleft.Controls.Add(Page.LoadControl("block/GroupPda.ascx"));
            //            break;
            //        default:
            //            break;
            //    }
            //}
            //catch
            //{
            //    ClassifyProduct.ascx
            //    plhleft.Controls.Add(Page.LoadControl("block/ClassifyProduct.ascx"));
            //    plhleft.Controls.Add(Page.LoadControl("block/brandproduct.ascx"));
            //}
            //plhleft.Controls.Add(Page.LoadControl("block/brandproduct.ascx"));
            //Trong phan Default chuyen ra:
            plhleft.Controls.Add(Page.LoadControl("block/ClassifyProduct.ascx"));
            plhleft.Controls.Add(Page.LoadControl("block/brandproduct.ascx"));
            plhleft.Controls.Add(Page.LoadControl("block/GroupComponent.ascx"));
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
