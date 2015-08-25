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
public partial class admin_block_Contacts : System.Web.UI.UserControl
{
    public string tablecontacts = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //Show Contacts:
        try
        {
            DataSet dscontact = new ContacstSystem().ContactsSelectAll();
            if (dscontact.Tables.Count > 0)
            {
                int num = dscontact.Tables[0].Rows.Count;
                if (num > 0)
                {
                    tablecontacts = "<table border='1' cellpadding='2' cellspacing='0' bordercolor='#DFDFDF' style='border-collapse:collapse;' width='100%'>";
                    tablecontacts += "<tr class='tlist'><td width='30'>STT</td><td width='80'>Địa chỉ cho</td><td width='130'>Tiêu đề liên hệ</td><td width='160'>Nhóm liên hệ</td><td width='120'>Khu vực liên hệ</td><td width='40'>Xóa bỏ</td></tr>";
                    for (int i = 1; i <= num; i++)
                    {
                        string id = dscontact.Tables[0].Rows[i - 1]["idcontact"].ToString();
                        string strsupport = "máy tính";
                        if (dscontact.Tables[0].Rows[i - 1]["groupid"].Equals(2))
                        {
                            strsupport = "Điện thoại";
                            
                        }
                        tablecontacts += "<tr><td align='center'>" + i.ToString() + "</td><td align='center'>" + strsupport + "</td><td class='title1'><a href='?menu=editcontact&id=" + id + "'>" + dscontact.Tables[0].Rows[i - 1]["name"].ToString() + "</a></td>";
                        tablecontacts += "<td>" + dscontact.Tables[0].Rows[i - 1]["groupcontact"].ToString() + "</td>";
                        tablecontacts += "<td>" + dscontact.Tables[0].Rows[i - 1]["location"].ToString() + "</td>";
                        tablecontacts += "<td align='center'><span class='spanbt' onclick='Dfunction(" + id + ",8);'>Xóa</span></td></tr>";
                    }
                    tablecontacts += "</table>";
                }
                else
                {
                    tablecontacts = "Chưa có địa chỉ liên hệ.";
                }
            }
        }
        catch
        {
        }
    }
}
