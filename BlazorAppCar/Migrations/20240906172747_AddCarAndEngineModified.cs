using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorAppCar.Migrations
{
    /// <inheritdoc />
    public partial class AddCarAndEngineModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EngineId",
                table: "Car",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Car",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Car_EngineId",
                table: "Car",
                column: "EngineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Engine_EngineId",
                table: "Car",
                column: "EngineId",
                principalTable: "Engine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Engine_EngineId",
                table: "Car");

            migrationBuilder.DropIndex(
                name: "IX_Car_EngineId",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "EngineId",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Car");
        }
    }
}
