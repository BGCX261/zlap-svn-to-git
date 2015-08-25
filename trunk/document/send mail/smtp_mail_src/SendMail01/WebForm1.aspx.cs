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
using System.Web.Mail;
using System.Configuration;

namespace WebApplication1
{
	/// <summary>
	/// -------------------------------------------------------------------------
	/// ---- SendMail01 - Send e-mails using a smtp-server ----------------------
	/// ---- Idea and Coding: Miro Grenda alias eightfour -----------------------
	/// ---- dev@eightfour.de - www.csharp-board.de -----------------------------
	/// -------------------------------------------------------------------------
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TextBoxFrom;
		protected System.Web.UI.WebControls.TextBox TextBoxSubject;
		protected System.Web.UI.WebControls.TextBox TextBoxTo;
		protected System.Web.UI.WebControls.TextBox TextBoxCc;
		protected System.Web.UI.WebControls.TextBox TextBoxBcc;
		protected System.Web.UI.WebControls.Button ButtonSubmit;
		protected System.Web.UI.WebControls.TextBox TextBoxBody;

		private void Page_Load(object sender, System.EventArgs e)
		{
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: Dieser Aufruf ist für den ASP.NET Web Form-Designer erforderlich.
			//
			InitializeComponent();
			base.OnInit(e);
		}

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this.ButtonSubmit.Click += new System.EventHandler(this.ButtonSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

		protected void ButtonSubmit_Click(object sender, System.EventArgs e)
		{
			Server.ScriptTimeout = 1000;
			Response.Flush();

			SmtpMail.SmtpServer = "localhost"; 
			MailMessage mail = new MailMessage();
			mail.To = this.TextBoxTo.Text;
			mail.Cc = this.TextBoxCc.Text;
			mail.Bcc = this.TextBoxBcc.Text;
			mail.From = this.TextBoxFrom.Text;
			mail.Subject = this.TextBoxSubject.Text;
			mail.Body = this.TextBoxBody.Text;
			
			try
			{
				SmtpMail.Send(mail);
				Response.Write("<p><strong> The Mail has been sent to: </strong></p>");
				Response.Write("&bull; To:&nbsp;&nbsp;&nbsp;" + mail.To + "</br>");
				Response.Write("&bull; Cc:&nbsp;&nbsp;&nbsp;" + mail.Cc + "</br>");
				Response.Write("&bull; Bcc:&nbsp;&nbsp;" + mail.Bcc + "</br>");
			}
			catch(System.Exception ex)
			{
				Response.Write("<p><strong>An erros has occured: " + ex.Message + "</strong><p>");
			}			
			
			Response.Flush();		
		}
	}
}