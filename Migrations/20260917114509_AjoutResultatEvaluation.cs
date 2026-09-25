using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlateE_learning.Migrations
{
    /// <inheritdoc />
    public partial class AjoutResultatEvaluation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResultatEvaluations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApprenantId = table.Column<int>(type: "int", nullable: false),
                    EvaluationId = table.Column<int>(type: "int", nullable: false),
                    PointsObtenus = table.Column<int>(type: "int", nullable: false),
                    PointsMax = table.Column<int>(type: "int", nullable: false),
                    EstReussi = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DateTentative = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultatEvaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultatEvaluations_Evaluations_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "Evaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResultatEvaluations_Utilisateurs_ApprenantId",
                        column: x => x.ApprenantId,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ResultatEvaluations_ApprenantId",
                table: "ResultatEvaluations",
                column: "ApprenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultatEvaluations_EvaluationId",
                table: "ResultatEvaluations",
                column: "EvaluationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResultatEvaluations");
        }
    }
}
