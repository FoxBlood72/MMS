using Microsoft.EntityFrameworkCore.Migrations;

namespace MMS.DAL.Migrations
{
    public partial class SmallUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Corps_Militaries_CommanderId",
                table: "Corps");

            migrationBuilder.AlterColumn<string>(
                name: "sex",
                table: "Militaries",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<int>(
                name: "CommanderId",
                table: "Corps",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Corps_Militaries_CommanderId",
                table: "Corps",
                column: "CommanderId",
                principalTable: "Militaries",
                principalColumn: "ID_PERS",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Corps_Militaries_CommanderId",
                table: "Corps");

            migrationBuilder.AlterColumn<string>(
                name: "sex",
                table: "Militaries",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CommanderId",
                table: "Corps",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Corps_Militaries_CommanderId",
                table: "Corps",
                column: "CommanderId",
                principalTable: "Militaries",
                principalColumn: "ID_PERS",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
