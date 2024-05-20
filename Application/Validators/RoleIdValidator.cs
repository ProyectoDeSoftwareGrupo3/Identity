using FluentValidation;

namespace Application.Validators;

public class RoleIdValidator : AbstractValidator<string>
{
    public RoleIdValidator()
    {
        RuleFor(roleId => roleId)
            .NotEmpty().WithMessage("RoleId es requerido.")
            .Must(IsRole).WithMessage("RoleId debe ser valido.");
    }

    private bool IsRole(string roleId)
    {
        var roles = new List<string> { "Miembro", "Refugio", "Administrador" };
        return roles.Contains(roleId);
    }
}