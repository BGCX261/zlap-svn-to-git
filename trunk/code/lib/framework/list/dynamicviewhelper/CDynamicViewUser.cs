using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using facade.list;
namespace framework.list.dynamicviewhelper
{
    public class CDynamicViewUser:CDynamicViewHelper
    {
        public DataSet GetUserFromTo()
        {
            return new UserManagerSystem().GetUserFromTo(this.GetFromRow(), this.GetToRow());
        }
        public DataSet GetUserTopFromTo()
        {
            return new UserManagerSystem().GetUserTopFromTo(this.GetFromRow(), this.GetToRow());
        }
        public DataSet TestUserIdGetFromTo()
        {
            return new UserManagerSystem().TestUserGetIdFromTo(GetFromRow(), GetToRow());
        }
        public DataSet TestUserGetGroup(string group)
        {
            return new UserManagerSystem().TestUserGetGroup(group);
        }
        public DataSet UserWithRowCountFromTo()
        {
            return new UserManagerSystem().UserWithRowCountFromTo(GetCurrentPage(), GetPageSize());
        }
    }
}
