using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClsAppEntityFrameworkCore21.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "people",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    created = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_people", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "people",
                columns: new[] { "id", "created", "name" },
                values: new object[] { 1, new DateTime(2018, 5, 7, 11, 16, 8, 377, DateTimeKind.Local), "Example 1" });

            migrationBuilder.InsertData(
                table: "people",
                columns: new[] { "id", "created", "name" },
                values: new object[] { 2, new DateTime(2018, 5, 6, 11, 16, 8, 379, DateTimeKind.Local), "Example 2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "people");
        }
    }
}
