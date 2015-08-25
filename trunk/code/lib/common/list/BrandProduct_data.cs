using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data;
namespace common.list
{
    public partial class BrandProduct_data : DataSet
    {
        public const string _table = "BrandPro";
        public const string _id = "id";
        public const string _name = "name";
        public const string _logourl = "logourl";
        public BrandProduct_data()
        {
            BuildTable();
        }
        public void BuildTable()
        {
            DataTable table = new DataTable(_table);
            DataColumnCollection cols = table.Columns;

            cols.Add(_id, typeof(int));
            cols.Add(_name, typeof(string));
            cols.Add(_logourl, typeof(string));
            UniqueConstraint uc = new UniqueConstraint(cols[_id], true);
            table.Constraints.Add(uc);
            this.Tables.Add(table);
        }
    }
}
