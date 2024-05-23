using System.ComponentModel.DataAnnotations;

namespace spa_project_management.Models;

public class InvoiceStatus
{
    [Key] public int Id { get; set; }

    [Required] [StringLength(50)] public required string Name { get; set; }

    public ICollection<Invoice>? Invoices { get; set; }
}