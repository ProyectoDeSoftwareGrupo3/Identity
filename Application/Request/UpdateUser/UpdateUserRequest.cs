using System.ComponentModel.DataAnnotations;

namespace Application.Request.UpdateUser;

public class UpdateUserRequest
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required, EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public string City { get; set; }
}
