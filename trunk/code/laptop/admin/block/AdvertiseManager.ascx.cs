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
public partial class admin_block_AdvertiseManager : System.Web.UI.UserControl
{
    public string tblLinkWeb = "";
    AdvertiseSystem advertise = new AdvertiseSystem();
    protected void Page_Load(object sender, EventArgs e)
    {
        ViewLinkWeb();
    }
    void ViewLinkWeb()
    {
        try
        {
            DataSet listLink = advertise.AdvertiseAdminSelectAll();
            int num = listLink.Tables[0].Rows.Count;
            tblLinkWeb = "<table border='1' cellpadding='2' cellspacing='0' bordercolor='#DFDFDF' style='border-collapse:collapse;'>";
            tblLinkWeb += "<tr class='tlist'><td width='30'>STT</td><td width='180'>Tiêu đề liên kết</td><td width='180'>Hình ảnh</td><td width='80'>Được hiển thị</td><td width='100'>Xóa bỏ</td></tr>";
            for (int i = 1; i <= num; i++)
            {
                string id = listLink.Tables[0].Rows[i - 1]["id"].ToString();
                string check = "";
                if (listLink.Tables[0].Rows[i - 1]["show"].ToString().Equals("1"))
                {
                    check = "<input type='checkbox' checked='checked' DISABLED />";
                }
                else
                {
                    check = "<input type='checkbox' DISABLED />";
                }
                string img = listLink.Tables[0].Rows[i - 1]["urlImage"].ToString();
                string[] array = img.Split('.');
                if (array.Length>=2 && array[1].Equals("swf"))
                {
                    tblLinkWeb += "<tr><td align='center'>" + i.ToString() + "</td><td class='title1'><a href='?menu=editadvertise&id=" + id + "'>" + listLink.Tables[0].Rows[i - 1]["title"].ToString() + "</a></td><td align='center'><object width='175'><embed src='../image/advertise/" + img + "'></embed></object></td><td align='center'>" + check + "</td><td align='center'><span class='spanbt' onclick='Dfunction(" + id + ",5);'>Xóa</span></td></tr>";
                }
                else
                {
                    tblLinkWeb += "<tr><td align='center'>" + i.ToString() + "</td><td class='title1'><a href='?menu=editadvertise&id=" + id + "'>" + listLink.Tables[0].Rows[i - 1]["title"].ToString() + "</a></td><td align='center'><img src='../image/advertise/" + img + "' border=0 /></td><td align='center'>" + check + "</td><td align='center'><span class='spanbt' onclick='Dfunction(" + id + ",5);'>Xóa</span></td></tr>";
                }
            }
            tblLinkWeb += "</table>";
        }
        catch
        { }
    }
}