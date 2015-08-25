using System;
using System.Text;
using facade.list;
using common.list;
using System.Collections;
using System.Data;
namespace framework.list.dynamicviewhelper
{
    public class CdymanicViewCom : CDynamicViewHelper
    {
        int idtype = 0;
        int idgroup = 0;
        string NameGroup = "";
        string twhere = "";
        string tsearch = "";
        string hasImg = "";
        ComponentProductSystem managerCom = new ComponentProductSystem();
        public void SetWhere(string where)
        {
            this.twhere = where;
        }
        public void SetHasImage(string has)
        {
            this.hasImg = has;
        }
        public void SetTextSearch(string text)
        {
            this.tsearch = text;
        }
        public string GetTextSearch()
        {
            return this.tsearch;
        }
        public void SetIdType(int type)
        {
            this.idtype = type;
        }
        public void setIdGroup(int idgroup)
        {
            this.idgroup = idgroup;
        }
        public int GetIdGroup()
        {
            return this.idgroup;
        }
        public void SetNameGroup()
        {
            this.NameGroup = managerCom.ComponentGroupName(idtype, idgroup);
        }
        public string GetNameGroup()
        {
            return this.NameGroup;
        }
        public void SetNumAllCom()
        {
            this.SetNumberRecord(managerCom.ComponentAllCount(idtype));
        }
        public void SetNumComGroup()
        { 
            this.SetNumberRecord(managerCom.ComponentGroupCount(idtype,idgroup,ref NameGroup));
        }
        public Component_data ComponentAllFromTo()
        {
            return managerCom.ComponentAllFromTo(idtype, GetFromRow(), GetToRow());
        }
        public Component_data ComponentGroupFromTo()
        {
            return managerCom.ComponentGroupFromTo(idtype, idgroup, GetFromRow(), GetToRow());
        }
        public void BuildWhere()
        {
            twhere = "where producttypeid=" + idtype.ToString() + " and CanSales=1";
            if (tsearch.Length > 0)
            {
                twhere += " and " + BuildWhereText();
            }
        }
        private string BuildWhereText()
        {
            string str1 = "";
            string str2 = "";
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
                        str1 += "Name like N'%" + arrStr[num] + "%' and ";
                        str2 += "Brand like N'%" + arrStr[num] + "%' and ";
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
            }
            str = "(" + str1 + " or " + str2 + ")";
            return str;
        }
        public void SetNumComQuickSearch()
        {
            this.SetNumberRecord(managerCom.ComponentQuickSearchCount(twhere));
        }
        public Component_data ComponentQuickSearchFromTo()
        {
            return managerCom.ComponentQuickSearchFromTo(twhere, GetFromRow(), GetToRow());
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
            twhere = "where producttypeid=" + idtype.ToString() + " and CanSales=1";
            if (tsearch.Length > 0)
            {
                twhere += " and " + BuildWhereAdmin();
            }
            if (hasImg.Length > 0)
            {
                string subwhere = "";
                if (hasImg.Equals("1"))
                {
                    subwhere += " and len(UrlImage)>0";
                }
                else
                {
                    subwhere += " and (UrlImage is null or len(UrlImage)=0)";
                }
                twhere += subwhere;
            }
        }
        public void SetNumComWhere()
        { 
            this.SetNumberRecord(managerCom.ComponentAllCount(twhere));
        }
        public DataSet GetComFromToWhere()
        {
            return managerCom.ComponentSelectAllFromTo(twhere, this.GetFromRow(), this.GetToRow());
        }
        public void SetNumCompatible()
        {
            this.SetNumberRecord(managerCom.ComponentCompatibleCount(twhere));
        }
        public DataSet GetCompatibleFromToWhere()
        {
            return managerCom.ComponentCompatibleFromTo(twhere, this.GetFromRow(), this.GetToRow());
        }
        public DataSet ComponentCurrentAccess(string where)
        {
            return managerCom.ComponentCurrentAccess(where);
        }
    }
}
