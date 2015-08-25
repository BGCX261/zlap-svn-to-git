using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data;
namespace common.list
{
    public partial class Component_data : DataSet
    {
        public const string _table = "component";
        public const string _id = "Id";
        public const string _name = "Name";
        public const string _brand = "Brand";
        public const string _urlImage = "UrlImage";
        public const string _sellingPrice = "SellingPrice";
        public const string _warrantyMonth = "WarrantyMonth";
        public const string _note = "Note";
        public Component_data()
        {
            BuildTable();
        }
        public void BuildTable()
        {
            DataTable table = new DataTable(_table);
            DataColumnCollection cols = table.Columns;

            cols.Add(_id, typeof(int));
            cols.Add(_name, typeof(string));
            cols.Add(_brand, typeof(string));
            cols.Add(_urlImage, typeof(string));
            cols.Add(_sellingPrice, typeof(string));
            cols.Add(_warrantyMonth, typeof(string));
            cols.Add(_note, typeof(string));
            UniqueConstraint uc = new UniqueConstraint(cols[_id], true);
            table.Constraints.Add(uc);
            this.Tables.Add(table);
        }
    }
}
