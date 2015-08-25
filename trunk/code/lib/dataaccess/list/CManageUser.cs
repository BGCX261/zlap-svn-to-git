using System;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace dataaccess.list
{
    [Serializable]
    public class CManageUser
    {
        SqlDataAdapter sqlda;
        public CManageUser()
        {
            sqlda = new SqlDataAdapter();
        }
        public DataSet SelectUserLogin(string UserName)
        {
            //select top 1 Id,Name,Username,Password from tbl_employee
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select top 1 Id,Name,UserName,Password from tbl_employee where UserName ='" + UserName + "'";
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
        public DataSet SelectAllAccount()
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select Id,Name,Username from tbl_employee order by name";
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
        public DataSet SelectAccountSearch(string where)
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select Id,Name,Username from tbl_employee " + where + " order by name";
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
        public DataSet SelectAllAccountInPos(string PosId)
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select distinct Id,Name from v_web_employee_in_pos where PosId=" + PosId + " order by name";
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
        public DataSet SelectAllPosofAccount(string idUser)
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                if (idUser.Equals("0"))
                {
                    sqlselect = "select distinct Id as PosId,Name as PosName from tbl_pos order by Name";
                }
                else
                {
                    sqlselect = "select distinct PosId,PosName from v_web_employee_in_pos where Id=" + idUser + " order by PosName";
                }
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
        public DataSet selectAllKettienOfAccount(string idUser)
        {
            //select distinct Id,PosId,PosName,Name from fullkettien where EmployeeId=22 or EmployeeId1=22 or EmployeeId2=22
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                if (idUser.Equals("0"))
                {
                    sqlselect = "select distinct Id,PosId,PosName,Name from fullkettien order by Name";
                }
                else
                {
                    sqlselect = "select distinct Id,PosId,PosName,Name from fullkettien where EmployeeId=" + idUser + " or EmployeeId1=" + idUser + " or EmployeeId2=" + idUser + " order by Name";
                }
                SqlConnection con = new SqlConnection(dataaccess.list.CSQL.sqlcn2);
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
        public DataSet selectAllBankAccountOfAccount(string idUser)
        {
            //select distinct Id,PosId,PosName,Name from fullkettien where EmployeeId=22 or EmployeeId1=22 or EmployeeId2=22
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                if (idUser.Equals("0"))
                {
                    sqlselect = "select distinct Id,PosId,PosName,Name from BankAccount order by Name";
                }
                else
                {
                    sqlselect = "select distinct Id,PosId,PosName,Name from BankAccount where EmployeeId=" + idUser + " or EmployeeId1=" + idUser + " or EmployeeId2=" + idUser + " order by Name";
                }
                SqlConnection con = new SqlConnection(dataaccess.list.CSQL.sqlcn2);
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
        public DataSet selectPosOfKettien(string KetId)
        {
            //select distinct Id,PosId,PosName,Name from fullkettien where EmployeeId=22 or EmployeeId1=22 or EmployeeId2=22
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select Id,PosId,PosName from fullkettien where id=" + KetId;
                SqlConnection con = new SqlConnection(dataaccess.list.CSQL.sqlcn2);
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
        public DataSet selectDepartment(string where)
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select Id,Name from department " + where + " order by Name";
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
        public DataSet WareHouseUserPos(string UserId, string PosId)
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                if (PosId.Equals("0"))
                {
                    sqlselect = "select Id,Name FROM tbl_WareHouse where PosId>0 and Id in(select WareHouseId from tbl_EmployeeAndWareHouse where EmployeeId=" + UserId + ") order by Name";
                }
                else
                {
                    sqlselect = "select Id,Name FROM tbl_WareHouse where PosId=" + PosId + " and Id in(select WareHouseId from tbl_EmployeeAndWareHouse where EmployeeId=" + UserId + ") order by Name";
                }
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
        public DataSet WareHouseOfPos(string PosId)
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select Id,Name from tbl_WareHouse where PosId=" + PosId + " order by Name";
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
        public DataSet DestinationOfWH(string WHId)
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select Id,Name from tbl_WareHouse where Id in (Select DestinationWHId from destinationwh where WareHouseId=" + WHId + ") order by name";
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
        public DataSet SelectAllUserWareHouse(string WareHouseId)
        {
            //select Id,name from tbl_employee where Id in(select EmployeeId from tbl_EmployeeAndWareHouse where WareHouseId=1)
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select Id,name from tbl_employee where Id in(select EmployeeId from tbl_EmployeeAndWareHouse where WareHouseId=" + WareHouseId + ") order by Name";
                SqlConnection con = new SqlConnection(dataaccess.list.CSQL.sqlcn1);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, "Employee");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return ds;
        }
        public DataSet SelectAddressReport(string PosId)
        {
            DataSet ds = new DataSet();
            try
            {
                string sqlselect = "";
                sqlselect = "select * from reporttitle where PosId=" + PosId;
                SqlConnection con = new SqlConnection(dataaccess.list.CSQL.sqlcn1);
                SqlDataAdapter da = new SqlDataAdapter(sqlselect, con);
                da.Fill(ds, "Address");
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