using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using common.list;
using dataaccess.list;
namespace facade.list
{
    public class ProductSystem
    {
        public DataSet ListNamePro(int idtype, int brandid)
        {
            return new Product().ListNamePro(idtype, brandid);
        }
        public int ProductCountIdType(int idtype)
        {
            return new Product().ProductCountIdType(idtype);
        }
        public Product_data ProductIdTypeFromTo(int idtype, int from, int to)
        {
            return new Product().ProductSelectIdTypeFromTo(idtype, from, to);
        }
        public Product_data ProductWithIdBrandFromTo(int idtype, int idbrand, int from, int to)
        {
            return new Product().ProductWithBrandFromTo(idtype, idbrand, from, to);
        }
        public int ProductWithBrandCount(int idtype, int idbrand, ref string NameBrand)
        {
            return new Product().ProductWithBrandCount(idtype, idbrand,ref NameBrand);
        }
        public int ProductQuickSearchCount(string where)
        {
            return new Product().ProductQuickSearchCount(where);
        }
        public Product_data ProductQuickSearchFromTo(string where, int from, int to)
        {
            return new Product().ProductQuickSearchFromTo(where, from, to);
        }
        public int ProductWillHave(int idtype)
        {
            return new Product().ProductWillHaveCount(idtype);
        }
        public Product_data ProductWillHaveFromTo(int idtype, int from, int to)
        {
            return new Product().ProductWillHaveFromTo(idtype, from, to);
        }
        public DataSet GetDetailProductType(int id, int type)
        {
            return new Product().ProductDetailType(id, type);
        }
        public DataSet GetDetailProductTypeNew(int id, int type)
        {
            return new Product().ProductDetailTypeNew(id, type);
        }
        public DataSet ProductDetailTypeAll(int id, int type)
        {
            return new Product().ProductDetailTypeAll(id, type);
        }
        public DataSet ProductDetailTypeOther(int id, string idtype)
        {
            return new Product().ProductDetailTypeOther(id, idtype);
        }
        public string ProductDes(string id)
        {
            return new Product().ProductDes(id);
        }
        public DataSet ProductNameId(string id)
        {
            return new Product().ProductNameId(id);
        }
        public string ProductShortNote(string id)
        {
            return new Product().ProductShortNote(id);
        }
        public string ProductDesandStock(string id)
        {
            return new Product().ProductDesAndStock(id);
        }
        public DataSet ProductToCart(string id, string idtype)
        {
            return new Product().ProducttoCart(id, idtype);
        }
        public DataSet ProductExportPrice(string Currency, int idbrand, int idtype)
        {
            return new Product().ProductToExportPrice(Currency, idbrand, idtype);
        }
        public DataSet ProductForUploadFromTo(string where, int from, int to)
        {
            return new Product().ProductForUploadFromTo(where, from, to);
        }
        public Boolean ProductUpdateImage(int id, string nameImage)
        {
            return new Product().ProductUpdateImage(id, nameImage);
        }
        public DataSet ProductSelectForCompare(int id1, int id2, int type)
        {
            return new Product().ProductSelectForCompare(id1, id2, type);
        }
        public DataSet ProductSelectNameWithBrand(int idbrand1, int idbrand2, int type)
        {
            return new Product().ProductSelectNameWithBrand(idbrand1, idbrand2, type);
        }
        public int ProductAdvansearchCount(string where)
        {
            return new Product().ProductSearchCount(where);
        }
        public Product_data ProductAdvanceSearch(string where, int from, int to)
        {
            return new Product().ProductSearchFromTo(where, from, to);
        }
        public DataSet ProductSelectAllIdType(string where)
        {
            return new Product().ProductSelectAllIdType(where);
        }
        public string PromotionSelectId(string id)
        {
            return new Product().PromotionSelectId(id);
        }
        public int ProductOtherCount(string where)
        {
            return new Product().ProductOtherSelectCount(where);
        }
        public DataSet ProductOtherFromTo(string where, int from, int to)
        {
            return new Product().ProductOtherSelectFromTo(where, from, to);
        }
        public DataSet ProductDesId(string id)
        {
            return new Product().ProductDesId(id);
        }
        public Boolean ProductDesUpdate(int id, string des)
        {
            return new Product().ProductDesUpdate(id, des);
        }
        public Boolean ProductDesUpdate(int id, string des, string shortdes)
        {
            return new Product().ProductDesUpdate(id, des, shortdes);
        }
        public Boolean ProductDesUpdateGroup(string Name, string des)
        {
            return new Product().ProductDesUpdateGroup(Name, des);
        }
        public float GetCurrencyProductType(string idtype)
        {
            return new Product().GetCurrencyProductType(idtype);
        }
        public Boolean UpdateUSD(string usd)
        {
            return new Product().UpdateUSD(usd);
        }
        //for Multi Image:
        public int ProductMultiImgCount(string where)
        { 
            return new Product().ProductMultiImageCount(where);
        }
        public DataSet ProductMultiImgFromTo(string where, int from, int to)
        {
            return new Product().ProductMultiImgFromTo(where, from, to);
        }
        public Boolean ProductUpdateMultiImage(int id, string index, string img)
        {
            return new Product().ProductUpdateMultiImage(id, index, img);
        }
        public DataSet Promotionall()
        {
            return new Product().Promotionall();
        }
        public Boolean PromationUpdateImage(string Image, string Id)
        {
            return new Product().PromationUpdateImage(Image, Id);
        }
    }
}
