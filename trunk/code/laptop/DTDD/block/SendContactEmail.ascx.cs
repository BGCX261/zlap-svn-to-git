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
using framework.list.common;
using System.Net;
using System.Net.Mail;
using facade.list;
public partial class block_SendContactEmail : System.Web.UI.UserControl
{
    CGetDataCommon DataCommon = new CGetDataCommon();
    UserManagerSystem Users = new UserManagerSystem();
    public string tblsendmail = "";
    public string ttitle = "";
    public string tname = "";
    public string tyestosendmail = "";
    public string tcontent = "";
    public string tcode = "";
    public string tcodo1 = "";
    public string tfrom = "";
    public string terrcommon = "";
    public string terrlengcontent = "";
    public string terrcode = "";
    public string tnotsupportsend = "";
    public string tyestosend = "";
    public string tbutton = "";
    public string currentAccess = "";
    string thome = "";
    string tsendmail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["infoUser"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        divErrors.Visible = false;
        if (!IsPostBack)
        {
            string[] arrvalue = (string[])Session["infoUser"];
            DataSet ds = Users.GetUserInformation(int.Parse(arrvalue[0]));
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtEmailFrom.Value = ds.Tables[0].Rows[0]["Email1"].ToString();
                    txtName.Value = ds.Tables[0].Rows[0]["Contactname"].ToString();
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
        if (Session["RamDomCodeRegister"] == null)
        {
            string random = DataCommon.CreateCodeRanDom(5);
            Session["RamDomCodeRegister"] = random;
        }
        try
        {
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            currentAccess = hash["currentpage"].ToString();
            thome = hash["home"].ToString();
            tsendmail = hash["fsendmail"].ToString();
            currentAccess += ": <a href='?menu=home'>" + thome + "</a> &raquo; " + tsendmail;
            tbutton = "Đồng ý";
            btsend.Value = tbutton;
            tblsendmail = "Gửi thư yêu cầu với chúng tôi";
            ttitle = "Tiêu đề yêu cầu";
            tname = "Họ tên người gửi";
            tcontent = "Nội dung yêu cầu";
            tcode = "Mã xác nhận";
            tcodo1 = "Nhập lại mã xác nhận";
            tfrom = "Email người gửi";
            terrcommon = "Xin hãy nhập đầy đủ thông tin";
            terrlengcontent = "Nội dung yêu cầu phải trên 50 ký tự.";
            terrcode = "Mã xác nhận không đúng";
            tnotsupportsend = "Hệ thống không hỗ trợ gửi mail. Thành thật xin lỗi bạn về điều này.";
            tyestosend = "Chúng tôi đã nhận được yêu cầu của bạn. Chúng tôi sẽ cố gắng liên lạc với bạn trong thời gian sớm nhất.";
        }
        catch
        { 
        }
    }
    protected void btsend_ServerClick(object sender, EventArgs e)
    {
        try
        {
            string title = txtTitle.Value.Trim();
            string mailFrom = txtEmailFrom.Value.Trim();
            string name = txtName.Value.Trim();
            string content = txtcontent.Value.Trim();
            string code = txtcode.Value.Trim();
            if((title.Length==0)||(content.Length==0))
            {
                divErrors.Visible = true;
                divErrors.InnerHtml = "<div class='diverror'>" + terrcommon + "</div>";
                return;
            }
            else if (content.Length < 50)
            {
                divErrors.Visible = true;
                divErrors.InnerHtml = "<div class='diverror'>" + terrlengcontent + "</div>";
                return;
            }
            else if (code.Equals(Session["RamDomCodeRegister"].ToString()))
            {
                try
                {
                    XmlDocument docservermail = new XmlDocument();
                    string xpathfile = Server.MapPath("data/xml/configmailserver.xml");
                    XmlTextReader readfile = new XmlTextReader(xpathfile);
                    docservermail.Load(readfile);
                    readfile.Close();
                    XmlNode node = docservermail.SelectSingleNode("/server");
                    XmlNodeList listnode = node.ChildNodes;
                    int numnodes = listnode.Count;
                    Hashtable hastServer = new Hashtable();
                    for (int i = 0; i < numnodes; i++)
                    {
                        hastServer.Add(listnode[i].Name, listnode[i].InnerText);
                    }
                    SmtpClient client = new SmtpClient();
                    MailAddress addressfrom = new MailAddress(mailFrom, name, System.Text.Encoding.UTF8);
                    MailAddress MailTo = new MailAddress(hastServer["from"].ToString());
                    MailMessage message = new MailMessage();
                    message.From = addressfrom;
                    message.To.Add(MailTo);
                    message.CC.Add(MailTo);
                    message.BodyEncoding = System.Text.Encoding.UTF8;
                    message.SubjectEncoding = System.Text.Encoding.UTF8;
                    message.Subject=title;
                    message.IsBodyHtml = true;
                    message.Body = "<table><tr><td>" + content + "</td></tr></table>";
                    client.Host = hastServer["host"].ToString();
                    client.Port = int.Parse(hastServer["port"].ToString());
                    //Boolean testInsert = usermanager.UserInsertRequestPass(codeGet, name, addressto, time);
                    client.Credentials = new NetworkCredential(hastServer["username"].ToString(), hastServer["password"].ToString(), hastServer["domain"].ToString());
                    client.Send(message);
                    message.Dispose();
                    txtcode.Value = "";
                    txtTitle.Value = "";
                    txtcontent.Value = "";
                    Session["RamDomCodeRegister"] = DataCommon.CreateCodeRanDom(5);
                    divErrors.Visible = true;
                    divErrors.InnerHtml = "<div class='diverror'>" + tyestosend + "</div>";
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                    divErrors.Visible = true;
                    divErrors.InnerHtml = "<div class='diverror'>" + tnotsupportsend + "</div>";
                }
            }
            else
            {
                divErrors.Visible = true;
                divErrors.InnerHtml = "<div class='diverror'>" + terrcode + "</div>";
                return;
            }
        }
        catch
        {
            divErrors.Visible = true;
            divErrors.InnerHtml = "<div class='diverror'>" + terrcode + "</div>";
            return;
        }
    }
}
