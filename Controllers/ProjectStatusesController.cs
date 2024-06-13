using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpaProjectManagement.Interfaces;
using SpaProjectManagement.Models;

namespace SpaProjectManagement.Controllers;

/// <summary>
/// Controller for <see cref="ProjectStatus"/> model.
/// </summary>
/// <param name="repository">Project status repository to use</param>
[Route("api/[controller]")]
[Authorize(Roles = RoleEnum.Manager + "," + RoleEnum.Admin)]
public class ProjectStatusesController(IProjectStatusRepository repository)
    : BaseController<ProjectStatus, IProjectStatusRepository>(repository);