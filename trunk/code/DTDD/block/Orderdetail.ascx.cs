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
public partial class block_Orderdetail : System.Web.UI.UserControl
{
    public string tbl = "Chi tiết đơn đặt hàng";
    public string id = "";
    public string strorderinfo = "";
    public string strDetailShipper = "";
    public UserManagerSystem UserManage = new UserManagerSystem();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            id=Request.QueryString["id"].ToString();
            if (Session["infoUser"] == null)
            {
                Response.Redirect("Default.aspx?menu=manageorder");
            }
            else
            {
                string[] InforUser=(string[])Session["infoUser"];
                DataSet OrderDetail = UserManage.OrderSelectDetailId(int.Parse(id), int.Parse(InforUser[0]));
                if (OrderDetail.Tables[0].Rows.Count > 0)
                {
                    DateTime time = (DateTime)OrderDetail.Tables[0].Rows[0]["orderdate"];
                    DateTime time1 = (DateTime)OrderDetail.Tables[0].Rows[0]["shipDate"];
                    strorderinfo += "<table border='0' cellspacing='0' cellpadding='1' width='100%'>";
                    strorderinfo += "<tr><td width='140'>Mã đơn hàng:</td>";
                    strorderinfo += "<td><span class='text_title'>" + OrderDetail.Tables[0].Rows[0]["ordernumber"].ToString() + "</span></td></tr>";
                    strorderinfo += "<tr><td colspan='2' class='bg_line2'></td></tr>";
                    strorderinfo += "<tr><td width='140'>Trạng thái:</td>";
                    strorderinfo += "<td><span class='text_title'>" + OrderDetail.Tables[0].Rows[0]["state"].ToString() + "</span></td></tr>";
                    strorderinfo += "<tr><td colspan='2' class='bg_line2'></td></tr>";
                    strorderinfo += "<tr><td width='140'>Ngày đặt hàng:</td>";
                    strorderinfo += "<td><span class='price'>" + time.ToString("dd/MM/yyyy") + " " + time.ToShortTimeString() + "</span></td></tr>";
                    strorderinfo += "<tr><td colspan='2' class='bg_line2'></td></tr>";
                    strorderinfo += "<tr><td width='140'>Ngày nhận hàng:</td>";
                    strorderinfo += "<td><span class='text_title'>" + time1.ToString("dd/MM/yyyy") + "</span></td></tr>";
                    strorderinfo += "<tr><td colspan='2' class='bg_line2'></td></tr>";
                    strorderinfo += "<tr><td width='140'>Điểm bán hàng:</td>";
                    strorderinfo += "<td><span class='price'>" + OrderDetail.Tables[0].Rows[0]["address"].ToString() + "</span></td></tr>";
                    strorderinfo += "<tr><td colspan='2' class='bg_line2'></td></tr>";
                    strorderinfo += "<tr><td width='140'>Người nhận hàng:</td>";
                    strorderinfo += "<td><span class='price'>" + OrderDetail.Tables[0].Rows[0]["shippingName"].ToString() + "</span></td></tr>";
                    strorderinfo += "<tr><td colspan='2' class='bg_line2'></td></tr>";
                    strorderinfo += "<tr><td width='140'>Nơi nhận hàng:</td>";
                    strorderinfo += "<td><span class='price'>" + OrderDetail.Tables[0].Rows[0]["shippingAddress"].ToString() + "</span></td></tr>";
                    strorderinfo += "<tr><td colspan='2' class='bg_line2'></td></tr>";
                    strorderinfo += "<tr><td width='140'>Thành phố:</td>";
                    strorderinfo += "<td><span class='price'>" + OrderDetail.Tables[0].Rows[0]["shippingCity"].ToString() + "</span></td></tr>";
                    strorderinfo += "<tr><td colspan='2' class='bg_line2'></td></tr>";
                    strorderinfo += "<tr><td width='140'>Điện thoại:</td>";
                    strorderinfo += "<td><span class='price'>" + OrderDetail.Tables[0].Rows[0]["phone"].ToString() + "</span></td></tr>";
                    strorderinfo += "<tr><td colspan='2' class='bg_line2'></td></tr>";
                    strorderinfo += "<tr><td width='140'>Email:</td>";
                    strorderinfo += "<td><span class='price'>" + OrderDetail.Tables[0].Rows[0]["email"].ToString() + "</span></td></tr>";
                    strorderinfo += "<tr><td colspan='2' class='bg_line2'></td></tr>";
                    strorderinfo += "</table>";
                    if (OrderDetail.Tables[0].Rows[0]["shippername"].ToString().Length > 0)
                    {
                        strDetailShipper += "<table border='0' cellpadding='0' cellspacing='0' width='100%'>";
                        strDetailShipper += "<tr><td colspan='2' class='title_1'>Thông tin giao hàng</td></tr>";
                        strDetailShipper += "<tr><td width='120' height='5'></td><td></td></tr>";
                        strDetailShipper += "<tr class='bgtr1'><td class='td1'>Người giao hàng</td>";
                        strDetailShipper += "<td>" + OrderDetail.Tables[0].Rows[0]["shippername"].ToString() + "</td></tr>";
                        Boolean isround = false;
                        if (OrderDetail.Tables[0].Rows[0]["company"].ToString().Length > 0)
                        {
                            if (isround)
                            {
                                strDetailShipper += "<tr class='bgtr1'>";
                                isround = false;
                            }
                            else
                            {
                                strDetailShipper += "<tr class='bgtr2'>";
                                isround = true;
                            }
                            strDetailShipper += "<td class='td1'>Công ty:</td>";
                            strDetailShipper += "<td>" + OrderDetail.Tables[0].Rows[0]["company"].ToString() + "</td></tr>";
                        }
                        string shipperphonemobile = OrderDetail.Tables[0].Rows[0]["Mobilephone"].ToString();
                        string shipperphoneoffice = OrderDetail.Tables[0].Rows[0]["Homephone"].ToString();
                        if (shipperphonemobile.Length > 0 || shipperphoneoffice.Length > 0)
                        {
                            if (isround)
                            {
                                strDetailShipper += "<tr class='bgtr1'>";
                                isround = false;
                            }
                            else
                            {
                                strDetailShipper += "<tr class='bgtr2'>";
                                isround = true;
                            }
                            strDetailShipper += "<td class='td1'>Điện thoại</td>";
                            if (shipperphonemobile.Length > 0)
                            {
                                if (shipperphoneoffice.Length > 0)
                                {
                                    shipperphonemobile += ", " + shipperphoneoffice;
                                }
                            }
                            else
                            {
                                shipperphonemobile = shipperphoneoffice;
                            }
                            strDetailShipper += "<td>" + shipperphonemobile + "</td></tr>";
                        }
                        if (OrderDetail.Tables[0].Rows[0]["addressship"].ToString().Length > 0)
                        {
                            if (isround)
                            {
                                strDetailShipper += "<tr class='bgtr1'>";
                                isround = false;
                            }
                            else
                            {
                                strDetailShipper += "<tr class='bgtr2'>";
                                isround = true;
                            }
                            strDetailShipper += "<td class='td1'>Địa chỉ:</td>";
                            strDetailShipper += "<td>" + OrderDetail.Tables[0].Rows[0]["addressship"].ToString() + " " + OrderDetail.Tables[0].Rows[0]["city"].ToString() + "</td></tr>";
                        }
                        if (OrderDetail.Tables[0].Rows[0]["email1"].ToString().Length > 0)
                        {
                            if (isround)
                            {
                                strDetailShipper += "<tr class='bgtr1'>";
                                isround = false;
                            }
                            else
                            {
                                strDetailShipper += "<tr class='bgtr2'>";
                                isround = true;
                            }
                            strDetailShipper += "<td class='td1'>Email:</td>";
                            strDetailShipper += "<td>" + OrderDetail.Tables[0].Rows[0]["email1"].ToString() + "</td></tr>";
                        }
                        strDetailShipper += "</table>";
                    }
                    //DetailOrder:
                }
                else
                {
                    Response.Redirect("Default.aspx?menu=manageorder");
                }
            }
        }
        catch
        {
            Response.Redirect("Default.aspx?menu=manageorder");
        }
    }
}
