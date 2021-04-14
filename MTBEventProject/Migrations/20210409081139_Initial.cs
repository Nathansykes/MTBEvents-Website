using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MTBEventProject.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MTBEvents",
                columns: table => new
                {
                    MTBEventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MTBEventTitle = table.Column<string>(type: "varchar(100)", nullable: false),
                    MTBEventLocation = table.Column<string>(type: "varchar(100)", nullable: true),
                    MTBEventDescription = table.Column<string>(type: "text", nullable: true),
                    MTBEventWebsite = table.Column<string>(type: "varchar(100)", nullable: true),
                    MTBEventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MTBEventGroup = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MTBEvents", x => x.MTBEventID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MTBEvents");
        }
    }
}
