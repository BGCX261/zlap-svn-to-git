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
using framework.list.dynamicviewhelper;
//For test Manager User:
public partial class ManagerUser : System.Web.UI.Page
{
    public string tableUser = "";
    public string strTime = "";
    public string strChangePage = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime time = new DateTime();
        time = DateTime.Now;
        long ticks = time.Ticks;
        int size = 20;
        CDynamicViewUser UserView;
        int currentpage = 0;
        try
        {
            size = int.Parse(Request.QueryString["size"].ToString());
            currentpage = int.Parse(Request.QueryString["page"].ToString());
        }
        catch { }
        if (Session["ssUser"] == null)
        {
            UserView = new CDynamicViewUser();
            UserView.SetPageSize(size);
            UserView.SetNumberRecord(731703);
            if (currentpage > 0)
            {
                UserView.SetCurrentPage(currentpage);
            }
            else
            {
                UserView.SetCurrentPage();
            }
            Session["ssUser"] = UserView;
        }
        else
        {
            UserView = (CDynamicViewUser)Session["ssUser"];
            UserView.SetPageSize(size);
            UserView.SetCurrentPage(currentpage);
        }
        DataSet ds=new DataSet();
        int index=1;
        int num=0;
        if (index == 1)
        {
            ds = UserView.UserWithRowCountFromTo();
            //DataSet dsId = UserView.TestUserIdGetFromTo();
            //num = dsId.Tables[0].Rows.Count;
            //string idgroup = "";
            //for (int i = 0; i < num; i++)
            //{
            //    idgroup += dsId.Tables[0].Rows[i]["id"].ToString() + ",";
            //}
            //idgroup = idgroup.Substring(0, idgroup.Length - 1);
            //ds = UserView.TestUserGetGroup(idgroup);
        }
        else if(index==2)
        {
            //Get Top From to
            ds = UserView.GetUserTopFromTo();
        }
        else if (index == 3)
        {
            ds = UserView.GetUserFromTo();
        }
        num = ds.Tables[0].Rows.Count;
        tableUser = "<table border=1>";
        tableUser += "<tr>";
        tableUser += "<td width='50'>STT</td>";
        tableUser += "<td width='80'>Mã khách hàng</td>";
        tableUser += "<td width='100'>Tên đăng nhập</td>";
        tableUser += "<td width='200'>Mật khẩu đăng nhập</td>";
        tableUser += "<td width='150'>Họ và tên</td>";
        tableUser += "<td width='150'>Công ty</td>";
        tableUser += "<td width='150'>Nghề nghiệp</td>";
        tableUser += "<td width='150'>Thành phố nơi nhận hàng</td>";
        tableUser += "<td width='150'>Địa chỉ chính xác</td>";
        tableUser += "</tr>";
        for (int i = 0; i < num; i++)
        {
            int indexid = i + 1;
            tableUser += "<tr>";
            tableUser += "<td width='50'>" + indexid + "</td>";
            tableUser += "<td width='80'>" + ds.Tables[0].Rows[i]["Id"].ToString() + "</td>";
            tableUser += "<td width='100'>" + ds.Tables[0].Rows[i]["UserName"].ToString() + "</td>";
            tableUser += "<td width='200'>" + ds.Tables[0].Rows[i]["Password"].ToString() + "</td>";
            tableUser += "<td width='150'>" + ds.Tables[0].Rows[i]["ContactName"].ToString() + "</td>";
            tableUser += "<td width='150'>" + ds.Tables[0].Rows[i]["Company"].ToString() + "</td>";
            tableUser += "<td width='150'>" + ds.Tables[0].Rows[i]["JobTitle"].ToString() + "</td>";
            tableUser += "<td width='150'>" + ds.Tables[0].Rows[i]["BillingAddress"].ToString() + "</td>";
            tableUser += "<td width='150'>" + ds.Tables[0].Rows[i]["ShippingAddress"].ToString() + "</td>";
            tableUser += "</tr>";
        }
        tableUser += "</table>";
        strChangePage = "<table border=1 style='cursor:pointer;'>";
        strChangePage += "<tr>";
        strChangePage += "<td>";
        strChangePage += "<div onclick='Change(1," + UserView.GetCurrentPage() + ");'>";
        strChangePage += "Trang truoc";
        strChangePage += "</div>";
        strChangePage += "</td>";
        strChangePage += "<td>";
        strChangePage += "<div onclick='Change(2," + UserView.GetCurrentPage() + ");'>";
        strChangePage += "Trang sau";
        strChangePage += "</div>";
        strChangePage += "</td>";
        strChangePage += "</tr>";
        strChangePage += "</table>";
        time = DateTime.Now;
        ticks = time.Ticks - ticks;
        double second = ticks / 10000000.0;
        strTime = second.ToString();
    }
}
