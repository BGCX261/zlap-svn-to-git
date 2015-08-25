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
public partial class admin_block_GroupContactEdit : System.Web.UI.UserControl
{
    public int id = 0;
    ContacstSystem Contacts = new ContacstSystem();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            id = int.Parse(Request.QueryString["id"].ToString());
            if (!IsPostBack)
            {
                DataSet dsGroup = Contacts.GroupContactSelectIdName(id, "group");
                if (dsGroup.Tables[0].Rows.Count > 0)
                {
                    txttitle.Value = dsGroup.Tables[0].Rows[0]["name"].ToString();
                    int indexselect = int.Parse(dsGroup.Tables[0].Rows[0]["sort"].ToString());
                    slsort.Items[indexselect - 1].Selected = true;
                }
                else
                {
                    Response.Redirect("AdminWebsite.aspx?menu=groupcontact");
                }
            }
        }
        catch
        {
            Response.Redirect("AdminWebsite.aspx?menu=groupcontact");
        }
    }
    protected void btedit_ServerClick(object sender, EventArgs e)
    {
        try
        {
            string title = txttitle.Value.Trim();
            int sort = int.Parse(slsort.Value);
            if (title.Length > 0)
            {
                ContacstSystem Contacts = new ContacstSystem();
                DataSet ds = Contacts.GroupContactSelectIdName(id, title);
                if (ds.Tables[0].Rows.Count > 0)
                {

                }
                else
                {
                    Response.Redirect("AdminWebsite.aspx?menu=groupcontact");
                }
                if (ds.Tables[1].Rows.Count > 0 && !(id==int.Parse(ds.Tables[1].Rows[0]["id"].ToString())))
                {
                    diverror.Visible = true;
                    diverror.InnerHtml = "<div class='diverror'>Tiêu đề nhóm liên hễ đã tồn tại. Hãy nhập nhóm khác</div>";
                    return;
                }
                else
                {
                    if (Contacts.GroupContactUpdate(id,title, sort))
                    {
                        diverror.Visible = true;
                        diverror.InnerHtml = "<div class='diverror'>Nhóm liên hệ đã được chỉnh sửa</div>";
                        //txttitle.Value = "";
                        //slsort.Items[0].Selected = true;
                        return;
                    }
                    else
                    {
                        diverror.Visible = true;
                        diverror.InnerHtml = "<div class='diverror'>Xin bạn hãy nhập tiêu đề nhóm liên hệ</div>";
                        return;
                    }
                }
            }
            else
            {
                diverror.Visible = true;
                diverror.InnerHtml = "<div class='diverror'>Xin bạn hãy nhập tiêu đề nhóm liên hệ</div>";
                return;
            }
        }
        catch
        {
            diverror.Visible = true;
            diverror.InnerHtml = "<div class='diverror'>Lỗi kết nối SQL. Không thể thêm mới.</div>";
            return;
        }
    }
}
