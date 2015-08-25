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
public partial class block_Helps : System.Web.UI.UserControl
{
    public string tblHelps = "Mục trợ giúp";
    public string listHelps = "";
    public string tableHelps = "";
    public HelpsSystem helps = new HelpsSystem();
    public string currentAccess = "";
    string thome = "";
    string help = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            currentAccess = hash["currentpage"].ToString();
            thome = hash["home"].ToString();
            help = hash["help"].ToString();
            currentAccess += ": <a href='?menu=home'>" + thome + "</a> &raquo; " + help;
            DataSet ds = helps.HelpsSelectAll();
            if (ds.Tables.Count > 0)
            {
                int numHelps = ds.Tables[0].Rows.Count;
                tableHelps = "<table border='0' cellpadding='0' cellspacing='0' width='100%' align='left'>";
                tableHelps += "<tr><td height='5'></td></tr>";
                for (int i = 1; i <= numHelps; i++)
                {
                    listHelps += "<span  class='agroup'><a href='#td" + ds.Tables[0].Rows[i - 1]["id"].ToString() + "'>" + i + ". " + ds.Tables[0].Rows[i - 1]["title"].ToString() + "</a></span><br />";
                    tableHelps += "<tr style='background-color:#EEEEEE'><td class='text_title' align='center' id='td" + ds.Tables[0].Rows[i - 1]["id"].ToString() + "'>" + ds.Tables[0].Rows[i - 1]["title"].ToString() + "</td></tr>";
                    tableHelps += "<tr><td valign='top' class='text_5'>" + ds.Tables[0].Rows[i - 1]["content"].ToString() + "</td></tr>";
                    tableHelps += "<tr><td height='5'></td></tr><tr><td align='right'><a href='#'>Đầu trang</a></td></tr>";
                }
                tableHelps += "</table>";
            }
        }
        catch
        {
        }
    }
}
