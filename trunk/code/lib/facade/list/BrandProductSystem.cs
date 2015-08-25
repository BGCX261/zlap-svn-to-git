using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using common.list;
using dataaccess.list;
namespace facade.list
{
    public class BrandProductSystem
    {
        public BrandProduct_data BrandProAllType(int type)
        {
            return new BrandProduct().SelectAllBrandWithTypePro(type);
        }
        public Boolean UploadUrlBrand(int id, string Url)
        {
            return new BrandProduct().UpdateImageBrand(id, Url);
        }
        public DataSet BrandDetail(string id)
        {
            return new BrandProduct().BrandDetail(id);
        }
        public DataSet BrandNameWhere(string Where)
        {
            return new BrandProduct().BrandNameWhere(Where);
        }
    }
}