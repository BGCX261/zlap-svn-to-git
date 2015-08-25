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

public partial class block_FuncUser : System.Web.UI.UserControl
{
    public string thello = "";
    public string name = "";
    public string functions = "";
    public string tminformation = "";
    public string tmorder = "";
    public string tsendcontact = "";
    public string tfeedback = "";
    public string tlogout = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            functions = hash["mfunction"].ToString();
            thello = hash["bluser"].ToString();
            tminformation = hash["facount"].ToString();
            tmorder = hash["forder"].ToString();
            tsendcontact = hash["fsendmail"].ToString();
            tfeedback = hash["ffeedback"].ToString();
            tlogout = hash["bout"].ToString();
        }
        catch
        { 
        
        }
        try
        {
            string[] arrAccount = (string[])Session["infoUser"];
            name = arrAccount[2];
        }
        catch { }
    }
}
