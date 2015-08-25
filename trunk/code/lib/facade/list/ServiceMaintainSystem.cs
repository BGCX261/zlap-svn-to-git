using System;
using System.Collections.Generic;
using System.Text;
using dataaccess.list;
using System.Data;
namespace facade.list
{
    public class ServiceMaintainSystem
    {
        public DataSet ServiceMaintainAll()
        {
            return new ServiceMaintain().ServiceMaintainAll();
        }
    }
}
