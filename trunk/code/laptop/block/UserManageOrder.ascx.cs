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
public partial class block_UserManageOrder : System.Web.UI.UserControl
{
    public string tbl_listorder = "Danh sách đơn đặt hàng";
    public string tcodeorder = "Mã đơn";
    public string tshipdate = "Ngày nhân";
    public string tshippingname = "Người nhân";
    public string tshippingaddress = "Địa chỉ";
    public string tstate = "Trạng thái";
    public string strorder = "";
    public string tmnothoveorder = "Chưa có đơn đặt hàng nào";
    public string tpage = "";
    public string currentAccess = "";
    string thome = "";
    string tblorder = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //ViewListOrder:
        try
        {
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            currentAccess = hash["currentpage"].ToString();
            thome = hash["home"].ToString();
            tblorder = hash["forder"].ToString();
            currentAccess += ": <a href='?menu=home'>" + thome + "</a> &raquo; " + tblorder;
            if (Session["infoUser"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            ViewListOrder();
        }   
        catch (Exception ex)
        {

        }
    }
    public void ViewListOrder()
    {
        int page = 1;
        try
        {
            page = int.Parse(Request.QueryString["page"].ToString());
        }
        catch
        { 
        
        }
        CDynamicViewListOrder ViewListOrder = new CDynamicViewListOrder();
        if (Session["ssListOrder"] == null)
        {
            string[] arrAccount = (string[])Session["infoUser"];
            ViewListOrder.SetIduser(arrAccount[0]);
            ViewListOrder.SetPageSize(20);
            ViewListOrder.SetListOrderAllTop();
            ViewListOrder.SetCurrentPage(page);
        }
        else
        {
            ViewListOrder = (CDynamicViewListOrder)Session["ssListOrder"];
            ViewListOrder.SetCurrentPage(page);
        }
        buildPage(ViewListOrder.GetCurrentPage(), ViewListOrder.GetPages());
        strorder = ViewListOrder.GetOrderFromTo();
    }
    public void buildPage(int currentpage, int pages)
    {
        if (pages >= 2)
        {
            tpage = "<table border='0' cellpadding='0' cellspacing='0' width='100%' class='bg_page'>";
            tpage += "<tr><td width='70'>Trang/Page</td>";
            tpage += "<td align='left' class='text_page'>";
            for (int i = 1; i <= pages; i++)
            {
                if (i == currentpage)
                {
                    tpage += "<u>"+ i +"</u> ";
                }
                else
                {
                    tpage += "<a href='?menu=manageorder&page="+ i +"'>" + i + "</a> ";
                }
            }
            tpage += "</td></tr></table>";
        }
    }
}
