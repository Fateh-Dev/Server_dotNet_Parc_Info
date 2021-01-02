using System;
using System.Collections.Generic;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Data
{
    public interface IUniteMesureRepo
    {
        bool SaveChanges();
        IEnumerable<UniteMesure> GetAllUniteMesures();
        UniteMesure GetUniteMesureById(Guid id);
        void CreateUniteMesure(UniteMesure item);
        void UpdateUniteMesure(UniteMesure item);
        bool Delete(Guid id);
    }
}