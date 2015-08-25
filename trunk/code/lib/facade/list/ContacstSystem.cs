using System;
using System.Collections.Generic;
using System.Text;
using dataaccess.list;
using System.Data;
namespace facade.list
{
    public class ContacstSystem
    {
        public DataSet ContactsSelectAll()
        {
            return new ContactManager().ContactSelectAll();
        }
        public DataSet ContactsSelectAll(string groupid)
        {
            return new ContactManager().ContactSelectAll(groupid);
        }
        //admin:Group:
        public DataSet GroupContactSelectAll()
        {
            return new ContactManager().GroupContactSelectAll();
        }
        public DataSet GroupContactSelectIdName(int id, string name)
        {
            return new ContactManager().GroupContactSelectIdName(id, name);
        }
        public Boolean GroupContactInsert(string name, int sort)
        {
            return new ContactManager().GroupContactInsert(name, sort);
        }
        public Boolean GroupContactUpdate(int id, string name, int sort)
        {
            return new ContactManager().GroupContactUpdate(id, name, sort);
        }
        public Boolean GroupContactDeleteId(string id)
        {
            return new ContactManager().GroupContactDelete(id);
        }
        //Admin Location contact:
        public DataSet LocationContactSelectAll()
        {
            return new ContactManager().LocationContactSelectAll();
        }
        public DataSet LocationContactSelectIdName(int id, string name)
        {
            return new ContactManager().LocationContactSelectIdName(id, name);
        }
        public Boolean LocationContactInsert(string name)
        {
            return new ContactManager().LocationContactInsert(name);
        }
        public Boolean LocationContactupdate(int id,string name)
        {
            return new ContactManager().LocationContactUpdate(id,name);
        }
        public Boolean LocationContactDelete(string id)
        {
            return new ContactManager().LocationContactDelete(id);
        }
        public DataSet ContactAdminSelectAll()
        {
            return new ContactManager().ContactAdminSelectAll();
        }
        public DataSet ContactAdminSelectIdName(int id, string name)
        {
            return new ContactManager().ContactAdminSelectIdName(id, name);
        }
        public Boolean ContactAdminInsert(int idlocation, int idtype, string name, string des, string address, string urlImage, string timeservice, string phone, string delegate1, string email, string fax,int groupid)
        {
            return new ContactManager().ContactAdminInsert(idlocation, idtype, name, des, address, urlImage, timeservice, phone, delegate1, email, fax, groupid);
        }
        public Boolean ContactAdminUpdate(int id, int idlocation, int idtype, string name, string des, string address, string urlImage, string timeservice, string phone, string delegate1, string email, string fax)
        {
            return new ContactManager().ContactAdminUpdate(id,idlocation, idtype, name, des, address, urlImage, timeservice, phone, delegate1, email, fax);
        }
        public Boolean ContactAdminDelete(string id)
        {
            return new ContactManager().ContactAdminDelete(id);
        }
    }
}
