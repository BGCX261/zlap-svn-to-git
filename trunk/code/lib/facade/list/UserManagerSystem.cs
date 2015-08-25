using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using dataaccess.list;
using System.Data;
using common.list;
namespace facade.list
{
    public class UserManagerSystem
    {
        public DataSet GetUserAccount(string user)
        {
            return new UserManager().UserGetUserAndPass(user);
        }
        public DataSet UserSelectUsernameandEmail(string user, string email)
        {
            return new UserManager().UserTestUserNameAndEmail(user, email);
        }
        public Boolean UserInsert(string user, string pass, string name, string company, string job, string baddress, string bcity, string bzip, string bcountry, string saddress, string scity, string szip, string scountry, string mphone, string ophone, string hphone, string fax, string tax, string email1, string email2, string website)
        {
            return new UserManager().UserInsert(user, pass, name, company, job, baddress, bcity, bzip, bcountry, saddress, scity, szip, scountry, mphone, ophone, hphone, fax, tax, email1, email2, website);
        }
        public DataSet GetUserFromTo(int from, int to)
        {
            return new UserManager().UserGetFromTo(from, to);
        }
        public DataSet GetUserTopFromTo(int from,int to)
        {
            return new UserManager().GetDsFromTo("id", "tbl_customeraccount", from, to);
        }
        public DataSet TestUserGetIdFromTo(int from, int to)
        {
            return new UserManager().TestUserGetIdFromTo(from,to);
        }
        public DataSet TestUserGetGroup(string group)
        {
            return new UserManager().TestUserGetGroupId(group);
        }
        public UserAccount_data GetUserInformation(int id)
        {
            return new UserManager().UserGetInformation(id);
        }
        public DataSet GetPayment()
        {
            return new UserManager().GetPayMent();
        }
        public string getOrderNumber()
        {
            return new UserManager().getOrderNumber();
        }
        public DataSet OrderSelectIdUser(string iduser)
        {
            return new UserManager().OrderSelectIdUser(iduser);
        }
        public int OrderUserCount(string iduser)
        {
            return new UserManager().OrderUserCount(iduser);
        }
        public DataSet OrderUserFromTo(string iduser, int from, int to)
        {
            return new UserManager().OrderUserFromTo(iduser, from, to);
        }
        public int OrderInsertNew(string oNumber, int pId, DateTime oDate, int eId, int cId, int posId, int oSId, int oTId, int daysRequest, int shipperId, string shippername, float shippingFee, int currencyId, float currencyRate, string sName, string sAddress, string sCity, string sZipCode, string sCountry, string phone, string email,string note)
        {
            return new UserManager().InsertOrder(oNumber, pId, oDate, eId, cId, posId, oSId, oTId, daysRequest, shipperId, shippername, shippingFee, currencyId, currencyRate, sName, sAddress, sCity, sZipCode, sCountry, phone, email,note);
        }
        public DataSet PosSelectAllForOrderProduct()
        {
            return new UserManager().PosSelectAll();
        }
        public DataSet OrderState()
        {
            return new UserManager().OrderState();
        }
        public DataSet CurrencyCurrent(string name)
        {
            return new UserManager().CurrencyCurrent(name);
        }
        public DataSet SelectInformationForOrder(int idUser, string currencyName)
        {
            return new UserManager().SelectInforForOrder(idUser, currencyName);
        }
        public Boolean InsertOrderDetail(int OrderId, float currencyrate, float discount, float tax, ArrayList listpro)
        {
            return new UserManager().InsertOrderDetail(OrderId, currencyrate, discount, tax, listpro);
        }
        public DataSet OrderSelectDetailId(int id,int iduser)
        {
            return new UserManager().OrderSelectDetailId(id,iduser);
        }
        public DataSet UserGetInforFeedBack(string id)
        {
            return new UserManager().UserGetInforFeedBack(id);
        }
        public Boolean UserSendFeedback(int idUser, string title, string content, DateTime datetime, int type)
        {
            return new UserManager().UserSendFeedback(idUser,title,content,datetime,type);
        }
        public DataSet UserWithRowCountFromTo(int page, int size)
        {
            return new UserManager().UserWithRowCountFromTo(page,size);
        }
        public DataSet UserSelecWithEmail(string email)
        {
            return new UserManager().UserSelectAccountWithEmail(email);
        }
        public Boolean UserInsertRequestPass(string code, string name, string email, DateTime time)
        {
            return new UserManager().UserRequestNewPassInsert(code, name, email, time);
        }
        public DataSet UserTestInfoGetNewPass(string code)
        {
            return new UserManager().UserTestInfoGetNewPass(code);
        }
        public Boolean UserUpdateNewPass(string email, string pass)
        {
            return new UserManager().UserUpdateNewPass(email, pass);
        }
        public Boolean UserUpdateNewPassId(int id, string pass)
        {
            return new UserManager().UserUpdateNewPassId(id, pass);
        }
        public Boolean UserUpdateInfoId(int id, string contactname, string company, string job, string mobile, string officephome, string homephone, string email2, string fax, string tax, string website)
        {
            return new UserManager().UserUpdateInfoId(id, contactname, company, job, mobile, officephome, homephone, email2, fax, tax, website);
        }
        public Boolean UserUpdateBillingId(int id, string address, string city, string zipcode, string country)
        {
            return new UserManager().UserUpdateBillingId(id, address, city, zipcode, country);
        }
        public Boolean UserUpdateShippingId(int id, string address, string city, string zipcode, string country)
        {
            return new UserManager().UserUpdateShippingId(id, address, city, zipcode, country);
        }
    }
}
