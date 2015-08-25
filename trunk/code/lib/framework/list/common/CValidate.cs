using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Net.Mail;
using System.Text.RegularExpressions;
//===============================================================================
//  Date:25/08/2006
//  Create by: Lê Bùi Sùng
//  Using test Validate.
//===============================================================================
/// <summary>
/// Class using test validate of string, number, maxleng, .....
/// </summary>
/// 
namespace framework.list.common
{
    public class CValidate
    {
        public CValidate()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region 1:test is Number ? return true if is number else return false:
        public bool isNumber(string str)
        {
            bool test = true;
            int str_length, i;
            string str_number = "0123456789";
            str_length = str.Length;
            if (str_length > 0)
            {
                for (i = 0; i < str_length; i++)
                {
                    if (!ExsitCharInString(str[i], str_number))
                    {
                        test = false;
                    }
                }
            }
            else
            {
                test = false;
            }
            return test;
        }
        private bool ExsitCharInString(char str_char, string str)
        {
            bool test = false;
            int i, str_length;
            if ((str_char != 0) && (str.Length > 0))
            {
                str_length = str.Length;
                for (i = 0; i < str_length; i++)
                {
                    if (str_char.Equals(str[i]))
                    {
                        test = true;
                    }
                }
            }
            return test;
        }
        #endregion
        #region 2:Test is number integer:
        public bool isInt32(string str_int)
        {
            bool test = false;
            int num = 0;
            try
            {
                num = int.Parse(str_int);
                test = true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                test = false;
            }
            return test;
        }
        #endregion
        #region 3: test is number int64:
        public bool idInt64(string str_int64)
        {
            bool test = false;
            Int64 num = 0;
            try
            {
                num = Int64.Parse(str_int64);
                test = true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                test = false;
            }
            return test;
        }
        #endregion
        #region 4: Test Maxlength
        //
        // If (str.Length >Maxlength return true, else return false)
        //
        public bool isMaxLength(int Maxlength, string str)
        {
            bool test = false;
            if ((str.Length > 0) && (Maxlength > 0))
            {
                if (str.Length > Maxlength)
                {
                    test = true;
                }
            }
            return test;
        }
        #endregion
        #region 5: Test MinLength
        //
        // if (str.Length<MinLength return true, else return false)
        //
        public bool isMinLength(int MinLength, string str)
        {
            bool test = true;
            if ((str.Length > 0) && (MinLength > 0))
            {
                if (str.Length > MinLength)
                {
                    test = false;
                }
            }
            return test;
        }
        #endregion
        private string DevideString(int lengthdivide, string value)
        {
            string str = "";
            int index, i;
            if (lengthdivide > 0)
            {
                index = value.Length / lengthdivide;
                if ((value.Length % lengthdivide) > 0)
                {
                    index++;
                }
                for (i = 0; i < index; i++)
                {
                    if ((value.Length - (i * lengthdivide)) > lengthdivide)
                    {
                        str = str + value.Substring(i * lengthdivide, lengthdivide) + " ";
                    }
                    else
                    {
                        str = str + value.Substring(i * lengthdivide, (value.Length - (i * lengthdivide))) + " ";
                    }
                }
            }
            return str.Trim();
        }
        public string ConvertString(int lengdevide, string str)
        {
            string strchange = "";
            int num_Word, i;
            string[] arrstr;
            if (str.Length > 0)
            {
                arrstr = str.Split(' ');
                num_Word = arrstr.Length;
                for (i = 0; i < num_Word; i++)
                    if (arrstr[i].Length > lengdevide)
                    {
                        strchange = strchange + DevideString(lengdevide, arrstr[i]) + " ";
                    }
                    else
                    {
                        if (arrstr[i].Length > 0)
                        {
                            strchange = strchange + arrstr[i] + " ";
                        }
                    }
            }
            strchange = strchange.Trim();
            return strchange;
        }
        public bool ExistWordLength(int lenght, string str)
        {
            bool test = false;
            if ((lenght > 0) && (str.Length > 0) && str.Length > lenght)
            {
                string[] arrstr;
                arrstr = str.Split(' ');
                int num_Word = arrstr.Length;
                int i;
                try
                {
                    for (i = 0; i < num_Word; i++)
                    {
                        if (arrstr[i].Length > lenght)
                        {
                            test = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                }
            }
            return test;
        }
        public bool TestFile(string st)
        {
            string arrString = "ABCDEFGHIJKLMNOPQRSTUVXYZWabcdefghijklmnopqrstuvxyzw0123456789_";
            if (arrString.Contains(st))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int CodeIsStandard(string code_id)
        {
            string char_pass = "0123456789abcdefghikjlmnopqrstuvwxyzABCDEFGHIKJLMNOPQRSTUVWXYZ_";
            if (code_id.IndexOf(" ") != -1)
            {
                return 1;
            }
            else
            { 
                int i=0,length=code_id.Length;
                for (i = 0; i < length; i++)
                {
                    if (char_pass.IndexOf(code_id[i]) == -1)
                    {
                        return 2;
                    }
                }
            }
            return 0;
        }
        public int TestUserName(string user)
        {
            string char_pass = "abcdefghikjlmnopqrstuvwxyzABCDEFGHIKJLMNOPQRSTUVWXYZ";
            if (user.IndexOf(" ") != -1)
            {
                return 1;
            }
            else
            {
                int i = 0, length = user.Length;
                for (i = 0; i < length; i++)
                {
                    if (char_pass.IndexOf(user[i]) == -1)
                    {
                        return 2;
                    }
                }
            }
            return 0;
        }
        public Boolean TestAddressEmail(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
               return (false);
        }
    }
}