using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMS.DAL.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commanders");

            migrationBuilder.DropTable(
                name: "Generals");

            migrationBuilder.CreateTable(
                name: "Bases",
                columns: table => new
                {
                    IdBase = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    locationid_location = table.Column<int>(type: "int", nullable: true),
                    stateID_STATE = table.Column<int>(type: "int", nullable: true),
                    BaseName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FoundDate = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bases", x => x.IdBase);
                    table.ForeignKey(
                        name: "FK_Bases_Locations_locationid_location",
                        column: x => x.locationid_location,
                        principalTable: "Locations",
                        principalColumn: "id_location",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bases_States_stateID_STATE",
                        column: x => x.stateID_STATE,
                        principalTable: "States",
                        principalColumn: "ID_STATE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Corps",
                columns: table => new
                {
                    CorpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommanderId = table.Column<int>(type: "int", nullable: false),
                    stateID_STATE = table.Column<int>(type: "int", nullable: true),
                    defeates = table.Column<int>(type: "int", nullable: false),
                    victories = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corps", x => x.CorpId);
                    table.ForeignKey(
                        name: "FK_Corps_Militaries_CommanderId",
                        column: x => x.CommanderId,
                        principalTable: "Militaries",
                        principalColumn: "ID_PERS",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Corps_States_stateID_STATE",
                        column: x => x.stateID_STATE,
                        principalTable: "States",
                        principalColumn: "ID_STATE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Missions",
                columns: table => new
                {
                    id_mission = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    start_date = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "GetDate()"),
                    end_date = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.id_mission);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkillDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "Garrisons",
                columns: table => new
                {
                    id_garrison = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MilitaryBaseIdBase = table.Column<int>(type: "int", nullable: true),
                    available_rooms = table.Column<int>(type: "int", nullable: false),
                    start_date = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "GetDate()"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garrisons", x => x.id_garrison);
                    table.ForeignKey(
                        name: "FK_Garrisons_Bases_MilitaryBaseIdBase",
                        column: x => x.MilitaryBaseIdBase,
                        principalTable: "Bases",
                        principalColumn: "IdBase",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Divizions",
                columns: table => new
                {
                    DivizionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DivizionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeneralID = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoundDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CorpId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divizions", x => x.DivizionID);
                    table.ForeignKey(
                        name: "FK_Divizions_Corps_CorpId",
                        column: x => x.CorpId,
                        principalTable: "Corps",
                        principalColumn: "CorpId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bases_locationid_location",
                table: "Bases",
                column: "locationid_location");

            migrationBuilder.CreateIndex(
                name: "IX_Bases_stateID_STATE",
                table: "Bases",
                column: "stateID_STATE");

            migrationBuilder.CreateIndex(
                name: "IX_Corps_CommanderId",
                table: "Corps",
                column: "CommanderId");

            migrationBuilder.CreateIndex(
                name: "IX_Corps_stateID_STATE",
                table: "Corps",
                column: "stateID_STATE");

            migrationBuilder.CreateIndex(
                name: "IX_Divizions_CorpId",
                table: "Divizions",
                column: "CorpId");

            migrationBuilder.CreateIndex(
                name: "IX_Garrisons_MilitaryBaseIdBase",
                table: "Garrisons",
                column: "MilitaryBaseIdBase");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Divizions");

            migrationBuilder.DropTable(
                name: "Garrisons");

            migrationBuilder.DropTable(
                name: "Missions");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Corps");

            migrationBuilder.DropTable(
                name: "Bases");

            migrationBuilder.CreateTable(
                name: "Commanders",
                columns: table => new
                {
                    id_personal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    max_soldiers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commanders", x => x.id_personal);
                });

            migrationBuilder.CreateTable(
                name: "Generals",
                columns: table => new
                {
                    id_personal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    max_div = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generals", x => x.id_personal);
                });
        }
    }
}
