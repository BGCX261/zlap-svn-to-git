using System;
using System.Collections;
using System.Text;
using dataaccess.list;
using System.Data;
namespace facade.list
{
    [Serializable]
    public class CManageUserSystem
    {
        public DataSet SelectAllUser()
        {
            return new CManageUser().SelectAllAccount();
        }
        public DataSet SelectUserLogin(string UserName)
        {
            return new CManageUser().SelectUserLogin(UserName);
        }
        public DataSet SelectUserSearch(string where)
        {
            return new CManageUser().SelectAccountSearch(where);
        }
        public DataSet SelectAllAccountInPos(string PosId)
        {
            return new CManageUser().SelectAllAccountInPos(PosId);
        }
        public DataSet SelectAllPosofAccount(string idUser)
        {
            return new CManageUser().SelectAllPosofAccount(idUser);
        }
        public DataSet selectAllKettienOfAccount(string idUser)
        {
            return new CManageUser().selectAllKettienOfAccount(idUser);
        }
        public DataSet selectAllBankAccountOfAccount(string idUser)
        {
            return new CManageUser().selectAllBankAccountOfAccount(idUser);
        }
        public DataSet selectPosOfKettien(string KetId)
        {
            return new CManageUser().selectPosOfKettien(KetId);
        }
        public DataSet selectDepartment(string where)
        {
            return new CManageUser().selectDepartment(where);
        }
        public DataSet WareHouseUserPos(string UserId, string PosId)
        {
            return new CManageUser().WareHouseUserPos(UserId, PosId);
        }
        public DataSet WareHouseOfPos(string PosId)
        {
            return new CManageUser().WareHouseOfPos(PosId);
        }
        public DataSet DestinationOfWH(string WHId)
        {
            return new CManageUser().DestinationOfWH(WHId);
        }
        public DataSet SelectAllUserWareHouse(string WareHouseId)
        {
            return new CManageUser().SelectAllUserWareHouse(WareHouseId);
        }
        public DataSet SelectAddressReport(string PosId)
        {
            return new CManageUser().SelectAddressReport(PosId);
        }
    }
}