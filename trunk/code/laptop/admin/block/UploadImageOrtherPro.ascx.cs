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
using framework.list.common;
using facade.list;

public partial class admin_block_UploadImageOrtherPro : System.Web.UI.UserControl
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
        try
        {
            page = int.Parse(Request.QueryString["page"].ToString());
        }
        catch
        {
        }
        CDynamicViewProduct ViewProduct = new CDynamicViewProduct();
        if (Session["SSListotherPro"] == null)
        {
            ViewProduct.SetPageSize(10);
            string listIdtype = "(" + Application["idtypeproduct"].ToString() + "," + Application["apppda"].ToString() + ")";
            string strwhere = " where producttypeid not in " + listIdtype + " and cansales=1";
            ViewProduct.SetWhere(strwhere);
            ViewProduct.SetNumQuickSearch();
            ViewProduct.SetCurrentPage(page);
            Session["SSListotherPro"] = ViewProduct;
        }
        else
        {
            ViewProduct = (CDynamicViewProduct)Session["SSListotherPro"];
            ViewProduct.SetNumQuickSearch();
            ViewProduct.SetCurrentPage(page);
        }
        if (ViewProduct.GetPages() > 1)
        {
            BuildPage(ViewProduct.GetCurrentPage(), ViewProduct.GetPages());
        }
        DataSet ds = ViewProduct.ProductUploadImageFromTo();
        if (ds.Tables.Count == 0)
        {
            strlist = "Lỗi kết nối SQL. Không thể hiển thị dữ liệu";
            return;
        }
        int num = ds.Tables[0].Rows.Count;
        strlist = "<table border='1' cellpadding='1' cellspacing='0' width='100%' bordercolor='#DFDFDF' style='border-collapse:collapse;'>";
        strlist += "<tr class='tlist'><td width='30'>STT</td><td width='50'>Mã SP</td><td width='95'>Tên sản phẩm</td><td width='60'>Nhãn hiệu</td><td width='70'>Ảnh sản phẩm</td><td width='55'>Giá bán</td><td>Mô tả sản phẩm</td></tr>";
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
                url = "<img class='imgpro' src='../image/img_pro/" + url + "' onclick=\"OnChoicePro(" + ds.Tables[0].Rows[i - 1]["Id"].ToString() + ",event,'" + nameImage + "','" + ds.Tables[0].Rows[i - 1]["Name"].ToString() + "');\" />";
            }
            else
            {
                url = "<img class='imgpro' src='../image/common/notimgpro.png' onclick=\"OnChoicePro(" + ds.Tables[0].Rows[i - 1]["Id"].ToString() + ",event,'" + nameImage + "','" + ds.Tables[0].Rows[i - 1]["Name"].ToString() + "');\" />";
            }
            strlist += "<td align='center'>" + url + "</td>";
            strlist += "<td align='center'>" + ds.Tables[0].Rows[i - 1]["SellingPrice"].ToString() + "</td>";
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
                strPage += "<a href='?menu=otherpro&page=" + i + "'>" + i + "</a> ";
            }
        }
    }
    protected string ButtonUpload_UploadClick(object sender, WebControls.UploadButtonEventArgs e)
    {
        string message = "";
        try
        {
            if (Session["SSIdProUpload"] == null)
            {
                message = "Xin bạn hãy chọn sản phẩm muốn upload ảnh.";
                return message;
            }
            else
            {
                string strIdAndName = Session["SSIdProUpload"].ToString();
                string[] arrvalue = strIdAndName.Split(',');
                CvalidateImageForPost imgProcess = new CvalidateImageForPost();
                FileUpload file = e.FileUploadControl;
                string file_name = file.PostedFile.FileName;
                if (file_name.Length == 0)
                {
                    message = "Xin bạn hãy chọn file ảnh";
                    return message;
                }
                else
                {
                    if (!imgProcess.TestTypeFile(file))
                    {
                        message = "File Không hợp lệ";
                        return message;
                    }
                    else if (imgProcess.TestMaxSizeImage(file, 20480))
                    {
                        message = "Kích thước ảnh không quá 20 KB";
                        return message;
                    }
                    else
                    {
                        string _path = Server.MapPath("../image/img_pro/");
                        string namepro = "_";
                        if (arrvalue.Length == 3)
                        {
                            namepro = arrvalue[2];
                            namepro = namepro.Replace(" ", "");
                        }
                        string strgetTime = new CGetDataCommon().GetStrMonthDayYearSecondMinuteHour();
                        string nameNew = "pro_" + arrvalue[0] + "_" + strgetTime + "." + imgProcess.GetExtension(file_name);
                        Boolean isUpload = imgProcess.UploadFile(file, _path + nameNew);
                        if (isUpload)
                        {
                            ProductSystem ManagerPro = new ProductSystem();
                            Boolean isUpdate = ManagerPro.ProductUpdateImage(int.Parse(arrvalue[0]), nameNew);
                            if (isUpdate)
                            {
                                message = "";
                                //Xóa ảnh cũ đi:
                                imgProcess.DeleteFile(_path + arrvalue[1]);
                                return message;
                            }
                            else
                            {
                                //Lỗi không thể cập nhật vào cơ sở dữ liệu. Xóa ảnh vừa upload lên đi.
                                imgProcess.DeleteFile(_path + nameNew);
                                message = "Lỗi kết nối SQL server. Không thể cập nhật được ảnh. Xin hãy thử lại";
                                return message;
                            }
                        }
                        else
                        {
                            message = "Lỗi mạng hoặc không có quyền tạo file trong thư mục ảnh sản phẩm. Không thể Upload file ảnh. Xin bạn hãy thử lại";
                            return message;
                        }
                    }
                }
            }
        }
        catch
        {
            message = "Có các lỗi sau đây: Không có quyền tạo file trong thư mục ảnh sản phẩm. Hoặc không cập nhật được vào CSDL. Hoặc ảnh bạn chọn không còn tồn tại. Xin bạn hãy thử lại";
        }
        return message;
    }
}
