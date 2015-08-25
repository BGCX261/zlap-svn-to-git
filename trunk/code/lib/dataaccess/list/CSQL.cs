using System;
using System.Collections.Generic;
using System.Text;

namespace dataaccess.list
{
    [Serializable]
    public class CSQL
    {
        static string strcn1 = "";
        static string strcn2 = "";
        public static string sqlcn1
        {
            set
            { }
            get
            {
                if (strcn1.Length == 0)
                {
                    //strcn1 = "server=localhost;database=wms_local;user id=sa;password=sa";
                    strcn1 = "server=112.213.89.26;database=maytinhxachtay_com_SGEWMS;user id=mtxt2009;password=kashmiryenbinh";
                    //strcn1 = "server=mssql502.hostexcellence.com;database=C268754_mtxt;user id=C268754_Wm2009;password=Korea2009";
                    //strcn1 = "server=112.213.89.26;database=wm2009;user id=wm2009;password=northkorea";
                }
                return strcn1;
            }
        }
        public static string sqlcn2
        {
            set
            { }
            get
            {
                if (strcn2.Length == 0)
                {
                    //strcn2 = "server=localhost;database=wms_local;user id=sa;password=sa";
                    strcn2 = "server=mssql502.hostexcellence.com;database=C268754_Wm2009;user id=C268754_Wm2009;password=Korea2009";
                }
                return strcn2;
            }
        }
    }
}