using System.ComponentModel.DataAnnotations;

namespace Application.Request.Registration;

public class RegistrationRequest
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required, EmailAddress]
    public string Email { get; set; }
    [Required, Compare(nameof(Password))]
    public string Password { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public string City { get; set; }
}
