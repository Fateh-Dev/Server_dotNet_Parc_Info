using System;
using System.Collections.Generic;
using System.Linq;
using GestionParcInformatique.Dtos.Article;
using GestionParcInformatique.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionParcInformatique.Data
{
    public class SqlArticleRepo : IArticleRepo
    {
        private readonly GParcInfoContext _context;

        public SqlArticleRepo(GParcInfoContext context)
        {
            _context = context;
        }

        public void CreateArticle(Article item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _context.Articles.Add(item);
        }

        public IEnumerable<Article> GetAllArticles()
        {
            return _context.Articles.ToList();
        }

        public Article GetArticleById(Guid id)
        {
            return _context.Articles.Find(id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }


        public bool Delete(Guid id)
        {
            var Item = _context.Articles.Find(id);
            if (Item == null)
            {
                return false;
            }
            _context.Articles.Remove(Item);
            return true;
        }

        public void UpdateArticle(Article item)
        {

        }
        public long getMaxNumOrdre()
        {
            long maxOrdre = _context.Articles.Max(x => (long?)x.NumOrdre) ?? 0;
            // long maxOrdre = _context.Articles.Select(p => p.NumOrdre).DefaultIfEmpty(0).Max();
            return maxOrdre+1;
        }
    }
}