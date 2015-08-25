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
public partial class block_Contacts : System.Web.UI.UserControl
{
    public string tblContact = "Địa chỉ liên hệ mua hàng và bảo hành";
    public string currentAccess = "";
    public string tableContacts = "Phần liên hệ đang được cập nhật. Xin bạn vui lòng quay lại sau";
    string thome = "";
    string tcontact = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            currentAccess = hash["currentpage"].ToString();
            thome = hash["home"].ToString();
            tcontact = hash["contact"].ToString();
            currentAccess += ": <a href='?menu=home'>" + thome + "</a> &raquo; " + tcontact;
            DataSet ds = new ContacstSystem().ContactsSelectAll();
            int numContact=ds.Tables[0].Rows.Count;
            if (numContact > 0)
            {
                string idtype = ds.Tables[0].Rows[0]["idtype"].ToString();
                string idlocation = ds.Tables[0].Rows[0]["id"].ToString();
                for (int i = 0; i < numContact; i++)
                {
                    string nameGroup = ds.Tables[0].Rows[i]["groupcontact"].ToString();
                    string location = ds.Tables[0].Rows[i]["location"].ToString();
                    if (idtype.Equals(ds.Tables[0].Rows[i]["idtype"].ToString()))
                    {
                        if (i==0)
                        {
                            tableContacts = "<span class='text_title'>" + nameGroup + "</span>";
                            tableContacts += "<div class='tdborder'>";
                        }
                    }
                    else
                    {
                        tableContacts += "</div>";
                        tableContacts += "<span class='text_title'>" + nameGroup + "</span>";
                        tableContacts += "<div class='tdborder'>";
                    }
                    if (idlocation.Equals(ds.Tables[0].Rows[i]["id"].ToString()))
                    {
                        if (i == 0)
                        {
                            tableContacts += "<div class='tgroup'>" + location + "</div>";
                        }
                    }
                    else
                    {
                        tableContacts += "<div class='tgroup'>" + location + "</div>";
                    }
                    //Contact:
                    tableContacts+="<table border='0' cellpadding='0' cellspacing='0' width='100%'>";
	                tableContacts+="<tr><td height='5' width='150'></td><td></td></tr>";
                    tableContacts += "<tr><td colspan='2' class='title_1' height='24'>" + ds.Tables[0].Rows[i]["name"].ToString() +"</td></tr>";
                    tableContacts += "<tr class='bgtr1'><td class='td1'>Địa chỉ</td><td>" + ds.Tables[0].Rows[i]["address"].ToString() + "</td></tr>";
                    tableContacts += "<tr class='bgtr2'><td class='td1'>Mô tả</td><td>" + ds.Tables[0].Rows[i]["des"].ToString() + "</td></tr>";
                    tableContacts += "<tr class='bgtr1'><td class='td1'>Thời gian phục vụ</td><td>" + ds.Tables[0].Rows[i]["timeservice"].ToString() + "</td></tr>";
                    tableContacts += "<tr class='bgtr2'><td class='td1'>Số điện thoại</td><td>" + ds.Tables[0].Rows[i]["phone"].ToString() + "</td></tr>";
                    tableContacts += "<tr class='bgtr1'><td class='td1'>Số Fax</td><td>" + ds.Tables[0].Rows[i]["fax"].ToString() + "</td></tr>";
                    tableContacts += "<tr class='bgtr2'><td class='td1'>Email</td><td>" + ds.Tables[0].Rows[i]["email"].ToString() + "</td></tr>";
                    if (ds.Tables[0].Rows[i]["delegate"].ToString().Length > 0)
                    {
                        tableContacts += "<tr class='bgtr1'><td class='td1'>Người đại diện</td><td>" + ds.Tables[0].Rows[i]["delegate"].ToString() + "</td></tr>";
                    }
                    tableContacts += "</table>";
                    //string id = ds.Tables[0].Rows[i]["groupcontact"].ToString();
                    idtype = ds.Tables[0].Rows[i]["idtype"].ToString();
                    idlocation = ds.Tables[0].Rows[i]["id"].ToString();
                }
                tableContacts += "</div>";
            }
        }
        catch
        { 
        }
    }
}
