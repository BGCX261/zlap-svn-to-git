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
public partial class admin_block_UploadImagePromation : System.Web.UI.UserControl
{
    public string strPage = "Trang : ";
    public string strlist = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        ShowProduct();
    }
    public void ShowProduct()
    {
        try
        {
            DataSet ds = new ProductSystem().Promotionall();
            int num = ds.Tables[0].Rows.Count;
            strlist = "<table border='1' cellpadding='1' cellspacing='0' width='100%' bordercolor='#DFDFDF' style='border-collapse:collapse;'>";
            strlist += "<tr class='tlist'><td width='30'>STT</td><td width='120'>Ngào tạo</td><td width='120'>Ảnh khuyễn mãi</td><td width='200'>Ảnh SP khuyến mãi nếu có</td></tr>";
            for (int i = 0; i < num; i++)
            {
                //Id,Name,UrlImage,SellingPrice,WarrantyMonth
                strlist += "<tr>";
                strlist += "<td align='center'>" + (i + 1) + "</td>";
                strlist += "<td align='center'>" + ds.Tables[0].Rows[i]["CreatedDate"].ToString() + "</td>";
                
                string nameImage = ds.Tables[0].Rows[i]["UrlImage"].ToString();
                string url = nameImage;
                if (nameImage.Length == 0)
                {
                    nameImage = "noimage";
                }
                if (url.Length > 0)
                {
                    url = "<img class='imgpro' src='../image/img_promotion/" + url + "' onclick=\"OnChoicePro(" + ds.Tables[0].Rows[i]["Id"].ToString() + ",event,'" + nameImage + "','" + ds.Tables[0].Rows[i]["Id"].ToString() + "');\" />";
                }
                else
                {
                    url = "<img class='imgpro' src='../image/common/notimgpro.png' onclick=\"OnChoicePro(" + ds.Tables[0].Rows[i]["Id"].ToString() + ",event,'" + nameImage + "','" + ds.Tables[0].Rows[i]["Id"].ToString() + "');\" />";
                }
                strlist += "<td align='center'>" + url + "</td>";
                strlist += "<td>" + ds.Tables[0].Rows[i]["Name"].ToString() + "</td>";
                strlist += "</tr>";
            }
            strlist += "</table>";
        }
        catch
        {

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
                    else if (imgProcess.TestMaxSizeImage(file, 30720))
                    {
                        message = "Kích thước ảnh không quá 30 KB";
                        return message;
                    }
                    else
                    {
                        string _path = Server.MapPath("../image/img_promotion/");
                        string namepro = "_";
                        if (arrvalue.Length == 3)
                        {
                            namepro = arrvalue[2];
                        }
                        string strgetTime = new CGetDataCommon().GetStrMonthDayYearSecondMinuteHour();
                        string nameNew = "promotion_" + arrvalue[0] + "_" + strgetTime + "." + imgProcess.GetExtension(file_name);
                        Boolean isUpload = imgProcess.UploadFile(file, _path + nameNew);
                        if (isUpload)
                        {
                            ProductSystem ManagerPro = new ProductSystem();
                            Boolean isUpdate = ManagerPro.PromationUpdateImage(nameNew, arrvalue[0]);
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
