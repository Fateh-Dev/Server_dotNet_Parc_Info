using System;
using System.Collections.Generic;
using System.Linq;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Data
{
    public class SqlUniteMesureRepo : IUniteMesureRepo
    {
        private readonly GParcInfoContext _context;

        public SqlUniteMesureRepo(GParcInfoContext context)
        {
            _context = context;
        }

        public void CreateUniteMesure(UniteMesure item)
        {
            if(item==null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _context.UniteMesures.Add(item);
        }

        public IEnumerable<UniteMesure> GetAllUniteMesures()
        {
            return _context.UniteMesures.ToList();
        }

        public UniteMesure GetUniteMesureById(Guid id)
        {
            return _context.UniteMesures.Find(id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >=0);
        }
        
        
        public bool Delete(Guid id)
        {
            var Item = _context.UniteMesures.Find(id);
            if(Item==null)
            {
                return false;
            }
            _context.UniteMesures.Remove(Item);
            return true;
        }

        public void UpdateUniteMesure(UniteMesure item)
        {
             
        }
    }
}