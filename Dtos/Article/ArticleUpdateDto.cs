using System;
using System.ComponentModel.DataAnnotations;

namespace GestionParcInformatique.Dtos.Article
{
    public class ArticleUpdateDto
    {
        public string NumSerie { get; set; }
        public string NumRef { get; set; }
        public long NumKit { get; set; }
        public long? QteSeuil { get; set; }
        public long? AnneExpiration { get; set; }
        public long? QteGlobaleEntre { get; set; }
        public string Observation { get; set; }
        public Guid? IdTypeArticle { get; set; }
        public Guid? IdMarque { get; set; }
        public Guid? IdModelArticle { get; set; }
        public Guid? IdCategorie { get; set; }
        public Guid? IdCouleur { get; set; }
        public Guid? IdUniteMesure { get; set; }
        public Guid? IdEtat { get; set; }
        public Guid? IdModeConsommation { get; set; }
        public long NumOrdre { get; set; }
        public DateTime DateCreation { get; set; }
        public string IdOwner { get; set; }
        public long? PrixUnitaire { get; set; }
        public DateTime DateReception { get; set; }
    }
}