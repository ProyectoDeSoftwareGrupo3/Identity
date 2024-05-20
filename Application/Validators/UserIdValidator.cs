using FluentValidation;

namespace Application.Validators;

public class UserIdValidator : AbstractValidator<string>
{
    public UserIdValidator()
    {
        RuleFor(userId => userId)
            .NotEmpty().WithMessage("UserId es requerido.")
            .Must(IsGuid).WithMessage("UserId debe ser un GUID valido.");
    }

    private bool IsGuid(string userId)
    {
        return Guid.TryParse(userId, out _);
    }
}