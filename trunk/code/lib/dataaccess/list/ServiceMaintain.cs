using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace dataaccess.list
{
    public class ServiceMaintain
    {
         SqlDataAdapter sqlda;
        public ServiceMaintain()
        {
            sqlda = new SqlDataAdapter();
        }
        public DataSet ServiceMaintainAll()
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select id,title from w_servicemaintain order by sort";
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                sqlda = new SqlDataAdapter(sqlselect, con);
                sqlda.Fill(ds);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
    }
}
