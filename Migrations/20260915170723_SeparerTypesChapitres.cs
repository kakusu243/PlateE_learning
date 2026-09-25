using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlateE_learning.Migrations
{
    /// <inheritdoc />
    public partial class SeparerTypesChapitres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // ❌ Commenté car la colonne "Contenu" a déjà été supprimée en BDD lors de l'essai précédent
            // migrationBuilder.DropColumn(
            //     name: "Contenu",
            //     table: "Chapitres");

            migrationBuilder.RenameColumn(
                name: "VideoUrl",
                table: "Chapitres",
                newName: "ContenuHtml");

            migrationBuilder.AddColumn<string>(
                name: "CheminFichierVideo",
                table: "Chapitres",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "DureeEnSecondes",
                table: "Chapitres",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeChapitre",
                table: "Chapitres",
                type: "varchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheminFichierVideo",
                table: "Chapitres");

            migrationBuilder.DropColumn(
                name: "DureeEnSecondes",
                table: "Chapitres");

            migrationBuilder.DropColumn(
                name: "TypeChapitre",
                table: "Chapitres");

            migrationBuilder.RenameColumn(
                name: "ContenuHtml",
                table: "Chapitres",
                newName: "VideoUrl");

            // ❌ Commenté pour correspondre à l'état de la méthode Up
            // migrationBuilder.AddColumn<string>(
            //     name: "Contenu",
            //     table: "Chapitres",
            //     type: "longtext",
            //     nullable: false)
            //     .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}