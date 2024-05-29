using Microsoft.AspNetCore.Mvc;
using SpaProjectManagement.Interfaces;
using SpaProjectManagement.Models;

namespace SpaProjectManagement.Controllers;

/// <summary>
/// Base controller for CRUD operations.
/// </summary>
/// <param name="repository">Repository to use</param>
/// <typeparam name="TEntity">Entity type</typeparam>
/// <typeparam name="TRepository">Repository type</typeparam>
[ApiController]
public abstract class BaseController<TEntity, TRepository>(TRepository repository) : ControllerBase
    where TEntity : BaseEntity
    where TRepository : IBaseRepository<TEntity>
{
    protected readonly TRepository Repository = repository;

    /// <summary>
    /// Gets all entities asynchronously from the repository and returns them in a JSON format in the response.
    /// </summary>
    /// <param name="ct">Cancellation token</param>
    /// <returns>Status code 200 and list of all entities</returns>
    [HttpGet]
    public virtual async Task<ActionResult<IEnumerable<TEntity>>> GetAllAsync(CancellationToken ct)
    {
        var entities = await Repository.GetAllAsync(ct);
        return Ok(entities);
    }

    /// <summary>
    /// Gets an entity by id asynchronously from the repository and returns it in a JSON format in the response.
    /// </summary>
    /// <param name="id">Id of the entity to get</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>Status code 200 and found entity</returns>
    [HttpGet("{id:int}")]
    public virtual async Task<ActionResult<TEntity>> GetByIdAsync(int id, CancellationToken ct)
    {
        var entity = await Repository.GetByIdAsync(id, ct);
        if (entity == null)
        {
            return NotFound();
        }

        return Ok(entity);
    }

    /// <summary>
    /// Creates an entity asynchronously in the repository and returns it in a JSON format in the response.
    /// </summary>
    /// <param name="entity">Entity to create</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>Status code 201 and created entity</returns>
    [HttpPost]
    public virtual async Task<ActionResult> CreateAsync(TEntity entity, CancellationToken ct)
    {
        await Repository.AddAsync(entity, ct);
        return Created(string.Empty, entity);
    }

    /// <summary>
    /// Updates an entity asynchronously in the repository and returns it in a JSON format in the response.
    /// </summary>
    /// <param name="entity">Entity to update</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>Status code 204</returns>
    [HttpPut]
    public virtual async Task<ActionResult> UpdateAsync(TEntity entity, CancellationToken ct)
    {
        await Repository.UpdateAsync(entity, ct);
        return NoContent();
    }

    /// <summary>
    /// Deletes an entity asynchronously from the repository and returns it in a JSON format in the response.
    /// </summary>
    /// <param name="id">Id of the entity to delete</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns></returns>
    [HttpDelete("{id:int}")]
    public virtual async Task<ActionResult> DeleteAsync(int id, CancellationToken ct)
    {
        await Repository.DeleteAsync(id, ct);
        return NoContent();
    }
}