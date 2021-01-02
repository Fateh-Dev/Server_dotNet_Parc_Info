using System;
using System.Collections.Generic;

#nullable disable

namespace GestionParcInformatique.Models
{
    public partial class Article
    {
        public Article()
        {
            OperationArticles = new HashSet<OperationArticle>();
        }

        public Guid Id { get; set; }
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

        public virtual Categorie IdCategorieNavigation { get; set; }
        public virtual Couleur IdCouleurNavigation { get; set; }
        public virtual Etat IdEtatNavigation { get; set; }
        public virtual Marque IdMarqueNavigation { get; set; }
        public virtual ModeConsommation IdModeConsommationNavigation { get; set; }
        public virtual ModelArticle IdModelArticleNavigation { get; set; }
        public virtual Utilisateur IdOwnerNavigation { get; set; }
        public virtual TypeArticle IdTypeArticleNavigation { get; set; }
        public virtual UniteMesure IdUniteMesureNavigation { get; set; }
        public virtual ICollection<OperationArticle> OperationArticles { get; set; }
    }
}
