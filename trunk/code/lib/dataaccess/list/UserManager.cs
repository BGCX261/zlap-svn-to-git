using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using common.list;
using System.Collections;
namespace dataaccess.list
{
    public class UserManager
    {
        SqlDataAdapter sqlda;
        public UserManager()
        {
            sqlda = new SqlDataAdapter();
        }
        public DataSet UserGetUserAndPass(string user)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_user_select_acount_pass", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@user", SqlDbType.VarChar, 25));
                prmcols["@user"].Value = user;
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
        public UserAccount_data UserGetInformation(int id)
        {
            UserAccount_data ds = new UserAccount_data();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_user_select_infor_account", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = id;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds,UserAccount_data._table);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public DataSet UserTestUserNameAndEmail(string username,string email)
        {
            //w_user_select_username_email
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_user_select_username_email", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@username", SqlDbType.VarChar, 25));
                prmcols["@username"].Value = username;
                prmcols.Add(new SqlParameter("@email", SqlDbType.VarChar, 50));
                prmcols["@email"].Value = email;
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
        public DataSet UserGetFromTo(int from, int to)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_user_select_all_test", con);
                command.CommandType = CommandType.StoredProcedure;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds,from,to-from,"user");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public DataSet UserIdGetTopFromTo(int from, int to)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_user_select_all_test", con);
                command.CommandType = CommandType.StoredProcedure;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds, from, to - from, "user");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public Boolean UserInsert(string user, string pass, string name, string company, string job, string baddress, string bcity, string bzip, string bcountry, string saddress, string scity, string szip, string scountry, string mphone, string ophone, string hphone, string fax,string tax, string email1, string email2, string website)
        {
            Boolean test = true;
            //w_user_insert
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_user_insert", con);
                command.CommandType = CommandType.StoredProcedure;
                //1: username:
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@username", SqlDbType.VarChar, 25));
                prmcols["@username"].Value = user;
                //2: password:
                prmcols.Add(new SqlParameter("@password", SqlDbType.VarChar, 255));
                prmcols["@password"].Value = pass;
                //3: contactname:
                prmcols.Add(new SqlParameter("@contactname", SqlDbType.NVarChar, 50));
                prmcols["@contactname"].Value = name;
                //4: company:
                prmcols.Add(new SqlParameter("@company", SqlDbType.NVarChar, 255));
                prmcols["@company"].Value = company;
                //5: jobtitle:
                prmcols.Add(new SqlParameter("@jobtitle", SqlDbType.NVarChar, 50));
                prmcols["@jobtitle"].Value = job;
                //6: billingaddress:
                prmcols.Add(new SqlParameter("@billingaddress", SqlDbType.NVarChar, 128));
                prmcols["@billingaddress"].Value = baddress;
                //7: billingcity:
                prmcols.Add(new SqlParameter("@billingcity", SqlDbType.NVarChar, 128));
                prmcols["@billingcity"].Value = bcity;
                //8: billingzipcode:
                prmcols.Add(new SqlParameter("@billingzipcode", SqlDbType.NVarChar, 128));
                prmcols["@billingzipcode"].Value = bzip;
                //9: billingcountry:
                prmcols.Add(new SqlParameter("@billingcountry", SqlDbType.NVarChar, 128));
                prmcols["@billingcountry"].Value = bcountry;
                //10: shippingaddress:
                prmcols.Add(new SqlParameter("@shippingaddress", SqlDbType.NVarChar, 128));
                prmcols["@shippingaddress"].Value = saddress;
                //11: shippingcity:
                prmcols.Add(new SqlParameter("@shippingcity", SqlDbType.NVarChar, 128));
                prmcols["@shippingcity"].Value = scity;
                //12: shippingzipcode:
                prmcols.Add(new SqlParameter("@shippingzipcode", SqlDbType.NVarChar, 128));
                prmcols["@shippingzipcode"].Value = szip;
                //13: shippingcountry:
                prmcols.Add(new SqlParameter("@shippingcountry", SqlDbType.NVarChar, 128));
                prmcols["@shippingcountry"].Value = scountry;
                //14: mobilephone:
                prmcols.Add(new SqlParameter("@mobilephone", SqlDbType.VarChar, 20));
                prmcols["@mobilephone"].Value = mphone;
                //15: officephone:
                prmcols.Add(new SqlParameter("@officephone", SqlDbType.VarChar, 20));
                prmcols["@officephone"].Value = ophone;
                //16: homephone:
                prmcols.Add(new SqlParameter("@homephone", SqlDbType.VarChar, 20));
                prmcols["@homephone"].Value = hphone;
                //17: faxnumber:
                prmcols.Add(new SqlParameter("@faxnumber", SqlDbType.VarChar, 20));
                prmcols["@faxnumber"].Value = fax;
                //18: taxcode:
                prmcols.Add(new SqlParameter("@taxcode", SqlDbType.VarChar, 50));
                prmcols["@taxcode"].Value = tax;
                //19: email1:
                prmcols.Add(new SqlParameter("@email1", SqlDbType.VarChar, 50));
                prmcols["@email1"].Value = email1;
                //20: email2:
                prmcols.Add(new SqlParameter("@email2", SqlDbType.VarChar, 50));
                prmcols["@email2"].Value = email2;
                //20: website:
                prmcols.Add(new SqlParameter("@website", SqlDbType.VarChar, 128));
                prmcols["@website"].Value = website;
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
        public DataSet GetDsFromTo(string name_Column_Order_By, string table_Name,int from, int to)
        {
            DataSet ds1 = new DataSet();
            if ((from >= 0) && (to > 0))
            {
                try
                {
                    string sqlselect = "";
                    Int64 num_Row_Get = to - from;
                    sqlselect = "SELECT * FROM ( ";
                    sqlselect = sqlselect + "SELECT TOP " + num_Row_Get.ToString();
                    sqlselect = sqlselect + " * FROM( SELECT TOP " + to.ToString() + " * FROM [" + table_Name + "]";
                    sqlselect = sqlselect + " order by [" + name_Column_Order_By + "] asc) as t1 ";
                    sqlselect = sqlselect + " order by [" + name_Column_Order_By + "] desc) as t2 ";
                    sqlselect = sqlselect + " order by [" + name_Column_Order_By + "] asc ";
                    SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                    SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                    da.Fill(ds1, "tbl" + table_Name);
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                }
            }
            return ds1;
        }
        public DataSet GetPayMent()
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select * from paymentmethod";
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
        public string getOrderNumber()
        {
            string OrderNumber = DateTime.Today.ToString("yyyyMMdd");
            string sql = "SELECT MAX(OrderNumber) as OrderNumber FROM [Order] WHERE OrderNumber like '" + OrderNumber + "%'";
            DataTable table = new DataTable();
            try
            {
                //w_product_id_type
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(table);
                con.Close();
                if (table.Rows.Count > 0)
                {
                    OrderNumber = table.Rows[0]["OrderNumber"].ToString();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            if (OrderNumber.Length == 0)
            {
                OrderNumber = DateTime.Today.ToString("yyyyMMdd") + "0000";
            }
            try
            {
                OrderNumber = Convert.ToString((Convert.ToInt64(OrderNumber) + 1));
            }
            catch
            {
                
            }
            return OrderNumber;
        }
        public DataSet TestUserGetIdFromTo(int from,int to)
        {
            DataSet ds1 = new DataSet();
            if ((from >= 0) && (to > 0))
            {
                try
                {
                    string sqlselect = "";
                    int num_Row_Get = to - from;
                    sqlselect = "SELECT id FROM ( ";
                    sqlselect = sqlselect + "SELECT TOP " + num_Row_Get.ToString();
                    sqlselect = sqlselect + " id FROM( SELECT TOP " + to.ToString() + " id FROM [tbl_customeraccount]";
                    sqlselect = sqlselect + " order by [id] asc) as t1 ";
                    sqlselect = sqlselect + " order by [id] desc) as t2 ";
                    sqlselect = sqlselect + " order by [id] asc ";
                    SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                    SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                    da.Fill(ds1, "tbl_use_id");
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                }
            }
            return ds1;
        }
        public DataSet TestUserGetGroupId(string group)
        {
            DataSet ds1 = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "SELECT * from tbl_customeraccount where id in (" + group + ")";
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds1, "tbl_use");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds1;
        }
        public DataSet OrderSelectIdUser(string iduser)
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select top 100 idorder,ordernumber,shipdate,shippingname,shippingaddress,id,name from v_web_order_quick_view where customerid=" + iduser + "  order by orderdate desc,id";
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
        public int OrderUserCount(string where)
        {
            
            try
            {
                DataSet ds = new DataSet();
                string sqlselect = "";
                sqlselect = "select count(idorder) as count from v_web_order_quick_view " + where;
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds);
                con.Close();
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return (int)ds.Tables[0].Rows[0]["count"];
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return 0;
            }
            return 0;
        }
        public DataSet OrderUserFromTo(string where, int from, int to)
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                int num_Row_Get = to - from;
                sqlselect = "SELECT * FROM ( ";
                sqlselect = sqlselect + "SELECT TOP " + num_Row_Get.ToString();
                sqlselect = sqlselect + " * FROM( SELECT TOP " + to.ToString() + " idorder,orderDate,ordernumber,shipdate,shippingname,shippingaddress,id,name from v_web_order_quick_view " + where;
                sqlselect = sqlselect + " order by orderDate desc,idorder) as t1 ";
                sqlselect = sqlselect + " order by orderDate asc,idorder) as t2 ";
                sqlselect = sqlselect + " order by orderDate desc,idorder";
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, "OrderUser");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public DataSet OrderSelectDetailId(int id,int iduser)
        { 
            //w_order_user_select_detail_id:
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_order_user_select_detail_id", con);
                command.CommandType = CommandType.StoredProcedure;
                //1: username:
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = id;
                prmcols.Add(new SqlParameter("@iduser", SqlDbType.Int, 4));
                prmcols["@iduser"].Value = iduser;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds);
                con.Close();
            }
            catch
            {
            }
            return ds;
        }
        public int InsertOrder(string oNumber,int pId,DateTime oDate,int eId,int cId,int posId,int oSId,int oTId,int  daysrequest,int shipperId,string shippername,float shippingFee,int currencyId,float currencyRate,string sName,string sAddress,string sCity,string sZipCode,string sCountry,string phone,string email,string note)
        {
            int id = 0;
            //w_user_insert
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_order_insert", con);
                command.CommandType = CommandType.StoredProcedure;
                //1: OrderNumber:
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@OrderNumber", SqlDbType.VarChar, 50));
                prmcols["@OrderNumber"].Value = oNumber;
                //2: ParentId:
                prmcols.Add(new SqlParameter("@ParentId", SqlDbType.Int, 4));
                prmcols["@ParentId"].Value = pId;
                //3: OrderDate:
                prmcols.Add(new SqlParameter("@OrderDate", SqlDbType.DateTime, 8));
                prmcols["@OrderDate"].Value = oDate;
                //4: EmployeeId:
                prmcols.Add(new SqlParameter("@EmployeeId", SqlDbType.Int, 4));
                prmcols["@EmployeeId"].Value = eId;
                //5: CustomerId:
                prmcols.Add(new SqlParameter("@CustomerId", SqlDbType.Int, 4));
                prmcols["@CustomerId"].Value = cId;
                //6: POSId:
                prmcols.Add(new SqlParameter("@POSId", SqlDbType.Int, 4));
                prmcols["@POSId"].Value = posId;
                //7: OrderStateId:
                prmcols.Add(new SqlParameter("@OrderStateId", SqlDbType.Int, 4));
                prmcols["@OrderStateId"].Value = oSId;
                //8: OrderTypeId:
                prmcols.Add(new SqlParameter("@OrderTypeId", SqlDbType.Int, 4));
                prmcols["@OrderTypeId"].Value = oTId;
                //9: ShipDate:
                prmcols.Add(new SqlParameter("@ShipDate", SqlDbType.Int, 4));
                prmcols["@ShipDate"].Value = daysrequest;
                //10: ShipperId:
                prmcols.Add(new SqlParameter("@ShipperId", SqlDbType.Int, 4));
                prmcols["@ShipperId"].Value = DBNull.Value;
                //11: ShipperName:
                prmcols.Add(new SqlParameter("@ShipperName", SqlDbType.NVarChar, 128));
                prmcols["@ShipperName"].Value = shippername;
                //12: ShippingFee:
                prmcols.Add(new SqlParameter("@ShippingFee", SqlDbType.Float, 8));
                prmcols["@ShippingFee"].Value = shippingFee;
                //13: CurrencyId:
                prmcols.Add(new SqlParameter("@CurrencyId", SqlDbType.Int, 4));
                prmcols["@CurrencyId"].Value = currencyId;
                //14: CurrencyRate:
                prmcols.Add(new SqlParameter("@CurrencyRate", SqlDbType.Float, 8));
                prmcols["@CurrencyRate"].Value = currencyRate;
                //15: ShippingName:
                prmcols.Add(new SqlParameter("@ShippingName", SqlDbType.NVarChar, 128));
                prmcols["@ShippingName"].Value = sName;
                //16: ShippingAddress:
                prmcols.Add(new SqlParameter("@ShippingAddress", SqlDbType.NVarChar, 128));
                prmcols["@ShippingAddress"].Value = sAddress;
                //17: ShippingCity:
                prmcols.Add(new SqlParameter("@ShippingCity", SqlDbType.NVarChar, 128));
                prmcols["@ShippingCity"].Value = sCity;
                //18: ShippingZipCode:
                prmcols.Add(new SqlParameter("@ShippingZipCode", SqlDbType.NVarChar, 128));
                prmcols["@ShippingZipCode"].Value = sZipCode;
                //19: ShippingCountry:
                prmcols.Add(new SqlParameter("@ShippingCountry", SqlDbType.NVarChar, 128));
                prmcols["@ShippingCountry"].Value = sCountry;
                //20: Phone:
                prmcols.Add(new SqlParameter("@Phone", SqlDbType.NVarChar, 50));
                prmcols["@Phone"].Value = phone;
                //21: Email:
                prmcols.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 50));
                prmcols["@Email"].Value = email;
                //22: Note:
                prmcols.Add(new SqlParameter("@Note", SqlDbType.NVarChar, 256));
                prmcols["@Note"].Value = note;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds);
                con.Close();
                if (ds.Tables.Count > 0)
                { 
                    id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return id;
        }
        public DataSet PosSelectAll()
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select Id,Show as Name from tbl_pos where IsShowOnWeb=1";
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
        public DataSet OrderState()
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select * from orderstate";
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
        public DataSet CurrencyCurrent(string name)
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select Id,Rate from tbl_currency where Name='" + name + "'";
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
        public DataSet SelectInforForOrder(int idUser, string currencyName)
        {
            //w_select_infor_for_order
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_select_infor_for_order", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@iduser", SqlDbType.Int, 4));
                prmcols["@iduser"].Value = idUser;
                prmcols.Add(new SqlParameter("@currencyName", SqlDbType.VarChar, 50));
                prmcols["@currencyName"].Value = currencyName;
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
        public Boolean InsertOrderDetail(int OrderId, float currencyrate, float discount, float tax, ArrayList listpro)
        {
            Boolean test = true;
            try
            {
                int numPro = listpro.Count;
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                for (int i = 0; i < numPro; i++)
                {
                    SqlCommand command = new SqlCommand("w_orderdetail_insert", con);
                    command.CommandType = CommandType.StoredProcedure;
                    string[] arrValue = (string[])listpro[i];
                    int idPro = int.Parse(arrValue[0]);
                    int ispro = int.Parse(arrValue[1]);
                    string seri = arrValue[2];
                    float Quantity = float.Parse(arrValue[3]);
                    float Price = float.Parse(arrValue[4]);
                    float RateNow = float.Parse(arrValue[5]);
                    SqlParameterCollection prmcols = command.Parameters;
                    prmcols.Add(new SqlParameter("@orderId", SqlDbType.Int, 4));
                    prmcols["@orderId"].Value = OrderId;
                    prmcols.Add(new SqlParameter("@idproduct", SqlDbType.Int, 4));
                    prmcols["@idproduct"].Value = idPro;
                    prmcols.Add(new SqlParameter("@isproduct", SqlDbType.Int, 4));
                    prmcols["@isproduct"].Value = ispro;
                    prmcols.Add(new SqlParameter("@seriNumber", SqlDbType.NVarChar, 128));
                    prmcols["@seriNumber"].Value = seri;
                    prmcols.Add(new SqlParameter("@Quantity", SqlDbType.Float, 8));
                    prmcols["@Quantity"].Value = Quantity;
                    prmcols.Add(new SqlParameter("@Price", SqlDbType.Float, 8));
                    prmcols["@Price"].Value = Price;
                    prmcols.Add(new SqlParameter("@CurrencyRate", SqlDbType.Float, 8));
                    prmcols["@CurrencyRate"].Value = RateNow;
                    prmcols.Add(new SqlParameter("@Discount", SqlDbType.Float, 8));
                    prmcols["@Discount"].Value = discount;
                    prmcols.Add(new SqlParameter("@Tax", SqlDbType.Float, 8));
                    prmcols["@Tax"].Value = tax;
                    sqlda.SelectCommand = command;
                    sqlda.Fill(ds);
                    con.Close();
                }
            }
            catch
            {
                test = false;
            }
            return test;
        }
        public DataSet UserGetInforFeedBack(string id)
        { 
            //select ContactName MobilePhone,OfficePhone,HomePhone,Email1 from tbl_customeraccount where id=2
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select ContactName,MobilePhone,OfficePhone,HomePhone,Email1 from tbl_customeraccount where id=" + id;
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
        public Boolean UserSendFeedback(int idUser, string title, string content, DateTime datetime, int type)
        {
            //w_customeropinion_insert
             Boolean test = true;
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_customeropinion_insert", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@CustomerId", SqlDbType.Int, 4));
                prmcols["@CustomerId"].Value = idUser;
                prmcols.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 128));
                prmcols["@Name"].Value = title;
                prmcols.Add(new SqlParameter("@Comment", SqlDbType.NVarChar, 2000));
                prmcols["@Comment"].Value = content;
                prmcols.Add(new SqlParameter("@CommentDate", SqlDbType.DateTime, 8));
                prmcols["@CommentDate"].Value = datetime;
                prmcols.Add(new SqlParameter("@OpinionTypeId", SqlDbType.Int, 4));
                prmcols["@OpinionTypeId"].Value = type;
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
        public DataSet UserWithRowCountFromTo(int page, int size)
        {
            //cusloadpage
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("cusloadpage", con);
                command.CommandType = CommandType.StoredProcedure;
                //1: username:
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@pagesize", SqlDbType.Int, 4));
                prmcols["@pagesize"].Value = size;
                prmcols.Add(new SqlParameter("@pagenumber", SqlDbType.Int, 4));
                prmcols["@pagenumber"].Value = page;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds);
                con.Close();
            }
            catch
            { 
            
            }
            return ds;
        }
        public DataSet UserSelectAccountWithEmail(string email)
        {
            //w_user_select_account_email
            DataSet ds = new DataSet();
            try
            {

                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_user_select_account_email", con);
                command.CommandType = CommandType.StoredProcedure;
                //1: username:
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@email", SqlDbType.VarChar, 255));
                prmcols["@email"].Value = email;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds);
                con.Close();

            }
            catch
            {

            }
            return ds;
        }
        public Boolean UserRequestNewPassInsert(string code, string name, string email, DateTime time)
        {
            //w_user_insert_request_pass:
            Boolean test = true;
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_user_insert_request_pass", con);
                command.CommandType = CommandType.StoredProcedure;
                //1: username:
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@name", SqlDbType.NVarChar, 128));
                prmcols["@name"].Value = name;
                prmcols.Add(new SqlParameter("@code", SqlDbType.VarChar, 64));
                prmcols["@code"].Value = code;
                prmcols.Add(new SqlParameter("@email", SqlDbType.VarChar, 128));
                prmcols["@email"].Value = email;
                prmcols.Add(new SqlParameter("@time", SqlDbType.DateTime, 8));
                prmcols["@time"].Value = time;
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
        public DataSet UserTestInfoGetNewPass(string code)
        {
            DataSet ds = new DataSet();
            //w_user_select_test_get_pass:
            try
            {
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_user_select_test_get_pass", con);
                command.CommandType = CommandType.StoredProcedure;
                //1: username:
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@code", SqlDbType.VarChar, 64));
                prmcols["@code"].Value = code;
                sqlda.SelectCommand = command;
                sqlda.Fill(ds);
                con.Close();
            }
            catch
            {
            }
            return ds;
        }
        public Boolean UserUpdateNewPass(string email, string pass)
        {
            Boolean test = true;
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_user_update_pass", con);
                command.CommandType = CommandType.StoredProcedure;
                //1: username:
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@email", SqlDbType.VarChar, 255));
                prmcols["@email"].Value = email;
                prmcols.Add(new SqlParameter("@pass", SqlDbType.VarChar, 128));
                prmcols["@pass"].Value = pass;
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
        public Boolean UserUpdateNewPassId(int id, string pass)
        {
            Boolean test = true;
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_user_change_pass", con);
                command.CommandType = CommandType.StoredProcedure;
                //1: username:
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = id;
                prmcols.Add(new SqlParameter("@pass", SqlDbType.VarChar, 128));
                prmcols["@pass"].Value = pass;
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
        public Boolean UserUpdateInfoId(int id,string contactname,string company,string job,string mobile,string officephome,string homephone,string email2,string fax,string tax,string website)
        {
            Boolean test = true;
            //w_user_insert
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_user_unpdate_info_id", con);
                command.CommandType = CommandType.StoredProcedure;
                //1: id:
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = id;
                //2: contactname:
                prmcols.Add(new SqlParameter("@name", SqlDbType.NVarChar, 50));
                prmcols["@name"].Value = contactname;
                //3: company:
                prmcols.Add(new SqlParameter("@company", SqlDbType.NVarChar, 255));
                prmcols["@company"].Value = company;
                //4: jobtitle:
                prmcols.Add(new SqlParameter("@job", SqlDbType.NVarChar, 50));
                prmcols["@job"].Value = job;
                //5: mobilephone:
                prmcols.Add(new SqlParameter("@mobilephone", SqlDbType.VarChar, 20));
                prmcols["@mobilephone"].Value = mobile;
                //6: officephone:
                prmcols.Add(new SqlParameter("@officephone", SqlDbType.VarChar, 20));
                prmcols["@officephone"].Value = officephome;
                //7: homephone:
                prmcols.Add(new SqlParameter("@homephone", SqlDbType.VarChar, 20));
                prmcols["@homephone"].Value = homephone;
                //8: email2:
                prmcols.Add(new SqlParameter("@email2", SqlDbType.VarChar, 50));
                prmcols["@email2"].Value = email2;
                //9: faxnumber:
                prmcols.Add(new SqlParameter("@fax", SqlDbType.VarChar, 20));
                prmcols["@fax"].Value = fax;
                //10: taxcode:
                prmcols.Add(new SqlParameter("@tax", SqlDbType.VarChar, 50));
                prmcols["@tax"].Value = tax;
                //11: website:
                prmcols.Add(new SqlParameter("@website", SqlDbType.VarChar, 128));
                prmcols["@website"].Value = website;
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
        public Boolean UserUpdateBillingId(int id, string address, string city, string zipcode, string country)
        {
            Boolean test = true;
            //w_user_insert
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_user_update_billing", con);
                command.CommandType = CommandType.StoredProcedure;
                //1: id:
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = id;
                //2: id:
                prmcols.Add(new SqlParameter("@billingaddress", SqlDbType.NVarChar, 128));
                prmcols["@billingaddress"].Value = address;
                //3: billingcity:
                prmcols.Add(new SqlParameter("@billingcity", SqlDbType.NVarChar, 128));
                prmcols["@billingcity"].Value = city;
                //4: billingzipcode:
                prmcols.Add(new SqlParameter("@billingzipcode", SqlDbType.NVarChar, 128));
                prmcols["@billingzipcode"].Value = zipcode;
                //5: billingcountry:
                prmcols.Add(new SqlParameter("@billingcountry", SqlDbType.NVarChar, 128));
                prmcols["@billingcountry"].Value = country;
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
        public Boolean UserUpdateShippingId(int id, string address, string city, string zipcode, string country)
        {
            Boolean test = true;
            //w_user_insert
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(dataaccess.configsql.strcon);
                con.Open();
                SqlCommand command = new SqlCommand("w_user_update_shipping", con);
                command.CommandType = CommandType.StoredProcedure;
                //1: id:
                SqlParameterCollection prmcols = command.Parameters;
                prmcols.Add(new SqlParameter("@id", SqlDbType.Int, 4));
                prmcols["@id"].Value = id;
                //2: shippingaddress:
                prmcols.Add(new SqlParameter("@shippingaddress", SqlDbType.NVarChar, 128));
                prmcols["@shippingaddress"].Value = address;
                //3: shippingcity:
                prmcols.Add(new SqlParameter("@shippingcity", SqlDbType.NVarChar, 128));
                prmcols["@shippingcity"].Value = city;
                //4: shippingzipcode:
                prmcols.Add(new SqlParameter("@shippingzipcode", SqlDbType.NVarChar, 128));
                prmcols["@shippingzipcode"].Value = zipcode;
                //5: shippingcountry:
                prmcols.Add(new SqlParameter("@shippingcountry", SqlDbType.NVarChar, 128));
                prmcols["@shippingcountry"].Value = country;
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