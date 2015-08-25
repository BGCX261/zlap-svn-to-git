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
public partial class admin_block_ContactEdit : System.Web.UI.UserControl
{
    ContacstSystem Contacts = new ContacstSystem();
    int id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            diverror.Visible = false;
            id=int.Parse(Request.QueryString["id"].ToString());
            if (!IsPostBack)
            {
                DataSet dscontact = Contacts.ContactAdminSelectIdName(id, "ContactAdminSelectIdName");
                if (dscontact.Tables.Count > 0 && dscontact.Tables[0].Rows.Count>0)
                {
                    string idgroup = dscontact.Tables[0].Rows[0]["idtype"].ToString();
                    string idlocation = dscontact.Tables[0].Rows[0]["idlocation"].ToString();
                    txttitle.Value = dscontact.Tables[0].Rows[0]["name"].ToString();
                    txtdes.Value = dscontact.Tables[0].Rows[0]["des"].ToString();
                    txtaddress.Value = dscontact.Tables[0].Rows[0]["address"].ToString();
                    txttimeservice.Value = dscontact.Tables[0].Rows[0]["timeservice"].ToString();
                    txtphone.Value = dscontact.Tables[0].Rows[0]["phone"].ToString();
                    txtemail.Value = dscontact.Tables[0].Rows[0]["email"].ToString();
                    txtdelegate.Value = dscontact.Tables[0].Rows[0]["delegate"].ToString();
                    txtfax.Value = dscontact.Tables[0].Rows[0]["fax"].ToString();
                    DataSet ds = Contacts.GroupContactSelectAll();
                    int num = ds.Tables[0].Rows.Count;
                    ListItem Item;
                    Item = new ListItem("Hãy chọn nhóm liên hệ", "0");
                    slgroup.Items.Add(Item);
                    for (int i = 0; i < num; i++)
                    {
                        Item = new ListItem(ds.Tables[0].Rows[i]["name"].ToString(), ds.Tables[0].Rows[i]["id"].ToString());
                        slgroup.Items.Add(Item);
                        if (ds.Tables[0].Rows[i]["id"].ToString().Equals(idgroup))
                        {
                            slgroup.Items[i+1].Selected = true;
                        }
                    }
                    ds = Contacts.LocationContactSelectAll();
                    num = ds.Tables[0].Rows.Count;
                    Item = new ListItem("Hãy chọn khu vực liên hệ", "0");
                    sllocation.Items.Add(Item);
                    for (int i = 0; i < num; i++)
                    {
                        Item = new ListItem(ds.Tables[0].Rows[i]["name"].ToString(), ds.Tables[0].Rows[i]["id"].ToString());
                        sllocation.Items.Add(Item);
                        if (ds.Tables[0].Rows[i]["id"].ToString().Equals(idlocation))
                        {
                            sllocation.Items[i+1].Selected = true;
                        }
                    }
                }
                else
                {
                    Response.Redirect("AdminWebsite.aspx?menu=contact");
                }
            }
        }
        catch
        {
            Response.Redirect("AdminWebsite.aspx?menu=contact");
        }
    }
    protected void btedit_ServerClick(object sender, EventArgs e)
    {
        try
        {
            string title = txttitle.Value.Trim();
            int idgroup = int.Parse(slgroup.Value);
            int idlocation = int.Parse(sllocation.Value);
            string des = txtdes.Value.Trim();
            string address = txtaddress.Value.Trim();
            string timeservice = txttimeservice.Value.Trim();
            string phone = txtphone.Value.Trim();
            string delegate1 = txtdelegate.Value.Trim();
            string email = txtemail.Value.Trim();
            string fax = txtfax.Value.Trim();
            if (title.Length == 0)
            {
                diverror.InnerHtml = "<div class='diverror'>Xin hãy nhập tiêu đề liên hệ</div>";
                diverror.Visible = true;
                return;
            }
            else if (idgroup == 0)
            {
                diverror.InnerHtml = "<div class='diverror'>Xin hãy chọn nhóm liên hệ</div>";
                diverror.Visible = true;
                return;
            }
            else if (idlocation == 0)
            {
                diverror.InnerHtml = "<div class='diverror'>Xin hãy chọn khu vực liên hệ</div>";
                diverror.Visible = true;
                return;
            }
            else if (address.Length == 0)
            {
                diverror.InnerHtml = "<div class='diverror'>Xin hãy nhập địa chỉ liên hệ</div>";
                diverror.Visible = true;
                return;
            }
            DataSet dsContact = Contacts.ContactAdminSelectIdName(id, title);
            if (dsContact.Tables.Count > 0)
            {
                if (dsContact.Tables[0].Rows.Count == 0)
                {
                    Response.Redirect("AdminWebsite.aspx?menu=contact");
                }
                else
                {
                    if (Contacts.ContactAdminUpdate(id,idlocation, idgroup, title, des, address, "", timeservice, phone, delegate1, email, fax))
                    {
                        diverror.InnerHtml = "<div class='diverror'>Địa chỉ liên hệ đã được chỉnh sửa.</div>";
                        diverror.Visible = true;
                        return;
                    }
                    else
                    {
                        diverror.InnerHtml = "<div class='diverror'>Lỗi kết nối SQL. Không thể thêm mới.</div>";
                        diverror.Visible = true;
                        return;
                    }
                }
            }
            else
            {
                diverror.InnerHtml = "<div class='diverror'>Lỗi kết nối SQL. Không thể thêm mới.</div>";
                diverror.Visible = true;
                return;
            }

        }
        catch
        {
            diverror.InnerHtml = "<div class='diverror'>Lỗi kết nối SQL. Không thể thêm mới.</div>";
            diverror.Visible = true;
            return;
        }
    }
}
