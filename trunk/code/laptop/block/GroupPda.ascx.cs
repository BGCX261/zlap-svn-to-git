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
using common.list;
using facade.list;
public partial class block_GroupPda : System.Web.UI.UserControl
{
    public string tblpocketpc = "";
    public string listbrand = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if(Application["apppda"]==null)
            {
                Application["apppda"]=1;
            }
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            tblpocketpc=hash["pocketpc"].ToString();
            DataSet dsBrand = new BrandProductSystem().BrandProAllType(int.Parse(Application["apppda"].ToString()));
            int num = dsBrand.Tables[0].Rows.Count;
            for (int i = 0; i < num; i++)
            {
                listbrand += dsBrand.Tables[0].Rows[i][BrandProduct_data._name].ToString() + "<br />";
            }
        }
        catch
        {
            
        }
    }
}
