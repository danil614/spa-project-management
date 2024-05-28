using Microsoft.EntityFrameworkCore;
using SpaProjectManagement.Interfaces;
using SpaProjectManagement.Models;

namespace SpaProjectManagement.Repositories;

public class InvoiceRepository(ApplicationContext context)
    : BaseRepository<Invoice, ApplicationContext>(context), IInvoiceRepository
{
    private readonly ApplicationContext _context = context;

    public new async Task<IEnumerable<Invoice>> GetAllAsync(CancellationToken ct = default)
    {
        return await _context.Invoices
            .Include(i => i.Project)
            .Include(i => i.Client)
            .Include(i => i.Status)
            .ToListAsync(ct);
    }

    public override async Task<Invoice?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        return await _context.Invoices
            .Include(i => i.Project)
            .Include(i => i.Client)
            .Include(i => i.Status)
            .FirstOrDefaultAsync(i => i.Id == id, ct);
    }
}