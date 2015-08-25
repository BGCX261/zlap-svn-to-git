using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using common.list;
namespace dataaccess.list
{
    public class ProductMainPage
    {
        SqlDataAdapter sqlda;
        public ProductMainPage()
        {
            sqlda = new SqlDataAdapter();
        }
        public DataSet MainPageSelectAll()
        {
            //w_select_in_mainpage
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_select_in_mainpage", con);
                command.CommandType = CommandType.StoredProcedure;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds, "main");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public DataSet MainPageSelectAll2()
        {
            //w_select_in_mainpage
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_select_in_mainpage_2", con);
                command.CommandType = CommandType.StoredProcedure;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds, "main");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public  ProductMainPage_data ProductMainPageAll()
        {
            ProductMainPage_data ds = new ProductMainPage_data();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_product_mainpage", con);
                command.CommandType = CommandType.StoredProcedure;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds, ProductMainPage_data._table);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public DataSet ProductChoiceMainpageFromTo(string where, int from, int to)
        {
            DataSet ds = new DataSet();
            try
            {
                //w_product_for_quick_search
                string sqlselect = "";
                int num_Row_Get = to - from;
                sqlselect = "SELECT * FROM ( ";
                sqlselect = sqlselect + "SELECT TOP " + num_Row_Get.ToString();
                sqlselect = sqlselect + " * FROM( SELECT TOP " + to.ToString() + " id,brandid,brand,name,urlimage,sellingprice,warrantymonth,note,idproduct from v_web_product_choice_mainpage " + where;
                sqlselect = sqlselect + " order by SellingPrice asc,brand asc,Id asc) as t1 ";
                sqlselect = sqlselect + " order by SellingPrice desc,brand desc,Id desc) as t2 ";
                sqlselect = sqlselect + " order by SellingPrice asc,brand asc,Id asc";
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, "ChoiceBestsell");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public int ProductCountChoiceMainpage(string where)
        {
            int num = 0;
            DataSet ds = new DataSet();
            try
            {
                //w_product_for_quick_search
                string sqlselect = "";
                sqlselect = sqlselect + "SELECT count(id)as count from v_web_product_choice_mainpage " + where;
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds);
                con.Close();
                if (ds.Tables.Count > 0)
                {
                    num = int.Parse(ds.Tables[0].Rows[0]["count"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return num;
        }
        public Boolean ProductMainpageUpdate(int idpro, int type, int sort)
        {
            //w_product_best_sell_update:
            Boolean test = true;
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_product_mainpage_update", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = idpro;
                prmcols.Add(new SqlParameter("@type", SqlDbType.Int, 4));
                prmcols["@type"].Value = type;
                prmcols.Add(new SqlParameter("@sort", SqlDbType.Int, 4));
                prmcols["@sort"].Value = sort;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds);
                con.Close();
            }
            catch
            { }
            return test;
        }

        //Original:
        public DataSet ProductChoiceOriginalFromTo(string where, int from, int to)
        {
            DataSet ds = new DataSet();
            try
            {
                //w_product_for_quick_search
                string sqlselect = "";
                int num_Row_Get = to - from;
                sqlselect = "SELECT * FROM ( ";
                sqlselect = sqlselect + "SELECT TOP " + num_Row_Get.ToString();
                sqlselect = sqlselect + " * FROM( SELECT TOP " + to.ToString() + " id,brandid,brand,name,urlimage,sellingprice,warrantymonth,note,idproduct from v_web_product_choice_original " + where;
                sqlselect = sqlselect + " order by SellingPrice asc,brand asc,Id asc) as t1 ";
                sqlselect = sqlselect + " order by SellingPrice desc,brand desc,Id desc) as t2 ";
                sqlselect = sqlselect + " order by SellingPrice asc,brand asc,Id asc";
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, "Choiceoriginal");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public int ProductCountChoiceOriginal(string where)
        {
            int num = 0;
            DataSet ds = new DataSet();
            try
            {
                //w_product_for_quick_search
                string sqlselect = "";
                sqlselect = sqlselect + "SELECT count(id)as count from v_web_product_choice_original " + where;
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds);
                con.Close();
                if (ds.Tables.Count > 0)
                {
                    num = int.Parse(ds.Tables[0].Rows[0]["count"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return num;
        }
        public Boolean ProductOriginalUpdate(int idpro, int type, int sort)
        {
            //w_product_best_sell_update:
            Boolean test = true;
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_product_original_update", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = idpro;
                prmcols.Add(new SqlParameter("@type", SqlDbType.Int, 4));
                prmcols["@type"].Value = type;
                prmcols.Add(new SqlParameter("@sort", SqlDbType.Int, 4));
                prmcols["@sort"].Value = sort;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds);
                con.Close();
            }
            catch
            { }
            return test;
        }
        public DataSet OriginalSelectTop()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_select_original", con);
                command.CommandType = CommandType.StoredProcedure;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds, "original");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public DataSet OriginalSelectTop4()
        {
            //w_select_original_top:
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_select_original_top", con);
                command.CommandType = CommandType.StoredProcedure;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds, "original");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        //Pocket Pc:
        public DataSet PocketPcMainPage()
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = sqlselect + "SELECT * from v_web_pocketpc_mainpage order by SellingPrice";
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
    }
}
