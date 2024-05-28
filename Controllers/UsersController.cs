using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaProjectManagement.Models;

namespace SpaProjectManagement.Controllers;

[Route("api/[controller]")]
public class UsersController(ApplicationContext context) : Controller
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> Get()
    {
        return await context.Users.ToListAsync();
    }
}