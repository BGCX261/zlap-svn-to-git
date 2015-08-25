using System;
using System.Data;
using System.Configuration;
using System.Web;

/// <summary>
/// Class support Get value common :
/// Date: 25-08-2006
/// Create by: Lê Bùi Sùng
/// Note: Using Get data common sample: date, table Init_time
/// </summary>
namespace framework.list.common
{
    public class CGetDataCommon
    {
        public CGetDataCommon()
        {

        }
        #region Get string: Month+ Day+ Year + Second + Minute +Hour:
        public string GetStrMonthDayYearSecondMinuteHour()
        {
            string str = "";
            DateTime datetime = new DateTime();
            datetime = DateTime.Now;
            string str_Month = datetime.Month.ToString();
            string str_Day = datetime.Day.ToString();
            string str_Year = datetime.Year.ToString();
            string str_Hour = datetime.Hour.ToString();
            string str_Minute = datetime.Minute.ToString();
            string str_Second = datetime.Second.ToString();
            str = str_Month + str_Day + str_Year + str_Hour + str_Minute + str_Second.ToString();
            return str;
        }
        #endregion
        #region Get Month+ Day + secon + Minute + Houre
        public string GetStrDayMonthHourMinuteSecond()
        {
            string str = "";
            DateTime datetime = new DateTime();
            datetime = DateTime.Now;
            string str_Month = datetime.Month.ToString();
            string str_Day = datetime.Day.ToString();
            string str_Hour = datetime.Hour.ToString();
            string str_Minute = datetime.Minute.ToString();
            string str_Second = datetime.Second.ToString();
            str =  str_Day + str_Month + str_Hour + str_Minute + str_Second;
            return str;
        }
        #endregion
        #region Get String random used for create code random:
        // Date: 22-09-06
        // Create By: sungbl@thoidai.net
        // input: length code want reate
        // output: String random
        public string CreateCodeRanDom(int length_code)
        {
            string str = "";
            int i;
            int id_choice;
            string str_num = "0123456789";
            string str_char_low = "qwertyuiopasdfghjklzxcvbnm";
            string str_char_hight = "QWERTYUIOPASDFGHJKLZXCVBNM";
            Random random = new Random();
            int number_random;
            if (length_code > 0)
            {
                for (i = 0; i < length_code; i++)
                {
                    id_choice = random.Next(6);
                    if (id_choice == 2)
                    {
                        number_random = random.Next(str_char_low.Length);
                        str = str + str_char_low[number_random].ToString();
                    }
                    else
                    {
                        if (id_choice == 3)
                        {
                            number_random = random.Next(str_char_hight.Length);
                            str = str + str_char_hight[number_random].ToString();
                        }
                        else
                        {
                            number_random = random.Next(str_num.Length);
                            str = str + str_num[number_random].ToString();
                        }
                    }

                }
            }
            return str;
        }
        public int CreateNumRandom()
        {
            int numRandom = 1;
            Random random = new Random();
            numRandom+=random.Next(999);
            return numRandom;
        }
        #endregion
    }
}
