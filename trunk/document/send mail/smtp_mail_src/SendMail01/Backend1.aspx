<%@ Page Language="C#" Debug="true" %>
<% @Import Namespace="System.Data" %>
<% @Import Namespace="System.Data.OleDb" %>
<% @Import Namespace="System.Web.Mail" %>
<script runat="server">

void form_PreRender(object sender, EventArgs e)
{
 if(!IsPostBack)
 {
  HtmlForm form = (HtmlForm) sender;
  form.Attributes["onsubmit"] += "return(confirm('Sind Sie sicher, dass Sie fortfahren möchten?'));";
 }
}

void btsend_click(object sender, EventArgs e)
{
 ph1.Visible = false;
 Server.ScriptTimeout = 1000;
 Response.Write("<p><b> Der Newsletter wird versandt. Bitte warten! </b></p>");
 Response.Flush();

/*
 OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" +
  @"Data Source=c:\inetpub\wwwroot\aspnet\community.mdb");
 conn.Open();

 string SQL = "SELECT * FROM Newsletter WHERE Authenticated=-1;";
 OleDbCommand cmd = new OleDbCommand(SQL, conn);
 OleDbDataReader reader = cmd.ExecuteReader();

 while(reader.Read())
 {
  MailMessage mail = new MailMessage();
  mail.To = (string) reader["Email"];
  mail.From = tb_from.Text;
  mail.Subject = tb_subject.Text;

  string body = tb_body.Text;
  for(int i=0; i<reader.FieldCount; i++)
   body = body.Replace("<" + reader.GetName(i) + ">", reader.GetValue(i).ToString());

  mail.Body = body;
  SmtpMail.Send(mail);

  Response.Write("&bull; " + reader["Email"] + "<br>");
  Response.Flush();
 }

 reader.Close();
 conn.Close();
*/

 MailMessage mail = new MailMessage();
 mail.To = "miro.grenda@beb-gmbh.de";
 mail.From = tb_from.Text;
 mail.Subject = tb_subject.Text;
 
 string body = tb_body.Text;
 
 mail.Body = body;
 SmtpMail.Send(mail);
 
 Response.Write("&bull; " + mail.To + "</br>");
 Response.Flush();
}

</script>
<form runat="server" OnPreRender="form_PreRender">
	<ASP:PlaceHolder id="ph1" runat="server">
		<h1>Newsletter-Versand (Backend)</h1>
		<p>
			Bitte geben Sie die notwendigen Daten zum Versand des Newsletters ein. Sie 
			können die Platzhalter &lt;Title&gt;, &lt;Firstname&gt;, &lt;Lastname&gt; und 
			&lt;Email&gt; verwenden.
		</p>
		<table>
			<tr>
				<td>Absender:</td>
				<td>
					<ASP:TextBox id="tb_from" runat="server" />
				</td>
			</tr>
			<tr>
				<td>Betreff:</td>
				<td>
					<ASP:TextBox id="tb_subject" runat="server" />
				</td>
			</tr>
			<tr>
				<td valign="top">Text:</td>
				<td>
					<ASP:TextBox id="tb_body" runat="server" TextMode="Multiline" Width="400" Height="200" />
				</td>
			</tr>
		</table>
		<p>
			<ASP:Button runat="server" text="Absenden" onclick="btsend_click" />
		</p>
	</ASP:PlaceHolder>
</form>
