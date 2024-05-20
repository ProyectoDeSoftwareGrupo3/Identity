using Application.Commons.Extensions;
using FluentValidation;

namespace Application.Commons;

public static class PasswordValidator
{
    public static IRuleBuilderOptions<T, string> PasswordValid<T>(
this IRuleBuilder<T, string> ruleBuilder)
    {
        return
            ruleBuilder
            .NotEmpty().WithMessage("El campo Contraseña es requerido.")
            .Matches(StringExtensions.PasswordRegex).WithMessage("El campo Contraseña no cumple el formato deseado.");
    }

}
