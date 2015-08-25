using System;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace dataaccess.list
{
    [Serializable]
    public class CManageProduct
    {
        SqlDataAdapter sqlda;
        public CManageProduct()
        {
            sqlda = new SqlDataAdapter();
        }
        public DataSet ProductDetailForOrder(string id)
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select * from v_web_product_choice where id=" + id;
                SqlConnection con = new SqlConnection(dataaccess.list.CSQL.sqlcn1);
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
        public DataSet ProductSeriForOrder(string Seri)
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select * from v_web_product_choice where id=(select top 1 ProductId from tbl_productseri where SeriNumber='" + Seri + "' and discontinued in (0))";
                SqlConnection con = new SqlConnection(dataaccess.list.CSQL.sqlcn1);
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
        public DataSet ProductSeriForOrder(string Seri, string WareHouseId)
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select * from v_web_product_choice where id=(select top 1 ProductId from tbl_productseri where WareHouseId=" + WareHouseId + " and SeriNumber='" + Seri + "' and discontinued=1)";
                SqlConnection con = new SqlConnection(dataaccess.list.CSQL.sqlcn1);
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
        public DataSet ProductSeriForExport(string Seri, string WareHouseId)
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select * from v_web_product_choice where id=(select top 1 ProductId from tbl_productseri where WareHouseId=" + WareHouseId + " and SeriNumber='" + Seri + "' and discontinued=0)";
                sqlselect += " select Id,ImportPrice from tbl_productseri where WareHouseId=" + WareHouseId + " and SeriNumber='" + Seri + "' and discontinued=0";
                SqlConnection con = new SqlConnection(dataaccess.list.CSQL.sqlcn1);
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
        public DataSet ProductNoSeriForExport(string ProductId, string WareHouseId)
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select * from v_web_product_choice where id=(select top 1 ProductId from tbl_ProductNoSeri where WareHouseId=" + WareHouseId + " and ProductId=" + ProductId + ")";
                sqlselect += " select top 1 Id,Quantity from tbl_ProductNoSeri where WareHouseId=" + WareHouseId + " and ProductId=" + ProductId;
                SqlConnection con = new SqlConnection(dataaccess.list.CSQL.sqlcn1);
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
        public DataSet ProductSeriForImport(string Seri, string WareHouseId, string Discontinued)
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select * from v_web_product_choice where id=(select top 1 ProductId from tbl_productseri where WareHouseId=" + WareHouseId + " and SeriNumber='" + Seri + "' and discontinued=" + Discontinued + ")";
                sqlselect += " select Id,ImportPrice from tbl_productseri where WareHouseId=" + WareHouseId + " and SeriNumber='" + Seri + "' and discontinued=" + Discontinued;
                SqlConnection con = new SqlConnection(dataaccess.list.CSQL.sqlcn1);
                con.Open();
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
        public DataSet ProductNoSeriQuantity(string WareHouseId, string ListProId)
        {
            //Select Id,ProductId,Quantity from tbl_ProductNoSeri where WareHouseId=1 and ProductId=7
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "Select ProductId,sum(Quantity) as Quantity From Tbl_ProductNoSeri where WareHouseId=" + WareHouseId + " and ProductId in(" + ListProId + ") group by ProductId";
                SqlConnection con = new SqlConnection(dataaccess.list.CSQL.sqlcn1);
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
        public DataSet ProductNoSeriId(string WareHouseId, string ListProId)
        {
            //Select Id,ProductId,Quantity from tbl_ProductNoSeri where WareHouseId=1 and ProductId=7
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "Select Id,ProductId,Quantity From Tbl_ProductNoSeri where WareHouseId=" + WareHouseId + " and ProductId in(" + ListProId + ")";
                SqlConnection con = new SqlConnection(dataaccess.list.CSQL.sqlcn1);
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
        public DataSet ProductChoiceSeeDetail(string id)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.list.CSQL.sqlcn1);
                con.Open();
                SqlCommand command = new SqlCommand("web_productchoice_seedetail", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = int.Parse(id);
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
        public DataSet ProductChoiceSeeDetailAndSeri(string id, string WareHouseId)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.list.CSQL.sqlcn1);
                con.Open();
                SqlCommand command = new SqlCommand("web_productchoice_seedetail_and_seri", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = id;
                prmcols.Add(new SqlParameter("@WarehouseId", SqlDbType.Int, 4));
                prmcols["@WarehouseId"].Value = WareHouseId;
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
        public DataSet ProductSeriId(string ListSeri)
        {
            //Select Id,ProductId,Quantity from tbl_ProductNoSeri where WareHouseId=1 and ProductId=7
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "Select Id From Tbl_ProductSeri Where Serinumber in (" + ListSeri + ")";
                SqlConnection con = new SqlConnection(dataaccess.list.CSQL.sqlcn1);
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
        public DataSet ProductSeriDiscontinued(string condition, string ListSeri)
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                string where = "";
                if (condition.Length > 0)
                {
                    where = "where " + condition + " and Serinumber in(" + ListSeri + ")";
                }
                else
                {
                    where = "where Serinumber in(" + ListSeri + ")";
                }
                sqlselect = "select discontinued,Serinumber from tbl_ProductSeri " + where;
                SqlConnection con = new SqlConnection(dataaccess.list.CSQL.sqlcn1);
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
        public DataSet ProductSearchFromTo(string where, int from, int to)
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                int num_Row_Get = to - from;
                sqlselect = "SELECT * FROM ( ";
                sqlselect = sqlselect + "SELECT TOP " + num_Row_Get.ToString();
                sqlselect = sqlselect + " * FROM( SELECT TOP " + to.ToString() + " Id,Name,BrandName,SellingPrice,CurrencyName,StateName,Cansales from v_web_product_choice " + where;
                sqlselect = sqlselect + " order by SellingPrice,id) as t1 ";
                sqlselect = sqlselect + " order by SellingPrice desc,id desc) as t2 ";
                sqlselect = sqlselect + " order by SellingPrice,id";
                SqlConnection con = new SqlConnection(dataaccess.list.CSQL.sqlcn1);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, "Product");
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
                sqlselect = "select count(id) as count from v_web_product_choice " + where;
                SqlConnection con = new SqlConnection(dataaccess.list.CSQL.sqlcn1);
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

        //Statistic:
        public DataSet ProductSeriStatistic(string id)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.list.CSQL.sqlcn1);
                con.Open();
                SqlCommand command = new SqlCommand("web_productseri_statistic", con);
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
        //w_product_seri_export_update
        public Boolean ProductSeriExportUpdate(int Discontinued, string SeriNumber)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.list.CSQL.sqlcn1);
                con.Open();
                SqlCommand command = new SqlCommand("w_product_seri_export_update", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@Discontinued", SqlDbType.Int, 4));
                prmcols["@Discontinued"].Value = Discontinued;
                prmcols.Add(new SqlParameter("@SeriNumber", SqlDbType.VarChar));
                prmcols["@SeriNumber"].Value = SeriNumber;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds);
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Boolean ProductNoSeriQuantityUpdate(int Id, int Quantity)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.list.CSQL.sqlcn1);
                con.Open();
                SqlCommand command = new SqlCommand("tbl_productnoseri_updeate_quantity", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@Id", SqlDbType.Int, 4));
                prmcols["@Id"].Value = Id;
                prmcols.Add(new SqlParameter("@Quantity", SqlDbType.Int, 4));
                prmcols["@Quantity"].Value = Quantity;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds);
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Import Update:
        public Boolean ProductSeriImportUpdate(int WareHouseId, int Discontinued, string SeriNumber)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.list.CSQL.sqlcn1);
                con.Open();
                SqlCommand command = new SqlCommand("w_product_seri_import_otherWH_update", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@WareHouseId", SqlDbType.Int, 4));
                prmcols["@WareHouseId"].Value = WareHouseId;
                prmcols.Add(new SqlParameter("@Discontinued", SqlDbType.Int, 4));
                prmcols["@Discontinued"].Value = Discontinued;
                prmcols.Add(new SqlParameter("@SeriNumber", SqlDbType.VarChar));
                prmcols["@SeriNumber"].Value = SeriNumber;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds);
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Boolean ProductNoSeriImportUpdate(int WareHouseId, int Id, int Quantity)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.list.CSQL.sqlcn1);
                con.Open();
                SqlCommand command = new SqlCommand("w_tbl_productnoseri_import_update_quantity", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;

                prmcols.Add(new SqlParameter("@WareHouseId", SqlDbType.Int, 4));
                prmcols["@WareHouseId"].Value = WareHouseId;

                prmcols.Add(new SqlParameter("@Id", SqlDbType.Int, 4));
                prmcols["@Id"].Value = Id;

                prmcols.Add(new SqlParameter("@Quantity", SqlDbType.Int, 4));
                prmcols["@Quantity"].Value = Quantity;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds);
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Select Producttype:
        public DataSet ProductTypeAll(string where)
        {
            //select Id,Name,HaveComponent,HaveSeri from tbl_producttype where Cansales=1
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "select Id,Name from tbl_producttype " + where;//where Cansales=1           
                SqlConnection con = new SqlConnection(dataaccess.list.CSQL.sqlcn1);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, "ProductType");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        //select BrandName with producttype:
        public DataSet BrandNameofProductType(string ProductTypeId)
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "select Id,Name from v_web_producttype_brand where ProducttypeId=" + ProductTypeId + " order by Name";
                SqlConnection con = new SqlConnection(dataaccess.list.CSQL.sqlcn1);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, "ProductType");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        //select statedproduct:        
        public DataSet ProductStateAll()
        {
            //select * FROM productstate
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "select Id,Name FROM productstate";
                SqlConnection con = new SqlConnection(dataaccess.list.CSQL.sqlcn1);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, "ProductType");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        //select Warehouse:
        public DataSet WareHouseAll()
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "select Id,Name FROM tbl_WareHouse order by Name";
                SqlConnection con = new SqlConnection(dataaccess.list.CSQL.sqlcn1);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, "WareHouse");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }

        //Product For Report:
        public DataSet ReportProduct(int ProductTypeId, int Cansales)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.list.CSQL.sqlcn1);
                con.Open();
                SqlCommand command = new SqlCommand("w_report_productprice", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@ProductTypeId", SqlDbType.Int, 4));
                prmcols["@ProductTypeId"].Value = ProductTypeId;
                prmcols.Add(new SqlParameter("@Cansales", SqlDbType.Int, 4));
                prmcols["@Cansales"].Value = Cansales;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds);
                con.Close();
            }
            catch
            {
            }
            return ds;
        }

        //View ProductSeri:
        public DataSet SeriSearchFromTo(string where, int from, int to)
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                int num_Row_Get = to - from;
                sqlselect = "SELECT * FROM ( ";
                sqlselect = sqlselect + "SELECT TOP " + num_Row_Get.ToString();
                sqlselect = sqlselect + " * FROM( SELECT TOP " + to.ToString() + " Id,ProductId,Name,SellingPrice,Rate,State,WareHouse,SeriNumber,Color from v_web_productseri_warehouse " + where;
                sqlselect = sqlselect + " order by SellingPrice,id) as t1 ";
                sqlselect = sqlselect + " order by SellingPrice desc,id desc) as t2 ";
                sqlselect = sqlselect + " order by SellingPrice,id";
                SqlConnection con = new SqlConnection(dataaccess.list.CSQL.sqlcn1);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, "Product");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public int SeriSearchCount(string where)
        {
            int num = 0;
            try
            {
                DataSet ds = new DataSet();
                string sqlselect = "";
                sqlselect = "select count(id) as count from v_web_productseri_warehouse " + where;
                SqlConnection con = new SqlConnection(dataaccess.list.CSQL.sqlcn1);
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
        public DataSet ProductSeriDetail(string ProductId, string SeriId)
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "select BrandName,Name,SellingPrice,CurrencyName,CurrencyRate,WarrantyMonth,Note,Cansales,StateName from v_web_product_choice where Id=" + ProductId;
                sqlselect += " select * from tbl_productseri where Id=" + SeriId;
                sqlselect += " select Name,Component from v_web_component_and_componenttype where Id in (select ComponentId from tbl_productseriandcomponent where ProductSeriId=" + SeriId + ") order by Sort";
                SqlConnection con = new SqlConnection(dataaccess.list.CSQL.sqlcn1);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, "ProductSeri");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public DataSet SeriProDetail(string SeriId)
        {
            //select * from v_web_warehouse_seri_choice where Id=1
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "select * from tbl_productseri where Id=" + SeriId;
                sqlselect += " select Name,Component from v_web_component_and_componenttype where Id in (select ComponentId from tbl_productseriandcomponent where ProductSeriId=" + SeriId + ") order by Sort";
                SqlConnection con = new SqlConnection(dataaccess.list.CSQL.sqlcn1);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, "Seridetail");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        //View Statistic Product:
        public DataSet TKSeriFromTo(string where, int from, int to)
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                int num_Row_Get = to - from;
                sqlselect = "SELECT * FROM ( ";
                sqlselect = sqlselect + "SELECT TOP " + num_Row_Get.ToString();
                sqlselect = sqlselect + " * FROM( SELECT TOP " + to.ToString() + " productId,Name,State,Sellingprice,Rate,Count(Serinumber) as numseri from v_web_productseri_warehouse " + where + " group by productId,Name,State,Rate,Sellingprice";
                sqlselect = sqlselect + " order by SellingPrice,productId) as t1 ";
                sqlselect = sqlselect + " order by SellingPrice desc,productId desc) as t2 ";
                sqlselect = sqlselect + " order by SellingPrice,productId";
                SqlConnection con = new SqlConnection(dataaccess.list.CSQL.sqlcn1);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, "Product");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public int TKSeriCount(string where)
        {
            int num = 0;
            try
            {
                DataSet ds = new DataSet();
                string sqlselect = "";
                sqlselect = "select count(productId) as Count from (select count(productId) as productId,State, count(Serinumber) as numseri from v_web_productseri_warehouse " + where + " group by productId,State)as tb1";
                SqlConnection con = new SqlConnection(dataaccess.list.CSQL.sqlcn1);
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
    }
}