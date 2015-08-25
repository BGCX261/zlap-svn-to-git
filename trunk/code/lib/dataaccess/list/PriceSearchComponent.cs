using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace dataaccess.list
{
    public class PriceSearchComponent
    {
        SqlDataAdapter sqlda;
        public PriceSearchComponent()
        {
            sqlda = new SqlDataAdapter();
        }
        public DataSet PriceComSearchAllGroup(string where)
        {
            //select * from v_web_Price_search_all
            //v_web_Price_search_all:
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = sqlselect + "select ProductTypeId,Name,PriceFrom,PriceTo from v_web_Price_search_all " + where;
                sqlselect = sqlselect + " order by Sort, componenttypeid";
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, "ListPrice");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public int PriceComSearchCount(string where)
        {
            int num = 0;
            try
            {
                //v_web_Price_search_all
                DataSet ds = new DataSet();
                string sqlselect = "";
                sqlselect = "SELECT count(Id) as count FROM v_web_Price_search_all " + where;
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds);
                con.Close();
                num = int.Parse(ds.Tables[0].Rows[0]["count"].ToString());
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return num;
        } 
        public DataSet PriceComSearchFromTo(string where, int from, int to)
        {
            //v_web_Price_search_all:
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                int num_Row_Get = to - from;
                sqlselect = "SELECT * FROM ( ";
                sqlselect = sqlselect + "SELECT TOP " + num_Row_Get.ToString();
                sqlselect = sqlselect + " * FROM( SELECT TOP " + to.ToString() + " * FROM v_web_Price_search_all " + where;
                sqlselect = sqlselect + " order by Sort, componenttypeid) as t1";
                sqlselect = sqlselect + " order by Sort desc, componenttypeid desc) as t2";
                sqlselect = sqlselect + " order by Sort, componenttypeid";
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds,"ListPrice");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public Boolean PriceComSearchInsert(int typecomid, string Name, float pricefrom, float priceto, int sort)
        {
            //w_Price_Search_Com_Insert
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_Price_Search_Com_Insert", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@typecomid", SqlDbType.Int, 4));
                prmcols["@typecomid"].Value = typecomid;
                prmcols.Add(new SqlParameter("@name", SqlDbType.NVarChar, 64));
                prmcols["@name"].Value = Name;
                prmcols.Add(new SqlParameter("@pricefrom", SqlDbType.Float, 8));
                prmcols["@pricefrom"].Value = pricefrom;
                prmcols.Add(new SqlParameter("@priceto", SqlDbType.Float, 8));
                prmcols["@priceto"].Value = priceto;
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
        public Boolean PriceComSearchDelete(string id)
        {
            
            try
            {
                DataSet ds = new DataSet();
                string sqlselect = "";
                sqlselect = sqlselect + "delete w_pricesearch where id=" + id;
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, "DeletePriceSearch");
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return false;
            }
        }
    }
}