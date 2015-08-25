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
using System.Text;
using System.IO;
using facade.list;
using framework.list.common;
using System.Xml;
using System.Net.Mail;
using System.Net;
using System.Runtime.InteropServices;
public partial class block_ReportPrice : System.Web.UI.UserControl
{
    CGetDataCommon DataCommon = new CGetDataCommon();
    FileInfo file;
    Boolean isCreatenewExcel = false;
    public string bldownprice = "Download và gửi báo giá";
    public string tmessagedown = "Bạn muốn tải báo giá Click vào đây: ";
    public string tdownload = "Tải báo giá";
    public string tsendpricetoemail = "Gửi báo giá vào Email";
    public string tchoiceBrand = "Chọn nhãn hiệu";
    public string tallbrand = "Tất cả nhãn hiệu";
    public string ttitle = "Tiêu đề";
    public string temailFrom = "Email người gửi";
    public string temailTo = "Email người nhận";
    public string tcode = "Mã an toàn";
    public string tconfirmcode = "Nhập lại mã";
    public string tsend = "Đồng ý";
    public string terror = "Xin bạn hãy điền các thông tin cần thiết";
    public string tinfor = "Thông tin thêm";
    public string terrEmail = "Địa chỉ Email không đúng";
    public string terrcode = "Mã an toàn không đúng";
    public string terrtosend = "Xin lỗi, hệ thống không hỗ trợ gửi Email";
    public string tyestsend = "Báo giá đã được gửi đến địa chỉ Email người nhận.";
    public string tCurrentAccess = "www.MayTinhXachTay.com";
    private string thome = "Trang chủ";
    public DateTime timecurrent = new DateTime();
    protected void Page_Load(object sender, EventArgs e)
    {
        tCurrentAccess += ": <a href='?menu=home'>" + thome + "</a> &raquo; " + bldownprice;
        string _path = Server.MapPath("data/exportprice/");
        string _nameFile = "bao_gia_laptop.xls";
        //tdownload += "(" timecurrent.g ")";
        //BarcodeLib.Code39 code39=new BarcodeLib.Code39('lebuisung');
        if (!IsPostBack)
        {
            if (Application["AppDownloadPrice"].ToString().Equals("0"))
            {
                Response.Redirect("Default.aspx");
            }
            divErrors.Visible = true;
            string random = DataCommon.CreateCodeRanDom(5);
            btsend.Value = tsend;
            Session["RamDomCodeRegister"] = random;
            try
            {
                file = new FileInfo(_path + _nameFile);
                if (file.Exists)
                {
                    DateTime timeNow = new DateTime();
                    DateTime timeLast = new DateTime();
                    timeNow = DateTime.Now;
                    timeLast = file.LastWriteTime;
                    TimeSpan subtime = timeNow - timeLast;
                    if (subtime.Minutes >10)
                    {
                        isCreatenewExcel = true;
                    }
                    else
                    {
                        if (subtime.Hours > 0)
                        {
                            isCreatenewExcel = true;
                        }
                        else if (subtime.Days > 0)
                        {
                            isCreatenewExcel = true;
                        }
                    }
                }
                else
                {
                    isCreatenewExcel = true;
                }
            }
            catch
            {
                isCreatenewExcel = true;
            }
        }
        if (Session["RamDomCodeRegister"] == null)
        {
            string random = DataCommon.CreateCodeRanDom(4);
            Session["RamDomCodeRegister"] = random;
        }
        if(isCreatenewExcel)
        {
            try
            {
                string table = "";
                table = ProducttoExcel("USD", 0, (int)Application["idtypeproduct"]);
                if (table.Length == 0)
                {
                    table = "<table><tr><td>Không có sản phẩm nào</td></tr></table>";
                }
                StreamWriter createFile = new StreamWriter(_path + _nameFile, false, Encoding.UTF8);
                createFile.Write(table, Encoding.UTF8);
                createFile.Close();
            }
            catch
            { 
            
            }
        }
        file = new FileInfo(_path + _nameFile);
        if (file.Exists)
        {
            timecurrent = file.LastWriteTime;
            timecurrent = timecurrent.ToUniversalTime();
            timecurrent = timecurrent.AddHours(7);
            tdownload = "<font color='blue'>" + tdownload + " (Cập nhật lúc: " + timecurrent.ToShortTimeString() + ", " + timecurrent.ToString("dd/MM/yy") + " - Hà Nội)</font>";
        }
    }
    public string ProducttoExcel(string Currency, int idbrand, int idtype)
    {
        ProductSystem product = new ProductSystem();
        DataSet ds = product.ProductExportPrice(Currency, idbrand, idtype);
        string table = "";
        try
        {
            DataTable TableCurrency = new DataTable();
            DataTable TablePro = new DataTable();
            DataTable TableWhere = new DataTable();
            timecurrent = DateTime.Now;
            timecurrent = timecurrent.ToUniversalTime();
            timecurrent = timecurrent.AddHours(7);
            float rate = (float)Application["ratepromain"];
            if (ds.Tables.Count > 0)
            {
                TableCurrency = ds.Tables[0];
                TablePro = ds.Tables[1];
                TableWhere = ds.Tables[2];
                float Exchange = 0, price = 0;
                float priceStand = 0;
                if (TableCurrency.Rows.Count > 0)
                {
                    Exchange = float.Parse(TableCurrency.Rows[0]["Rate"].ToString());
                }
                int numPro = TablePro.Rows.Count;
                int maxWhere = TableWhere.Rows.Count;
                string CurrentBrand = "";
                string currentId = "";
                //create HastTableWhere:
                Hashtable hashwhere = new Hashtable();
                int numwhere = TableWhere.Rows.Count;
                string idpro = "";
                DateTime time = new DateTime();
                for (int j = 0; j < numwhere; j++)
                {
                    idpro = TableWhere.Rows[j]["productid"].ToString();
                    int idstate = int.Parse(TableWhere.Rows[j]["id"].ToString());
                    string message = "";
                    time = DateTime.Now.ToUniversalTime();
                    time = time.AddHours(7);
                    if (idstate <= 5)
                    {

                    }
                    else
                    {
                        if (idstate == 6)
                        {
                            time = time.AddHours(24);
                        }
                        else if (idstate == 7)
                        {
                            time = time.AddHours(24);
                        }
                        else if (idstate == 8)
                        {
                            time = time.AddHours(48);
                        }
                        else if (idstate == 9)
                        {
                            if (TableWhere.Rows[j]["DisContinued"].ToString().Equals("7"))
                            {
                                time = (DateTime)TableWhere.Rows[j]["FirstImportDate"];
                                message = "(Đợt mới sẽ có ngày <font color='red'>" + time.ToString("dd/MM") + "</font>)";
                                continue;
                            }
                            else
                            {
                                time = time.AddHours(72);
                            }
                        }
                        else
                        {
                            continue;
                        }
                        message = "(Có thêm hàng ngày <font color='red'>" + time.ToString("dd/MM") + "</font>)";
                    }
                    try
                    {
                        if (hashwhere[idpro] != null)
                        {
                            hashwhere[idpro] = hashwhere[idpro].ToString() + "<br />* " + TableWhere.Rows[j]["address"].ToString() + message;
                        }
                        else
                        {
                            hashwhere[idpro] = "* " + TableWhere.Rows[j]["address"].ToString() + message;
                        }
                    }
                    catch
                    { }
                }
                table = "<table border='1' cellpadding='3' cellspacing='0' bordercolor='#676767' style='border-collapse:collapse;color:#000000;font-family:Arial, Helvetica,sans-serif;font-size:10px;'>";
                table += "<tr height='1'><td style='width:140px;'></td><td style='width:65px;'></td><td style='width:425px;'></td><td style='width:70px;'></td><td style='width:58px;'></td><td style='width:60px;'></td><td style='width:140px;'></td></tr>";
                table += "<tr height='36'><td colspan='7' align='center' style='vertical-align:middle;'><font style='font-size:19px;text-decoration:underline;font-weight:bold;'>";
                table += "WWW.MayTinhXachTay.com</font></td></tr>";
                
                table += "<tr height='45' style='line-height:18px'><td  style='font-weight:bold;font-size:14px;border-width:0px;vertical-align:top;'>TP.Hồ Chí Minh:</td><td colspan='6' style='font-size:12px;border-width:0px;vertical-align:middle;'>Showroom Nguyễn Ngọc Laptop,236-Cao Thắng nối dài. P12. Q 10-TP.HCM,(08)22430786,(08)22148675,0946769396.<br />";
                table += "Showroom Công Nghệ Di Động BTX, 77C Bùi thị xuân - P. Phạm Ngũ Lão - Q1 - TP.HCM, Tel: (08) 224.887.36, (08) 224.887.37, 0169.2204.686<br />Showroom Công Nghệ Di Động CMT8, 740-742 CMT8, F5, Q. Tân Bình - TP.HCM, Tel: 08.6.6567.069, 08.6.2680.865, 0902.894749</td></tr>";
                table += "<tr height='30' style='line-height:18px'><td style='font-weight:bold;font-size:14px;border-width:0px;vertical-align:top;'>Hà Nội:</td><td colspan='6' style='font-size:12px;border-width:0px;'>Showroom Điện Tử Sài Gòn, 270 Đào Duy Anh - Q. Đống Đa, Hà Nội, Tel: (04)35724492, (04)35724493, 0915025448, 0955169893. Fax: 84-4-5724519<br />";
                table += "Showroom Nguyễn Ngọc Laptop, 32 Thái Hà -Q. Đống Đa, Hà Nội: (04)35378840, (04)35378841, 0912745204, 0955925454. Fax: 84-4-5378839</td></tr>";
                table += "<tr height='20' style='line-height:18px'><td style='font-weight:bold;font-size:14px;border-width:0px;vertical-align:top;'>Đà Nẵng:</td><td colspan='6' style='font-size:12px;border-width:0px;'>Showroom Công Nghệ Di Động, 144 Hàm Nghi- Đà Nẵng, Tel: 0511 3656848, 01263664142, 01254480698";
                table += "</td></tr>";
                table += "<tr height='20' style='line-height:18px'><td style='font-weight:bold;font-size:14px;border-width:0px;vertical-align:top;'>Cần Thơ:</td><td colspan='6' style='font-size:12px;border-width:0px;'>Showroom Công Nghệ Di Động Tây Đô, 102 Trần Hưng Đạo - Q Ninh Kiều - TP Cần Thơ. Tel: 07106266889, 07106262979";
                table += "</td></tr>";
                table += "<tr height='20' style='line-height:18px'><td style='font-weight:bold;font-size:14px;border-width:0px;vertical-align:top;'>Quy Nhơn:</td><td colspan='6' style='font-size:12px;border-width:0px;'>Showroom Công nghệ di động Quy Nhơn 27 Lý Thường Kệt - P. Lê Hồng Phong - TP. Quy Nhơn ";
                table += "</td></tr>";
                table += "<tr height='20' style='line-height:18px'><td style='font-weight:bold;font-size:14px;border-width:0px;vertical-align:top;'>Long Xuyên:</td><td colspan='6' style='font-size:12px;border-width:0px;'>Công Nghệ Di Động Long Xuyên ";
                table += "</td></tr>";
                table += "<tr height='20' style='line-height:18px'><td style='font-weight:bold;font-size:14px;border-width:0px;vertical-align:top;'>Nha Trang:</td><td colspan='6' style='font-size:12px;border-width:0px;'>Công Nghệ Di Động Nha Trang ";
                table += "</td></tr>";
                //table += "</table>";
                //
                table +="<tr><td colspan='7' style='border-width:0px;' height='10'></td></tr>";
                table += "<tr height='22'><td colspan='7' style='border-width:0px;'>";
                table += "Báo giá chưa kể thuế VAT 5%, các máy tính bán đều phải cộng VAT và hoá đơn. Thanh toán bằng tiền mặt hoặc chuyển khoản.<br />";
                table += "</td></tr>";
                table += "<tr><td colspan='7' style='border-width:0px;' height='10'></td></tr>";
                table += "<tr height='28' style='vertical-align:middle;text-align:left;font-size:14px;'>";
                if (rate != 1)
                {
                    table += "<td colspan='3' style='border-width:0px;'><b>Báo giá máy tính xách tay</b>: Ngày <i>" + timecurrent.ToString("dd/MM/yy") + ", " + timecurrent.ToShortTimeString() + "(Giờ Hà Nội)</i></td><td align='center' style='border-width:0px;'>" + Exchange + "</td><td colspan='3' style='border-width:0px;'></td></tr>";
                }
                else
                {
                    table += "<td colspan='3' style='border-width:0px;'><b>Báo giá máy tính xách tay</b>: Ngày <i>" + timecurrent.ToString("dd/MM/yy") + ", " + timecurrent.ToShortTimeString() + "(Giờ Hà Nội)</i></td><td align='center' style='border-width:0px;'></td><td colspan='3' style='border-width:0px;'></td></tr>";
                }
                //table += "<td colspan='3' style='border-width:0px;'><b>Báo giá máy tính xách tay</b>: Ngày <i>" + timecurrent.ToString("dd/MM/yy") + ", " + timecurrent.ToShortTimeString() + "(Giờ Hà Nội)</i></td><td align='center' style='border-width:0px;'></td><td colspan='3' style='border-width:0px;'></td></tr>";
                table += "<tr height='34' style='vertical-align:middle;text-align:center;font-size:12px;font-weight:bold;'>";
                table += "<td colspan='2'>Tên và nhãn hiệu sản phẩm</td>";
                table += "<td>Mô tả sản phẩm</td>";
                table += "<td>Giá VND<br />(x1000đ)</td>";
                table += "<td>So sánh<br /></td>";
                table += "<td>Bảo hành<br />(Tháng)</td>";
                table += "<td>Nơi bán<br />(Stock)</td></tr>";
                if (numPro > 0)
                {
                    CurrentBrand = TablePro.Rows[0]["Brand"].ToString();
                    table += "<tr height='28'><td colspan='7' align='left' style='padding-left:20px;vertical-align:middle;font-size:12px;text-decoration:underline;font-weight:bold;'>" + CurrentBrand + "</td></tr>";
                }
                for (int i = 0; i < numPro; i++)
                {
                    string whereHave = "";
                    currentId = TablePro.Rows[i]["Id"].ToString();
                    if (hashwhere[currentId] != null)
                    {
                        whereHave = hashwhere[currentId].ToString();
                    }
                    else
                    {
                        continue;
                    }
                    price = float.Parse(TablePro.Rows[i]["SellingPrice"].ToString());
                    priceStand = (float)Math.Round(Exchange * price, 0);
                    if (!CurrentBrand.Equals(TablePro.Rows[i]["Brand"].ToString()))
                    {
                        CurrentBrand = TablePro.Rows[i]["Brand"].ToString();
                        table += "<tr height='28'><td colspan='7' align='left' style='padding-left:20px;vertical-align:middle;font-size:12px;text-decoration:underline;font-weight:bold;'>" + CurrentBrand + "</td></tr>";
                    }
                    table += "<tr height='120' style='vertical-align:middle;'>";
                    table += "<td colspan='2' style='font-size:12px;font-weight:bold;'>" + TablePro.Rows[i]["Name"].ToString() + " " + TablePro.Rows[i]["state"].ToString() + "</td>";
                    table += "<td style='vertical-align:middle;text-align:justify;'>" + TablePro.Rows[i]["Note"].ToString() + "</td>";
                    string subprice = "0";
                    try
                    {
                        subprice = priceStand.ToString("N").Split('.')[0];
                        if (subprice.Equals("0"))
                        {
                            subprice = "Đang cập nhật";
                        }
                    }
                    catch
                    { }
                    table += "<td align='center'>" + subprice + "</td>";
                    if (price == 0)
                    {
                        table += "<td align='center'></td>";
                    }
                    else
                    {
                        table += "<td align='center'>" + price + "</td>";
                    }
                    table += "<td align='center'>" + TablePro.Rows[i]["WarrantyMonth"].ToString() + "</td>";
                    table += "<td>" + whereHave + "</td></tr>";
                }
                table += "<tr height='40'><td colspan='7' style='border-width:0px;vertical-align:middle;text-align:justify;'>";
                table += "Chú ý: Mọi sản phẩm, hàng hóa, dịch vụ và giá cả bán ra đều dựa trên hiện trạng thực tế của sản phẩm, hàng hóa dịch vụ đó tại thời điểm bán ra và theo điều kiện bảo hành và điều kiện mua bán trong sổ bảo hành đi kèm.";
                table += "</td></tr>";
                table += "</table>";
            }
        }
        catch
        {
        }
        return table;
    }
    protected void btsend_ServerClick(object sender, EventArgs e)
    {
        try
        {
            string title = txtTitle.Value.Trim();
            string emailfrom = txtEmailFrom.Value.Trim();
            string emailto = txtEmailTo.Value.Trim();
            string morinfor = txtareamore.Value.Trim();
            string code = txtcode.Value.Trim();
            CManageError errors = Validate(title, emailfrom, emailto, code);
            if (errors.GetNumberErr() > 0)
            {
                divErrors.Visible = true;
                divErrors.InnerHtml = "<div class='diverror'>" + errors.GetAllError() + "</div>";
            }
            else
            {
                XmlDocument docservermail = new XmlDocument();
                string xpathfile = Server.MapPath("data/xml/configmailserver.xml");
                XmlTextReader readfile = new XmlTextReader(xpathfile);
                docservermail.Load(readfile);
                readfile.Close();
                XmlNode node = docservermail.SelectSingleNode("/server");
                XmlNodeList listnode = node.ChildNodes;
                int numnodes = listnode.Count;
                Hashtable hastServer = new Hashtable();
                for (int i = 0; i < numnodes; i++)
                {
                    hastServer.Add(listnode[i].Name, listnode[i].InnerText);
                }
                SmtpClient client = new SmtpClient();
                MailAddress addressfrom = new MailAddress(emailfrom, emailfrom, System.Text.Encoding.UTF8);
                MailAddress MailTo = new MailAddress(emailto);
                MailMessage message = new MailMessage();
                message.From = addressfrom;
                message.To.Add(MailTo);
                message.CC.Add(MailTo);
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                message.Subject =title;
                message.IsBodyHtml = false;
                message.Body = morinfor;
                xpathfile = Server.MapPath("data/exportprice/");
                DirectoryInfo listFile=new DirectoryInfo(xpathfile);
                //message.Attachments.Add(new Attachment(
                FileInfo[] allFile=listFile.GetFiles("*.xls");
                int numFile = allFile.Length;
                if (numFile > 3)
                {
                    numFile = 3;
                }
                if (numFile > 0)
                {
                    for (int i = 0; i < numFile; i++)
                    {
                        message.Attachments.Add(new Attachment(xpathfile + allFile[i].Name));
                    }
                }
                client.Host = hastServer["host"].ToString();
                client.Port = int.Parse(hastServer["port"].ToString());
                client.Credentials = new NetworkCredential(hastServer["username"].ToString(), hastServer["password"].ToString(), hastServer["domain"].ToString());
                client.Send(message);
                message.Dispose();
                txtEmailFrom.Value = "";
                txtEmailTo.Value = "";
                txtTitle.Value = "";
                txtcode.Value = "";
                txtareamore.Value = "";
                Session["RamDomCodeRegister"] = DataCommon.CreateCodeRanDom(5);
                divErrors.Visible = true;
                divErrors.InnerHtml = "<div class='diverror'>" + tyestsend + "</div>";
            }
        }
        catch(Exception ex)
        {
            divErrors.Visible = true;
            divErrors.InnerHtml = "<div class='diverror'>" + ex.ToString() + "</div>";
        }
    }
    public CManageError Validate(string title, string mailfrom, string mailto, string code)
    {
        CManageError errors = new CManageError();
        CValidate TestValue=new CValidate();
        int numErr = 0;
        if ((title.Length == 0) || (mailfrom.Length == 0) || (mailto.Length == 0) || (code.Length == 0))
        {
            errors.AddError(terror);
            numErr++;
            return errors;
        }
        if (!TestValue.TestAddressEmail(mailfrom) || !TestValue.TestAddressEmail(mailto))
        {
            errors.AddError(terrEmail);
            numErr++;
            return errors;
        }
        if (Session["RamDomCodeRegister"] != null)
        { 
            if(!code.Equals(Session["RamDomCodeRegister"].ToString()))
            {
                errors.AddError(terrcode);
                numErr++;
                Session["RamDomCodeRegister"] = DataCommon.CreateCodeRanDom(5);
                return errors;

            }
        }
        return errors;
    }
}