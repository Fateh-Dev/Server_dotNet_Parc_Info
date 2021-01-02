using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionParcInformatique.Migrations
{
    public partial class newerr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "NumOrdre",
                table: "Categorie",
                type: "INTEGER(10)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "NumOrdre",
                table: "Categorie",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER(10)");
        }
    }
}
