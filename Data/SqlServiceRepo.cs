using System;
using System.Collections.Generic;
using System.Linq;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Data
{
    public class SqlServiceRepo : IServiceRepo
    {
        private readonly GParcInfoContext _context;

        public SqlServiceRepo(GParcInfoContext context)
        {
            _context = context;
        }

        public void CreateService(Service item)
        {
            if(item==null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _context.Services.Add(item);
        }

        public IEnumerable<Service> GetAllServices()
        {
            return _context.Services.ToList();
        }

        public Service GetServiceById(Guid id)
        {
            return _context.Services.Find(id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >=0);
        }
        
        public bool Delete(Guid id)
        {
            var Item = _context.Services.Find(id);
            if(Item==null)
            {
                return false;
            }
            _context.Services.Remove(Item);
            return true;
        }
    }
}