using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using facade.list;
using common.list;
public partial class block_brandproduct : System.Web.UI.UserControl
{
    public string tablebrand = "";
    //public string strphanphoi = "Hàng phân phối của hãng";
    //public string strnhapkhau = "Hàng nhập khẩu";
    protected void Page_Load(object sender, EventArgs e)
    {
        tablebrand = ListBrand();
    }
    public string ListBrand()
    {
        string bl_brand = "";
        string seeAll = "";
        string listbrand = "";
        string strreturn = "";
        try
        {
            Hashtable hashLang = (Hashtable)Application[Session["langcurrent"].ToString()];
            bl_brand = hashLang["blbrand"].ToString();
            seeAll = hashLang["sapro"].ToString();
        }
        catch (Exception ex)
        {
            Console.Write(ex.ToString());
        }
        if (Application["listBrandPro"] == null)
        {
            string arrBrand = "";
            //Read brand:
            BrandProduct_data ds = new BrandProductSystem().BrandProAllType((int)Application["idtypeproduct"]);
            DataTable table = ds.Tables[BrandProduct_data._table];
            int numBrand = table.Rows.Count;
            for (int i = 0; i < numBrand; i++)
            {
                string id = table.Rows[i][BrandProduct_data._id].ToString();
                string name = table.Rows[i][BrandProduct_data._name].ToString();
                arrBrand += "<a href='default.html?menu=pro&brand=" + id + "' onmouseover='OnMOMenu(" + id + "," + i + ",10,event);' onmouseout='TimeHidden();'>" + name + "</a><br />";
            }
            if (arrBrand.Length > 3)
            {
                Application["listBrandPro"] = arrBrand;
            }
            //listbrand = "<a href='default.html?menu=dasp&state=6'>" + strphanphoi + "</a><br />";
            //listbrand += "<a href='default.html?menu=dasp&state=1,2,3,5'>" + strnhapkhau + "</a><br />";
            listbrand += "<a href='default.html?menu=product'>" + seeAll + "</a><br />" + arrBrand;
        }
        else
        {
            //listbrand = "<a href='default.html?menu=dasp&state=6'>" + strphanphoi + "</a><br />";
            //listbrand += "<a href='default.html?menu=dasp&state=1,2,3,5'>" + strnhapkhau + "</a><br />";
            listbrand += "<a href='default.html?menu=product'>" + seeAll + "</a><br />";
            if (Application["listBrandPro"] != null)
            {
                listbrand += Application["listBrandPro"].ToString();
            }
        }
        strreturn = "<table width='100%' cellpadding='0' cellspacing='0'>";
        strreturn += "<tr><td class='bg_b1'></td><td class='bg_b2'><div class='text_bl'>" + bl_brand + "</div></td><td class='bg_b3'></td></tr>";
        strreturn += "<tr><td class='bg_b4'></td><td class='text_2'>" + listbrand + "</td><td class='bg_b5'></td></tr>";
        strreturn += "<tr><td class='bg_b7' colspan='3'></td></tr>";
        strreturn += "<tr><td height='8'></td></tr></table>";
        return strreturn;
    }
}
