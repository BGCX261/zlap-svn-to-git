using System;
using System.Collections.Generic;
using System.Text;
using dataaccess.list;
using System.Data;
using common.list;
namespace facade.list
{
    public class ComponentProductSystem
    {
        public DataSet ComponentGroup(int idtype)
        {
            return new ComponentProduct().ComponentSelectGroup(idtype);
        }
        public DataSet ComponentGroupSale(int IdType)
        {
            return new ComponentProduct().ComponentSelectGroupSale(IdType);
        }
        public DataSet ComGroupTop(string idtype)
        {
            return new ComponentProduct().ComponentGroupTop(idtype);
        }
        public DataSet ComponentGroupTop(int idtype)
        {
            return new ComponentProduct().ComponentSelectGroupTop(idtype);
        }
        public DataSet GroupComponentBrand(int idtype)
        {
            return new ComponentProduct().GroupComponentBrand(idtype);
        }
        public int ComponentAllCount(int idtype)
        {
            return new ComponentProduct().ComponentAllCount(idtype);
        }
        public Component_data ComponentAllFromTo(int idtype, int from, int to)
        {
            return new ComponentProduct().ComponentAllFromTo(idtype, from, to);
        }
        public Component_data ComponentGroupFromTo(int idtype, int idgroup, int from, int to)
        {
            return new ComponentProduct().ComponantGroupFromTo(idtype, idgroup, from, to);
        }
        public int ComponentGroupCount(int idtype, int idgroup,ref string NameGroup)
        {
            return new ComponentProduct().ComponentGroupCount(idtype, idgroup,ref NameGroup);
        }
        public DataSet ComponentNameId(string id)
        {
            return new ComponentProduct().ComponentNameId(id);
        }
        public string ComponentGroupName(int idtype, int idgroup)
        {
            return new ComponentProduct().ComponentTypeName(idtype, idgroup);
        }
        public int ComponentQuickSearchCount(string where)
        {
            return new ComponentProduct().ComponentQuickSearchCount(where);
        }
        public Component_data ComponentQuickSearchFromTo(string where, int from, int to)
        {
            return new ComponentProduct().ComponentQuickSearchFromTo(where, from, to);
        }
        public DataSet ComponenttoCart(string id, string idtype)
        {
            return new ComponentProduct().ComponenttoCart(id, idtype);
        }
        public DataSet ComponenttoCart(string id)
        {
            return new ComponentProduct().ComponenttoCart(id);
        }
        public DataSet ComponentSelectDetail(int id, int type)
        {
            return new ComponentProduct().ComponentSelectDetail(id, type);
        }
        public DataSet ComponentSelectDetailId(int id)
        {
            return new ComponentProduct().ComponentSelectDetailId(id);
        }
        public Boolean ComponentUpdateImage(int id, string nameImage)
        {
            return new ComponentProduct().ComponentUpdateImage(id, nameImage);
        }
        public Boolean GroupComponentUpdateImage(int id, string nameImage)
        {
            return new ComponentProduct().GroupComponentUpdateImage(id, nameImage);
        }
        public int ComponentAllCount(string where)
        {
            return new ComponentProduct().ComponentAllCount(where);
        }
        public DataSet ComponentSelectAllFromTo(string where, int from, int to)
        {
            return new ComponentProduct().ComponentSelectAllFromTo(where, from, to);
        }
        public DataSet ComponentCurrentAccess(string where)
        {
            return new ComponentProduct().ComponentCurrentAccess(where);
        }
        public int ComponentCompatibleCount(string where)
        {
            return new ComponentProduct().ComponentCompatibleCount(where);
        }
        public DataSet ComponentCompatibleFromTo(string where,int from,int to)
        {
            return new ComponentProduct().ComponentCompatibleSelectAllFromTo(where, from, to);
        }
    }
}
