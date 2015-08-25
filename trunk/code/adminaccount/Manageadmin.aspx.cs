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

public partial class Manageadmin : System.Web.UI.Page
{
    public string strInformation = "";
    public string username = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserLogin"] == null)
        {
            Response.Redirect("Mainpage.aspx");
        }
        else
        {
            DataTable tableUser = (DataTable)Session["UserLogin"];
            username = "Xin chao : " + tableUser.Rows[0]["username"].ToString();
            //Hien thi danh sach username theo level
            int level = int.Parse(tableUser.Rows[0]["userlevel"].ToString());
            DataSet listAdmin = new DataSet();
            if (level == 0)
            {
                listAdmin = new CmanagerAdmin().AdminSelectLevel(1,"");
                strInformation = "Danh sach nguoi dung cac tinh";
            }
            else if (level == 1)
            {
                listAdmin = new CmanagerAdmin().AdminSelectLevel(2,tableUser.Rows[0]["idtinh"].ToString());
                strInformation = "Danh sach nguoi dung cua huyen";
            }
            else
            {
                Response.Redirect("manageinformaitonaccount.aspx");
            }
            int numadmin = listAdmin.Tables[0].Rows.Count;
            if (numadmin > 0)
            {
                strInformation += "<br /><table border='1'>";
                for (int i = 0; i < numadmin; i++)
                {
                    strInformation += "<tr><td>" + listAdmin.Tables[0].Rows[i]["username"].ToString() + "</td>";
                    if (level == 0)
                    {
                        strInformation += "<td>" + listAdmin.Tables[0].Rows[i]["idtinh"].ToString() + "</td></tr>";
                    }
                    if (level == 1)
                    {
                        strInformation += "<td>" + listAdmin.Tables[0].Rows[i]["idhuyen"].ToString() + "</td></tr>";
                    }
                    strInformation += "</tr>";
                }
                strInformation += "</table>";
            }
        }
    }
}
