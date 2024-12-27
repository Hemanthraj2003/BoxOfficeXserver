using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class init04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    showID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    movieID = table.Column<int>(type: "int", nullable: false),
                    theaterID = table.Column<int>(type: "int", nullable: false),
                    seats = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    slot = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.showID);
                });

            migrationBuilder.CreateTable(
                name: "Theater",
                columns: table => new
                {
                    theaterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    theaterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theater", x => x.theaterId);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    ticketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    movieID = table.Column<int>(type: "int", nullable: false),
                    showID = table.Column<int>(type: "int", nullable: false),
                    userID = table.Column<int>(type: "int", nullable: false),
                    count = table.Column<int>(type: "int", nullable: false),
                    seats = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.ticketID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shows");

            migrationBuilder.DropTable(
                name: "Theater");

            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
