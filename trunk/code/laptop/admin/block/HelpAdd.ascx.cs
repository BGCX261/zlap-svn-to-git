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
public partial class admin_block_HelpAdd : System.Web.UI.UserControl
{
    public string content = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        diverror.Visible = false;
    }
    protected void btadd_ServerClick(object sender, EventArgs e)
    {
        try
        {
            string title = txttitle.Value.Trim();
            content = Request.Form["txtContent"].ToString();
            int sort =int.Parse(slsort.Value);
            if (title.Length == 0)
            {
                diverror.InnerHtml = "<div class='diverror'>Xin hãy nhập tiêu đề trợ giúp</div>";
                diverror.Visible = true;
                return;
            }
            else if (content.Length == 0)
            {
                diverror.InnerHtml = "<div class='diverror'>Xin hãy nhập nội dung trợ giúp</div>";
                diverror.Visible = true;
                return;
            }
            else
            {
                HelpsSystem Helps = new HelpsSystem();
                DataSet dsHelp = Helps.HelpsSelectIdName(0, title);
                if (dsHelp.Tables[1].Rows.Count > 0)
                {
                    diverror.InnerHtml = "<div class='diverror'>Tiêu đề trợ giúp đã tồn tại, hãy nhập tiêu đề khác</div>";
                    diverror.Visible = true;
                    return;
                }
                else
                {
                    if (Helps.HelpsInsert(title, content, sort))
                    {
                        diverror.InnerHtml = "<div class='diverror'>Trợ giúp đã được thêm mới</div>";
                        diverror.Visible = true;
                        txttitle.Value = "";
                        content = "";
                        slsort.Items[0].Selected=true;
                        return;
                    }
                    else
                    {
                        diverror.InnerHtml = "<div class='diverror'>Lỗi kết nối SQL. Không thể thêm mới</div>";
                        diverror.Visible = true;
                        return;
                    }
                }
            }
        }
        catch
        {
            diverror.InnerHtml = "<div class='diverror'>Lỗi kết nối SQL. Không thể thêm mới</div>";
            diverror.Visible = true;
            return;
        }
    }
}
