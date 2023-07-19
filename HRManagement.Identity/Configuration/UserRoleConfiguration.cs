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
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                //User
                new IdentityUserRole<string>
                {
                    
                    RoleId= "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                    UserId= "90bh10o0-mco4-sh48-an48vprlod"
                   
                },
                //Admin
                new IdentityUserRole<string>
                {
                    RoleId= "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                    UserId= "89ko9l03-j49c-9340-njd8940koq"
                }
                );
        }
    }
}
