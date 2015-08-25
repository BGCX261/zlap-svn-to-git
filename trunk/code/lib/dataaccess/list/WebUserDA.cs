using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using common.list.WebUser;
using System.Data.SqlClient;
namespace dataAccess.list.WebUser
{
    /// <summary>
    ///  Create by: tuannc
    ///  Created Date: 6/7/2008 12:00:00 AM
    /// </summary>
    /// <remarks></remarks>
    public class WebUserDA
    {
        SqlCommand sqlCmd;
        SqlDataAdapter sqlDtApr;
        private const string PARA_ID = "@Id";
        private const string PARA_USERNAME = "@UserName";
        private const string PARA_PASSWORD = "@Password";
        private const string PARA_RETURN = "@RETURN";

        //Store Procedure
        private const string PRO_UPDATE = "WebUser_Update";
        private const string PRO_DELETE = "WebUser_Delete";
        private const string PRO_ADD = "WebUser_Insert";

        #region "public Methods"

        public int Insert(common.list.WebUser.WebUser obj)
        {
            int result = 0;
            SqlTransaction trans = null;
            SqlConnection conn = new SqlConnection(dataaccess.configsql.strcon);
            conn.Open();
            sqlDtApr = new SqlDataAdapter();
            try
            {
                trans = conn.BeginTransaction();
                sqlDtApr.InsertCommand = GetInsertCommand(conn, trans, obj);
                sqlDtApr.InsertCommand.ExecuteNonQuery();
                result = System.Convert.ToInt32(sqlCmd.Parameters[PARA_RETURN].Value);
                trans.Commit();
            }
            catch (System.Exception ex)
            {
                Console.Write("Error in WebUserDA:" + ex.StackTrace);
                trans.Rollback();
                return 0;
            }
            finally
            {
                trans.Dispose();
                conn.Close();
            }
            return result;
        }

        public Boolean Update(common.list.WebUser.WebUser obj)
        {
            SqlTransaction trans = null;
            SqlConnection conn = new SqlConnection(dataaccess.configsql.strcon);
            conn.Open();
            sqlDtApr = new SqlDataAdapter();
            try
            {
                trans = conn.BeginTransaction();
                sqlDtApr.UpdateCommand = GetUpdateCommand(conn, trans, obj);
                sqlDtApr.UpdateCommand.ExecuteNonQuery();
                trans.Commit();
            }
            catch (System.Exception ex)
            {
                Console.Write("Error in WebUserDA:" + ex.StackTrace);
                trans.Rollback();
                return false;
            }
            finally
            {
                trans.Dispose();
                conn.Close();
            }
            return true;
        }

        public Boolean Delete(int ID)
        {
            SqlConnection conn = new SqlConnection(dataaccess.configsql.strcon);
            conn.Open();
            sqlDtApr = new SqlDataAdapter();
            try
            {
                sqlDtApr.DeleteCommand = GetDeleteCommand(conn, ID);
                sqlDtApr.DeleteCommand.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                Console.Write("Error in WebUserDA:" + ex.StackTrace);
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }

        public Boolean CheckExist(common.list.WebUser.WebUser obj)
        {
            SqlConnection conn = new SqlConnection(dataaccess.configsql.strcon);
            conn.Open();
            try
            {
                DataTable tbl = new DataTable();
                string _sqltext = " select * from " + WebUserCM.TABLE_NAME + " where " +
                WebUserCM.FLD_ID + "<>" + obj.Id + " and " +
                WebUserCM.FLD_USERNAME + "=N'" + obj.UserName + "'" + " and " +
                WebUserCM.FLD_PASSWORD + "=N'" + obj.Password + "'";
                sqlDtApr = new SqlDataAdapter(_sqltext, conn);
                sqlDtApr.Fill(tbl);
                if (tbl.Rows.Count > 0)
                {
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                Console.Write("Error in WebUserDA:" + ex.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }
        # endregion

        #region "private Methods"

        private SqlCommand GetInsertCommand(SqlConnection con, SqlTransaction sqlTransaction,
        common.list.WebUser.WebUser obj)
        {
            try
            {
                if (con == null) return null;
                sqlCmd = new SqlCommand(PRO_ADD, con, sqlTransaction);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection sqlParams = sqlCmd.Parameters;
                // add parameter to store
                sqlParams.AddWithValue(PARA_USERNAME, obj.UserName);
                sqlParams.AddWithValue(PARA_PASSWORD, obj.Password);
                sqlParams.Add(PARA_RETURN, SqlDbType.Int, 4);
                sqlParams[PARA_RETURN].Direction = ParameterDirection.ReturnValue;
            }
            catch (System.Exception ex)
            {
                Console.Write("Error in WebUserDA:" + ex.StackTrace);
            }
            return sqlCmd;
        }

        private SqlCommand GetUpdateCommand(SqlConnection con, SqlTransaction tran,
        common.list.WebUser.WebUser obj)
        {
            try
            {
                if (con == null) return null;
                sqlCmd = new SqlCommand(PRO_UPDATE, con, tran);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection sqlParams = sqlCmd.Parameters;
                // add parameter to store
                sqlParams.AddWithValue(PARA_ID, obj.Id);
                sqlParams.AddWithValue(PARA_USERNAME, obj.UserName);
                sqlParams.AddWithValue(PARA_PASSWORD, obj.Password);
            }
            catch (System.Exception ex)
            {
                Console.Write("Error in WebUserDA:" + ex.StackTrace);
            }
            return sqlCmd;
        }

        private SqlCommand GetDeleteCommand(SqlConnection con, int id)
        {
            try
            {
                if (con == null) return null;
                sqlCmd = new SqlCommand(PRO_DELETE, con);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection sqlParams = sqlCmd.Parameters;
                sqlParams.AddWithValue(PARA_ID, id);
            }
            catch (System.Exception ex)
            {
                Console.Write("Error in WebUserDA:" + ex.StackTrace);
            }
            return sqlCmd;
        }
        # endregion

        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(dataaccess.configsql.strcon);
            conn.Open();
            try
            {
                DataTable tbl = new DataTable();
                string _sqltext = " select * from " + WebUserCM.TABLE_NAME;
                sqlDtApr = new SqlDataAdapter(_sqltext, conn);
                sqlDtApr.Fill(tbl);
                return tbl;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable Select(string sql)
        {
            SqlConnection conn = new SqlConnection(dataaccess.configsql.strcon);
            conn.Open();
            try
            {
                DataTable tbl = new DataTable();
                sqlDtApr = new SqlDataAdapter(sql, conn);
                sqlDtApr.Fill(tbl);
                return tbl;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}