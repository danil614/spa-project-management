using SpaProjectManagement.Interfaces;
using SpaProjectManagement.Models;

namespace SpaProjectManagement.Repositories;

/// <summary>
/// Repository for <see cref="Service"/> model.
/// </summary>
/// <param name="context">Application database context</param>
public class ProjectRepository(ApplicationContext context)
    : BaseRepository<Project, ApplicationContext>(context), IProjectRepository;