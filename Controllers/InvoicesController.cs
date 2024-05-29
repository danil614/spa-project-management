using Microsoft.AspNetCore.Mvc;
using SpaProjectManagement.Interfaces;
using SpaProjectManagement.Models;

namespace SpaProjectManagement.Controllers;

/// <summary>
/// Controller for <see cref="Invoice"/> model.
/// </summary>
/// <param name="repository">Invoice repository to use</param>
[Route("api/[controller]")]
public class InvoicesController(IInvoiceRepository repository)
    : BaseController<Invoice, IInvoiceRepository>(repository);