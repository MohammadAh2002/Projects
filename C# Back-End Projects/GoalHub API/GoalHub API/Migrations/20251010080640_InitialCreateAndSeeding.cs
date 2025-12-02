using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GoalHub_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateAndSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompetitionTypes",
                columns: table => new
                {
                    ID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    ID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MatchStatuses",
                columns: table => new
                {
                    ID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchStatuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "Date", nullable: false),
                    CountryID = table.Column<short>(type: "smallint", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TransferStatuses",
                columns: table => new
                {
                    ID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferStatuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    ID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CountryID = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TypeID = table.Column<short>(type: "smallint", nullable: false),
                    StartYear = table.Column<DateOnly>(type: "date", nullable: false),
                    EndYear = table.Column<DateOnly>(type: "date", nullable: false),
                    Organizer = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CountryID = table.Column<short>(type: "smallint", nullable: false)
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
                name: "Stadiums",
                columns: table => new
                {
                    ID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    CityID = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stadiums", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Stadiums_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CityID = table.Column<short>(type: "smallint", nullable: false),
                    StadiumID = table.Column<short>(type: "smallint", nullable: false),
                    FoundedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Teams_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Stadiums_StadiumID",
                        column: x => x.StadiumID,
                        principalTable: "Stadiums",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Coachs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    CurrentTeamID = table.Column<int>(type: "int", nullable: false),
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
                name: "Contracts",
                columns: table => new
                {
                    PlayerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamID = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Salary = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.PlayerID);
                    table.ForeignKey(
                        name: "FK_Contracts_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matchs",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeTeamID = table.Column<int>(type: "int", nullable: false),
                    AwayTeamID = table.Column<int>(type: "int", nullable: false),
                    KickoffTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StadiumID = table.Column<short>(type: "smallint", nullable: false),
                    HomeTeamScore = table.Column<byte>(type: "tinyint", nullable: false),
                    AwayTeamScore = table.Column<byte>(type: "tinyint", nullable: false),
                    CompetitionID = table.Column<int>(type: "int", nullable: false),
                    Round = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StatusID = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matchs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Matchs_Competitions_CompetitionID",
                        column: x => x.CompetitionID,
                        principalTable: "Competitions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matchs_MatchStatuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "MatchStatuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matchs_Stadiums_StadiumID",
                        column: x => x.StadiumID,
                        principalTable: "Stadiums",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matchs_Teams_AwayTeamID",
                        column: x => x.AwayTeamID,
                        principalTable: "Teams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matchs_Teams_HomeTeamID",
                        column: x => x.HomeTeamID,
                        principalTable: "Teams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    ShirtNumber = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CurrentTeamID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Players_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Players_Teams_CurrentTeamID",
                        column: x => x.CurrentTeamID,
                        principalTable: "Teams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayerStatuses",
                columns: table => new
                {
                    PlayerID = table.Column<int>(type: "int", nullable: false),
                    Goals = table.Column<short>(type: "smallint", nullable: true),
                    Assists = table.Column<short>(type: "smallint", nullable: true),
                    RedCards = table.Column<byte>(type: "tinyint", nullable: true),
                    YellowCards = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStatuses", x => x.PlayerID);
                    table.ForeignKey(
                        name: "FK_PlayerStatuses_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransferRequests",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerID = table.Column<int>(type: "int", nullable: false),
                    FromTeamID = table.Column<int>(type: "int", nullable: false),
                    ToTeamID = table.Column<int>(type: "int", nullable: false),
                    TransferFee = table.Column<decimal>(type: "money", nullable: false),
                    ApplyingDate = table.Column<DateOnly>(type: "date", nullable: false),
                    StatusID = table.Column<short>(type: "smallint", nullable: false),
                    PDFDocument = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DecisionDate = table.Column<DateTime>(type: "Date", nullable: true)
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
                table: "Countries",
                columns: new[] { "ID", "Name", "Nationality" },
                values: new object[,]
                {
                    { (short)1, "Germany", "German" },
                    { (short)2, "Spain", "Spanish" },
                    { (short)3, "France", "French" },
                    { (short)4, "England", "English" },
                    { (short)5, "Italy", "Italian" },
                    { (short)6, "Portugal", "Portuguese" },
                    { (short)7, "Netherlands", "Dutch" },
                    { (short)8, "Belgium", "Belgian" },
                    { (short)9, "Russia", "Russian" },
                    { (short)10, "Turkey", "Turkish" },
                    { (short)11, "Argentina", "Argentine" },
                    { (short)12, "Brazil", "Brazilian" },
                    { (short)13, "Mexico", "Mexican" },
                    { (short)14, "USA", "American" },
                    { (short)15, "Scotland", "Scottish" },
                    { (short)16, "Greece", "Greek" },
                    { (short)17, "Switzerland", "Swiss" },
                    { (short)18, "Austria", "Austrian" },
                    { (short)19, "Denmark", "Danish" },
                    { (short)20, "Norway", "Norwegian" },
                    { (short)21, "Sweden", "Swedish" },
                    { (short)22, "Poland", "Polish" },
                    { (short)23, "Ukraine", "Ukrainian" },
                    { (short)24, "Serbia", "Serbian" },
                    { (short)25, "Croatia", "Croatian" },
                    { (short)26, "Czech Republic", "Czech" },
                    { (short)27, "Japan", "Japanese" },
                    { (short)28, "South Korea", "Korean" },
                    { (short)29, "China", "Chinese" },
                    { (short)30, "Australia", "Australian" },
                    { (short)31, "Saudi Arabia", "Saudi" },
                    { (short)32, "Egypt", "Egyptian" }
                });

            migrationBuilder.InsertData(
                table: "MatchStatuses",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[,]
                {
                    { (short)1, "The match is planned and scheduled to take place in the future.", "Scheduled" },
                    { (short)2, "The match is currently in progress.", "Live" },
                    { (short)3, "The match has ended and the final result is recorded.", "Finished" },
                    { (short)4, "The match was canceled and will not take place.", "Canceled" },
                    { (short)5, "The match has been temporarily stopped and will continue later; the time already played will still count.", "Postponed" }
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

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "ID", "CountryID", "Name" },
                values: new object[,]
                {
                    { (short)1, (short)1, "Berlin" },
                    { (short)2, (short)1, "Munich" },
                    { (short)3, (short)1, "Hamburg" },
                    { (short)4, (short)1, "Cologne" },
                    { (short)5, (short)1, "Frankfurt" },
                    { (short)6, (short)2, "Madrid" },
                    { (short)7, (short)2, "Barcelona" },
                    { (short)8, (short)2, "Valencia" },
                    { (short)9, (short)2, "Seville" },
                    { (short)10, (short)2, "Zaragoza" },
                    { (short)11, (short)3, "Paris" },
                    { (short)12, (short)3, "Marseille" },
                    { (short)13, (short)3, "Lyon" },
                    { (short)14, (short)3, "Toulouse" },
                    { (short)15, (short)3, "Nice" },
                    { (short)16, (short)4, "London" },
                    { (short)17, (short)4, "Birmingham" },
                    { (short)18, (short)4, "Manchester" },
                    { (short)19, (short)4, "Liverpool" },
                    { (short)20, (short)5, "Rome" },
                    { (short)21, (short)5, "Milan" },
                    { (short)22, (short)5, "Naples" },
                    { (short)23, (short)5, "Turin" },
                    { (short)24, (short)5, "Florence" },
                    { (short)25, (short)6, "Lisbon" },
                    { (short)26, (short)6, "Porto" },
                    { (short)27, (short)7, "Amsterdam" },
                    { (short)28, (short)7, "Rotterdam" },
                    { (short)29, (short)8, "Brussels" },
                    { (short)30, (short)8, "Antwerp" },
                    { (short)31, (short)9, "Moscow" },
                    { (short)32, (short)9, "Saint Petersburg" },
                    { (short)33, (short)9, "Kazan" },
                    { (short)34, (short)10, "Istanbul" },
                    { (short)35, (short)10, "Ankara" },
                    { (short)36, (short)10, "Izmir" },
                    { (short)37, (short)11, "Buenos Aires" },
                    { (short)38, (short)11, "Córdoba" },
                    { (short)39, (short)12, "São Paulo" },
                    { (short)40, (short)12, "Rio de Janeiro" },
                    { (short)41, (short)12, "Brasília" },
                    { (short)42, (short)12, "Salvador" },
                    { (short)43, (short)12, "Fortaleza" },
                    { (short)44, (short)13, "Mexico City" },
                    { (short)45, (short)13, "Guadalajara" },
                    { (short)46, (short)13, "Monterrey" },
                    { (short)47, (short)14, "New York" },
                    { (short)48, (short)14, "Los Angeles" },
                    { (short)49, (short)14, "Chicago" },
                    { (short)50, (short)14, "Houston" },
                    { (short)51, (short)14, "Miami" },
                    { (short)52, (short)15, "Edinburgh" },
                    { (short)53, (short)15, "Glasgow" },
                    { (short)54, (short)16, "Athens" },
                    { (short)55, (short)16, "Thessaloniki" },
                    { (short)56, (short)17, "Zurich" },
                    { (short)57, (short)17, "Geneva" },
                    { (short)58, (short)18, "Vienna" },
                    { (short)59, (short)18, "Salzburg" },
                    { (short)60, (short)19, "Copenhagen" },
                    { (short)61, (short)20, "Oslo" },
                    { (short)62, (short)21, "Stockholm" },
                    { (short)63, (short)21, "Gothenburg" },
                    { (short)64, (short)22, "Warsaw" },
                    { (short)65, (short)22, "Krakow" },
                    { (short)66, (short)23, "Kyiv" },
                    { (short)67, (short)23, "Lviv" },
                    { (short)68, (short)24, "Belgrade" },
                    { (short)69, (short)25, "Zagreb" },
                    { (short)70, (short)26, "Prague" },
                    { (short)71, (short)27, "Tokyo" },
                    { (short)72, (short)27, "Osaka" },
                    { (short)73, (short)27, "Kyoto" },
                    { (short)74, (short)27, "Yokohama" },
                    { (short)75, (short)27, "Nagoya" },
                    { (short)76, (short)28, "Seoul" },
                    { (short)77, (short)28, "Busan" },
                    { (short)78, (short)29, "Shanghai" },
                    { (short)79, (short)29, "Beijing" },
                    { (short)80, (short)29, "Guangzhou" },
                    { (short)81, (short)29, "Shenzhen" },
                    { (short)82, (short)29, "Chengdu" },
                    { (short)83, (short)30, "Sydney" },
                    { (short)84, (short)30, "Melbourne" },
                    { (short)85, (short)30, "Brisbane" },
                    { (short)86, (short)30, "Perth" },
                    { (short)87, (short)30, "Adelaide" },
                    { (short)88, (short)31, "Riyadh" },
                    { (short)89, (short)31, "Jeddah" },
                    { (short)90, (short)32, "Cairo" },
                    { (short)91, (short)32, "Alexandria" },
                    { (short)92, (short)4, "Sheffield" },
                    { (short)93, (short)5, "Bologna" },
                    { (short)94, (short)14, "Philadelphia" },
                    { (short)95, (short)14, "Dallas" },
                    { (short)96, (short)9, "Novosibirsk" },
                    { (short)97, (short)1, "Stuttgart" },
                    { (short)98, (short)3, "Bordeaux" },
                    { (short)99, (short)2, "Málaga" },
                    { (short)100, (short)12, "Curitiba" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryID",
                table: "Cities",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Name",
                table: "Cities",
                column: "Name",
                unique: true);

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
                name: "IX_Contracts_TeamID",
                table: "Contracts",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name",
                table: "Countries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Nationality",
                table: "Countries",
                column: "Nationality",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_AwayTeamID",
                table: "Matchs",
                column: "AwayTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_CompetitionID",
                table: "Matchs",
                column: "CompetitionID");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_HomeTeamID",
                table: "Matchs",
                column: "HomeTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_StadiumID",
                table: "Matchs",
                column: "StadiumID");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_StatusID",
                table: "Matchs",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_MatchStatuses_Description",
                table: "MatchStatuses",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MatchStatuses_Name",
                table: "MatchStatuses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_Name",
                table: "People",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_People_Photo",
                table: "People",
                column: "Photo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_CurrentTeamID",
                table: "Players",
                column: "CurrentTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PersonID",
                table: "Players",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Players_Position",
                table: "Players",
                column: "Position");

            migrationBuilder.CreateIndex(
                name: "IX_Stadiums_CityID",
                table: "Stadiums",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Stadiums_Name",
                table: "Stadiums",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CityID",
                table: "Teams",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Logo",
                table: "Teams",
                column: "Logo",
                unique: true,
                filter: "[Logo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Name",
                table: "Teams",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_StadiumID",
                table: "Teams",
                column: "StadiumID");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coachs");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Matchs");

            migrationBuilder.DropTable(
                name: "PlayerStatuses");

            migrationBuilder.DropTable(
                name: "TransferRequests");

            migrationBuilder.DropTable(
                name: "Competitions");

            migrationBuilder.DropTable(
                name: "MatchStatuses");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "TransferStatuses");

            migrationBuilder.DropTable(
                name: "CompetitionTypes");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Stadiums");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
