using System;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Text;
using System.Net;
using facade.list;
using framework.list.common;
using System.Xml;
public partial class block_ForgotPass : System.Web.UI.UserControl
{
    public string tbutton = "";
    public string tblforgetpass = "";
    public string titlemessage = "";
    public string merrmail = "";
    public string mnothave = "";
    public string temail = "";
    public string tnotsend = "";
    public string tyestosend = "";
    public string tcode = "";
    public string tcode2 = "";
    public string mcodeerr = "";
    public string terrInsert = "";
    public string thome = "";
    public string tCurrentAccess = "";
    CGetDataCommon datacommon = new CGetDataCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            tblforgetpass = hash["blforgetp"].ToString();
            tbutton = hash["bsubmit"].ToString();
            titlemessage = hash["mtgetpass"].ToString();
            temail = hash["memail"].ToString();
            merrmail = hash["merremail"].ToString();
            mnothave = hash["mnotemail"].ToString();
            tnotsend = hash["mnotsend"].ToString();
            tyestosend = hash["msent"].ToString();
            tcode = hash["mcode"].ToString();
            tcode2 = hash["mccode"].ToString();
            mcodeerr = hash["merrcode"].ToString();
            terrInsert = hash["merrsql"].ToString();
            tCurrentAccess = hash["currentpage"].ToString();
            thome = hash["home"].ToString();
            tCurrentAccess += ": <a href='?menu=home'>" + thome + "</a> &raquo; " + tblforgetpass;
            btgetpass.Text = tbutton;
        }
        catch
        { 
        
        }
        if (!IsPostBack)
        {
            divErrors.Visible = false;
            
        }
        if (Session["RamDomCodeRegister"]==null)
        {
            Session["RamDomCodeRegister"] = datacommon.CreateCodeRanDom(5);
        }
    }
    protected void getpass_Click(object sender, EventArgs e)
    {
        try
        {
            string addressto = txtemail.Value.Trim();
            CValidate validate = new CValidate();
            UserManagerSystem usermanager=new UserManagerSystem();
            if (!validate.TestAddressEmail(addressto))
            {
                divErrors.InnerHtml = "<div class='diverror'>" + merrmail + "</div>";
                divErrors.Visible = true;
                return;
            }
            else
            {
                string code = txtcode.Value.Trim();
                if(!Session["RamDomCodeRegister"].ToString().Equals(code))
                {
                    divErrors.InnerHtml = "<div class='diverror'>" + mcodeerr + "</div>";
                    divErrors.Visible = true;
                    Session["RamDomCodeRegister"] = datacommon.CreateCodeRanDom(5);
                    return;
                }
            }
            DataSet ds=usermanager.UserSelecWithEmail(addressto);
            string username="";
            string name="";
            if(ds.Tables.Count>0)
            {
                if(ds.Tables[0].Rows.Count>0)
                {
                    username=ds.Tables[0].Rows[0]["userName"].ToString();
                    name=ds.Tables[0].Rows[0]["contactName"].ToString();
                }else
                {
                    divErrors.InnerHtml = "<div class='diverror'>" + mnothave + "</div>";
                    divErrors.Visible = true;
                    return;
                }
            }else
            {
                divErrors.InnerHtml = "<div class='diverror'>" + mnothave + "</div>";
                divErrors.Visible = true;
                return;
            }
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
                MailAddress addressfrom = new MailAddress(hastServer["from"].ToString(), hastServer["displayname"].ToString(), System.Text.Encoding.UTF8);
                MailAddress MailTo = new MailAddress(addressto);
                MailMessage message = new MailMessage();
                message.From = addressfrom;
                message.To.Add(MailTo);
                message.CC.Add(MailTo);
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                message.Subject = "YÊU CẦU LẤY LẠI MẬT KHẨU";
                message.IsBodyHtml = true;
                string codeGet=datacommon.CreateCodeRanDom(32);
                DateTime time = new DateTime();
                time = DateTime.Now;

                message.Body = BuildTable(username,name,hastServer["domain"].ToString(),hastServer["website"].ToString(),addressto,codeGet,time);
                client.Host = hastServer["host"].ToString();
                client.Port = int.Parse(hastServer["port"].ToString());
                Boolean testInsert = usermanager.UserInsertRequestPass(codeGet, name, addressto, time);
                if (testInsert)
                {
                    client.Credentials = new NetworkCredential(hastServer["username"].ToString(), hastServer["password"].ToString(), hastServer["domain"].ToString());
                    client.Send(message);
                    message.Dispose();
                    divErrors.Visible = true;
                    divErrors.InnerHtml = "<div class='diverror'>" + tyestosend + "</div>";
                    txtcode.Value = "";
                    txtemail.Value = "";
                    Session["RamDomCodeRegister"] = datacommon.CreateCodeRanDom(5);
                }
                else
                {
                    divErrors.Visible = true;
                    divErrors.InnerHtml = "<div class='diverror'>" + terrInsert + "</div>";
                }
            }
            catch(Exception ex)
            {
                Console.Write(ex.ToString());
                divErrors.Visible = true;
                divErrors.InnerHtml = "<div class='diverror'>" + tnotsend + "</div>";
            }
        }
        catch (Exception ex)
        {
            divErrors.InnerHtml = "<div class='diverror'>" + ex.ToString() + "</div>";
        }
    }
    public string BuildTable(string user,string name,string domain,string website, string email,string getnewpass,DateTime time)
    {
        string str = "";
        str += "<table cellpadding='3' cellspacing='0' border='0' width='600' style='font-family:Arial, Helvetica, sans-serif;background-color:#F4F4F4'>";
        str += "<tr height='5'><td></td></tr>";
        str += "<tr><td style='color:#0000FF;font-size:15px;' align='center'>yêu cầu lấy lại mật khẩu</td></tr>";
        str += "<tr height='7'><td></td></tr>";
        str += "<tr><td style='color:#000000;font-size:12px;'>";
        str += "Chào bạn. Bạn hoặc ai đó đã yêu cầu lấy lại thông tin đăng nhập thành viên của website: <b>" + domain + "</b> với email đăng ký là: <b>" + email + "</b>";
        str += "<br />Sau đây chúng tôi xin cung cấp thông tin tài khoản đăng nhập như sau:<br /><br />";
        str += "<b>Tên đăng nhập</b>: "+ user +"<br />";
        str += "<b>Tên hiển thị</b>: " + name + "<br />";
        str += "<b>Mật khẩu đăng nhập:</b> Không rõ<br /><br />";
        str += "Vì sự bảo mật thông tin cá nhân cho bạn. Chúng tôi đã mã hóa một chiều mật khẩu đăng nhập của bạn. ";
        str += "Vì thế chúng tôi cũng không có cánh nào cung cấp lại mật khẩu cũ cho bạn. ";
        str += "Để có mật khẩu đăng nhập mới xin bạn hãy vào địa chỉ sau đây :<br /><br />" + website + "?menu=newpass&code=" + getnewpass + " <br /><br />";
        str += "Sau đó bạn nhập mật khẩu mới. Bạn sẽ lấy lại được tài khoản đăng nhập<br /><br />";
        str += "<b>Xin cảm ơn và chúc bạn may mắn.</b><br /><br />";
        str += "<b>(Xin lưu ý: Việc yêu cầu lấy lại thông tin tài khoản đăng nhập chỉ có giới hạn trong vòng 7 ngày kể từ ngày ("+ time.ToString("dd-MM-yyyy") +").Sau 7 ngày chúng tôi sẽ xóa bỏ yêu cầu của bạn)</b>";
        str += "</td></tr></table>";
        return str;
    }
}
