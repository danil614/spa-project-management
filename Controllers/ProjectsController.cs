using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpaProjectManagement.Interfaces;
using SpaProjectManagement.Models;

namespace SpaProjectManagement.Controllers;

/// <summary>
/// Controller for <see cref="Project"/> model.
/// </summary>
/// <param name="repository">Project repository to use</param>
[Route("api/[controller]")]
public class ProjectsController(IProjectRepository repository)
    : BaseController<Project, IProjectRepository>(repository)
{
    [Authorize(Roles = RoleEnum.Manager + Constants.Comma + RoleEnum.Admin)]
    public override async Task<ActionResult<IEnumerable<Project>>> GetAllAsync(CancellationToken ct)
    {
        return await base.GetAllAsync(ct);
    }

    [Authorize(Roles = RoleEnum.Manager + Constants.Comma + RoleEnum.Client + Constants.Comma + RoleEnum.Admin)]
    public override async Task<ActionResult<Project>> GetByIdAsync(int id, CancellationToken ct)
    {
        return await base.GetByIdAsync(id, ct);
    }

    [Authorize(Roles = RoleEnum.Manager + Constants.Comma + RoleEnum.Admin)]
    public override async Task<ActionResult> CreateAsync(Project entity, CancellationToken ct)
    {
        return await base.CreateAsync(entity, ct);
    }

    [Authorize(Roles = RoleEnum.Manager + Constants.Comma + RoleEnum.Admin)]
    public override async Task<ActionResult> UpdateAsync(Project entity, CancellationToken ct)
    {
        return await base.UpdateAsync(entity, ct);
    }

    [Authorize(Roles = RoleEnum.Manager + Constants.Comma + RoleEnum.Admin)]
    public override Task<ActionResult> DeleteAsync(int id, CancellationToken ct)
    {
        return base.DeleteAsync(id, ct);
    }
}