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

public partial class block_center : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string urlMenu = "";
        try
        {
            urlMenu=Request.QueryString["menu"].ToString();
        }
        catch (Exception ex)
        {
            //Console.Write(ex.ToString());
        }
        try
        {
            switch (urlMenu)
            { 
                case "product":
                    plhcenter.Controls.Add(Page.LoadControl("block/productall.ascx"));
                    break;
                case "pro":
                    plhcenter.Controls.Add(Page.LoadControl("block/ProductWithBrandName.ascx"));
                    break;
                case "dp":
                    plhcenter.Controls.Add(Page.LoadControl("block/DetailProduct.ascx"));
                    //plhcenter.Controls.Add(Page.LoadControl("block/ProPrepareout.ascx"));
                    break;
                case "nh":
                    plhcenter.Controls.Add(Page.LoadControl("block/ProductNewHaveAll.ascx"));
                    //plhcenter.Controls.Add(Page.LoadControl("block/ProPrepareout.ascx"));
                    break;
                case "qsp":
                    plhcenter.Controls.Add(Page.LoadControl("block/QuickSearchProduct.ascx"));
                    break;
                case "asp":
                    plhcenter.Controls.Add(Page.LoadControl("block/AdvanceSearch.ascx"));
                    break;
                case "dasp":
                    plhcenter.Controls.Add(Page.LoadControl("block/AdvanceSearchDetail.ascx"));
                    break;
                case "wh":
                    plhcenter.Controls.Add(Page.LoadControl("block/ProductWillHave.ascx"));
                    break;
                case "originalpro":
                    plhcenter.Controls.Add(Page.LoadControl("block/OriginalPro.ascx"));
                    //plhcenter.Controls.Add(Page.LoadControl("block/ProPrepareout.ascx"));
                    break;
                case "compare":
                    plhcenter.Controls.Add(Page.LoadControl("block/ComparePro.ascx"));
                    break;
                case "shoppingcart":
                    plhcenter.Controls.Add(Page.LoadControl("block/DetailCart.ascx"));
                    break;
                case "addpro":
                    plhcenter.Controls.Add(Page.LoadControl("block/AddNewProductToCart.ascx"));
                    break;
                case "order":
                    plhcenter.Controls.Add(Page.LoadControl("block/OrderProduct.ascx"));
                    break;
                case "yesorder":
                    plhcenter.Controls.Add(Page.LoadControl("block/SuccessFulOrder.ascx"));
                    plhcenter.Controls.Add(Page.LoadControl("block/Contacts.ascx"));
                    break;
                case "price":
                    plhcenter.Controls.Add(Page.LoadControl("block/ReportPrice.ascx"));
                    break;
                case ("register"):
                    plhcenter.Controls.Add(Page.LoadControl("block/RegistUser.ascx"));
                    break;
                case ("com"):
                    plhcenter.Controls.Add(Page.LoadControl("block/ComponentAll.ascx"));
                    break;
                    case ("igc"):
                    plhcenter.Controls.Add(Page.LoadControl("block/ComponentInGroup.ascx"));
                    break;
                case ("qsc"):
                    plhcenter.Controls.Add(Page.LoadControl("block/ComponentForQuickSearch.ascx"));
                    break;
                case ("dc"):
                    plhcenter.Controls.Add(Page.LoadControl("block/DetailComponent.ascx"));
                    break;
                //article
                case ("article"):
                    plhcenter.Controls.Add(Page.LoadControl("block/Articles.ascx"));
                    break;
                //ArticlesInGroup.ascx
                case ("ga"):
                    plhcenter.Controls.Add(Page.LoadControl("block/ArticlesInGroup.ascx"));
                    break;
                //ArticleDetail.ascx
                case ("da"):
                    plhcenter.Controls.Add(Page.LoadControl("block/ArticleDetail.ascx"));
                    break;
                //Send feedback:
                case ("feedback"):
                    plhcenter.Controls.Add(Page.LoadControl("block/SendIdea.ascx"));
                    break;
                case ("changeaccount"):
                    plhcenter.Controls.Add(Page.LoadControl("block/ChangeAccount.ascx"));
                    break;
                case ("manageorder"):
                    plhcenter.Controls.Add(Page.LoadControl("block/UserManageOrder.ascx"));
                    break;
                case ("dorder"):
                    plhcenter.Controls.Add(Page.LoadControl("block/Orderdetail.ascx"));
                    break;
                case ("sendemail"):
                    plhcenter.Controls.Add(Page.LoadControl("block/SendContactEmail.ascx"));
                    break;
                case ("successfeedback"):
                    plhcenter.Controls.Add(Page.LoadControl("block/SuccessfulSendFeedback.ascx"));
                    break;
                case ("introduce"):
                    plhcenter.Controls.Add(Page.LoadControl("block/IntroduceCompany.ascx"));
                    break;
                case ("help"):
                    plhcenter.Controls.Add(Page.LoadControl("block/Helps.ascx"));
                    break;
                case ("contact"):
                    plhcenter.Controls.Add(Page.LoadControl("block/Contacts.ascx"));
                    break;
                //ForgotPass
                case ("forgotPass"):
                    plhcenter.Controls.Add(Page.LoadControl("block/ForgotPass.ascx"));
                    break;
                case ("newpass"):
                    plhcenter.Controls.Add(Page.LoadControl("block/UserGetNewPassword.ascx"));
                    break;
                case "pda":
                    plhcenter.Controls.Add(Page.LoadControl("block/PocketPcAll.ascx"));
                    break;
                case "dpda":
                    plhcenter.Controls.Add(Page.LoadControl("block/DetailPocketPc.ascx"));
                    break;
                case "other":
                    plhcenter.Controls.Add(Page.LoadControl("block/OtherProductAll.ascx"));
                    break;
                case "dother":
                    plhcenter.Controls.Add(Page.LoadControl("block/OtherDetail.ascx"));
                    break;
                default:
                    plhcenter.Controls.Add(Page.LoadControl("block/promainpage.ascx"));
                    break;
            }
        }
        catch (Exception ex)
        {
            //Console.Write(ex.ToString());
        }
    }
}