using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace dataaccess.list
{
    public class ArticlesManager
    {
        SqlDataAdapter sqlda;
        public ArticlesManager()
        {
            sqlda = new SqlDataAdapter();
        }
        public DataSet ArticleGroupSelectAll()
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select Id,Name from w_grouparticle where ishow='1'";
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
        public DataSet ArticleAllSelectFromTo( int from, int to)
        {
            DataSet ds = new DataSet();
            if ((from >= 0) && (to > 0))
            {
                try
                {
                    string sqlselect = "";
                    string table_Name = "v_web_article_select_all";
                    string name_Column_Order_By = "timeupdate";
                    int num_Row_Get = to - from;
                    sqlselect = "SELECT * FROM ( ";
                    sqlselect = sqlselect + "SELECT TOP " + num_Row_Get.ToString();
                    sqlselect = sqlselect + " * FROM( SELECT TOP " + to.ToString() + " id,title,sumarticle,urlimage,timeupdate FROM [" + table_Name + "] where ishowg='1' and ishow='1'";
                    sqlselect = sqlselect + " order by [" + name_Column_Order_By + "] desc) as t1 ";
                    sqlselect = sqlselect + " order by [" + name_Column_Order_By + "] asc) as t2 ";
                    sqlselect = sqlselect + " order by [" + name_Column_Order_By + "] desc ";
                    SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                    SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                    da.Fill(ds, "tbl_artlces");
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                }
            }
            return ds;
        }
        public int ArticleAllCount()
        {
            int num = 0;
            try
            {
                DataSet ds = new DataSet();
                string sqlselect = "";
                sqlselect = "SELECT count(id) as count FROM v_web_article_select_all where ishowg='1' and ishow='1'";
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds,"table");
                con.Close();
                if (ds.Tables.Count > 0)
                {
                    num = (int)ds.Tables[0].Rows[0]["count"];
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return num;
        }
        public int ArticleGroupCount(int idGroup)
        {
            int num = 0;
            try
            {
                DataSet ds = new DataSet();
                string sqlselect = "";
                sqlselect = "SELECT count(id) as count FROM v_web_article_select_all where ishowg='1' and ishow='1' and idgroup=" + idGroup;
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, "table");
                con.Close();
                if (ds.Tables.Count > 0)
                {
                    num = (int)ds.Tables[0].Rows[0]["count"];
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return num;
        }
        public DataSet ArticleGroupSelectFromTo(int idgroup,int from, int to)
        {
            DataSet ds = new DataSet();
            if ((from >= 0) && (to > 0))
            {
                try
                {
                    string sqlselect = "";
                    string table_Name = "v_web_article_select_all";
                    string name_Column_Order_By = "timeupdate";
                    int num_Row_Get = to - from;
                    sqlselect = "SELECT * FROM ( ";
                    sqlselect = sqlselect + "SELECT TOP " + num_Row_Get.ToString();
                    sqlselect = sqlselect + " * FROM( SELECT TOP " + to.ToString() + " id,title,sumarticle,urlimage,timeupdate FROM [" + table_Name + "] where ishowg='1' and ishow='1' and idgroup=" + idgroup;
                    sqlselect = sqlselect + " order by [" + name_Column_Order_By + "] desc) as t1 ";
                    sqlselect = sqlselect + " order by [" + name_Column_Order_By + "] asc) as t2 ";
                    sqlselect = sqlselect + " order by [" + name_Column_Order_By + "] desc ";
                    SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                    SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                    da.Fill(ds, "tbl_artlces");
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                }
            }
            return ds;
        }
        public DataSet ArticleSelectDetail(int id)
        {
            //w_article_select_detail
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_article_select_detail", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = id;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public DataSet ArticleTop()
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "SELECT TOP 14 id,title,urlimage FROM v_web_article_select_all where ishowg='1' and ishow='1' order by timeupdate desc";
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, "tbl_artlces");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        //Administrator group:
        public DataSet AdminGroupAll()
        {

            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select * from w_grouparticle";
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
        public DataSet AdminGroupSelectId(int id, string name)
        {
            //w_group_select_with_id
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_group_select_with_id", con);
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
            }
            return ds;
        }
        public Boolean AdminGroupInsert(string name, string ishow)
        {
            //w_group_update_id
            Boolean test = true;
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_group_insert", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@name", SqlDbType.NVarChar, 128));
                prmcols["@name"].Value = name;
                prmcols.Add(new SqlParameter("@ishow", SqlDbType.VarChar, 1));
                prmcols["@ishow"].Value = ishow;
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
        public Boolean AdminGroupUpdateId(int id, string name, string ishow)
        {
            //w_group_update_id
            Boolean test = true;
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_group_update_id", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = id;
                prmcols.Add(new SqlParameter("@name", SqlDbType.NVarChar, 128));
                prmcols["@name"].Value = name;
                prmcols.Add(new SqlParameter("@ishow", SqlDbType.VarChar, 1));
                prmcols["@ishow"].Value = ishow;
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
        public Boolean AdminGroupDeleteId(string id)
        {
            Boolean test = true;
            try
            {
                string sqlselect = "";
                DataSet ds = new DataSet();
                sqlselect = "Delete from w_grouparticle where id=" + id;
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
        //Administrator Articles:
        public DataSet AdminArticleSelectFromTo(string where, int from, int to)
        {
            DataSet ds = new DataSet();
            if ((from >= 0) && (to > 0))
            {
                try
                {
                    string sqlselect = "";
                    string table_Name = "v_web_article_select_all";
                    string name_Column_Order_By = "timeupdate";
                    int num_Row_Get = to - from;
                    sqlselect = "SELECT * FROM ( ";
                    sqlselect = sqlselect + "SELECT TOP " + num_Row_Get.ToString();
                    sqlselect = sqlselect + " * FROM( SELECT TOP " + to.ToString() + " * FROM [" + table_Name + "] " + where;
                    sqlselect = sqlselect + " order by [" + name_Column_Order_By + "] desc) as t1 ";
                    sqlselect = sqlselect + " order by [" + name_Column_Order_By + "] asc) as t2 ";
                    sqlselect = sqlselect + " order by [" + name_Column_Order_By + "] desc ";
                    SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                    SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                    da.Fill(ds, "tbl_artlces");
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                }
            }
            return ds;
        }
        public int AdminArticleAllCount(string where)
        {
            int num = 0;
            try
            {
                DataSet ds = new DataSet();
                string sqlselect = "";
                sqlselect = "SELECT count(id) as count FROM v_web_article_select_all "+ where;
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, "table");
                con.Close();
                if (ds.Tables.Count > 0)
                {
                    num = (int)ds.Tables[0].Rows[0]["count"];
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return num;
        }
        public DataSet AdminArticleTestExsit(int id, string name)
        {
            //w_article_select_with_id_name
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_article_select_with_id_name", con);
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
            }
            return ds;
        }
        public Boolean AdminArticleInsert(int idgroup, string title, string sum, string content, string image, DateTime time, string source, string link, string ishow)
        {
            //w_articles_insert
            Boolean test = true;
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_articles_insert", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@idgroup", SqlDbType.Int, 4));
                prmcols["@idgroup"].Value = idgroup;

                prmcols.Add(new SqlParameter("@title", SqlDbType.NVarChar, 128));
                prmcols["@title"].Value = title;
                
                prmcols.Add(new SqlParameter("@sum", SqlDbType.NVarChar, 500));
                prmcols["@sum"].Value = sum;

                prmcols.Add(new SqlParameter("@content", SqlDbType.NText));
                prmcols["@content"].Value = content;

                prmcols.Add(new SqlParameter("@image", SqlDbType.VarChar,128));
                prmcols["@image"].Value = image;

                prmcols.Add(new SqlParameter("@time", SqlDbType.DateTime, 8));
                prmcols["@time"].Value = time;

                prmcols.Add(new SqlParameter("@source", SqlDbType.NVarChar, 128));
                prmcols["@source"].Value = source;

                prmcols.Add(new SqlParameter("@link", SqlDbType.NVarChar, 128));
                prmcols["@link"].Value = link;

                prmcols.Add(new SqlParameter("@ishow", SqlDbType.VarChar,1));
                prmcols["@ishow"].Value = ishow;
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
        public Boolean AdminArticleUpdate(int id,int idgroup, string title, string sum, string content, string image, DateTime time, string source, string link, string ishow)
        {
            //w_articles_update
            Boolean test = true;
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_articles_update", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;

                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = id;

                prmcols.Add(new SqlParameter("@idgroup", SqlDbType.Int, 4));
                prmcols["@idgroup"].Value = idgroup;

                prmcols.Add(new SqlParameter("@title", SqlDbType.NVarChar, 128));
                prmcols["@title"].Value = title;

                prmcols.Add(new SqlParameter("@sum", SqlDbType.NVarChar, 500));
                prmcols["@sum"].Value = sum;

                prmcols.Add(new SqlParameter("@content", SqlDbType.NText));
                prmcols["@content"].Value = content;

                prmcols.Add(new SqlParameter("@image", SqlDbType.VarChar, 128));
                prmcols["@image"].Value = image;

                prmcols.Add(new SqlParameter("@time", SqlDbType.DateTime, 8));
                prmcols["@time"].Value = time;

                prmcols.Add(new SqlParameter("@source", SqlDbType.NVarChar, 128));
                prmcols["@source"].Value = source;

                prmcols.Add(new SqlParameter("@link", SqlDbType.NVarChar, 128));
                prmcols["@link"].Value = link;

                prmcols.Add(new SqlParameter("@ishow", SqlDbType.VarChar, 1));
                prmcols["@ishow"].Value = ishow;
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
        public Boolean AdminArticleDelete(string id)
        {
            Boolean test = true;
            try
            {
                string sqlselect = "";
                DataSet ds = new DataSet();
                sqlselect = "Delete from w_articles where id=" + id;
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
        //For Support Buy Laptop:
        public DataSet HelpBuyTopTitle()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_how_buy_laptop_top", con);
                command.CommandType = CommandType.StoredProcedure;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        
        }
        public DataSet HelpBuyAllTitle()
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select Id,title from w_HowBuyLaptop order by timeupdate desc";
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
        public DataSet HelpBuyDetail(string id)
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select * from w_HowBuyLaptop where id=" + id;
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
        public Boolean HelpBuyInsert(string title, string subcontent, string content, string urlimage, string source, string link, DateTime timeupdate)
        {
            //w_articles_insert
            Boolean test = true;
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_whow_buy_laptop_insert", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;

                prmcols.Add(new SqlParameter("@title", SqlDbType.NVarChar, 128));
                prmcols["@title"].Value = title;

                prmcols.Add(new SqlParameter("@subcontent", SqlDbType.NVarChar,400));
                prmcols["@subcontent"].Value = subcontent;

                prmcols.Add(new SqlParameter("@content", SqlDbType.NText));
                prmcols["@content"].Value = content;

                prmcols.Add(new SqlParameter("@urlimage", SqlDbType.VarChar, 128));
                prmcols["@urlimage"].Value = urlimage;

                prmcols.Add(new SqlParameter("@source", SqlDbType.NVarChar, 128));
                prmcols["@source"].Value = source;

                prmcols.Add(new SqlParameter("@link", SqlDbType.VarChar, 255));
                prmcols["@link"].Value = link;

                prmcols.Add(new SqlParameter("@timeupdate", SqlDbType.DateTime, 8));
                prmcols["@timeupdate"].Value = timeupdate;
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
        public Boolean HelpBuyUpdate(int id,string title, string subcontent, string content, string urlimage, string source, string link, DateTime timeupdate)
        {
            //w_articles_insert
            Boolean test = true;
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_whow_buy_laptop_update", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;

                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = id;
                
                prmcols.Add(new SqlParameter("@title", SqlDbType.NVarChar, 128));
                prmcols["@title"].Value = title;

                prmcols.Add(new SqlParameter("@subcontent", SqlDbType.NVarChar, 400));
                prmcols["@subcontent"].Value = subcontent;

                prmcols.Add(new SqlParameter("@content", SqlDbType.NText));
                prmcols["@content"].Value = content;

                prmcols.Add(new SqlParameter("@urlimage", SqlDbType.VarChar, 128));
                prmcols["@urlimage"].Value = urlimage;

                prmcols.Add(new SqlParameter("@source", SqlDbType.NVarChar, 128));
                prmcols["@source"].Value = source;

                prmcols.Add(new SqlParameter("@link", SqlDbType.VarChar, 255));
                prmcols["@link"].Value = link;

                prmcols.Add(new SqlParameter("@timeupdate", SqlDbType.DateTime, 8));
                prmcols["@timeupdate"].Value = timeupdate;
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
        public Boolean HelpBuyDeleteId(string id)
        {

            Boolean test = true;
            try
            {
                DataSet ds = new DataSet();
                string sqlselect = "";
                sqlselect = "delete from w_HowBuyLaptop where id=" + id;
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
    }
}
