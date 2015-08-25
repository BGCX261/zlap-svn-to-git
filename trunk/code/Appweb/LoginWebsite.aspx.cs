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
public partial class LoginWebsite : System.Web.UI.Page
{
    public string strIP = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Session["UserLogin"] = null;
                txtPass.Value = "";
                txtUser.Value = "";
            }
            strIP = Request.ServerVariables["REMOTE_ADDR"];
            divErrors.Visible = false;
        }
        catch
        { }
    }
    protected void btLogin_Click(object sender, EventArgs e)
    {
        //Boolean isOk = false;
        //try
        //{
        //    string userName = "";
        //    string passWord = "";
        //    userName = txtUser.Value.Trim();
        //    passWord = txtPass.Value.Trim();
        //    MD5 EncodeMDS = new MD5();
        //    if (userName.Length > 0 && passWord.Length>0)
        //    {
        //        DataSet ds = new CManageUserSystem().SelectUserLogin(userName);
        //        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //        {
        //            string Pass = ds.Tables[0].Rows[0]["PassWord"].ToString();
        //            if (!EncodeMDS.Verify(passWord, Pass))
        //            {
        //                //Test địa chi IP của bạn:
        //                string strIP = Request.ServerVariables["REMOTE_ADDR"];
        //                //Test xem Ip được phép không?:
        //                string[] arrInfor = new string[] { "", "", "" };
        //                arrInfor[0] = ds.Tables[0].Rows[0]["Id"].ToString();
        //                arrInfor[1] = ds.Tables[0].Rows[0]["Name"].ToString();
        //                arrInfor[2] = ds.Tables[0].Rows[0]["UserName"].ToString();
        //                //int count = new CManageIPsystem().IpUserLoginTest(arrInfor[0], strIP);
        //                int count = 1;
        //                if (count > 0)
        //                {
        //                    Session["UserLogin"] = arrInfor;
        //                    isOk = true;
        //                    //Insert login:
        //                    DateTime timeNow = CTime.GetTimeHaNoi();
        //                    DateTime timeOld = new DateTime();
        //                    timeOld = timeNow.AddMonths(-3);
        //                    new CManageIPsystem().UserLoginInsert(int.Parse(arrInfor[0]), arrInfor[1], arrInfor[2], strIP, timeNow,timeOld);
        //                }
        //                else
        //                {
        //                    Session["UserLogin"] = null;
        //                    divErrors.Visible = true;
        //                    divErrors.InnerHtml = "Bạn không được đăng nhập với IP này";
        //                    txtUser.Focus();
        //                    isOk = false;
        //                }
        //            }
        //            else
        //            {
        //                divErrors.Visible = true;
        //                divErrors.InnerHtml = "* Mật khẩu không chính xác";
        //                txtUser.Focus();
        //            }
        //        }
        //        else
        //        {
        //            divErrors.Visible = true;
        //            divErrors.InnerHtml = "* Tên đăng nhập không tồn tại";
        //            txtUser.Focus();
        //        }
        //    }
        //    else
        //    {
        //        divErrors.Visible = true;
        //        divErrors.InnerHtml = "* Xin hãy điền thông tin đăng nhập";
        //        txtUser.Focus();
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Console.Write(ex.ToString());
        //}
        //if (isOk)
        //{
        //    Response.Redirect("Default.aspx");
        //}
    }
}