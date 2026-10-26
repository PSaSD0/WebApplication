using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication.Migrations
{
    /// <inheritdoc />
    public partial class AddAddressToShawarmaPlace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "ShawarmaPlaces",
                type: "TEXT",
                maxLength: 200,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "DA36513F-6393-43B8-A1E1-5CDF3D8EB6BF",
                column: "ConcurrencyStamp",
                value: "4e5767b1-2040-4e92-a388-a55bd01978c9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FA2325ED-7786-447A-BA83-93C89FE17D93",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c467e324-794b-4b98-ac0c-c3ad51bb6d1c", "AQAAAAIAAYagAAAAEExL7ZUNETiYlO+3MDvjEYFa/PMdXkqL7G0xSd570yJG1422gfZJDEDk/KwW+5mKLA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "ShawarmaPlaces");

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
        }
    }
}
