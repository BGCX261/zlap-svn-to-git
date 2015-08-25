using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using facade.list;
namespace framework.list.dynamicviewhelper
{
    public class CDynamicViewPriceSearch : CDynamicViewHelper
    {
        string where = "";
        PriceSearchComSystem PriceManage = new PriceSearchComSystem();
        public void SetWhere(string where)
        {
            this.where = where;
        }
        public void SetNumRecord()
        {
            this.SetNumberRecord(PriceManage.PriceComSearchCount(where));
        }
        public DataSet PriceComFromTo()
        {
            return PriceManage.PriceComSearchFromTo(where, this.GetFromRow(), this.GetToRow());
        }
    }
}
