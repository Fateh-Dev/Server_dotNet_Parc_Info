using System;
using System.Collections.Generic;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Data
{
    public interface IServiceRepo
    {
        bool SaveChanges();
        IEnumerable<Service> GetAllServices();
        Service GetServiceById(Guid id);
        void CreateService(Service item); 
        bool Delete(Guid id);
    }
}