using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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
        public ModelContext() : base("DefaultConnection")
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
        //protected override void OnModelCreating(DbModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    //builder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        //    var dbOption = DatabaseGeneratedOption.None;

        //    //builder.Entity<GameAchievement>().Property(c => c.AppId).HasDatabaseGeneratedOption().HasColumnOrder(10).IsRequired().HasMaxLength(250);
        //    builder.Entity<GameAchievement>().Property(c => c.AppId).HasDatabaseGeneratedOption(dbOption).HasColumnOrder(10).IsRequired().HasMaxLength(250);
        //    builder.Entity<GameAchievement>().Property(c => c.Name).HasColumnOrder(10).IsRequired().HasMaxLength(250);
        //    builder.Entity<GameAchievement>().Property(c => c.Description).IsRequired().HasMaxLength(350);


        //    //builder.Entity<ApplicationUser>().HasMany(u => u.Claims).WithOne().HasForeignKey(c => c.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);

        //    //builder.Entity<ApplicationUser>().HasMany(u => u.Roles).WithOne().HasForeignKey(r => r.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);

        //    //builder.Entity<ApplicationRole>().HasMany(r => r.Claims).WithOne().HasForeignKey(c => c.RoleId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        //    //builder.Entity<ApplicationRole>().HasMany(r => r.Users).WithOne().HasForeignKey(r => r.RoleId).IsRequired().OnDelete(DeleteBehavior.Cascade);

        //    //builder.Entity<Customer>().Property(c => c.Name).IsRequired().HasMaxLength(100);
        //    //builder.Entity<Customer>().HasIndex(c => c.Name);
        //    //builder.Entity<Customer>().Property(c => c.Email).HasMaxLength(100);
        //    //builder.Entity<Customer>().Property(c => c.PhoneNumber).IsUnicode(false).HasMaxLength(30);
        //    //builder.Entity<Customer>().Property(c => c.City).HasMaxLength(50);
        //    //builder.Entity<Customer>().ToTable($"App{nameof(this.Customers)}");

        //    //builder.Entity<ProductCategory>().Property(p => p.Name).IsRequired().HasMaxLength(100);
        //    //builder.Entity<ProductCategory>().Property(p => p.Description).HasMaxLength(500);
        //    //builder.Entity<ProductCategory>().ToTable($"App{nameof(this.ProductCategories)}");

        //    //builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(100);
        //    //builder.Entity<Product>().HasIndex(p => p.Name);
        //    //builder.Entity<Product>().Property(p => p.Description).HasMaxLength(500);
        //    //builder.Entity<Product>().Property(p => p.Icon).IsUnicode(false).HasMaxLength(256);
        //    //builder.Entity<Product>().HasOne(p => p.Parent).WithMany(p => p.Children).OnDelete(DeleteBehavior.Restrict);
        //    //builder.Entity<Product>().ToTable($"App{nameof(this.Products)}");

        //    //builder.Entity<Order>().Property(o => o.Comments).HasMaxLength(500);
        //    //builder.Entity<Order>().ToTable($"App{nameof(this.Orders)}");

        //    //builder.Entity<OrderDetail>().ToTable($"App{nameof(this.OrderDetails)}");
        //}

    }
}
