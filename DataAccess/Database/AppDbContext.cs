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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PalaceMeasure>().HasKey(c => new { c.PalaceId, c.MeasureId });
            builder.Entity<PalaceService>().HasKey(c => new { c.PalaceId, c.ServiceId });
            builder.Entity<ClothesColor>().HasKey(c => new { c.ClothesId, c.ColorId });
            builder.Entity<ClothesSize>().HasKey(c => new { c.ClothesId, c.SizeId });


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

        }
    }
}
