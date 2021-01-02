using System;
using System.Collections.Generic;
using System.Linq;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Data
{
    public class SqlTypeDocumentRepo : ITypeDocumentRepo
    {
        private readonly GParcInfoContext _context;

        public SqlTypeDocumentRepo(GParcInfoContext context)
        {
            _context = context;
        }

        public void CreateTypeDocument(TypeDocument item)
        {
            if(item==null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _context.TypeDocuments.Add(item);
        }

        public IEnumerable<TypeDocument> GetAllTypeDocuments()
        {
            return _context.TypeDocuments.ToList();
        }

        public TypeDocument GetTypeDocumentById(Guid id)
        {
            return _context.TypeDocuments.Find(id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >=0);
        }
        
        public bool Delete(Guid id)
        {
            var Item = _context.TypeDocuments.Find(id);
            if(Item==null)
            {
                return false;
            }
            _context.TypeDocuments.Remove(Item);
            return true;
        }

        public void UpdateTypeDocument(TypeDocument item)
        {
             
        }
    }
}