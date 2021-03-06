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
public partial class admin_block_AdvertiseSpecialManager : System.Web.UI.UserControl
{
    public string tblSpecial = "";
    AdvertiseSystem advertise = new AdvertiseSystem();
    protected void Page_Load(object sender, EventArgs e)
    {
        ViewLinkWeb();
    }
    void ViewLinkWeb()
    {
        try
        {
            DataSet dsSpecial = advertise.SpecialAdminAll();
            int num = dsSpecial.Tables[0].Rows.Count;
            tblSpecial = "<table border='1' cellpadding='2' cellspacing='0' bordercolor='#DFDFDF' style='border-collapse:collapse;'>";
            tblSpecial += "<tr class='tlist'><td width='30'>STT</td><td width='180'>Tiêu đề</td><td width='170'>Hình nhỏ</td><td width='300'>Hình To</td><td width='70'>Xóa bỏ</td></tr>";
            for (int i = 1; i <= num; i++)
            {
                string id = dsSpecial.Tables[0].Rows[i - 1]["id"].ToString();
                tblSpecial += "<tr><td align='center'>" + i.ToString() + "</td><td class='title1'><a href='?menu=editadspecial&id=" + id + "'>" + dsSpecial.Tables[0].Rows[i - 1]["title"].ToString() + "</a></td>";
                string image1 = dsSpecial.Tables[0].Rows[i - 1]["urlImage1"].ToString();
                string image2 = dsSpecial.Tables[0].Rows[i - 1]["urlImage2"].ToString();
                string[] extension = new string[] { "", "" };
                if (image1.Length > 0)
                {
                    extension = image1.Split('.');
                    if (extension[1].Equals("swf"))
                    {
                        image1 = "<object width='150' height='60'><embed src='../image/advertise/" + image1 + "' width='150' height='60'></embed></object>";
                    }
                    else
                    {
                        image1 = "<img src='../image/advertise/" + image1 + "' border=0 width='150' height='60' />";
                    }
                }
                if (image2.Length > 0)
                {
                    extension = image2.Split('.');
                    if (extension[1].Equals("swf"))
                    {
                        image2 = "<object width='200' height='90'><embed src='../image/advertise/" + image2 + "' width='200' height='90'></embed></object>";
                    }
                    else
                    {
                        image2 = "<img src='../image/advertise/" + image2 + "' border=0 width='200' height='90' />";
                    }
                }
                tblSpecial += "<td align='center'>" + image1 + "</td>";
                tblSpecial += "<td align='center'>" + image2 + "</td>";
                tblSpecial += "<td align='center'><span class='spanbt' onclick='Dfunction(" + id + ",6);'>Xóa</span></td></tr>";
            }
            tblSpecial += "</table>";
        }
        catch
        { }
    }
}
