using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.IO;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using framework.list.dynamicviewhelper;
using framework.list.common;
using facade.list;

public partial class admin_block_UploadmultiImgProduct : System.Web.UI.UserControl
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
        string state = "";
        try
        {
            if (Request.QueryString["page"] != null)
            {
                page = int.Parse(Request.QueryString["page"].ToString());
            }
            if (Request.QueryString["search"] != null)
            {
                text = Request.QueryString["search"].ToString();
            }
            if (Request.QueryString["state"] != null)
            {
                state = Request.QueryString["state"].ToString();
            }
            if (Request.QueryString["viewall"] != null)
            {
                page = 1;
                text = "";
            }
        }
        catch
        {
        }
        try
        {
            CDynamicViewProduct ViewProduct = new CDynamicViewProduct();
            if (Session["SSListmultiImgPro"] == null)
            {
                ViewProduct.SetPageSize(10);
                ViewProduct.SetIdType(int.Parse(Application["idtypeproduct"].ToString()));
                if (text.Equals("-1"))
                {
                    ViewProduct.BuildWhere();
                }
                else
                {
                    ViewProduct.SetTextSearch(text);
                    ViewProduct.SetHasImage(state);
                    ViewProduct.BuildWhereMultiImg();
                }
                ViewProduct.SetNumMultiImg();
                ViewProduct.SetCurrentPage(page);
                Session["SSListmultiImgPro"] = ViewProduct;
            }
            else
            {
                ViewProduct = (CDynamicViewProduct)Session["SSListmultiImgPro"];
                if (text.Equals("-1"))
                {
                    //ViewProduct.BuildWhere();
                }
                else
                {
                    ViewProduct.SetTextSearch(text);
                    ViewProduct.SetHasImage(state);
                    ViewProduct.BuildWhereMultiImg();
                }
                ViewProduct.SetNumMultiImg();
                ViewProduct.SetCurrentPage(page);
            }
            if (ViewProduct.GetPages() > 1)
            {
                BuildPage(ViewProduct.GetCurrentPage(), ViewProduct.GetPages());
            }
            DataSet ds = ViewProduct.ProductMultiImgFromTo();
            if (ds.Tables.Count == 0)
            {
                strlist = "Lỗi kết nối SQL. Không thể hiển thị dữ liệu";
                return;
            }
            int num = ds.Tables[0].Rows.Count;
            strlist = "<table border='1' cellpadding='1' cellspacing='0' width='100%' bordercolor='#DFDFDF' style='border-collapse:collapse;'>";
            strlist += "<tr class='tlist'><td width='30'>STT</td><td width='70'>Ảnh 1</td><td width='70'>Ảnh 2</td><td width='70'>Ảnh 3</td><td width='70'>Ảnh 4</td><td width='70'>Ảnh 5</td><td width='70'>Quảng cáo thêm</td><td width='50'>Mã SP</td><td width='70'>Tên sản phẩm</td><td width='70'>Giá bán</td></tr>";
            for (int i = 1; i <= num; i++)
            {
                //Id,Name,UrlImage,SellingPrice,WarrantyMonth
                strlist += "<tr>";
                //strlist += "<td align='center'>" + ds.Tables[0].Rows[i - 1]["brand"].ToString() + "</td>";
                string img1 = ds.Tables[0].Rows[i - 1]["img1"].ToString();
                if (img1.Length > 0)
                {
                    img1 = "<img class='imgpro' src='../image/multiimg/" + img1 + "' onclick=\"OnChoicePro(" + ds.Tables[0].Rows[i - 1]["Id"].ToString() + ",event,'" + img1 + "','1');\" />";
                }
                else
                {
                    img1 = "<img class='imgpro' src='../image/common/notimgpro.png' onclick=\"OnChoicePro(" + ds.Tables[0].Rows[i - 1]["Id"].ToString() + ",event,'" + img1 + "','1');\" />";
                }
                string img2 = ds.Tables[0].Rows[i - 1]["img2"].ToString();
                if (img2.Length > 0)
                {
                    img2 = "<img class='imgpro' src='../image/multiimg/" + img2 + "' onclick=\"OnChoicePro(" + ds.Tables[0].Rows[i - 1]["Id"].ToString() + ",event,'" + img2 + "','2');\" />";
                }
                else
                {
                    img2 = "<img class='imgpro' src='../image/common/notimgpro.png' onclick=\"OnChoicePro(" + ds.Tables[0].Rows[i - 1]["Id"].ToString() + ",event,'" + img2 + "','2');\" />";
                }
                string img3 = ds.Tables[0].Rows[i - 1]["img3"].ToString();
                if (img3.Length > 0)
                {
                    img3 = "<img class='imgpro' src='../image/multiimg/" + img3 + "' onclick=\"OnChoicePro(" + ds.Tables[0].Rows[i - 1]["Id"].ToString() + ",event,'" + img3 + "','3');\" />";
                }
                else
                {
                    img3 = "<img class='imgpro' src='../image/common/notimgpro.png' onclick=\"OnChoicePro(" + ds.Tables[0].Rows[i - 1]["Id"].ToString() + ",event,'" + img3 + "','3');\" />";
                }
                string img4 = ds.Tables[0].Rows[i - 1]["img4"].ToString();
                if (img4.Length > 0)
                {
                    img4 = "<img class='imgpro' src='../image/multiimg/" + img4 + "' onclick=\"OnChoicePro(" + ds.Tables[0].Rows[i - 1]["Id"].ToString() + ",event,'" + img4 + "','4');\" />";
                }
                else
                {
                    img4 = "<img class='imgpro' src='../image/common/notimgpro.png' onclick=\"OnChoicePro(" + ds.Tables[0].Rows[i - 1]["Id"].ToString() + ",event,'" + img4 + "','4');\" />";
                }
                string img5 = ds.Tables[0].Rows[i - 1]["img5"].ToString();
                if (img5.Length > 0)
                {
                    img5 = "<img class='imgpro' src='../image/multiimg/" + img5 + "' onclick=\"OnChoicePro(" + ds.Tables[0].Rows[i - 1]["Id"].ToString() + ",event,'" + img5 + "','5');\" />";
                }
                else
                {
                    img5 = "<img class='imgpro' src='../image/common/notimgpro.png' onclick=\"OnChoicePro(" + ds.Tables[0].Rows[i - 1]["Id"].ToString() + ",event,'" + img5 + "','5');\" />";
                }
                string img7 = ds.Tables[0].Rows[i - 1]["img7"].ToString();
                if (img7.Length > 0)
                {
                    img7 = "<img class='imgpro' src='../image/multiimg/" + img7 + "' onclick=\"OnChoicePro(" + ds.Tables[0].Rows[i - 1]["Id"].ToString() + ",event,'" + img7 + "','7');\" />";
                }
                else
                {
                    img7 = "<img class='imgpro' src='../image/common/notimgpro.png' onclick=\"OnChoicePro(" + ds.Tables[0].Rows[i - 1]["Id"].ToString() + ",event,'" + img7 + "','7');\" />";
                }
                strlist += "<td align='center'>" + i + "</td>";
                strlist += "<td align='center'>" + img1 + "</td>";
                strlist += "<td align='center'>" + img2 + "</td>";
                strlist += "<td align='center'>" + img3 + "</td>";
                strlist += "<td align='center'>" + img4 + "</td>";
                strlist += "<td align='center'>" + img5 + "</td>";
                strlist += "<td align='center'>" + img7 + "</td>";
                strlist += "<td align='center'>" + ds.Tables[0].Rows[i - 1]["Id"].ToString() + "</td>";
                strlist += "<td><a href='?menu=updateDes&back=imgpro&id=" + ds.Tables[0].Rows[i - 1]["Id"].ToString() + "'>" + ds.Tables[0].Rows[i - 1]["Name"].ToString() + "</a></td>";
                strlist += "<td align='center'>" + ds.Tables[0].Rows[i - 1]["SellingPrice"].ToString() + "</td>";
                strlist += "</tr>";
            }
            strlist += "</table>";
        }
        catch
        {
            strlist = "";
        }
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
                strPage += "<a href='?menu=imgpromulti&page=" + i + "'>" + i + "</a> ";
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
                string _path = Server.MapPath("../image/multiimg/");
                if (file_name.Length == 0)
                {
                    if (arrvalue.Length==3)
                    {
                        if (arrvalue[2].Equals("7") && arrvalue[1].Length > 0)
                        {
                            //Delete advertise:
                            ProductSystem ManagerPro = new ProductSystem();
                            Boolean isUpdate = ManagerPro.ProductUpdateMultiImage(int.Parse(arrvalue[0]), arrvalue[2], "");
                            if (isUpdate)
                            {
                                imgProcess.DeleteFile(_path + arrvalue[1]);
                                message = "";
                                return message;
                            }
                        }
                    }
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
                    else if (imgProcess.TestMaxSizeImage(file, 102400))
                    {
                        message = "Kích thước ảnh không quá 100 KB";
                        return message;
                    }
                    else
                    {
                        string namepro = "";
                        if (arrvalue.Length == 3)
                        {
                            namepro = arrvalue[2];
                        }
                        string strgetTime = new CGetDataCommon().GetStrMonthDayYearSecondMinuteHour();
                        string nameNew = "pro_" + arrvalue[0] + "_" + namepro + "_" + strgetTime + "." + imgProcess.GetExtension(file_name);
                        Boolean isUpload = imgProcess.UploadFile(file, _path + nameNew);
                        if (isUpload)
                        {
                            ProductSystem ManagerPro = new ProductSystem();
                            Boolean isUpdate = ManagerPro.ProductUpdateMultiImage(int.Parse(arrvalue[0]),arrvalue[2], nameNew);
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
