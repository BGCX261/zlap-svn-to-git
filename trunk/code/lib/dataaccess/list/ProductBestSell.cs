using System;
using System.Collections.Generic;
using System.Text;
using common.list;
using System.Data;
using System.Data.SqlClient;
namespace dataaccess.list
{
    public class ProductBestSell
    {
        //w_product_bestsell
        SqlDataAdapter sqlda;
        public ProductBestSell()
        {
            sqlda = new SqlDataAdapter();
        }
        //Product BestSell:
        public  ProductMainPage_data ProductBestSellAll()
        {
            ProductMainPage_data ds = new ProductMainPage_data();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_product_bestsell", con);
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
        public DataSet ProductSelectChoiceBestSellFromTo(string where, int from, int to)
        {
            DataSet ds = new DataSet();
            try
            {
                //w_product_for_quick_search
                string sqlselect = "";
                int num_Row_Get = to - from;
                sqlselect = "SELECT * FROM ( ";
                sqlselect = sqlselect + "SELECT TOP " + num_Row_Get.ToString();
                sqlselect = sqlselect + " * FROM( SELECT TOP " + to.ToString() + " id,brandid,brand,name,urlimage,sellingprice,warrantymonth,note,idproduct from v_web_product_choice_bestsell " + where;
                sqlselect = sqlselect + " order by SellingPrice asc,brand asc,Id asc) as t1 ";
                sqlselect = sqlselect + " order by SellingPrice desc,brand desc,Id desc) as t2 ";
                sqlselect = sqlselect + " order by SellingPrice asc,brand asc,Id asc";
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds,"ChoiceBestsell");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public int ProductCountSelectChoiceBestSell(string where)
        {
            int num=0;
            DataSet ds = new DataSet();
            try
            {
                //w_product_for_quick_search
                string sqlselect = "";
                sqlselect = sqlselect + "SELECT count(id)as count from v_web_product_choice_bestsell " + where;
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
        public Boolean ProductBestUpdate(int idpro, int type)
        {
            //w_product_best_sell_update:
            Boolean test = true;
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_product_best_sell_update", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = idpro;
                prmcols.Add(new SqlParameter("@type", SqlDbType.Int, 4));
                prmcols["@type"].Value = type;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds);
                con.Close();
            }
            catch
            {
                test = false;
            }
            return test;
        }
        //Product JustHave:
        public ProductMainPage_data ProductJustHavelTop()
        {
            ProductMainPage_data ds = new ProductMainPage_data();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_product_justhave_top", con);
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
        public ProductMainPage_data ProductJustHavelAll()
        {
            ProductMainPage_data ds = new ProductMainPage_data();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_product_justhave", con);
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
        public DataSet ProductSelectChoiceJustHaveFromTo(string where, int from, int to)
        {
            DataSet ds = new DataSet();
            try
            {
                //w_product_for_quick_search
                string sqlselect = "";
                int num_Row_Get = to - from;
                sqlselect = "SELECT * FROM ( ";
                sqlselect = sqlselect + "SELECT TOP " + num_Row_Get.ToString();
                sqlselect = sqlselect + " * FROM( SELECT TOP " + to.ToString() + " id,brandid,brand,name,urlimage,sellingprice,warrantymonth,note,idproduct from v_web_product_choice_justhave " + where;
                sqlselect = sqlselect + " order by SellingPrice asc,brand asc,Id asc) as t1 ";
                sqlselect = sqlselect + " order by SellingPrice desc,brand desc,Id desc) as t2 ";
                sqlselect = sqlselect + " order by SellingPrice asc,brand asc,Id asc";
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, "choicejusthave");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public int ProductCountSelectChoicejusthave(string where)
        {
            int num = 0;
            DataSet ds = new DataSet();
            try
            {
                //w_product_for_quick_search
                string sqlselect = "";
                sqlselect = sqlselect + "SELECT count(id)as count from v_web_product_choice_justhave " + where;
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
        public Boolean ProductJustHaveUpdate(int idpro, int type)
        {
            //w_product_best_sell_update:
            Boolean test = true;
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_product_justhave_update", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = idpro;
                prmcols.Add(new SqlParameter("@type", SqlDbType.Int, 4));
                prmcols["@type"].Value = type;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds);
                con.Close();
            }
            catch
            {
                test = false;
            }
            return test;
        }

        //Product prepare out:
        public ProductMainPage_data ProductPrepareoutlAll()
        {
            ProductMainPage_data ds = new ProductMainPage_data();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_product_prepareout", con);
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
        public DataSet ProductSelectChoicePrepareoutFromTo(string where, int from, int to)
        {
            DataSet ds = new DataSet();
            try
            {
                //w_product_for_quick_search
                string sqlselect = "";
                int num_Row_Get = to - from;
                sqlselect = "SELECT * FROM ( ";
                sqlselect = sqlselect + "SELECT TOP " + num_Row_Get.ToString();
                sqlselect = sqlselect + " * FROM( SELECT TOP " + to.ToString() + " id,brandid,brand,name,urlimage,sellingprice,warrantymonth,note,idproduct from v_web_product_choice_prepareout " + where;
                sqlselect = sqlselect + " order by SellingPrice asc,brand asc,Id asc) as t1 ";
                sqlselect = sqlselect + " order by SellingPrice desc,brand desc,Id desc) as t2 ";
                sqlselect = sqlselect + " order by SellingPrice asc,brand asc,Id asc";
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, "prepareout");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public int ProductCountSelectChoiceprepareout(string where)
        {
            int num = 0;
            DataSet ds = new DataSet();
            try
            {
                //w_product_for_quick_search
                string sqlselect = "";
                sqlselect = sqlselect + "SELECT count(id)as count from v_web_product_choice_prepareout " + where;
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
        public Boolean ProductPrepareoutUpdate(int idpro, int type)
        {
            //w_product_best_sell_update:
            Boolean test = true;
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_product_prepareout_update", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = idpro;
                prmcols.Add(new SqlParameter("@type", SqlDbType.Int, 4));
                prmcols["@type"].Value = type;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds);
                con.Close();
            }
            catch
            {
                test = false;
            }
            return test;
        }

        //Product Promotion:
        public DataSet ProductSpecialPromotion()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_pro_special_promotion", con);
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
        public DataSet ProChoicePromotionFromTo(string where, int from, int to)
        {
            DataSet ds = new DataSet();
            try
            {
                //w_product_for_quick_search
                string sqlselect = "";
                int num_Row_Get = to - from;
                sqlselect = "SELECT * FROM ( ";
                sqlselect = sqlselect + "SELECT TOP " + num_Row_Get.ToString();
                sqlselect = sqlselect + " * FROM( SELECT TOP " + to.ToString() + " id,brandid,brand,name,urlimage,sellingprice,warrantymonth,note,productid,content from v_web_pro_choice_special_promotion " + where;
                sqlselect = sqlselect + " order by SellingPrice asc,brand asc,Id asc) as t1 ";
                sqlselect = sqlselect + " order by SellingPrice desc,brand desc,Id desc) as t2 ";
                sqlselect = sqlselect + " order by SellingPrice asc,brand asc,Id asc";
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, "specialpromotion");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public int ProCountpromotion(string where)
        {
            int num = 0;
            DataSet ds = new DataSet();
            try
            {
                //w_product_for_quick_search
                string sqlselect = "";
                sqlselect = sqlselect + "SELECT count(id)as count from v_web_pro_choice_special_promotion " + where;
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
        public Boolean ProductSpecialPromotionUpdate(int idpro, int type)
        {
            //w_product_best_sell_update:
            Boolean test = true;
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_product_special_promotion_update", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = idpro;
                prmcols.Add(new SqlParameter("@type", SqlDbType.Int, 4));
                prmcols["@type"].Value = type;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds);
                con.Close();
            }
            catch
            {
                test = false;
            }
            return test;
        }

        //Product SellOff:
        public DataSet ProductSellOffAll()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_product_selloff_all", con);
                command.CommandType = CommandType.StoredProcedure;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds, "selloff");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public DataSet ProductSellOffFromTo(string where, int from, int to)
        {
            DataSet ds = new DataSet();
            try
            {
                //w_product_for_quick_search
                string sqlselect = "";
                int num_Row_Get = to - from;
                sqlselect = "SELECT * FROM ( ";
                sqlselect = sqlselect + "SELECT TOP " + num_Row_Get.ToString();
                sqlselect = sqlselect + " * FROM( SELECT TOP " + to.ToString() + " id,brandid,brand,name,urlimage,sellingprice,price,warrantymonth,note,idproduct from v_web_product_choice_selloff " + where;
                sqlselect = sqlselect + " order by SellingPrice asc,brand asc,Id asc) as t1 ";
                sqlselect = sqlselect + " order by SellingPrice desc,brand desc,Id desc) as t2 ";
                sqlselect = sqlselect + " order by SellingPrice asc,brand asc,Id asc";
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, "choiceselloff");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public int ProductCountChoiceSellOff(string where)
        {
            int num = 0;
            DataSet ds = new DataSet();
            try
            {
                //w_product_for_quick_search
                string sqlselect = "";
                sqlselect = sqlselect + "SELECT count(id)as count from v_web_product_choice_selloff " + where;
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
        public Boolean ProductSellOffUpdate(int idpro, int type,float price)
        {
            //w_product_best_sell_update:
            Boolean test = true;
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_product_selloff_update", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = idpro;
                prmcols.Add(new SqlParameter("@type", SqlDbType.Int, 4));
                prmcols["@type"].Value = type;
                prmcols.Add(new SqlParameter("@price", SqlDbType.Float, 8));
                prmcols["@price"].Value = price;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds);
                con.Close();
            }
            catch
            {
                test = false;
            }
            return test;
        }
        public DataSet ProductBestView()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_product_view_in_web_top", con);
                command.CommandType = CommandType.StoredProcedure;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds,"bestview");
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