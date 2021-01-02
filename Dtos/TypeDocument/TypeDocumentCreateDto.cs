using System;
using System.ComponentModel.DataAnnotations;

namespace GestionParcInformatique.Dtos.TypeDocument
{
    public class TypeDocumentCreateDto
    {
    
        public Guid Id{get;set;}
        public string DesignationFr{get;set;}
        public string DesignationAr { get; set; }
    }
}