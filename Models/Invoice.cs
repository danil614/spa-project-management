using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaProjectManagement.Models;

/// <summary>
/// Invoice model class. Allows to create invoices for client on project.
/// </summary>
public class Invoice : BaseEntity
{
    /// <summary>
    /// Id of attached project.
    /// </summary>
    [Required]
    [ForeignKey("Project")]
    public int ProjectId { get; set; }

    /// <summary>
    /// Id of attached client.
    /// </summary>
    [Required]
    [ForeignKey("User")]
    public int ClientId { get; set; }

    /// <summary>
    /// Amount of invoice.
    /// </summary>
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }

    /// <summary>
    /// Date of issue of invoice.
    /// </summary>
    [Required]
    public DateTime IssueDate
    { get; set; }

    /// <summary>
    /// Date of payment of invoice. If invoice is not paid, it will be null.
    /// </summary>
    public DateTime? PaymentDate { get; set; }

    /// <summary>
    /// Id of invoice status.
    /// </summary>
    [Required]
    [ForeignKey("InvoiceStatus")]
    public int StatusId { get; set; }

    /// <summary>
    /// Project attached to invoice.
    /// </summary>
    public Project? Project { get; set; }
    
    /// <summary>
    /// Client attached to invoice.
    /// </summary>
    public User? Client { get; set; }
    
    /// <summary>
    /// Invoice status attached to invoice.
    /// </summary>
    public InvoiceStatus? Status { get; set; }
}