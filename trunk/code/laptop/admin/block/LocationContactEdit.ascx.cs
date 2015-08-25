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
public partial class admin_block_LocationContactEdit : System.Web.UI.UserControl
{
    public int id = 0;
    public ContacstSystem Contacts = new ContacstSystem();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            id = int.Parse(Request.QueryString["id"].ToString());
            if (!IsPostBack)
            {
                DataSet dsLocation = Contacts.LocationContactSelectIdName(id, "Location");
                if (dsLocation.Tables[0].Rows.Count > 0)
                {
                    txttitle.Value = dsLocation.Tables[0].Rows[0]["name"].ToString();
                }
                else
                {
                    Response.Redirect("AdminWebsite.aspx?menu=locationcontact");
                }
            }
        }
        catch
        {
            Response.Redirect("AdminWebsite.aspx?menu=locationcontact");
        }
    }
    protected void btedit_ServerClick(object sender, EventArgs e)
    {
        try
        {
            string title = txttitle.Value.Trim();
            if (title.Length > 0)
            {
                ContacstSystem Contacts = new ContacstSystem();
                DataSet ds = Contacts.LocationContactSelectIdName(id, title);
                if (ds.Tables[0].Rows.Count > 0)
                {

                }
                else
                {
                    Response.Redirect("AdminWebsite.aspx?menu=locationcontact");
                }
                if (ds.Tables[1].Rows.Count > 0 && !(id==int.Parse(ds.Tables[1].Rows[0]["id"].ToString())))
                {
                    diverror.Visible = true;
                    diverror.InnerHtml = "<div class='diverror'>Khu vực liên hệ đã tồn tại, hãy nhập khu vực khác.</div>";
                    return;
                }
                else
                {
                    if (Contacts.LocationContactupdate(id,title))
                    {
                        diverror.Visible = true;
                        diverror.InnerHtml = "<div class='diverror'>Khu vực liên hệ đã được chỉnh sửa.</div>";
                        txttitle.Value = "";
                        return;
                    }
                    else
                    {
                        diverror.Visible = true;
                        diverror.InnerHtml = "<div class='diverror'>Lỗi kết nối SQL. Không thể chỉnh sửa, xin hãy thử lại.</div>";
                        return;
                    }
                }
            }
            else
            {
                diverror.Visible = true;
                diverror.InnerHtml = "<div class='diverror'>Xin hãy nhập khu vực liên hệ.</div>";
                return;
            }
        }
        catch
        {
            diverror.Visible = true;
            diverror.InnerHtml = "<div class='diverror'>Lỗi kết nối SQL. Không thể chỉnh sửa, xin hãy thử lại.</div>";
            return;
        }
    }
}
