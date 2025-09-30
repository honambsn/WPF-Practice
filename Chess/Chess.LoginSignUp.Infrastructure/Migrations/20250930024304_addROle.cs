using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Chess.LoginSignUp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addROle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { new Guid("2e942320-401b-4990-9096-f2fdc72a90d2"), "Admin" },
                    { new Guid("cca564cd-a15a-420f-9836-81f301a37b14"), "Guest" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Email", "Name", "PasswordHash", "RoleID", "Username" },
                values: new object[,]
                {
                    { new Guid("01e4b8c6-3baf-4046-b0f2-f2eaaa2b43df"), "guest@example.com", "Guest User", "guest", new Guid("cca564cd-a15a-420f-9836-81f301a37b14"), "guest" },
                    { new Guid("8b7f31e2-60d9-473f-a824-23458f681040"), "user2@example.com", "User Two", "user2password", new Guid("cca564cd-a15a-420f-9836-81f301a37b14"), "user2" },
                    { new Guid("984980c9-efde-47f9-820d-0e44a7824f5d"), "user1@example.com", "User One", "user1password", new Guid("cca564cd-a15a-420f-9836-81f301a37b14"), "user1" },
                    { new Guid("e1958583-4591-40a9-b365-9b11d0993ac4"), "user3@example.com", "User Three", "user3password", new Guid("cca564cd-a15a-420f-9836-81f301a37b14"), "user3" },
                    { new Guid("ef0b473f-dd5c-42fc-bcf1-33142ea0ed4e"), "admin@example.com", "Administrator", "123", new Guid("2e942320-401b-4990-9096-f2fdc72a90d2"), "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
