using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using framework.list.dynamicviewhelper;
using common.list;
using facade.list;

namespace framework.list.dynamicviewhelper
{
    public class CDynamicViewProduct:CDynamicViewHelper
    {
        int idType=0;
        int idBrand = 0;
        string nameBrand = "";
        string tsearch = "";
        string twhere="";
        string hasImg = "";
        string tadvance="";
        public void SetAdvance(string sql)
        {
            tadvance=sql;
        }
        ProductSystem productSystem = new ProductSystem();
        public void SetHasImage(string str)
        {
            hasImg = str;
        }
        public void SetIdType(int idtype)
        {
            this.idType=idtype;
        }
        public void SetNumProduct()
        { 
            this.SetNumberRecord(productSystem.ProductCountIdType(idType));
        }
        public Product_data ProductIdTypeFromTo()
        {
            return productSystem.ProductIdTypeFromTo(idType, this.GetFromRow(), this.GetToRow());
        }
        public void SetNumProductWithBrand()
        { 
            this.SetNumberRecord(productSystem.ProductWithBrandCount(idType,idBrand,ref this.nameBrand));
        }
        public Product_data ProductWithBrandFromTo()
        {
            return productSystem.ProductWithIdBrandFromTo(idType, idBrand,this.GetFromRow(),this.GetToRow());
        }
        public void SetIdBrand(int idBrand)
        {
            this.idBrand = idBrand;
        }
        public int GetIdBrand()
        {
            return this.idBrand;
        }
        public void SetNameBrand(string Name)
        {
            this.nameBrand = Name;
        }
        public string GetNameBrand()
        {
            return this.nameBrand;
        }
        public void SetTextSearch(string text)
        {
            this.tsearch = text;
        }
        public string GetTextSearch()
        {
            return this.tsearch;
        }
        public void BuildWhere()
        {
            twhere = "where producttypeid=" + idType.ToString() + " and CanSales=1";
            if (tsearch.Length > 0)
            {
                twhere += " and " + BuildWhereText();
            }
        }
        public void SetWhere()
        {
            twhere = "where producttypeid=" + idType.ToString() + " and CanSales=1 ";
            if (tadvance.Length > 0)
            {
                twhere += tadvance;
            }
        }
        public void SetWhere(string where)
        {
            this.twhere = where;
        }
        private string BuildWhereText()
        {
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str = "";
            string strSub = tsearch.ToLower();
            str1 += "name like N'%" + strSub + "%'";
            str2 += "brand like N'%" + strSub + "%'";
            str3 += "Note like N'%" + strSub + "%'";
            if (str1.Length > 0)
            {
                str = "(" + str1 + " or " + str2 + " or " + str3 + ")";
            }
            return str;
        }
        public void SetNumQuickSearch()
        { 
            this.SetNumberRecord(productSystem.ProductQuickSearchCount(twhere));
        }
        public Product_data ProductQuickSearchFromTo()
        {
            return productSystem.ProductQuickSearchFromTo(twhere, this.GetFromRow(), this.GetToRow());
        }
        public DataSet ProductUploadImageFromTo()
        {
            return productSystem.ProductForUploadFromTo(twhere, GetFromRow(), GetToRow());
        }
        private string BuildWhereAdmin()
        {
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str = "";
            string strSub = tsearch.ToLower();
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
                        str1 += "name like N'%" + arrStr[num] + "%' and ";
                        str2 += "brand like N'%" + arrStr[num] + "%' and ";
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
            return str;
        }
        public void BuildWhereAdminSearch()
        {
            twhere = "where producttypeid=" + idType.ToString() + " and CanSales=1";
            if (tsearch.Length > 0)
            {
                twhere += " and " + BuildWhereAdmin();
            }
            if (hasImg.Length > 0)
            {
                string subwhere = "";
                if (hasImg.Equals("1"))
                {
                    subwhere += " and (UrlImage<>'')";
                }
                else if( hasImg.Equals("0"))
                {
                    subwhere += " and (UrlImage is null or UrlImage='')";
                }
                else if (hasImg.Equals("2"))
                {
                    subwhere += " and (des is null or des='')";
                }
                else if (hasImg.Equals("3"))
                {
                    subwhere += " and (des <>'')";
                }
                twhere += subwhere;
            }
        }
        public void SetNumAdvanceSearch()
        {
            this.SetNumberRecord(productSystem.ProductAdvansearchCount(twhere));
        }
        public Product_data ProductAdvanceSearchFromTo()
        {
            return productSystem.ProductAdvanceSearch(twhere, GetFromRow(), GetToRow());
        }
        public void SetNumberOther()
        {
            this.SetNumberRecord(productSystem.ProductOtherCount(twhere));
        }
        public DataSet ProductOtherFromTo()
        {
            return productSystem.ProductOtherFromTo(twhere, GetFromRow(), GetToRow());
        }
        public void SetNumWillHave()
        {
            this.SetNumberRecord(productSystem.ProductWillHave(idType));
        }
        public Product_data ProductWillHaveFromTo()
        {
            return productSystem.ProductWillHaveFromTo(idType, this.GetFromRow(), this.GetToRow());
        }
        //For Promulti Img:
        public void SetNumMultiImg()
        {
            this.SetNumberRecord(productSystem.ProductMultiImgCount(twhere));
        }
        public DataSet ProductMultiImgFromTo()
        {
            return this.productSystem.ProductMultiImgFromTo(twhere, this.GetFromRow(), this.GetToRow());
        }
        public void BuildWhereMultiImg()
        {
            twhere = "where producttypeid=" + idType.ToString() + " and CanSales=1";
            if (tsearch.Length > 0)
            {
                twhere += " and " + BuildWhereAdmin();
            }
            if (hasImg.Length > 0)
            {
                string subwhere = "";
                if (hasImg.Equals("1"))
                {
                    subwhere += " and (idpro is not null)";
                }
                else if (hasImg.Equals("0"))
                {
                    subwhere += " and (idpro is null or len(idpro)=0)";
                }
                twhere += subwhere;
            }
        }
    }
}
