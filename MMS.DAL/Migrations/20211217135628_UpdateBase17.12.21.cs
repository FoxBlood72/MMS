using Microsoft.EntityFrameworkCore.Migrations;

namespace MMS.DAL.Migrations
{
    public partial class UpdateBase171221 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID_BASE",
                table: "Militaries");

            migrationBuilder.AddColumn<int>(
                name: "mBaseIdBase",
                table: "Militaries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Militaries_mBaseIdBase",
                table: "Militaries",
                column: "mBaseIdBase");

            migrationBuilder.AddForeignKey(
                name: "FK_Militaries_Bases_mBaseIdBase",
                table: "Militaries",
                column: "mBaseIdBase",
                principalTable: "Bases",
                principalColumn: "IdBase",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Militaries_Bases_mBaseIdBase",
                table: "Militaries");

            migrationBuilder.DropIndex(
                name: "IX_Militaries_mBaseIdBase",
                table: "Militaries");

            migrationBuilder.DropColumn(
                name: "mBaseIdBase",
                table: "Militaries");

            migrationBuilder.AddColumn<int>(
                name: "ID_BASE",
                table: "Militaries",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
