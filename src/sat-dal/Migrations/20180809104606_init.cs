using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sat_dal.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameSchemas",
                columns: table => new
                {
                    AppId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    LastSchemaUpdate = table.Column<DateTime>(nullable: false),
                    HasAchievements = table.Column<bool>(nullable: false),
                    HasCommunityVisibleStats = table.Column<bool>(nullable: false),
                    AvgUnlock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSchemas", x => x.AppId);
                });

            migrationBuilder.CreateTable(
                name: "PlayerProfiles",
                columns: table => new
                {
                    SteamId = table.Column<long>(nullable: false),
                    PersonaName = table.Column<string>(maxLength: 250, nullable: false),
                    RealName = table.Column<string>(maxLength: 250, nullable: false),
                    AvatarFull = table.Column<string>(maxLength: 250, nullable: false),
                    ProfileUrl = table.Column<string>(maxLength: 250, nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    LibraryLastUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerProfiles", x => x.SteamId);
                });

            migrationBuilder.CreateTable(
                name: "GameAchievements",
                columns: table => new
                {
                    AppId = table.Column<long>(maxLength: 250, nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Description = table.Column<string>(maxLength: 350, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 250, nullable: false),
                    Hidden = table.Column<bool>(nullable: false),
                    Icon = table.Column<string>(maxLength: 250, nullable: false),
                    IconGray = table.Column<string>(nullable: true),
                    Percent = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameAchievements", x => new { x.AppId, x.Name });
                    table.ForeignKey(
                        name: "FK_GameAchievements_GameSchemas_AppId",
                        column: x => x.AppId,
                        principalTable: "GameSchemas",
                        principalColumn: "AppId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayerGames",
                columns: table => new
                {
                    SteamId = table.Column<long>(nullable: false),
                    AppID = table.Column<long>(nullable: false),
                    PlaytimeForever = table.Column<decimal>(nullable: false),
                    Playtime2weeks = table.Column<decimal>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    AchievementRefresh = table.Column<DateTime>(nullable: false),
                    RefreshAchievements = table.Column<bool>(nullable: false),
                    AchievementsEarned = table.Column<int>(nullable: false),
                    AchievementsLocked = table.Column<int>(nullable: false),
                    TotalAchievements = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGames", x => new { x.AppID, x.SteamId });
                    table.ForeignKey(
                        name: "FK_PlayerGames_GameSchemas_AppID",
                        column: x => x.AppID,
                        principalTable: "GameSchemas",
                        principalColumn: "AppId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerGames_PlayerProfiles_SteamId",
                        column: x => x.SteamId,
                        principalTable: "PlayerProfiles",
                        principalColumn: "SteamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfileRecentGames",
                columns: table => new
                {
                    SteamId = table.Column<long>(nullable: false),
                    AppId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileRecentGames", x => new { x.SteamId, x.AppId });
                    table.ForeignKey(
                        name: "FK_ProfileRecentGames_GameSchemas_AppId",
                        column: x => x.AppId,
                        principalTable: "GameSchemas",
                        principalColumn: "AppId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfileRecentGames_PlayerProfiles_SteamId",
                        column: x => x.SteamId,
                        principalTable: "PlayerProfiles",
                        principalColumn: "SteamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayerGameAchievements",
                columns: table => new
                {
                    SteamId = table.Column<long>(nullable: false),
                    AppID = table.Column<long>(nullable: false),
                    ApiName = table.Column<string>(maxLength: 250, nullable: false),
                    Achieved = table.Column<bool>(nullable: false),
                    UnlockTimestamp = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGameAchievements", x => new { x.SteamId, x.AppID, x.ApiName });
                    table.ForeignKey(
                        name: "FK_PlayerGameAchievements_PlayerProfiles_SteamId",
                        column: x => x.SteamId,
                        principalTable: "PlayerProfiles",
                        principalColumn: "SteamId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerGameAchievements_PlayerGames_AppID_SteamId",
                        columns: x => new { x.AppID, x.SteamId },
                        principalTable: "PlayerGames",
                        principalColumns: new[] { "AppID", "SteamId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGameAchievements_AppID_SteamId",
                table: "PlayerGameAchievements",
                columns: new[] { "AppID", "SteamId" });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_SteamId",
                table: "PlayerGames",
                column: "SteamId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileRecentGames_AppId",
                table: "ProfileRecentGames",
                column: "AppId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameAchievements");

            migrationBuilder.DropTable(
                name: "PlayerGameAchievements");

            migrationBuilder.DropTable(
                name: "ProfileRecentGames");

            migrationBuilder.DropTable(
                name: "PlayerGames");

            migrationBuilder.DropTable(
                name: "GameSchemas");

            migrationBuilder.DropTable(
                name: "PlayerProfiles");
        }
    }
}
