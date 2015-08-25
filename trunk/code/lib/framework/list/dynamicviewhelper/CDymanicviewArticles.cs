using System;
using System.Collections.Generic;
using System.Text;
using facade.list;
using System.Data;
namespace framework.list.dynamicviewhelper
{
    public class CDymanicviewArticles:CDynamicViewHelper
    {
        ArticleManagerSystem Articles = new ArticleManagerSystem();
        string where = "";
        int idgroup =0;
        public void BuildWhere()
        {
            if (idgroup > 0)
            {
                where = "idgroup=" + idgroup;
            }
        }
        public void SetIdGroup(int idgroup)
        {
            this.idgroup = idgroup;
        }
        public DataSet ArticleSelectAllFromTo()
        {
            return Articles.ArticleAllSelectFromTo(this.GetFromRow(), this.GetToRow());
        }
        public void SetNumberArticleAll()
        {
            this.SetNumberRecord(this.Articles.ArticleAllCount());
        }
        public void SetNumberArticlesGroup(int idgroup)
        {
            this.SetNumberRecord(Articles.ArticleGroupCount(idgroup));
        }
        public DataSet ArticleGroupSelectFromTo(int idgroup)
        {
            return Articles.ArticleGroupFromTo(idgroup, GetFromRow(), GetToRow());
        }

        //Show Admin article:
        public void AdminSetNumarticle()
        {
            this.SetNumberRecord(Articles.AdminArticleAllCount(where));
        }
        public DataSet AdminArticleFromTo()
        {
            return Articles.AdminArticleSelectFromTo(where, GetFromRow(), GetToRow());
        }
    }
}
