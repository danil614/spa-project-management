using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace SpaProjectManagement.Services;

public class JwtProvider(IOptions<JwtOptions> options) : IJwtProvider
{
    private readonly JwtOptions _options = options.Value;

    public static SymmetricSecurityKey GetSymmetricSecurityKey(string? key) =>
        new(Encoding.UTF8.GetBytes(key ?? "secret-key-jwt-authentication-spa-project-management"));

    public string GenerateToken(string login, string role)
    {
        var claims = new List<Claim>
        {
            new(ClaimsIdentity.DefaultNameClaimType, login),
            new(ClaimsIdentity.DefaultRoleClaimType, role)
        };

        // Create the JWT and write it to a string
        var jwt = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromDays(_options.ExpirationDays)),
            signingCredentials: new SigningCredentials(GetSymmetricSecurityKey(_options.SecretKey),
                SecurityAlgorithms.HmacSha256));
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
        return encodedJwt;
    }
}