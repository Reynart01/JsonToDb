using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JsonToDb.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    GeoId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    TerrorityCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.GeoId);
                });

            migrationBuilder.CreateTable(
                name: "DailyData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Cases = table.Column<int>(nullable: false),
                    Deaths = table.Column<int>(nullable: false),
                    PopData2018 = table.Column<string>(nullable: true),
                    CountryId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyData_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "GeoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyData_CountryId",
                table: "DailyData",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyData");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
