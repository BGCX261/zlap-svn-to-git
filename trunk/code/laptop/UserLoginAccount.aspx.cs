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
using framework.list.common;
using facade.list;
public partial class UserLoginAccount : System.Web.UI.Page
{
    public string isOk = "Tài khoản đăng nhập không tồn tại (Not found account)";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string user=Request.QueryString["user"].ToString();
            string pass = Request.QueryString["pass"].ToString();
            MD5 EncodeMDS = new MD5();
            DataSet ds = new DataSet();
            UserManagerSystem UserManage = new UserManagerSystem();
            ds=UserManage.GetUserAccount(user);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string PassUser = ds.Tables[0].Rows[0]["password"].ToString();
                    if (EncodeMDS.Verify(pass, PassUser))
                    {
                        isOk = "ok";
                        string[] userAcount = new string[3];
                        userAcount[0] = ds.Tables[0].Rows[0]["id"].ToString();
                        userAcount[1] = ds.Tables[0].Rows[0]["UserName"].ToString();
                        userAcount[2] = ds.Tables[0].Rows[0]["ContactName"].ToString();
                        Session["infoUser"] = userAcount;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.ToString());
        }
        Response.Write(isOk);
    }
}
