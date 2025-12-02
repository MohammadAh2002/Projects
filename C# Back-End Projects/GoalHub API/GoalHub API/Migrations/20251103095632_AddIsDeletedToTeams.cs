using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoalHub_API.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeletedToTeams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Stadiums");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Teams",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Teams");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Stadiums",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
