using System;
using System.Collections.Generic;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Data
{
    public interface ITypeDocumentRepo
    {
        bool SaveChanges();
        IEnumerable<TypeDocument> GetAllTypeDocuments();
        TypeDocument GetTypeDocumentById(Guid id);
        void CreateTypeDocument(TypeDocument item);
        void UpdateTypeDocument(TypeDocument item);
        bool Delete(Guid id);
    }
}