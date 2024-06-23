using Application.DTOs;
using Application.Request.UpdateUser;

namespace Application.Interfaces.User;

public interface IUserService
{
    Task<List<UserDto>> GetAllUsersAsync();
    Task<UserDto> GetUserByIdAsync(string userId);
    Task<bool> UpdateUserAsync(string userId, UpdateUserRequest request);
    Task<string> DeleteUserAsync(string userId);
    Task<List<string>> GetUserRoles(string userId);
    Task<bool> UpdateUserRole(string userId, string roleId);
}
