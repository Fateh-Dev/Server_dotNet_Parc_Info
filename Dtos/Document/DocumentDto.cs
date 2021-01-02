using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Dtos.Document
{
    public class DocumentDto
    {
    
        public Guid? Id { get; set; }
        public string RefDocument { get; set; }
        public string Observation { get; set; }
        public DateTime DateDocument { get; set; }
        public DateTime DateValidation { get; set; }
        public Guid? IdPersonneSigne { get; set; }
        public Guid? IdPersonneUse { get; set; }
        public Guid? IdTypeDocument { get; set; }
        public Guid? IdTypeMouvement { get; set; }
        public Guid? IdServiceOwner { get; set; }
        public Guid? IdServiceDest { get; set; }
        public Guid? IdOldService { get; set; }
        public long NumOrdre { get; set; }
        public DateTime DateCreation { get; set; }
        public string IdOwner { get; set; }
        public Guid? IdMagasin { get; set; }
         public virtual ICollection<OperationArticle> OperationArticles { get; set; }
    }
}