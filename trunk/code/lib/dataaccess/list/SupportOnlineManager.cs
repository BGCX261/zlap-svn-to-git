using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
namespace dataaccess.list
{
    public class SupportOnlineManager
    {
        SqlDataAdapter sqlda;
        public SupportOnlineManager()
        {
            sqlda = new SqlDataAdapter();
        }
        public DataSet OnlineSelectAll(string type)
        {
            DataSet ds = new DataSet();
            try
            {
                //w_product_id_type
                string sqlselect = "";
                sqlselect = "select name,nickname,title,idgroup,namegroup from w_supportonline where typeid=" + type + " order by idgroup,sort";
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
        public DataSet OnlineAdminSelectAll()
        {
            DataSet ds = new DataSet();
            try
            {
                //w_product_id_type
                string sqlselect = "";
                sqlselect = "select * from w_supportonline order by typeid,idgroup,sort";
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
        public DataSet OnlineSelectId(string id)
        {
            DataSet ds = new DataSet();
            try
            {
                //w_product_id_type
                string sqlselect = "";
                sqlselect = "select * from w_supportonline where id=" + id;
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
        public Boolean OnlineInsert(string name, string nickname, string title, int idgroup, string namegroup, int sort, int type)
        {
            //w_support_online_insert
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_support_online_insert", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@name", SqlDbType.NVarChar, 64));
                prmcols["@name"].Value = name;
                prmcols.Add(new SqlParameter("@nickname", SqlDbType.VarChar, 64));
                prmcols["@nickname"].Value = nickname;
                prmcols.Add(new SqlParameter("@title", SqlDbType.NVarChar, 64));
                prmcols["@title"].Value = title;
                prmcols.Add(new SqlParameter("@idgroup", SqlDbType.Int, 4));
                prmcols["@idgroup"].Value = idgroup;
                prmcols.Add(new SqlParameter("@namegroup", SqlDbType.NVarChar, 64));
                prmcols["@namegroup"].Value = namegroup;
                prmcols.Add(new SqlParameter("@sort", SqlDbType.Int, 4));
                prmcols["@sort"].Value = sort;
                prmcols.Add(new SqlParameter("@type", SqlDbType.Int, 4));
                prmcols["@type"].Value = type;
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
        public Boolean OnlineUpdate(int id, string name, string nickname, string title, int idgroup, string namegroup, int sort)
        {
            //w_support_online_update
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_support_online_update", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = id;
                prmcols.Add(new SqlParameter("@name", SqlDbType.NVarChar, 64));
                prmcols["@name"].Value = name;
                prmcols.Add(new SqlParameter("@nickname", SqlDbType.VarChar, 64));
                prmcols["@nickname"].Value = nickname;
                prmcols.Add(new SqlParameter("@title", SqlDbType.NVarChar, 64));
                prmcols["@title"].Value = title;
                prmcols.Add(new SqlParameter("@idgroup", SqlDbType.Int, 4));
                prmcols["@idgroup"].Value = idgroup;
                prmcols.Add(new SqlParameter("@namegroup", SqlDbType.NVarChar, 64));
                prmcols["@namegroup"].Value = namegroup;
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
        public Boolean OnlineDelete(string id)
        {
            try
            {
                DataSet ds = new DataSet();
                string sqlselect = "";
                sqlselect = "delete from w_supportonline where id=" + id;
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
