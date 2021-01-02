using System;
using System.Collections.Generic;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Data
{
    public interface IArticleRepo
    {
        bool SaveChanges();
        IEnumerable<Article> GetAllArticles();
        Article GetArticleById(Guid id);
        void CreateArticle(Article item);
        void UpdateArticle(Article item);
        bool Delete(Guid id);
        long getMaxNumOrdre();
    }
}