using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SkillUp.Migrations
{
    /// <inheritdoc />
    public partial class nmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "trainingcenterId",
                table: "trainings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "trainingCenters",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "mdp",
                table: "trainingCenters",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Candidat",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nom = table.Column<string>(type: "text", nullable: false),
                    prenom = table.Column<string>(type: "text", nullable: false),
                    dateNaissance = table.Column<string>(type: "text", nullable: false),
                    tel = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    fonction = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CandidatTraining",
                columns: table => new
                {
                    candidatsId = table.Column<long>(type: "bigint", nullable: false),
                    trainingsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatTraining", x => new { x.candidatsId, x.trainingsId });
                    table.ForeignKey(
                        name: "FK_CandidatTraining_Candidat_candidatsId",
                        column: x => x.candidatsId,
                        principalTable: "Candidat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatTraining_trainings_trainingsId",
                        column: x => x.trainingsId,
                        principalTable: "trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_trainings_trainingcenterId",
                table: "trainings",
                column: "trainingcenterId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatTraining_trainingsId",
                table: "CandidatTraining",
                column: "trainingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_trainings_trainingCenters_trainingcenterId",
                table: "trainings",
                column: "trainingcenterId",
                principalTable: "trainingCenters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trainings_trainingCenters_trainingcenterId",
                table: "trainings");

            migrationBuilder.DropTable(
                name: "CandidatTraining");

            migrationBuilder.DropTable(
                name: "Candidat");

            migrationBuilder.DropIndex(
                name: "IX_trainings_trainingcenterId",
                table: "trainings");

            migrationBuilder.DropColumn(
                name: "trainingcenterId",
                table: "trainings");

            migrationBuilder.DropColumn(
                name: "email",
                table: "trainingCenters");

            migrationBuilder.DropColumn(
                name: "mdp",
                table: "trainingCenters");
        }
    }
}
