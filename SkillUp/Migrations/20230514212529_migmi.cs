using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SkillUp.Migrations
{
    /// <inheritdoc />
    public partial class migmi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "candidats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "managers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "text", nullable: false),
                    mdp = table.Column<string>(type: "text", nullable: false),
                    nom = table.Column<string>(type: "text", nullable: false),
                    role = table.Column<int>(type: "integer", nullable: false),
                    prenom = table.Column<string>(type: "text", nullable: false),
                    dateNaissance = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    tel = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_managers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "trainingCenters",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nom = table.Column<string>(type: "text", nullable: false),
                    addresse = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    dateCreation = table.Column<string>(type: "text", nullable: false),
                    matriculeFiscale = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    rib = table.Column<long>(type: "bigint", nullable: false),
                    logo = table.Column<string>(type: "text", nullable: false),
                    tel = table.Column<int>(type: "integer", nullable: false),
                    etatDemandeInscription = table.Column<int>(type: "integer", nullable: false),
                    managerId = table.Column<int>(type: "integer", nullable: true),
                    TrainingCenterid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trainingCenters", x => x.id);
                    table.ForeignKey(
                        name: "FK_trainingCenters_managers_managerId",
                        column: x => x.managerId,
                        principalTable: "managers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_trainingCenters_trainingCenters_TrainingCenterid",
                        column: x => x.TrainingCenterid,
                        principalTable: "trainingCenters",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "trainings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    trainingCenterid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trainings_trainingCenters_trainingCenterid",
                        column: x => x.trainingCenterid,
                        principalTable: "trainingCenters",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "achats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    trainingId = table.Column<int>(type: "integer", nullable: true),
                    CandidatId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_achats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_achats_candidats_CandidatId",
                        column: x => x.CandidatId,
                        principalTable: "candidats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_achats_trainings_trainingId",
                        column: x => x.trainingId,
                        principalTable: "trainings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_achats_CandidatId",
                table: "achats",
                column: "CandidatId");

            migrationBuilder.CreateIndex(
                name: "IX_achats_trainingId",
                table: "achats",
                column: "trainingId");

            migrationBuilder.CreateIndex(
                name: "IX_trainingCenters_managerId",
                table: "trainingCenters",
                column: "managerId");

            migrationBuilder.CreateIndex(
                name: "IX_trainingCenters_TrainingCenterid",
                table: "trainingCenters",
                column: "TrainingCenterid");

            migrationBuilder.CreateIndex(
                name: "IX_trainings_trainingCenterid",
                table: "trainings",
                column: "trainingCenterid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "achats");

            migrationBuilder.DropTable(
                name: "candidats");

            migrationBuilder.DropTable(
                name: "trainings");

            migrationBuilder.DropTable(
                name: "trainingCenters");

            migrationBuilder.DropTable(
                name: "managers");
        }
    }
}
