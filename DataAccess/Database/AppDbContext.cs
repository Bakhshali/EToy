using Domain.Model;
using Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Database
{
    public class AppDbContext :

     IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

       
        public DbSet<CategoryOfClothes> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Clothes> Clothes { get; set; }
        public DbSet<ClothesColor> ClothesColors { get; set; }
        public DbSet<ClothesImage> ClothesImages { get; set; }
        public DbSet<ClothesSize> ClothesSizes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Industrial> Industrials { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<ModelOfClothes> Models { get; set; }
        public DbSet<Neckline> Necklines { get; set; }
        public DbSet<Palace> Palaces { get; set; }
        public DbSet<PalaceImage> PalaceImages { get; set; }
        public DbSet<PalaceMeasure> PalaceMeasures { get; set; }
        public DbSet<PalaceService> PalaceServices { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Silhouette> Silhouettes { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Textile> Textiles { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PalaceMeasure>().HasKey(c => new { c.PalaceId, c.MeasureId });
            builder.Entity<PalaceService>().HasKey(c => new { c.PalaceId, c.ServiceId });
            builder.Entity<ClothesColor>().HasKey(c => new { c.ClothesId, c.ColorId });
            builder.Entity<ClothesSize>().HasKey(c => new { c.ClothesId, c.SizeId });

            //builder.Entity<Palace>().HasIndex(c=>c.SeoUrl).IsUnique();

            builder.Entity<PalaceMeasure>().HasOne(c => c.Palace).WithMany(c => c.MeasuresOfPalaces).HasForeignKey(c => c.PalaceId);
            builder.Entity<PalaceMeasure>().HasOne(c => c.Measure).WithMany(c => c.MeasuresOfPalaces).HasForeignKey(c => c.MeasureId);

            builder.Entity<PalaceService>().HasOne(c => c.Palace).WithMany(c => c.ServicesOfPalaces).HasForeignKey(c => c.PalaceId);
            builder.Entity<PalaceService>().HasOne(c => c.Service).WithMany(c => c.ServicesOfPalaces).HasForeignKey(c => c.ServiceId);

            builder.Entity<ClothesColor>().HasOne(c => c.Clothes).WithMany(c => c.ColorOfClothes).HasForeignKey(c => c.ClothesId);
            builder.Entity<ClothesColor>().HasOne(c => c.Color).WithMany(c => c.ColorOfClothes).HasForeignKey(c => c.ColorId);

            builder.Entity<ClothesSize>().HasOne(c => c.Clothes).WithMany(c => c.SizeOfClothes).HasForeignKey(c => c.ClothesId);
            builder.Entity<ClothesSize>().HasOne(c => c.Size).WithMany(c => c.ClothesSize).HasForeignKey(c => c.SizeId);


            builder.Entity<ApplicationUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
            builder.AddSeedUser();
        }
    }
}
