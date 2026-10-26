using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication.Migrations
{
    /// <inheritdoc />
    public partial class AddReviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    ShawarmaPlaceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_ShawarmaPlaces_ShawarmaPlaceId",
                        column: x => x.ShawarmaPlaceId,
                        principalTable: "ShawarmaPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ShawarmaPlaceId",
                table: "Reviews",
                column: "ShawarmaPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "DA36513F-6393-43B8-A1E1-5CDF3D8EB6BF",
                column: "ConcurrencyStamp",
                value: "d221ea46-3375-4f98-8992-3525b9fe825d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FA2325ED-7786-447A-BA83-93C89FE17D93",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7896ff06-8357-486e-aa68-ec281a9df31a", "AQAAAAIAAYagAAAAEB/+4Iu1pkffUiSeWwkfiHrwgWcEZNW3S0P3cogGbNvpTBAqcCYV+KV4+6M+cayMrA==" });
        }
    }
}
