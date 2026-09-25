using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlateE_learning.Migrations
{
    /// <inheritdoc />
    public partial class SupportChapitresHerites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Supprimer la clé étrangère qui bloque l'index
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Chapitres_ChapitreId",
                table: "Evaluations");

            // 2. Supprimer l'ancien index
            migrationBuilder.DropIndex(
                name: "IX_Evaluations_ChapitreId",
                table: "Evaluations");

            // 3. Ajouter la colonne Titre à Evaluations
            migrationBuilder.AddColumn<string>(
                name: "Titre",
                table: "Evaluations",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            // 4. Créer le nouvel index unique
            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_ChapitreId",
                table: "Evaluations",
                column: "ChapitreId",
                unique: true);

            // 5. Remettre la clé étrangère
            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Chapitres_ChapitreId",
                table: "Evaluations",
                column: "ChapitreId",
                principalTable: "Chapitres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Chapitres_ChapitreId",
                table: "Evaluations");

            migrationBuilder.DropIndex(
                name: "IX_Evaluations_ChapitreId",
                table: "Evaluations");

            migrationBuilder.DropColumn(
                name: "Titre",
                table: "Evaluations");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_ChapitreId",
                table: "Evaluations",
                column: "ChapitreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Chapitres_ChapitreId",
                table: "Evaluations",
                column: "ChapitreId",
                principalTable: "Chapitres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}