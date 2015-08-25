using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Configuration;

namespace WSBarCode
{
	/// <summary>
	/// Summary description for Service1.
	/// </summary>
	public class BarCodeGenerator : System.Web.Services.WebService
	{
		public BarCodeGenerator()
		{
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();
		}

		#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion
	

		[WebMethod]
		public  byte[] Code39(string code, int barSize, bool showCodeString, string title)
		{

			Barcodes.Code39 c39=new Barcodes.Code39();

			// Create stream....
			MemoryStream ms = new MemoryStream();
			c39.FontFamilyName=ConfigurationSettings.AppSettings["BarCodeFontFamily"];
			c39.FontFileName=ConfigurationSettings.AppSettings["BarCodeFontFile"];
			c39.FontSize=barSize;
			c39.ShowCodeString=showCodeString;
			if (title+""!="")
				c39.Title=title;
			Bitmap objBitmap=c39.GenerateBarcode(code);
			objBitmap.Save(ms ,ImageFormat.Png); 
 
			//return bytes....
			return ms.GetBuffer();			
		}
	}
}
