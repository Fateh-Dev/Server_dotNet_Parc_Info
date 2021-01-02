using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GestionParcInformatique.Models;
using GestionParcInformatique.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
#nullable disable

namespace GestionParcInformatique.Data
{
    public partial class GParcInfoContext : IdentityDbContext<Utilisateur>
    {
        public GParcInfoContext()
        {
        }

        public GParcInfoContext(DbContextOptions<GParcInfoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Categorie> Categories { get; set; }
        public virtual DbSet<Couleur> Couleurs { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Etat> Etats { get; set; }
        public virtual DbSet<Magasin> Magasins { get; set; }
        public virtual DbSet<Marque> Marques { get; set; }
        public virtual DbSet<ModeConsommation> ModeConsommations { get; set; }
        public virtual DbSet<ModelArticle> ModelArticles { get; set; }
        public virtual DbSet<OperationArticle> OperationArticles { get; set; }
        public virtual DbSet<Personne> Personnes { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<TypeArticle> TypeArticles { get; set; }
        public virtual DbSet<TypeDocument> TypeDocuments { get; set; }
        public virtual DbSet<TypeMouvement> TypeMouvements { get; set; }
        public virtual DbSet<UniteMesure> UniteMesures { get; set; }
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("DataSource=d:\\GestionParcInformatique\\GParcInfo.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("Article");

                entity.HasIndex(e => new { e.Id, e.NumSerie, e.NumRef }, "IX_Article_Id_NumSerie_NumRef ")
                    .IsUnique();

                entity.Property(e => e.AnneExpiration).HasColumnType("INTEGER(4)");

                entity.Property(e => e.Observation).HasColumnType("TEXT(100)");

                entity.Property(e => e.QteSeuil).HasColumnType("INTEGER(4)");

                entity.HasOne(d => d.IdCategorieNavigation)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.IdCategorie);

                entity.HasOne(d => d.IdCouleurNavigation)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.IdCouleur);

                entity.HasOne(d => d.IdEtatNavigation)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.IdEtat);

                entity.HasOne(d => d.IdMarqueNavigation)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.IdMarque);

                entity.HasOne(d => d.IdModeConsommationNavigation)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.IdModeConsommation);

