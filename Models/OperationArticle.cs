using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using AutoMapper.Configuration.Annotations;

#nullable disable

namespace GestionParcInformatique.Models
{
    public partial class OperationArticle
    {
        public Guid Id { get; set; }
        public Guid? IdArticle { get; set; }
        public Guid? IdDocument { get; set; }
        public long? QteDemande { get; set; }
        public long? QteDistribue { get; set; }
        public string Observation { get; set; }
        public long NumOrdre { get; set; }
        public string IdOwner { get; set; }
        public DateTime DateCreation { get; set; }
        public long? QteRestante { get; set; } 
        public long? QteEntre { get; set; }
        public long? QteSupp { get; set; }
        [JsonIgnore]
        public virtual Article IdArticleNavigation { get; set; }
        [JsonIgnore]
        public virtual Document IdDocumentNavigation { get; set; }
        [JsonIgnore]
        public virtual Utilisateur IdOwnerNavigation { get; set; }
    }
}
