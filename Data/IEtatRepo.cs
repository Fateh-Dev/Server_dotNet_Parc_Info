using System;
using System.Collections.Generic;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Data
{
    public interface IEtatRepo
    {
        bool SaveChanges();
        IEnumerable<Etat> GetAllEtats();
        Etat GetEtatById(Guid id);
        void CreateEtat(Etat item); 
        void UpdateEtat(Etat item); 
        bool Delete(Guid id);
    }
}