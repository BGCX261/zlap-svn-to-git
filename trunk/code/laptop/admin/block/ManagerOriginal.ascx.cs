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

using System.Web.UI.HtmlControls;
using framework.list.dynamicviewhelper;
public partial class admin_block_ManagerOriginal : System.Web.UI.UserControl
{
    public string strPage = "Trang : ";
    public string strlist = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        ShowProduct();
    }
    public void ShowProduct()
    {
        int page = 1;
        string text = "-1";
        string ismain = "";
        try
        {
            page = int.Parse(Request.QueryString["page"].ToString());
        }
        catch
        {
            try
            {
                text = Request.QueryString["search"].ToString();
                ismain = Request.QueryString["original"].ToString();
            }
            catch
            {
                text = "";
                ismain = "";
            }
        }
        CDynamicViewProMainPage ViewProduct = new CDynamicViewProMainPage();
        if (Session["SSListProOriginal"] == null)
        {
            ViewProduct.SetPageSize(20);
            ViewProduct.SetIdtype(int.Parse(Application["idtypeproduct"].ToString()));
            if (text.Equals("-1"))
            {
                ViewProduct.Buildwhere();
            }
            else
            {
                ViewProduct.SetTxtSearch(text);
                ViewProduct.SetIsMainpage(ismain);
                ViewProduct.Buildwhere();
            }
            ViewProduct.SetNumSelectOriginal();
            ViewProduct.SetCurrentPage(page);
            Session["SSListProOriginal"] = ViewProduct;
        }
        else
        {
            ViewProduct = (CDynamicViewProMainPage)Session["SSListProOriginal"];
            if (text.Equals("-1"))
            {
                //ViewProduct.BuildWhere();
            }
            else
            {
                ViewProduct.SetTxtSearch(text);
                ViewProduct.SetIsMainpage(ismain);
                ViewProduct.Buildwhere();
            }
            ViewProduct.SetNumSelectOriginal();
            ViewProduct.SetCurrentPage(page);
        }
        if (ViewProduct.GetPages() > 1)
        {
            BuildPage(ViewProduct.GetCurrentPage(), ViewProduct.GetPages());
        }
        DataSet ds = ViewProduct.ProductSelectFromToOriginal();
        if (ds.Tables.Count == 0)
        {
            strlist = "Lỗi kết nối SQL. Không thể hiển thị dữ liệu";
            return;
        }
        int num = ds.Tables[0].Rows.Count;
        strlist = "<table border='1' cellpadding='1' cellspacing='0' width='100%' bordercolor='#DFDFDF' style='border-collapse:collapse;'>";
        strlist += "<tr class='tlist'><td width='30'>STT</td><td width='50'>Mã SP</td><td width='95'>Tên sản phẩm</td><td width='60'>Nhãn hiệu</td><td width='70'>Ảnh sản phẩm</td><td width='55'>Giá bán</td><td width='60'>Hàng độc?</td><td>Mô tả sản phẩm</td></tr>";
        for (int i = 1; i <= num; i++)
        {
            //Id,Name,UrlImage,SellingPrice,WarrantyMonth
            strlist += "<tr>";
            strlist += "<td align='center'>" + i + "</td>";
            strlist += "<td align='center'>" + ds.Tables[0].Rows[i - 1]["Id"].ToString() + "</td>";
            strlist += "<td>" + ds.Tables[0].Rows[i - 1]["Name"].ToString() + "</td>";
            strlist += "<td align='center'>" + ds.Tables[0].Rows[i - 1]["brand"].ToString() + "</td>";
            string nameImage = ds.Tables[0].Rows[i - 1]["UrlImage"].ToString();
            string url = nameImage;
            if (nameImage.Length == 0)
            {
                nameImage = "noimage";
            }
            if (url.Length > 0)
            {
                url = "<img class='imgpro' src='../image/img_pro/" + url + "' =/>";
            }
            else
            {
                url = "<img class='imgpro' src='../image/common/notimgpro.png'/>";
            }
            strlist += "<td align='center'>" + url + "</td>";
            strlist += "<td align='center'>" + ds.Tables[0].Rows[i - 1]["SellingPrice"].ToString() + "</td>";
            string idBest = ds.Tables[0].Rows[i - 1]["idproduct"].ToString();
            if (idBest.Length > 0)
            {
                strlist += "<td style='background-color:#CCCCCC' align='center'><input type='checkbox' id='" + idBest + "' checked='checked' onclick='changeOriginal(this);'/></td>";
            }
            else
            {
                //ds.Tables[0].Rows[i - 1]["Id"].ToString()
                strlist += "<td align='center'><input type='checkbox' id='" + ds.Tables[0].Rows[i - 1]["Id"].ToString() + "' onclick='changeOriginal(this);'/></td>";
            }
            strlist += "<td align='left'>" + ds.Tables[0].Rows[i - 1]["Note"].ToString() + "</td>";
            strlist += "</tr>";
        }
        strlist += "</table>";
    }
    public void BuildPage(int currentpage, int pages)
    {
        for (int i = 1; i <= pages; i++)
        {
            if (i == currentpage)
            {
                strPage += "<u>" + i + "</u>";
            }
            else
            {
                strPage += "<a href='?menu=original&page=" + i + "'>" + i + "</a> ";
            }
        }
    }
}
