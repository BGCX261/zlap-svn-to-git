using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data;
namespace common.list
{
    public partial class Order_data : DataSet
    {
        public const string _table = "order";
        public const string _id = "Id";
        public const string _OrderNumber = "OrderNumber";
        public const string _ParentId = "ParentId";
        public const string _OrderDate = "OrderDate";
        public const string _EmployeeId = "EmployeeId";
        public const string _CustomerId = "CustomerId";
        public const string _POSId = "POSId";
        public const string _OrderStateId = "OrderStateId";
        public const string _OrderTypeId = "OrderTypeId";
        public const string _ShipDate = "ShipDate";
        public const string _ShipperId = "ShipperId";
        public const string _ShipperName = "ShipperName";
        public const string _ShippingFee = "ShippingFee";
        public const string _CurrencyId = "CurrencyId";
        public const string _CurrencyRate = "CurrencyRate";
        public const string _ShippingName = "ShippingName";
        public const string _ShippingAddress = "ShippingAddress";
        public const string _ShippingCity = "ShippingCity";
        public const string _ShippingZipCode = "ShippingZipCode";
        public const string _ShippingCounttry = "ShippingCounttry";
        public const string _Phone = "Phone";
        public const string _email = "Email";
        public Order_data()
        {
            BuildTable();
        }
        public void BuildTable()
        {
            DataTable table = new DataTable(_table);
            DataColumnCollection cols = table.Columns;

            cols.Add(_id, typeof(int));
            cols.Add(_OrderNumber, typeof(string));
            cols.Add(_ParentId, typeof(int));
            cols.Add(_OrderDate, typeof(DateTime));
            cols.Add(_EmployeeId, typeof(int));
            cols.Add(_CustomerId, typeof(int));
            cols.Add(_POSId, typeof(int));
            cols.Add(_OrderStateId, typeof(int));
            cols.Add(_OrderTypeId, typeof(int));
            cols.Add(_ShipDate, typeof(DateTime));
            cols.Add(_ShipperId, typeof(int));
            cols.Add(_ShipperName, typeof(string));
            cols.Add(_ShippingFee, typeof(float));
            cols.Add(_CurrencyId, typeof(int));
            cols.Add(_CurrencyRate, typeof(int));
            cols.Add(_ShippingName, typeof(string));
            cols.Add(_ShippingAddress, typeof(string));
            cols.Add(_ShippingCity, typeof(string));
            cols.Add(_ShippingZipCode, typeof(string));
            cols.Add(_ShippingCounttry, typeof(string));
            cols.Add(_Phone, typeof(string));
            cols.Add(_email, typeof(string));
            UniqueConstraint uc = new UniqueConstraint(cols[_id], true);
            table.Constraints.Add(uc);
            this.Tables.Add(table);
        }
    }
}
