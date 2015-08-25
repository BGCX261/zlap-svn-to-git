using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using common.list;
namespace dataaccess.list
{
    public class Mobile
    {
        SqlDataAdapter sqlda;
        public Mobile()
        {
            sqlda = new SqlDataAdapter();
        }
        public DataSet MobileChoiceFromTo(string where, int from, int to)
        {
            DataSet ds = new DataSet();
            try
            {
                //w_product_for_quick_search
                string sqlselect = "";
                int num_Row_Get = to - from;
                sqlselect = "SELECT * FROM ( ";
                sqlselect = sqlselect + "SELECT TOP " + num_Row_Get.ToString();
                sqlselect = sqlselect + " * FROM( SELECT TOP " + to.ToString() + " id,brand,name,urlimage,sellingprice,shortnote from v_web_mobile_choice_all " + where + " group by id,brand,name,urlimage,sellingprice,shortnote ";
                sqlselect = sqlselect + " order by SellingPrice asc,brand asc,Id asc) as t1 ";
                sqlselect = sqlselect + " order by SellingPrice desc,brand desc,Id desc) as t2 ";
                sqlselect = sqlselect + " order by SellingPrice asc,brand asc,Id asc";
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, "ChoiceMobile");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public int MobilecountChoice(string where)
        {
            int num = 0;
            DataSet ds = new DataSet();
            try
            {
                //w_product_for_quick_search
                string sqlselect = "";
                sqlselect = sqlselect + "SELECT count(id)as count from (select id from v_web_mobile_choice_all " + where + " group by id ) as tb1";
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
        public Boolean MobileUpdate(int idpro, int isinsert, int type, int sort)
        {
            Boolean test = true;
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_product_Mobile_update", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = idpro;
                prmcols.Add(new SqlParameter("@isinsert", SqlDbType.Int, 4));
                prmcols["@isinsert"].Value = isinsert;
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
        public ProductMainPage_data MobileforShow(string select)
        {
            ProductMainPage_data ds = new ProductMainPage_data();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(select, con);
                da.Fill(ds, ProductMainPage_data._table);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public DataSet MobileMainpage()
        {
            //w_mobile_mainpage:
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_mobile_mainpage", con);
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
    }
}
