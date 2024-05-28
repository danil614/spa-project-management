using SpaProjectManagement.Interfaces;

namespace SpaProjectManagement.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly ApplicationContext _context;
    private readonly Lazy<IInvoiceRepository> _invoiceRepository;

    public RepositoryManager(ApplicationContext context)
    {
        _context = context;
        _invoiceRepository = new Lazy<IInvoiceRepository>(() => new InvoiceRepository(_context));
    }

    public IInvoiceRepository InvoiceRepository => _invoiceRepository.Value;

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}