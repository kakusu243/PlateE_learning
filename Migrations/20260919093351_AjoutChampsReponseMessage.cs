using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlateE_learning.Migrations
{
    /// <inheritdoc />
    public partial class AjoutChampsReponseMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MessageReponduAuteur",
                table: "MessagesForum",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "MessageReponduContenu",
                table: "MessagesForum",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessageReponduAuteur",
                table: "MessagesForum");

            migrationBuilder.DropColumn(
                name: "MessageReponduContenu",
                table: "MessagesForum");
        }
    }
}
