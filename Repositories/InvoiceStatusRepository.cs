using SpaProjectManagement.Interfaces;
using SpaProjectManagement.Models;

namespace SpaProjectManagement.Repositories;

/// <summary>
/// Repository for <see cref="InvoiceStatus"/> model.
/// </summary>
/// <param name="context">Application database context</param>
public class InvoiceStatusRepository(ApplicationContext context)
    : BaseRepository<InvoiceStatus, ApplicationContext>(context), IInvoiceStatusRepository;