using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SkillUp.Migrations
{
    /// <inheritdoc />
    public partial class mymig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidatTraining_Candidat_candidatsId",
                table: "CandidatTraining");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Candidat",
                table: "Candidat");

            migrationBuilder.DropColumn(
                name: "email",
                table: "trainingCenters");

            migrationBuilder.DropColumn(
                name: "mdp",
                table: "trainingCenters");

            migrationBuilder.RenameTable(
                name: "Candidat",
                newName: "candidats");

            migrationBuilder.AddPrimaryKey(
                name: "PK_candidats",
                table: "candidats",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "text", nullable: false),
                    mdp = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatTraining_candidats_candidatsId",
                table: "CandidatTraining",
                column: "candidatsId",
                principalTable: "candidats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidatTraining_candidats_candidatsId",
                table: "CandidatTraining");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_candidats",
                table: "candidats");

            migrationBuilder.RenameTable(
                name: "candidats",
                newName: "Candidat");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Candidat",
                table: "Candidat",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatTraining_Candidat_candidatsId",
                table: "CandidatTraining",
                column: "candidatsId",
                principalTable: "Candidat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
