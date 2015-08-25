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

using System.Xml;
public partial class admin_block_ChangeCurrency : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            diverr.Visible = false;
        }
    }
    protected void Button1_ServerClick(object sender, EventArgs e)
    {
        try
        {
            string currency = idChoice.Value;
            XmlDocument doc = new XmlDocument();
            string url = Server.MapPath("../data/xml/configproduct.xml");
            XmlTextReader reader = new XmlTextReader(url);
            doc.Load(reader);
            reader.Close();
            if (doc.IsReadOnly)
            {
                diverr.Visible = true;
                diverr.InnerHtml = "File XML đã bị khóa. Không thể thay đổi";
                return;
            }
            XmlNode nodeEdit = doc.SelectSingleNode("root/product[nameappunit='currency']/unit");
            string value = nodeEdit.InnerText;
            if (!value.Equals(currency))
            {
                nodeEdit.InnerText = currency;
                doc.Save(url);
                Application["currency"] = currency;
                diverr.Visible = true;
                diverr.InnerHtml = "Đã thay đổi cách hiển thị tiền tệ";
            }
            else
            {
                diverr.Visible = true;
                diverr.InnerHtml = "Hệ thống đang hiển thị kiểu tiền này.";
            }
        }catch
        {}
    }
}
