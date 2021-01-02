using System;
using System.Collections.Generic;
using System.Linq;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Data
{
    public class SqlModeConsommationRepo : IModeConsommationRepo
    {
        private readonly GParcInfoContext _context;

        public SqlModeConsommationRepo(GParcInfoContext context)
        {
            _context = context;
        }

        public void CreateModeConsommation(ModeConsommation item)
        {
            if(item==null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _context.ModeConsommations.Add(item);
        }

        public IEnumerable<ModeConsommation> GetAllModeConsommations()
        {
            return _context.ModeConsommations.ToList();
        }

        public ModeConsommation GetModeConsommationById(Guid id)
        {
            return _context.ModeConsommations.Find(id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >=0);
        }
        
        public bool Delete(Guid id)
        {
            var Item = _context.ModeConsommations.Find(id);
            if(Item==null)
            {
                return false;
            }
            _context.ModeConsommations.Remove(Item);
            return true;
        }

        public void UpdateModeConsommation(ModeConsommation item)
        {
             
        }
    }
}