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
public partial class block_Header : System.Web.UI.UserControl
{
    public string nameUser = "";
    public string strtime = "";
    public string strIP = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //string[] arrInfor = new string[] { "", "" };
            //strIP = Request.ServerVariables["REMOTE_ADDR"];
            //if (Session["UserLogin"] != null)
            //{
            //    arrInfor = (string[])Session["UserLogin"];
            //    nameUser = arrInfor[1];
            //    DateTime time = CTime.GetTimeHaNoi();
            //    strtime = time.ToString("hh:mm dd/MM/yyyy");
            //}
            //else
            //{
            //    Response.Redirect("LoginWebsite.aspx");
            //}
        }
        catch
        { 
        }
    }
}