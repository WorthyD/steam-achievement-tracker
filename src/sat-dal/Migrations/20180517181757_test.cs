using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace sat_dal.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Playtime_Forever",
                table: "PlayerGames",
                newName: "PlaytimeForever");

            migrationBuilder.RenameColumn(
                name: "Playtime_2weeks",
                table: "PlayerGames",
                newName: "Playtime2weeks");

            migrationBuilder.RenameColumn(
                name: "has_community_visible_stats",
                table: "GameSchemas",
                newName: "HasCommunityVisibleStats");

            migrationBuilder.RenameColumn(
                name: "Img_Logo_Url",
                table: "GameSchemas",
                newName: "ImgLogoUrl");

            migrationBuilder.RenameColumn(
                name: "Img_Icon_Url",
                table: "GameSchemas",
                newName: "ImgIconUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlaytimeForever",
                table: "PlayerGames",
                newName: "Playtime_Forever");

            migrationBuilder.RenameColumn(
                name: "Playtime2weeks",
                table: "PlayerGames",
                newName: "Playtime_2weeks");

            migrationBuilder.RenameColumn(
                name: "ImgLogoUrl",
                table: "GameSchemas",
                newName: "Img_Logo_Url");

            migrationBuilder.RenameColumn(
                name: "ImgIconUrl",
                table: "GameSchemas",
                newName: "Img_Icon_Url");

            migrationBuilder.RenameColumn(
                name: "HasCommunityVisibleStats",
                table: "GameSchemas",
                newName: "has_community_visible_stats");
        }
    }
}
