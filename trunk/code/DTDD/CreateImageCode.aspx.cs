using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Drawing.Imaging;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using framework.list.common;
using System.Drawing;
//using BarcodeLib;
public partial class CreateImageCode : System.Web.UI.Page
{
    private void Page_Load(object sender, System.EventArgs e)
    {
        if (Session["RamDomCodeRegister"] == null)
        {
            Session["RamDomCodeRegister"] = "ab467";
        }
        CreateImageRandom ci = new CreateImageRandom(Session["RamDomCodeRegister"].ToString(), 100, 32, "");
        this.Response.Clear();
        this.Response.ContentType = "image/jpeg";
        ci.Image.Save(this.Response.OutputStream, ImageFormat.Jpeg);
        //ci.Dispose();
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
        this.Load += new System.EventHandler(this.Page_Load);
    }
    #endregion
}
