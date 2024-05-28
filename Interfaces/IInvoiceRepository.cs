using SpaProjectManagement.Models;

namespace SpaProjectManagement.Interfaces;

public interface IInvoiceRepository
{
    Task<IEnumerable<Invoice>> GetAllAsync(CancellationToken cancellationToken);
    Task<Invoice?> GetByIdAsync(int id);
    Task AddAsync(Invoice invoice);
    void Update(Invoice invoice);
    Task DeleteAsync(int id);
}