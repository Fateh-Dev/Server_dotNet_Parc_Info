using System;
using System.Collections.Generic;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Data
{
    public interface ITypeArticleRepo
    {
        bool SaveChanges();
        IEnumerable<TypeArticle> GetAllTypeArticles();
        TypeArticle GetTypeArticleById(Guid id);
        void CreateTypeArticle(TypeArticle item);
        void UpdateTypeArticle(TypeArticle item);
        bool Delete(Guid id);
    }
}