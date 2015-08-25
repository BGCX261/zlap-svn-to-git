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
using framework.list.dynamicviewhelper;
public partial class admin_block_ManageProBestSell : System.Web.UI.UserControl
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
        string bestsell = "";
        try
        {
            page = int.Parse(Request.QueryString["page"].ToString());
        }
        catch
        {
            try
            {
                text = Request.QueryString["search"].ToString();
                bestsell = Request.QueryString["best"].ToString();
            }
            catch
            {
                text = "";
                bestsell = "";
            }
        }
        CDynamicViewProBestSell ViewProduct = new CDynamicViewProBestSell();
        if (Session["SSListProBestSell"] == null)
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
                ViewProduct.SetIsBest(bestsell);
                ViewProduct.Buildwhere();
            }
            ViewProduct.SetNumSelectBestSell();
            ViewProduct.SetCurrentPage(page);
            Session["SSListProBestSell"] = ViewProduct;
        }
        else
        {
            ViewProduct = (CDynamicViewProBestSell)Session["SSListProBestSell"];
            if (text.Equals("-1"))
            {
                //ViewProduct.BuildWhere();
            }
            else
            {
                ViewProduct.SetTxtSearch(text);
                ViewProduct.SetIsBest(bestsell);
                ViewProduct.Buildwhere();
            }
            ViewProduct.SetNumSelectBestSell();
            ViewProduct.SetCurrentPage(page);
        }
        if (ViewProduct.GetPages() > 1)
        {
            BuildPage(ViewProduct.GetCurrentPage(), ViewProduct.GetPages());
        }
        DataSet ds = ViewProduct.ProductSelectFromTo();
        if (ds.Tables.Count == 0)
        {
            strlist = "Lỗi kết nối SQL. Không thể hiển thị dữ liệu";
            return;
        }
        int num = ds.Tables[0].Rows.Count;
        strlist = "<table border='1' cellpadding='1' cellspacing='0' width='100%' bordercolor='#DFDFDF' style='border-collapse:collapse;'>";
        strlist += "<tr class='tlist'><td width='30'>STT</td><td width='50'>Mã SP</td><td width='95'>Tên sản phẩm</td><td width='60'>Nhãn hiệu</td><td width='70'>Ảnh sản phẩm</td><td width='55'>Giá bán</td><td width='60'>Bán chạy?</td><td>Mô tả sản phẩm</td></tr>";
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
                strlist += "<td style='background-color:#CCCCCC' align='center'><input type='checkbox' id='" + idBest + "' checked='checked' onclick='changeBest(this,1);'/></td>";
            }
            else
            {
                //ds.Tables[0].Rows[i - 1]["Id"].ToString()
                strlist += "<td align='center'><input type='checkbox' id='" + ds.Tables[0].Rows[i - 1]["Id"].ToString() + "' onclick='changeBest(this,1);'/></td>";
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
                strPage += "<a href='?menu=probestsell&page=" + i + "'>" + i + "</a> ";
            }
        }
    }
}
