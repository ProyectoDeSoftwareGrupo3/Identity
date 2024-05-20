namespace Application.Commons.Extensions;

public static class StringExtensions
{
    public const string PasswordRegex = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[!@$?_-])[A-Za-z\d@!$?_-]{8}$";

}
