using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using common.list;
using dataaccess.list;
namespace facade.list
{
    public class ProductBestSellSystem
    {
        public ProductMainPage_data ProductBestSellAll()
        {
            return new ProductBestSell().ProductBestSellAll();
        }
        public DataSet ProductChoiceBestsellFromTo(string where, int from, int to)
        {
            return new ProductBestSell().ProductSelectChoiceBestSellFromTo(where, from, to);
        }
        public int ProductCountChoiceBestSell(string where)
        {
            return new ProductBestSell().ProductCountSelectChoiceBestSell(where);
        }
        public Boolean ProductBestUpdate(int id, int type)
        {
            return new ProductBestSell().ProductBestUpdate(id, type);
        }
        public ProductMainPage_data ProductJustHaveTop()
        {
            return new ProductBestSell().ProductJustHavelTop();
        }
        public ProductMainPage_data ProductJustHaveAll()
        {
            return new ProductBestSell().ProductJustHavelAll();
        }
        public DataSet ProductChoiceJusthaveFromTo(string where, int from, int to)
        {
            return new ProductBestSell().ProductSelectChoiceJustHaveFromTo(where, from, to);
        }
        public int ProductCountChoiceJustHave(string where)
        {
            return new ProductBestSell().ProductCountSelectChoicejusthave(where);
        }
        public Boolean ProductJustHaveUpdate(int id, int type)
        {
            return new ProductBestSell().ProductJustHaveUpdate(id, type);
        }

        //Product prepare out:
        public ProductMainPage_data ProductPrepareoutAll()
        {
            return new ProductBestSell().ProductPrepareoutlAll();
        }
        public DataSet ProductChoicePrepareoutFromTo(string where, int from, int to)
        {
            return new ProductBestSell().ProductSelectChoicePrepareoutFromTo(where, from, to);
        }
        public int ProductCountChoicePrepareout(string where)
        {
            return new ProductBestSell().ProductCountSelectChoiceprepareout(where);
        }
        public Boolean ProductPrepareoutUpdate(int id, int type)
        {
            return new ProductBestSell().ProductPrepareoutUpdate(id, type);
        }
        //For product special promotion:
        public DataSet ProductSpecialPromotion()
        {
            return new ProductBestSell().ProductSpecialPromotion();
        }
        public DataSet ProductChoiceSpecialPromtion(string where, int from, int to)
        {
            return new ProductBestSell().ProChoicePromotionFromTo(where, from, to);
        }
        public int ProductChoiceSpecialPromotionCount(string where)
        {
            return new ProductBestSell().ProCountpromotion(where);
        }
        public Boolean ProductSpecialPromotionUpdate(int id, int type)
        {
            return new ProductBestSell().ProductSpecialPromotionUpdate(id, type);
        }
        //For Product SellOFf:
        public DataSet ProductSelloffAll()
        {
            return new ProductBestSell().ProductSellOffAll();
        }
        public DataSet ProductSelloffChoiceFromTo(string where, int from, int to)
        {
            return new ProductBestSell().ProductSellOffFromTo(where, from, to);
        }
        public int ProductCountChoiceSelloff(string where)
        {
            return new ProductBestSell().ProductCountChoiceSellOff(where);
        }
        public Boolean ProductSelloffUpdate(int id, int type, float price)
        {
            return new ProductBestSell().ProductSellOffUpdate(id, type, price);
        }
        public DataSet ProductBestView()
        {
            return new ProductBestSell().ProductBestView();
        }
    }
}
