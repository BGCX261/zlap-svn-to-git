using System;
using System.Collections.Generic;
using System.Text;

namespace framework.list.common
{
    [Serializable]
    public class CTime
    {
        public static DateTime GetTimeHaNoi()
        {
            DateTime time = new DateTime();
            try
            {
                time = DateTime.Now.ToUniversalTime();
                time = time.AddHours(7);
            }
            catch
            { }
            return time;
        }
    }
}
