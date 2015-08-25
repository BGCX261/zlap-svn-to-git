using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using facade.list;
using System.Data;
namespace framework.list.dynamicviewhelper
{
    public class CDynamicViewProBestSell:CDynamicViewHelper
    {
        int idtype = 0;
        string txtsearch = "";
        string where = "";
        string isbest = "";
        ProductBestSellSystem products = new ProductBestSellSystem();
        public void SetIdtype(int type)
        {
            this.idtype = type;
        }
        public void SetTxtSearch(string txt)
        {
            this.txtsearch = txt;
        }
        public void SetIsBest(string isbest)
        {
            this.isbest = isbest;
        }
        public void Buildwhere()
        {
            where = " where producttypeid=" + idtype + " and CanSales=1 ";
            if (isbest.Equals("1"))
            {
                where += " and idproduct is not null ";
            }
            else if(isbest.Equals("0"))
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
        public void SetNumSelectBestSell()
        { 
            this.SetNumberRecord(products.ProductCountChoiceBestSell(where));
        }
        public DataSet ProductSelectFromTo()
        {
            return products.ProductChoiceBestsellFromTo(where, GetFromRow(), GetToRow());
        }
        public void SetNumSelectJustHave()
        {
            this.SetNumberRecord(products.ProductCountChoiceJustHave(where));
        }
        public DataSet ProductChoiceJustHaveFromTo()
        {
            return products.ProductChoiceJusthaveFromTo(where, this.GetFromRow(), this.GetToRow());
        }
        public void SetNumSelectPrepareout()
        {
            this.SetNumberRecord(products.ProductCountChoicePrepareout(where));
        }
        public DataSet ProductChoicePrepareoutFromTo()
        {
            return products.ProductChoicePrepareoutFromTo(where, this.GetFromRow(), this.GetToRow());
        }
        public void SetNumHavePromotion()
        {
            this.SetNumberRecord(products.ProductChoiceSpecialPromotionCount(where));
        }
        public DataSet ProHavePromotionFromTo()
        {
            return products.ProductChoiceSpecialPromtion(where, this.GetFromRow(), this.GetToRow());
        }
        public void SetNumProSellOff()
        {
            this.SetNumberRecord(products.ProductCountChoiceSelloff(where));
        }
        public DataSet ProductChoiceSellOffFromTo()
        {
            return products.ProductSelloffChoiceFromTo(where, this.GetFromRow(), this.GetToRow());
        }
        public void SetWhere(string where)
        {
            this.where = where;
        }
    }
}
