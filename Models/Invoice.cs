using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace spa_project_management.Models;

public class Invoice
{
    [Key] public int InvoiceId { get; set; }

    [Required] [ForeignKey("Project")] public int ProjectId { get; set; }

    [Required] [ForeignKey("User")] public int ClientId { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; } // Сумма счета

    [Required] public DateTime IssueDate { get; set; } // Дата выставления счета

    public DateTime? PaymentDate { get; set; } // Дата оплаты, если оплачено

    public bool IsPaid { get; set; }

    public Project? Project { get; set; }
    public User? Client { get; set; }
}