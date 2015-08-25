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
using System.IO;
public partial class admin_block_EditBottom : System.Web.UI.UserControl
{
    public string content = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                StreamReader myFile = new StreamReader(Server.MapPath("../data/file/footer.txt"));
                content = myFile.ReadToEnd();
                myFile.Close();
                diverror.Visible = false;
            }
        }
        catch { }

    }
    protected void btEdit_Click(object sender, EventArgs e)
    {
        try
        {
            content = Request.Form["txtContent"].ToString();
            StreamWriter writefile = new StreamWriter(Server.MapPath("../data/file/footer.txt"));
            writefile.Write(content);
            writefile.Close();
            Application["AppFooter"] = content;
            diverror.Visible = true;
            diverror.InnerHtml = "Chân trang đã được chỉnh sửa.";
        }
        catch
        {
            diverror.Visible = true;
            diverror.InnerHtml = "Quyền cập nhật file đã bị khóa. Không thể cập nhật.";
        }

    }
}
