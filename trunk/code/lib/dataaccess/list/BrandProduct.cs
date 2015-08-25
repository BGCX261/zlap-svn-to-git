using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using common.list;
namespace dataaccess.list
{
    public class BrandProduct
    {
        SqlDataAdapter sqlda;
        public BrandProduct()
        {
            sqlda = new SqlDataAdapter();
        }
        public DataSet BrandDetail(string id)
        {
            DataSet ds = new DataSet();
            try
            {
                string sql = "Select * From tbl_brand where id=" + id;
                SqlConnection Connect = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                da.Fill(ds,"detailbrand");
                Connect.Close();
            }
            catch
            { }
            return ds;
        }
        public BrandProduct_data SelectAllBrandWithTypePro(int type)
        {
            BrandProduct_data ds = new BrandProduct_data();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_brand_product_all", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@idtype", SqlDbType.Int, 4));
                prmcols["@idtype"].Value = type;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds,BrandProduct_data._table);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public Boolean UpdateImageBrand(int id,string url)
        {
            //w_update_url_brand
            Boolean test = true;
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_update_url_brand", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = id;
                prmcols.Add(new SqlParameter("@url", SqlDbType.NVarChar, 128));
                prmcols["@url"].Value = url;
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
        public DataSet BrandNameWhere(string Where)
        {
            //select Id,Name from tbl_brand order by Name:
            DataSet ds = new DataSet();
            try
            {
                string sql = "select Id,Name from tbl_brand " + Where;
                SqlConnection Connect = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                da.Fill(ds, "AllBrand");
                Connect.Close();
            }
            catch
            { }
            return ds;

        }
    }
}