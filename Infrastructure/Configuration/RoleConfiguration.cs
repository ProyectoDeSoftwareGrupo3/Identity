using Domain.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole { Id = "DCD3F190-A5F0-4A75-8E2C-095CBED0B551", Name = Roles.Administrador, ConcurrencyStamp = "1", NormalizedName = Roles.Administrador.ToUpper() },
            new IdentityRole { Id = "3A6F1076-6B34-4251-83D9-E2C71519F402", Name = Roles.Refugio, ConcurrencyStamp = "2", NormalizedName = Roles.Refugio.ToUpper() },
            new IdentityRole { Id = "05456319-A1AD-4AF9-B68B-7B6FD4161A7F", Name = Roles.Miembro, ConcurrencyStamp = "3", NormalizedName = Roles.Miembro.ToUpper() }
            );
    }
}
