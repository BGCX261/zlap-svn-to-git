using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for CmanagerAdmin
/// </summary>
public class CmanagerAdmin
{
	SqlDataAdapter sqlda;
    public CmanagerAdmin()
    {
        sqlda = new SqlDataAdapter();
    }
    public DataSet AdminSelectUsernamePass(string username,string pass)
    {
        DataSet ds = new DataSet();
        try
        {
            string sqlselect = "select * from accountadmin where username='" + username + "' and pass='" + pass + "'";
            SqlConnection con = new SqlConnection(Cconnect.connect);
            SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
            da.Fill(ds);
            con.Close();
        }
        catch (Exception ex)
        {
            Console.Write(ex.ToString());
        }
        return ds;
    }
    public DataSet AdminSelectLevel(int level,string idtinh)
    {
        DataSet ds = new DataSet();
        try
        {
            string sqlselect = "";
            if (idtinh.Length > 0)
            {
                sqlselect = "select * from accountadmin where userlevel=" + level + " and idtinh='" + idtinh + "'";
            }
            else
            {
                sqlselect = "select * from accountadmin where userlevel=" + level;
            }
            SqlConnection con = new SqlConnection(Cconnect.connect);
            SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
            da.Fill(ds);
            con.Close();
        }
        catch (Exception ex)
        {
            Console.Write(ex.ToString());
        }
        return ds;
    }
}
