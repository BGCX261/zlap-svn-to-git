using System;
using System.Collections.Generic;
using System.Text;
using dataaccess.list;
using System.Data;
namespace facade.list
{
    public class ProductTypeSystem
    {
        public DataSet GetGroupProduct()
        {
            return new ProductType().GetGroupProduct();
        }
    }
}
