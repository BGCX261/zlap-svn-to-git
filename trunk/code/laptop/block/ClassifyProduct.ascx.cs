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

using dataaccess.list;

public partial class block_ClassifyProduct : System.Web.UI.UserControl
{
    public string bl_pro = "Phân loại MayTinhXachTay";
    public string strphanphoi = "Hàng phân phối của hãng";
    public string strnhapkhau = "Hàng nhập khẩu";
    public string strall = "Xem tất cả";
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
