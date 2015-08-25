using System;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class block_CatalogueProduct : System.Web.UI.UserControl
{
    public string tcom = "";
    public string blcatalogue = "";
    public string tlaptop = "";
    public string tpocketpc = "";
    public string totherpro = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            blcatalogue = hash["listpro"].ToString();
            tlaptop = hash["product"].ToString();
            tcom = hash["component"].ToString();
            tpocketpc = hash["pocketpc"].ToString();
            totherpro = hash["otherpro"].ToString();
        }
        catch
        { }
    }
}
