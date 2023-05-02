using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SkillUp.Migrations
{
    /// <inheritdoc />
    public partial class secmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidatTraining_candidats_candidatsId",
                table: "CandidatTraining");

            migrationBuilder.DropTable(
                name: "candidats");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "dateNaissance",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fonction",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nom",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "prenom",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tel",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatTraining_users_candidatsId",
                table: "CandidatTraining",
                column: "candidatsId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidatTraining_users_candidatsId",
                table: "CandidatTraining");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "users");

            migrationBuilder.DropColumn(
                name: "address",
                table: "users");

            migrationBuilder.DropColumn(
                name: "dateNaissance",
                table: "users");

            migrationBuilder.DropColumn(
                name: "fonction",
                table: "users");

            migrationBuilder.DropColumn(
                name: "nom",
                table: "users");

            migrationBuilder.DropColumn(
                name: "prenom",
                table: "users");

            migrationBuilder.DropColumn(
                name: "tel",
                table: "users");

            migrationBuilder.CreateTable(
                name: "candidats",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    address = table.Column<string>(type: "text", nullable: false),
                    dateNaissance = table.Column<string>(type: "text", nullable: false),
                    fonction = table.Column<string>(type: "text", nullable: false),
                    nom = table.Column<string>(type: "text", nullable: false),
                    prenom = table.Column<string>(type: "text", nullable: false),
                    tel = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidats", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatTraining_candidats_candidatsId",
                table: "CandidatTraining",
                column: "candidatsId",
                principalTable: "candidats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
