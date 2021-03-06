﻿using System;
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
using framework.list.dynamicviewhelper;
public partial class block_ComponentInGroup : System.Web.UI.UserControl
{
    public string blpro = "";
    public string strProduct = "";
    public string strpage1 = "";
    public string strpage2 = "";
    public string tprice = "";
    public string torder = "";
    public string tmonth = "";
    public string twarranty = "";
    public string tdisplay = "";
    public string tspage = "";
    public string tlastp = "";
    public string tfirstp = "";
    public string tCurrentAccess = "";
    public string thome = "";
    public string tpro = "";
    public string tcompare = "";
    public string unitPrice = "";
    public string tbrand = "";
    private string strMVAT = "";
    private string tupdate = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            unitPrice = Application["currency"].ToString();
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            blpro = hash["blpro"].ToString();
            tprice = hash["tprice"].ToString();
            twarranty = hash["twarranty"].ToString();
            tmonth = hash["tmonth"].ToString();
            torder = hash["torder"].ToString();
            tCurrentAccess = hash["currentpage"].ToString();
            tcompare = hash["bcompare"].ToString();
            tpro = hash["component"].ToString();
            tfirstp = hash["firstp"].ToString();
            tlastp = hash["lastp"].ToString();
            tdisplay = hash["display"].ToString();
            tspage = hash["spage"].ToString();
            thome = hash["home"].ToString();
            tbrand = hash["brand"].ToString();
            tupdate = hash["tupdate"].ToString();
            strMVAT = hash["msvat"].ToString();

