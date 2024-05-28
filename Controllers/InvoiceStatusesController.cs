using Microsoft.AspNetCore.Mvc;
using SpaProjectManagement.Interfaces;
using SpaProjectManagement.Models;

namespace SpaProjectManagement.Controllers;

[Route("api/[controller]")]
public class InvoiceStatusesController(IInvoiceStatusRepository repository)
    : BaseController<InvoiceStatus, IInvoiceStatusRepository>(repository);