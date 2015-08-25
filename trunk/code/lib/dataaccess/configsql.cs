using System;
using System.Collections.Generic;
using System.Text;

namespace dataaccess
{
    public class configsql
    {
        static string sqlconnect = "";
        public static string strcon
        {
            set 
            {}
            get 
            {
                if (sqlconnect.Length == 0)
                {
                    //sqlconnect = "server=112.213.89.26;database=maytinhxachtay_com_SGEWMS;user id=mtxt2010;password=";
                    sqlconnect = "server=localhost;database=wm;user id=sa;password=sa";
                }
                 return sqlconnect;
            }
        }
        private string GetSQl()
        {
            string str = "";
            return str;
        }
    }
}