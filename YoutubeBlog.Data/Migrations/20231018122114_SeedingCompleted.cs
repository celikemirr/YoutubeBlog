using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YoutubeBlog.Data.Migrations
{
    public partial class SeedingCompleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiendBy", "ModifiendDate", "Name" },
                values: new object[,]
                {
                    { new Guid("5ddbda80-1b6b-40c7-883c-09327c5db051"), "Admin Test", new DateTime(2023, 10, 18, 15, 21, 13, 808, DateTimeKind.Local).AddTicks(7338), null, null, false, null, null, "ASP .NET Core" },
                    { new Guid("c7bd74b3-9849-4543-920e-765685029892"), "Admin Test", new DateTime(2023, 10, 18, 15, 21, 13, 808, DateTimeKind.Local).AddTicks(7341), null, null, false, null, null, "Visual Studio 2022" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsDeleted", "ModifiendBy", "ModifiendDate" },
                values: new object[,]
                {
                    { new Guid("10c694e0-0796-4ab4-b664-c8b74830ca68"), "Admin Test", new DateTime(2023, 10, 18, 15, 21, 13, 808, DateTimeKind.Local).AddTicks(7420), null, null, "Images/testimage", "jpg", false, null, null },
                    { new Guid("c4c4d9ea-9e80-4f11-9fd4-6590b167c0a3"), "Admin Test", new DateTime(2023, 10, 18, 15, 21, 13, 808, DateTimeKind.Local).AddTicks(7424), null, null, "Images/vstest", "png", false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiendBy", "ModifiendDate", "Title", "ViewCount" },
                values: new object[] { new Guid("a52e954d-2b9f-4ac4-93ec-8b12e81eb720"), new Guid("5ddbda80-1b6b-40c7-883c-09327c5db051"), "ASP .NET Core Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.\r\n\r\n", "Admin Test", new DateTime(2023, 10, 18, 15, 21, 13, 808, DateTimeKind.Local).AddTicks(7153), null, null, new Guid("10c694e0-0796-4ab4-b664-c8b74830ca68"), false, null, null, "Asp .Net Core Denem Makalesi 1", 15 });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiendBy", "ModifiendDate", "Title", "ViewCount" },
                values: new object[] { new Guid("e85a9700-9d92-4c6e-95ba-dd50c710f178"), new Guid("c7bd74b3-9849-4543-920e-765685029892"), "Visual Studio Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.\r\n\r\n", "Admin Test", new DateTime(2023, 10, 18, 15, 21, 13, 808, DateTimeKind.Local).AddTicks(7170), null, null, new Guid("c4c4d9ea-9e80-4f11-9fd4-6590b167c0a3"), false, null, null, "Visual Studio Denem Makalesi 1", 15 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("a52e954d-2b9f-4ac4-93ec-8b12e81eb720"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("e85a9700-9d92-4c6e-95ba-dd50c710f178"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5ddbda80-1b6b-40c7-883c-09327c5db051"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c7bd74b3-9849-4543-920e-765685029892"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("10c694e0-0796-4ab4-b664-c8b74830ca68"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("c4c4d9ea-9e80-4f11-9fd4-6590b167c0a3"));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Articles",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
