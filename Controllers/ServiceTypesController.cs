using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpaProjectManagement.Interfaces;
using SpaProjectManagement.Models;

namespace SpaProjectManagement.Controllers;

/// <summary>
/// Controller for <see cref="ServiceType"/> model.
/// </summary>
/// <param name="repository">Service type repository to use</param>
[Route("api/[controller]")]
[Authorize(Roles = RoleEnum.Manager + "," + RoleEnum.Admin)]
public class ServiceTypesController(IServiceTypeRepository repository)
    : BaseController<ServiceType, IServiceTypeRepository>(repository);