using Application.Interfaces.Auth;
using Application.Models;
using Application.Request.Auth;
using Application.Request.Registration;
using Application.Response;
using Domain.Constants;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.UseCases;

public class AuthService(UserManager<ApplicationUser> userManager, IOptions<JwtOptions> jwtOptions) : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IOptions<JwtOptions> _jwtOptions = jwtOptions;

    public async Task<AuthResponse> Login(AuthRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
            
        if(user == null) throw new Exception($"User not found with {request.Email}");

       var result = await _userManager.CheckPasswordAsync(user, request.Password);

        if (!result)
        {
            throw new Exception($"Credential for {request.Email} are not valid!");
        }

        JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

        AuthResponse response = new(user.Id, user.UserName, user.Email, new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken));

        return response;

    }

    public async Task<RegistrationResponse> Register(RegistrationRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user != null)
            throw new Exception($"User {request.Email} already exist");

        var newUser = new ApplicationUser
        {
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            UserName = request.Email,
            EmailConfirmed = true,
            Address = request.Address,
            City = request.City
        };

        var result = await _userManager.CreateAsync(newUser, request.Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(newUser, Roles.Miembro);
            return new RegistrationResponse(newUser.Id);
        }
        else
        {
            throw new Exception($"{result.Errors}");
        }
    }

    private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);

        var roleClaims = new List<Claim>();

        for (int i = 0; i < roles.Count; i++)
        {
            roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
        }

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("uid", user.Id)
        }.Union(userClaims).Union(roleClaims);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Value.SigningKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtOptions.Value.Issuer,
            audience: _jwtOptions.Value.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(_jwtOptions.Value.ExpirationInMinutes),
            signingCredentials: credentials);

        return token;
    }
}
