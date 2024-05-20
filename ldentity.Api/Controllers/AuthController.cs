using Application.Interfaces.Auth;
using Application.Request.Auth;
using Application.Request.Registration;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService authService) : Controller
{
    private readonly IAuthService _authService = authService;

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
    {
        var validator = new AuthRequestValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            return BadRequest(result.Errors);
        }

        return Ok(await _authService.Login(request));
    }

    [HttpPost("signup")]
    public async Task<ActionResult<RegistrationResponse>> RegisterUser(RegistrationRequest request)
    {
        var validator = new RegistrationRequestValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            return BadRequest(result.Errors);
        }

        return Ok(await _authService.Register(request));
    }
}
