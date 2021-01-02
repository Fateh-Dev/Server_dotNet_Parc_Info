using System;
using System.Collections.Generic;

#nullable disable

namespace GestionParcInformatique.Models
{
    public partial class TypeMouvement
    {
        public TypeMouvement()
        {
            Documents = new HashSet<Document>();
        }

        public Guid? Id { get; set; }
        public string DesignationFr { get; set; }
        public string DesignationAr { get; set; }
        public long NumOrdre { get; set; }
        public DateTime DateCreation { get; set; }
        public string IdOwner { get; set; }

        public virtual Utilisateur IdOwnerNavigation { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }
}
