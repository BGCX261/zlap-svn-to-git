using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace dataaccess.list
{
    public class ProductType
    {
        SqlDataAdapter sqlda;
        public ProductType()
        {
            sqlda = new SqlDataAdapter();
        }
        public DataSet GetGroupProduct()
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "select id,othername,name from tbl_producttype where cansales=1 order by id";
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds);
                con.Close();
            
            }catch
            {
                ds = null;
            }
            return ds;
        }
    }
}
