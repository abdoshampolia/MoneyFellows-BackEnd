using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoneyFellows.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addingroleseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0b311a9b-07b6-423c-a67e-65ae06e5febb"), null, "User", "USER" },
                    { new Guid("f1b8b59f-6cd7-4074-b481-1f1c7859070f"), null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0b311a9b-07b6-423c-a67e-65ae06e5febb"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f1b8b59f-6cd7-4074-b481-1f1c7859070f"));
        }
    }
}