            tCurrentAccess += ": <a href='?menu=home'>" + thome + "</a> &raquo; <a href='?menu=com'>" + tpro + "</a>";
            strProduct = ShowComGroup();
        }
        catch
        {
        }
    }
    public string ShowComGroup()
    {
        CdymanicViewCom ViewProduct;
        int currentpage = 0;
        int size = 20;
        int idgroup = 0;
        string nameGroup = "";
        try
        {
            idgroup = int.Parse(Request.QueryString["id"].ToString());
            currentpage = int.Parse(Request.QueryString["page"].ToString());
            size = int.Parse(Request.QueryString["size"].ToString());
            if (size > 40 || size < 10)
            {
                size = 20;
            }
        }
        catch
        {

        }
        if (Session["SSComponentGroup"] != null)
        {
            ViewProduct = (CdymanicViewCom)Session["SSComponentGroup"];
            ViewProduct.SetPageSize(size);
            if (idgroup != ViewProduct.GetIdGroup())
            {
                ViewProduct.setIdGroup(idgroup);
                ViewProduct.SetNumComGroup();
            }
            if (currentpage > 0)
            {
                ViewProduct.SetCurrentPage(currentpage);
            }
            else
            {
                ViewProduct.SetCurrentPage();
            }
        }
        else
        {
            ViewProduct = new CdymanicViewCom();
            ViewProduct.SetIdType((int)Application["idtypeproduct"]);
            ViewProduct.setIdGroup(idgroup);
            ViewProduct.SetNumComGroup();
            ViewProduct.SetPageSize(size);
            if (currentpage > 0)
            {
                ViewProduct.SetCurrentPage(currentpage);
            }
            else
            {
                ViewProduct.SetCurrentPage();
            }
            Session["SSComponentGroup"] = ViewProduct;
        }
        nameGroup = ViewProduct.GetNameGroup();
        if (nameGroup.Length > 0)
        {
            tCurrentAccess += " &raquo; " + nameGroup;
        }
        blpro = string.Format(blpro, "<u>" + ViewProduct.GetNumberRecord() + "</u>");
        Component_data product = ViewProduct.ComponentGroupFromTo();
        DataTable table = product.Tables[Component_data._table];
        int numPro = table.Rows.Count;
        Boolean iseven = true;
        if (ViewProduct.GetPages() > 1)
        {
            strpage1 = CreatePage(idgroup, ViewProduct.GetCurrentPage(), ViewProduct.GetPages(), ViewProduct.GetPageSize(), 1);
            strpage2 = CreatePage(idgroup, ViewProduct.GetCurrentPage(), ViewProduct.GetPages(), ViewProduct.GetPageSize(), 2);
        }
        else if (ViewProduct.GetPages() == 1)
        {
            strpage1 = ButtonCompare(true);
            strpage2 = ButtonCompare(false);
        }
        string strProMain = "";
        if (numPro > 0)
        {
            strProMain = "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
            strProMain += "<tr height='5'><td colspan='3'></td></tr>";
            string id = "";
            string name = "";
            string url = "";
            string price = "";

            float rate = (float)Application["ratepromain"];
            float price1 = 1;
            string price2 = "";

            string warranty = "";
            string brand="";
            string note="";
            for (int i = 0; i < numPro; i++)
            {
                id = table.Rows[i][Component_data._id].ToString();
                name = table.Rows[i][Component_data._name].ToString();
                url = table.Rows[i][Component_data._urlImage].ToString();
                brand = table.Rows[i][Component_data._brand].ToString();
                note = table.Rows[i][Component_data._note].ToString();
                string namepro = name;
                namepro = namepro.Replace("/", "");
                namepro = namepro.Replace("#", "");
                namepro = namepro.Replace(":", "");
                namepro = namepro.Replace("\"", "");
                if (note.Length > 0)
                {
                    note = note.Replace("\"", "''");
                    note = note.Replace('\r', ' ');
                    note = note.Replace('\n', ' ');
                }
                else
                {
                    note = name;
                }
                if (url.Length > 0)
                {
                    url = "image/img_com/" + url;
                }
                else
                {
                    url = "image/common/notimgpro.png";
                }

                price2 = table.Rows[i][Component_data._sellingPrice].ToString();
                price1 = float.Parse(table.Rows[i][Component_data._sellingPrice].ToString());
                price1 = price1 * rate;
                price = price1.ToString("N").Split('.')[0];

                warranty = table.Rows[i][Component_data._warrantyMonth].ToString();
                if (iseven)
                {
                    strProMain += "<tr><td width='272'>";
                    strProMain += "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
                    strProMain += "<tr><td rowspan='2' width='100'><a href='" + namepro + "-dc-" + id + ".html'><img class='border_img' src='" + url + "'/></a></td>";
                    strProMain += "<td colspan='2' valign='top' class='text_title'><a href='" + namepro + "-dc-" + id + ".html' onmouseover=\"ShowSpeccom('" + note + "',event);\" onmouseout='OnMOut(event)'>" + name + "</a></td></tr>";

                    strProMain += "<tr><td height='70'>" + tbrand + ": <span class='price'>" + brand + "</span><br />";

                    strProMain += tprice + ": <span class='price'>";
                    if (price.Equals("0"))
                    {
                        strProMain += tupdate + "</span><br />";
                    }
                    else
                    {
                        if (unitPrice.Equals("$"))
                        {
                            strProMain += price + " VND</span><br />";
                            strProMain += "<font color='#FFFFFF'>" + tprice + ": </font><span class='price'>" + price2 + "</span><br />";
                        }
                        else if (unitPrice.Equals("$$"))
                        {
                            strProMain += price + " VND</span><br />";
                            strProMain += "<font color='#FFFFFF'>" + tprice + ": </font><span class='price'>" + price2 + " USD</span><br />";
                        }
                        else
                        {
                            strProMain += price + " " + unitPrice + "</span><br />";
                        }
                        strProMain += "<span class='tvat'>" + strMVAT + "</span><br />";
                    }



                    strProMain += twarranty + ": <span class='price'>" + warranty + " " + tmonth + "</span></td>";
                    
                    strProMain += "<td><input type='checkbox' id='c" + id + "' name='cp'/></td></tr>";
                    //strProMain += "<tr><td colspan='3' height='29' align='center'><div class='button3' onclick='AddCart(" + id + ",2);'>" + torder + "</div></td></tr>";
                    strProMain += "</table></td>";
                    iseven = false;
                    if (i + 1 == numPro)
                    {
                        strProMain += "<td class='bg_line4' width='11'></td>";
                        strProMain += "<td width='272'>&nbsp;</td>";
                        strProMain += "</tr>";
                    }
                }
                else
                {
                    strProMain += "<td class='bg_line4' width='11'></td>";
                    strProMain += "<td width='272'>";
                    strProMain += "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
                    strProMain += "<tr><td rowspan='2' width='100'><a href='" + namepro + "-dc-" + id + ".html'><img class='border_img' src='" + url + "'/></a></td>";
                    strProMain += "<td colspan='2' valign='top' class='text_title'><a href='" + namepro + "-dc-" + id + ".html' onmouseover=\"ShowSpeccom('" + note + "',event);\" onmouseout='OnMOut(event)'>" + name + "</a></td></tr>";

                    strProMain += "<tr><td height='70'>" + tbrand + ": <span class='price'>" + brand + "</span><br />";

                    strProMain += tprice + ": <span class='price'>";
                    if (price.Equals("0"))
                    {
                        strProMain += tupdate + "</span><br />";
                    }
                    else
                    {
                        if (unitPrice.Equals("$"))
                        {
                            strProMain += price + " VND</span><br />";
                            strProMain += "<font color='#FFFFFF'>" + tprice + ": </font><span class='price'>" + price2 + "</span><br />";
                        }
                        else if (unitPrice.Equals("$$"))
                        {
                            strProMain += price + " VND</span><br />";
                            strProMain += "<font color='#FFFFFF'>" + tprice + ": </font><span class='price'>" + price2 + " USD</span><br />";
                        }
                        else
                        {
                            strProMain += price + " " + unitPrice + "</span><br />";
                        }
                        strProMain += "<span class='tvat'>" + strMVAT + "</span><br />";
                    }
                    strProMain += twarranty + ": <span class='price'>" + warranty + " " + tmonth + "</span></td>";
                    
                    strProMain += "<td><input type='checkbox' id='c" + id + "' name='cp'/></td></tr>";
                    //strProMain += "<tr><td colspan='3' height='29' align='center'><div class='button3' onclick='AddCart(" + id + ",2);'>" + torder + "</div></td></tr>";
                    strProMain += "</table></td></tr>";
                    if (i + 1 < numPro)
                    {
                        strProMain += "<tr><td class='bg_line3'></td><td></td><td class='bg_line3'></td></tr>";
                    }
                    iseven = true;
                }
            }
            strProMain += "<tr height='5'><td colspan='3'></td></tr>";
            strProMain += "</table>";
        }
        else
        {
            strProMain = "Không có sản phẩm nào.";
        }
        return strProMain;
    }
    public string CreatePage(int idbrand, int current, int pages, int pagesize, int index)
    {
        string str = "";
        string strSelect = "";
        str = "<table border='0' cellpadding='0' cellspacing='0' width='100%' class='bg_page'><tr>";
        if (pagesize == 20)
        {
            strSelect = "<select class='select_num' id='s" + index + "' onchange='PageBrand(this," + idbrand + "," + current.ToString() + ",2);'><option value='20'>20</option><option value='30'>30</option><option value='40'>40</option></select>";
        }
        else if (pagesize == 30)
        {
            strSelect = "<select class='select_num' id='s" + index + "' onchange='PageBrand(this," + idbrand + "," + current.ToString() + ",2);'><option value='20'>20</option><option value='30' selected='selected'>30</option><option value='40'>40</option></select>";
        }
        else
        {
            strSelect = "<select class='select_num' id='s" + index + "' onchange='PageBrand(this," + idbrand + "," + current.ToString() + ",2);'><option value='20'>20</option><option value='30'>30</option><option value='40' selected='selected'>40</option></select>";
        }
        str += "<td width='45'>" + tdisplay + "</td><td width='45'>" + strSelect + "</td>";
        str += "<td width='100' align='right'><input type='text' id='t" + index + "' onkeydown=\"OnEnterSend(event,'u" + index + "');\" value='' class='tb_go' /><u class='u1' id='u" + index + "' onclick='GoGageB(" + idbrand + "," + index + ",2);'>" + tspage + "</u></td>";
        str += "<td align='right'>";
        if (index == 2)
        {
            str += "<div class='dcomparet' onclick='compcom();'>" + tcompare + "</div>";
        }
        string strlinkPage = "";
        int num = 0;
        int currentIndex = current - 1;
        if (current > 1)
        {
            num = current - 1;
            strlinkPage += "<a href='?menu=igc&id=" + idbrand + "&page=1&size=" + pagesize.ToString() + "' class='page_previous'>" + tfirstp + "</a>";
        }
        int numLeft = 0;
        strlinkPage += "<span class='text_page'>";
        string subleft = "";
        while ((currentIndex >= 1) && ((current - currentIndex) < 3))
        {
            subleft = "<a href='?menu=igc&id=" + idbrand + "&page=" + currentIndex.ToString() + "&size=" + pagesize.ToString() + "'>" + currentIndex.ToString() + "</a>" + subleft;
            numLeft++;
            currentIndex--;
        }
        strlinkPage += subleft;
        strlinkPage += "<u>" + current.ToString() + "</u>";
        currentIndex = current + 1;
        while ((currentIndex <= pages) && ((currentIndex - current) < 6 - numLeft))
        {
            strlinkPage += "<a href='?menu=igc&id=" + idbrand + "&page=" + currentIndex.ToString() + "&size=" + pagesize.ToString() + "'>" + currentIndex.ToString() + "</a>";
            currentIndex++;
        }
        strlinkPage += "</span>";
        if (current < pages)
        {
            num = current + 1;
            strlinkPage += "<a href='?menu=igc&id=" + idbrand + "&page=" + pages.ToString() + "&size=" + pagesize.ToString() + "' class='page_next'>" + tlastp + "</a>";
        }
        str += strlinkPage;
        if (index == 1)
        {
            str += "<div class='dcompared' onclick='compcom();'>" + tcompare + "</div>";
        }
        str += "</td></tr></table>";
        return str;
    }
    public string ButtonCompare(Boolean istop)
    {
        string str = "";
        str = "<table border='0' cellpadding='0' cellspacing='0' width='100%' class='bg_page'>";
        if (istop)
        {
            str += "<tr><td align='right' width='255'><div class='dcompared' onclick='compcom();'>" + tcompare + "</div></td><td>&nbsp;</td></tr></table>";
        }
        else
        {
            str += "<tr><td align='right' width='255'><div class='dcomparet' onclick='compcom();'>" + tcompare + "</div></td><td>&nbsp;</td></tr></table>";
        }
        return str;
    }
}
