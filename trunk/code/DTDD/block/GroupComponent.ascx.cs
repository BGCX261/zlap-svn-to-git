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
using facade.list;
public partial class block_GroupComponent : System.Web.UI.UserControl
{
    public string tblComponent = "";
    public string strGroupcom = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            tblComponent = hash["component"].ToString();
        }
        catch
        { 
            
        }
        if (Application["appgroupcom"] != null)
        {
            strGroupcom = Application["appgroupcom"].ToString();
        }
        else
        {
            try
            {
                DataSet dscom = new ComponentProductSystem().ComponentGroup((int)Application["idtypeproduct"]);
                int num = dscom.Tables[0].Rows.Count;
                for (int i = 0; i < num; i++)
                {
                    strGroupcom += "<a href='?menu=igc&id=" + dscom.Tables[0].Rows[i]["Id"].ToString() + "'>" + dscom.Tables[0].Rows[i]["Name"].ToString() + "</a><br />";
                }
                Application["appgroupcom"] = strGroupcom;
            }
            catch
            { }
        }
    }
}
