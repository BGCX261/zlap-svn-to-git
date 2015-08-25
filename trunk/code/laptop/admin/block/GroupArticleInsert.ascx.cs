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
public partial class admin_block_GroupArticleInsert : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            diverror.Visible = false;
        }
        catch
        { 
        
        }
    }
    protected void btadd_ServerClick(object sender, EventArgs e)
    {
        try
        {
            string name = txttitle.Value.Trim();
            string  ishow = "0";
            if(checkshow.Checked)
            {
                ishow="1";
            }
            ArticleManagerSystem Articles = new ArticleManagerSystem();
            if (name.Length > 0)
            {
                DataSet testexsit = Articles.AdminGroupSelectId(0, name);
                if (testexsit.Tables.Count > 0)
                {
                    if (testexsit.Tables[1].Rows.Count > 0)
                    {
                        diverror.Visible = true;
                        diverror.InnerHtml = "<div class='diverror'>Tiêu đề nhóm tin đã tồn tại, hãy nhập tin khác</div>";
                        return;
                    }
                    else
                    {
                        if (Articles.AdminGroupInsert(name, ishow))
                        {
                            diverror.Visible = true;
                            diverror.InnerHtml = "<div class='diverror'>Nhóm tin đã được thêm mới.</div>";
                            return;
                        }
                        else
                        {
                            diverror.Visible = true;
                            diverror.InnerHtml = "<div class='diverror'>Lỗi kết nối SQL SERVER. Không thể thêm mới.</div>";
                            return;
                        }
                    }
                }
                else
                {
                    diverror.Visible = true;
                    diverror.InnerHtml = "<div class='diverror'>Lỗi kết nối SQL SERVER. Không thể thêm mới.</div>";
                    return;
                }
            }
            else
            {
                diverror.Visible = true;
                diverror.InnerHtml = "<div class='diverror'>Xin hãy nhập tiêu đề nhóm tin tức</div>";
                return;
            }   
        }
        catch
        {
            diverror.Visible = true;
            diverror.InnerHtml = "<div class='diverror'>Lỗi kết nối SQL SERVER. Không thể thêm mới.</div>";
            return;
        }
    }
}
