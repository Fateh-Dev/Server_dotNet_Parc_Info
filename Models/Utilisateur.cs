using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

#nullable disable

namespace GestionParcInformatique.Models
{
    public partial class Utilisateur:IdentityUser
    {
        public Utilisateur()
        {
            Articles = new HashSet<Article>();
            Categories = new HashSet<Categorie>();
            Couleurs = new HashSet<Couleur>();
            Documents = new HashSet<Document>();
            Etats = new HashSet<Etat>();
            Magasins = new HashSet<Magasin>();
            Marques = new HashSet<Marque>();
            ModeConsommations = new HashSet<ModeConsommation>();
            ModelArticles = new HashSet<ModelArticle>();
            OperationArticles = new HashSet<OperationArticle>();
            Personnes = new HashSet<Personne>();
            Services = new HashSet<Service>();
            TypeArticles = new HashSet<TypeArticle>();
            TypeDocuments = new HashSet<TypeDocument>();
            TypeMouvements = new HashSet<TypeMouvement>();
            UniteMesures = new HashSet<UniteMesure>();
        }

        // public Guid? Id { get; set; }
        public string Password { get; set; }
        public DateTime DateCreation { get; set; }
        public Guid? IdPersonne { get; set; }

        public virtual Personne IdPersonneNavigation { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Categorie> Categories { get; set; }
        public virtual ICollection<Couleur> Couleurs { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<Etat> Etats { get; set; }
        public virtual ICollection<Magasin> Magasins { get; set; }
        public virtual ICollection<Marque> Marques { get; set; }
        public virtual ICollection<ModeConsommation> ModeConsommations { get; set; }
        public virtual ICollection<ModelArticle> ModelArticles { get; set; }
        public virtual ICollection<OperationArticle> OperationArticles { get; set; }
        public virtual ICollection<Personne> Personnes { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<TypeArticle> TypeArticles { get; set; }
        public virtual ICollection<TypeDocument> TypeDocuments { get; set; }
        public virtual ICollection<TypeMouvement> TypeMouvements { get; set; }
        public virtual ICollection<UniteMesure> UniteMesures { get; set; }
    }
}
