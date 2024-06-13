using SpaProjectManagement.Models;

namespace SpaProjectManagement.Interfaces;

/// <summary>
/// Interface for <see cref="User"/> repository.
/// </summary>
public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetByLoginAsync(string login, CancellationToken cancellationToken = default);
}