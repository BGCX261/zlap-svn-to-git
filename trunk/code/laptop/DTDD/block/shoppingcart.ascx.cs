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
using framework.list.bean;
public partial class block_shoppingcart : System.Web.UI.UserControl
{
    private string blCart = "Shopping cart";
    private string tnumber = "Number";
    private int Number = 0;
    private float Total = 0;
    public string str="";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            blCart = hash["blcart"].ToString();
            tnumber = hash["mnumber"].ToString();
        }
        catch
        { 
        
        }
        try
        {
            if (Session["ProductInCart"] != null)
            {
                ManagerProcart ManagePro = (ManagerProcart)Session["ProductInCart"];
                Number = ManagePro.GetNumBerPro();
                Total = ManagePro.TotalCostVND();
            }
            str = "<span class='txt8'>" + blCart + ":</span><br />";
            str += tnumber + ": <span class='txt7'>" + Number.ToString() + "</span><br />";
            str +="<span class='txt7'>" + Total.ToString("N").Split('.')[0] + " (VND)</span>";
        }
        catch
        { }
    }
}
