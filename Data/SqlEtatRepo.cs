using System;
using System.Collections.Generic;
using System.Linq;
using GestionParcInformatique.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionParcInformatique.Data
{
    public class SqlEtatRepo : IEtatRepo
    {
        private readonly GParcInfoContext _context;

        public SqlEtatRepo(GParcInfoContext context)
        {
            _context = context;
        }

        public void CreateEtat(Etat item)
        {
            if(item==null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _context.Etats.Add(item);
        }
        public void UpdateEtat(Etat item)
        {
            if(item==null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _context.Etats.Add(item);
        }

        public IEnumerable<Etat> GetAllEtats()
        {
            return _context.Etats.ToList();
        }

        public Etat GetEtatById(Guid id)
        {
            return _context.Etats.Find(id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >=0);
        }
        
        public bool Delete(Guid id)
        {
            var Item = _context.Etats.Find(id);
            if(Item==null)
            {
                return false;
            }
            _context.Etats.Remove(Item);
            return true;
        }
    }
}