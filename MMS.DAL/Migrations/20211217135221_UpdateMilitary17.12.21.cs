using Microsoft.EntityFrameworkCore.Migrations;

namespace MMS.DAL.Migrations
{
    public partial class UpdateMilitary171221 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID_DIVIZION",
                table: "Militaries");

            migrationBuilder.AddColumn<int>(
                name: "DivizionID",
                table: "Militaries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Militaries_DivizionID",
                table: "Militaries",
                column: "DivizionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Militaries_Divizions_DivizionID",
                table: "Militaries",
                column: "DivizionID",
                principalTable: "Divizions",
                principalColumn: "DivizionID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Militaries_Divizions_DivizionID",
                table: "Militaries");

            migrationBuilder.DropIndex(
                name: "IX_Militaries_DivizionID",
                table: "Militaries");

            migrationBuilder.DropColumn(
                name: "DivizionID",
                table: "Militaries");

            migrationBuilder.AddColumn<int>(
                name: "ID_DIVIZION",
                table: "Militaries",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
