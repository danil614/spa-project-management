using Microsoft.AspNetCore.Mvc;
using SpaProjectManagement.Interfaces;
using SpaProjectManagement.Models;

namespace SpaProjectManagement.Controllers;

[Route("api/[controller]")]
public class InvoicesController(IInvoiceRepository repository)
    : BaseController<Invoice, IInvoiceRepository>(repository);