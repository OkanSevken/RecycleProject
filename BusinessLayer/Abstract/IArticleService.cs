using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IArticleService
    {
        List<Article> GetList();
        void ArticleAdd(Article article);
        Article GetByID(int id);
        void ArticleDelete(Article article);
        void ArticleUpdate(Article article);
    }
}
