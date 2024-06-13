using SpaProjectManagement.Interfaces;
using SpaProjectManagement.Models;

namespace SpaProjectManagement.Repositories;

/// <summary>
/// Repository for <see cref="ProjectStatus"/> model.
/// </summary>
/// <param name="context">Application database context</param>
public class ProjectStatusRepository(ApplicationContext context)
    : BaseRepository<ProjectStatus, ApplicationContext>(context), IProjectStatusRepository;