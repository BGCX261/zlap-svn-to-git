using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Diagnostics;


namespace BarCodeClient
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMain: System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btGenerate;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtFontSize;
		private System.Windows.Forms.TextBox txtTitle;
		private System.Windows.Forms.TextBox txtCode;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.PictureBox pictBox;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBar statbar;
		private System.Windows.Forms.CheckBox chkBoxShowBarcode;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btGenerate = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtFontSize = new System.Windows.Forms.TextBox();
			this.txtTitle = new System.Windows.Forms.TextBox();
			this.txtCode = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.chkBoxShowBarcode = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.pictBox = new System.Windows.Forms.PictureBox();
			this.statbar = new System.Windows.Forms.StatusBar();
			this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
			this.SuspendLayout();
			// 
			// btGenerate
			// 
			this.btGenerate.Location = new System.Drawing.Point(464, 16);
			this.btGenerate.Name = "btGenerate";
			this.btGenerate.Size = new System.Drawing.Size(112, 24);
			this.btGenerate.TabIndex = 2;
			this.btGenerate.Text = "Generate Barcode";
			this.btGenerate.Click += new System.EventHandler(this.btGenerate_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.chkBoxShowBarcode,
																					this.label3,
																					this.txtFontSize,
																					this.txtTitle,
																					this.txtCode,
																					this.label2,
																					this.label1});
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(448, 120);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Barcode Parameters";
			// 
			// txtFontSize
			// 
			this.txtFontSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtFontSize.Location = new System.Drawing.Point(368, 56);
			this.txtFontSize.Name = "txtFontSize";
			this.txtFontSize.Size = new System.Drawing.Size(24, 20);
			this.txtFontSize.TabIndex = 13;
			this.txtFontSize.Text = "30";
			// 
			// txtTitle
			// 
			this.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtTitle.Location = new System.Drawing.Point(72, 24);
			this.txtTitle.Name = "txtTitle";
			this.txtTitle.Size = new System.Drawing.Size(336, 20);
			this.txtTitle.TabIndex = 12;
			this.txtTitle.Text = "Centralbiz...";
			// 
			// txtCode
			// 
			this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtCode.Location = new System.Drawing.Point(72, 56);
			this.txtCode.Name = "txtCode";
			this.txtCode.Size = new System.Drawing.Size(176, 20);
			this.txtCode.TabIndex = 9;
			this.txtCode.Text = "123456";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 11;
			this.label2.Text = "Top Label :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 10;
			this.label1.Text = "Bar Code:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(264, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 16);
			this.label3.TabIndex = 14;
			this.label3.Text = "Barcode (Bar) Size:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// chkBoxShowBarcode
			// 
			this.chkBoxShowBarcode.Checked = true;
			this.chkBoxShowBarcode.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkBoxShowBarcode.Location = new System.Drawing.Point(72, 88);
			this.chkBoxShowBarcode.Name = "chkBoxShowBarcode";
			this.chkBoxShowBarcode.Size = new System.Drawing.Size(152, 24);
			this.chkBoxShowBarcode.TabIndex = 15;
			this.chkBoxShowBarcode.Text = "Show Barcode String";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.pictBox});
			this.groupBox2.Location = new System.Drawing.Point(8, 136);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(568, 136);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Result Barcode Image";
			// 
			// pictBox
			// 
			this.pictBox.Location = new System.Drawing.Point(16, 24);
			this.pictBox.Name = "pictBox";
			this.pictBox.Size = new System.Drawing.Size(536, 104);
			this.pictBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictBox.TabIndex = 1;
			this.pictBox.TabStop = false;
			// 
			// statbar
			// 
			this.statbar.Location = new System.Drawing.Point(0, 280);
			this.statbar.Name = "statbar";
			this.statbar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																					   this.statusBarPanel1});
			this.statbar.Size = new System.Drawing.Size(584, 22);
			this.statbar.TabIndex = 11;
			// 
			// statusBarPanel1
			// 
			this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusBarPanel1.Text = "statusBarPanel1";
			// 
			// frmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(584, 302);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.statbar,
																		  this.groupBox2,
																		  this.btGenerate,
																		  this.groupBox1});
			this.Name = "frmMain";
			this.Text = "WS Barcode Generator client";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmMain());
		}

		private void btGenerate_Click(object sender, System.EventArgs e)
		{
			GenerateBarCode();
		}

		private void GenerateBarCode()
		{
			this.Cursor=Cursors.WaitCursor;
			statbar.Panels[0].Text="Generating barcode...";


			WSBarcodeGenerator.BarCodeGenerator barCodeGen=new WSBarcodeGenerator.BarCodeGenerator();
			
			int barSize=System.Convert.ToInt32(txtFontSize.Text);

			System.Byte[] imgBarcode=barCodeGen.Code39(txtCode.Text, barSize, chkBoxShowBarcode.Checked ,  txtTitle.Text);
			
			MemoryStream memStream = new MemoryStream(imgBarcode); 			
			
			pictBox.Image=new Bitmap(memStream);

			statbar.Panels[0].Text="Done.";
			this.Cursor=Cursors.Default;
		}



	}
}
