using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillUp.Migrations
{
    /// <inheritdoc />
    public partial class allcontrollers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "trainingCenterId",
                table: "trainings",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_trainings_trainingCenterId",
                table: "trainings",
                column: "trainingCenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_trainings_trainingCenters_trainingCenterId",
                table: "trainings",
                column: "trainingCenterId",
                principalTable: "trainingCenters",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trainings_trainingCenters_trainingCenterId",
                table: "trainings");

            migrationBuilder.DropIndex(
                name: "IX_trainings_trainingCenterId",
                table: "trainings");

            migrationBuilder.DropColumn(
                name: "trainingCenterId",
                table: "trainings");
        }
    }
}
