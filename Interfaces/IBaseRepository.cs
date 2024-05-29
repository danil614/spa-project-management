using SpaProjectManagement.Models;

namespace SpaProjectManagement.Interfaces;

/// <summary>
/// Interface for base repository with CRUD operations.
/// </summary>
/// <typeparam name="TEntity">Entity type</typeparam>
public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}