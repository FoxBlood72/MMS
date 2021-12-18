using Microsoft.EntityFrameworkCore.Migrations;

namespace MMS.DAL.Migrations
{
    public partial class AddedStateConflict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StateConflict",
                columns: table => new
                {
                    state1Id = table.Column<int>(type: "int", nullable: false),
                    conflictId = table.Column<int>(type: "int", nullable: false),
                    state2Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateConflict", x => new { x.conflictId, x.state1Id });
                    table.ForeignKey(
                        name: "FK_StateConflict_Conflicts_conflictId",
                        column: x => x.conflictId,
                        principalTable: "Conflicts",
                        principalColumn: "id_conflict",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StateConflict_States_state1Id",
                        column: x => x.state1Id,
                        principalTable: "States",
                        principalColumn: "ID_STATE",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StateConflict_States_state2Id",
                        column: x => x.state2Id,
                        principalTable: "States",
                        principalColumn: "ID_STATE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StateConflict_state1Id",
                table: "StateConflict",
                column: "state1Id");

            migrationBuilder.CreateIndex(
                name: "IX_StateConflict_state2Id",
                table: "StateConflict",
                column: "state2Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StateConflict");
        }
    }
}
