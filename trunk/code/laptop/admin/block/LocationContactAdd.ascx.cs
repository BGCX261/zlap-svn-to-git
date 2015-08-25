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
public partial class admin_block_LocationContactAdd : System.Web.UI.UserControl
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
            if (title.Length > 0)
            {
                ContacstSystem Contacts = new ContacstSystem();
                DataSet ds = Contacts.LocationContactSelectIdName(0, title);
                if (ds.Tables[1].Rows.Count > 0)
                {
                    diverror.Visible = true;
                    diverror.InnerHtml = "<div class='diverror'>Khu vực liên hệ đã tồn tại, hãy nhập khu vực khác</div>";
                    return;
                }
                else
                {
                    if (Contacts.LocationContactInsert(title))
                    {
                        diverror.Visible = true;
                        diverror.InnerHtml = "<div class='diverror'>Khu vực liên hệ đã được tạo</div>";
                        txttitle.Value = "";
                        return;
                    }
                    else
                    {
                        diverror.Visible = true;
                        diverror.InnerHtml = "<div class='diverror'>Lỗi kết nối SQL. Không thể thêm mới, xin hãy thử lại</div>";
                        return;
                    }
                }
            }
            else
            {
                diverror.Visible = true;
                diverror.InnerHtml = "<div class='diverror'>Xin hãy nhập khu vực liên hệ</div>";
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
