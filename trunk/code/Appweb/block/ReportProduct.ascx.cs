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
//using CrystalDecisions.CrystalReports.Engine;
using facade.list;
public partial class block_ReportProduct : System.Web.UI.UserControl
{
    string path = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //try
        //{
        //    path = Server.MapPath("report/ReportTest.rpt");
        //    ViewProductPriceListReport();
        //}
        //catch (Exception ex)
        //{ 
            
        //}
    }
    //public void ViewProductPriceListReport()
    //{
    //    try
    //    {
    //        ReportDocument rpt = new ReportDocument();
    //        rpt.Load(path);
    //        DataTable tbl1 = new DataTable();
    //        DataSet ds = new CManageProductSystem().ProductSearchFromTo("", 0, 20);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            rpt.SetDataSource(ds.Tables[0]);
    //        }
    //        this.CrystalReportViewer1.ReportSource = rpt;
    //        return;
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write(ex.Message);
    //        return;
    //    }
    //}
}
