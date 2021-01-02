using System;
using System.Collections.Generic;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Data
{
    public interface IModelArticleRepo
    {
        bool SaveChanges();
        IEnumerable<ModelArticle> GetAllModelArticles();
        ModelArticle GetModelArticleById(Guid id);
        void CreateModelArticle(ModelArticle item);
        void UpdateModelArticle(ModelArticle item);
        bool Delete(Guid id);
    }
}