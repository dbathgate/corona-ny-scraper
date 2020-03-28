using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoronaNyScaper.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "corona_ny",
                columns: table => new
                {
                    last_updated = table.Column<DateTime>(nullable: false),
                    suffolk = table.Column<int>(nullable: false),
                    nassau = table.Column<int>(nullable: false),
                    nyc = table.Column<int>(nullable: false),
                    state = table.Column<int>(nullable: false),
                    newsday_last_updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_corona_ny", x => x.last_updated);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "corona_ny");
        }
    }
}
