using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using AutoMapper.Configuration.Annotations;

#nullable disable

namespace GestionParcInformatique.Models
{
    public partial class Etat
    {
        public Etat()
        {
            Articles = new HashSet<Article>();
        }

        public Guid Id { get; set; }
        public string DesignationFr { get; set; }
        public string DesignationAr { get; set; }
        public long NumOrdre { get; set; }
        public DateTime DateCreation { get; set; }
        public string IdOwner { get; set; }
        
        public virtual Utilisateur IdOwnerNavigation { get; set; }
        
        public virtual ICollection<Article> Articles { get; set; }
    }
}
