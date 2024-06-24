using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "05456319-A1AD-4AF9-B68B-7B6FD4161A7F", "3", "Miembro", "MIEMBRO" },
                    { "3A6F1076-6B34-4251-83D9-E2C71519F402", "2", "Refugio", "REFUGIO" },
                    { "DCD3F190-A5F0-4A75-8E2C-095CBED0B551", "1", "Administrador", "ADMINISTRADOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "19BB7F59-3372-433F-B343-00E75953D3A3", 0, "Adolfo Alsina 1238", "Florencio Varela", "39e3f8f3-ee5f-4d53-be11-d1908474329b", "francopalacio03@gmail.com", true, "Franco", "Palacio", false, null, "FRANCOPALACIO03@GMAIL.COM", "FRANCOPALACIO03@GMAIL.COM", "AQAAAAIAAYagAAAAENx+mqz327vW7nNg+1zgqiA0kYoFjll9H4UKjkdHMWEsIXIV4CjQ07Zy5qUp3yJ+ng==", null, false, "d17779c1-bb60-4676-83a2-b6154e66aa27", false, "francopalacio03@gmail.com" },
                    { "1D98B435-C2C4-44D7-B1B2-AB229DE2ACED", 0, "Calle Grecia N°1234", "Florencio Varela", "1037afe5-3ff5-4a8e-a195-88e1833e1d5e", "luciaoses1997@gmail.com", true, "Lucia", "Oses", false, null, "LUCIAOSES1997@GMAIL.COM", "LUCIAOSES1997@GMAIL.COM", "AQAAAAIAAYagAAAAEMstGPxoJbbquBMPx4j6vlFLwQmkmPbx041/T7gtDUd1ySLZPMD/LmzcOvxAz9NOuA==", null, false, "29056e7c-1fbd-471e-9b7c-117e032c643d", false, "luciaoses1997@gmail.com" },
                    { "3D0F1848-5354-4CED-A125-525218044370", 0, "Viena n°1057", "Florencio Varela", "40d9c49f-eefe-451d-a062-e741de07266e", "diegorolon01@outlook.com", true, "Diego", "Rolon", false, null, "DIEGOROLON01@OUTLOOK.COM", "DIEGOROLON01@OUTLOOK.COM", "AQAAAAIAAYagAAAAEJ99b/u3aCs68PhO68rRTqWeAVuOvA+ic6uy0rDufCCKUHXfzCfc+3W5zbAOHqbIfQ==", null, false, "ea78efd2-3610-40cb-af84-efbdcee50160", false, "diegorolon01@outlook.com" },
                    { "AAEF2C4F-DED7-4B1A-ADD3-9A3448B9E9E0", 0, "Calle 9 N° 2946", "Berazategui", "796b349d-71ec-4a75-84e9-d05a2807874c", "bravo.jose.luis18@gmail.com", true, "Jose", "Bravo", false, null, "BRAVO.JOSE.LUIS18@GMAIL.COM", "BRAVO.JOSE.LUIS18@GMAIL.COM", "AQAAAAIAAYagAAAAEKtcjxpNVPBVuOmfukqsH2qMUCoqJQobf9gpkO+PIh6BT4pUNJ62kkfAtg5ixPYTjg==", null, false, "b934e6dd-745e-4da5-adf9-389873339583", false, "bravo.jose.luis18@gmail.com" },
                    { "FD9CB11E-76D6-4DEE-AAA3-921E983F36CA", 0, "Calle Los Andes N° 3850", "Bernal", "ab7917f5-470b-4785-8f4d-4fff8f60935b", "alanleandrovargas03@gmail.com", true, "Alan", "Vargas", false, null, "ALANLEANDROVARGAS03@gmail.com", "ALANLEANDROVARGAS03@GMAIL.COM", "AQAAAAIAAYagAAAAEIIVuOPg3c8xpdSp2T6Lm+qLuvKQ2Yi4cTaY524j49qQaom/oWPM3v+wHJUDBBfFTw==", null, false, "67ef9ff6-6309-4033-904e-7ac4c25c6a23", false, "alanleandrovargas03@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "05456319-A1AD-4AF9-B68B-7B6FD4161A7F", "19BB7F59-3372-433F-B343-00E75953D3A3" },
                    { "DCD3F190-A5F0-4A75-8E2C-095CBED0B551", "1D98B435-C2C4-44D7-B1B2-AB229DE2ACED" },
                    { "DCD3F190-A5F0-4A75-8E2C-095CBED0B551", "3D0F1848-5354-4CED-A125-525218044370" },
                    { "DCD3F190-A5F0-4A75-8E2C-095CBED0B551", "AAEF2C4F-DED7-4B1A-ADD3-9A3448B9E9E0" },
                    { "3A6F1076-6B34-4251-83D9-E2C71519F402", "FD9CB11E-76D6-4DEE-AAA3-921E983F36CA" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
