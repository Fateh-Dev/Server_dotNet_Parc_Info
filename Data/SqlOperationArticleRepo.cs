using System;
using System.Collections.Generic;
using System.Linq;
using GestionParcInformatique.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionParcInformatique.Data
{
    public class SqlOperationArticleRepo : IOperationArticleRepo
    {
        private readonly GParcInfoContext _context;

        public SqlOperationArticleRepo(GParcInfoContext context)
        {
            _context = context;
        }

        public void CreateOperationArticle(OperationArticle item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _context.OperationArticles.Add(item);
        }

        public IEnumerable<OperationArticle> GetAllOperationArticles()
        {
            return _context.OperationArticles.ToList();
        }

        public OperationArticle GetOperationArticleById(Guid id)
        {
            return _context.OperationArticles.Find(id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }


        public bool Delete(Guid id)
        {
            var Item = _context.OperationArticles.Find(id);
            if(Item==null)
            {
                return false;
            }
            _context.OperationArticles.Remove(Item);
            return true;
        }

        public void UpdateOperationArticle(OperationArticle item)
        {
             
        }
    }
}