using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace sat_dal.Migrations
{
    public partial class stuff3333 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgIconUrl",
                table: "GameSchemas");

            migrationBuilder.DropColumn(
                name: "ImgLogoUrl",
                table: "GameSchemas");

            //migrationBuilder.AlterColumn<long>(
            //    name: "SteamId",
            //    table: "PlayerProfiles",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "SteamId",
                table: "PlayerProfiles",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "ImgIconUrl",
                table: "GameSchemas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgLogoUrl",
                table: "GameSchemas",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }
    }
}
