using System;
using System.Collections.Generic;
using System.Linq;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Data
{
    public class SqlTypeArticleRepo : ITypeArticleRepo
    {
        private readonly GParcInfoContext _context;

        public SqlTypeArticleRepo(GParcInfoContext context)
        {
            _context = context;
        }

        public void CreateTypeArticle(TypeArticle item)
        {
            if(item==null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _context.TypeArticles.Add(item);
        }

        public IEnumerable<TypeArticle> GetAllTypeArticles()
        {
            return _context.TypeArticles.ToList();
        }

        public TypeArticle GetTypeArticleById(Guid id)
        {
            return _context.TypeArticles.Find(id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >=0);
        }
        
        public bool Delete(Guid id)
        {
            var Item = _context.TypeArticles.Find(id);
            if(Item==null)
            {
                return false;
            }
            _context.TypeArticles.Remove(Item);
            return true;
        }

        public void UpdateTypeArticle(TypeArticle item)
        {
             
        }
    }
}