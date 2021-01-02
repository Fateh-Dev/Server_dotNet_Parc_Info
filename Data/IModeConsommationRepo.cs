using System;
using System.Collections.Generic;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Data
{
    public interface IModeConsommationRepo
    {
        bool SaveChanges();
        IEnumerable<ModeConsommation> GetAllModeConsommations();
        ModeConsommation GetModeConsommationById(Guid id);
        void CreateModeConsommation(ModeConsommation item);
        void UpdateModeConsommation(ModeConsommation item);
        bool Delete(Guid id);
    }
}