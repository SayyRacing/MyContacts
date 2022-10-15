using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyContacts.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FistName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SubCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Prywatny" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Służbowy" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Inny" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CategoryId", "DateOfBirth", "Email", "FistName", "LastName", "Password", "PhoneNumber", "SubCategory" },
                values: new object[] { 1, 1, new DateTime(1999, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "cLeclerc@gmail.com", "Charles", "Leclerc", "abc123", 506432523, "" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CategoryId", "DateOfBirth", "Email", "FistName", "LastName", "Password", "PhoneNumber", "SubCategory" },
                values: new object[] { 2, 2, new DateTime(1981, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lHam44@gmail.com", "Lewis", "Hamilton", "abc123", 677312444, "" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CategoryId", "DateOfBirth", "Email", "FistName", "LastName", "Password", "PhoneNumber", "SubCategory" },
                values: new object[] { 3, 1, new DateTime(1997, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "fAlonso@gmail.com", "Fernando", "Alonso", "235634", 111222145, "" });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CategoryId",
                table: "Contacts",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
