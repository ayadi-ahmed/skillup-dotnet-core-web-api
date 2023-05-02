using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillUp.Migrations
{
    /// <inheritdoc />
    public partial class ajoutTraining : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_souscategories",
                table: "souscategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categorie",
                table: "categorie");

            migrationBuilder.RenameTable(
                name: "souscategories",
                newName: "trainingCenters");

            migrationBuilder.RenameTable(
                name: "categorie",
                newName: "trainings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_trainingCenters",
                table: "trainingCenters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_trainings",
                table: "trainings",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_trainings",
                table: "trainings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_trainingCenters",
                table: "trainingCenters");

            migrationBuilder.RenameTable(
                name: "trainings",
                newName: "categorie");

            migrationBuilder.RenameTable(
                name: "trainingCenters",
                newName: "souscategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categorie",
                table: "categorie",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_souscategories",
                table: "souscategories",
                column: "Id");
        }
    }
}
