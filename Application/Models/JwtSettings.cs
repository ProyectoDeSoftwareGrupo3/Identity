namespace Application.Models;

public class JwtOptions
{

    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string SigningKey { get; set; }
    public double ExpirationInMinutes { get; set; }
}