using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoronaNyScaper.Migrations
{
    public partial class Boroughs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "newsday_last_updated",
                table: "corona_ny");

            migrationBuilder.CreateTable(
                name: "corona_borough_deaths",
                columns: table => new
                {
                    last_updated = table.Column<DateTime>(nullable: false),
                    queens = table.Column<int>(nullable: false),
                    manhattan = table.Column<int>(nullable: false),
                    brooklyn = table.Column<int>(nullable: false),
                    staten = table.Column<int>(nullable: false),
                    bronx = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_corona_borough_deaths", x => x.last_updated);
                });

            migrationBuilder.CreateTable(
                name: "corona_borough_hospitalizations",
                columns: table => new
                {
                    last_updated = table.Column<DateTime>(nullable: false),
                    queens = table.Column<int>(nullable: false),
                    manhattan = table.Column<int>(nullable: false),
                    brooklyn = table.Column<int>(nullable: false),
                    staten = table.Column<int>(nullable: false),
                    bronx = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_corona_borough_hospitalizations", x => x.last_updated);
                });

            migrationBuilder.CreateTable(
                name: "corona_boroughs",
                columns: table => new
                {
                    last_updated = table.Column<DateTime>(nullable: false),
                    queens = table.Column<int>(nullable: false),
                    manhattan = table.Column<int>(nullable: false),
                    brooklyn = table.Column<int>(nullable: false),
                    staten = table.Column<int>(nullable: false),
                    bronx = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_corona_boroughs", x => x.last_updated);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "corona_borough_deaths");

            migrationBuilder.DropTable(
                name: "corona_borough_hospitalizations");

            migrationBuilder.DropTable(
                name: "corona_boroughs");

            migrationBuilder.AddColumn<DateTime>(
                name: "newsday_last_updated",
                table: "corona_ny",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
