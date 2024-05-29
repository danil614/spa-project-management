using Microsoft.EntityFrameworkCore;
using SpaProjectManagement.Interfaces;
using SpaProjectManagement.Models;

namespace SpaProjectManagement.Repositories;

/// <summary>
/// Repository for <see cref="Invoice"/> model.
/// </summary>
/// <param name="context">Application database context</param>
public class InvoiceRepository(ApplicationContext context)
    : BaseRepository<Invoice, ApplicationContext>(context), IInvoiceRepository
{
    /// <summary>
    /// Gets all invoices asynchronously from the database and returns them in a list. Includes project, client and status.
    /// </summary>
    /// <param name="ct">Cancellation token</param>
    /// <returns>List of all invoices</returns>
    public override async Task<IEnumerable<Invoice>> GetAllAsync(CancellationToken ct = default)
    {
        return await Context.Invoices
            .Include(i => i.Project)
            .Include(i => i.Client)
            .Include(i => i.Status)
            .ToListAsync(ct);
    }

    /// <summary>
    /// Gets an invoice by id asynchronously from the database and returns it. Includes project, client and status.
    /// </summary>
    /// <param name="id">Id of the entity</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>Found invoice</returns>
    public override async Task<Invoice?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        return await Context.Invoices
            .Include(i => i.Project)
            .Include(i => i.Client)
            .Include(i => i.Status)
            .FirstOrDefaultAsync(i => i.Id == id, ct);
    }
}