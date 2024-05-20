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
                    { "19BB7F59-3372-433F-B343-00E75953D3A3", 0, "Adolfo Alsina 1238", "Florencio Varela", "cfcbd0c0-e274-45b5-b21c-febdb720d917", "francopalacio03@gmail.com", true, "Franco", "Palacio", false, null, "FRANCOPALACIO03@GMAIL.COM", "FRANCOPALACIO03@GMAIL.COM", "AQAAAAIAAYagAAAAEFSs/qDT6Ip9fAFk+maKgN6XOZJJ1fBrmNu+V4XefWfsCkihqAfeIDOv2+um+BAXKQ==", null, false, "14c819b3-31b1-46f7-8e99-3c81c40348ed", false, "francopalacio03@gmail.com" },
                    { "1D98B435-C2C4-44D7-B1B2-AB229DE2ACED", 0, "Calle Grecia N°1234", "Florencio Varela", "cd40ea2f-902c-4acc-a696-132a4e6d4594", "luciaoses1997@gmail.com", true, "Lucia", "Oses", false, null, "LUCIAOSES1997@GMAIL.COM", "LUCIAOSES1997@GMAIL.COM", "AQAAAAIAAYagAAAAEHyORvBmlXCVctDhWUst7S5dsOvGtUFE/c6F51mffmVu/l1+5xRSu3/gESzYngBWTg==", null, false, "cca20d58-0a6a-45aa-be3c-dc3cb5b4cf13", false, "luciaoses1997@gmail.com" },
                    { "3D0F1848-5354-4CED-A125-525218044370", 0, "Viena n°1057", "Florencio Varela", "8e69154b-4597-424e-9da4-bc76bca68856", "diegorolon01@outlook.com", true, "Diego", "Rolon", false, null, "DIEGOROLON01@OUTLOOK.COM", "DIEGOROLON01@OUTLOOK.COM", "AQAAAAIAAYagAAAAECnNGC/TN8O/hdMkSMp+EKiQLm/P2z9mjy8wbnXSNaI8EvYZyxnDkAet1d8Md4C1jw==", null, false, "98a6ec59-6078-4263-acea-cd2e7a2fb760", false, "diegorolon01@outlook.com" },
                    { "AAEF2C4F-DED7-4B1A-ADD3-9A3448B9E9E0", 0, "Calle 9 N° 2946", "Berazategui", "e5051399-3985-4c2f-8913-2f70183cf6d3", "bravo.jose.luis18@gmail.com", true, "Jose", "Bravo", false, null, "BRAVO.JOSE.LUIS18@GMAIL.COM", "BRAVO.JOSE.LUIS18@GMAIL.COM", "AQAAAAIAAYagAAAAEFYPU6bw9KuMcdGPfXvQV2ccsH/5rNT9tNtywDpkgcoPiNf7kuQ99KXIDv+WfKWNfg==", null, false, "c0755a50-3f5e-440f-80b7-36e16e1eba00", false, "bravo.jose.luis18@gmail.com" },
                    { "FD9CB11E-76D6-4DEE-AAA3-921E983F36CA", 0, "Calle Los Andes N° 3850", "Bernal", "ad34d53a-f992-47b5-b7ed-46596c3efae8", "alanleandrovargas03@gmail.com", true, "Alan", "Vargas", false, null, "ALANLEANDROVARGAS03@gmail.com", "ALANLEANDROVARGAS03@GMAIL.COM", "AQAAAAIAAYagAAAAEL7zu2Cx1qhhCtrQxzWs1fILHORSpJgLp33nFiUiI4RjHdK6Ai4A1v44+4jFan5cgQ==", null, false, "c61e7a9e-ff7d-47ba-a49c-4ff6dfb3413f", false, "alanleandrovargas03@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "DCD3F190-A5F0-4A75-8E2C-095CBED0B551", "19BB7F59-3372-433F-B343-00E75953D3A3" },
                    { "DCD3F190-A5F0-4A75-8E2C-095CBED0B551", "1D98B435-C2C4-44D7-B1B2-AB229DE2ACED" },
                    { "DCD3F190-A5F0-4A75-8E2C-095CBED0B551", "3D0F1848-5354-4CED-A125-525218044370" },
                    { "DCD3F190-A5F0-4A75-8E2C-095CBED0B551", "AAEF2C4F-DED7-4B1A-ADD3-9A3448B9E9E0" },
                    { "DCD3F190-A5F0-4A75-8E2C-095CBED0B551", "FD9CB11E-76D6-4DEE-AAA3-921E983F36CA" }
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
