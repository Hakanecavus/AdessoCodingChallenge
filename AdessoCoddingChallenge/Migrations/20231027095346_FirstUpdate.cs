using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdessoCoddingChallenge.Migrations
{
    /// <inheritdoc />
    public partial class FirstUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_DrawResults_DrawResultId",
                table: "Groups");

            migrationBuilder.AlterColumn<int>(
                name: "DrawResultId",
                table: "Groups",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_DrawResults_DrawResultId",
                table: "Groups",
                column: "DrawResultId",
                principalTable: "DrawResults",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_DrawResults_DrawResultId",
                table: "Groups");

            migrationBuilder.AlterColumn<int>(
                name: "DrawResultId",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_DrawResults_DrawResultId",
                table: "Groups",
                column: "DrawResultId",
                principalTable: "DrawResults",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
