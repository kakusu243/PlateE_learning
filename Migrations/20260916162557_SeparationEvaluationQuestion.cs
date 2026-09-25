using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Pomelo.EntityFrameworkCore.MySql.Metadata;

#nullable disable

namespace PlateE_learning.Migrations
{
    /// <inheritdoc />
    public partial class SeparationEvaluationQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Création de la nouvelle table Questions
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Enonce = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OptionA = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OptionB = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OptionC = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OptionD = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReponseCorrecte = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Points = table.Column<int>(type: "int", nullable: false),
                    EvaluationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Evaluations_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "Evaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_EvaluationId",
                table: "Questions",
                column: "EvaluationId");

            // 2. Copie sécurisée des données existantes
            migrationBuilder.Sql(@"
                INSERT INTO Questions (Enonce, OptionA, OptionB, OptionC, OptionD, ReponseCorrecte, Points, EvaluationId)
                SELECT 
                    COALESCE(NULLIF(QuestionText, ''), 'Question sans titre') AS Enonce,
                    COALESCE(OptionA, '') AS OptionA,
                    COALESCE(OptionB, '') AS OptionB,
                    COALESCE(OptionC, '') AS OptionC,
                    COALESCE(OptionD, '') AS OptionD,
                    COALESCE(ReponseCorrecte, 'A') AS ReponseCorrecte,
                    1 AS Points,
                    Id AS EvaluationId
                FROM Evaluations
                WHERE QuestionText IS NOT NULL AND QuestionText <> '';
            ");

            // 3. Suppression des anciennes colonnes
            migrationBuilder.DropColumn(name: "OptionA", table: "Evaluations");
            migrationBuilder.DropColumn(name: "OptionB", table: "Evaluations");
            migrationBuilder.DropColumn(name: "OptionC", table: "Evaluations");
            migrationBuilder.DropColumn(name: "OptionD", table: "Evaluations");
            migrationBuilder.DropColumn(name: "QuestionText", table: "Evaluations");
            migrationBuilder.DropColumn(name: "Questions", table: "Evaluations");
            migrationBuilder.DropColumn(name: "ReponseCorrecte", table: "Evaluations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Questions");

            migrationBuilder.AddColumn<string>(name: "OptionA", table: "Evaluations", type: "longtext", nullable: false).Annotation("MySql:CharSet", "utf8mb4");
            migrationBuilder.AddColumn<string>(name: "OptionB", table: "Evaluations", type: "longtext", nullable: false).Annotation("MySql:CharSet", "utf8mb4");
            migrationBuilder.AddColumn<string>(name: "OptionC", table: "Evaluations", type: "longtext", nullable: false).Annotation("MySql:CharSet", "utf8mb4");
            migrationBuilder.AddColumn<string>(name: "OptionD", table: "Evaluations", type: "longtext", nullable: false).Annotation("MySql:CharSet", "utf8mb4");
            migrationBuilder.AddColumn<string>(name: "QuestionText", table: "Evaluations", type: "longtext", nullable: false).Annotation("MySql:CharSet", "utf8mb4");
            migrationBuilder.AddColumn<string>(name: "Questions", table: "Evaluations", type: "longtext", nullable: false).Annotation("MySql:CharSet", "utf8mb4");
            migrationBuilder.AddColumn<string>(name: "ReponseCorrecte", table: "Evaluations", type: "longtext", nullable: false).Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}