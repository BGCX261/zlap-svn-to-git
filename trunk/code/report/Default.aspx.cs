using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;
public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            DataSet ds = new DsProduct();
            DataTable Table = ds.Tables["Products"];
            
            //for (int i = 0; i <= 100; i++)
            //{
            //    DataRow Row = ds.Tables["Products"].NewRow();
            //    Row["Id"] = i + 1;
            //    Row["Name"] = "Alfreds Futterkiste Alfreds Futterkiste";
            //    Row["Note"] = "Alfreds Futterkiste Alfreds Futterkiste Alfreds Futterkiste Alfreds Futterkiste Alfreds Futterkiste Alfreds Futterkiste Alfreds Futterkiste Alfreds Futterkiste Alfreds Futterkiste Alfreds Futterkiste Alfreds Futterkiste Alfreds Futterkiste";
            //    ds.Tables["Products"].Rows.Add(Row);
            //}
            string cnString = "server=localhost;database=wms_local;user id=sa;password=sa";
            //Declare Connection, command, and other related objects
            SqlConnection conReport = new SqlConnection(cnString);
            SqlCommand cmdReport = new SqlCommand();
            SqlDataReader drReport;
            conReport.Open();
            cmdReport.CommandType = CommandType.Text;
            cmdReport.Connection = conReport;
            cmdReport.CommandText = "Select Id,Name,Note from tbl_product";
            drReport = cmdReport.ExecuteReader();
            ds.Tables["Products"].Load(drReport);
            drReport.Close();
            conReport.Close();
            string strSource = Server.MapPath("Report/ReportProduct.rdlc");
            RpProductPrice.LocalReport.ReportPath = strSource;
            ReportDataSource rds=new ReportDataSource();
            rds.Name = "DsProduct_Products";
            rds.Value = ds.Tables["Products"];
            RpProductPrice.LocalReport.DataSources.Add(rds);
            //RpProductPrice.LocalReport.Render();
        }
        catch
        {
        }
    }
}