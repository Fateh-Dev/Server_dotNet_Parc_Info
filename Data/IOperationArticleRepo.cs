using System;
using System.Collections.Generic;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Data
{
    public interface IOperationArticleRepo
    {
        bool SaveChanges();
        IEnumerable<OperationArticle> GetAllOperationArticles();
        OperationArticle GetOperationArticleById(Guid id);
        void CreateOperationArticle(OperationArticle item);
        void UpdateOperationArticle(OperationArticle item);
        bool Delete(Guid id);
    }
}