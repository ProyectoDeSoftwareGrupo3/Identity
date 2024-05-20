using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        var hasher = new PasswordHasher<ApplicationUser>();

        builder.HasData(
            new ApplicationUser
            {
                Id = "AAEF2C4F-DED7-4B1A-ADD3-9A3448B9E9E0",
                Email = "bravo.jose.luis18@gmail.com",
                NormalizedEmail = "BRAVO.JOSE.LUIS18@GMAIL.COM",
                FirstName = "Jose",
                LastName = "Bravo",
                UserName = "bravo.jose.luis18@gmail.com",
                NormalizedUserName = "BRAVO.JOSE.LUIS18@GMAIL.COM",
                PasswordHash = hasher.HashPassword(null, "GrupoAdmin3!"),
                EmailConfirmed = true,
                Address = "Calle 9 N° 2946",
                City = "Berazategui"
            },
            new ApplicationUser
            {
                Id = "FD9CB11E-76D6-4DEE-AAA3-921E983F36CA",
                Email = "alanleandrovargas03@gmail.com",
                NormalizedEmail = "ALANLEANDROVARGAS03@gmail.com",
                FirstName = "Alan",
                LastName = "Vargas",
                UserName = "alanleandrovargas03@gmail.com",
                NormalizedUserName = "ALANLEANDROVARGAS03@GMAIL.COM",
                PasswordHash = hasher.HashPassword(null, "GrupoAdmin3!"),
                EmailConfirmed = true,
                Address = "Calle Los Andes N° 3850",
                City = "Bernal"
            },
            new ApplicationUser
            {
                Id = "1D98B435-C2C4-44D7-B1B2-AB229DE2ACED",
                Email = "luciaoses1997@gmail.com",
                NormalizedEmail = "LUCIAOSES1997@GMAIL.COM",
                FirstName = "Lucia",
                LastName = "Oses",
                UserName = "luciaoses1997@gmail.com",
                NormalizedUserName = "LUCIAOSES1997@GMAIL.COM",
                PasswordHash = hasher.HashPassword(null, "GrupoAdmin3!"),
                EmailConfirmed = true,
                Address = "Calle Grecia N°1234",
                City = "Florencio Varela"
            },
            new ApplicationUser
            {
                Id = "3D0F1848-5354-4CED-A125-525218044370",
                Email = "diegorolon01@outlook.com",
                NormalizedEmail = "DIEGOROLON01@OUTLOOK.COM",
                FirstName = "Diego",
                LastName = "Rolon",
                UserName = "diegorolon01@outlook.com",
                NormalizedUserName = "DIEGOROLON01@OUTLOOK.COM",
                PasswordHash = hasher.HashPassword(null, "GrupoAdmin3!"),
                EmailConfirmed = true,
                Address = "Viena n°1057",
                City = "Florencio Varela"
            },
            new ApplicationUser
            {
                Id = "19BB7F59-3372-433F-B343-00E75953D3A3",
                Email = "francopalacio03@gmail.com",
                NormalizedEmail = "FRANCOPALACIO03@GMAIL.COM",
                FirstName = "Franco",
                LastName = "Palacio",
                UserName = "francopalacio03@gmail.com",
                NormalizedUserName = "FRANCOPALACIO03@GMAIL.COM",
                PasswordHash = hasher.HashPassword(null, "GrupoAdmin3!"),
                EmailConfirmed = true,
                Address = "Adolfo Alsina 1238",
                City = "Florencio Varela"
            }
            );
    }
}
