using System;
using System.Collections.Generic;
using System.Linq;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Data
{
    public class SqlPersonneRepo : IPersonneRepo
    {
        private readonly GParcInfoContext _context;

        public SqlPersonneRepo(GParcInfoContext context)
        {
            _context = context;
        }

        public void CreatePersonne(Personne item)
        {
            if(item==null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _context.Personnes.Add(item);
        }

        public IEnumerable<Personne> GetAllPersonnes()
        {
            return _context.Personnes.ToList();
        }

        public Personne GetPersonneById(Guid id)
        {
            return _context.Personnes.Find(id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >=0);
        }
        
        
        public bool Delete(Guid id)
        {
            var Item = _context.Personnes.Find(id);
            if(Item==null)
            {
                return false;
            }
            _context.Personnes.Remove(Item);
            return true;
        }

        public void UpdatePersonne(Personne item)
        {
             
        }
    }
}