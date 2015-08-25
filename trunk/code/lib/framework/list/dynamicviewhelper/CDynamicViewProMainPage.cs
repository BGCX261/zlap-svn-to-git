using System;
using System.Collections.Generic;
using System.Text;
using facade.list;
using System.Data;
using System.Collections;
namespace framework.list.dynamicviewhelper
{
    public class CDynamicViewProMainPage:CDynamicViewHelper
    {
        int idtype = 0;
        string txtsearch = "";
        string where = "";
        string ismain = "";
        ProductMainPageSystem products = new ProductMainPageSystem();
        public void SetIdtype(int type)
        {
            this.idtype = type;
        }
        public void SetTxtSearch(string txt)
        {
            this.txtsearch = txt;
        }
        public void SetIsMainpage(string ismain)
        {
            this.ismain = ismain;
        }
        public void Buildwhere()
        {
            where = " where producttypeid=" + idtype + " and CanSales=1 ";
            if (ismain.Equals("1"))
            {
                where += " and idproduct is not null ";
            }
            else if (ismain.Equals("0"))
            {
                where += " and idproduct is null ";
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
        public void SetNumSelectMainPage()
        {
            this.SetNumberRecord(products.ProductCountChoiceMainpage(where));
        }
        public DataSet ProductSelectFromTo()
        {
            return products.ProductChoiceMainpageFromTo(where, GetFromRow(), GetToRow());
        }

        //original:
        public void SetNumSelectOriginal()
        {
            this.SetNumberRecord(products.ProductCountChoiceOriginal(where));
        }
        public DataSet ProductSelectFromToOriginal()
        {
            return products.ProductChoiceOriginalFromTo(where, GetFromRow(), GetToRow());
        }
    }
}
