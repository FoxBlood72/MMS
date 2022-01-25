using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMS.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conflicts",
                columns: table => new
                {
                    id_conflict = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    start_date = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "GetDate()"),
                    description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conflicts", x => x.id_conflict);
                });

            migrationBuilder.CreateTable(
                name: "Leaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Last_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    sex = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    birth_date = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    id_location = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    province = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.id_location);
                });

            migrationBuilder.CreateTable(
                name: "Missions",
                columns: table => new
                {
                    id_mission = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    start_date = table.Column<DateTime>(type: "Date", nullable: true, defaultValueSql: "GetDate()"),
                    end_date = table.Column<DateTime>(type: "Date", nullable: true, defaultValueSql: "GetDate()")
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
                    SkillName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SkillDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    ID_STATE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    population = table.Column<int>(type: "int", nullable: false),
                    surface = table.Column<int>(type: "int", nullable: false),
                    legislator = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    id_leader = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.ID_STATE);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<int>(type: "int", nullable: true),
                    RoleId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId1",
                        column: x => x.RoleId1,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "Militaries",
                columns: table => new
                {
                    ID_PERS = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DivizionID = table.Column<int>(type: "int", nullable: true),
                    mBaseIdBase = table.Column<int>(type: "int", nullable: true),
                    salary = table.Column<float>(type: "float(2)", maxLength: 20, precision: 2, nullable: false),
                    firstname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    lastname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    cnp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sex = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    hire_date = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Militaries", x => x.ID_PERS);
                    table.ForeignKey(
                        name: "FK_Militaries_Bases_mBaseIdBase",
                        column: x => x.mBaseIdBase,
                        principalTable: "Bases",
                        principalColumn: "IdBase",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Corps",
                columns: table => new
                {
                    CorpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommanderId = table.Column<int>(type: "int", nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Corps_States_stateID_STATE",
                        column: x => x.stateID_STATE,
                        principalTable: "States",
                        principalColumn: "ID_STATE",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "ArmyCorpMission",
                columns: table => new
                {
                    missionId = table.Column<int>(type: "int", nullable: false),
                    armycorpId = table.Column<int>(type: "int", nullable: false),
                    endDate = table.Column<DateTime>(type: "Date", nullable: true),
                    isVictory = table.Column<int>(type: "int", nullable: true),
                    startDate = table.Column<DateTime>(type: "Date", nullable: true, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmyCorpMission", x => new { x.missionId, x.armycorpId });
                    table.ForeignKey(
                        name: "FK_ArmyCorpMission_Corps_armycorpId",
                        column: x => x.armycorpId,
                        principalTable: "Corps",
                        principalColumn: "CorpId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArmyCorpMission_Missions_missionId",
                        column: x => x.missionId,
                        principalTable: "Missions",
                        principalColumn: "id_mission",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_ArmyCorpMission_armycorpId",
                table: "ArmyCorpMission",
                column: "armycorpId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId1",
                table: "AspNetUserRoles",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId1",
                table: "AspNetUserRoles",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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

            migrationBuilder.CreateIndex(
                name: "IX_Militaries_DivizionID",
                table: "Militaries",
                column: "DivizionID");

            migrationBuilder.CreateIndex(
                name: "IX_Militaries_mBaseIdBase",
                table: "Militaries",
                column: "mBaseIdBase");

            migrationBuilder.CreateIndex(
                name: "IX_MilitarySkill_militaryId",
                table: "MilitarySkill",
                column: "militaryId");

            migrationBuilder.CreateIndex(
                name: "IX_StateConflict_state1Id",
                table: "StateConflict",
                column: "state1Id");

            migrationBuilder.CreateIndex(
                name: "IX_StateConflict_state2Id",
                table: "StateConflict",
                column: "state2Id");

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
                name: "FK_Divizions_Corps_CorpId",
                table: "Divizions");

            migrationBuilder.DropTable(
                name: "ArmyCorpMission");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Garrisons");

            migrationBuilder.DropTable(
                name: "Leaders");

            migrationBuilder.DropTable(
                name: "MilitarySkill");

            migrationBuilder.DropTable(
                name: "StateConflict");

            migrationBuilder.DropTable(
                name: "Missions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Conflicts");

            migrationBuilder.DropTable(
                name: "Corps");

            migrationBuilder.DropTable(
                name: "Militaries");

            migrationBuilder.DropTable(
                name: "Bases");

            migrationBuilder.DropTable(
                name: "Divizions");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
