using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YoutubeBlog.Data.Migrations
{
    public partial class DALExtensions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("a52e954d-2b9f-4ac4-93ec-8b12e81eb720"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("e85a9700-9d92-4c6e-95ba-dd50c710f178"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiendBy", "ModifiendDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("250d4c0a-d1ec-4cbe-ac6c-be11885b300d"), new Guid("c7bd74b3-9849-4543-920e-765685029892"), "Visual Studio Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.\r\n\r\n", "Admin Test", new DateTime(2023, 10, 19, 13, 55, 24, 689, DateTimeKind.Local).AddTicks(1167), null, null, new Guid("c4c4d9ea-9e80-4f11-9fd4-6590b167c0a3"), false, null, null, "Visual Studio Denem Makalesi 1", 15 },
                    { new Guid("76f6ce62-35fa-4c8a-8006-83b3d06ea81e"), new Guid("5ddbda80-1b6b-40c7-883c-09327c5db051"), "ASP .NET Core Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.\r\n\r\n", "Admin Test", new DateTime(2023, 10, 19, 13, 55, 24, 689, DateTimeKind.Local).AddTicks(1159), null, null, new Guid("10c694e0-0796-4ab4-b664-c8b74830ca68"), false, null, null, "Asp .Net Core Denem Makalesi 1", 15 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5ddbda80-1b6b-40c7-883c-09327c5db051"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 13, 55, 24, 689, DateTimeKind.Local).AddTicks(1366));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c7bd74b3-9849-4543-920e-765685029892"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 13, 55, 24, 689, DateTimeKind.Local).AddTicks(1370));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("10c694e0-0796-4ab4-b664-c8b74830ca68"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 13, 55, 24, 689, DateTimeKind.Local).AddTicks(1477));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("c4c4d9ea-9e80-4f11-9fd4-6590b167c0a3"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 13, 55, 24, 689, DateTimeKind.Local).AddTicks(1481));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("250d4c0a-d1ec-4cbe-ac6c-be11885b300d"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("76f6ce62-35fa-4c8a-8006-83b3d06ea81e"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiendBy", "ModifiendDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("a52e954d-2b9f-4ac4-93ec-8b12e81eb720"), new Guid("5ddbda80-1b6b-40c7-883c-09327c5db051"), "ASP .NET Core Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.\r\n\r\n", "Admin Test", new DateTime(2023, 10, 18, 15, 21, 13, 808, DateTimeKind.Local).AddTicks(7153), null, null, new Guid("10c694e0-0796-4ab4-b664-c8b74830ca68"), false, null, null, "Asp .Net Core Denem Makalesi 1", 15 },
                    { new Guid("e85a9700-9d92-4c6e-95ba-dd50c710f178"), new Guid("c7bd74b3-9849-4543-920e-765685029892"), "Visual Studio Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.\r\n\r\n", "Admin Test", new DateTime(2023, 10, 18, 15, 21, 13, 808, DateTimeKind.Local).AddTicks(7170), null, null, new Guid("c4c4d9ea-9e80-4f11-9fd4-6590b167c0a3"), false, null, null, "Visual Studio Denem Makalesi 1", 15 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5ddbda80-1b6b-40c7-883c-09327c5db051"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 15, 21, 13, 808, DateTimeKind.Local).AddTicks(7338));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c7bd74b3-9849-4543-920e-765685029892"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 15, 21, 13, 808, DateTimeKind.Local).AddTicks(7341));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("10c694e0-0796-4ab4-b664-c8b74830ca68"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 15, 21, 13, 808, DateTimeKind.Local).AddTicks(7420));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("c4c4d9ea-9e80-4f11-9fd4-6590b167c0a3"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 15, 21, 13, 808, DateTimeKind.Local).AddTicks(7424));
        }
    }
}
