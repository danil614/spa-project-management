using Microsoft.AspNetCore.Mvc;
using SpaProjectManagement.Interfaces;
using SpaProjectManagement.Models;

namespace SpaProjectManagement.Controllers;

[ApiController]
public abstract class BaseController<TEntity, TRepository>(TRepository repository) : ControllerBase
    where TEntity : BaseEntity
    where TRepository : IBaseRepository<TEntity>
{
    protected readonly TRepository Repository = repository;

    [HttpGet]
    public virtual async Task<ActionResult<IEnumerable<TEntity>>> GetAllAsync(CancellationToken ct)
    {
        var entities = await Repository.GetAllAsync(ct);
        return Ok(entities);
    }

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

    [HttpPost]
    public virtual async Task<ActionResult> CreateAsync(TEntity entity, CancellationToken ct)
    {
        await Repository.AddAsync(entity, ct);
        return Created(string.Empty, entity);
    }

    [HttpPut]
    public virtual async Task<ActionResult> UpdateAsync(TEntity entity, CancellationToken ct)
    {
        await Repository.UpdateAsync(entity, ct);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public virtual async Task<ActionResult> DeleteAsync(int id, CancellationToken ct)
    {
        await Repository.DeleteAsync(id, ct);
        return NoContent();
    }
}