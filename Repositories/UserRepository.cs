using Microsoft.EntityFrameworkCore;
using SpaProjectManagement.Interfaces;
using SpaProjectManagement.Models;

namespace SpaProjectManagement.Repositories;

/// <summary>
/// Repository for <see cref="User"/> model.
/// </summary>
/// <param name="context">Application database context</param>
public class UserRepository(ApplicationContext context)
    : BaseRepository<User, ApplicationContext>(context), IUserRepository
{
    /// <summary>
    /// Gets all users asynchronously from the database and returns them in a list. Includes user roles.
    /// </summary>
    /// <param name="ct">Cancellation token</param>
    /// <returns>List of all users</returns>
    public override async Task<IEnumerable<User>> GetAllAsync(CancellationToken ct = default)
    {
        return await Context.Users
            .Include(i => i.UserRoles)
            .ToListAsync(ct);
    }

    /// <summary>
    /// Gets an user by id asynchronously from the database and returns it. Includes user roles.
    /// </summary>
    /// <param name="id">Id of the entity</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>Found user</returns>
    public override async Task<User?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        return await Context.Users
            .Include(i => i.UserRoles)
            .FirstOrDefaultAsync(i => i.Id == id, ct);
    }

    /// <summary>
    /// Gets an user by login asynchronously from the database and returns it.
    /// </summary>
    /// <param name="login">Login of the user</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>Found user</returns>
    public async Task<User?> GetByLoginAsync(string login, CancellationToken ct = default)
    {
        return await Context.Users
            .Include(i => i.UserRoles)!
            .ThenInclude(i => i.Role)
            .FirstOrDefaultAsync(i => i.Login == login, ct);
    }
}