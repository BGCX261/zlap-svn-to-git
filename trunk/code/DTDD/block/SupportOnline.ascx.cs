using System;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using facade.list;
public partial class block_SupportOnline : System.Web.UI.UserControl
{
    public string online = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        online = SupportOnline();
    }
    public string SupportOnline()
    {
        string strOnline = "";
        try
        {
            if (Application["appOnline"] == null)
            {
                DataSet dsOnline = new SupportOnlineSystem().OnlineSelectAll();
                int numOnline = dsOnline.Tables[0].Rows.Count;
                if (numOnline > 0)
                {
                    strOnline = "<table border='0' cellpadding='0' cellspacing='0' width='100%'>";
                    string idgroup1 = dsOnline.Tables[0].Rows[0]["idgroup"].ToString();
                    strOnline += "<tr><td class='text_b2'>" + dsOnline.Tables[0].Rows[0]["namegroup"].ToString() + "</td></tr>";
                    for (int i = 0; i < numOnline; i++)
                    {
                        if (idgroup1 != dsOnline.Tables[0].Rows[i]["idgroup"].ToString())
                        {
                            strOnline += "<tr><td class='text_b2'>" + dsOnline.Tables[0].Rows[i]["namegroup"].ToString() + "</td></tr>";
                            idgroup1 = dsOnline.Tables[0].Rows[i]["idgroup"].ToString();
                        }
                        string name = dsOnline.Tables[0].Rows[i]["name"].ToString();
                        if (dsOnline.Tables[0].Rows[i]["title"].ToString().Length > 0)
                        {
                            name = "<br /><span class='text_5'>" + dsOnline.Tables[0].Rows[i]["title"].ToString() + ":</span> " + name;
                        }
                        strOnline += "<tr height='26'><td class='text_title' align='left'>";
                        strOnline += "&nbsp;&nbsp;<a href ='ymsgr:sendim?" + dsOnline.Tables[0].Rows[i]["nickname"].ToString() + "'><img src='http://opi.yahoo.com/online?u=" + dsOnline.Tables[0].Rows[i]["nickname"].ToString() + "&m=g&t=1' border='0' style='vertical-align:middle'/></a> " + name + "</td></tr>";
                        if (i < numOnline - 1 && idgroup1 == dsOnline.Tables[0].Rows[i + 1]["idgroup"].ToString())
                        {
                            strOnline += "<tr><td class='bg_line2'></td></tr>";
                        }
                        else if (i == numOnline - 1)
                        {
                            strOnline += "<tr><td height='2'></td></tr>";
                        }
                    }
                    strOnline += "</table>";
                    Application["appOnline"] = strOnline;
                }
            }
            else
            {
                strOnline = Application["appOnline"].ToString();
            }
        }
        catch
        { }
        return strOnline;
    }
}
