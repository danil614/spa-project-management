using Microsoft.EntityFrameworkCore;
using SpaProjectManagement.Interfaces;
using SpaProjectManagement.Models;

namespace SpaProjectManagement.Repositories;

/// <summary>
/// Repository for <see cref="Service"/> model.
/// </summary>
/// <param name="context">Application database context</param>
public class ProjectRepository(ApplicationContext context)
    : BaseRepository<Project, ApplicationContext>(context), IProjectRepository
{
    /// <summary>
    /// Gets all projects asynchronously from the database and returns them in a list.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>List of all entities</returns>
    public override async Task<IEnumerable<Project>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await Context.Projects.Include(p => p.Client)
            .ToListAsync(cancellationToken);
    }
}