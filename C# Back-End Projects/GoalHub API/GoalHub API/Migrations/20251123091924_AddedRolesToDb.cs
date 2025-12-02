using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GoalHub_API.Migrations
{
    /// <inheritdoc />
    public partial class AddedRolesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "08d965f6-c210-437c-9776-bd00a16bc1cd", null, "Data Analyst", "DATA ANALYST" },
                    { "1849483a-e65d-4b47-8691-94ba92df50c7", null, "Player Manager", "PLAYER MANAGER" },
                    { "4628e719-a2f2-4e05-a81c-35a5f2e9b86c", null, "Match Manager", "MATCH MANAGER" },
                    { "76a405a1-0762-4033-b73d-8521b7c780e4", null, "Team Manager", "TEAM MANAGER" },
                    { "8c94137a-93ff-4669-9748-9104c2be244e", null, "Manager", "MANAGER" },
                    { "9efb9d35-695d-4517-aa37-0d6dff646646", null, "Match Viewer", "MATCH VIEWER" },
                    { "e44658b4-56bc-4ec7-943e-d89556918a9f", null, "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08d965f6-c210-437c-9776-bd00a16bc1cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1849483a-e65d-4b47-8691-94ba92df50c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4628e719-a2f2-4e05-a81c-35a5f2e9b86c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76a405a1-0762-4033-b73d-8521b7c780e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c94137a-93ff-4669-9748-9104c2be244e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9efb9d35-695d-4517-aa37-0d6dff646646");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e44658b4-56bc-4ec7-943e-d89556918a9f");
        }
    }
}
