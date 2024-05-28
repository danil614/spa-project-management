using spa_project_management.Models;

namespace spa_project_management.Interfaces;

public interface IInvoiceRepository
{
    Task<IEnumerable<Invoice>> GetAllAsync();
    Task<Invoice?> GetByIdAsync(int id);
    Task AddAsync(Invoice invoice);
    void Update(Invoice invoice);
    Task DeleteAsync(int id);
}