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
            Application["appOnline"] = null;
            if (Application["appOnline"] == null)
            {
                DataSet dsOnline = new SupportOnlineSystem().OnlineSelectAll("1");
                int numOnline = dsOnline.Tables[0].Rows.Count;
                if (numOnline > 0)
                {
                    strOnline = "<table border='0' cellpadding='0' cellspacing='0' width='100%'>";
                    string idgroup1 = dsOnline.Tables[0].Rows[0]["idgroup"].ToString();
                    strOnline += "<tr><td class='blol' title='Xin mời quý khách Click vào đây.' onclick='OnMOverDOnline(" + idgroup1 + ");'>" + dsOnline.Tables[0].Rows[0]["namegroup"].ToString() + "</td></tr>";
                    strOnline += "<tr><td align='left'>";
                    strOnline += "<div class='donline' id='donline" + idgroup1 + "' style='display:none;'>";
                    for (int i = 0; i < numOnline; i++)
                    {
                        if (idgroup1 != dsOnline.Tables[0].Rows[i]["idgroup"].ToString())
                        {
                            strOnline += "</div></td></tr>";
                            idgroup1 = dsOnline.Tables[0].Rows[i]["idgroup"].ToString();
                            strOnline += "<tr><td class='blol' title='Xin mời quý khách Click vào đây.' onclick='OnMOverDOnline(" + idgroup1 + ");'>" + dsOnline.Tables[0].Rows[i]["namegroup"].ToString() + "</td></tr>";
                            strOnline += "<tr><td align='left'>";
                            strOnline += "<div class='donline' id='donline" + idgroup1 + "' style='display:none;'>";
                        }
                        string name = dsOnline.Tables[0].Rows[i]["name"].ToString();
                        strOnline += "<a href ='ymsgr:sendim?" + dsOnline.Tables[0].Rows[i]["nickname"].ToString() + "'><img src='http://opi.yahoo.com/online?u=" + dsOnline.Tables[0].Rows[i]["nickname"].ToString() + "' border='0' style='vertical-align:middle;'/> " + name + "</a>";
                        if (i < numOnline - 1 && idgroup1 == dsOnline.Tables[0].Rows[i + 1]["idgroup"].ToString())
                        {
                            strOnline += "<div class='bg_line2' style='height:5px;'></div>";
                        }
                        else if (i == numOnline - 1)
                        {
                            strOnline += "</div></td></tr>";
                        }
                    }
                    strOnline += "</table>";
                    //Application["appOnline"] = strOnline;
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
