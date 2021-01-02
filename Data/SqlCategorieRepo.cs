using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Data
{
    public class SqlCategorieRepo : ICategorieRepo
    {
        private readonly GParcInfoContext _context;

        public SqlCategorieRepo(GParcInfoContext context)
        {
            _context = context;
        }

        public void CreateCategorie(Categorie item)
        {
            if(item==null) 
            {
                throw new ArgumentNullException(nameof(item));
            }
            _context.Categories.Add(item);
        }

        public IEnumerable<Categorie> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public Categorie GetCategorieById(Guid id)
        {
            return _context.Categories.Find(id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >=0);
        }
        
        public bool Delete(Guid id)
        {
            var CategorieItem = _context.Categories.Find(id);
            if(CategorieItem==null)
            {
                return false;
            }
            _context.Categories.Remove(CategorieItem);
            return true;
        }

        public void UpdateCategorie(Categorie item)
        {
             
        }
    }
}