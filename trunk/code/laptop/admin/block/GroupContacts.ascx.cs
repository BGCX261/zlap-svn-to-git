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
public partial class admin_block_GroupContacts : System.Web.UI.UserControl
{
    public string tableListGroup = "Nhóm liên hệ";

    protected void Page_Load(object sender, EventArgs e)
    {
        //Show GroupContact:
        try
        {
            DataSet dsGroupContact = new ContacstSystem().GroupContactSelectAll();
            if (dsGroupContact.Tables.Count > 0)
            {
                int num = dsGroupContact.Tables[0].Rows.Count;
                if (num > 0)
                {
                    tableListGroup = "<table border='1' cellpadding='2' cellspacing='0' bordercolor='#DFDFDF' style='border-collapse:collapse;'>";
                    tableListGroup += "<tr class='tlist'><td width='30'>STT</td><td width='180'>Tiêu đề nhóm</td><td width='80'>Thứ tự ưu tiên</td><td width='100'>Xóa bỏ</td></tr>";
                    for (int i = 1; i <= num; i++)
                    {
                        string id = dsGroupContact.Tables[0].Rows[i - 1]["id"].ToString();
                        tableListGroup += "<tr><td align='center'>" + i.ToString() + "</td><td class='title1'><a href='?menu=editgroupcontact&id=" + id + "'>" + dsGroupContact.Tables[0].Rows[i - 1]["name"].ToString() + "</a></td><td align='center'>" + dsGroupContact.Tables[0].Rows[i - 1]["sort"].ToString() + "</td><td align='center'><span class='spanbt' onclick='Dfunction(" + id + ",1);'>Xóa</span></td></tr>";
                    }
                    tableListGroup += "</table>";
                }
                else
                {
                    tableListGroup = "Chưa có nhóm liên hệ nào.";
                }
            }
        }
        catch
        { 
        }
    }
}
