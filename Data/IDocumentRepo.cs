using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestionParcInformatique.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionParcInformatique.Data
{
    public interface IDocumentRepo
    {
        bool SaveChanges();
        IEnumerable<Document> GetAllDocuments();
        Document GetDocumentById(Guid id);
        void  CreateDocument(Document item);
        void UpdateDocument(Document item);
        bool Delete(Guid id);
        void createMissingDetails(Document Item);
    }
}