using Microsoft.EntityFrameworkCore.Migrations;

namespace MMS.DAL.Migrations
{
    public partial class MtoMSkillMilitary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MilitarySkill",
                columns: table => new
                {
                    militaryId = table.Column<int>(type: "int", nullable: false),
                    skillId = table.Column<int>(type: "int", nullable: false),
                    militaryGrade = table.Column<float>(type: "real", nullable: false, defaultValue: 1f)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitarySkill", x => new { x.skillId, x.militaryId });
                    table.ForeignKey(
                        name: "FK_MilitarySkill_Militaries_militaryId",
                        column: x => x.militaryId,
                        principalTable: "Militaries",
                        principalColumn: "ID_PERS",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MilitarySkill_Skills_skillId",
                        column: x => x.skillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MilitarySkill_militaryId",
                table: "MilitarySkill",
                column: "militaryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MilitarySkill");
        }
    }
}
