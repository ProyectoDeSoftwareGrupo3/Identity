using FluentValidation;

namespace Application.Request.Auth;

public class AuthRequestValidator : AbstractValidator<AuthRequest>
{
    public AuthRequestValidator()
    {
        RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("Debe ingresar un email.")
            .EmailAddress().WithMessage("Debe ingresar un email valido.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Debe ingresar una contraseña")
            .MaximumLength(15).WithMessage("La contraseña tener como maximo 15 caracteres");
    }
}