using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using dataaccess.list;
namespace facade.list
{
    public class ArticleManagerSystem
    {
        public DataSet ArticleGroupSelectAll()
        {
            return new ArticlesManager().AdminGroupAll();
        }
        public DataSet ArticleAllSelectFromTo(int from, int to)
        {
            return new ArticlesManager().ArticleAllSelectFromTo(from, to);
        }
        public int ArticleAllCount()
        {
            return new ArticlesManager().ArticleAllCount();
        }
        public int ArticleGroupCount(int idgroup)
        {
            return new ArticlesManager().ArticleGroupCount(idgroup);
        }
        public DataSet ArticleGroupFromTo(int idgroup,int from,int to)
        {
            return new ArticlesManager().ArticleGroupSelectFromTo(idgroup, from, to);
        }
        public DataSet ArticlesTop()
        {
            return new ArticlesManager().ArticleTop();
        }
        public DataSet ArticleSelectDetail(int id)
        {
            return new ArticlesManager().ArticleSelectDetail(id);
        }
        public DataSet AdminGroupAll()
        {
            return new ArticlesManager().AdminGroupAll();
        }
        public DataSet AdminGroupSelectId(int id, string name)
        {
            return new ArticlesManager().AdminGroupSelectId(id, name);
        }
        public Boolean AdminGroupInsert(string name, string ishow)
        {
            return new ArticlesManager().AdminGroupInsert(name, ishow);
        }
        public Boolean AdminGroupUpdateId(int id, string name, string ishow)
        {
            return new ArticlesManager().AdminGroupUpdateId(id, name, ishow);
        }
        public Boolean AdminGroupDeleteId(string id)
        {
            return new ArticlesManager().AdminGroupDeleteId(id);
        }
        public DataSet AdminArticleSelectFromTo(string where, int from, int to)
        {
            return new ArticlesManager().AdminArticleSelectFromTo(where, from, to);
        }
        public int AdminArticleAllCount(string where)
        {
            return new ArticlesManager().AdminArticleAllCount(where);
        }
        public DataSet AdminArticleTestExsit(int id, string name)
        {
            return new ArticlesManager().AdminArticleTestExsit(id, name);
        }
        public Boolean AdminArticleInsert(int idgroup, string title, string sum, string content, string image, DateTime time, string source, string link, string ishow)
        {
            return new ArticlesManager().AdminArticleInsert(idgroup, title, sum, content, image, time, source, link, ishow);
        }
        public Boolean AdminArticleUpdate(int id,int idgroup, string title, string sum, string content, string image, DateTime time, string source, string link, string ishow)
        {
            return new ArticlesManager().AdminArticleUpdate(id,idgroup, title, sum, content, image, time, source, link, ishow);
        }
        public Boolean AdminArticleDelete(string id)
        {
            return new ArticlesManager().AdminArticleDelete(id);
        }
        //For help buy laptop:
        public DataSet HelpBuyAllTile()
        {
            return new ArticlesManager().HelpBuyAllTitle();
        }
        public DataSet HelpBuyDetail(string id)
        {
            return new ArticlesManager().HelpBuyDetail(id);
        }
        public Boolean HelpBuyInsert(string title, string subcontent, string content, string urlimage, string source, string link, DateTime timeupdate)
        {
            return new ArticlesManager().HelpBuyInsert(title, subcontent, content, urlimage, source, link, timeupdate);
        }
        public Boolean HelpBuyUpdate(int id,string title,string subcontent, string content, string urlimage, string source, string link, DateTime timeupdate)
        {
            return new ArticlesManager().HelpBuyUpdate(id, title, subcontent, content, urlimage, source, link, timeupdate);
        }
        public Boolean HelpBuyDeleteid(string id)
        {
            return new ArticlesManager().HelpBuyDeleteId(id);
        }
        public DataSet HelpBuyTopTitle()
        {
            return new ArticlesManager().HelpBuyTopTitle();
        }
    }
}