using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using common.list;
namespace dataaccess.list
{
    public class ComponentProduct
    {
        SqlDataAdapter sqlda;
        public ComponentProduct()
        {
            sqlda = new SqlDataAdapter();
        }
        public DataSet ComponentSelectGroup(int idtype)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_component_select_group_typepro", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
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
        public DataSet ComponentSelectGroupSale(int idtype)
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "select Id,Name,UrlImage,IsShowBrand from tbl_componenttype where ProductTypeId=" + idtype + " and IsSale=1  order by Sort";
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds);
                con.Close();
            }
            catch
            {
                ds = null;
            }
            return ds;
        }
        public DataSet GroupComponentBrand(int idtype)
        {
            
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select Idtype,Id,Name from v_web_componenttype_brand where ComponentTypeId=" + idtype + " order by id";
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
        public DataSet ComponentSelectGroupTop(int idtype)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_component_select_group_typepro_top", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
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
        public DataSet ComponentGroupTop(string idtype)
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select top 12 Id,Name,UrlImage from tbl_componenttype where ProducttypeId="+ idtype + " order by Sort";
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, "GroupCom");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public Component_data ComponentAllFromTo(int idtype, int from, int to)
        {
            //v_web_component_all:
            Component_data ds = new Component_data();
            try
            {
                string sqlselect = "";
                int num_Row_Get = to - from;
                sqlselect = "SELECT * FROM ( ";
                sqlselect = sqlselect + "SELECT TOP " + num_Row_Get.ToString();
                sqlselect = sqlselect + " * FROM( SELECT TOP " + to.ToString() + " Id,Name,Brand,UrlImage,SellingPrice,WarrantyMonth,Note FROM v_web_component_all where ProductTypeId=" + idtype + " and CanSales=1";
                sqlselect = sqlselect + " order by ComponentTypeId,SellingPrice asc) as t1 ";
                sqlselect = sqlselect + " order by SellingPrice desc) as t2 ";
                sqlselect = sqlselect + " order by SellingPrice asc ";
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, Component_data._table);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public int ComponentAllCount(int idtype)
        {
            int num = 0;
            try
            {
                //w_product_id_type
                DataSet ds = new DataSet();
                string sqlselect = "";
                sqlselect = "SELECT count(Id) as count FROM v_web_component_all where ProductTypeId=" + idtype + " and CanSales=1";
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
        public Component_data ComponantGroupFromTo(int idtype, int idgroup, int from, int to)
        {
            Component_data ds = new Component_data();
            try
            {
                string sqlselect = "";
                int num_Row_Get = to - from;
                sqlselect = "SELECT * FROM ( ";
                sqlselect = sqlselect + "SELECT TOP " + num_Row_Get.ToString();
                sqlselect = sqlselect + " * FROM( SELECT TOP " + to.ToString() + " Id,Name,Brand,UrlImage,SellingPrice,WarrantyMonth,Note FROM v_web_component_all where ProductTypeId=" + idtype + " and ComponentTypeId=" + idgroup + " and CanSales=1";
                sqlselect = sqlselect + " order by SellingPrice asc) as t1 ";
                sqlselect = sqlselect + " order by SellingPrice desc) as t2 ";
                sqlselect = sqlselect + " order by SellingPrice asc ";
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, Component_data._table);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public int ComponentGroupCount(int idtype, int idgroup,ref string NameGroup)
        {
            int num = 0;
            try
            {
                //w_product_id_type
                DataSet ds = new DataSet();
                string sqlselect = "";
                sqlselect = "SELECT count(Id) as count FROM v_web_component_all where ProductTypeId=" + idtype + " and ComponentTypeId=" + idgroup + " and CanSales=1 ";
                sqlselect += "SELECT Name FROM tbl_componenttype where ProductTypeId=" + idtype + " and id=" + idgroup;
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds);
                con.Close();
                num = int.Parse(ds.Tables[0].Rows[0]["count"].ToString());
                NameGroup = ds.Tables[1].Rows[0]["Name"].ToString();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return num;
        }
        public DataSet ComponentNameId(string id)
        {
            DataSet ds = new DataSet();
            try
            {
                //w_product_id_type
                
                string sqlselect = "";
                sqlselect = "select Name from tbl_component where id=" + id;
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
        public string ComponentTypeName(int idtype, int idgroup)
        {
            string name = "";
            try
            {
                //w_product_id_type
                DataSet ds = new DataSet();
                string sqlselect = "";
                sqlselect = "SELECT Name FROM tbl_componenttype where ProductTypeId=" + idtype + " and id=" + idgroup;
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds);
                con.Close();
                name = ds.Tables[0].Rows[0]["Name"].ToString();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return name;
        }
        public int ComponentQuickSearchCount(string where)
        {
            int num = 0;
            try
            {
                DataSet ds = new DataSet();
                string sqlselect = "";
                sqlselect = "SELECT count(Id) as count FROM v_web_component_all " + where;
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
        public Component_data ComponentQuickSearchFromTo(string where, int from, int to)
        {
            Component_data ds = new Component_data();
            try
            {
                //w_product_for_quick_search
                string sqlselect = "";
                int num_Row_Get = to - from;
                sqlselect = "SELECT * FROM ( ";
                sqlselect = sqlselect + "SELECT TOP " + num_Row_Get.ToString();
                sqlselect = sqlselect + " * FROM( SELECT TOP " + to.ToString() + " Id,Name,Brand,UrlImage,SellingPrice,WarrantyMonth,Note FROM v_web_component_all " + where;
                sqlselect = sqlselect + " order by SellingPrice asc) as t1 ";
                sqlselect = sqlselect + " order by SellingPrice desc) as t2 ";
                sqlselect = sqlselect + " order by SellingPrice asc ";
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, Component_data._table);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public DataSet ComponenttoCart(string id, string idtype)
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select Id,Name,UrlImage,Sellingprice,WarrantyMonth,currency,rate from v_web_component_to_cart where Id=" + id + " and ProductTypeId=" + idtype + " and CanSales=1";
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
        public DataSet ComponenttoCart(string id)
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select Id,Name,UrlImage,Sellingprice,WarrantyMonth,currency,rate from v_web_component_to_cart where Id=" + id + " and CanSales=1";
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
        public DataSet ComponentSelectDetail(int id, int type)
        {
            //w_component_select_detail
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_component_select_detail", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = id;
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
        public DataSet ComponentSelectDetailId(int id)
        {
            //w_component_select_detail
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_component_select_detail_id", con);
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
        public int ComponentAllCount(string where)
        {
            int num = 0;
            try
            {
                //w_product_id_type
                DataSet ds = new DataSet();
                string sqlselect = "";
                sqlselect = "SELECT count(Id) as count FROM v_web_component_all " + where;
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
        public DataSet ComponentSelectAllFromTo(string where,int from,int to)
        {
            //v_web_component_all:
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                int num_Row_Get = to - from;
                sqlselect = "SELECT * FROM ( ";
                sqlselect = sqlselect + "SELECT TOP " + num_Row_Get.ToString();
                sqlselect = sqlselect + " * FROM( SELECT TOP " + to.ToString() + " Id,Name,Brand,UrlImage,SellingPrice,WarrantyMonth,Note,currency FROM v_web_component_all " + where;
                sqlselect = sqlselect + " order by SellingPrice, Id) as t1";
                sqlselect = sqlselect + " order by SellingPrice desc, Id desc) as t2";
                sqlselect = sqlselect + " order by SellingPrice, Id";
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, Component_data._table);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public int ComponentCompatibleCount(string where)
        {
            int num = 0;
            try
            {
                //w_product_id_type
                DataSet ds = new DataSet();
                string sqlselect = "";
                sqlselect = "SELECT count(Id) as count FROM w_product_compatible_with_component " + where;
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
        public DataSet ComponentCompatibleSelectAllFromTo(string where, int from, int to)
        {
            //v_web_component_all:
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                int num_Row_Get = to - from;
                sqlselect = "SELECT * FROM ( ";
                sqlselect = sqlselect + "SELECT TOP " + num_Row_Get.ToString();
                sqlselect = sqlselect + " * FROM( SELECT TOP " + to.ToString() + " Id,Name,Brand,UrlImage,SellingPrice,WarrantyMonth,Note,currency FROM w_product_compatible_with_component " + where;
                sqlselect = sqlselect + " order by SellingPrice, Id) as t1";
                sqlselect = sqlselect + " order by SellingPrice desc, Id desc) as t2";
                sqlselect = sqlselect + " order by SellingPrice, Id";
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, Component_data._table);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public DataSet ComponentCurrentAccess(string where)
        {
            //select top 1 * from v_w_protype_comtype_brand where Cansales=1
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select top 1 * from v_w_protype_comtype_brand " + where;
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, Component_data._table);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public Boolean ComponentUpdateImage(int id, string nameImage)
        {
            //w_product_update_image
            Boolean test = true;
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_component_update_image", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = id;
                prmcols.Add(new SqlParameter("@UrlImage", SqlDbType.VarChar, 128));
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
        public Boolean GroupComponentUpdateImage(int id, string nameImage)
        {
            //w_product_update_image
            Boolean test = true;
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_group_component_update_image", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = id;
                prmcols.Add(new SqlParameter("@UrlImage", SqlDbType.VarChar, 128));
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
    }
}