using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using dataaccess.list;
namespace facade.list
{
    public class AdvertiseSystem
    {
        public DataSet AdvertiseSelectAllShow()
        {
            return new advertisemanager().AdvertiseSelectAll();
        }
        public Boolean AdvertiseInsert(string title, int sort, string link, string image, string ishow,string note)
        {
            return new advertisemanager().AdvertiseInsert(title, sort, link, image, ishow, note);
        }
        public Boolean AdvertiseUpdate(int id,string title, int sort, string link, string image, string ishow, string note)
        {
            return new advertisemanager().AdvertiseUpdate(id,title, sort, link, image, ishow, note);
        }
        public Boolean AdvertiseDelete(string id)
        {
            return new advertisemanager().AdvertiseDelete(id);
        }
        public DataSet AdvertiseAdminSelectAll()
        {
            return new advertisemanager().AdvertiseAdminSelectAll();
        }
        public DataSet AdvertiseSelectId(string id)
        {
            return new advertisemanager().AdvertiseSelectId(id);
        }
        //Advertise Special:
        public DataSet SpecialIdbrandTop(string idbrand,int type)
        {
            return new advertisemanager().SpecialIdbrand(idbrand,type);
        }
        public DataSet SpecialSelectWhere(string where)
        {
            return new advertisemanager().SpecialSelectWhere(where);
        }
        public DataSet SpecialAll()
        {
            return new advertisemanager().SpecialAll();
        }
        public DataSet SpecialSelectId(int id)
        {
            return new advertisemanager().SpecialSelectId(id);
        }
        public DataSet SpecialAdminAll()
        {
            return new advertisemanager().SpecialAdminAll();
        }
        public Boolean SpecialInsert(int idbrand, string title, string content, string Url1, string Url2, string Link, int sort,int type)
        {
            return new advertisemanager().SpecialInsert(idbrand, title, content, Url1, Url2, Link, sort,type);
        }
        public Boolean SpecialUpdate(int id, int idbrand, string title, string content, string Url1, string Url2, string Link, int sort)
        {
            return new advertisemanager().SpecialUpdate(id,idbrand, title, content, Url1, Url2, Link, sort);
        }
        public Boolean SpecialDelete(string id)
        {
            return new advertisemanager().SpecialDelete(id);
        }
    }
}
