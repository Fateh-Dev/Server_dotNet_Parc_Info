using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionParcInformatique.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperationArticle",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdArticle = table.Column<Guid>(type: "TEXT", nullable: true),
                    IdDocument = table.Column<Guid>(type: "TEXT", nullable: true),
                    QteDemande = table.Column<long>(type: "INTEGER", nullable: true),
                    QteDistribue = table.Column<long>(type: "INTEGER", nullable: true),
                    Observation = table.Column<string>(type: "TEXT", nullable: true),
                    NumOrdre = table.Column<long>(type: "INTEGER", nullable: false),
                    IdOwner = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    QteRestante = table.Column<long>(type: "INTEGER", nullable: true),
                    QteEntre = table.Column<long>(type: "INTEGER", nullable: true),
                    QteSupp = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationArticle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NumSerie = table.Column<string>(type: "TEXT", nullable: true),
                    NumRef = table.Column<string>(type: "TEXT", nullable: true),
                    NumKit = table.Column<long>(type: "INTEGER", nullable: false),
                    QteSeuil = table.Column<long>(type: "INTEGER(4)", nullable: true),
                    AnneExpiration = table.Column<long>(type: "INTEGER(4)", nullable: true),
                    QteGlobaleEntre = table.Column<long>(type: "INTEGER", nullable: true),
                    Observation = table.Column<string>(type: "TEXT(100)", nullable: true),
                    IdTypeArticle = table.Column<Guid>(type: "TEXT", nullable: true),
                    IdMarque = table.Column<Guid>(type: "TEXT", nullable: true),
                    IdModelArticle = table.Column<Guid>(type: "TEXT", nullable: true),
                    IdCategorie = table.Column<Guid>(type: "TEXT", nullable: true),
                    IdCouleur = table.Column<Guid>(type: "TEXT", nullable: true),
                    IdUniteMesure = table.Column<Guid>(type: "TEXT", nullable: true),
                    IdEtat = table.Column<Guid>(type: "TEXT", nullable: true),
                    IdModeConsommation = table.Column<Guid>(type: "TEXT", nullable: true),
                    NumOrdre = table.Column<long>(type: "INTEGER", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdOwner = table.Column<string>(type: "TEXT", nullable: true),
                    PrixUnitaire = table.Column<long>(type: "INTEGER", nullable: true),
                    DateReception = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RefDocument = table.Column<string>(type: "TEXT", nullable: false),
                    Observation = table.Column<string>(type: "TEXT", nullable: true),
                    DateDocument = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateValidation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdPersonneSigne = table.Column<Guid>(type: "TEXT", nullable: true),
                    IdPersonneUse = table.Column<Guid>(type: "TEXT", nullable: true),
                    IdTypeDocument = table.Column<Guid>(type: "TEXT", nullable: true),
                    IdTypeMouvement = table.Column<Guid>(type: "TEXT", nullable: true),
                    IdServiceOwner = table.Column<Guid>(type: "TEXT", nullable: true),
                    IdServiceDest = table.Column<Guid>(type: "TEXT", nullable: true),
                    IdOldService = table.Column<Guid>(type: "TEXT", nullable: true),
                    NumOrdre = table.Column<long>(type: "INTEGER", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdOwner = table.Column<string>(type: "TEXT", nullable: true),
                    IdMagasin = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateur",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdPersonne = table.Column<Guid>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Utilisateur_UserId",
                        column: x => x.UserId,
                        principalTable: "Utilisateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Utilisateur_UserId",
                        column: x => x.UserId,
                        principalTable: "Utilisateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Utilisateur_UserId",
                        column: x => x.UserId,
                        principalTable: "Utilisateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DesignationFr = table.Column<string>(type: "TEXT", nullable: true),
                    DesignationAr = table.Column<string>(type: "TEXT", nullable: true),
                    NumOrdre = table.Column<long>(type: "INTEGER", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdOwner = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categorie_Utilisateur_IdOwner",
                        column: x => x.IdOwner,
                        principalTable: "Utilisateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Couleur",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DesignationFr = table.Column<string>(type: "TEXT", nullable: true),
                    DesignationAr = table.Column<string>(type: "TEXT", nullable: true),
                    NumOrdre = table.Column<long>(type: "INTEGER", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdOwner = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Couleur", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Couleur_Utilisateur_IdOwner",
                        column: x => x.IdOwner,
                        principalTable: "Utilisateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Etat",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DesignationFr = table.Column<string>(type: "TEXT", nullable: true),
                    DesignationAr = table.Column<string>(type: "TEXT", nullable: true),
                    NumOrdre = table.Column<long>(type: "INTEGER", nullable: false),
                    DateCreation = table.Column<string>(type: "TEXT", nullable: true),
                    IdOwner = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Etat_Utilisateur_IdOwner",
                        column: x => x.IdOwner,
                        principalTable: "Utilisateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Magasin",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DesignationFr = table.Column<string>(type: "TEXT", nullable: true),
                    DesignationAr = table.Column<string>(type: "TEXT", nullable: true),
                    NumOrdre = table.Column<long>(type: "INTEGER", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdOwner = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magasin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Magasin_Utilisateur_IdOwner",
                        column: x => x.IdOwner,
                        principalTable: "Utilisateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Marque",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DesignationFr = table.Column<string>(type: "TEXT", nullable: true),
                    DesignationAr = table.Column<string>(type: "TEXT", nullable: true),
                    NumOrdre = table.Column<long>(type: "INTEGER", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdOwner = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Marque_Utilisateur_IdOwner",
                        column: x => x.IdOwner,
                        principalTable: "Utilisateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ModeConsommation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DesignationFr = table.Column<string>(type: "TEXT", nullable: true),
                    DesignationAr = table.Column<string>(type: "TEXT", nullable: true),
                    NumOrdre = table.Column<long>(type: "INTEGER", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdOwner = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeConsommation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModeConsommation_Utilisateur_IdOwner",
                        column: x => x.IdOwner,
                        principalTable: "Utilisateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ModelArticle",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DesignationFr = table.Column<string>(type: "TEXT", nullable: true),
                    DesignationAr = table.Column<string>(type: "TEXT", nullable: true),
                    NumOrdre = table.Column<long>(type: "INTEGER", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdOwner = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelArticle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelArticle_Utilisateur_IdOwner",
                        column: x => x.IdOwner,
                        principalTable: "Utilisateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DesignationFr = table.Column<string>(type: "TEXT", nullable: true),
                    DesignationAr = table.Column<string>(type: "TEXT", nullable: true),
                    NumOrdre = table.Column<long>(type: "INTEGER", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdOwner = table.Column<string>(type: "TEXT", nullable: true),
                    Abreviation = table.Column<string>(type: "TEXT", nullable: true),
                    IdServiceParent = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Service_Service_IdServiceParent",
                        column: x => x.IdServiceParent,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Service_Utilisateur_IdOwner",
                        column: x => x.IdOwner,
                        principalTable: "Utilisateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TypeArticle",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DesignationFr = table.Column<string>(type: "TEXT", nullable: true),
                    DesignationAr = table.Column<string>(type: "TEXT", nullable: true),
                    NumOrdre = table.Column<long>(type: "INTEGER", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdOwner = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeArticle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeArticle_Utilisateur_IdOwner",
                        column: x => x.IdOwner,
                        principalTable: "Utilisateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TypeDocument",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DesignationFr = table.Column<string>(type: "TEXT", nullable: true),
                    DesignationAr = table.Column<string>(type: "TEXT", nullable: true),
                    NumOrdre = table.Column<long>(type: "INTEGER", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdOwner = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeDocument_Utilisateur_IdOwner",
                        column: x => x.IdOwner,
                        principalTable: "Utilisateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TypeMouvement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DesignationFr = table.Column<string>(type: "TEXT", nullable: true),
                    DesignationAr = table.Column<string>(type: "TEXT", nullable: true),
                    NumOrdre = table.Column<long>(type: "INTEGER", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdOwner = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeMouvement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeMouvement_Utilisateur_IdOwner",
                        column: x => x.IdOwner,
                        principalTable: "Utilisateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UniteMesure",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DesignationFr = table.Column<string>(type: "TEXT", nullable: true),
                    DesignationAr = table.Column<string>(type: "TEXT", nullable: true),
                    NumOrdre = table.Column<long>(type: "INTEGER", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdOwner = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniteMesure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UniteMesure_Utilisateur_IdOwner",
                        column: x => x.IdOwner,
                        principalTable: "Utilisateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Personne",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nom = table.Column<string>(type: "TEXT", nullable: true),
                    Prenom = table.Column<string>(type: "TEXT", nullable: true),
                    Matricule = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<long>(type: "INTEGER", nullable: true),
                    Taille = table.Column<long>(type: "INTEGER", nullable: true),
                    IdService = table.Column<Guid>(type: "TEXT", nullable: true),
                    IdOwner = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NumOrdre = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personne", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personne_Service_IdService",
                        column: x => x.IdService,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personne_Utilisateur_IdOwner",
                        column: x => x.IdOwner,
                        principalTable: "Utilisateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_Id_NumSerie_NumRef ",
                table: "Article",
                columns: new[] { "Id", "NumSerie", "NumRef" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Article_IdCategorie",
                table: "Article",
                column: "IdCategorie");

            migrationBuilder.CreateIndex(
                name: "IX_Article_IdCouleur",
                table: "Article",
                column: "IdCouleur");

            migrationBuilder.CreateIndex(
                name: "IX_Article_IdEtat",
                table: "Article",
                column: "IdEtat");

            migrationBuilder.CreateIndex(
                name: "IX_Article_IdMarque",
                table: "Article",
                column: "IdMarque");

            migrationBuilder.CreateIndex(
                name: "IX_Article_IdModeConsommation",
                table: "Article",
                column: "IdModeConsommation");

            migrationBuilder.CreateIndex(
                name: "IX_Article_IdModelArticle",
                table: "Article",
                column: "IdModelArticle");

            migrationBuilder.CreateIndex(
                name: "IX_Article_IdOwner",
                table: "Article",
                column: "IdOwner");

            migrationBuilder.CreateIndex(
                name: "IX_Article_IdTypeArticle",
                table: "Article",
                column: "IdTypeArticle");

            migrationBuilder.CreateIndex(
                name: "IX_Article_IdUniteMesure",
                table: "Article",
                column: "IdUniteMesure");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Categorie_IdOwner",
                table: "Categorie",
                column: "IdOwner");

            migrationBuilder.CreateIndex(
                name: "IX_Couleur_IdOwner",
                table: "Couleur",
                column: "IdOwner");

            migrationBuilder.CreateIndex(
                name: "IX_Document_IdMagasin",
                table: "Document",
                column: "IdMagasin");

            migrationBuilder.CreateIndex(
                name: "IX_Document_IdOldService",
                table: "Document",
                column: "IdOldService");

            migrationBuilder.CreateIndex(
                name: "IX_Document_IdOwner",
                table: "Document",
                column: "IdOwner");

            migrationBuilder.CreateIndex(
                name: "IX_Document_IdPersonneSigne",
                table: "Document",
                column: "IdPersonneSigne");

            migrationBuilder.CreateIndex(
                name: "IX_Document_IdPersonneUse",
                table: "Document",
                column: "IdPersonneUse");

            migrationBuilder.CreateIndex(
                name: "IX_Document_IdServiceDest",
                table: "Document",
                column: "IdServiceDest");

            migrationBuilder.CreateIndex(
                name: "IX_Document_IdServiceOwner",
                table: "Document",
                column: "IdServiceOwner");

            migrationBuilder.CreateIndex(
                name: "IX_Document_IdTypeDocument",
                table: "Document",
                column: "IdTypeDocument");

            migrationBuilder.CreateIndex(
                name: "IX_Document_IdTypeMouvement",
                table: "Document",
                column: "IdTypeMouvement");

            migrationBuilder.CreateIndex(
                name: "IX_Etat_IdOwner",
                table: "Etat",
                column: "IdOwner");

            migrationBuilder.CreateIndex(
                name: "IX_Magasin_IdOwner",
                table: "Magasin",
                column: "IdOwner");

            migrationBuilder.CreateIndex(
                name: "IX_Marque_IdOwner",
                table: "Marque",
                column: "IdOwner");

            migrationBuilder.CreateIndex(
                name: "IX_ModeConsommation_IdOwner",
                table: "ModeConsommation",
                column: "IdOwner");

            migrationBuilder.CreateIndex(
                name: "IX_ModelArticle_IdOwner",
                table: "ModelArticle",
                column: "IdOwner");

            migrationBuilder.CreateIndex(
                name: "IX_OperationArticle_IdArticle",
                table: "OperationArticle",
                column: "IdArticle");

            migrationBuilder.CreateIndex(
                name: "IX_OperationArticle_IdDocument",
                table: "OperationArticle",
                column: "IdDocument");

            migrationBuilder.CreateIndex(
                name: "IX_OperationArticle_IdOwner",
                table: "OperationArticle",
                column: "IdOwner");

            migrationBuilder.CreateIndex(
                name: "IX_Personne_IdOwner",
                table: "Personne",
                column: "IdOwner");

            migrationBuilder.CreateIndex(
                name: "IX_Personne_IdService",
                table: "Personne",
                column: "IdService");

            migrationBuilder.CreateIndex(
                name: "IX_Service_IdOwner",
                table: "Service",
                column: "IdOwner");

            migrationBuilder.CreateIndex(
                name: "IX_Service_IdServiceParent",
                table: "Service",
                column: "IdServiceParent");

            migrationBuilder.CreateIndex(
                name: "IX_TypeArticle_IdOwner",
                table: "TypeArticle",
                column: "IdOwner");

            migrationBuilder.CreateIndex(
                name: "IX_TypeDocument_IdOwner",
                table: "TypeDocument",
                column: "IdOwner");

            migrationBuilder.CreateIndex(
                name: "IX_TypeMouvement_IdOwner",
                table: "TypeMouvement",
                column: "IdOwner");

            migrationBuilder.CreateIndex(
                name: "IX_UniteMesure_IdOwner",
                table: "UniteMesure",
                column: "IdOwner");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Utilisateur",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateur_IdPersonne",
                table: "Utilisateur",
                column: "IdPersonne");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Utilisateur",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OperationArticle_Article_IdArticle",
                table: "OperationArticle",
                column: "IdArticle",
                principalTable: "Article",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OperationArticle_Document_IdDocument",
                table: "OperationArticle",
                column: "IdDocument",
                principalTable: "Document",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OperationArticle_Utilisateur_IdOwner",
                table: "OperationArticle",
                column: "IdOwner",
                principalTable: "Utilisateur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_Utilisateur_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "Utilisateur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Categorie_IdCategorie",
                table: "Article",
                column: "IdCategorie",
                principalTable: "Categorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Couleur_IdCouleur",
                table: "Article",
                column: "IdCouleur",
                principalTable: "Couleur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Etat_IdEtat",
                table: "Article",
                column: "IdEtat",
                principalTable: "Etat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Marque_IdMarque",
                table: "Article",
                column: "IdMarque",
                principalTable: "Marque",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Article_ModeConsommation_IdModeConsommation",
                table: "Article",
                column: "IdModeConsommation",
                principalTable: "ModeConsommation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Article_ModelArticle_IdModelArticle",
                table: "Article",
                column: "IdModelArticle",
                principalTable: "ModelArticle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Article_TypeArticle_IdTypeArticle",
                table: "Article",
                column: "IdTypeArticle",
                principalTable: "TypeArticle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Article_UniteMesure_IdUniteMesure",
                table: "Article",
                column: "IdUniteMesure",
                principalTable: "UniteMesure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Utilisateur_IdOwner",
                table: "Article",
                column: "IdOwner",
                principalTable: "Utilisateur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Magasin_IdMagasin",
                table: "Document",
                column: "IdMagasin",
                principalTable: "Magasin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Personne_IdPersonneSigne",
                table: "Document",
                column: "IdPersonneSigne",
                principalTable: "Personne",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Personne_IdPersonneUse",
                table: "Document",
                column: "IdPersonneUse",
                principalTable: "Personne",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Service_IdOldService",
                table: "Document",
                column: "IdOldService",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Service_IdServiceDest",
                table: "Document",
                column: "IdServiceDest",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Service_IdServiceOwner",
                table: "Document",
                column: "IdServiceOwner",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Document_TypeDocument_IdTypeDocument",
                table: "Document",
                column: "IdTypeDocument",
                principalTable: "TypeDocument",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Document_TypeMouvement_IdTypeMouvement",
                table: "Document",
                column: "IdTypeMouvement",
                principalTable: "TypeMouvement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Utilisateur_IdOwner",
                table: "Document",
                column: "IdOwner",
                principalTable: "Utilisateur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Utilisateur_Personne_IdPersonne",
                table: "Utilisateur",
                column: "IdPersonne",
                principalTable: "Personne",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personne_Utilisateur_IdOwner",
                table: "Personne");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_Utilisateur_IdOwner",
                table: "Service");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OperationArticle");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropTable(
                name: "Couleur");

            migrationBuilder.DropTable(
                name: "Etat");

            migrationBuilder.DropTable(
                name: "Marque");

            migrationBuilder.DropTable(
                name: "ModeConsommation");

            migrationBuilder.DropTable(
                name: "ModelArticle");

            migrationBuilder.DropTable(
                name: "TypeArticle");

            migrationBuilder.DropTable(
                name: "UniteMesure");

            migrationBuilder.DropTable(
                name: "Magasin");

            migrationBuilder.DropTable(
                name: "TypeDocument");

            migrationBuilder.DropTable(
                name: "TypeMouvement");

            migrationBuilder.DropTable(
                name: "Utilisateur");

            migrationBuilder.DropTable(
                name: "Personne");

            migrationBuilder.DropTable(
                name: "Service");
        }
    }
}
