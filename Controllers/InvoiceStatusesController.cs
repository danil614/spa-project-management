using Microsoft.AspNetCore.Mvc;
using SpaProjectManagement.Interfaces;
using SpaProjectManagement.Models;

namespace SpaProjectManagement.Controllers;

/// <summary>
/// Controller for <see cref="InvoiceStatus"/> model.
/// </summary>
/// <param name="repository">Invoice status repository to use</param>
[Route("api/[controller]")]
public class InvoiceStatusesController(IInvoiceStatusRepository repository)
    : BaseController<InvoiceStatus, IInvoiceStatusRepository>(repository);