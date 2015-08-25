using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using common.list;
using dataaccess.list;
namespace facade.list
{
    public class ProductMainPageSystem
    {
        public DataSet MainPageSelectAll()
        {
            return new ProductMainPage().MainPageSelectAll();
        }
        public DataSet MainPageSelectAll2()
        {
            return new ProductMainPage().MainPageSelectAll2();
        }
        public ProductMainPage_data ProductMainPageAll()
        {
            return new ProductMainPage().ProductMainPageAll();
        }
        public DataSet ProductChoiceMainpageFromTo(string where, int from, int to)
        {
            return new ProductMainPage().ProductChoiceMainpageFromTo(where, from, to);
        }
        public int ProductCountChoiceMainpage(string where)
        {
            return new ProductMainPage().ProductCountChoiceMainpage(where);
        }
        public Boolean ProductMainpageUpdate(int idpro, int type,int sort)
        {
            return new ProductMainPage().ProductMainpageUpdate(idpro, type,sort);
        }
        //original:
        public DataSet ProductChoiceOriginalFromTo(string where, int from, int to)
        {
            return new ProductMainPage().ProductChoiceOriginalFromTo(where, from, to);
        }
        public int ProductCountChoiceOriginal(string where)
        {
            return new ProductMainPage().ProductCountChoiceOriginal(where);
        }

        public Boolean ProductOriginalUpdate(int idpro, int type, int sort)
        {
            return new ProductMainPage().ProductOriginalUpdate(idpro, type, sort);
        }
        public DataSet OriginalSelectTop()
        {
            return new ProductMainPage().OriginalSelectTop();
        }
        public DataSet OriginalSelectTop4()
        {
            return new ProductMainPage().OriginalSelectTop4();
        }
        public DataSet PocketPcmainpage()
        {
            return new ProductMainPage().PocketPcMainPage();
        }
    }
}
