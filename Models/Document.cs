using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace GestionParcInformatique.Models
{
    public partial class Document
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
        [JsonIgnore]
        public virtual Magasin IdMagasinNavigation { get; set; }
        [JsonIgnore]

        public virtual Service IdOldServiceNavigation { get; set; }
        [JsonIgnore]

        public virtual Utilisateur IdOwnerNavigation { get; set; }
        [JsonIgnore]

        public virtual Personne IdPersonneSigneNavigation { get; set; }
        [JsonIgnore]

        public virtual Personne IdPersonneUseNavigation { get; set; }
        [JsonIgnore]

        public virtual Service IdServiceDestNavigation { get; set; }
        [JsonIgnore]

        public virtual Service IdServiceOwnerNavigation { get; set; }
        [JsonIgnore]

        public virtual TypeDocument IdTypeDocumentNavigation { get; set; }
        [JsonIgnore]

        public virtual TypeMouvement IdTypeMouvementNavigation { get; set; }
        public virtual ICollection<OperationArticle> OperationArticles { get; set; }
    }
}
