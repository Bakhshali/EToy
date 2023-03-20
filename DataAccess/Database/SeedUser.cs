using Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Database
{
    public static class SeedUser
    {
        public static void AddSeedUser(this ModelBuilder modelBuilder)
        {
            const string userId = "0f8fad5b-d9cb-469f-a165-70867728950e";
            const string roleId = "0f8za25b-t9cb-469f-a165-708677289502";

            var user = new ApplicationUser()
            {
                Id = userId,
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "Admin@gmail.com",
                NormalizedEmail = "admin@GMAIL.COM"
            };

            var ph = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = ph.HashPassword(user, "Admin1234");

            var role = new ApplicationRole()
            {
                Id = roleId,
                Name = "Admin",
                NormalizedName = "ADMIN",
                Rank = 1
            };

            var userRole = new ApplicationUserRole()
            {
                RoleId = roleId,
                UserId = userId
            };

            var claim = new IdentityRoleClaim<string>()
            {
                Id = 1,
                RoleId = role.Id,
                ClaimValue = "Role",
                ClaimType = "Role"
            };


            modelBuilder.Entity<ApplicationUser>().HasData(user);
            modelBuilder.Entity<ApplicationRole>().HasData(role);
            modelBuilder.Entity<ApplicationUserRole>().HasData(userRole);
            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(claim);
        }
    }
}
