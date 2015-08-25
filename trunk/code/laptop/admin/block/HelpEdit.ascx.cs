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
public partial class admin_block_HelpEdit : System.Web.UI.UserControl
{
    public string content = "";
    public HelpsSystem Helps = new HelpsSystem();
    int id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        diverror.Visible = false;
        try
        {
            id = int.Parse(Request.QueryString["id"].ToString());
            if (!IsPostBack)
            {
                DataSet dsHelsp = Helps.HelpsSelectIdName(id, "HelpsSelectIdName");
                if (dsHelsp.Tables[0].Rows.Count > 0)
                {
                    txttitle.Value = dsHelsp.Tables[0].Rows[0]["title"].ToString();
                    content = dsHelsp.Tables[0].Rows[0]["content"].ToString();
                    int index = int.Parse(dsHelsp.Tables[0].Rows[0]["sort"].ToString());
                    slsort.Items[index - 1].Selected = true;
                }
                else
                {
                    Response.Redirect("AdminWebsite.aspx?menu=help");
                }
            }
        }
        catch
        {
            Response.Redirect("AdminWebsite.aspx?menu=help");
        }
    }
    protected void btedit_ServerClick(object sender, EventArgs e)
    {
        try
        {
            string title = txttitle.Value.Trim();
            content = Request.Form["txtContent"].ToString();
            int sort = int.Parse(slsort.Value);
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
                DataSet dsHelp = Helps.HelpsSelectIdName(id, title);
                if (dsHelp.Tables[0].Rows.Count == 0)
                {
                    Response.Redirect("AdminWebsite.aspx?menu=help");
                }
                if (dsHelp.Tables[1].Rows.Count > 0 && !(id==int.Parse(dsHelp.Tables[1].Rows[0]["id"].ToString())))
                {
                    diverror.InnerHtml = "<div class='diverror'>Tiêu đề trợ giúp đã tồn tại, hãy nhập tiêu đề khác</div>";
                    diverror.Visible = true;
                    return;
                }
                else
                {
                    if (Helps.HelpsUpdate(id,title, content, sort))
                    {
                        diverror.InnerHtml = "<div class='diverror'>Trợ giúp đã được chỉnh sửa.</div>";
                        diverror.Visible = true;
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
