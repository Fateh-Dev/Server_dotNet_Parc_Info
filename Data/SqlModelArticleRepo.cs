using System;
using System.Collections.Generic;
using System.Linq;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Data
{
    public class SqlModelArticleRepo : IModelArticleRepo
    {
        private readonly GParcInfoContext _context;

        public SqlModelArticleRepo(GParcInfoContext context)
        {
            _context = context;
        }

        public void CreateModelArticle(ModelArticle item)
        {
            if(item==null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _context.ModelArticles.Add(item);
        }

        public IEnumerable<ModelArticle> GetAllModelArticles()
        {
            return _context.ModelArticles.ToList();
        }

        public ModelArticle GetModelArticleById(Guid id)
        {
            return _context.ModelArticles.Find(id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >=0);
        }
        
        public bool Delete(Guid id)
        {
            var Item = _context.ModelArticles.Find(id);
            if(Item==null)
            {
                return false;
            }
            _context.ModelArticles.Remove(Item);
            return true;
        }

        public void UpdateModelArticle(ModelArticle item)
        {
             
        }
    }
}