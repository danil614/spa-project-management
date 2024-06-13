using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace SpaProjectManagement;

public static class AuthOptions
{
    public const string Issuer = "MyAuthServer";
    public const string Audience = "MyAuthClient";
    private const string Key = "secret-key-jwt-authentication-spa-project-management";

    public static SymmetricSecurityKey GetSymmetricSecurityKey() => new(Encoding.UTF8.GetBytes(Key));
}