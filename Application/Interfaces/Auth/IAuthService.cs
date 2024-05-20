using Application.Request.Auth;
using Application.Request.Registration;
using Application.Response;

namespace Application.Interfaces.Auth;

public interface IAuthService
{
    Task<AuthResponse> Login(AuthRequest request);
    Task<RegistrationResponse> Register(RegistrationRequest request);
}
