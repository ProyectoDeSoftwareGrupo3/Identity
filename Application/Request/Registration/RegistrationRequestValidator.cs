using Domain.Constants;
using FluentValidation;

namespace Application.Request.Registration;

public class RegistrationRequestValidator : AbstractValidator<RegistrationRequest>
{
    public RegistrationRequestValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("El nombre es requerido.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("El apellido es requerido.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("El correo electrónico es requerido.")
            .EmailAddress().WithMessage("Por favor, ingrese un correo electrónico válido.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("La contraseña es requerida.");

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("La dirección es requerida.");

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("La ciudad es requerida.");

        RuleFor(x => x.Role)
            .NotEmpty().WithMessage("El rol es requerido.")
            .Must(BeAValidRole).WithMessage("El rol proporcionado no es válido.");
    }

    private bool BeAValidRole(string role)
    {
        var validRoles = new List<string> { Roles.Administrador, Roles.Refugio, Roles.Miembro };
        return validRoles.Contains(role);
    }
}