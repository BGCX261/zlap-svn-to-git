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
public partial class admin_block_ManageGroupArticle : System.Web.UI.UserControl
{
    public string tableListGroup = "";
    ArticleManagerSystem Articles = new ArticleManagerSystem();
    protected void Page_Load(object sender, EventArgs e)
    {
        ViewListGroup();
    }
    void ViewListGroup()
    {
        try
        {
            DataSet ListGroup = Articles.AdminGroupAll();
            int numGroup = ListGroup.Tables[0].Rows.Count;
            tableListGroup = "<table border='1' cellpadding='2' cellspacing='0' bordercolor='#DFDFDF' style='border-collapse:collapse;'>";
            tableListGroup += "<tr class='tlist'><td width='30'>STT</td><td width='180'>Tiêu đề nhóm</td><td width='80'>Được hiển thị</td><td width='100'>Xóa bỏ</td></tr>";
            for (int i = 1; i <= numGroup; i++)
            {
                string id = ListGroup.Tables[0].Rows[i - 1]["id"].ToString();
                string check = "";
                if (ListGroup.Tables[0].Rows[i - 1]["ishow"].ToString().Equals("1"))
                {
                    check = "<input type='checkbox' checked='checked' DISABLED />";
                }
                else
                {
                    check = "<input type='checkbox' DISABLED />";
                }
                tableListGroup += "<tr><td align='center'>" + i.ToString() + "</td><td class='title1'><a href='?menu=editga&id=" + id + "'>" + ListGroup.Tables[0].Rows[i - 1]["name"].ToString() + "</a></td><td align='center'>" + check + "</td><td align='center'><span class='spanbt' onclick='DeleteGroup("+ id +");'>Xóa</span></td></tr>";
            }
            tableListGroup += "</table>";
        }
        catch
        { }
    }
}
