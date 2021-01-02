using System;
using System.Collections.Generic;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Data
{
    public interface IPersonneRepo
    {
        bool SaveChanges();
        IEnumerable<Personne> GetAllPersonnes();
        Personne GetPersonneById(Guid id);
        void CreatePersonne(Personne item);
        void UpdatePersonne(Personne item);
        bool Delete(Guid id);
    }
}