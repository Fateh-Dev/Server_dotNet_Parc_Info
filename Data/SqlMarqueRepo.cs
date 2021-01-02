using System;
using System.Collections.Generic;
using System.Linq;
using GestionParcInformatique.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionParcInformatique.Data
{
    public class SqlMarqueRepo : IMarqueRepo
    {
        private readonly GParcInfoContext _context;

        public SqlMarqueRepo(GParcInfoContext context)
        {
            _context = context;
        }

        public void CreateMarque(Marque item)
        {
            if(item==null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _context.Marques.Add(item);
        }

        public void UpdateMarque(Marque item)
        {
            // _context.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<Marque> GetAllMarques()
        {
            return _context.Marques.ToList();
        }

        public Marque GetMarqueById(Guid id)
        {
            return _context.Marques.Find(id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >=0);
        }
        
        public bool Delete(Guid id)
        {
            var Item = _context.Marques.Find(id);
            if(Item==null)
            {
                return false;
            }
            _context.Marques.Remove(Item);
            return true;
        }
    }
}