using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using dataaccess.list;
namespace facade.list
{
    public class SupportOnlineSystem
    {
        SupportOnlineManager OnlineManager = new SupportOnlineManager();
        public DataSet OnlineSelectAll(string typeid)
        {
            return OnlineManager.OnlineSelectAll(typeid);
        }
        public DataSet OnlineAdminSelectAll()
        {
            return OnlineManager.OnlineAdminSelectAll();
        }
        public DataSet OnlineSelectId(string id)
        {
            return OnlineManager.OnlineSelectId(id);
        }
        public Boolean OnlineInsert(string name, string nickname, string title, int idgroup, string namegroup, int sort, int type)
        {
            return OnlineManager.OnlineInsert(name, nickname, title, idgroup, namegroup, sort, type);
        }
        public Boolean OnlineUpdate(int id, string name, string nickname, string title, int idgroup, string namegroup, int sort)
        {
            return OnlineManager.OnlineUpdate(id, name, nickname, title, idgroup, namegroup, sort);
        }
        public Boolean OnlineDelete(string id)
        {
            return OnlineManager.OnlineDelete(id);
        }
    }
}