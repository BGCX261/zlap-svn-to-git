using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using RKLib.ExportData;

namespace ExportDemo_CSharpNet
{
	/// <summary>
	/// Summary description for EmployeeInfo.
	/// </summary>
	public class EmployeeInfo : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnExport1;
		protected System.Web.UI.WebControls.Label lblScenario2;
		protected System.Web.UI.WebControls.DataGrid dgEmployee1;
		protected System.Web.UI.WebControls.DataGrid dgEmployee2;
		protected System.Web.UI.WebControls.Button btnExport2;
		protected System.Web.UI.WebControls.Label lblScenario3;
		protected System.Web.UI.WebControls.DataGrid dgEmployee3;
		protected System.Web.UI.WebControls.Button btnExport3;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label lblScenario1;
	
		DataSet dsEmployee = new DataSet( );	

		private void Page_Load(object sender, System.EventArgs e)
		{			
			try
			{
				lblError.Text = "";
				if (!IsPostBack)
				{
					get_AllEmployees( );
					Session["dsEmployee"] = dsEmployee;	
				
					dgEmployee1.DataSource = dsEmployee.Tables["Employee"];
					dgEmployee1.DataBind();					
					
					dgEmployee2.DataSource = dsEmployee.Tables["Employee"];
					dgEmployee2.DataBind();
					
					dgEmployee3.DataSource = dsEmployee.Tables["Employee"];
					dgEmployee3.DataBind();					
				}
			}
			catch(Exception Ex)
			{
				lblError.Text = Ex.Message;
			}
		}

		private DataSet get_AllEmployees()
		{
			try
			{
				// Get the employee details
				string strSql = "SELECT EmployeeID, LastName, FirstName, Format(BirthDate, 'dd-MMM-yyyy') As BirthDate, Format(HireDate, 'dd-MMM-yyyy') As HireDate, Address, PostalCode FROM Employees";
				OleDbConnection objConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("Database\\Employee.mdb"));
				OleDbDataAdapter daEmp = new OleDbDataAdapter(strSql, objConn);				
				daEmp.Fill(dsEmployee, "Employee");
				return dsEmployee;
			}
			catch(Exception Ex)
			{
				throw Ex;
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnExport1.Click += new System.EventHandler(this.btnExport1_Click);
			this.btnExport2.Click += new System.EventHandler(this.btnExport2_Click);
			this.btnExport3.Click += new System.EventHandler(this.btnExport3_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnExport1_Click(object sender, System.EventArgs e)
		{			
			// Export all the details
			try
			{			
				// Get the datatable to export			
				DataTable dtEmployee = ((DataSet) Session["dsEmployee"]).Tables["Employee"].Copy();
				
				// Export all the details to CSV
				RKLib.ExportData.Export objExport = new RKLib.ExportData.Export();
				objExport.ExportDetails(dtEmployee, Export.ExportFormat.CSV, "EmployeesInfo1");
			}
			catch(Exception Ex)
			{
				lblError.Text = Ex.Message;
			}
		}

		private void btnExport2_Click(object sender, System.EventArgs e)
		{			
			// Export the details of specified columns
			try
			{
				// Get the datatable to export			
				DataTable dtEmployee = ((DataSet) Session["dsEmployee"]).Tables["Employee"].Copy();			
				
				// Specify the column list to export
				int[] iColumns = {1,2,3,5,6};
				
				// Export the details of specified columns to Excel
				RKLib.ExportData.Export objExport = new RKLib.ExportData.Export();
				objExport.ExportDetails(dtEmployee, iColumns, Export.ExportFormat.Excel, "EmployeesInfo2");
			}
			catch(Exception Ex)
			{
				lblError.Text = Ex.Message;
			}
		}

		private void btnExport3_Click(object sender, System.EventArgs e)
		{
			
			// Export the details of specified columns with specified headers

			try
			{
				// Get the datatable to export
				DataTable dtEmployee = ((DataSet) Session["dsEmployee"]).Tables["Employee"].Copy();
				
				// Specify the column list and headers to export
				int[] iColumns = {1,2,3,5,6};
				string[] sHeaders = {"LastName", "FirstName", "DOB", "Address", "ZipCode"};

				// Export the details of specified columns with specified headers to CSV
				RKLib.ExportData.Export objExport = new RKLib.ExportData.Export();
				objExport.ExportDetails(dtEmployee, iColumns, sHeaders, Export.ExportFormat.CSV, "EmployeesInfo3");			
			}
			catch(Exception Ex)
			{
				lblError.Text = Ex.Message;
			}
		}
	}
}
