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

public partial class block_userlogin : System.Web.UI.UserControl
{
    public string blUser = "Xin mời bạn đăng nhập";
    public string tforgotpass = "Bạn quyên mật khẩu ?";
    public string tnewmember = "Bạn là khách hàng mới ?";
    public string tbutton = "Đăng nhập";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            blUser = hash["bllogin"].ToString();
            tbutton = hash["blogin"].ToString();
            tforgotpass = hash["mforgetp"].ToString();
            tnewmember = hash["mnewaccount"].ToString();
        }
        catch
        { 
        
        }
    }
}