                entity.HasOne(d => d.IdModelArticleNavigation)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.IdModelArticle);

                entity.HasOne(d => d.IdOwnerNavigation)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.IdOwner);

                entity.HasOne(d => d.IdTypeArticleNavigation)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.IdTypeArticle);

                entity.HasOne(d => d.IdUniteMesureNavigation)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.IdUniteMesure);
            });

            modelBuilder.Entity<Categorie>(entity =>
            {
                entity.ToTable("Categorie");
                entity.Property(e => e.NumOrdre).HasColumnType("INTEGER(10)").ValueGeneratedOnAdd();;

                entity.HasOne(d => d.IdOwnerNavigation)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.IdOwner);
            });

            modelBuilder.Entity<Couleur>(entity =>
            {
                entity.ToTable("Couleur");

                entity.HasOne(d => d.IdOwnerNavigation)
                    .WithMany(p => p.Couleurs)
                    .HasForeignKey(d => d.IdOwner);
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("Document");

                entity.Property(e => e.RefDocument).IsRequired();

                entity.HasOne(d => d.IdMagasinNavigation)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.IdMagasin);

                entity.HasOne(d => d.IdOldServiceNavigation)
                    .WithMany(p => p.DocumentIdOldServiceNavigations)
                    .HasForeignKey(d => d.IdOldService);

                entity.HasOne(d => d.IdOwnerNavigation)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.IdOwner);

                entity.HasOne(d => d.IdPersonneSigneNavigation)
                    .WithMany(p => p.DocumentIdPersonneSigneNavigations)
                    .HasForeignKey(d => d.IdPersonneSigne);

                entity.HasOne(d => d.IdPersonneUseNavigation)
                    .WithMany(p => p.DocumentIdPersonneUseNavigations)
                    .HasForeignKey(d => d.IdPersonneUse);

                entity.HasOne(d => d.IdServiceDestNavigation)
                    .WithMany(p => p.DocumentIdServiceDestNavigations)
                    .HasForeignKey(d => d.IdServiceDest);

                entity.HasOne(d => d.IdServiceOwnerNavigation)
                    .WithMany(p => p.DocumentIdServiceOwnerNavigations)
                    .HasForeignKey(d => d.IdServiceOwner);

                entity.HasOne(d => d.IdTypeDocumentNavigation)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.IdTypeDocument);

                entity.HasOne(d => d.IdTypeMouvementNavigation)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.IdTypeMouvement);
            });

            modelBuilder.Entity<Etat>(entity =>
            {
                entity.ToTable("Etat");

                entity.HasOne(d => d.IdOwnerNavigation)
                    .WithMany(p => p.Etats)
                    .HasForeignKey(d => d.IdOwner);
            });

            modelBuilder.Entity<Magasin>(entity =>
            {
                entity.ToTable("Magasin");


                entity.HasOne(d => d.IdOwnerNavigation)
                    .WithMany(p => p.Magasins)
                    .HasForeignKey(d => d.IdOwner);
            });

            modelBuilder.Entity<Marque>(entity =>
            {
                entity.ToTable("Marque");

                entity.HasOne(d => d.IdOwnerNavigation)
                    .WithMany(p => p.Marques)
                    .HasForeignKey(d => d.IdOwner);
            });

            modelBuilder.Entity<ModeConsommation>(entity =>
            {
                entity.ToTable("ModeConsommation");


                entity.HasOne(d => d.IdOwnerNavigation)
                    .WithMany(p => p.ModeConsommations)
                    .HasForeignKey(d => d.IdOwner);
            });

            modelBuilder.Entity<ModelArticle>(entity =>
            {
                entity.ToTable("ModelArticle");

                entity.HasOne(d => d.IdOwnerNavigation)
                    .WithMany(p => p.ModelArticles)
                    .HasForeignKey(d => d.IdOwner);
            });

            modelBuilder.Entity<OperationArticle>(entity =>
            {
                entity.ToTable("OperationArticle");

                entity.HasOne(d => d.IdArticleNavigation)
                    .WithMany(p => p.OperationArticles)
                    .HasForeignKey(d => d.IdArticle);

                entity.HasOne(d => d.IdDocumentNavigation)
                    .WithMany(p => p.OperationArticles)
                    .HasForeignKey(d => d.IdDocument);

                entity.HasOne(d => d.IdOwnerNavigation)
                    .WithMany(p => p.OperationArticles)
                    .HasForeignKey(d => d.IdOwner);
            });

            modelBuilder.Entity<Personne>(entity =>
            {
                entity.ToTable("Personne");

                entity.HasOne(d => d.IdOwnerNavigation)
                    .WithMany(p => p.Personnes)
                    .HasForeignKey(d => d.IdOwner);

                entity.HasOne(d => d.IdServiceNavigation)
                    .WithMany(p => p.Personnes)
                    .HasForeignKey(d => d.IdService);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.HasOne(d => d.IdOwnerNavigation)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.IdOwner);

                entity.HasOne(d => d.IdServiceParentNavigation)
                    .WithMany(p => p.InverseIdServiceParentNavigation)
                    .HasForeignKey(d => d.IdServiceParent);
            });

            modelBuilder.Entity<TypeArticle>(entity =>
            {
                entity.ToTable("TypeArticle");

                entity.HasOne(d => d.IdOwnerNavigation)
                    .WithMany(p => p.TypeArticles)
                    .HasForeignKey(d => d.IdOwner);
            });

            modelBuilder.Entity<TypeDocument>(entity =>
            {
                entity.ToTable("TypeDocument");

                entity.HasOne(d => d.IdOwnerNavigation)
                    .WithMany(p => p.TypeDocuments)
                    .HasForeignKey(d => d.IdOwner);
            });

            modelBuilder.Entity<TypeMouvement>(entity =>
            {
                entity.ToTable("TypeMouvement");

                entity.HasOne(d => d.IdOwnerNavigation)
                    .WithMany(p => p.TypeMouvements)
                    .HasForeignKey(d => d.IdOwner);
            });

            modelBuilder.Entity<UniteMesure>(entity =>
            {
                entity.ToTable("UniteMesure");

                entity.HasOne(d => d.IdOwnerNavigation)
                    .WithMany(p => p.UniteMesures)
                    .HasForeignKey(d => d.IdOwner);
            });

            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.ToTable("Utilisateur");

                entity.HasOne(d => d.IdPersonneNavigation)
                    .WithMany(p => p.Utilisateurs)
                    .HasForeignKey(d => d.IdPersonne);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
