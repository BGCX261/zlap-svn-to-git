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
public partial class admin_block_ProductDesUpdate : System.Web.UI.UserControl
{
    public string specification = "Thông tin cấu hình";
    public string content = "";
    public string title = "";
    public string id = "";
    public string srtback = "imgpro";
    protected void Page_Load(object sender, EventArgs e)
    {
        diverror.Visible = false;
        try
        {
            id = Request.QueryString["id"].ToString();
            srtback = Request.QueryString["back"].ToString();
            DataSet ds = new ProductSystem().ProductDesId(id);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                content = ds.Tables[0].Rows[0]["des"].ToString();
                title = ds.Tables[0].Rows[0]["name"].ToString();
                specification = ds.Tables[0].Rows[0]["note"].ToString();
            }
            else
            {
                Response.Redirect("?menu=imgpro");
            }
        }
        catch
        {
            Response.Redirect("?menu=imgpro");
        }
    }
    protected void btedit_ServerClick(object sender, EventArgs e)
    {
        try
        {
            content = Request.Form["txtContent"].ToString();
            string _ShortDes = txtShortDes.Value.Trim();
            ProductSystem managerProduct = new ProductSystem();
            if (managerProduct.ProductDesUpdate(int.Parse(id), content,_ShortDes))
            {
                diverror.Visible = true;
                string nameGroup = txtName.Value.Trim();
                diverror.InnerHtml = "Thông tin mô tả sản phẩm đã được cập nhật !";
                if (nameGroup.Length > 0)
                { 
                    //UpdateGroupName:
                    managerProduct.ProductDesUpdateGroup(nameGroup, content);
                    diverror.InnerHtml += "<br />Sản phẩm theo nhóm đã được cập nhật mô tả !";
                    txtName.Value = "";
                }
                
            }
            else
            {
                diverror.Visible = true;
                diverror.InnerHtml = "Lỗi kết nối, xin bạn hãy thử lại";
            }
        }
        catch
        {
            diverror.InnerHtml = "Lỗi kết nối, xin bạn hãy thử lại";
        }
    }
}
