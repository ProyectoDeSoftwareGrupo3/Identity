using FluentValidation;

namespace Application.Request.UpdateUser;

public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserRequestValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("El nombre es requerido.");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("El apellido es requerido.");
        RuleFor(x => x.Address).NotEmpty().WithMessage("La dirección es requerida.");
        RuleFor(x => x.City).NotEmpty().WithMessage("La ciudad es requerida.");
    }
}