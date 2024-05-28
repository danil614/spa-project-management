using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SpaProjectManagement.Models;

[Index(nameof(ServiceId), nameof(EffectiveDate), IsUnique = true)]
public class Price : BaseEntity
{
    [Required]
    [ForeignKey("Service")]
    public int ServiceId { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }

    [Required]
    public DateTime EffectiveDate { get; set; } // Дата начала действия цены

    public Service? Service { get; set; }
}