using System;
using System.Collections.Generic;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Data
{
    public interface IMarqueRepo
    {
        bool SaveChanges();
        IEnumerable<Marque> GetAllMarques();
        Marque GetMarqueById(Guid id);
        void CreateMarque(Marque item);
        void UpdateMarque(Marque item);
        bool Delete(Guid id);
    }
}