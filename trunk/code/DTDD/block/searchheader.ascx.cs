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

public partial class block_searchheader : System.Web.UI.UserControl
{
    public string tsearch = "";
    public string msearch = "";
    public string tpro = "";
    public string tcom = "";
    public string avsearch = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            tsearch = hash["tsearch"].ToString();
            msearch = hash["msearch"].ToString();
            avsearch = hash["avsearch"].ToString();
            tpro = hash["product"].ToString();
            tcom = hash["component"].ToString();
        }
        catch (Exception ex)
        {
            Console.Write(ex.ToString());
        }
    }
}
