using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data;
namespace common.list
{
    public partial class ProductMainPage_data : DataSet
    {
        public const string _table = "productmain";
        public const string _id = "idproduct";
        public const string _name = "Name";
        public const string _state = "state";
        public const string _urlImage = "UrlImage";
        public const string _price = "SellingPrice";
        public const string _WarrantyMonth = "WarrantyMonth";
        public const string _ispromotion = "promotion";
        public const string _shortnote = "ShortNote";
        public const string _isspec = "Isspec";
        public ProductMainPage_data()
        {
            BuildTable();
        }
        public void BuildTable()
        {
            DataTable table = new DataTable(_table);
            DataColumnCollection cols = table.Columns;

            cols.Add(_id, typeof(int));
            cols.Add(_name, typeof(string));
            cols.Add(_state, typeof(string));
            cols.Add(_urlImage, typeof(string));
            cols.Add(_price, typeof(float));
            cols.Add(_WarrantyMonth, typeof(int));
            cols.Add(_ispromotion, typeof(int));
            cols.Add(_shortnote, typeof(string));
            cols.Add(_isspec, typeof(string));
            UniqueConstraint uc = new UniqueConstraint(cols[_id], true);
            table.Constraints.Add(uc);
            this.Tables.Add(table);
        }
    }
}
