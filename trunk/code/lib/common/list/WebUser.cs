using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace common.list.WebUser
{
    /// <summary>
    ///  Create by: tuannc
    ///  Created Date: 6/7/2008 12:00:00 AM
    /// </summary>
    /// <remarks></remarks>
    public class WebUserCM : DataSet
    {
        public const string TABLE_NAME = "WebUser";
        public const string FLD_ID = "Id";
        public const string FLD_USERNAME = "UserName";
        public const string FLD_PASSWORD = "Password";

        public WebUserCM()
        {
            BuildTables();
        }

        private void BuildTables()
        {
            DataTable table = new DataTable(TABLE_NAME);
            DataColumnCollection columns = table.Columns;
            columns.Add(FLD_ID, Type.GetType("System.Int32"));
            columns.Add(FLD_USERNAME, Type.GetType("System.String"));
            columns.Add(FLD_PASSWORD, Type.GetType("System.String"));
            UniqueConstraint uc = new UniqueConstraint(columns[FLD_ID], true);
            table.Constraints.Add(uc);
            this.Tables.Add(table);
        }
    }

    /// <summary>
    ///  Create by: tuannc
    ///  Created Date: 6/7/2008 12:00:00 AM
    /// </summary>
    /// <remarks></remarks>
    public class WebUser
    {

        private Int32 _Id;
        public Int32 Id
        {
            get { return this._Id; }
            set { this._Id = value; }
        }

        private String _UserName;
        public String UserName
        {
            get { return this._UserName; }
            set { this._UserName = value; }
        }

        private String _Password;
        public String Password
        {
            get { return this._Password; }
            set { this._Password = value; }
        }


        public WebUser() { }

        public WebUser(DataRow dr)
        {
            this._Id = System.Convert.ToInt32(dr[WebUserCM.FLD_ID]);
            this._UserName = System.Convert.ToString(dr[WebUserCM.FLD_USERNAME]);
            this._Password = System.Convert.ToString(dr[WebUserCM.FLD_PASSWORD]);
        }

        public DataRow ToRow(DataTable tbl)
        {
            DataRow dr = tbl.NewRow();
            dr[WebUserCM.FLD_ID] = this._Id;
            dr[WebUserCM.FLD_USERNAME] = this._UserName;
            dr[WebUserCM.FLD_PASSWORD] = this._Password;
            return dr;
        }
    }
}