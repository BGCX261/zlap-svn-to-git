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
public partial class admin_block_GroupContactAdd : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        diverror.Visible = false;
    }
    protected void btadd_ServerClick(object sender, EventArgs e)
    {
        try
        {
            string title = txttitle.Value.Trim();
            int sort = int.Parse(slsort.Value);
            if (title.Length > 0)
            {
                ContacstSystem Contacts = new ContacstSystem();
                DataSet ds = Contacts.GroupContactSelectIdName(0, title);
                if (ds.Tables[1].Rows.Count > 0)
                {
                    diverror.Visible = true;
                    diverror.InnerHtml = "<div class='diverror'>Tiêu đề nhóm liên hễ đã tồn tại. Hãy nhập nhóm khác</div>";
                    return;
                }
                else
                {
                    if (Contacts.GroupContactInsert(title, sort))
                    {
                        diverror.Visible = true;
                        diverror.InnerHtml = "<div class='diverror'>Nhóm liên hệ đã được tạo</div>";
                        txttitle.Value = "";
                        slsort.Items[0].Selected = true;
                        return;
                    }
                    else
                    {
                        diverror.Visible = true;
                        diverror.InnerHtml = "<div class='diverror'>Lỗi kết nối SQL. Không thể thêm mới. Xin hãy thử lại.</div>";
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
