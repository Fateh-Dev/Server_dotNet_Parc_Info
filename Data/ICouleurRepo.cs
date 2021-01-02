using System;
using System.Collections.Generic;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Data
{
    public interface ICouleurRepo
    {
        bool SaveChanges();
        IEnumerable<Couleur> GetAllCouleurs();
        Couleur GetCouleurById(Guid id);
        void CreateCouleur(Couleur item);
        void UpdateCouleur(Couleur item);
        bool Delete(Guid id);
    }
}