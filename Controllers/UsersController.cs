using Microsoft.AspNetCore.Mvc;
using SpaProjectManagement.Interfaces;
using SpaProjectManagement.Models;

namespace SpaProjectManagement.Controllers;

/// <summary>
/// Controller for <see cref="User"/> model.
/// </summary>
/// <param name="repository">User repository to use</param>
[Route("api/[controller]")]
public class UsersController(IUserRepository repository) : BaseController<User, IUserRepository>(repository);