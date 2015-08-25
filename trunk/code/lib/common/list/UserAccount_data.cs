using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data;
namespace common.list
{
    public partial class UserAccount_data : DataSet
    {

        public const string _table = "useraccount";
        public const string _Id = "Id";
        public const string _UserName = "Username";
        public const string _Password = "Password";
        public const string _ContactName= "ContactName";
        public const string _Company = "Company";
        public const string _JobTitle = "JobTitle";
        public const string _BillingAddress = "BillingAddress";
        public const string _BillingCity = "BillingCity";
        public const string _BillingZipCode = "BillingZipCode";
        public const string _BillingCountry = "BillingCountry";
        public const string _ShippingAddress = "ShippingAddress";
        public const string _ShippingCity = "ShippingCity";
        public const string _ShippingZipCode = "ShippingZipCode";
        public const string _ShippingCountry = "ShippingCountry";
        public const string _MobilePhone = "MobilePhone";
        public const string _OfficePhone = "OfficePhone";
        public const string _HomePhone = "HomePhone";
        public const string _FaxNumber = "FaxNumber";
        public const string _TaxCode = "TaxCode";
        public const string _Email1 = "Email1";
        public const string _Email2 = "Email2";
        public const string _Website = "Website";
        public UserAccount_data()
        {
            BuildTable();
        }
        public void BuildTable()
        {
            DataTable table = new DataTable(_table);
            DataColumnCollection cols = table.Columns;

            cols.Add(_Id, typeof(int));
            cols.Add(_UserName, typeof(string));
            cols.Add(_Password, typeof(string));
            cols.Add(_ContactName, typeof(string));
            cols.Add(_Company, typeof(string));
            cols.Add(_JobTitle, typeof(string));
            cols.Add(_BillingAddress, typeof(string));
            cols.Add(_BillingCity, typeof(string));
            cols.Add(_BillingZipCode, typeof(string));
            cols.Add(_BillingCountry, typeof(string));
            cols.Add(_ShippingCity, typeof(string));
            cols.Add(_ShippingZipCode, typeof(string));
            cols.Add(_ShippingCountry, typeof(string));
            cols.Add(_MobilePhone, typeof(string));
            cols.Add(_OfficePhone, typeof(string));
            cols.Add(_HomePhone, typeof(string));
            cols.Add(_FaxNumber, typeof(string));
            cols.Add(_TaxCode, typeof(string));
            cols.Add(_Email1, typeof(string));
            cols.Add(_Email2, typeof(string));
            cols.Add(_Website, typeof(string));
            UniqueConstraint uc = new UniqueConstraint(cols[_Id], true);
            table.Constraints.Add(uc);
            this.Tables.Add(table);
        }
    }
}
