using HRManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Identity.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id="89ko9l03-j49c-9340-njd8940koq",
                    Email="admin@localhost.com",
                    NormalizedEmail="ADMIN@LOCALHOST.COM",
                    FirstName="System",
                    LastName="Admin",
                    UserName= "admin@localhost.com",
                    NormalizedUserName= "ADMIN@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(null,"Q@werty1234"),
                    EmailConfirmed= true,
                },

                new ApplicationUser
                {
                    Id="90bh10o0-mco4-sh48-an48vprlod",
                    Email="user@localhost.com",
                    NormalizedEmail="USER@LOCALHOST.COM",
                    FirstName="System",
                    LastName="User",
                    UserName= "user@localhost.com",
                    NormalizedUserName= "USER@LOCALHOST.COM",
                    PasswordHash= hasher.HashPassword(null,"Q@werty1234"),
                    EmailConfirmed= true,
                }

                );
        }
    }
}
