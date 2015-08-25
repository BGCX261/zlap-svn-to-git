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
public partial class admin_block_Locationcontacts : System.Web.UI.UserControl
{
    public string tableLocations = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        //Show GroupContact:
        try
        {
            DataSet dsLocation = new ContacstSystem().LocationContactSelectAll();
            if (dsLocation.Tables.Count > 0)
            {
                int num = dsLocation.Tables[0].Rows.Count;
                if (num > 0)
                {
                    tableLocations = "<table border='1' cellpadding='2' cellspacing='0' bordercolor='#DFDFDF' style='border-collapse:collapse;'>";
                    tableLocations += "<tr class='tlist'><td width='30'>STT</td><td width='180'>Khu vực liên hệ</td><td width='100'>Xóa bỏ</td></tr>";
                    for (int i = 1; i <= num; i++)
                    {
                        string id = dsLocation.Tables[0].Rows[i - 1]["id"].ToString();
                        tableLocations += "<tr><td align='center'>" + i.ToString() + "</td><td class='title1'><a href='?menu=editlocationcontact&id=" + id + "'>" + dsLocation.Tables[0].Rows[i - 1]["name"].ToString() + "</a></td><td align='center'><span class='spanbt' onclick='Dfunction(" + id + ",2);'>Xóa</span></td></tr>";
                    }
                    tableLocations += "</table>";
                }
                else
                {
                    tableLocations = "Chưa có khu vực liên hệ nào";
                }
            }
        }
        catch
        {
        }
    }
}
