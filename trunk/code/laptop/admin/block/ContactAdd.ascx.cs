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
public partial class admin_block_ContactAdd : System.Web.UI.UserControl
{
    ContacstSystem Contacts = new ContacstSystem();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            diverror.Visible = false;
            if (!IsPostBack)
            {
                DataSet ds = Contacts.GroupContactSelectAll();
                int num = ds.Tables[0].Rows.Count;
                ListItem Item;
                Item = new ListItem("Hãy chọn nhóm liên hệ","0");
                slgroup.Items.Add(Item);
                for (int i = 0; i < num; i++)
                {
                    Item = new ListItem(ds.Tables[0].Rows[i]["name"].ToString(), ds.Tables[0].Rows[i]["id"].ToString());
                    slgroup.Items.Add(Item);
                }
                ds = Contacts.LocationContactSelectAll();
                num = ds.Tables[0].Rows.Count;
                Item = new ListItem("Hãy chọn khu vực liên hệ", "0");
                sllocation.Items.Add(Item);
                for (int i = 0; i < num; i++)
                {
                    Item = new ListItem(ds.Tables[0].Rows[i]["name"].ToString(), ds.Tables[0].Rows[i]["id"].ToString());
                    sllocation.Items.Add(Item);
                }
            }
        }
        catch
        {
            Response.Redirect("AdminWebsite.aspx?menu=contact");
        }
    }
    protected void btadd_ServerClick(object sender, EventArgs e)
    {
        try
        {
            string title = txttitle.Value.Trim();
            int type = int.Parse(SlType.Text.ToString());
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
            DataSet dsContact = Contacts.ContactAdminSelectIdName(0, title);
            if (dsContact.Tables.Count > 0)
            {
                if (Contacts.ContactAdminInsert(idlocation, idgroup, title, des, address, "", timeservice, phone, delegate1, email, fax,type))
                {
                    diverror.InnerHtml = "<div class='diverror'>Địa chỉ liên hệ đã được thêm mới</div>";
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
