using System;
using System.Collections.Generic;
using System.Text;
using facade.list;
using System.Data;
using System.Collections;
namespace framework.list.dynamicviewhelper
{
    public class CDynamicViewMobile : CDynamicViewHelper
    {
        string where = "";
        string type = "";
        string txtsearch = "";
        string idprotype = "";
        string isChoice = "";
        Mobilesystem Mobile = new Mobilesystem();
        public void SetType(string type)
        {
            this.type = type;
        }
        public void SetIdtype(string idtype)
        {
            this.idprotype = idtype;
        }
        public void SetTxtSearch(string txt)
        {
            this.txtsearch = txt;
        }
        public void SetIsChoice(string isChoice)
        {
            this.isChoice = isChoice;
        }
        public void SetWhere(string where)
        {
            this.where = where;
        }
        public void setNumberMobile()
        {
            this.SetNumberRecord(Mobile.MobilecountChoice(where));
        }
        public DataSet MobileChoiceFromTo()
        {
            return Mobile.MobileChoiceFromTo(where, this.GetFromRow(), this.GetToRow());
        }
        public void Buildwhere()
        {
            where = " where producttypeid=" + idprotype + " and CanSales=1 ";
            if (isChoice.Equals("1"))
            {
                where += " and type=" + type + " ";
            }
            else
            {
                where += " and (type <> " + type + " or type is null) ";
            }
            if (txtsearch.Length > 0)
            {
                string str1 = "";
                string str2 = "";
                string str3 = "";
                string str = "";
                string strSub = txtsearch.ToLower();
                string[] arrStr = strSub.Split(' ');
                int numText = arrStr.Length;
                int num = 0;
                Hashtable hash = new Hashtable();
                int index = 0;
                while (index < 5 && num < numText)
                {
                    try
                    {
                        if (arrStr[num].Length > 0)
                        {
                            hash.Add(arrStr[num], num);
                            str3 += "id like '%" + arrStr[num] + "%' and ";
                            str1 += "name like '%" + arrStr[num] + "%' and ";
                            str2 += "brand like '%" + arrStr[num] + "%' and ";
                            index++;
                        }
                    }
                    catch
                    {

                    }
                    num++;
                }
                if (str1.Length > 0)
                {
                    str1 = str1.Substring(0, str1.Length - 5);
                    str2 = str2.Substring(0, str2.Length - 5);
                    str3 = str3.Substring(0, str3.Length - 5);
                }
                str = "(" + str3 + " or " + str1 + " or " + str2 + ")";
                where += " and " + str;
            }
        }
    }
}