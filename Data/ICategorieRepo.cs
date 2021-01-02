using System;
using System.Collections.Generic;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Data
{
    public interface ICategorieRepo
    {
        bool SaveChanges();
        IEnumerable<Categorie> GetAllCategories();
        Categorie GetCategorieById(Guid id);
        void CreateCategorie(Categorie item);

        void UpdateCategorie(Categorie item);
        bool Delete(Guid id);
    }
} 