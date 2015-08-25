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
using framework.list.bean;
using facade.list;
public partial class block_DetailCart : System.Web.UI.UserControl
{
    public string blCart = "Thông tin giỏ hàng";
    public string tinfopro = "sản phẩm";
    public string tnumber = "Số lượng";
    public string tTatal = "Tổng";
    public string tCurrentcy = "";
    public string tablePro = "";
    public string numberincart = "0";
    public string tprice = "Giá bán";
    public string twarranty = "Bảo hành";
    public string tmonth = "Tháng";
    public ProInCart proIncart = new ProInCart();
    public ManagerProcart ManagerCart = new ManagerProcart();
    public string currentAccess = "";
    string thome = "";
    public string nohave = "";
    public string bupdate = "";
    public string bcon = "";
    public string torder = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ProductInCart"] != null)
        {
            ManagerCart = (ManagerProcart)Session["ProductInCart"];
            numberincart = ManagerCart.getLengList().ToString();
        }
        try
        {
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            currentAccess = hash["currentpage"].ToString();
            thome = hash["home"].ToString();
            blCart = hash["blcart"].ToString();
            nohave = hash["mnothave"].ToString();
            tnumber = hash["mnumber"].ToString();
            tTatal = hash["mtotal"].ToString();
            twarranty=hash["twarranty"].ToString();
            tmonth = hash["tmonth"].ToString();
            tprice = hash["tprice"].ToString();
            tinfopro = hash["tinfop"].ToString();
            bcon = hash["bcon"].ToString();
            bupdate = hash["bupdate"].ToString();
            btUpdate.Value = bupdate;
            torder = hash["torder"].ToString();
            currentAccess += ": <a href='?menu=home'>" + thome + "</a> &raquo; " + blCart;
        }
        catch
        { }
        if (!IsPostBack)
        {
            tablePro = ShowCart();
            if (numberincart.Equals("0"))
            {
                divbutton.Visible = false;
            }
        }
    }
    public string ShowCart()
    {
        string str = "";
        int numPro=ManagerCart.getLengList();
        if (numPro > 0)
        {
            str="<table border='0' cellpadding='0' cellspacing='0' width='100%'>";
            string url = "";
            string subsrt = "";
            for (int i = 0; i < numPro; i++)
            {
                proIncart = (ProInCart)ManagerCart.GetProIndex(i);
                tCurrentcy = proIncart.currency;
                url = proIncart.urlImage;
                if (url.Length > 0)
                {
                    if (proIncart.type == 1 || proIncart.type == 3 || proIncart.type == 4)
                    {
                        url = "image/img_pro/" + url;
                    }
                    else if (proIncart.type == 2)
                    {
                        url = "image/img_com/" + url;
                    }
                }
                else
                {
                    url = "image/common/notimgpro.png";
                }
                subsrt = "<span class='text_title'>";
                if (proIncart.type == 1)
                {
                    subsrt += "<a href='?menu=dp&id=" + proIncart.id.ToString() + "' class='text_title'>";
                }
                else if (proIncart.type == 3)
                {
                    subsrt += "<a href='?menu=dpda&id=" + proIncart.id.ToString() + "' class='text_title'>";
                }
                else if (proIncart.type == 4)
                {
                    subsrt += "<a href='?menu=dother&id=" + proIncart.id.ToString() + "' class='text_title'>";
                }
                else if (proIncart.type == 2)
                {
                    subsrt += "<a href='?menu=dc&id=" + proIncart.id.ToString() + "' class='text_title'>";
                }
                subsrt += proIncart.name + "</a></span><br />";
                subsrt += tprice + ": <span class='price'>" + proIncart.PriceStandard() + " VND</span><br />";
                subsrt += twarranty + ": <span class='price'>" + proIncart.warranty.ToString() + " " + tmonth + "</span>";
                str += "<tr>";
                str += "<td  width='110'>";
                str += "<img src='" + url + "' width='76' height='65' />";
                str += "</td>";
                str += "<td valign='top' align='left' width='220'>" + subsrt + "</td>";
                str += "<td width='80' align='center'><input class='tnumber' type='text' id='procart"+ i.ToString() +"' value='" + proIncart.number.ToString() + "' maxlength='3' /></td>";
                str += "<td width='80' align='center' class='price'>" + proIncart.ValueTotal() + "</td>";
                if (proIncart.type == 1)
                {
                    str += "<td align='center'><img src='image/common/icon_delete.bmp' class='idelete' onclick='AddCart(" + proIncart.id.ToString() + ",11);'/></td>";
                }
                else if (proIncart.type == 3)
                {
                    str += "<td align='center'><img src='image/common/icon_delete.bmp' class='idelete' onclick='AddCart(" + proIncart.id.ToString() + ",13);'/></td>";
                }
                else if (proIncart.type == 4)
                {
                    str += "<td align='center'><img src='image/common/icon_delete.bmp' class='idelete' onclick='AddCart(" + proIncart.id.ToString() + ",14);'/></td>";
                }
                else if (proIncart.type == 2)
                {
                    str += "<td align='center'><img src='image/common/icon_delete.bmp' class='idelete' onclick='AddCart(" + proIncart.id.ToString() + ",12);'/></td>";
                }
                str += "</tr>";
                if (i < numPro - 1)
                {
                    str += "<tr><td colspan='5' class='bg_line3'></td></tr>";
                }
            }
            str += "<tr class='text_b2'><td width='110'></td><td valign='top' align='left' width='220'></td>";
            str += "<td width='80' align='center'>" + ManagerCart.GetNumBerPro().ToString() + "</td>";
            str += "<td align='left' class='price' colspan='2'>" + ManagerCart.TotalCostVND().ToString("N") + " (VND)</td>";
            str += "</tr>";
            str += "</table>";
        }
        else
        {
            str = "<div style='text-align:center;'>" + nohave + "</div>";
        }
        return str;
    }
    protected void btUpdate_ServerClick(object sender, EventArgs e)
    {
        //UPdate
        try
        {
            string objText = Request.Form["hdtext"].ToString();
            if (objText.Length > 0)
            {
                string[] arrvalue = objText.Split(':');
                int numValue = arrvalue.Length;
                numValue--;
                for (int i = 0; i < numValue; i++)
                {
                    ManagerCart.SetNumPro(i, int.Parse(arrvalue[i]));
                }
                Session["ProductInCart"] = ManagerCart;
            }
        }
        catch
        { 
        }
        tablePro = ShowCart();
    }
}
