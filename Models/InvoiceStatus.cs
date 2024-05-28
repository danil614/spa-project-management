using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SpaProjectManagement.Models;

[Index(nameof(Name), IsUnique = true)]
public class InvoiceStatus : BaseEntity
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    public ICollection<Invoice>? Invoices { get; set; }
}