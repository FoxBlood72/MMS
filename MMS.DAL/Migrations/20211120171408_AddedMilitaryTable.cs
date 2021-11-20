using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMS.DAL.Migrations
{
    public partial class AddedMilitaryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Militaries",
                columns: table => new
                {
                    ID_PERS = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_DIVIZION = table.Column<int>(type: "int", nullable: false),
                    ID_BASE = table.Column<int>(type: "int", nullable: false),
                    salary = table.Column<float>(type: "float(2)", maxLength: 20, precision: 2, nullable: false),
                    firstname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    lastname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    cnp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sex = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    hire_date = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Militaries", x => x.ID_PERS);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Militaries");
        }
    }
}
