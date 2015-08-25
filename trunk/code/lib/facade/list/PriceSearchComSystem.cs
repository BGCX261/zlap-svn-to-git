using System;
using System.Collections.Generic;
using System.Text;
using dataaccess.list;
using System.Data;
namespace facade.list
{
    public class PriceSearchComSystem
    {
        public DataSet PriceComSearchAllGroup(string where)
        {
            return new PriceSearchComponent().PriceComSearchAllGroup(where);
        }
        public int PriceComSearchCount(string where)
        {
            return new PriceSearchComponent().PriceComSearchCount(where);
        }
        public DataSet PriceComSearchFromTo(string where, int from, int to)
        {
            return new PriceSearchComponent().PriceComSearchFromTo(where, from, to);
        }
        public Boolean PriceComSearchInsert(int typecomid, string name, float pricefrom, float priceto, int sort)
        {
            return new PriceSearchComponent().PriceComSearchInsert(typecomid, name, pricefrom, priceto, sort);
        }
        public Boolean PriceComSearchDelete(string id)
        {
            return new PriceSearchComponent().PriceComSearchDelete(id);
        }
    }
}
