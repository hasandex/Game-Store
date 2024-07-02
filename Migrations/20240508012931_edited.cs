using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameZone.Migrations
{
    /// <inheritdoc />
    public partial class edited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5596e579-c9df-4885-9a9e-cd49d6aa4b56");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f7685d5-2f96-4a70-8db9-016028d544e8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "88facdb9-2ba4-4acb-9fe4-e55c1d42f8d1", "ff3a016b-6ecf-42a7-ba3a-30a8db8311e2", "User", "user" },
                    { "e2c9101b-c3ac-4130-ad55-e15b7f1d25c0", "8a27aef0-b01e-498e-950c-ceddaf251128", "Admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88facdb9-2ba4-4acb-9fe4-e55c1d42f8d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2c9101b-c3ac-4130-ad55-e15b7f1d25c0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5596e579-c9df-4885-9a9e-cd49d6aa4b56", "71e2acbf-1211-4f5b-9e98-58b6d2440a82", "Admin", "admin" },
                    { "5f7685d5-2f96-4a70-8db9-016028d544e8", "f7172d1f-8d96-49be-8d49-7ea107e34122", "User", "user" }
                });
        }
    }
}
