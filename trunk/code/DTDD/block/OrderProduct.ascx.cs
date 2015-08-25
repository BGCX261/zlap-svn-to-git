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
using framework.list.bean;
using framework.list.common;
public partial class block_OrderProduct : System.Web.UI.UserControl
{
    public ProInCart proIncart = new ProInCart();
    public ManagerProcart ManagerCart = new ManagerProcart();
    public string tblOrder = "Đặt hàng trực tuyến";
    public string tmessageinfo = "Bạn chưa đăng nhập. Xin bạn hãy đăng nhập hặc đăng ký là thành viên";
    public string currentAccess = "Bạn đang đăng truy cập đến";
    public string tname = "Họ tên";
    public string taddress = "Địa chỉ";
    public string temail = "Email";
    public string tmobile = "Số di động";
    public string thome = "Số cố định";
    public string tmoreinfo = "Thông tin thêm";
    public string stroption = "";
    public string terrmail = "Địa chỉ email không hợp lệ";
    public string terrcommon = "Xin bạn hãy nhập đầy đủ thông tin";
    public string tdayRequest = "Số ngày yêu cầu";
    public string tWhereOrder = "Địa điểm đặt hàng";
    public string tPleaseChoiceWhere = "Xin chọn địa điểm đạt hàng";
    public string lhome = "Trang chủ";
    public string terrOrder = "Lỗi kết nối, không thể đặt hàng. Xin bạn hãy thử lại";
    UserManagerSystem ManagerUser = new UserManagerSystem();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ProductInCart"] != null)
        {
            ManagerCart = (ManagerProcart)Session["ProductInCart"];
        }
        if (ManagerCart.getLengList() > 0)
        {

        }
        else
        {
            Response.Redirect("?menu=shoppingcart");
        }
        //Getlang:
        try
        {
            currentAccess += ": <a href='?menu=home'>" + lhome + "</a> &raquo; " + tblOrder;
        }
        catch
        { 
        
        }
        plhTop.Controls.Add(Page.LoadControl("block/ShoppingCart.ascx"));
        if (Session["infoUser"] != null)
        {
            tmessageinfo = "Xin bạy hãy chỉnh sửa thông tin liên hệ, nếu cần thiết";
        }
        if (!IsPostBack)
        {
            divErrors.Disabled = true;
            //Get Pos:
            DataSet dsPos = ManagerUser.PosSelectAllForOrderProduct();
            int numPos = dsPos.Tables[0].Rows.Count;
            ListItem Item = new ListItem(tPleaseChoiceWhere, "0");
            slPos.Items.Add(Item);
            for (int i = 0; i < numPos; i++)
            { 
                Item=new ListItem(dsPos.Tables[0].Rows[i]["Name"].ToString(),dsPos.Tables[0].Rows[i]["Id"].ToString());
                slPos.Items.Add(Item);
            }
            if(Session["infoUser"] != null)
            {
                string[] arrInfo =(string[])Session["infoUser"];
                DataSet ds=ManagerUser.GetUserInformation(int.Parse(arrInfo[0]));
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtname.Value = ds.Tables[0].Rows[0]["ContactName"].ToString();
                        txtaddess.Value = ds.Tables[0].Rows[0]["ShippingAddress"].ToString();
                        txtemail.Value = ds.Tables[0].Rows[0]["Email1"].ToString();
                        txtmobile.Value = ds.Tables[0].Rows[0]["MobilePhone"].ToString();
                        txthome.Value = ds.Tables[0].Rows[0]["HomePhone"].ToString();
                    }
                }
            }
        }
    }
    protected void btorder_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if (Session["infoUser"] != null)
            {
                string name = txtname.Value.Trim();
                string address = txtaddess.Value.Trim();
                string email = txtemail.Value.Trim();
                string mobile = txtmobile.Value.Trim();
                string homephone = txthome.Value.Trim();
                int idPost = int.Parse(slPos.Value);
                int NumDay = int.Parse(slNumberDay.Value);
                string City="";
                string Zipcode="";
                string Country="";
                name = name.Replace('<', ' ');
                name = name.Replace('>', ' ');
                address = address.Replace('<', ' ');
                address = address.Replace('>', ' ');
                mobile = mobile.Replace('<', ' ');
                mobile = mobile.Replace('>', ' ');
                homephone = homephone.Replace('<', ' ');
                homephone = homephone.Replace('>', ' ');
                string note="";
                if (homephone.Length > 0)
                {
                    mobile += ", " + homephone;
                }
                CManageError error = Validate(name, address, email, mobile,idPost);
                if (error.GetNumberErr() > 0)
                {
                    divErrors.Disabled = false;
                    divErrors.InnerHtml = "<br /><div class='diverror'>" + error.GetAllError() + "</div>";
                }
                else
                {
                    DateTime timeNow=new DateTime();
                    timeNow=DateTime.Now;
                    string[] arrInfo = (string[])Session["infoUser"];
                    int idCurrency=0;
                    float Rate=0;
                    
                    //InsertValue:
                    string codenumber = ManagerUser.getOrderNumber();
                    DataSet dsInfo = ManagerUser.SelectInformationForOrder(int.Parse(arrInfo[0]), Application["currency"].ToString());
                    try
                    {
                        if (dsInfo.Tables.Count > 0)
                        {
                            if (dsInfo.Tables[0].Rows.Count > 0)
                            {
                                City = dsInfo.Tables[0].Rows[0]["ShippingCity"].ToString();
                                Zipcode = dsInfo.Tables[0].Rows[0]["ShippingZipcode"].ToString();
                                Country = dsInfo.Tables[0].Rows[0]["ShippingCountry"].ToString();
                            }
                        }
                    }
                    catch
                    {

                    }
                    try
                    {
                        if (dsInfo.Tables.Count > 0)
                        {
                            if (dsInfo.Tables[1].Rows.Count > 0)
                            {
                                idCurrency = int.Parse(dsInfo.Tables[1].Rows[0]["id"].ToString());
                                Rate = float.Parse(dsInfo.Tables[1].Rows[0]["Rate"].ToString());
                            }
                        }
                    }
                    catch
                    {

                    }
                    int Idorder=ManagerUser.OrderInsertNew(codenumber, 0, timeNow, 0, int.Parse(arrInfo[0]), idPost, 1, 4, NumDay, 0, "", 0, idCurrency, Rate, name, address, City, Zipcode, Country, mobile, email, note);
                    if (Idorder>0)
                    {
                        ArrayList listvalue = new ArrayList();
                        ManagerCart = (ManagerProcart)Session["ProductInCart"];
                        int Num = ManagerCart.getLengList();
                        for (int i = 0; i < Num; i++)
                        {
                            string[] arrvalue = new string[6];
                            proIncart = (ProInCart)ManagerCart.GetProIndex(i);
                            arrvalue[0] = proIncart.id.ToString();
                            if (proIncart.type == 2)
                            {
                                arrvalue[1] = "0";
                            }
                            else
                            {
                                arrvalue[1] = "1";
                            }
                            //seri:
                            arrvalue[2] = "";
                            arrvalue[3] = proIncart.number.ToString();
                            arrvalue[4] = proIncart.price.ToString();
                            arrvalue[5] = proIncart.rate.ToString();
                            listvalue.Add(arrvalue);
                        }
                        float discount=0;
                        float tax=0;
                        Boolean test= ManagerUser.InsertOrderDetail(Idorder, Rate, discount, tax, listvalue);
                        if (test)
                        {
                            Session["ProductInCart"] = null;
                            Session["ssListOrder"] = null;
                            Response.Redirect("Default.aspx?menu=yesorder");
                        }
                        else
                        {
                            divErrors.Disabled = false;
                            divErrors.InnerHtml = "<br /><div class='diverror'>" + terrOrder + "</div>";
                        }
                    }
                    else
                    {
                        divErrors.Disabled = false;
                        divErrors.InnerHtml = "<br /><div class='diverror'>" + terrOrder + "</div>";
                    }
                }
            }
            else
            {
                divErrors.Disabled = false;
                divErrors.InnerHtml = "<br /><div class='diverror'>" + tmessageinfo + "</div>";
            }
        }
        catch
        { 
        }
    }
    public CManageError Validate(string name, string address, string email,string mobile,int idPos)
    {
        CValidate testValue = new CValidate();
        CManageError errors = new CManageError();
        int numErr = 0;
        if (name.Length == 0 || address.Length == 0 || email.Length==0 || mobile.Length==0)
        {
            numErr++;
            errors.AddError(terrcommon);
            return errors;
        }
        if (idPos==0)
        {
            numErr++;
            errors.AddError(tPleaseChoiceWhere);
            return errors;
        }
        if (!testValue.TestAddressEmail(email))
        {
            numErr++;
            errors.AddError(terrmail);
            return errors;
        }
        return errors;
    }
}
