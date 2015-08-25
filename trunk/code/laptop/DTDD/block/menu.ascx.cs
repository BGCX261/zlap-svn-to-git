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

public partial class block_menu : System.Web.UI.UserControl
{
    public string flag = "";
    public string home = "";
    public string product = "";
    public string article = "";
    public string contact = "";
    public string download = "";
    public string help = "";
    public string tnewhave = "";
    public string twillhave = "";
    public string loriginal = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        flag=GetFlagLanguage();
        try
        {
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            home = hash["home"].ToString();
            product = hash["product"].ToString();
            article = hash["article"].ToString();
            contact = hash["contact"].ToString();
            download = hash["download"].ToString();
            help = hash["help"].ToString();
            tnewhave = hash["justh"].ToString();
            twillhave = hash["whave"].ToString();
            loriginal = hash["loriginal"].ToString();
        }
        catch (Exception ex)
        {
            Console.Write(ex.ToString());
        }
    }
    public string GetFlagLanguage()
    {
        string flag = "";
        try
        {
            if (Session["strlangsupport"] != null)
            {
                flag = Session["strlangsupport"].ToString();
            }
            else
            {
                ArrayList _list = (ArrayList)Application["langsupport"];
                int numLang = _list.Count;
                for (int i = 0; i < numLang; i++)
                {
                    string[] arrstr = (string[])_list[i];
                    if (Session["langcurrent"].ToString().Equals(arrstr[1]))
                    {
                        flag += "<img id='" + arrstr[1] + "' src='image/flag/" + arrstr[2] + "' class='img_flag2' title='" + arrstr[0] + "'/>";
                    }
                    else
                    {
                        flag += "<img id='" + arrstr[1] + "' src='image/flag/" + arrstr[2] + "' class='img_flag1' title='" + arrstr[0] + "' onclick='OnChangeLang(this);'/>";
                    }
                }
                Session["strlangsupport"] = flag;
            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.ToString());
        }
        return flag;
    }
}
