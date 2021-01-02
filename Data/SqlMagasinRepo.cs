using System;
using System.Collections.Generic;
using System.Linq;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Data
{
    public class SqlMagasinRepo : IMagasinRepo
    {
        private readonly GParcInfoContext _context;

        public SqlMagasinRepo(GParcInfoContext context)
        {
            _context = context;
        }

        public void CreateMagasin(Magasin item)
        {
            if(item==null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _context.Magasins.Add(item);
        }

        public IEnumerable<Magasin> GetAllMagasins()
        {
            return _context.Magasins.ToList();
        }

        public Magasin GetMagasinById(Guid id)
        {
            return _context.Magasins.Find(id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >=0);
        }
        
        public bool Delete(Guid id)
        {
            var Item = _context.Magasins.Find(id);
            if(Item==null)
            {
                return false;
            }
            _context.Magasins.Remove(Item);
            return true;
        }

        public void UpdateMagasin(Magasin item)
        {
             
        }
    }
}