using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Runtime.ConstrainedExecution;

namespace Infrastructure.Configuration;

public class UserRolesConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        var hasher = new PasswordHasher<IdentityUserRole<string>>();

        builder.HasData(
            new IdentityUserRole<string>
            {
                RoleId = "DCD3F190-A5F0-4A75-8E2C-095CBED0B551",
                UserId = "AAEF2C4F-DED7-4B1A-ADD3-9A3448B9E9E0"
            },
            new IdentityUserRole<string>
            {
                RoleId = "DCD3F190-A5F0-4A75-8E2C-095CBED0B551",
                UserId = "FD9CB11E-76D6-4DEE-AAA3-921E983F36CA"
            },
            new IdentityUserRole<string>
            {
                RoleId = "DCD3F190-A5F0-4A75-8E2C-095CBED0B551",
                UserId = "1D98B435-C2C4-44D7-B1B2-AB229DE2ACED"
            },
            new IdentityUserRole<string>
            {
                RoleId = "DCD3F190-A5F0-4A75-8E2C-095CBED0B551",
                UserId = "3D0F1848-5354-4CED-A125-525218044370"
            },
            new IdentityUserRole<string>
            {
                RoleId = "DCD3F190-A5F0-4A75-8E2C-095CBED0B551",
                UserId = "19BB7F59-3372-433F-B343-00E75953D3A3"
            }
            );
    }
}
