using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestion_dossier_patient.Migrations
{
    /// <inheritdoc />
    public partial class initDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dossier_patient",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sexe = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Tel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Adresse = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Date_Enregistrement = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dossier_patient", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "medecin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sexe = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Tel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Adresse = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Specialite = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medecin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "consultation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    medecinId = table.Column<int>(type: "int", nullable: true),
                    patientCode = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Poids = table.Column<double>(type: "float", nullable: true),
                    Hauteur = table.Column<double>(type: "float", nullable: true),
                    Diagnostique = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date_Consultation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_consultation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_consultation_dossier_patient_patientCode",
                        column: x => x.patientCode,
                        principalTable: "dossier_patient",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_consultation_medecin_medecinId",
                        column: x => x.medecinId,
                        principalTable: "medecin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "prescription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    consultationId = table.Column<int>(type: "int", nullable: true),
                    Prescription_Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_prescription_consultation_consultationId",
                        column: x => x.consultationId,
                        principalTable: "consultation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_consultation_medecinId",
                table: "consultation",
                column: "medecinId");

            migrationBuilder.CreateIndex(
                name: "IX_consultation_patientCode",
                table: "consultation",
                column: "patientCode");

            migrationBuilder.CreateIndex(
                name: "IX_prescription_consultationId",
                table: "prescription",
                column: "consultationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "prescription");

            migrationBuilder.DropTable(
                name: "consultation");

            migrationBuilder.DropTable(
                name: "dossier_patient");

            migrationBuilder.DropTable(
                name: "medecin");
        }
    }
}
