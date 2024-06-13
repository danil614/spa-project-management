using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpaProjectManagement.Interfaces;
using SpaProjectManagement.Models;
using SpaProjectManagement.Services;

namespace SpaProjectManagement.Controllers;

/// <summary>
/// Controller for <see cref="User"/> model.
/// </summary>
/// <param name="repository">User repository to use</param>
[Route("api/[controller]")]
public class UsersController(IUserRepository repository, IJwtProvider jwtProvider)
    : BaseController<User, IUserRepository>(repository)
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

        var encodedJwt = jwtProvider.GenerateToken(entity.Login, role);
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