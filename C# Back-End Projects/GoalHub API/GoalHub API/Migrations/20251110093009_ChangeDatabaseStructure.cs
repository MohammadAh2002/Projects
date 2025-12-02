using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GoalHub_API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDatabaseStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matchs_Competitions_CompetitionID",
                table: "Matchs");

            migrationBuilder.DropTable(
                name: "Coachs");

            migrationBuilder.DropTable(
                name: "Competitions");

            migrationBuilder.DropTable(
                name: "TransferRequests");

            migrationBuilder.DropTable(
                name: "CompetitionTypes");

            migrationBuilder.DropTable(
                name: "TransferStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Matchs_CompetitionID",
                table: "Matchs");

            migrationBuilder.DropColumn(
                name: "CompetitionID",
                table: "Matchs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompetitionID",
                table: "Matchs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Coachs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentTeamID = table.Column<int>(type: "int", nullable: false),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coachs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Coachs_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Coachs_Teams_CurrentTeamID",
                        column: x => x.CurrentTeamID,
                        principalTable: "Teams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionTypes",
                columns: table => new
                {
                    ID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TransferStatuses",
                columns: table => new
                {
                    ID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferStatuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryID = table.Column<short>(type: "smallint", nullable: false),
                    TypeID = table.Column<short>(type: "smallint", nullable: false),
                    EndYear = table.Column<DateOnly>(type: "date", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Organizer = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    StartYear = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Competitions_CompetitionTypes_TypeID",
                        column: x => x.TypeID,
                        principalTable: "CompetitionTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Competitions_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransferRequests",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromTeamID = table.Column<int>(type: "int", nullable: false),
                    PlayerID = table.Column<int>(type: "int", nullable: false),
                    StatusID = table.Column<short>(type: "smallint", nullable: false),
                    ToTeamID = table.Column<int>(type: "int", nullable: false),
                    ApplyingDate = table.Column<DateOnly>(type: "date", nullable: false),
                    DecisionDate = table.Column<DateTime>(type: "Date", nullable: true),
                    PDFDocument = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TransferFee = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferRequests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TransferRequests_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferRequests_Teams_FromTeamID",
                        column: x => x.FromTeamID,
                        principalTable: "Teams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferRequests_Teams_ToTeamID",
                        column: x => x.ToTeamID,
                        principalTable: "Teams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferRequests_TransferStatuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "TransferStatuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CompetitionTypes",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[,]
                {
                    { (short)1, "A regular season competition where teams play each other over multiple rounds to determine the champion.", "League" },
                    { (short)2, "A knockout-style tournament where teams compete in elimination rounds until one winner remains.", "Cup" },
                    { (short)3, "A one-off match between the winners of the league and cup competitions.", "Super Cup" },
                    { (short)4, "A non-competitive match often used for practice, preseason, or charity purposes.", "Friendly" }
                });

            migrationBuilder.InsertData(
                table: "TransferStatuses",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[,]
                {
                    { (short)1, "Transfer request has been approved.", "Accepted" },
                    { (short)2, "Transfer request has been canceled.", "Canceled" },
                    { (short)3, "Transfer request has been rejected.", "Rejected" },
                    { (short)4, "Transfer request is awaiting approval.", "Pending" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_CompetitionID",
                table: "Matchs",
                column: "CompetitionID");

            migrationBuilder.CreateIndex(
                name: "IX_Coachs_CurrentTeamID",
                table: "Coachs",
                column: "CurrentTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Coachs_PersonID",
                table: "Coachs",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_CountryID",
                table: "Competitions",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_Name",
                table: "Competitions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_TypeID",
                table: "Competitions",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionTypes_Description",
                table: "CompetitionTypes",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionTypes_Name",
                table: "CompetitionTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransferRequests_FromTeamID",
                table: "TransferRequests",
                column: "FromTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_TransferRequests_PDFDocument",
                table: "TransferRequests",
                column: "PDFDocument",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransferRequests_PlayerID",
                table: "TransferRequests",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_TransferRequests_StatusID",
                table: "TransferRequests",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_TransferRequests_ToTeamID",
                table: "TransferRequests",
                column: "ToTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_TransferStatuses_Description",
                table: "TransferStatuses",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransferStatuses_Name",
                table: "TransferStatuses",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Matchs_Competitions_CompetitionID",
                table: "Matchs",
                column: "CompetitionID",
                principalTable: "Competitions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
