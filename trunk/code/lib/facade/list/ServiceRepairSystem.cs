using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using dataaccess.list;
namespace facade.list
{
    public class ServiceRepairSystem
    {
        public DataSet ServiceRepairAll()
        {
            return new ServiceRepair().ServiceRepairAll();
        }
    }
}