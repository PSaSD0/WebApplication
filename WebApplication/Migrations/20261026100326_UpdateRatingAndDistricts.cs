using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRatingAndDistricts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ShawarmaPlaces");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "ShawarmaPlaces");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Reviews",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "DA36513F-6393-43B8-A1E1-5CDF3D8EB6BF",
                column: "ConcurrencyStamp",
                value: "b1f7294c-7940-47e5-8562-a76cfb8fc74b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FA2325ED-7786-447A-BA83-93C89FE17D93",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bd15c934-5600-4512-9937-03580d7bfa97", "AQAAAAIAAYagAAAAENqGaboG1HSUDC6FeNXDCcDjRMfQveem0JT3rKy1u7hrUxpC+u7J8GeePg6XVRr6cQ==" });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "DateCreated", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ленинский район" },
                    { 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Октябрьский район" },
                    { 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Первомайский район" },
                    { 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Индустриальный район" },
                    { 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Устиновский район" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Reviews");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ShawarmaPlaces",
                type: "TEXT",
                maxLength: 100000,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "ShawarmaPlaces",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "DA36513F-6393-43B8-A1E1-5CDF3D8EB6BF",
                column: "ConcurrencyStamp",
                value: "1cde5525-e93b-4030-bf3a-c4ebd1a03f25");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FA2325ED-7786-447A-BA83-93C89FE17D93",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9ac67e8c-1ea7-451e-88dd-691c71610bdb", "AQAAAAIAAYagAAAAEBNFAe8/tnrXhbOdjuBttT///JfGuz1xFUzyV3w4JoxtWvHs+AWgS4P8hr/MEVallw==" });
        }
    }
}
