using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public class Cconnect
{
    public static string connect = "server=(local); user id=sa; password=sa; database=manageaccount; min pool size=10; max pool size=250";
    public Cconnect()
	{
		
	}
}
