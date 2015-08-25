using System;
using System.Collections.Generic;
using System.Text;
using common.list;
using System.Data;
using System.Data.SqlClient;
namespace dataaccess.list
{
    public class Product
    {
        SqlDataAdapter sqlda;
        public Product()
        {
            sqlda = new SqlDataAdapter();
        }
        public DataSet ListNamePro(int idtype, int brandid)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_listname_pro", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@producttype", SqlDbType.Int, 4));
                prmcols["@producttype"].Value = idtype;
                prmcols.Add(new SqlParameter("@brandid", SqlDbType.Int, 4));
                prmcols["@brandid"].Value = brandid;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds);
                con.Close();
            }
            catch
            { }
            return ds;
        }
        public  Product_data ProductSelectIdTypeFromTo(int idtype,int from,int to)
        {
            Product_data ds = new Product_data();
            try
            {
                //w_product_id_type
                string sqlselect = "";
                int num_Row_Get = to - from;
                sqlselect = "SELECT * FROM ( ";
                sqlselect = sqlselect + "SELECT TOP " + num_Row_Get.ToString();
                sqlselect = sqlselect + " * FROM( SELECT TOP " + to.ToString() + " Id,Name,state,StateId,UrlImage,SellingPrice,WarrantyMonth,promotion,ShortNote,isSpec FROM v_web_product_quick_view where ProductTypeid=" + idtype;
                sqlselect = sqlselect + " order by SellingPrice,id) as t1 ";
                sqlselect = sqlselect + " order by SellingPrice desc,id desc) as t2 ";
                sqlselect = sqlselect + " order by SellingPrice,id";
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, Product_data._table);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public int ProductCountIdType(int idtype)
        {
            int num = 0;
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_product_count_id_type", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@idtype", SqlDbType.Int, 4));
                prmcols["@idtype"].Value = idtype;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    num = (int)ds.Tables[0].Rows[0]["count"];
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return num;
        }
        public Product_data ProductWithBrandFromTo(int idtype, int IdBrand, int from, int to)
        {
            Product_data ds = new Product_data();
            try
            {
                //w_product_with_brand
                string sqlselect = "";
                int num_Row_Get = to - from;
                sqlselect = "SELECT * FROM ( ";
                sqlselect = sqlselect + "SELECT TOP " + num_Row_Get.ToString();
                sqlselect = sqlselect + " * FROM( SELECT TOP " + to.ToString() + " Id,Name,state,StateId,UrlImage,SellingPrice,WarrantyMonth,ShortNote,promotion,isSpec FROM v_web_product_quick_view where ProductTypeid=" + idtype.ToString() + " and BrandId=" + IdBrand + "";
                sqlselect = sqlselect + " order by SellingPrice,id) as t1 ";
                sqlselect = sqlselect + " order by SellingPrice desc,id desc) as t2 ";
                sqlselect = sqlselect + " order by SellingPrice,id";
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, Product_data._table);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public int ProductWithBrandCount(int idtype,int idBrand,ref string NameBrand)
        {
            int num = 0;
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_product_with_brand_count", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@idtype", SqlDbType.Int, 4));
                prmcols["@idtype"].Value = idtype;
                prmcols.Add(new SqlParameter("@idbrand", SqlDbType.Int, 4));
                prmcols["@idbrand"].Value = idBrand;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds);
                con.Close();
                if (ds.Tables.Count > 0)
                {
                    num = (int)ds.Tables[0].Rows[0]["count"];
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    NameBrand = ds.Tables[1].Rows[0]["name"].ToString();
                }
                else
                {
                    NameBrand = "";
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return num;
        }
        public int ProductQuickSearchCount(string where)
        {
            int num = 0;
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_product_for_quick_search_count", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@where", SqlDbType.NVarChar, 500));
                prmcols["@where"].Value = where;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds);
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
        public Product_data ProductQuickSearchFromTo(string where, int from, int to)
        {
            Product_data ds = new Product_data();
            try
            {
                //w_product_for_quick_search
                string sqlselect = "";
                int num_Row_Get = to - from;
                sqlselect = "SELECT * FROM ( ";
                sqlselect = sqlselect + "SELECT TOP " + num_Row_Get.ToString();
                sqlselect = sqlselect + " * FROM( SELECT TOP " + to.ToString() + " Id,Name,state,UrlImage,SellingPrice,WarrantyMonth,promotion FROM v_web_product_for_search " + where;
                sqlselect = sqlselect + " order by SellingPrice desc,id desc) as t1 ";
                sqlselect = sqlselect + " order by SellingPrice,id) as t2 ";
                sqlselect = sqlselect + " order by SellingPrice desc,id desc";
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, Product_data._table);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public int ProductSearchCount(string where)
        {
            int num = 0;
            try
            {
                DataSet ds = new DataSet();
                string sqlselect = "";
                sqlselect = "select count(id) as count from v_web_product_advance_search " + where;
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds);
                con.Close();
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        num = int.Parse(ds.Tables[0].Rows[0]["count"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return num;
        }
        public Product_data ProductSearchFromTo(string where, int from, int to)
        {
            Product_data ds = new Product_data();
            try
            {
                //w_product_for_quick_search
                string sqlselect = "";
                int num_Row_Get = to - from;
                sqlselect = "SELECT * FROM ( ";
                sqlselect = sqlselect + "SELECT TOP " + num_Row_Get.ToString();
                sqlselect = sqlselect + " * FROM( SELECT TOP " + to.ToString() + " Id,Name,state,UrlImage,SellingPrice,WarrantyMonth,ShortNote,promotion,Isspec FROM v_web_product_advance_search " + where;
                sqlselect = sqlselect + " order by SellingPrice,id) as t1 ";
                sqlselect = sqlselect + " order by SellingPrice desc,id desc) as t2 ";
                sqlselect = sqlselect + " order by SellingPrice,id";
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, Product_data._table);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public int ProductWillHaveCount(int idtype)
        {
            int num = 0;
            try
            {
                DataSet ds = new DataSet();
                string sqlselect = "";
                sqlselect = "select count(id) as count from v_web_product_will_have where ProductTypeId=" + idtype;
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds);
                con.Close();
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        num = int.Parse(ds.Tables[0].Rows[0]["count"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return num;
        }
        public Product_data ProductWillHaveFromTo(int idtype, int from, int to)
        {
            Product_data ds = new Product_data();
            try
            {
                //w_product_id_type
                string sqlselect = "";
                int num_Row_Get = to - from;
                sqlselect = "SELECT * FROM ( ";
                sqlselect = sqlselect + "SELECT TOP " + num_Row_Get.ToString();
                sqlselect = sqlselect + " * FROM( SELECT TOP " + to.ToString() + " Id,Name,state,UrlImage,SellingPrice,WarrantyMonth,promotion,ShortNote FROM v_web_product_will_have where ProductTypeid=" + idtype;
                sqlselect = sqlselect + " order by SellingPrice,id) as t1 ";
                sqlselect = sqlselect + " order by SellingPrice desc,id desc) as t2 ";
                sqlselect = sqlselect + " order by SellingPrice,id";
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, Product_data._table);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public DataSet ProductDetailType(int id, int idtype)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_product_select_detail_idtype", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = id;
                prmcols.Add(new SqlParameter("@idtype", SqlDbType.Int, 4));
                prmcols["@idtype"].Value = idtype;
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
        public DataSet ProductDetailTypeNew(int id, int idtype)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_product_select_detail_idtype_new", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = id;
                prmcols.Add(new SqlParameter("@idtype", SqlDbType.Int, 4));
                prmcols["@idtype"].Value = idtype;
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
        public DataSet ProductDetailTypeAll(int id, int idtype)
        {
            //w_product_select_detail_all
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_product_select_detail_all", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = id;
                prmcols.Add(new SqlParameter("@idtype", SqlDbType.Int, 4));
                prmcols["@idtype"].Value = idtype;
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
        public DataSet ProductDetailTypeOther(int id, string idtype)
        {
            //w_product_select_detail_orther
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_product_select_detail_orther", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = id;
                prmcols.Add(new SqlParameter("@idtype", SqlDbType.VarChar, 100));
                prmcols["@idtype"].Value = idtype;
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
        public string ProductDes(string id)
        {
            string str = "";
            try
            {
                //w_product_for_quick_search
                DataSet ds = new DataSet();
                string sqlselect = "";
                sqlselect = "select Name,Note from tbl_product where id="+ id;
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds);
                con.Close();
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        str = ds.Tables[0].Rows[0]["Name"].ToString() + "<@>" + ds.Tables[0].Rows[0]["Note"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return str;
        }
        public string ProductShortNote(string id)
        {
            string str = "";
            try
            {
                //w_product_for_quick_search
                DataSet ds = new DataSet();
                string sqlselect = "";
                sqlselect = "select Name,shortnote from tbl_product where id=" + id;
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds);
                con.Close();
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        str = ds.Tables[0].Rows[0]["Name"].ToString() + "<@>" + ds.Tables[0].Rows[0]["shortnote"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return str;
        }
        public string ProductDesAndStock(string id)
        {
            string str = "";
            try
            {
                DataSet ds = new DataSet();
                string sqlselect = "";
                sqlselect = "select Name,Note from tbl_product where id=" + id;
                sqlselect += " select address from v_web_product_warehouse where productid=" + id + " group by address";
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds);
                con.Close();
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    str = ds.Tables[0].Rows[0]["Name"].ToString() + "<@>" + ds.Tables[0].Rows[0]["Note"].ToString();
                    int num = ds.Tables[1].Rows.Count;
                    string sub="";
                    for (int i = 0; i < num; i++)
                    {
                        sub += "- " + ds.Tables[1].Rows[i]["address"].ToString() + "<br />";
                    }
                    if (sub.Length > 0)
                    {
                        str = str + "<@>" + sub;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return str;
        }
        public DataSet ProducttoCart(string id,string idtype)
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select Id,Name,state,Sellingprice,WarrantyMonth,UrlImage,currency,rate from v_web_product_to_cart where Id=" + id + " and CanSales=1";
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
        public DataSet ProductToExportPrice(string Currency, int idbrand, int idtype)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_product_export_price", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@currency", SqlDbType.VarChar, 50));
                prmcols["@currency"].Value = Currency;
                prmcols.Add(new SqlParameter("@idbrand", SqlDbType.Int, 4));
                prmcols["@idbrand"].Value = idbrand;
                prmcols.Add(new SqlParameter("@idtype", SqlDbType.Int, 4));
                prmcols["@idtype"].Value = idtype;
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
        public DataSet ProductForUploadFromTo(string where, int from, int to)
        {
            DataSet ds = new DataSet();
            try
            {
                //w_product_for_quick_search
                string sqlselect = "";
                int num_Row_Get = to - from;
                sqlselect = "SELECT * FROM ( ";
                sqlselect = sqlselect + "SELECT TOP " + num_Row_Get.ToString();
                sqlselect = sqlselect + " * FROM( SELECT TOP " + to.ToString() + " Id,Name,brand,UrlImage,SellingPrice,WarrantyMonth,Note,Des FROM v_web_product_all_information " + where;
                sqlselect = sqlselect + " order by SellingPrice asc,brand asc,Id asc) as t1 ";
                sqlselect = sqlselect + " order by SellingPrice desc,brand desc,Id desc) as t2 ";
                sqlselect = sqlselect + " order by SellingPrice asc,brand asc,Id asc";
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, Product_data._table);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public Boolean ProductUpdateImage(int id, string nameImage)
        {
            //w_product_update_image
            Boolean test = true;
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_product_update_image", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = id;
                prmcols.Add(new SqlParameter("@UrlImage", SqlDbType.NVarChar, 128));
                prmcols["@UrlImage"].Value = nameImage;
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
        public DataSet ProductDesId(string id)
        {
            DataSet ds = new DataSet();
            try
            {
                //w_product_id_type
                string sqlselect = "";
                sqlselect = "select name,Note,des from tbl_product where id=" + id;
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, "desPro");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        
        }
        public DataSet ProductNameId(string id)
        {
            DataSet ds = new DataSet();
            try
            {
                //w_product_id_type
                string sqlselect = "";
                sqlselect = "select name from tbl_product where id=" + id;
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, "desPro");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;

        }
        public Boolean ProductDesUpdate(int id, string des)
        {
            //w_product_update_des
            Boolean test = true;
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_product_update_des", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = id;
                prmcols.Add(new SqlParameter("@des", SqlDbType.NVarChar));
                prmcols["@des"].Value = des;
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
        public Boolean ProductDesUpdate(int id, string des,string shortdes)
        {
            //w_product_update_des
            Boolean test = true;
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_product_update_des_shortdes", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = id;
                prmcols.Add(new SqlParameter("@des", SqlDbType.NVarChar));
                prmcols["@des"].Value = des;

                prmcols.Add(new SqlParameter("@shortdes", SqlDbType.NVarChar));
                prmcols["@shortdes"].Value = shortdes;
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

        public Boolean ProductDesUpdateGroup(string Name, string des)
        {
            //w_product_update_des
            Boolean test = true;
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_product_update_des_group", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@Name", SqlDbType.VarChar));
                prmcols["@Name"].Value = Name;
                prmcols.Add(new SqlParameter("@des", SqlDbType.NVarChar));
                prmcols["@des"].Value = des;
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
        public DataSet ProductSelectForCompare(int id1, int id2, int type)
        {
            //w_product_select_detail_for_compare:
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_product_select_detail_for_compare", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id1", SqlDbType.Int, 4));
                prmcols["@id1"].Value = id1;
                prmcols.Add(new SqlParameter("@id2", SqlDbType.Int, 4));
                prmcols["@id2"].Value = id2;
                prmcols.Add(new SqlParameter("@idtype", SqlDbType.Int, 4));
                prmcols["@idtype"].Value = type;
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
        public DataSet ProductSelectNameWithBrand(int idbrand1, int idbrand2, int type)
        {
            //w_product_select_name_with_brand
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_product_select_name_with_brand", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@idbrand1", SqlDbType.Int, 4));
                prmcols["@idbrand1"].Value = idbrand1;
                prmcols.Add(new SqlParameter("@idbrand2", SqlDbType.Int, 4));
                prmcols["@idbrand2"].Value = idbrand2;
                prmcols.Add(new SqlParameter("@idtype", SqlDbType.Int, 4));
                prmcols["@idtype"].Value = type;
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
        public DataSet ProductSelectAllIdType(string where)
        {
            DataSet ds = new DataSet();
            try
            {
                //w_product_for_quick_search
                string sqlselect = "";
                sqlselect = sqlselect + "select Id,Name,Note,UrlImage,SellingPrice,WarrantyMonth,brand,idbrand,currency,promotion from v_web_product_all " + where;
                sqlselect = sqlselect + " order by SellingPrice asc";
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
        public int ProductOtherSelectCount(string where)
        {
            int num = 0;
            try
            {
                string sqlselect = "";
                DataSet ds = new DataSet();
                sqlselect = "select count(id) as count from v_web_product_all " + where;
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds);
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
        public DataSet ProductOtherSelectFromTo(string where,int from, int to)
        {
            DataSet ds = new DataSet();
            try
            {
                //v_web_product_all
                string sqlselect = "";
                int num_Row_Get = to - from;
                sqlselect = "SELECT * FROM ( ";
                sqlselect = sqlselect + "SELECT TOP " + num_Row_Get.ToString();
                sqlselect = sqlselect + " * FROM( SELECT TOP " + to.ToString() + " Id,Name,Note,UrlImage,SellingPrice,WarrantyMonth,brand,idbrand,currency,promotion from v_web_product_all " + where;
                sqlselect = sqlselect + " order by SellingPrice asc) as t1 ";
                sqlselect = sqlselect + " order by SellingPrice desc) as t2 ";
                sqlselect = sqlselect + " order by SellingPrice asc ";
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
        public string PromotionSelectId(string id)
        {
            string str = "";
            try
            {
                string sqlselect = "";
                DataSet ds=new DataSet();
                sqlselect = "select Name,Note,UrlImage,StartDate,EndDate from productpromotion where ProductId=" + id;
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds);
                con.Close();
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    str = "<div class='td_bd1'><table border='0' cellpadding='0' cellspacing='0' width='100%' bgcolor='#FFF1EA'>";
                    str += "<tr><td class='text_b3' align='center'>Sản phẩm đi kèm theo máy</td></tr>";
                    str += "<tr><td class='qshow'>";
                    if (ds.Tables[0].Rows[0]["Note"].ToString().Length > 0)
                    {
                        str += ds.Tables[0].Rows[0]["Note"].ToString() + "</td></tr>";
                    }
                    else
                    {
                        str += ds.Tables[0].Rows[0]["Name"].ToString() + "</td></tr>";
                    }
                    str += "<tr><td class='domain'>&nbsp;</td></tr></table></div>";
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return str;
        }
        public float GetCurrencyProductType(string idtype)
        {
            //select * from v_web_product_type_currency
            float value = 1;
            try
            {
                DataSet ds = new DataSet();
                string sqlselect = "select Rate from v_web_product_type_currency where id="+ idtype;
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds,"currency");
                con.Close();
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        value = float.Parse(ds.Tables[0].Rows[0]["Rate"].ToString());
                    }
                }
            }
            catch
            { }
            return value;
        }
        public Boolean UpdateUSD(string usd)
        {
            try
            {
                DataSet ds = new DataSet();
                string sqlselect = "update tbl_currency set Rate=" + usd + " where name='USD'";
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, "currency");
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //For Multi Image:
        public int ProductMultiImageCount(string where)
        {
            int num = 0;
            try
            {
                DataSet ds = new DataSet();
                string sqlselect = "";
                sqlselect = "select count(id) as count from v_web_product_choice_all_img " + where;
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds);
                con.Close();
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        num = int.Parse(ds.Tables[0].Rows[0]["count"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return num;
        }
        public DataSet ProductMultiImgFromTo(string where, int from, int to)
        {
            DataSet ds = new DataSet();
            try
            {
                //w_product_for_quick_search
                string sqlselect = "";
                int num_Row_Get = to - from;
                sqlselect = "SELECT * FROM ( ";
                sqlselect = sqlselect + "SELECT TOP " + num_Row_Get.ToString();
                sqlselect = sqlselect + " * FROM( SELECT TOP " + to.ToString() + " Id,Name,brand,SellingPrice,shortnote,idpro,img1,img2,img3,img4,img5,img6,img7 FROM v_web_product_choice_all_img " + where;
                sqlselect = sqlselect + " order by SellingPrice asc,brand asc,Id asc) as t1 ";
                sqlselect = sqlselect + " order by SellingPrice desc,brand desc,Id desc) as t2 ";
                sqlselect = sqlselect + " order by SellingPrice asc,brand asc,Id asc";
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, Product_data._table);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        //w_product_extension_img_update:
        public Boolean ProductUpdateMultiImage(int id, string index, string nameImage)
        {
            //w_product_update_image
            Boolean test = true;
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_product_extension_img_update", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = id;
                prmcols.Add(new SqlParameter("@index", SqlDbType.Int, 4));
                prmcols["@index"].Value = index;
                prmcols.Add(new SqlParameter("@img", SqlDbType.NVarChar, 128));
                prmcols["@img"].Value = nameImage;
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

        //All promotion:
        public DataSet Promotionall()
        {
            //select * from Masterpromotion
            DataSet ds = new DataSet();
            try
            {
                
                string sqlselect = "";
                sqlselect = "select * from masterpromotion order by Createddate desc";
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

        public Boolean PromationUpdateImage(string Image,string Id)
        {
            //select * from Masterpromotion:
            Boolean test = true;
            try
            {
                DataSet ds = new DataSet();
                string sqlselect = "";
                sqlselect = "Update masterpromotion set UrlImage='" + Image + "' where Id=" + Id;
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