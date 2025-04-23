using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class seed_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulty",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1a2b3c4d-5e6f-4a8b-9c0d-1e2f3a4b5c6d"), "Easy" },
                    { new Guid("2b3c4d5e-6f7a-4b8c-9d0e-2f3a4b5c6d7e"), "Medium" },
                    { new Guid("3c4d5e6f-7a8b-4c9d-0e1f-3a4b5c6d7e8f"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "Regionimageurl" },
                values: new object[,]
                {
                    { new Guid("1a2b3c4d-5e6f-4a8b-9c0d-1e2f3a4b5c6d"), "REG001", "Region 1", "https://example.com/region1.jpg" },
                    { new Guid("2b3c4d5e-6f7a-4b8c-9d0e-2f3a4b5c6d7e"), "REG002", "Region 2", "https://example.com/region2.jpg" },
                    { new Guid("3c4d5e6f-7a8b-4c9d-0e1f-3a4b5c6d7e8f"), "REG003", "Region 3", "https://example.com/region3.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulty",
                keyColumn: "Id",
                keyValue: new Guid("1a2b3c4d-5e6f-4a8b-9c0d-1e2f3a4b5c6d"));

            migrationBuilder.DeleteData(
                table: "Difficulty",
                keyColumn: "Id",
                keyValue: new Guid("2b3c4d5e-6f7a-4b8c-9d0e-2f3a4b5c6d7e"));

            migrationBuilder.DeleteData(
                table: "Difficulty",
                keyColumn: "Id",
                keyValue: new Guid("3c4d5e6f-7a8b-4c9d-0e1f-3a4b5c6d7e8f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1a2b3c4d-5e6f-4a8b-9c0d-1e2f3a4b5c6d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("2b3c4d5e-6f7a-4b8c-9d0e-2f3a4b5c6d7e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("3c4d5e6f-7a8b-4c9d-0e1f-3a4b5c6d7e8f"));
        }
    }
}
