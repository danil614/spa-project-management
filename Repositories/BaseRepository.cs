using Microsoft.EntityFrameworkCore;
using SpaProjectManagement.Interfaces;
using SpaProjectManagement.Models;

namespace SpaProjectManagement.Repositories;

/// <summary>
/// Base repository with CRUD operations.
/// </summary>
/// <param name="context">Database context to use</param>
/// <typeparam name="TEntity">Entity type</typeparam>
/// <typeparam name="TContext">Database context type</typeparam>
public abstract class BaseRepository<TEntity, TContext>(TContext context) : IBaseRepository<TEntity>
    where TEntity : BaseEntity
    where TContext : DbContext
{
    protected readonly TContext Context = context;

    /// <summary>
    /// Gets all entities asynchronously from the database and returns them in a list.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>List of all entities</returns>
    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await Context.Set<TEntity>().ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Gets an entity by id asynchronously from the database and returns it.
    /// </summary>
    /// <param name="id">Id of the entity</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Found entity</returns>
    public virtual async Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await Context.Set<TEntity>().FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
    }

    /// <summary>
    /// Adds an entity asynchronously to the database.
    /// </summary>
    /// <param name="entity">Entity to add</param>
    /// <param name="cancellationToken">Cancellation token</param>
    public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await Context.Set<TEntity>().AddAsync(entity, cancellationToken);
        await Context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Updates an entity asynchronously in the database.
    /// </summary>
    /// <param name="entity">Entity to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        Context.Set<TEntity>().Update(entity);
        await Context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Deletes an entity asynchronously from the database.
    /// </summary>
    /// <param name="id">Id of the entity</param>
    /// <param name="cancellationToken">Cancellation token</param>
    public virtual async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        await Context.Set<TEntity>()
            .Where(i => i.Id == id)
            .ExecuteDeleteAsync(cancellationToken);
    }
}