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
        if (Application["listBrandMobile"] == null)
        {
            string arrBrand = "";
            //Read brand:
            BrandProduct_data ds = new BrandProductSystem().BrandProAllType((int)Application["idtypemobile"]);
            DataTable table = ds.Tables[BrandProduct_data._table];
            int numBrand = table.Rows.Count;
            for (int i = 0; i < numBrand; i++)
            {
                string id = table.Rows[i][BrandProduct_data._id].ToString();
                string name = table.Rows[i][BrandProduct_data._name].ToString();
                arrBrand += "<a href='?menu=pro&brand=" + id + "'>- " + name + "</a><br />";
            }
            if (arrBrand.Length > 3)
            {
                Application["listBrandMobile"] = arrBrand;
            }
            listbrand = "<a href='?menu=product'>- " + seeAll + "</a><br />" + arrBrand;
        }
        else
        {
            listbrand = "<a href='?menu=product'>- " + seeAll + "</a><br />";
            if (Application["listBrandMobile"] != null)
            {
                listbrand += Application["listBrandMobile"].ToString();
            }
        }
        strreturn = "<table width='100%' cellpadding='0' cellspacing='0'>";
        strreturn += "<tr><td class='bgtl1'></td><td class='bgtc1' width='145'>" + bl_brand + "</td><td class='bgtr1'></td></tr>";
        strreturn += "<tr><td height='2'></td></tr>";
        strreturn += "<tr><td colspan='3' width='175' class='bgcl1'>" + listbrand + "</td></tr>";
        strreturn += "<tr><td height='10'></td></tr></table>";
        return strreturn;
    }
}
