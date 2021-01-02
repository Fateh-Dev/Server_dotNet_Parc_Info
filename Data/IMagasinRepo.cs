using System;
using System.Collections.Generic;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Data
{
    public interface IMagasinRepo
    {
        bool SaveChanges();
        IEnumerable<Magasin> GetAllMagasins();
        Magasin GetMagasinById(Guid id);
        void CreateMagasin(Magasin item); 
        void UpdateMagasin(Magasin item);
        bool Delete(Guid id);
    }
}