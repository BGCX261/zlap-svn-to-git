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
public partial class block_ComparePro : System.Web.UI.UserControl
{
    public string tblcompare = "So sánh máy tính xách tay";
    public string strInfoPro = "";
    public string selectBrand = "";
    public string strComponent = "";
    public string timage = "";
    public string tname = "Tên sản phẩm";
    public string tbrand = "Nhãn hiệu";
    public string twarehouse = "Nơi bán";
    public string tunit = "$";
    public string tmonth = "Tháng";
    public string tprice = "Giá";
    public string twarranty = "bảo hành";
    public string tnote = "mô tả";
    public string tnothave = "Hết hàng";
    public string timeShow = "";
    public string tspecification = "Thông tin chi tiết";
    public string idcompare1 = "";
    public string idcompare2 = "";
    public string tback = "Quay lại";
    public string currentAccess = "";
    string thome = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            tunit = Application["currency"].ToString();
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            currentAccess = hash["currentpage"].ToString();
            thome = hash["home"].ToString();
            tblcompare = hash["blcompare"].ToString();
            tbrand = hash["brand"].ToString();
            tname = hash["name"].ToString();
            twarehouse = hash["warehouse"].ToString();
            tprice = hash["tprice"].ToString();
            twarranty = hash["twarranty"].ToString();
            tmonth = hash["tmonth"].ToString();
            tnote = hash["des"].ToString();
            tnothave = hash["outstore"].ToString();
            tspecification =hash["specification"].ToString();
            tback = hash["bback"].ToString();
            currentAccess += ": <a href='default.html?menu=home'>" + thome + "</a> &raquo; " + tblcompare;
        }
        catch
        { }
        try
        {
            string[] arrId = new string[] {"0"};
            if (Request.QueryString["id"] != null)
            {
                arrId = Request.QueryString["id"].ToString().Split(',');
            }
            int id1 = 0;
            int id2 = 0;
            if (arrId.Length > 1)
            {
                id1 = int.Parse(arrId[0]);
                id2 = int.Parse(arrId[1]);
            }
            else
            {
                id1 = id2 = int.Parse(arrId[0]);
            }
            idcompare1 = id1.ToString();
            idcompare2 = id2.ToString();
            ProductSystem Products = new ProductSystem();
            DataSet DetailPro = Products.ProductSelectForCompare(id1, id2, int.Parse(Application["idtypeproduct"].ToString()));
            float rate = (float)Application["ratepromain"];
            float price1 = 1;
            string price11 = "0";
            string price12 = "0";
            if (DetailPro.Tables.Count > 0)
            { 
                //Information product:
                if ((DetailPro.Tables[0].Rows.Count > 0) && (DetailPro.Tables[4].Rows.Count > 0))
                {
                    selectBrand = GetSelectBrand(DetailPro.Tables[8], DetailPro.Tables[0].Rows[0]["idbrand"].ToString(), DetailPro.Tables[4].Rows[0]["idbrand"].ToString());
                    strInfoPro = "<table border='0' cellspacing='0' cellpadding='2' width='100%'>";
                    string img1 = DetailPro.Tables[0].Rows[0]["UrlImage"].ToString();
                    string img2 = DetailPro.Tables[4].Rows[0]["UrlImage"].ToString();
                    price1 = float.Parse(DetailPro.Tables[0].Rows[0]["SellingPrice"].ToString());
                    price1 = price1 * rate;
                    price11 = price1.ToString("N").Split('.')[0];
                    price1 = float.Parse(DetailPro.Tables[4].Rows[0]["SellingPrice"].ToString());
                    price1 = price1 * rate;
                    price12 = price1.ToString("N").Split('.')[0];
                    string where1 = "";
                    string where2 = "";
                    string namepro1 = "";
                    string namepro2 = "";

                    namepro1 = DetailPro.Tables[0].Rows[0]["Name"].ToString();
                    namepro2 = DetailPro.Tables[4].Rows[0]["Name"].ToString();

                    namepro1 = namepro1.Replace("/", "");
                    namepro1 = namepro1.Replace(":", "");
                    namepro1 = namepro1.Replace("#", "");

                    namepro2 = namepro2.Replace("/", "");
                    namepro2 = namepro2.Replace(":", "");
                    namepro2 = namepro2.Replace("#", "");
                    int num = DetailPro.Tables[1].Rows.Count;
                    for (int i = 0; i < num; i++)
                    {
                        where1 += "* " + DetailPro.Tables[1].Rows[i]["address"].ToString() + "<br />";
                    }
                    num = DetailPro.Tables[5].Rows.Count;
                    for (int i = 0; i < num; i++)
                    {
                        where2 += "* " + DetailPro.Tables[5].Rows[i]["address"].ToString() + "<br />";
                    }
                    if (where1.Length == 0)
                    {
                        where1 = tnothave;
                    }
                    if (where2.Length == 0)
                    {
                        where2 = tnothave;
                    }
                    if (img1.Length > 0)
                    {
                        img1 = "<img src='image/img_pro/" + img1 + "' width='155' height='132' border='0'/>";
                    }
                    else
                    {
                        img1 = "<img src='image/common/notimgpro.png' width='155' height='132' border='0'/>";
                    }
                    if (img2.Length > 0)
                    {
                        img2 = "<img src='image/img_pro/" + img2 + "' width='155' height='132' border='0'/>";
                    }
                    else
                    {
                        img2 = "<img src='image/common/notimgpro.png' width='155' height='132' border='0'/>";
                    }
                    strInfoPro += "<tr><td></td>";
                    strInfoPro += "<td align='center'><a href='" + namepro1 + "-dp-" + id1 + ".html'>" + img1 + "</a></td>";
                    strInfoPro += "<td class='btd1' width='5'></td>";
                    strInfoPro += "<td align='center'><a href='" + namepro2 + "-dp-" + id2 + ".html'>" + img2 + "</a></td></tr>";
                    strInfoPro += "<tr><td colspan='4' class='bg_line2'></td></tr>";
                    strInfoPro += "<tr><td>" + tname + "</td><td class='text_title'><a href='" + namepro1 + "-dp-" + id1 + ".html'>" + DetailPro.Tables[0].Rows[0]["Name"].ToString() + "</a></td><td class='btd1'></td><td class='text_title'><a href='" + namepro2 + "-dp-" + id2 + ".html'>" + DetailPro.Tables[4].Rows[0]["Name"].ToString() + "</a></td></tr>";
                    strInfoPro += "<tr><td colspan='4' class='bg_line2'></td></tr>";
                    strInfoPro += "<tr><td>" + tbrand + "</td><td class='price'>" + DetailPro.Tables[0].Rows[0]["Brand"].ToString() + "</td><td class='btd1'></td><td class='price'>" + DetailPro.Tables[4].Rows[0]["Brand"].ToString() + "</td></tr>";
                    strInfoPro += "<tr><td colspan='4' class='bg_line2'></td></tr>";
                    strInfoPro += "<tr><td>" + twarehouse + "</td><td>" + where1 + "</td><td class='btd1'></td><td>" + where2 + "</td></tr>";
                    strInfoPro += "<tr><td colspan='4' class='bg_line2'></td></tr>";
                    if (tunit.Equals("$") || tunit.Equals("$$"))
                    {
                        tunit = "VND";
                    }
                    strInfoPro += "<tr><td>" + tprice + "</td><td class='price'>" + price11 + " " + tunit + "</td><td class='btd1'></td><td class='price'>" + price12 + " " + tunit + "</td></tr>";
                    strInfoPro += "<tr><td colspan='4' class='bg_line2'></td></tr>";
                    strInfoPro += "<tr><td>" + twarranty + "</td><td class='price'>" + DetailPro.Tables[0].Rows[0]["WarrantyMonth"].ToString() + " " + tmonth + "</td><td class='btd1'></td><td class='price'>" + DetailPro.Tables[4].Rows[0]["WarrantyMonth"].ToString() + " " + tmonth + "</td></tr>";
                    strInfoPro += "<tr><td colspan='4' class='bg_line2'></td></tr>";
                    strInfoPro += "<tr><td width='111'>" + tnote + "</td><td width='225'>" + DetailPro.Tables[0].Rows[0]["Note"].ToString() + "</td><td class='btd1' width='5'></td><td width='225'>" + DetailPro.Tables[4].Rows[0]["Note"].ToString() + "</td></tr>";
                    strInfoPro += "<tr><td colspan='4' class='bg_line2'></td></tr>";
                    strInfoPro += "</table>";
                    strComponent = GetComponentPro(DetailPro.Tables[2], DetailPro.Tables[3], DetailPro.Tables[6], DetailPro.Tables[7]);
                }
                else
                {
                    Response.Redirect("default.html?menu=home");
                }
            }
            
        }
        catch
        {
            Response.Redirect("default.html?menu=home");
        }
    }
    public string GetSelectBrand(DataTable table,string idbrand1,string idbrand2)
    {
        int numselect = table.Rows.Count;
        string select1 = "";
        string select2 = "";
        string str = "";
        try
        {
            str = "<table border='0' cellspacing='1' cellpadding='0' width='100%'>";
            str += "<tr><td width='111' height='30'>" + tbrand + "</td>";
            for (int i = 0; i < numselect; i++)
            {
                if (table.Rows[i]["id"].ToString().Equals(idbrand1))
                {
                    select1 += "<option value='" + table.Rows[i]["id"].ToString() + "' selected='selected'>" + table.Rows[i]["name"].ToString() + "</option>";
                }
                else
                {
                    select1 += "<option value='" + table.Rows[i]["id"].ToString() + "'>" + table.Rows[i]["name"].ToString() + "</option>";
                }
                if (table.Rows[i]["id"].ToString().Equals(idbrand2))
                {
                    select2 += "<option value='" + table.Rows[i]["id"].ToString() + "' selected='selected'>" + table.Rows[i]["name"].ToString() + "</option>";
                }
                else
                {
                    select2 += "<option value='" + table.Rows[i]["id"].ToString() + "'>" + table.Rows[i]["name"].ToString() + "</option>";
                }
            }
            str += "<td><select class='text_box2' id='slBrand1' onchange='ChangeBrand(this,1);'>" + select1 + "</select></td>";
            str += "<td class='btd1' width='5'></td>";
            str += "<td><select class='text_box2' id='slBrand2' onchange='ChangeBrand(this,2);'>" + select2 + "</select></td></tr>";
            str += "<tr><td colspan='4' class='bg_line2'></td></tr>";
            str += "<tr><td width='110' height='30'>" + tname + "</td>";
            str += "<td><div id='divslName1'>" + idbrand1 + "</div></td>";
            str += "<td class='btd1' width='5'></td>";
            str += "<td><div id='divslName2'>" + idbrand2 + "</div></td></tr>";
            str += "<tr><td colspan='4' class='bg_line2'></td></tr>";
        }
        catch
        { }
        return str;
    }
    public string GetComponentPro(DataTable table1, DataTable table2,DataTable table3,DataTable table4)
    {
        string str = "";
        try
        {
            int numcom1 = table1.Rows.Count;
            int numpro1 = table2.Rows.Count;
            int numcom2 = table3.Rows.Count;
            int numpro2 = table4.Rows.Count;
            ArrayList listName = new ArrayList();
            Hashtable hash = new Hashtable();
            Hashtable hash2 = new Hashtable();
            string value="";
            if ((numcom1 >= numcom2) && numcom1 > 0)
            {
                for (int i = 0; i < numcom1; i++)
                {
                    if (i < numcom2)
                    {
                        if (hash[table1.Rows[i]["name"].ToString()] == null)
                        {
                            value = table1.Rows[i]["component"].ToString();
                            if (table1.Rows[i]["propertyvalue"].ToString().Length>0)
                            {
                                value += ", " + table1.Rows[i]["propertyvalue"].ToString() + " " + table1.Rows[i]["unit"].ToString();
                            }
                            hash.Add(table1.Rows[i]["name"].ToString(), value);
                            listName.Add(table1.Rows[i]["name"].ToString());
                        }
                        else
                        {
                            value = hash[table1.Rows[i]["name"].ToString()].ToString();
                            if (table1.Rows[i]["propertyvalue"].ToString().Length > 0)
                            {
                                if (table1.Rows[i]["unit"].ToString().Length > 0)
                                {
                                    value += ", " + table1.Rows[i]["propertyvalue"].ToString() + " " + table1.Rows[i]["unit"].ToString();
                                }
                                else
                                {
                                    value += ", " + table1.Rows[i]["propertyvalue"].ToString();
                                }
                            }
                            hash[table1.Rows[i]["name"].ToString()] = value;
                        }
                        if (hash[table3.Rows[i]["name"].ToString()] == null)
                        {
                            hash.Add(table3.Rows[i]["name"].ToString(), "");
                            listName.Add(table3.Rows[i]["name"].ToString());
                        }
                        if(hash2[table3.Rows[i]["name"].ToString()] == null)
                        {
                            value = table3.Rows[i]["component"].ToString();
                            if (table3.Rows[i]["propertyvalue"].ToString().Length > 0)
                            {
                                value += ", " + table3.Rows[i]["propertyvalue"].ToString() + " " + table3.Rows[i]["unit"].ToString();
                            }
                            hash2.Add(table3.Rows[i]["name"].ToString(), value);
                        }
                        else
                        {
                            value = hash2[table3.Rows[i]["name"].ToString()].ToString();
                            if (table3.Rows[i]["propertyvalue"].ToString().Length > 0)
                            {
                                if (table3.Rows[i]["unit"].ToString().Length > 0)
                                {
                                    value += ", " + table3.Rows[i]["propertyvalue"].ToString() + " " + table3.Rows[i]["unit"].ToString();
                                }
                                else
                                {
                                    value += ", " + table3.Rows[i]["propertyvalue"].ToString();
                                }
                            }
                            hash2[table3.Rows[i]["name"].ToString()] = value;
                        }
                    }
                    else
                    {
                        if (hash[table1.Rows[i]["name"].ToString()] == null)
                        {
                            value = table1.Rows[i]["component"].ToString();
                            if (table1.Rows[i]["propertyvalue"].ToString().Length > 0)
                            {
                                value += ", " + table1.Rows[i]["propertyvalue"].ToString() + " " + table1.Rows[i]["unit"].ToString();
                            }
                            hash.Add(table1.Rows[i]["name"].ToString(), value);
                            listName.Add(table1.Rows[i]["name"].ToString());
                        }
                        else
                        {
                            value = hash[table1.Rows[i]["name"].ToString()].ToString();
                            if (table1.Rows[i]["propertyvalue"].ToString().Length > 0)
                            {
                                if (table1.Rows[i]["unit"].ToString().Length > 0)
                                {
                                    value += ", " + table1.Rows[i]["propertyvalue"].ToString() + " " + table1.Rows[i]["unit"].ToString();
                                }
                                else
                                {
                                    value += ", " + table1.Rows[i]["propertyvalue"].ToString();
                                }
                            }
                            hash[table1.Rows[i]["name"].ToString()] = value;
                        }
                    }
                }
            }
            else if (numcom2 > 0)
            {
                for (int i = 0; i < numcom2; i++)
                {
                    if (i < numcom1)
                    {
                        if (hash[table1.Rows[i]["name"].ToString()] == null)
                        {
                            value = table1.Rows[i]["component"].ToString();
                            if (table1.Rows[i]["propertyvalue"].ToString().Length > 0)
                            {
                                value += ", " + table1.Rows[i]["propertyvalue"].ToString() + " " + table1.Rows[i]["unit"].ToString();
                            }
                            hash.Add(table1.Rows[i]["name"].ToString(), value);
                            listName.Add(table1.Rows[i]["name"].ToString());
                        }
                        else
                        {
                            value = hash[table1.Rows[i]["name"].ToString()].ToString();
                            if (table1.Rows[i]["propertyvalue"].ToString().Length > 0)
                            {
                                if (table1.Rows[i]["unit"].ToString().Length > 0)
                                {
                                    value += ", " + table1.Rows[i]["propertyvalue"].ToString() + " " + table1.Rows[i]["unit"].ToString();
                                }
                                else
                                {
                                    value += ", " + table1.Rows[i]["propertyvalue"].ToString();
                                }
                            }
                            hash[table1.Rows[i]["name"].ToString()] = value;
                        }
                        if (hash[table3.Rows[i]["name"].ToString()] == null)
                        {
                            hash.Add(table3.Rows[i]["name"].ToString(), "");
                            listName.Add(table3.Rows[i]["name"].ToString());
                        }
                        if (hash2[table3.Rows[i]["name"].ToString()] == null)
                        {
                            value = table3.Rows[i]["component"].ToString();
                            if (table3.Rows[i]["propertyvalue"].ToString().Length > 0)
                            {
                                value += ", " + table3.Rows[i]["propertyvalue"].ToString() + " " + table3.Rows[i]["unit"].ToString();
                            }
                            hash2.Add(table3.Rows[i]["name"].ToString(), value);
                        }
                        else
                        {
                            value = hash2[table3.Rows[i]["name"].ToString()].ToString();
                            if (table3.Rows[i]["propertyvalue"].ToString().Length > 0)
                            {
                                if (table3.Rows[i]["unit"].ToString().Length > 0)
                                {
                                    value += ", " + table3.Rows[i]["propertyvalue"].ToString() + " " + table3.Rows[i]["unit"].ToString();
                                }
                                else
                                {
                                    value += ", " + table3.Rows[i]["propertyvalue"].ToString();
                                }
                            }
                            hash2[table3.Rows[i]["name"].ToString()] = value;
                        }
                    }
                    else
                    {
                        if( hash[table3.Rows[i]["name"].ToString()]==null)
                        {
                            hash.Add(table3.Rows[i]["name"].ToString(), "");
                            listName.Add(table3.Rows[i]["name"].ToString());
                        }
                        if (hash2[table3.Rows[i]["name"].ToString()] == null)
                        {
                            value = table3.Rows[i]["component"].ToString();
                            if (table3.Rows[i]["propertyvalue"].ToString().Length > 0)
                            {
                                value += ", " + table3.Rows[i]["propertyvalue"].ToString() + " " + table3.Rows[i]["unit"].ToString();
                            }
                            hash2.Add(table3.Rows[i]["name"].ToString(), value);
                            listName.Add(table3.Rows[i]["name"].ToString());
                        }
                        else
                        {
                            value = hash2[table3.Rows[i]["name"].ToString()].ToString();
                            if (table3.Rows[i]["propertyvalue"].ToString().Length > 0)
                            {
                                if (table3.Rows[i]["unit"].ToString().Length > 0)
                                {
                                    value += ", " + table3.Rows[i]["propertyvalue"].ToString() + " " + table3.Rows[i]["unit"].ToString();
                                }
                                else
                                {
                                    value += ", " + table3.Rows[i]["propertyvalue"].ToString();
                                }
                            }
                            hash2[table3.Rows[i]["name"].ToString()] = value;
                        }
                    }
                }
            }
            if ((numpro1 >= numpro2) && numpro1 > 0)
            {
                for (int i = 0; i < numpro1; i++)
                {
                    if (i < numpro2)
                    {
                        try
                        {
                            hash.Add(table2.Rows[i]["name"].ToString(), table2.Rows[i]["PropertyValue"].ToString() + " " + table2.Rows[i]["Unit"].ToString());
                            listName.Add(table2.Rows[i]["name"].ToString());
                        }
                        catch
                        {
                            value = hash[table2.Rows[i]["name"].ToString()].ToString();
                            value += table2.Rows[i]["PropertyValue"].ToString() + " " + table2.Rows[i]["Unit"].ToString();
                            hash[table2.Rows[i]["name"].ToString()] = value;
                        }
                        try
                        {
                            hash.Add(table4.Rows[i]["name"].ToString(), "");
                            listName.Add(table4.Rows[i]["name"].ToString());
                        }
                        catch
                        { 
                            
                        }
                        try
                        {
                            hash2.Add(table4.Rows[i]["name"].ToString(), table4.Rows[i]["PropertyValue"].ToString() + " " + table4.Rows[i]["Unit"].ToString());
                        }
                        catch
                        {
                            value = hash2[table4.Rows[i]["name"].ToString()].ToString();
                            value = table4.Rows[i]["PropertyValue"].ToString() + " " + table4.Rows[i]["Unit"].ToString() + ", " + value;
                            hash2[table4.Rows[i]["name"].ToString()] = value;
                        }
                    }
                    else
                    {
                        try
                        {
                            hash.Add(table2.Rows[i]["name"].ToString(), table2.Rows[i]["PropertyValue"].ToString() + " " + table2.Rows[i]["Unit"].ToString());
                            listName.Add(table2.Rows[i]["name"].ToString());
                        }
                        catch
                        {
                            value = hash[table2.Rows[i]["name"].ToString()].ToString();
                            value = table2.Rows[i]["PropertyValue"].ToString() + " " + table2.Rows[i]["Unit"].ToString() + ", " + value;
                            hash[table2.Rows[i]["name"].ToString()] = value;
                        }
                    }
                }
            }
            else if (numpro2 > 0)
            {
                for (int i = 0; i < numpro2; i++)
                {
                    if (i < numpro1)
                    {
                        try
                        {
                            hash.Add(table2.Rows[i]["name"].ToString(), table2.Rows[i]["PropertyValue"].ToString() + " " + table2.Rows[i]["Unit"].ToString());
                            listName.Add(table2.Rows[i]["name"].ToString());
                        }
                        catch
                        {
                            value = hash[table2.Rows[i]["name"].ToString()].ToString();
                            value = table2.Rows[i]["PropertyValue"].ToString() + " " + table2.Rows[i]["Unit"].ToString() + ", " + value;
                            hash[table2.Rows[i]["name"].ToString()] = value;
                        }
                        try
                        {
                            hash.Add(table4.Rows[i]["name"].ToString(), "");
                            listName.Add(table4.Rows[i]["name"].ToString());
                        }
                        catch
                        {

                        }
                        try
                        {
                            hash2.Add(table4.Rows[i]["name"].ToString(), table4.Rows[i]["PropertyValue"].ToString() + " " + table4.Rows[i]["Unit"].ToString());
                        }
                        catch
                        {
                            value = hash2[table4.Rows[i]["name"].ToString()].ToString();
                            value = table4.Rows[i]["PropertyValue"].ToString() + " " + table4.Rows[i]["Unit"].ToString() + ", " + value;
                            hash2[table4.Rows[i]["name"].ToString()] = value;
                        }
                    }
                    else
                    {
                        try
                        {
                            hash.Add(table4.Rows[i]["name"].ToString(), "");
                            listName.Add(table4.Rows[i]["name"].ToString());
                        }
                        catch
                        {

                        }
                        try
                        {
                            hash2.Add(table4.Rows[i]["name"].ToString(), table4.Rows[i]["PropertyValue"].ToString() + " " + table4.Rows[i]["Unit"].ToString());
                        }
                        catch
                        {
                            value = hash2[table4.Rows[i]["name"].ToString()].ToString();
                            value = table4.Rows[i]["PropertyValue"].ToString() + " " + table4.Rows[i]["Unit"].ToString() + ", " + value;
                            hash2[table4.Rows[i]["name"].ToString()] = value;
                        }
                    }
                }
            }
            numcom1 = listName.Count;
            if (numcom1 > 0)
            {
                str = "<table border='0' cellpadding='0' cellspacing='0' width='100%'>";
                str += "<tr><td colspan='4' class='title_1'>" + tspecification + "</td></tr>";
                str += "<tr height='3'><td width='111'></td><td width='225'></td><td width='5'></td><td width='225'></td></tr>";
                Boolean isround = true;
                for (int i = 0; i < numcom1; i++)
                {
                    //char[] split='<@>';
                    string[] arrvalue = new string[2] {"",""};
                    if (hash[listName[i].ToString()] != null)
                    {
                        arrvalue[0] = hash[listName[i].ToString()].ToString();
                    }
                    if (hash2[listName[i].ToString()] != null)
                    {
                        arrvalue[1] = hash2[listName[i].ToString()].ToString();
                    }
                    if (isround)
                    {
                        isround = false;
                        str += "<tr class='bgtr1'><td class='td1' style='width:111px;padding-left:0px;'>" + listName[i].ToString() + "</td><td width='225'>" + arrvalue[0] + "</td><td class='btd1'></td><td width='225'>" + arrvalue[1] + "</td></tr>";
                    }
                    else
                    {
                        isround = true;
                        str += "<tr class='bgtr2'><td class='td1' style='width:111px;padding-left:0px;'>" + listName[i].ToString() + "</td><td width='225'>" + arrvalue[0] + "</td><td class='btd1'></td><td width='225'>" + arrvalue[1] + "</td></tr>";
                    }
                }
                str += "<tr><td colspan='4' class='bg_line2'></td></tr>";
                str += "</table>";
            }
        }
        catch
        { }
        return str;
    }
}
