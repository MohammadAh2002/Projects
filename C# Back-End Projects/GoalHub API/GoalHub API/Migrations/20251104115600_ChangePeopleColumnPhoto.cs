using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoalHub_API.Migrations
{
    /// <inheritdoc />
    public partial class ChangePeopleColumnPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Photo",
                table: "People",
                newName: "ImageFileName");

            migrationBuilder.RenameIndex(
                name: "IX_People_Photo",
                table: "People",
                newName: "IX_People_ImageFileName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageFileName",
                table: "People",
                newName: "Photo");

            migrationBuilder.RenameIndex(
                name: "IX_People_ImageFileName",
                table: "People",
                newName: "IX_People_Photo");
        }
    }
}
