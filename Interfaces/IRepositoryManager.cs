namespace SpaProjectManagement.Interfaces;

public interface IRepositoryManager
{
    IInvoiceRepository InvoiceRepository { get; }
    Task SaveAsync();
}