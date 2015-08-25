<%@ Page language="c#" Codebehind="WebForm1.aspx.cs" AutoEventWireup="false" Inherits="WebApplication1.WebForm1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SendMail01 - by eightfour (www.csharp-board.de)</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form runat="server" ID="Form2">
			<H1>SendMail01 - by eightfour (www.csharp-board.de)</H1>
			<TABLE>
				<TR>
					<TD>From:</TD>
					<TD>
						<ASP:TextBox id="TextBoxFrom" runat="server" Width="400px"></ASP:TextBox></TD>
				</TR>
				<TR>
					<TD>To:</TD>
					<TD>
						<ASP:TextBox id="TextBoxTo" runat="server" Width="400px"></ASP:TextBox></TD>
				</TR>
				<TR>
					<TD>Cc:</TD>
					<TD>
						<ASP:TextBox id="TextBoxCc" runat="server" Width="400px"></ASP:TextBox></TD>
				</TR>
				<TR>
					<TD>Bcc:</TD>
					<TD>
						<ASP:TextBox id="TextBoxBcc" runat="server" Width="400px"></ASP:TextBox></TD>
				</TR>
				<TR>
					<TD>Subject:</TD>
					<TD>
						<ASP:TextBox id="TextBoxSubject" runat="server" Width="400px"></ASP:TextBox></TD>
				</TR>
				<TR>
					<TD vAlign="top">Body:</TD>
					<TD>
						<ASP:TextBox id="TextBoxBody" runat="server" Height="200" Width="400" TextMode="Multiline"></ASP:TextBox></TD>
				</TR>
			</TABLE>
			<P>
				<ASP:Button id="ButtonSubmit" runat="server" text="Submit Mail"></ASP:Button></P>
		</form>
	</body>
</HTML>
