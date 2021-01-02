using System;
using System.ComponentModel.DataAnnotations;

namespace GestionParcInformatique.Dtos.ModelArticle
{
    public class ModelArticleCreateDto
    {
    
        public Guid Id{get;set;}
        public string DesignationFr{get;set;}
        public string DesignationAr { get; set; }
    }
}