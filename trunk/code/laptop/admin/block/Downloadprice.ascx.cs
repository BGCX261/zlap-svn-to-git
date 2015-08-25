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

public partial class admin_block_Downloadprice : System.Web.UI.UserControl
{
    public string content = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                StreamReader myFile = new StreamReader(Server.MapPath("../data/file/Downloadprice.txt"));
                content = myFile.ReadToEnd();
                myFile.Close();
                if (content.Equals("1"))
                {
                    slvalue.SelectedIndex = 1;
                }
                else
                {
                    slvalue.SelectedIndex = 0;
                }
                diverror.Visible = false;
            }
        }
        catch { }

    }
    protected void btEdit_Click(object sender, EventArgs e)
    {
        try
        {
            content = slvalue.Text;
            StreamWriter writefile = new StreamWriter(Server.MapPath("../data/file/Downloadprice.txt"));
            writefile.Write(content);
            writefile.Close();
            Application["AppDownloadPrice"] = content;
            diverror.Visible = true;
            diverror.InnerHtml = "Đã cập nhật thành công";
        }
        catch
        {
            diverror.Visible = true;
            diverror.InnerHtml = "Quyền cập nhật file đã bị khóa. Không thể cập nhật.";
        }

    }
}
