﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using sat_dal;
using System;

namespace sat_dal.Migrations
{
    [DbContext(typeof(ModelContext))]
    partial class ModelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("sat_dal.Models.GameAchievement", b =>
                {
                    b.Property<long>("AppId")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .HasMaxLength(250);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(350);

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<bool>("Hidden");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("IconGray");

                    b.Property<double>("Percent");

                    b.HasKey("AppId", "Name");

                    b.ToTable("GameAchievements");
                });

            modelBuilder.Entity("sat_dal.Models.GameSchema", b =>
                {
                    b.Property<long>("AppId");

                    b.Property<int>("AvgUnlock");

                    b.Property<bool>("HasAchievements");

                    b.Property<bool>("HasCommunityVisibleStats");

                    b.Property<DateTime>("LastSchemaUpdate");

                    b.Property<string>("Name")
                        .HasMaxLength(250);

                    b.HasKey("AppId");

                    b.ToTable("GameSchemas");
                });

            modelBuilder.Entity("sat_dal.Models.PlayerGame", b =>
                {
                    b.Property<long>("AppID");

                    b.Property<long>("SteamId");

                    b.Property<DateTime>("AchievementRefresh");

                    b.Property<int>("AchievementsEarned");

                    b.Property<int>("AchievementsLocked");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<decimal>("Playtime2weeks");

                    b.Property<decimal>("PlaytimeForever");

                    b.Property<bool>("RefreshAchievements");

                    b.Property<int>("TotalAchievements");

                    b.HasKey("AppID", "SteamId");

                    b.HasIndex("SteamId");

                    b.ToTable("PlayerGames");
                });

            modelBuilder.Entity("sat_dal.Models.PlayerGameAchievement", b =>
                {
                    b.Property<long>("SteamId");

                    b.Property<long>("AppID");

                    b.Property<string>("ApiName")
                        .HasMaxLength(250);

                    b.Property<bool>("Achieved");

                    b.Property<DateTime?>("UnlockTimestamp");

                    b.HasKey("SteamId", "AppID", "ApiName");

                    b.HasIndex("AppID", "SteamId");

                    b.ToTable("PlayerGameAchievements");
                });

            modelBuilder.Entity("sat_dal.Models.PlayerProfile", b =>
                {
                    b.Property<long>("SteamId");

                    b.Property<string>("AvatarFull")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<DateTime>("LastUpdate");

                    b.Property<DateTime>("LibraryLastUpdate");

                    b.Property<string>("PersonaName")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("ProfileUrl")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("RealName")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("SteamId");

                    b.ToTable("PlayerProfiles");
                });

            modelBuilder.Entity("sat_dal.Models.ProfileRecentGame", b =>
                {
                    b.Property<long>("SteamId");

                    b.Property<long>("AppId");

                    b.HasKey("SteamId", "AppId");

                    b.HasIndex("AppId");

                    b.ToTable("ProfileRecentGames");
                });

            modelBuilder.Entity("sat_dal.Models.GameAchievement", b =>
                {
                    b.HasOne("sat_dal.Models.GameSchema", "GameSchema")
                        .WithMany("GameAchievements")
                        .HasForeignKey("AppId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("sat_dal.Models.PlayerGame", b =>
                {
                    b.HasOne("sat_dal.Models.GameSchema", "GameSchema")
                        .WithMany("PlayerGames")
                        .HasForeignKey("AppID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("sat_dal.Models.PlayerProfile", "PlayerProfile")
                        .WithMany("PlayerGames")
                        .HasForeignKey("SteamId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("sat_dal.Models.PlayerGameAchievement", b =>
                {
                    b.HasOne("sat_dal.Models.PlayerProfile", "PlayerProfile")
                        .WithMany("PlayerGameAchievements")
                        .HasForeignKey("SteamId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("sat_dal.Models.PlayerGame", "PlayerGame")
                        .WithMany("PlayerGameAchievements")
                        .HasForeignKey("AppID", "SteamId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("sat_dal.Models.ProfileRecentGame", b =>
                {
                    b.HasOne("sat_dal.Models.GameSchema", "GameSchema")
                        .WithMany()
                        .HasForeignKey("AppId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("sat_dal.Models.PlayerProfile", "PlayerProfile")
                        .WithMany("PlayerRecentGames")
                        .HasForeignKey("SteamId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
