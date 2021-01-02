using System;
using System.Collections.Generic;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Data
{
    public interface ITypeMouvementRepo
    {
        bool SaveChanges();
        IEnumerable<TypeMouvement> GetAllTypeMouvements();
        TypeMouvement GetTypeMouvementById(Guid id);
        void CreateTypeMouvement(TypeMouvement item);
        void UpdateTypeMouvement(TypeMouvement item);
        bool Delete(Guid id);
    }
}