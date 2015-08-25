using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using common.list;
using dataaccess.list;
namespace facade.list
{
    public class Mobilesystem
    {
        public DataSet MobileChoiceFromTo(string where, int from, int to)
        {
            return new Mobile().MobileChoiceFromTo(where, from, to);
        }
        public int MobilecountChoice(string where)
        {
            return new Mobile().MobilecountChoice(where);
        }
        public Boolean MobileUpdate(int idpro, int isinsert, int type, int sort)
        {
            return new Mobile().MobileUpdate(idpro, isinsert, type, sort);
        }
        public ProductMainPage_data MobileforShow(string select)
        {
            return new Mobile().MobileforShow(select);
        }
        public DataSet MobileMainpage()
        {
            return new Mobile().MobileMainpage();
        }
    }
}
