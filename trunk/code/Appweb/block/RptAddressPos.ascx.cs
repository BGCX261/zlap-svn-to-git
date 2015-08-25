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
using Microsoft.Reporting.WebForms;
using facade.list;
using framework.list.common;
public partial class block_RptAddressPos : System.Web.UI.UserControl
{
    public string titleBlock = "Danh sách địa chỉ bán hàng bạn được chọn để in";
    string[] arrInfor = new string[] { "", "" };
    string nameForm = "";
    Hashtable hActive = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            nameForm = Request.QueryString["key"].ToString();
            //hActive = GetRight(nameForm);
            //if (hActive == null)
            //{
            //    Response.Redirect("LoginWebsite.aspx");
            //}
            //if (hActive[1] == null)
            //{
            //    Response.Redirect("Default.aspx?menu=MessageLock");
            //}
            if (!IsPostBack)
            {
                DataSet dsUser = new CManageUserSystem().SelectAllPosofAccount(arrInfor[0]);
                if (dsUser.Tables.Count > 0 && dsUser.Tables[0].Rows.Count > 0)
                {
                    int num = dsUser.Tables[0].Rows.Count;
                    for (int i = 0; i < num; i++)
                    {
                        ListItem Item = new ListItem(dsUser.Tables[0].Rows[i]["PosName"].ToString(), dsUser.Tables[0].Rows[i]["PosId"].ToString());
                        slPos.Items.Add(Item);
                    }
                }
                string strSource = Server.MapPath("report/rptAddressPos.rdlc");
                rptView.LocalReport.ReportPath = strSource;
                rptView.ZoomMode = ZoomMode.Percent;
                rptView.ZoomPercent = 100;
                string address = "";
                if (slPos.Text.Length > 0)
                {
                    DataSet dsAddress = new CManageUserSystem().SelectAddressReport(slPos.Text);
                    if (dsAddress.Tables.Count > 0 && dsAddress.Tables[0].Rows.Count > 0)
                    {
                        address = dsAddress.Tables[0].Rows[0]["ReportTile"].ToString();
                    }
                }
                DateTime time = CTime.GetTimeHaNoi();
                ReportParameter parTime = new ReportParameter("parTime", time.ToString("dd/MM - HH:mm"));
                ReportParameter parAddress = new ReportParameter("parAddress", address);
                rptView.LocalReport.SetParameters(new ReportParameter[] { parAddress, parTime });
            }
            
        }
        catch(Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
    protected void tbReport_click(object sender,EventArgs e)
    {
        try
        {
            string strSource = Server.MapPath("report/rptAddressPos.rdlc");
            rptView.LocalReport.ReportPath = strSource;
            rptView.ZoomMode = ZoomMode.Percent;
            rptView.ZoomPercent = 100;
            string address = "";
            if (slPos.Text.Length > 0)
            {
                DataSet dsAddress = new CManageUserSystem().SelectAddressReport(slPos.Text);
                if (dsAddress.Tables.Count > 0 && dsAddress.Tables[0].Rows.Count > 0)
                {
                    address = dsAddress.Tables[0].Rows[0]["ReportTile"].ToString();
                }
            }
            ReportParameter parAddress = new ReportParameter("parAddress", address);
            rptView.LocalReport.SetParameters(new ReportParameter[] { parAddress });
        }
        catch
        { }
    }
}
