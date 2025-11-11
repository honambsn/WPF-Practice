using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Chess.LoginSignUp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            // Convert the existing nvarchar data to varbinary
            // Bước 1: Thêm cột tạm thời với kiểu dữ liệu varbinary(max)
            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHashTemp",
                table: "Users",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            // Bước 2: Chuyển đổi dữ liệu từ PasswordHash (nvarchar) sang PasswordHashTemp (varbinary)
            migrationBuilder.Sql("UPDATE [Users] SET [PasswordHashTemp] = CONVERT(varbinary(max), [PasswordHash]) WHERE [PasswordHash] IS NOT NULL");

            // Bước 3: Xóa cột PasswordHash cũ
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            // Bước 4: Đổi tên cột tạm thời thành PasswordHash
            migrationBuilder.RenameColumn(
                name: "PasswordHashTemp",
                table: "Users",
                newName: "PasswordHash");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: new Guid("01e4b8c6-3baf-4046-b0f2-f2eaaa2b43df"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: new Guid("8b7f31e2-60d9-473f-a824-23458f681040"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: new Guid("984980c9-efde-47f9-820d-0e44a7824f5d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: new Guid("e1958583-4591-40a9-b365-9b11d0993ac4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: new Guid("ef0b473f-dd5c-42fc-bcf1-33142ea0ed4e"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("2e942320-401b-4990-9096-f2fdc72a90d2"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("cca564cd-a15a-420f-9836-81f301a37b14"));

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                table: "Users",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { new Guid("13dec387-3b5e-4331-8799-662c8797c3df"), "Guest" },
                    { new Guid("9fd17824-0d56-49d5-ad6d-2a924bf16110"), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Email", "ID", "LastName", "Name", "PasswordHash", "ProfilePicture", "RoleID", "Username" },
                values: new object[,]
                {
                    { new Guid("12847732-fb74-4b2a-a739-ecfca4c83c49"), "user2@example.com", 0, "LastTwo", "User Two", new byte[] { 48, 153, 193, 100, 217, 233, 46, 51, 14, 31, 82, 120, 159, 61, 199, 217, 182, 14, 112, 42, 195, 189, 126, 137, 136, 246, 28, 215, 234, 188, 107, 234, 20, 146, 91, 208, 128, 153, 103, 18, 156, 53, 130, 136, 97, 165, 219, 98 }, new byte[0], new Guid("13dec387-3b5e-4331-8799-662c8797c3df"), "user2" },
                    { new Guid("12f07c12-c32d-4f19-8744-fb6085cfb977"), "admin@example.com", 0, "Admin", "Administrator", new byte[] { 38, 61, 92, 107, 9, 25, 66, 175, 254, 22, 42, 35, 132, 58, 80, 85, 244, 95, 70, 128, 216, 112, 128, 148, 73, 6, 62, 51, 30, 231, 93, 133, 67, 40, 31, 89, 220, 228, 64, 162, 146, 56, 5, 77, 50, 46, 145, 32 }, new byte[0], new Guid("9fd17824-0d56-49d5-ad6d-2a924bf16110"), "admin" },
                    { new Guid("1de762f5-43fd-4177-967e-715280adce2c"), "usertest@example.com", 0, "TestLast", "User Test", new byte[] { 68, 129, 131, 53, 67, 115, 80, 244, 191, 207, 104, 205, 129, 57, 150, 157, 8, 218, 145, 58, 138, 182, 206, 67, 23, 126, 38, 138, 113, 123, 250, 29, 36, 4, 107, 158, 193, 13, 133, 11, 154, 46, 200, 249, 23, 183, 63, 55 }, new byte[0], new Guid("13dec387-3b5e-4331-8799-662c8797c3df"), "usertest" },
                    { new Guid("3197a298-cff0-4f60-8a72-ba66aafe8390"), "guest@example.com", 0, "Guest", "Guest User", new byte[] { 12, 67, 122, 59, 10, 136, 40, 73, 208, 102, 210, 116, 39, 38, 2, 252, 162, 152, 66, 198, 160, 21, 213, 193, 175, 188, 199, 47, 217, 207, 114, 107, 68, 210, 112, 145, 123, 69, 163, 117, 193, 9, 162, 79, 114, 235, 211, 86 }, new byte[0], new Guid("13dec387-3b5e-4331-8799-662c8797c3df"), "guest" },
                    { new Guid("b70c4e30-8cc0-414c-b4b1-ba90000d35db"), "user3@example.com", 0, "LastThree", "User Three", new byte[] { 179, 157, 10, 126, 24, 36, 162, 152, 127, 67, 111, 135, 5, 2, 121, 36, 241, 191, 28, 114, 144, 43, 236, 6, 43, 134, 126, 203, 161, 206, 64, 89, 41, 203, 243, 121, 224, 15, 196, 79, 57, 152, 55, 173, 214, 85, 27, 192 }, new byte[0], new Guid("13dec387-3b5e-4331-8799-662c8797c3df"), "user3" },
                    { new Guid("c7eaea73-c0ae-46f7-88d9-200cedce4069"), "user1@example.com", 0, "LastOne", "User One", new byte[] { 192, 175, 151, 123, 86, 185, 100, 143, 209, 105, 248, 58, 137, 140, 93, 148, 142, 180, 47, 42, 56, 31, 39, 190, 223, 196, 161, 149, 100, 148, 132, 158, 137, 228, 136, 73, 150, 36, 241, 164, 22, 5, 8, 111, 99, 107, 208, 244 }, new byte[0], new Guid("13dec387-3b5e-4331-8799-662c8797c3df"), "user1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Username",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: new Guid("12847732-fb74-4b2a-a739-ecfca4c83c49"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: new Guid("12f07c12-c32d-4f19-8744-fb6085cfb977"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: new Guid("1de762f5-43fd-4177-967e-715280adce2c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: new Guid("3197a298-cff0-4f60-8a72-ba66aafe8390"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: new Guid("b70c4e30-8cc0-414c-b4b1-ba90000d35db"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: new Guid("c7eaea73-c0ae-46f7-88d9-200cedce4069"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("13dec387-3b5e-4331-8799-662c8797c3df"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("9fd17824-0d56-49d5-ad6d-2a924bf16110"));

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

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
        }
    }
}
