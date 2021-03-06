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
using common.list.WebUser;

public partial class admin_block_UserManage : System.Web.UI.UserControl
{
    public string tablecontacts = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.ViewAllUser();
            //string menu = Request.QueryString["menu"].ToString();
            //switch (menu)
            //{
            //    case "addUser":
            //        this.AddUser();
            //        break;
            //    case "viewAllUser":
            //        this.ViewAllUser();
            //        break;
            //    case "deleteUser":
            //        this.DeleteUser();
            //        break;
            //    case "editUser":
            //        this.EditUser();
            //        break;
            //    default:
            //        this.ViewAllUser();
            //        break;
            //}
        }
        catch
        {
        }
    }

    //private void EditUser()
    //{
    //    try
    //    {
    //        throw new Exception("The method or operation is not implemented.");
    //    }
    //    catch (Exception)
    //    {

    //        throw;
    //    }
    //}

    //private void DeleteUser()
    //{
    //    try
    //    {
    //        throw new Exception("The method or operation is not implemented.");
    //    }
    //    catch (Exception)
    //    {

    //        throw;
    //    }
    //}

    //private void AddUser()
    //{
    //    try
    //    {
    //        throw new Exception("The method or operation is not implemented.");
    //    }
    //    catch (Exception)
    //    {

    //        throw;
    //    }
    //}

    private void ViewAllUser()
    {
        try
        {
            DataTable tbl = new facade.list.WebUserFC().Select();
            if (tbl.Rows.Count > 0)
            {
                int num = tbl.Rows.Count;
                if (num > 0)
                {
                    tablecontacts = "<table border='1' cellpadding='2' cellspacing='0' bordercolor='#DFDFDF' style='border-collapse:collapse;' width='100%'>";
                    tablecontacts += "<tr class='tlist'><td width='30'>STT</td><td width='160'>Mã</td><td width='160'>UserName</td><td width='140'>Password</td><td width='60'>Xóa bỏ</td></tr>";
                    int Stt = 0;
                    foreach (DataRow dr in tbl.Rows)
                    {
                        Stt++;
                        string id = dr[WebUserCM.FLD_ID].ToString();
                        tablecontacts += "<tr><td align='center'>" + Stt.ToString() + "</td><td class='title1'><a href='?menu=editUser&id=" + id + "'>" + id + "</a></td>";
                        tablecontacts += "<td class='title1'><a href='?menu=editUser&id=" + id + "'>" + dr[WebUserCM.FLD_USERNAME].ToString() + "</a></td>";
                        tablecontacts += "<td>???</td>";
                        tablecontacts += "<td align='center'><a href='?menu=deleteUser&id=" + id + "'>Xóa</a></td></tr>";
                    }
                    tablecontacts += "</table>";
                }
                else
                {
                    tablecontacts = "Chưa có địa chỉ liên hệ.";
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
}
