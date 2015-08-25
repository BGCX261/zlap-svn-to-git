using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace dataaccess.list
{
    public class advertisemanager
    {
        SqlDataAdapter sqlda;
        public advertisemanager()
        {
            sqlda = new SqlDataAdapter();
        }
        public DataSet AdvertiseSelectAll()
        {
            DataSet ds = new DataSet();
            try
            {
                //w_product_id_type
                string sqlselect = "";
                sqlselect = "select title,link,urlImage from w_advertise where show=1 order by sort";
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
        public DataSet AdvertiseAdminSelectAll()
        {
            DataSet ds = new DataSet();
            try
            {
                //w_product_id_type
                string sqlselect = "";
                sqlselect = "select * from w_advertise order by sort";
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
        public Boolean AdvertiseInsert(string title, int sort, string link, string image, string ishow, string note)
        {
            //w_articles_insert
            Boolean test = true;
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_advertise_insert", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;

                prmcols.Add(new SqlParameter("@title", SqlDbType.NVarChar, 128));
                prmcols["@title"].Value = title;

                prmcols.Add(new SqlParameter("@sort", SqlDbType.Int, 4));
                prmcols["@sort"].Value = sort;

                prmcols.Add(new SqlParameter("@link", SqlDbType.VarChar, 255));
                prmcols["@link"].Value = link;

                prmcols.Add(new SqlParameter("@image", SqlDbType.VarChar, 128));
                prmcols["@image"].Value = image;

                prmcols.Add(new SqlParameter("@show", SqlDbType.VarChar, 1));
                prmcols["@show"].Value = ishow;

                prmcols.Add(new SqlParameter("@note", SqlDbType.NVarChar, 255));
                prmcols["@note"].Value = note;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                test = false;
            }
            return test;
        }
        public Boolean AdvertiseUpdate(int id, string title, int sort, string link, string image, string ishow, string note)
        {
            //w_articles_insert
            Boolean test = true;
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_advertise_update", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;

                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = id;
                prmcols.Add(new SqlParameter("@title", SqlDbType.NVarChar, 128));
                prmcols["@title"].Value = title;

                prmcols.Add(new SqlParameter("@sort", SqlDbType.Int, 4));
                prmcols["@sort"].Value = sort;

                prmcols.Add(new SqlParameter("@link", SqlDbType.VarChar, 255));
                prmcols["@link"].Value = link;

                prmcols.Add(new SqlParameter("@image", SqlDbType.VarChar, 128));
                prmcols["@image"].Value = image;

                prmcols.Add(new SqlParameter("@show", SqlDbType.VarChar, 1));
                prmcols["@show"].Value = ishow;

                prmcols.Add(new SqlParameter("@note", SqlDbType.NVarChar, 255));
                prmcols["@note"].Value = note;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                test = false;
            }
            return test;
        }
        public Boolean AdvertiseDelete(string id)
        {
            Boolean test = true;
            try
            {
                string sqlselect = "";
                DataSet ds = new DataSet();
                sqlselect = "Delete from w_advertise where id=" + id;
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                sqlda = new SqlDataAdapter(sqlselect, con);
                sqlda.Fill(ds);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                test = false;
            }
            return test;
        }
        public DataSet AdvertiseSelectId(string id)
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";

                sqlselect = "select * from w_advertise where id=" + id;
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
        //For Advertise Special:
        public DataSet SpecialIdbrand(string idbrand, int type)
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select top 3 Id,Title,UrlImage1,UrlImage2,Link from w_AdvertiseSpecial where idBrand=" + idbrand + " and type=" + type + " order by sort";
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
        public DataSet SpecialSelectWhere(string where)
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select Id,Title,UrlImage1,UrlImage2,Link from w_AdvertiseSpecial " + where + " order by sort";
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
        public DataSet SpecialAll()
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select Id,Title,UrlImage1,UrlImage2,Link from w_AdvertiseSpecial order by sort";
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
        public DataSet SpecialAdminAll()
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select * from w_AdvertiseSpecial order by sort";
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
        public DataSet SpecialSelectId(int id)
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select * from w_AdvertiseSpecial where id=" + id;
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
        public Boolean SpecialInsert(int idbrand, string title, string content, string Url1, string Url2, string link, int sort, int type)
        {
            Boolean test = true;
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_advertise_special_insert", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;

                prmcols.Add(new SqlParameter("@idbrand", SqlDbType.Int, 4));
                prmcols["@idbrand"].Value = idbrand;

                prmcols.Add(new SqlParameter("@title", SqlDbType.NVarChar, 128));
                prmcols["@title"].Value = title;

                prmcols.Add(new SqlParameter("@content", SqlDbType.NVarChar, 255));
                prmcols["@content"].Value = content;

                prmcols.Add(new SqlParameter("@urlimage1", SqlDbType.VarChar, 128));
                prmcols["@urlimage1"].Value = Url1;

                prmcols.Add(new SqlParameter("@urlimage2", SqlDbType.VarChar, 128));
                prmcols["@urlimage2"].Value = Url2;

                prmcols.Add(new SqlParameter("@link", SqlDbType.VarChar, 255));
                prmcols["@link"].Value = link;

                prmcols.Add(new SqlParameter("@sort", SqlDbType.SmallInt, 2));
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
                test = false;
            }
            return test;
        }
        public Boolean SpecialUpdate(int id, int idbrand, string title, string content, string Url1, string Url2, string link, int sort)
        {
            Boolean test = true;
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_advertise_special_update", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;

                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = id;

                prmcols.Add(new SqlParameter("@idbrand", SqlDbType.Int, 4));
                prmcols["@idbrand"].Value = idbrand;

                prmcols.Add(new SqlParameter("@title", SqlDbType.NVarChar, 128));
                prmcols["@title"].Value = title;

                prmcols.Add(new SqlParameter("@content", SqlDbType.NVarChar, 255));
                prmcols["@content"].Value = content;

                prmcols.Add(new SqlParameter("@urlimage1", SqlDbType.VarChar, 128));
                prmcols["@urlimage1"].Value = Url1;

                prmcols.Add(new SqlParameter("@urlimage2", SqlDbType.VarChar, 128));
                prmcols["@urlimage2"].Value = Url2;

                prmcols.Add(new SqlParameter("@link", SqlDbType.VarChar, 255));
                prmcols["@link"].Value = link;

                prmcols.Add(new SqlParameter("@sort", SqlDbType.SmallInt, 2));
                prmcols["@sort"].Value = sort;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                test = false;
            }
            return test;
        }
        public Boolean SpecialDelete(string id)
        {
            Boolean test = true;
            try
            {
                DataSet ds = new DataSet();
                string sqlselect = "";
                sqlselect = "Delete w_AdvertiseSpecial where id=" + id;
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                test = false;
            }
            return test;
        }
    }
}
