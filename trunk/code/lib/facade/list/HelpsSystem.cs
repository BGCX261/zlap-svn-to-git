using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using dataaccess.list;
namespace facade.list
{
    public class HelpsSystem
    {
        public DataSet HelpsSelectAll()
        {
            return new HelpsManager().HelpsSelectAll();
        }
        public DataSet HelpsSelectIdName(int id, string name)
        {
            return new HelpsManager().HelpsSelectIdName(id, name);
        }
        public Boolean HelpsInsert(string name, string content, int sort)
        {
            return new HelpsManager().HelpsInsert(name, content, sort);
        }
        public Boolean HelpsUpdate(int id,string name, string content, int sort)
        {
            return new HelpsManager().HelpsUpdate(id,name, content, sort);
        }
        public Boolean HelpsDelete(string id)
        {
            return new HelpsManager().HelpsDelete(id);
        }
    }
}
