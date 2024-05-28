using Microsoft.AspNetCore.Mvc;
using spa_project_management.Interfaces;
using spa_project_management.Models;

namespace spa_project_management.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InvoicesController(IRepositoryManager repository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Invoice>>> GetAll()
    {
        var invoices = await repository.InvoiceRepository.GetAllAsync();
        return Ok(invoices);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Invoice>> GetById(int id)
    {
        var invoice = await repository.InvoiceRepository.GetByIdAsync(id);
        if (invoice == null)
        {
            return NotFound();
        }

        return Ok(invoice);
    }

    [HttpPost]
    public async Task<ActionResult> Create(Invoice invoice)
    {
        await repository.InvoiceRepository.AddAsync(invoice);
        await repository.SaveAsync();
        return Created(string.Empty, invoice);
    }

    [HttpPut]
    public async Task<ActionResult> Update(Invoice invoice)
    {
        repository.InvoiceRepository.Update(invoice);
        await repository.SaveAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        await repository.InvoiceRepository.DeleteAsync(id);
        await repository.SaveAsync();
        return NoContent();
    }
}