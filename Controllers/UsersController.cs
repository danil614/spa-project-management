using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SpaProjectManagement.Interfaces;
using SpaProjectManagement.Models;

namespace SpaProjectManagement.Controllers;

/// <summary>
/// Controller for <see cref="User"/> model.
/// </summary>
/// <param name="repository">User repository to use</param>
[Route("api/[controller]")]
public class UsersController(IUserRepository repository) : BaseController<User, IUserRepository>(repository)
{
    /// <summary>
    /// Logins user and returns JWT token.
    /// </summary>
    /// <param name="loginDto">Login DTO model</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns></returns>
    [HttpPost("login")]
    public async Task<ActionResult> LoginAsync(LoginDto loginDto, CancellationToken ct)
    {
        var entity = await Repository.GetByLoginAsync(loginDto.Login, ct);
        if (entity == null)
        {
            return NotFound();
        }

        if (entity.Password != loginDto.Password)
        {
            return Unauthorized();
        }

        if (entity.UserRoles == null || entity.UserRoles.Count == 0)
        {
            return Unauthorized();
        }

        var userRole = entity.UserRoles.Where(ur => ur.RoleId == loginDto.RoleId)
            .Select(ur => ur.Role?.SystemName)
            .ToList();
        if (userRole.Count == 0)
        {
            return Unauthorized();
        }

        var role = userRole.First();
        if (role == null)
        {
            return Unauthorized();
        }

        var claims = new List<Claim>
        {
            new(ClaimsIdentity.DefaultNameClaimType, entity.Login),
            new(ClaimsIdentity.DefaultRoleClaimType, role)
        };
        // Create the JWT and write it to a string
        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.Issuer,
            audience: AuthOptions.Audience,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromDays(7)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256));
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        var response = new
        {
            token = encodedJwt,
            username = entity.Login,
            role
        };

        return Ok(response);
    }

    [Authorize(Roles = RoleEnum.Admin)]
    public override async Task<ActionResult<IEnumerable<User>>> GetAllAsync(CancellationToken ct)
    {
        return await base.GetAllAsync(ct);
    }

    [Authorize(Roles = RoleEnum.Admin)]
    public override async Task<ActionResult<User>> GetByIdAsync(int id, CancellationToken ct)
    {
        return await base.GetByIdAsync(id, ct);
    }

    [Authorize(Roles = RoleEnum.Admin)]
    public override async Task<ActionResult> UpdateAsync(User entity, CancellationToken ct)
    {
        return await base.UpdateAsync(entity, ct);
    }

    [Authorize(Roles = RoleEnum.Admin)]
    public override async Task<ActionResult> DeleteAsync(int id, CancellationToken ct)
    {
        return await base.DeleteAsync(id, ct);
    }
}