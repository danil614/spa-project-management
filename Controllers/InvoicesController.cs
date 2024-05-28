using Microsoft.AspNetCore.Mvc;
using SpaProjectManagement.Interfaces;
using SpaProjectManagement.Models;

namespace SpaProjectManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InvoicesController(IInvoiceRepository repository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Invoice>>> GetAllAsync(CancellationToken ct)
    {
        var invoices = await repository.GetAllAsync(ct);
        return Ok(invoices);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Invoice>> GetByIdAsync(int id, CancellationToken ct)
    {
        var invoice = await repository.GetByIdAsync(id, ct);
        if (invoice == null)
        {
            return NotFound();
        }

        return Ok(invoice);
    }

    [HttpPost]
    public async Task<ActionResult> CreateAsync(Invoice invoice, CancellationToken ct)
    {
        await repository.AddAsync(invoice, ct);
        return Created(string.Empty, invoice);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAsync(Invoice invoice, CancellationToken ct)
    {
        await repository.UpdateAsync(invoice, ct);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteAsync(int id, CancellationToken ct)
    {
        await repository.DeleteAsync(id, ct);
        return NoContent();
    }
}