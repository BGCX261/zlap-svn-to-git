using System;
using System.Collections;
using System.Text;
using dataaccess.list;
using System.Data;

namespace facade.list
{
    [Serializable]
    public class CManageProductSystem
    {
        public DataSet ProductDetailForOrder(string id)
        {
            return new CManageProduct().ProductDetailForOrder(id);
        }
        public DataSet ProductSeriForOrder(string Seri)
        {
            return new CManageProduct().ProductSeriForOrder(Seri);
        }
        public DataSet ProductSeriForOrder(string Seri, string WareHouseId)
        {
            return new CManageProduct().ProductSeriForOrder(Seri, WareHouseId);
        }
        public DataSet ProductSeriForExport(string Seri, string WareHouseId)
        {
            return new CManageProduct().ProductSeriForExport(Seri, WareHouseId);
        }
        public DataSet ProductSeriForImport(string Seri, string WareHouseId, string Discontinued)
        {
            return new CManageProduct().ProductSeriForImport(Seri, WareHouseId, Discontinued);
        }
        public DataSet ProductSeriId(string ListSeri)//Get ProductSeriId with List Seri
        {
            return new CManageProduct().ProductSeriId(ListSeri);
        }
        public DataSet ProductSeriDiscontinued(string condition, string ListSeri)
        {
            return new CManageProduct().ProductSeriDiscontinued(condition, ListSeri);
        }
        public DataSet ProductNoSeriForExport(string ProductId, string WareHouseId)
        {
            return new CManageProduct().ProductNoSeriForExport(ProductId, WareHouseId);
        }
        public DataSet ProductNoSeriQuantity(string WareHouseId, string ListProId)
        {
            return new CManageProduct().ProductNoSeriQuantity(WareHouseId, ListProId);
        }
        public DataSet ProductNoSeriId(string WareHouseId, string ListProId)
        {
            return new CManageProduct().ProductNoSeriId(WareHouseId, ListProId);
        }
        public DataSet ProductChoiceSeeDetail(string id)
        {
            return new CManageProduct().ProductChoiceSeeDetail(id);
        }
        public DataSet ProductChoiceSeeDetailAndSeri(string id, string WareHouseId)
        {
            return new CManageProduct().ProductChoiceSeeDetailAndSeri(id, WareHouseId);
        }
        public DataSet ProductSearchFromTo(string where, int from, int to)
        {
            return new CManageProduct().ProductSearchFromTo(where, from, to);
        }
        public int ProductSearchCount(string where)
        {
            return new CManageProduct().ProductSearchCount(where);
        }
        public DataSet ProductTypeAll(string where)
        {
            return new CManageProduct().ProductTypeAll(where);
        }
        public DataSet BrandNameofProductType(string ProductTypeId)
        {
            return new CManageProduct().BrandNameofProductType(ProductTypeId);
        }
        public DataSet ProductStateAll()
        {
            return new CManageProduct().ProductStateAll();
        }
        public DataSet WareHouseAll()
        {
            return new CManageProduct().WareHouseAll();
        }
        //Statistic:
        public DataSet ProductSeriStatistic(string id)
        {
            return new CManageProduct().ProductSeriStatistic(id);
        }
        //Export Update:
        public Boolean ProductSeriExportUpdate(int Discontinued, string SeriNumber)
        {
            return new CManageProduct().ProductSeriExportUpdate(Discontinued, SeriNumber);
        }
        public Boolean ProductNoSeriQuantityUpdate(int Id, int Quantity)
        {
            return new CManageProduct().ProductNoSeriQuantityUpdate(Id, Quantity);
        }
        //Import Update:
        public Boolean ProductSeriImportUpdate(int WareHouseId, int Discontinued, string SeriNumber)
        {
            return new CManageProduct().ProductSeriImportUpdate(WareHouseId, Discontinued, SeriNumber);
        }
        public Boolean ProductNoSeriImportUpdate(int WareHouseId, int Id, int Quantity)
        {
            return new CManageProduct().ProductNoSeriImportUpdate(WareHouseId, Id, Quantity);
        }
        //Report:
        public DataSet ReportProduct(int ProductTypeId, int Cansales)
        {
            return new CManageProduct().ReportProduct(ProductTypeId, Cansales);
        }

        //Seri view:
        public DataSet SeriSearchFromTo(string where, int from, int to)
        {
            return new CManageProduct().SeriSearchFromTo(where, from, to);
        }
        public int SeriSearchCount(string where)
        {
            return new CManageProduct().SeriSearchCount(where);
        }
        public DataSet ProductSeriDetail(string ProductId, string SeriId)
        {
            return new CManageProduct().ProductSeriDetail(ProductId, SeriId);
        }
        public DataSet SeriProDetail(string SeriId)
        {
            return new CManageProduct().SeriProDetail(SeriId);
        }

        //THống kê:
        public DataSet TKSeriFromTo(string where, int from, int to)
        {
            return new CManageProduct().TKSeriFromTo(where, from, to);
        }
        public int TKSeriCount(string where)
        {
            return new CManageProduct().TKSeriCount(where);
        }

    }
}