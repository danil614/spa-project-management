using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using spa_project_management.Models;

namespace spa_project_management.Controllers;

[Route("api/[controller]")]
public class UsersController(ApplicationContext context) : Controller
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> Get()
    {
        return await context.Users.ToListAsync();
    }
}