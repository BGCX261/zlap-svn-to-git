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
using common.list;
using facade.list;
using framework.list.common;
public partial class block_ChangeAccount : System.Web.UI.UserControl
{
    public string tblchange = "";
    public string taccount = "";
    public string tusername = "";
    public string tpass1 = "";
    public string tpass2 = "";
    public string taccountinfo = "";
    public string tname = "";
    public string tcompany = "";
    public string tjob = "";
    public string tmobile = "";
    public string thomephone = "";
    public string toffice = "";
    public string temail1 = "";
    public string temail2 = "";
    public string tfax = "";
    public string ttax = "";
    public string twebsite = "";
    public string tbilling = "";
    public string taddress = "";
    public string tcity = "";
    public string tcountry = "";
    public string tzipcode = "";
    public string tshipping = "";
    public string tbutton = "";
    public string terrcommon = "";
    public string terrUpdate = "";
    public string terrlengpass = "";
    public string terrpass = "";
    public string tyestochange = "";
    public string terremail = "";
    public UserManagerSystem Users = new UserManagerSystem();
    public UserAccount_data userInfo = new UserAccount_data();
    CValidate Validate = new CValidate();
    public string currentAccess = "";
    string thome = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["infoUser"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        try
        {
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            currentAccess = hash["currentpage"].ToString();
            thome = hash["home"].ToString();
            tblchange = hash["facount"].ToString();
            currentAccess += ": <a href='?menu=home'>" + thome + "</a> &raquo; " + tblchange;
            if (!IsPostBack)
            {
                string[] arrstr = (string[])Session["infoUser"];
                UserAccount_data userInfo = Users.GetUserInformation(int.Parse(arrstr[0]));
                if (userInfo.Tables.Count > 0)
                {
                    if (userInfo.Tables[0].Rows.Count > 0)
                    {
                        txtusername.Value = userInfo.Tables[0].Rows[0][UserAccount_data._UserName].ToString();
                        txtname.Value = userInfo.Tables[0].Rows[0][UserAccount_data._ContactName].ToString();
                        txtcompany.Value = userInfo.Tables[0].Rows[0][UserAccount_data._Company].ToString();
                        txtjob.Value = userInfo.Tables[0].Rows[0][UserAccount_data._JobTitle].ToString();
                        txtmobile.Value = userInfo.Tables[0].Rows[0][UserAccount_data._MobilePhone].ToString();
                        txtoffice.Value = userInfo.Tables[0].Rows[0][UserAccount_data._OfficePhone].ToString();
                        txthome.Value = userInfo.Tables[0].Rows[0][UserAccount_data._HomePhone].ToString();
                        txtemail1.Value = userInfo.Tables[0].Rows[0][UserAccount_data._Email1].ToString();
                        txtemail2.Value = userInfo.Tables[0].Rows[0][UserAccount_data._Email2].ToString();
                        txtfax.Value = userInfo.Tables[0].Rows[0][UserAccount_data._FaxNumber].ToString();
                        txttax.Value = userInfo.Tables[0].Rows[0][UserAccount_data._TaxCode].ToString();
                        txtwebsite.Value = userInfo.Tables[0].Rows[0][UserAccount_data._Website].ToString();
                        txtaddressbill.Value = userInfo.Tables[0].Rows[0][UserAccount_data._BillingAddress].ToString();
                        txtcitybill.Value = userInfo.Tables[0].Rows[0][UserAccount_data._BillingCity].ToString();
                        txtzipcodebill.Value = userInfo.Tables[0].Rows[0][UserAccount_data._BillingZipCode].ToString();
                        txtcountrybill.Value = userInfo.Tables[0].Rows[0][UserAccount_data._BillingCountry].ToString();
                        txtaddressship.Value = userInfo.Tables[0].Rows[0][UserAccount_data._ShippingAddress].ToString();
                        txtcityship.Value = userInfo.Tables[0].Rows[0][UserAccount_data._ShippingCity].ToString();
                        txtzipcodeship.Value = userInfo.Tables[0].Rows[0][UserAccount_data._ShippingZipCode].ToString();
                        txtcountryship.Value = userInfo.Tables[0].Rows[0][UserAccount_data._ShippingCountry].ToString();

                    }
                    else
                    {
                        Session["infoUser"] = null;
                        Response.Redirect("Default.aspx");
                    }
                }
                else
                {
                    Session["infoUser"] = null;
                    Response.Redirect("Default.aspx");
                }
            }
            diverror1.Visible = false;
            diverror2.Visible = false;
            diverror3.Visible = false;
            diverror4.Visible = false;
            
            tblchange = "Thay đổi thông tin khách hàng";
            taccount = "Tài khoản đăng nhập";
            tusername = "Tên đăng nhập";
            tpass1 = "Mật khẩu";
            tpass2 = "Xác nhận mật khẩu";
            taccountinfo = "Thông tin khách hàng";
            tname = "Họ và tên";
            tcompany = "Tên công ty";
            tjob = "Nghề nghiệp";
            tmobile = "Số đt di động";
            toffice = "Số đt cơ quan";
            thomephone = "Số đt nhà riêng";
            temail1 = "Địa chỉ mail1";
            temail2 = "Địa chỉ mail2";
            tfax = "Số Fax";
            ttax = "Mã số thuế";
            twebsite = "Website";
            tbilling = "Địa chỉ thanh toán";
            taddress = "Địa chỉ";
            tcity = "Thành Phố";
            tcountry = "Quốc Gia";
            tzipcode = "Mã bưu điện";
            tshipping = "Địa chỉ giao hàng";
            tbutton = "Chỉnh sửa";
            terrUpdate = "Lỗi kết nối SQL. Không thể chỉnh sửa. Xin hãy thử lại";
            tyestochange = "Thông tin đã được thay đổi";
            terrlengpass = "Mật khẩu phải từ 4 đến 15 ký tự";
            terrpass = "Mật khẩu xác nhận không đúng";
            terrcommon = "Xin hãy nhập thông tin cần thiết";
            terremail = "Địa chỉ email không hợp lệ";
            buttonpass.Value = tbutton;
            buttoninfor.Value = tbutton;
            buttonbilling.Value = tbutton;
            buttonship.Value = tbutton;
        }
        catch
        { 
        
        }
    }
    protected void changepass_Click(object sender, EventArgs e)
    {
        try
        {
            string pass1 = txtpass1.Value.Trim();
            string pass2 = txtpass2.Value.Trim();
            if ((pass1.Length == 0) || (pass2.Length == 0))
            {
                diverror1.Visible = true;
                diverror1.InnerHtml = "<div class='diverror'>" + terrcommon + "</div>";
                return;
            }
            else if (pass1.Length < 4)
            {
                diverror1.Visible = true;
                diverror1.InnerHtml = "<div class='diverror'>" + terrlengpass + "</div>";
                return;
            }
            else if (!pass1.Equals(pass2))
            {
                diverror1.Visible = true;
                diverror1.InnerHtml = "<div class='diverror'>" + terrpass + "</div>";
                return;
            }
            MD5 md5 = new MD5();
            pass1 = md5.Encrypt(pass1);
            string[] arrstr = (string[])Session["infoUser"];
            Users.UserUpdateNewPassId(int.Parse(arrstr[0]), pass1);
            diverror1.Visible = true;
            diverror1.InnerHtml = "<div class='diverror'>" + tyestochange + "</div>";
            return;
        }
        catch
        {
            diverror1.Visible = true;
            diverror1.InnerHtml = "<div class='diverror'>" + terrUpdate + "</div>";
            return;
        }
    }
    protected void changeinfo_Click(object sender, EventArgs e)
    {
        try
        {
            string name = txtname.Value.Trim();
            string company = txtcompany.Value.Trim();
            string job = txtjob.Value.Trim();
            string mobile = txtmobile.Value.Trim();
            string office = txtoffice.Value.Trim();
            string home = txthome.Value.Trim();
            //string email1 = txtemail1.Value.Trim();
            string email2 = txtemail2.Value.Trim();
            string fax = txtfax.Value.Trim();
            string tax = txttax.Value.Trim();
            string website = txtwebsite.Value.Trim();
            if (name.Length == 0)
            {
                diverror2.Visible = true;
                diverror2.InnerHtml = "<div class='diverror'>" + terrcommon + "</div>";
                return;
            }
            else if (!Validate.TestAddressEmail(email2))
            {
                diverror2.Visible = true;
                diverror2.InnerHtml = "<div class='diverror'>" + terremail + "</div>";
                return;
            }
            string[] arrstr = (string[])Session["infoUser"];
            Boolean update = Users.UserUpdateInfoId(int.Parse(arrstr[0].ToString()), name, company, job, mobile, office, home, email2, fax, tax, website);
            if (update)
            {
                diverror2.Visible = true;
                diverror2.InnerHtml = "<div class='diverror'>" + tyestochange + "</div>";
                return;
            }
            else
            {
                diverror2.Visible = true;
                diverror2.InnerHtml = "<div class='diverror'>" + terrUpdate + "</div>";
                return;
                
            }
            
        }
        catch
        {
            diverror2.Visible = true;
            diverror2.InnerHtml = "<div class='diverror'>" + terrUpdate + "</div>";
            return;
        }
    }
    protected void changeBilling_Click(object sender, EventArgs e)
    {
        try
        {
            string address = txtaddressbill.Value.Trim();
            string city = txtcitybill.Value.Trim();
            string zipcode = txtzipcodebill.Value.Trim();
            string country = txtcountrybill.Value.Trim();
            if (address.Length == 0)
            {
                diverror3.Visible = true;
                diverror3.InnerHtml = "<div class='diverror'>" + terrcommon + "</div>";
                return;
            }
            string[] arrstr = (string[])Session["infoUser"];
            Boolean update = Users.UserUpdateBillingId(int.Parse(arrstr[0].ToString()),address,city,zipcode,country);
            if (update)
            {
                diverror3.Visible = true;
                diverror3.InnerHtml = "<div class='diverror'>" + tyestochange + "</div>";
                return;
            }
            else
            {
                diverror3.Visible = true;
                diverror3.InnerHtml = "<div class='diverror'>" + terrUpdate + "</div>";
                return;

            }
        }
        catch
        {
            diverror3.Visible = true;
            diverror3.InnerHtml = "<div class='diverror'>" + terrUpdate + "</div>";
            return;
        }
    }
    protected void changeShipping_Click(object sender, EventArgs e)
    {
        try
        {
            string address = txtaddressship.Value.Trim();
            string city = txtcityship.Value.Trim();
            string zipcode = txtzipcodeship.Value.Trim();
            string country = txtcountryship.Value.Trim();
            if (address.Length == 0)
            {
                diverror4.Visible = true;
                diverror4.InnerHtml = "<div class='diverror'>" + terrcommon + "</div>";
                return;
            }
            string[] arrstr = (string[])Session["infoUser"];
            Boolean update = Users.UserUpdateShippingId(int.Parse(arrstr[0].ToString()), address, city, zipcode, country);
            if (update)
            {
                diverror4.Visible = true;
                diverror4.InnerHtml = "<div class='diverror'>" + tyestochange + "</div>";
                return;
            }
            else
            {
                diverror4.Visible = true;
                diverror4.InnerHtml = "<div class='diverror'>" + terrUpdate + "</div>";
                return;

            }
        }
        catch
        {
            diverror4.Visible = true;
            diverror4.InnerHtml = "<div class='diverror'>" + terrUpdate + "</div>";
            return;
        }
    }
}
