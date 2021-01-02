using System;
using System.Collections.Generic;
using System.Linq;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Data
{
    public class SqlCouleurRepo : ICouleurRepo
    {
        private readonly GParcInfoContext _context;

        public SqlCouleurRepo(GParcInfoContext context)
        {
            _context = context;
        }

        public void CreateCouleur(Couleur item)
        {
            if(item==null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _context.Couleurs.Add(item);
        }

        public IEnumerable<Couleur> GetAllCouleurs()
        {
            return _context.Couleurs.ToList();
        }

        public Couleur GetCouleurById(Guid id)
        {
            return _context.Couleurs.Find(id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >=0);
        }
        
        public bool Delete(Guid id)
        {
            var Item = _context.Couleurs.Find(id);
            if(Item==null)
            {
                return false;
            }
            _context.Couleurs.Remove(Item);
            return true;
        }

        public void UpdateCouleur(Couleur item)
        {
             
        }
    }
}