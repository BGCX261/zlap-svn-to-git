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
public partial class block_BuildMenuUser : System.Web.UI.UserControl
{
    public string ListRoleUser = "";
    public string titleBlock = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ListRoleUser = "<a href='Default.aspx?key=RptProductPrice'>báo giá</a>";
            //string[] arrInfor = new string[] { "", "" };
            //if (Session["UserLogin"] != null)
            //{
            //    arrInfor = (string[])Session["UserLogin"];
            //    DataSet dsRoleOfUser = new DataSet();
            //    dsRoleOfUser = new CManageRoleOfUserSystem().SelectAllRoleOfUser(arrInfor[0]);
            //    if (dsRoleOfUser.Tables[0].Rows.Count > 0)
            //    {
            //        int numRows = dsRoleOfUser.Tables[0].Rows.Count;
            //        string idrole = "";
            //        for (int i = 0; i < numRows; i++)
            //        {
            //            idrole = dsRoleOfUser.Tables[0].Rows[i]["idrole"].ToString();
            //            ListRoleUser += "<a href='#' onmouseover='OnMOMenu(" + idrole + "," + i + ",event);' onmouseout='TimeHidden();'>" + (i + 1) + ". " + dsRoleOfUser.Tables[0].Rows[i]["name"] + "</a>";
            //            if (i + 1 < numRows)
            //            {
            //                ListRoleUser += "<div class='line3'></div>";
            //            }
            //        }
            //        titleBlock = "Những vai trò dành cho bạn:";
            //    }
            //    else
            //    {
            //        ListRoleUser = "";
            //        titleBlock = "Bạn không có vai trò nào";
            //    }
            //}
            //else
            //{
            //    Response.Redirect("LoginWebsite.aspx");
            //}
        }
        catch
        {
            ListRoleUser = "";
            titleBlock = "Bạn không có vai trò nào";
        }
    }
}
