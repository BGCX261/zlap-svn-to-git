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
public partial class admin_block_UpdateUSD : System.Web.UI.UserControl
{
    public string usd_update = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["usd"] != null)
            {
                string usd = Request.QueryString["usd"].ToString();
                ProductSystem product = new ProductSystem();
                if (product.UpdateUSD(usd))
                {
                    usd_update = "Tỷ giá USD đã được cập nhật";
                }
                else
                {
                    usd_update = "Có lỗi không thể cập nhật tỷ giá usd";
                }
            }
        }
        catch
        { 
        
        }
    }
}
