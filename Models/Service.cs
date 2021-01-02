using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace GestionParcInformatique.Models
{
    public partial class Service
    {
        public Service()
        {
            DocumentIdOldServiceNavigations = new HashSet<Document>();
            DocumentIdServiceDestNavigations = new HashSet<Document>();
            DocumentIdServiceOwnerNavigations = new HashSet<Document>();
            InverseIdServiceParentNavigation = new HashSet<Service>();
            Personnes = new HashSet<Personne>();
        }

        public Guid? Id { get; set; }
        public string DesignationFr { get; set; }
        public string DesignationAr { get; set; }
        public long NumOrdre { get; set; }
        public DateTime DateCreation { get; set; }
        public string IdOwner { get; set; }
        public string Abreviation { get; set; }
        public Guid? IdServiceParent { get; set; }
        [JsonIgnore]
        public virtual Utilisateur IdOwnerNavigation { get; set; }
        [JsonIgnore]
        public virtual Service IdServiceParentNavigation { get; set; }
        public virtual ICollection<Document> DocumentIdOldServiceNavigations { get; set; }
        public virtual ICollection<Document> DocumentIdServiceDestNavigations { get; set; }
        public virtual ICollection<Document> DocumentIdServiceOwnerNavigations { get; set; }
        public virtual ICollection<Service> InverseIdServiceParentNavigation { get; set; }
        public virtual ICollection<Personne> Personnes { get; set; }
    }
}
