using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpaProjectManagement.Interfaces;
using SpaProjectManagement.Models;

namespace SpaProjectManagement.Controllers;

/// <summary>
/// Controller for <see cref="Service"/> model.
/// </summary>
/// <param name="repository">Service type repository to use</param>
[Route("api/[controller]")]
public class ServicesController(IServiceRepository repository)
    : BaseController<Service, IServiceRepository>(repository)
{
    [Authorize(Roles = RoleEnum.Manager + "," + RoleEnum.Admin)]
    public override async Task<ActionResult<IEnumerable<Service>>> GetAllAsync(CancellationToken ct)
    {
        return await base.GetAllAsync(ct);
    }

    [Authorize(Roles = RoleEnum.Manager + "," + RoleEnum.Client + "," + RoleEnum.Admin)]
    public override async Task<ActionResult<Service>> GetByIdAsync(int id, CancellationToken ct)
    {
        return await base.GetByIdAsync(id, ct);
    }

    [Authorize(Roles = RoleEnum.Manager + "," + RoleEnum.Admin)]
    public override async Task<ActionResult> CreateAsync(Service entity, CancellationToken ct)
    {
        return await base.CreateAsync(entity, ct);
    }

    [Authorize(Roles = RoleEnum.Manager + "," + RoleEnum.Admin)]
    public override async Task<ActionResult> UpdateAsync(Service entity, CancellationToken ct)
    {
        return await base.UpdateAsync(entity, ct);
    }

    [Authorize(Roles = RoleEnum.Manager + "," + RoleEnum.Admin)]
    public override Task<ActionResult> DeleteAsync(int id, CancellationToken ct)
    {
        return base.DeleteAsync(id, ct);
    }
}