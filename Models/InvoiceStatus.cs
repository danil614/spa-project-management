using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SpaProjectManagement.Models;

/// <summary>
/// Invoice status model class. Represents invoice status.
/// </summary>
[Index(nameof(Name), IsUnique = true)]
public class InvoiceStatus : BaseEntity
{
    /// <summary>
    /// Name of the invoice status. Should be unique.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    /// <summary>
    /// Collection of invoices that have this status.
    /// </summary>
    public ICollection<Invoice>? Invoices { get; set; }
}