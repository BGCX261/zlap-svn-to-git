using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using common.list.WebUser;
using dataAccess.list.WebUser;
namespace facade.list
{
    /// <summary>
    ///  Create by: tuannc
    ///  Created Date: 6/7/2008 12:00:00 AM
    /// </summary>
    /// <remarks></remarks>
    public class WebUserFC
    {
        private WebUserDA _WebUserDA = new WebUserDA();

        public DataTable Select()
        {
            return _WebUserDA.Select();
        }

        public DataTable Select(string sql)
        {
            return _WebUserDA.Select(sql);
        }

        public int Insert(common.list.WebUser.WebUser obj)
        {
            return _WebUserDA.Insert(obj);
        }

        public Boolean Update(common.list.WebUser.WebUser obj)
        {
            return _WebUserDA.Update(obj);
        }

        public Boolean Delete(int ID)
        {
            return _WebUserDA.Delete(ID);
        }

        public Boolean CheckExist(common.list.WebUser.WebUser obj)
        {
            return _WebUserDA.CheckExist(obj);
        }
    }
}