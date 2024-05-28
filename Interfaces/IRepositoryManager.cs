namespace spa_project_management.Interfaces;

public interface IRepositoryManager
{
    IInvoiceRepository InvoiceRepository { get; }
    Task SaveAsync();
}