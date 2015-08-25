using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace dataaccess.list
{
    public class HelpsManager
    {
        //select * from w_helps order by sort
        SqlDataAdapter sqlda;
        public HelpsManager()
        {
            sqlda = new SqlDataAdapter();
        }
        public DataSet HelpsSelectAll()
        {
            DataSet ds = new DataSet();
            try
            {
                //w_product_id_type
                string sqlselect = "";
                sqlselect = "select * from w_helps order by sort";
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
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
        public DataSet HelpsSelectIdName(int id, string name)
        {
            //w_helps_select_id_name
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_helps_select_id_name", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = id;
                prmcols.Add(new SqlParameter("@title", SqlDbType.NVarChar, 128));
                prmcols["@title"].Value = name;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return ds;
            }
            return ds;
        }
        public Boolean HelpsInsert(string name, string content, int sort)
        { 
            //insert:
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_help_insert", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@title", SqlDbType.NVarChar, 128));
                prmcols["@title"].Value = name;
                prmcols.Add(new SqlParameter("@content", SqlDbType.NText));
                prmcols["@content"].Value = content;
                prmcols.Add(new SqlParameter("@sort", SqlDbType.Int, 4));
                prmcols["@sort"].Value = sort;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return false;
            }
            return true;
        }
        public Boolean HelpsUpdate(int id, string name, string content, int sort)
        {
            //insert:
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_help_update", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = id;
                prmcols.Add(new SqlParameter("@title", SqlDbType.NVarChar, 128));
                prmcols["@title"].Value = name;
                prmcols.Add(new SqlParameter("@content", SqlDbType.NText));
                prmcols["@content"].Value = content;
                prmcols.Add(new SqlParameter("@sort", SqlDbType.Int, 4));
                prmcols["@sort"].Value = sort;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return false;
            }
            return true;
        }
        public Boolean HelpsDelete(string id)
        {
            try
            {
                DataSet ds = new DataSet();
                string sqlselect = "";
                sqlselect = "delete from w_helps where id=" + id;
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return false;
            }
            return true;
        }
    }
}
