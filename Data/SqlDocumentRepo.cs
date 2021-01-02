using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionParcInformatique.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionParcInformatique.Data
{
    public class SqlDocumentRepo : IDocumentRepo
    {
        private readonly GParcInfoContext _context;

        public SqlDocumentRepo(GParcInfoContext context)
        {
            _context = context;
        }

        public void CreateDocument(Document item)
        {
            createMissingDetails(item);
            _context.Documents.Add(item);
        }

        public void UpdateDocument(Document item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                    var detailsIds = item.OperationArticles.Select(k => k.Id).ToHashSet();
                    var toDelete = _context.OperationArticles.Where(k => k.IdDocument == item.Id && !detailsIds.Contains(k.Id));
                    
                    //TODO 
                    _context.OperationArticles.RemoveRange(toDelete);
                    createMissingDetails(item);
                    _context.Entry(item).State = EntityState.Modified;
                }
        }

        public IEnumerable<Document> GetAllDocuments()
        {
            return _context.Documents.ToList();
        }

        public Document GetDocumentById(Guid id)
        {
            return _context.Documents.Find(id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }


        public bool Delete(Guid id)
        {
            var Item = _context.Documents.Find(id);
            if (Item == null)
            {
                return false;
            }
            var OperationsToDelete=_context.OperationArticles.Where(KeyExtensions=>KeyExtensions.IdDocument==id);
            _context.OperationArticles.RemoveRange(OperationsToDelete);
            _context.Documents.Remove(Item); 
            return true;
        }
        public void createMissingDetails(Document Item)
        {
            if (Item.OperationArticles != null) foreach (var det in Item.OperationArticles)
                {

                    if (det.Id == Guid.Empty)
                    {
                        det.Id = Guid.NewGuid();
                        det.IdDocument = Item.Id;
                        _context.OperationArticles.Add(det);
                    }
                }
        }
    }
}