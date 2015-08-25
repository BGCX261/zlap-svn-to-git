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
public partial class block_header : System.Web.UI.UserControl
{
    public string showRight = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            showRight = "<object height='116' width='470'><embed src='image/flash/flash_head_right.swf' width='470' height='116' type='application/x-shockwave-flash' pluginspage='http://www.macromedia.com/go/getflashplayer'></embed></object>";
            //if (Request.QueryString["brand"] != null)
            //{
            //    string idbrand = Request.QueryString["brand"].ToString();
            //    if (idbrand.Length > 0)
            //    {
            //        DataSet dsAdvertise=new AdvertiseSystem().SpecialIdbrandTop(idbrand);
            //        if (dsAdvertise.Tables[0].Rows.Count > 0)
            //        {
            //            string img2 = dsAdvertise.Tables[0].Rows[0]["UrlImage2"].ToString();
            //            if (img2.Length > 0)
            //            {
            //                string[] extension = img2.Split('.');
            //                if (extension[1].Equals("swf"))
            //                {
            //                    showRight = "<object height='116' width='470'><embed src='image/advertise/" + img2 + "' width='470' height='116'></embed></object>";
            //                }
            //                else
            //                {
            //                    showRight = "<a href='" + dsAdvertise.Tables[0].Rows[0]["link"].ToString() + "'><img src='image/advertise/" + img2 + "' width='470' height='116'/></a>";
            //                }
            //            }
            //        }
            //    }
            //}
        }
        catch
        { }
    }
}