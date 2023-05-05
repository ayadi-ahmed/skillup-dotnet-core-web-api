using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SkillUp.Migrations
{
    /// <inheritdoc />
    public partial class firstcommit : Migration
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_managers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "trainings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trainings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "trainingCenters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    managerId = table.Column<int>(type: "integer", nullable: true),
                    TrainingCenterId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trainingCenters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trainingCenters_managers_managerId",
                        column: x => x.managerId,
                        principalTable: "managers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_trainingCenters_trainingCenters_TrainingCenterId",
                        column: x => x.TrainingCenterId,
                        principalTable: "trainingCenters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "achats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    trainingId = table.Column<int>(type: "integer", nullable: true),
                    candidatId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_achats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_achats_candidats_candidatId",
                        column: x => x.candidatId,
                        principalTable: "candidats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_achats_trainings_trainingId",
                        column: x => x.trainingId,
                        principalTable: "trainings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_achats_candidatId",
                table: "achats",
                column: "candidatId");

            migrationBuilder.CreateIndex(
                name: "IX_achats_trainingId",
                table: "achats",
                column: "trainingId");

            migrationBuilder.CreateIndex(
                name: "IX_trainingCenters_managerId",
                table: "trainingCenters",
                column: "managerId");

            migrationBuilder.CreateIndex(
                name: "IX_trainingCenters_TrainingCenterId",
                table: "trainingCenters",
                column: "TrainingCenterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "achats");

            migrationBuilder.DropTable(
                name: "trainingCenters");

            migrationBuilder.DropTable(
                name: "candidats");

            migrationBuilder.DropTable(
                name: "trainings");

            migrationBuilder.DropTable(
                name: "managers");
        }
    }
}
