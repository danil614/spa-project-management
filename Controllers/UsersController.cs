using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaProjectManagement.Models;

namespace SpaProjectManagement.Controllers;

/// <summary>
/// Controller for <see cref="User"/> model.
/// </summary>
/// <param name="context">Invoice status repository to use</param>
[Route("api/[controller]")]
public class UsersController(ApplicationContext context) : Controller
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> Get()
    {
        return await context.Users.ToListAsync();
    }
}