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
public partial class admin_block_SupportOnline : System.Web.UI.UserControl
{
    public string stronline = "Hỗ trợ trực tuyến";

    protected void Page_Load(object sender, EventArgs e)
    {
        //Show GroupContact:
        try
        {
            DataSet dsonline = new SupportOnlineSystem().OnlineAdminSelectAll();
            if (dsonline.Tables.Count > 0)
            {
                int num = dsonline.Tables[0].Rows.Count;
                if (num > 0)
                {
                    stronline = "<table border='1' cellpadding='2' cellspacing='0' bordercolor='#DFDFDF' style='border-collapse:collapse;'>";
                    stronline += "<tr class='tlist'><td width='30'>STT</td><td width='60'>Hỗ trợ</td><td width='40'>Mã nhóm</td><td width='120'>Nhóm trực tuyến</td><td width='120'>Tên thành viên</td><td width='120'>Nick name</td><td width='120'>Tiêu đề</td><td width='60'>Xóa bỏ</td></tr>";
                    for (int i = 1; i <= num; i++)
                    {
                        string id = dsonline.Tables[0].Rows[i - 1]["id"].ToString();
                        string strsupport = "Máy tính";
                        if (dsonline.Tables[0].Rows[i - 1]["typeid"].Equals(2))
                        {
                            strsupport = "Điện thoại";
                        }
                        stronline += "<tr><td align='center'>" + i.ToString() + "</td><td align='center'>" + strsupport + "</td><td align='center'>" + dsonline.Tables[0].Rows[i - 1]["idgroup"].ToString() + "</td><td>" + dsonline.Tables[0].Rows[i - 1]["namegroup"].ToString() + "</td><td class='title1'><a href='?menu=onlinesupportedit&id=" + id + "'>" + dsonline.Tables[0].Rows[i - 1]["name"].ToString() + "</a></td><td align='center'>" + dsonline.Tables[0].Rows[i - 1]["nickname"].ToString() + "</td><td align='center'>" + dsonline.Tables[0].Rows[i - 1]["title"].ToString() + "</td><td align='center'><span class='spanbt' onclick='Dfunction(" + id + ",4);'>Xóa</span></td></tr>";
                    }
                    stronline += "</table>";
                }
                else
                {
                    stronline = "Chưa có hỗ trợ trực tuyến nào.";
                }
            }
        }
        catch
        {
        }
    }
}