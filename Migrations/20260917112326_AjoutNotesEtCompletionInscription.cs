using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlateE_learning.Migrations
{
    /// <inheritdoc />
    public partial class AjoutNotesEtCompletionInscription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCompletion",
                table: "Inscriptions",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "NoteFinale",
                table: "Inscriptions",
                type: "double",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCompletion",
                table: "Inscriptions");

            migrationBuilder.DropColumn(
                name: "NoteFinale",
                table: "Inscriptions");
        }
    }
}
