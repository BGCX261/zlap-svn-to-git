using System;
using System.Data;
using System.Data.SqlClient;   
using System.Configuration;
using System.Web;
using System.Collections;

/// <summary>
/// 
/// Class used to Manage Error when input information 
///  Date: 19-08-2006
///  Create by: Lê Bùi Sùng
///  
///=============================================================================
///
namespace framework.list.common
{
    public class CManageError
    {

        private ArrayList listerror;
        private int numErr = 0;
        public CManageError()
        {
            this.listerror = new ArrayList();
            this.numErr = 0;
        }
        public void AddError(string str_err)
        {
            listerror.Add(str_err);
        }
        public string GetAllError()
        {
            int i;
            string str = "";
            str = str + " <Table> ";
            this.numErr = listerror.Count;
            if (this.numErr > 0)
            {
                for (i = 0; i < numErr; i++)
                {
                    str = str + " <tr><td align='left'> " + " * " + listerror[i].ToString() + " </td></tr> ";
                }
            }
            str = str + " </Table> ";
            return str;
        }
        public int GetNumberErr()
        {
            this.numErr = listerror.Count;
            return this.numErr;
        }
    }
}