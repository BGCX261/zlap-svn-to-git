using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace dataaccess.list
{
    public class ContactManager
    {
        SqlDataAdapter sqlda;
        public ContactManager()
        {
            sqlda = new SqlDataAdapter();
        }
        public  DataSet ContactSelectAll()
        {
            DataSet ds = new DataSet();
            try
            {
                //w_product_id_type
                string sqlselect = "";
                sqlselect = "select * from v_web_contact_select_all order by groupid,sort,id";
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
        public DataSet ContactSelectAll(string groupid)
        {
            DataSet ds = new DataSet();
            try
            {
                //w_product_id_type
                string sqlselect = "";
                sqlselect = "select * from v_web_contact_select_all where groupid=" + groupid + " order by sort,id";
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
        //Admin:
        public DataSet GroupContactSelectAll()
        {
            DataSet ds = new DataSet();
            try
            {
                //w_product_id_type
                string sqlselect = "";
                sqlselect = "select * from w_typecontact order by sort";
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
        public DataSet GroupContactSelectIdName(int id, string name)
        {
            //w_type_contact_select_id_name
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_type_contact_select_id_name", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = id;
                prmcols.Add(new SqlParameter("@name", SqlDbType.NVarChar, 128));
                prmcols["@name"].Value = name;
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
        public Boolean GroupContactInsert(string name, int sort)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_type_contact_insert", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@name", SqlDbType.NVarChar, 128));
                prmcols["@name"].Value = name;
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
        public Boolean GroupContactUpdate(int id,string name, int sort)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_type_contact_update", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = id;
                prmcols.Add(new SqlParameter("@name", SqlDbType.NVarChar, 128));
                prmcols["@name"].Value = name;
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
        public Boolean GroupContactDelete(string id)
        {
            try
            {
                DataSet ds = new DataSet();
                string sqlselect = "";
                sqlselect = "delete from w_typecontact where id=" + id;
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
        public DataSet LocationContactSelectAll()
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select * from w_locationcontact";
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
        public DataSet LocationContactSelectIdName(int id, string name)
        {
            //w_type_contact_select_id_name
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_location_contact_select_id_name", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = id;
                prmcols.Add(new SqlParameter("@name", SqlDbType.NVarChar, 128));
                prmcols["@name"].Value = name;
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
        public Boolean LocationContactInsert(string name)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_location_contact_insert", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@name", SqlDbType.NVarChar, 128));
                prmcols["@name"].Value = name;
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
        public Boolean LocationContactUpdate(int id, string name)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_location_contact_update", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = id;
                prmcols.Add(new SqlParameter("@name", SqlDbType.NVarChar, 128));
                prmcols["@name"].Value = name;
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
        public Boolean LocationContactDelete(string id)
        {
            try
            {
                DataSet ds = new DataSet();
                string sqlselect = "";
                sqlselect = "delete from w_locationcontact where id=" + id;
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
        public DataSet ContactAdminSelectAll()
        {
            DataSet ds = new DataSet();
            try
            {
                //w_product_id_type
                string sqlselect = "";
                sqlselect = "select * from w_contact";
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
        public DataSet ContactAdminSelectIdName(int id, string name)
        {
            //w_contact_admin_select_id_name
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_contact_admin_select_id_name", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = id;
                prmcols.Add(new SqlParameter("@name", SqlDbType.NVarChar, 128));
                prmcols["@name"].Value = name;
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
        public Boolean ContactAdminInsert(int idlocation, int idtype, string name, string des, string address, string urlImage, string timeservice, string phone, string delegate1, string email, string fax,int groupid)
        {
            //w_contact_insert:
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_contact_insert", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@idlocation", SqlDbType.Int, 4));
                prmcols["@idlocation"].Value = idlocation;

                prmcols.Add(new SqlParameter("@idtype", SqlDbType.Int, 4));
                prmcols["@idtype"].Value = idtype;

                prmcols.Add(new SqlParameter("@name", SqlDbType.NVarChar, 128));
                prmcols["@name"].Value = name;

                prmcols.Add(new SqlParameter("@des", SqlDbType.NVarChar, 500));
                prmcols["@des"].Value = des;

                prmcols.Add(new SqlParameter("@address", SqlDbType.NVarChar, 255));
                prmcols["@address"].Value = address;

                prmcols.Add(new SqlParameter("@urlImage", SqlDbType.VarChar, 128));
                prmcols["@urlImage"].Value = urlImage;

                prmcols.Add(new SqlParameter("@timeservice", SqlDbType.NVarChar, 255));
                prmcols["@timeservice"].Value = timeservice;

                prmcols.Add(new SqlParameter("@phone", SqlDbType.NVarChar, 255));
                prmcols["@phone"].Value = phone;

                prmcols.Add(new SqlParameter("@delegate", SqlDbType.NVarChar, 64));
                prmcols["@delegate"].Value = delegate1;

                prmcols.Add(new SqlParameter("@email", SqlDbType.VarChar, 128));
                prmcols["@email"].Value = email;

                prmcols.Add(new SqlParameter("@fax", SqlDbType.VarChar, 128));
                prmcols["@fax"].Value = fax;

                prmcols.Add(new SqlParameter("@groupid", SqlDbType.Int, 4));
                prmcols["@groupid"].Value = groupid;
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
        public Boolean ContactAdminUpdate(int id, int idlocation, int idtype, string name, string des, string address, string urlImage, string timeservice, string phone, string delegate1, string email, string fax)
        {
            //w_contact_insert:
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_contact_update", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;

                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = id;

                prmcols.Add(new SqlParameter("@idlocation", SqlDbType.Int, 4));
                prmcols["@idlocation"].Value = idlocation;

                prmcols.Add(new SqlParameter("@idtype", SqlDbType.Int, 4));
                prmcols["@idtype"].Value = idtype;

                prmcols.Add(new SqlParameter("@name", SqlDbType.NVarChar, 128));
                prmcols["@name"].Value = name;

                prmcols.Add(new SqlParameter("@des", SqlDbType.NVarChar, 500));
                prmcols["@des"].Value = des;

                prmcols.Add(new SqlParameter("@address", SqlDbType.NVarChar, 255));
                prmcols["@address"].Value = address;

                prmcols.Add(new SqlParameter("@urlImage", SqlDbType.VarChar, 128));
                prmcols["@urlImage"].Value = urlImage;

                prmcols.Add(new SqlParameter("@timeservice", SqlDbType.NVarChar, 255));
                prmcols["@timeservice"].Value = timeservice;

                prmcols.Add(new SqlParameter("@phone", SqlDbType.NVarChar, 255));
                prmcols["@phone"].Value = phone;

                prmcols.Add(new SqlParameter("@delegate", SqlDbType.NVarChar, 64));
                prmcols["@delegate"].Value = delegate1;

                prmcols.Add(new SqlParameter("@email", SqlDbType.VarChar, 128));
                prmcols["@email"].Value = email;

                prmcols.Add(new SqlParameter("@fax", SqlDbType.VarChar, 128));
                prmcols["@fax"].Value = fax;
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
        public Boolean ContactAdminDelete(string id)
        {
            try
            {
                DataSet ds = new DataSet();
                string sqlselect = "";
                sqlselect = "delete from w_contact where id=" + id;
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
