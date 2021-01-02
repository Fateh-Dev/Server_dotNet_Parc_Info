using System;
using System.Collections.Generic;
using System.Linq;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Data
{
    public class SqlTypeMouvementRepo : ITypeMouvementRepo
    {
        private readonly GParcInfoContext _context;

        public SqlTypeMouvementRepo(GParcInfoContext context)
        {
            _context = context;
        }

        public void CreateTypeMouvement(TypeMouvement item)
        {
            if(item==null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _context.TypeMouvements.Add(item);
        }

        public IEnumerable<TypeMouvement> GetAllTypeMouvements()
        {
            return _context.TypeMouvements.ToList();
        }

        public TypeMouvement GetTypeMouvementById(Guid id)
        {
            return _context.TypeMouvements.Find(id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >=0);
        }
        
        public bool Delete(Guid id)
        {
            var Item = _context.TypeMouvements.Find(id);
            if(Item==null)
            {
                return false;
            }
            _context.TypeMouvements.Remove(Item);
            return true;
        }

        public void UpdateTypeMouvement(TypeMouvement item)
        {
             
        }
    }
}