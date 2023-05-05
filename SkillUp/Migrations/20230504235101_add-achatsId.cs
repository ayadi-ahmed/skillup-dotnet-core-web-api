using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillUp.Migrations
{
    /// <inheritdoc />
    public partial class addachatsId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_achats_candidats_candidatId",
                table: "achats");

            migrationBuilder.RenameColumn(
                name: "candidatId",
                table: "achats",
                newName: "CandidatId");

            migrationBuilder.RenameIndex(
                name: "IX_achats_candidatId",
                table: "achats",
                newName: "IX_achats_CandidatId");

            migrationBuilder.AddColumn<int[]>(
                name: "achatsId",
                table: "candidats",
                type: "integer[]",
                nullable: false,
                defaultValue: new int[0]);

            migrationBuilder.AddForeignKey(
                name: "FK_achats_candidats_CandidatId",
                table: "achats",
                column: "CandidatId",
                principalTable: "candidats",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_achats_candidats_CandidatId",
                table: "achats");

            migrationBuilder.DropColumn(
                name: "achatsId",
                table: "candidats");

            migrationBuilder.RenameColumn(
                name: "CandidatId",
                table: "achats",
                newName: "candidatId");

            migrationBuilder.RenameIndex(
                name: "IX_achats_CandidatId",
                table: "achats",
                newName: "IX_achats_candidatId");

            migrationBuilder.AddForeignKey(
                name: "FK_achats_candidats_candidatId",
                table: "achats",
                column: "candidatId",
                principalTable: "candidats",
                principalColumn: "Id");
        }
    }
}
