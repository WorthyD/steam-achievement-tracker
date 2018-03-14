using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.Entity;
//using System.Data.Entity.ModelConfiguration.Conventions;
using sat_dal.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace sat_dal
{
    public class ModelContext : DbContext, IDisposable
    {
        public static string Connection
        {
            get
            {

                return "DefaultConnection";
            }
        }
        public ModelContext(DbContextOptions options) : base(options)
        {
            //Database.SetInitializer<ModelContext>(null);
        }


        public DbSet<PlayerGame> PlayerGames { get; set; }
        //public DbSet<Models.PlayerGameTags> PlayerGameTags { get; set; }
        public DbSet<PlayerProfile> PlayerProfiles { get; set; }
        public DbSet<ProfileRecentGame> ProfileRecentGames { get; set; }

        public DbSet<PlayerGameAchievement> PlayerGameAchievements { get; set; }
        public DbSet<GameAchievement> GameAchievements { get; set; }
        public DbSet<GameSchema> GameSchemas { get; set; }

        ////protected override void OnModelCreating(DbModelBuilder modelBuilder)
        ////{
        ////    //base.OnModelCreating(modelBuilder);
        ////    //modelBuilder.Entity<aspnet_UsersInRoles>().HasMany(i => i.Users).WithRequired().WillCascadeOnDelete(false);
        ////}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //builder.
            var dbOption = DatabaseGeneratedOption.None;

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //builder.Entity<GameAchievement>().Property(c => c.AppId).HasDatabaseGeneratedOption().HasColumnOrder(10).IsRequired().HasMaxLength(250);
            builder.Entity<GameAchievement>().HasKey(c => new { c.AppId, c.Name });
            builder.Entity<GameAchievement>().Property(c => c.AppId).IsRequired().HasMaxLength(250);
            builder.Entity<GameAchievement>().Property(c => c.Name).IsRequired().HasMaxLength(250);
            builder.Entity<GameAchievement>().Property(c => c.Icon).IsRequired().HasMaxLength(250);
            builder.Entity<GameAchievement>().Property(c => c.DisplayName).IsRequired().HasMaxLength(250);
            builder.Entity<GameAchievement>().Property(c => c.Description).IsRequired().HasMaxLength(350);


            builder.Entity<GameSchema>().HasKey(c => new { c.AppId });
            builder.Entity<GameSchema>().Property(c => c.AppId).IsRequired();
            builder.Entity<GameSchema>().Property(c => c.Name).IsRequired().HasMaxLength(250);
            builder.Entity<GameSchema>().Property(c => c.LastSchemaUpdate).IsRequired();
            builder.Entity<GameSchema>().Property(c => c.HasAchievements).IsRequired();
            builder.Entity<GameSchema>().Property(c => c.ImgLogoUrl).IsRequired().HasMaxLength(250);
            builder.Entity<GameSchema>().Property(c => c.HasCommunityVisibleStats).IsRequired();
            builder.Entity<GameSchema>().Property(c => c.AvgUnlock).IsRequired();
            builder.Entity<GameSchema>().HasMany(c => c.GameAchievements);
            builder.Entity<GameSchema>().HasMany(c => c.PlayerGames);


            builder.Entity<PlayerGame>().HasKey(c => new { c.AppID, c.SteamId });
            //builder.Entity<PlayerGame>().Property(c => c.Name).IsRequired().HasMaxLength(250);
            builder.Entity<PlayerGame>().Property(c => c.AppID).IsRequired();
            builder.Entity<PlayerGame>().Property(c => c.SteamId).IsRequired();
            builder.Entity<PlayerGame>().Property(c => c.PlaytimeForever).IsRequired();
            builder.Entity<PlayerGame>().Property(c => c.Playtime2weeks).IsRequired();
            builder.Entity<PlayerGame>().Property(c => c.LastUpdated).IsRequired();
            builder.Entity<PlayerGame>().Property(c => c.AchievementRefresh).IsRequired();
            builder.Entity<PlayerGame>().Property(c => c.RefreshAchievements).IsRequired();
            builder.Entity<PlayerGame>().Property(c => c.AchievementsEarned).IsRequired();
            builder.Entity<PlayerGame>().Property(c => c.TotalAchievements).IsRequired();
            builder.Entity<PlayerGame>().HasMany(c => c.PlayerGameAchievements);



            builder.Entity<PlayerGameAchievement>().HasKey(c => new { c.SteamId, c.AppID, c.ApiName });
            //builder.Entity<PlayerGameAchievement>().HasMany(i => i.PlayerGame).WithRequired().WillCascadeOnDelete(false);
            //builder.Entity<PlayerGameAchievement>().HasMany(i => i.PlayerProfile).WithRequired().WillCascadeOnDelete(false);
            builder.Entity<PlayerGameAchievement>().Property(c => c.SteamId).IsRequired();
            builder.Entity<PlayerGameAchievement>().Property(c => c.AppID).IsRequired();
            builder.Entity<PlayerGameAchievement>().Property(c => c.ApiName).HasMaxLength(250).IsRequired();
            builder.Entity<PlayerGameAchievement>().Property(c => c.Achieved).IsRequired();



            builder.Entity<PlayerProfile>().HasKey(c => new { c.SteamId });
            builder.Entity<PlayerProfile>().Property(c => c.SteamId).IsRequired();
            builder.Entity<PlayerProfile>().Property(c => c.PersonaName).IsRequired().HasMaxLength(250);
            builder.Entity<PlayerProfile>().Property(c => c.RealName).IsRequired().HasMaxLength(250);
            builder.Entity<PlayerProfile>().Property(c => c.AvatarFull).IsRequired().HasMaxLength(250);
            builder.Entity<PlayerProfile>().Property(c => c.ProfileUrl).IsRequired().HasMaxLength(250);
            builder.Entity<PlayerProfile>().Property(c => c.LastUpdate).IsRequired();
            builder.Entity<PlayerProfile>().Property(c => c.LibraryLastUpdate).IsRequired();
            builder.Entity<PlayerProfile>().HasMany(c => c.PlayerGames);
            builder.Entity<PlayerProfile>().HasMany(c => c.PlayerRecentGames);
            builder.Entity<PlayerProfile>().HasMany(c => c.PlayerGameAchievements);


            builder.Entity<ProfileRecentGame>().HasKey(c => new { c.SteamId, c.AppId });
            builder.Entity<ProfileRecentGame>().Property(c => c.SteamId).IsRequired();
            builder.Entity<ProfileRecentGame>().Property(c => c.AppId).IsRequired();

            //builder.Entity<ApplicationUser>().HasMany(u => u.Claims).WithOne().HasForeignKey(c => c.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<ApplicationUser>().HasMany(u => u.Roles).WithOne().HasForeignKey(r => r.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<ApplicationRole>().HasMany(r => r.Claims).WithOne().HasForeignKey(c => c.RoleId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            //builder.Entity<ApplicationRole>().HasMany(r => r.Users).WithOne().HasForeignKey(r => r.RoleId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<Customer>().Property(c => c.Name).IsRequired().HasMaxLength(100);
            //builder.Entity<Customer>().HasIndex(c => c.Name);
            //builder.Entity<Customer>().Property(c => c.Email).HasMaxLength(100);
            //builder.Entity<Customer>().Property(c => c.PhoneNumber).IsUnicode(false).HasMaxLength(30);
            //builder.Entity<Customer>().Property(c => c.City).HasMaxLength(50);
            //builder.Entity<Customer>().ToTable($"App{nameof(this.Customers)}");

            //builder.Entity<ProductCategory>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            //builder.Entity<ProductCategory>().Property(p => p.Description).HasMaxLength(500);
            //builder.Entity<ProductCategory>().ToTable($"App{nameof(this.ProductCategories)}");

            //builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            //builder.Entity<Product>().HasIndex(p => p.Name);
            //builder.Entity<Product>().Property(p => p.Description).HasMaxLength(500);
            //builder.Entity<Product>().Property(p => p.Icon).IsUnicode(false).HasMaxLength(256);
            //builder.Entity<Product>().HasOne(p => p.Parent).WithMany(p => p.Children).OnDelete(DeleteBehavior.Restrict);
            //builder.Entity<Product>().ToTable($"App{nameof(this.Products)}");

            //builder.Entity<Order>().Property(o => o.Comments).HasMaxLength(500);
            //builder.Entity<Order>().ToTable($"App{nameof(this.Orders)}");

            //builder.Entity<OrderDetail>().ToTable($"App{nameof(this.OrderDetails)}");
        }

    }
}
