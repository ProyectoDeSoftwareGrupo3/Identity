using Application.DTOs;
using Application.Interfaces.User;
using Application.Request.UpdateUser;
using Application.Validators;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpGet]
    public async Task<ActionResult<List<UserDto>>> GetAllUsers()
    {
        return Ok(await _userService.GetAllUsersAsync());
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<UserDto>> GetUserById(string userId)
    {
        var validator = new UserIdValidator();
        var result = validator.Validate(userId);

        if (!result.IsValid)
        {
            return BadRequest(result.Errors.Select(e => e.ErrorMessage));
        }

        var user = await _userService.GetUserByIdAsync(userId);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpDelete("{userId}")]
    public async Task<ActionResult> DeleteUserAsync(string userId)
    {
        var validator = new UserIdValidator();
        var validationResult = validator.Validate(userId);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
        }

        try
        {
            var user = await _userService.DeleteUserAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Se ha producido un error al eliminar la usuario.", details = ex.Message });
        }
    }

    [HttpGet("{userId}/roles")]
    public async Task<ActionResult<List<string>>> GetUserRolesAsync(string userId)
    {
        var validator = new UserIdValidator();
        var result = validator.Validate(userId);

        if (!result.IsValid)
        {
            return BadRequest(result.Errors.Select(e => e.ErrorMessage));
        }

        var roles = await _userService.GetUserRoles(userId);

        if (roles == null)
        {
            return NotFound();
        }

        return Ok(roles);
    }

    [HttpPost("{userId}/roles")]
    public async Task<ActionResult> AssignRoleToUserAsync(string userId, [FromBody] string roleId)
    {
        var validator = new UserIdValidator();
        var rolevalidator = new RoleIdValidator();
        var userIdValidationResult = validator.Validate(userId);
        var roleIdValidationResult = rolevalidator.Validate(roleId);

        if (!userIdValidationResult.IsValid)
        {
            return BadRequest(userIdValidationResult.Errors.Select(e => e.ErrorMessage));
        }

        if (!roleIdValidationResult.IsValid)
        {
            return BadRequest(roleIdValidationResult.Errors.Select(e => e.ErrorMessage));
        }
        try
        {
            var result = await _userService.UpdateUserRole(userId, roleId);

            if (!result)
            {
                return NotFound("Usuario no encontrado.");
            }

            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Se produjo un error al actualizar el rol de usuario.", details = ex.Message });
        }
    }

    [HttpPut("{userId}")]
    public async Task<IActionResult> UpdateUser(string userId, [FromBody] UpdateUserRequest request)
    {
        var validator = new UpdateUserRequestValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            return BadRequest(result.Errors);
        }

        try
        {
            await _userService.UpdateUserAsync(userId, request);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
