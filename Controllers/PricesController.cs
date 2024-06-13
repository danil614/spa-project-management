using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpaProjectManagement.Interfaces;
using SpaProjectManagement.Models;

namespace SpaProjectManagement.Controllers;

/// <summary>
/// Controller for <see cref="Price"/> model.
/// </summary>
/// <param name="repository">Price repository to use</param>
[Route("api/[controller]")]
public class PricesController(IPriceRepository repository)
    : BaseController<Price, IPriceRepository>(repository)
{
    [Authorize(Roles = RoleEnum.Manager + "," + RoleEnum.Admin)]
    public override async Task<ActionResult<IEnumerable<Price>>> GetAllAsync(CancellationToken ct)
    {
        return await base.GetAllAsync(ct);
    }

    [Authorize(Roles = RoleEnum.Manager + "," + RoleEnum.Client + "," + RoleEnum.Admin)]
    public override async Task<ActionResult<Price>> GetByIdAsync(int id, CancellationToken ct)
    {
        return await base.GetByIdAsync(id, ct);
    }

    [Authorize(Roles = RoleEnum.Manager + "," + RoleEnum.Admin)]
    public override async Task<ActionResult> CreateAsync(Price entity, CancellationToken ct)
    {
        return await base.CreateAsync(entity, ct);
    }

    [Authorize(Roles = RoleEnum.Admin)]
    public override async Task<ActionResult> UpdateAsync(Price entity, CancellationToken ct)
    {
        return await base.UpdateAsync(entity, ct);
    }

    [Authorize(Roles = RoleEnum.Admin)]
    public override Task<ActionResult> DeleteAsync(int id, CancellationToken ct)
    {
        return base.DeleteAsync(id, ct);
    }
}