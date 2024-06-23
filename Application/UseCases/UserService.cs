using Application.DTOs;
using Application.Interfaces.User;
using Application.Request.UpdateUser;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases;

public class UserService(UserManager<ApplicationUser> userManager) : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;

    public async Task<List<UserDto>> GetAllUsersAsync()
    {
        var users = await _userManager.GetUsersInRoleAsync("Administrador");

        return users.Select(user => new UserDto
        {
            Id = user.Id,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            City = user.City
        }).ToList();
    }

    public async Task<UserDto> GetUserByIdAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user is null) return null;
        
        return new UserDto
        {
            Id = user.Id,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            City = user.City
        };
    }

    public async Task<string> DeleteUserAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return null;
        }

        var result = await _userManager.DeleteAsync(user);

        if (result.Succeeded)
        {
            return user.Id;
        }
        else
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new InvalidOperationException($"Error eliminando usuario: {errors}");
        }
    }

    public async Task<List<string>> GetUserRoles(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return null;
        }

        var roles = await _userManager.GetRolesAsync(user);

        return roles.ToList();
    }

    public async Task<UserDto> UpdateUser(string userId, UpdateUserRequest request)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);

        if (user == null)
        {
            return null;
        }

        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.Email = request.Email;
        user.Address = request.Address;
        user.City = request.City;

        _userManager.UpdateAsync(user);

        return new UserDto
        {
            Id = user.Id,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            City = user.City
        };
    }

    public async Task<bool> UpdateUserRole(string userId, string roleId)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return false;
            }

            var currentRoles = await _userManager.GetRolesAsync(user);

            // Quitar al usuario de todos los roles actuales
            await _userManager.RemoveFromRolesAsync(user, currentRoles);

            // Agregar el nuevo rol al usuario
            await _userManager.AddToRoleAsync(user, roleId);

            return true;
        }
        catch (Exception ex)
        {
            // Maneja la excepción de manera adecuada, por ejemplo, registrándola o lanzándola nuevamente
            Console.WriteLine($"Error al actualizar el rol del usuario: {ex.Message}");
            throw;
        }
    }
}
