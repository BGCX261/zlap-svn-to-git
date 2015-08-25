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

public partial class admin_block_SupportOnlineAdd : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        diverror.Visible = false;
    }
    protected void btadd_ServerClick(object sender, EventArgs e)
    {
        try
        {
            int idgroup = int.Parse(slgroup.Value);
            string group = txtgroup.Value.Trim();
            string name = txtname.Value.Trim();
            string nickname = txtnickname.Value.Trim();
            string title = txttitle.Value.Trim();
            int sort = int.Parse(slsort.Value);
            int type = int.Parse(SlType.Text.ToString());
            if (group.Length == 0)
            {
                diverror.Visible = true;
                diverror.InnerHtml = "<div class='diverror'>Xin hãy nhập nhóm hỗ trợ</div>";
                return;
            }
            else if (name.Length == 0)
            {
                diverror.Visible = true;
                diverror.InnerHtml = "<div class='diverror'>Xin hãy nhập tên nhân viên</div>";
                return;
            }
            else if (nickname.Length == 0)
            {
                diverror.Visible = true;
                diverror.InnerHtml = "<div class='diverror'>Xin hãy nhập Nick Name</div>";
                return;
            }
            SupportOnlineSystem SupportOnline = new SupportOnlineSystem();
            if (SupportOnline.OnlineInsert(name, nickname, title, idgroup, group, sort, type))
            {
                diverror.Visible = true;
                diverror.InnerHtml = "<div class='diverror'>Hỗ trợ trực tuyến đã được thêm mới</div>";
                ResetAppOnline();
                txtname.Value = "";
                txtnickname.Value = "";
                txttitle.Value = "";
                return;
            }
            else
            {
                diverror.Visible = true;
                diverror.InnerHtml = "<div class='diverror'>Lỗi kết nối SQL, không thể thêm mới</div>";
                return;
            }
        }
        catch
        {
            diverror.Visible = true;
            diverror.InnerHtml = "<div class='diverror'>Lỗi kết nối SQL, không thể thêm mới</div>";
            return;
        }
    }
    public void ResetAppOnline()
    {
        try
        {
            Application["appOnline"] = null;
            Application["appOnlineMobi"] = null;
        }
        catch
        { }
    }
}