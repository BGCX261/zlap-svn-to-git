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
public partial class admin_block_Helps : System.Web.UI.UserControl
{
    public string tablehelps = "Trợ giúp";

    protected void Page_Load(object sender, EventArgs e)
    {
        //Show GroupContact:
        try
        {
            DataSet dshelp = new HelpsSystem().HelpsSelectAll();
            if (dshelp.Tables.Count > 0)
            {
                int num = dshelp.Tables[0].Rows.Count;
                if (num > 0)
                {
                    tablehelps = "<table border='1' cellpadding='2' cellspacing='0' bordercolor='#DFDFDF' style='border-collapse:collapse;'>";
                    tablehelps += "<tr class='tlist'><td width='30'>STT</td><td width='180'>Tiêu đề trợ giúp</td><td width='80'>Ưu tiên</td><td width='100'>Xóa bỏ</td></tr>";
                    for (int i = 1; i <= num; i++)
                    {
                        string id = dshelp.Tables[0].Rows[i - 1]["id"].ToString();
                        tablehelps += "<tr><td align='center'>" + i.ToString() + "</td><td class='title1'><a href='?menu=edithelp&id=" + id + "'>" + dshelp.Tables[0].Rows[i - 1]["title"].ToString() + "</a></td><td align='center'>" + dshelp.Tables[0].Rows[i - 1]["sort"].ToString() + "</td><td align='center'><span class='spanbt' onclick='Dfunction(" + id + ",3);'>Xóa</span></td></tr>";
                    }
                    tablehelps += "</table>";
                }
                else
                {
                    tablehelps = "Chưa có trợ giúp nào.";
                }
            }
        }
        catch
        {
        }
    }
}
