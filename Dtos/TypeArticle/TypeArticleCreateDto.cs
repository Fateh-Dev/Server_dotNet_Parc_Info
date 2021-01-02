using System;
using System.ComponentModel.DataAnnotations;

namespace GestionParcInformatique.Dtos.TypeArticle
{
    public class TypeArticleCreateDto
    {
    
        public Guid Id{get;set;}
        public string DesignationFr{get;set;}
        public string DesignationAr { get; set; }
    }
}