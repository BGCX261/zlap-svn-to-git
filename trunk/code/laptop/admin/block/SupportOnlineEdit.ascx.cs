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
public partial class admin_block_SupportOnlineEdit : System.Web.UI.UserControl
{
    public string id = "0";
    SupportOnlineSystem SupportOnline = new SupportOnlineSystem();
    protected void Page_Load(object sender, EventArgs e)
    {
        diverror.Visible = false;
        try
        {
            id = Request.QueryString["id"].ToString();
            if (!IsPostBack)
            {
                DataSet dssupport = SupportOnline.OnlineSelectId(id);
                if (dssupport.Tables.Count > 0)
                {
                    txtgroup.Value = dssupport.Tables[0].Rows[0]["namegroup"].ToString();
                    txtname.Value = dssupport.Tables[0].Rows[0]["name"].ToString();
                    txtnickname.Value = dssupport.Tables[0].Rows[0]["nickname"].ToString();
                    txttitle.Value=dssupport.Tables[0].Rows[0]["title"].ToString();
                    int index=int.Parse(dssupport.Tables[0].Rows[0]["idgroup"].ToString());
                    if (index <= 0)
                    {
                        index = 1;
                    }
                    slgroup.Items[index - 1].Selected = true;
                    index = int.Parse(dssupport.Tables[0].Rows[0]["sort"].ToString());
                    if (index <= 0)
                    {
                        index = 1;
                    }
                    slsort.Items[index - 1].Selected = true;
                }
                else
                {
                    Response.Redirect("AdminWebsite.aspx?menu=onlinesupport");
                }
            }
        }
        catch
        {
            Response.Redirect("AdminWebsite.aspx?menu=onlinesupport");
        }
    }
    protected void btedit_ServerClick(object sender, EventArgs e)
    {
        try
        {
            int idgroup = int.Parse(slgroup.Value);
            string group = txtgroup.Value.Trim();
            string name = txtname.Value.Trim();
            string nickname = txtnickname.Value.Trim();
            string title = txttitle.Value.Trim();
            int sort = int.Parse(slsort.Value);
            if (group.Length == 0)
            {
                diverror.Visible = true;
                diverror.InnerHtml = "<div class='diverror'>Xin hãy nhập nhóm hỗ trợ</div>";
                return;
            }
            else if (name.Length == 0)
            {
                diverror.Visible = true;
                diverror.InnerHtml = "<div class='diverror'>Xin hãy nhập tên nhân viên</div>";
                return;
            }
            else if (nickname.Length == 0)
            {
                diverror.Visible = true;
                diverror.InnerHtml = "<div class='diverror'>Xin hãy nhập Nick Name</div>";
                return;
            }
            DataSet dsOnline = SupportOnline.OnlineSelectId(id);
            if (dsOnline.Tables[0].Rows.Count > 0)
            {
                if (SupportOnline.OnlineUpdate(int.Parse(id),name, nickname, title, idgroup, group, sort))
                {
                    diverror.Visible = true;
                    diverror.InnerHtml = "<div class='diverror'>Hỗ trợ trực đã được chỉnh sửa.</div>";
                    ResetAppOnline();
                    return;
                }
                else
                {
                    diverror.Visible = true;
                    diverror.InnerHtml = "<div class='diverror'>Lỗi kết nối SQL, không thể thêm mới</div>";
                    return;
                }
            }
            else
            {
                Response.Redirect("AdminWebsite.aspx?menu=onlinesupport");
            }
        }
        catch
        {
            Response.Redirect("AdminWebsite.aspx?menu=onlinesupport");
        }
    }
    public void ResetAppOnline()
    {
        try
        {
            DataSet dsOnline = new SupportOnlineSystem().OnlineSelectAll("1");
            int numOnline = dsOnline.Tables[0].Rows.Count;
            string strOnline = "";
            if (numOnline > 0)
            {
                strOnline = "<table border='0' cellpadding='0' cellspacing='0' width='100%'>";
                string idgroup1 = dsOnline.Tables[0].Rows[0]["idgroup"].ToString();
                strOnline += "<tr><td class='text_b2'>" + dsOnline.Tables[0].Rows[0]["namegroup"].ToString() + "</td></tr>";
                for (int i = 0; i < numOnline; i++)
                {
                    if (idgroup1 != dsOnline.Tables[0].Rows[i]["idgroup"].ToString())
                    {
                        strOnline += "<tr><td class='text_b2'>" + dsOnline.Tables[0].Rows[i]["namegroup"].ToString() + "</td></tr>";
                        idgroup1 = dsOnline.Tables[0].Rows[i]["idgroup"].ToString();
                    }
                    string name = dsOnline.Tables[0].Rows[i]["name"].ToString();
                    if (dsOnline.Tables[0].Rows[i]["title"].ToString().Length > 0)
                    {
                        name = "<br /><span class='text_5'>" + dsOnline.Tables[0].Rows[i]["title"].ToString() + ":</span> " + name;
                    }
                    strOnline += "<tr height='26'><td class='text_title' align='left'>";
                    strOnline += "&nbsp;&nbsp;<a href ='ymsgr:sendim?" + dsOnline.Tables[0].Rows[i]["nickname"].ToString() + "'><img src='http://opi.yahoo.com/online?u=" + dsOnline.Tables[0].Rows[i]["nickname"].ToString() + "&m=g&t=1' border='0' style='vertical-align:middle'/></a> " + name + "</td></tr>";
                    if (i < numOnline - 1 && idgroup1 == dsOnline.Tables[0].Rows[i + 1]["idgroup"].ToString())
                    {
                        strOnline += "<tr><td class='bg_line2'></td></tr>";
                    }
                    else if (i == numOnline - 1)
                    {
                        strOnline += "<tr><td height='2'></td></tr>";
                    }
                }
                strOnline += "</table>";
                Application["appOnline"] = strOnline;
            }
        }
        catch
        { }
    }
}
