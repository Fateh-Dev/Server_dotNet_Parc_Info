using System;

namespace GestionParcInformatique.Dtos.ModelArticle
{
    public class ModelArticleReadDto
    {
        public Guid Id { get; set; }
        public string DesignationFr { get; set; }
        public string DesignationAr { get; set; }
        public long NumOrdre { get; set; }
        public DateTime DateCreation { get; set; }
        public string IdOwner { get; set; } 
    }
}