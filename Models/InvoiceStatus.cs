using System.ComponentModel.DataAnnotations;

namespace SpaProjectManagement.Models;

public class InvoiceStatus : BaseEntity
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    public ICollection<Invoice>? Invoices { get; set; }
}