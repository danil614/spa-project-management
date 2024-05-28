using SpaProjectManagement.Interfaces;
using SpaProjectManagement.Models;

namespace SpaProjectManagement.Repositories;

public class InvoiceStatusRepository(ApplicationContext context)
    : BaseRepository<InvoiceStatus, ApplicationContext>(context), IInvoiceStatusRepository;