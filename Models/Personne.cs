using System;
using System.Collections.Generic;

#nullable disable

namespace GestionParcInformatique.Models
{
    public partial class Personne
    {
        public Personne()
        {
            DocumentIdPersonneSigneNavigations = new HashSet<Document>();
            DocumentIdPersonneUseNavigations = new HashSet<Document>();
            Utilisateurs = new HashSet<Utilisateur>();
        }

        public Guid? Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Matricule { get; set; }
        public long? Age { get; set; }
        public long? Taille { get; set; }
        public Guid? IdService { get; set; }
        public string IdOwner { get; set; }
        public DateTime DateCreation { get; set; }
        public long NumOrdre { get; set; }

        public virtual Utilisateur IdOwnerNavigation { get; set; }
        public virtual Service IdServiceNavigation { get; set; }
        public virtual ICollection<Document> DocumentIdPersonneSigneNavigations { get; set; }
        public virtual ICollection<Document> DocumentIdPersonneUseNavigations { get; set; }
        public virtual ICollection<Utilisateur> Utilisateurs { get; set; }
    }
}
