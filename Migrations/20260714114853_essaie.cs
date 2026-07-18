using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlateE_learning.Migrations
{
    /// <inheritdoc />
    public partial class essaie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Utilisateurs",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "EnseignantId",
                table: "Cours",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiniatureUrl",
                table: "Cours",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Cours_EnseignantId",
                table: "Cours",
                column: "EnseignantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cours_Utilisateurs_EnseignantId",
                table: "Cours",
                column: "EnseignantId",
                principalTable: "Utilisateurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cours_Utilisateurs_EnseignantId",
                table: "Cours");

            migrationBuilder.DropIndex(
                name: "IX_Cours_EnseignantId",
                table: "Cours");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "EnseignantId",
                table: "Cours");

            migrationBuilder.DropColumn(
                name: "MiniatureUrl",
                table: "Cours");
        }
    }
}
