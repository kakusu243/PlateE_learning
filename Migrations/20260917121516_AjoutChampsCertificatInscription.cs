using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlateE_learning.Migrations
{
    /// <inheritdoc />
    public partial class AjoutChampsCertificatInscription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CertificatDelivre",
                table: "Inscriptions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CodeVerificationCertificat",
                table: "Inscriptions",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDelivranceCertificat",
                table: "Inscriptions",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EstEligibleCertificat",
                table: "Inscriptions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CertificatDelivre",
                table: "Inscriptions");

            migrationBuilder.DropColumn(
                name: "CodeVerificationCertificat",
                table: "Inscriptions");

            migrationBuilder.DropColumn(
                name: "DateDelivranceCertificat",
                table: "Inscriptions");

            migrationBuilder.DropColumn(
                name: "EstEligibleCertificat",
                table: "Inscriptions");
        }
    }
}
