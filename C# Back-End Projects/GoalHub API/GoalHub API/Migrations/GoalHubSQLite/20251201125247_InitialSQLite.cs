using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GoalHub_API.Migrations.GoalHubSQLite
{
    /// <inheritdoc />
    public partial class InitialSQLite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    ID = table.Column<short>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Nationality = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MatchStatuses",
                columns: table => new
                {
                    ID = table.Column<short>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchStatuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    ID = table.Column<short>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CountryID = table.Column<short>(type: "INTEGER", nullable: false)
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
                name: "People",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "Date", nullable: false),
                    CountryID = table.Column<short>(type: "INTEGER", nullable: false),
                    ImageFileName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Gender = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.ID);
                    table.ForeignKey(
                        name: "FK_People_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stadiums",
                columns: table => new
                {
                    ID = table.Column<short>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Capacity = table.Column<int>(type: "INTEGER", nullable: false),
                    CityID = table.Column<short>(type: "INTEGER", nullable: false)
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
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Abbreviation = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    CityID = table.Column<short>(type: "INTEGER", nullable: false),
                    StadiumID = table.Column<short>(type: "INTEGER", nullable: false),
                    FoundedDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Logo = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
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
                name: "Matchs",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HomeTeamID = table.Column<int>(type: "INTEGER", nullable: false),
                    AwayTeamID = table.Column<int>(type: "INTEGER", nullable: false),
                    KickoffTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StadiumID = table.Column<short>(type: "INTEGER", nullable: false),
                    HomeTeamScore = table.Column<byte>(type: "INTEGER", nullable: false),
                    AwayTeamScore = table.Column<byte>(type: "INTEGER", nullable: false),
                    Round = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    StatusID = table.Column<short>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matchs", x => x.ID);
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
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonID = table.Column<int>(type: "INTEGER", nullable: false),
                    ShirtNumber = table.Column<byte>(type: "INTEGER", nullable: false),
                    Position = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    CurrentTeamID = table.Column<int>(type: "INTEGER", nullable: false)
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
                    PlayerID = table.Column<int>(type: "INTEGER", nullable: false),
                    Goals = table.Column<short>(type: "INTEGER", nullable: true),
                    Assists = table.Column<short>(type: "INTEGER", nullable: true),
                    RedCards = table.Column<byte>(type: "INTEGER", nullable: true),
                    YellowCards = table.Column<byte>(type: "INTEGER", nullable: true)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "581bfa23-7af2-4544-9610-2e96a93f6ff6", null, "Data Analyst", "DATA ANALYST" },
                    { "591c371d-98b0-4f4e-9fb1-45edf31a5628", null, "Administrator", "ADMINISTRATOR" },
                    { "867525eb-2a9c-4418-8e9d-484c6316c18d", null, "Match Viewer", "MATCH VIEWER" },
                    { "8b415ac6-a0ec-488e-a154-eed27853d4e5", null, "Match Manager", "MATCH MANAGER" },
                    { "8b4c18de-6ffc-4caa-aac4-13932ec8f5e5", null, "Manager", "MANAGER" },
                    { "a7be3427-8f34-42e4-b496-ec040e79faed", null, "Team Manager", "TEAM MANAGER" },
                    { "e2fc56c1-6f65-4a58-96a4-0441532cb0b3", null, "Player Manager", "PLAYER MANAGER" }
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

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
                name: "IX_People_CountryID",
                table: "People",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_People_ImageFileName",
                table: "People",
                column: "ImageFileName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_Name",
                table: "People",
                column: "Name");

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Name",
                table: "Teams",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_StadiumID",
                table: "Teams",
                column: "StadiumID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Matchs");

            migrationBuilder.DropTable(
                name: "PlayerStatuses");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "MatchStatuses");

            migrationBuilder.DropTable(
                name: "Players");

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
