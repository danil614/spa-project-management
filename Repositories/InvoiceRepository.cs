using Microsoft.EntityFrameworkCore;
using spa_project_management.Interfaces;
using spa_project_management.Models;

namespace spa_project_management.Repositories;

public class InvoiceRepository(ApplicationContext context) : IInvoiceRepository
{
    public async Task<IEnumerable<Invoice>> GetAllAsync()
    {
        return await context.Invoices
            .Include(i => i.Project)
            .Include(i => i.Client)
            .Include(i => i.Status)
            .ToListAsync();
    }

    public async Task<Invoice?> GetByIdAsync(int id)
    {
        return await context.Invoices
            .Include(i => i.Project)
            .Include(i => i.Client)
            .Include(i => i.Status)
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task AddAsync(Invoice invoice)
    {
        await context.Invoices.AddAsync(invoice);
    }

    public void Update(Invoice invoice)
    {
        context.Invoices.Update(invoice);
    }

    public async Task DeleteAsync(int id)
    {
        var invoice = new Invoice { Id = id };
        context.Invoices.Attach(invoice);
        context.Invoices.Remove(invoice);
        await context.SaveChangesAsync();
    }
}