using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SpaProjectManagement.Models;

/// <summary>
/// Price model class.
/// </summary>
[Index(nameof(ServiceId), nameof(EffectiveDate), IsUnique = true)]
public class Price : BaseEntity
{
    /// <summary>
    /// Service id of this price.
    /// </summary>
    [Required]
    [ForeignKey("Service")]
    public int ServiceId { get; set; }

    /// <summary>
    /// Amount of this price.
    /// </summary>
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }

    /// <summary>
    /// Start date of this price.
    /// </summary>
    [Required]
    public DateTime EffectiveDate { get; set; }

    /// <summary>
    /// Service of this price.
    /// </summary>
    public Service? Service { get; set; }
}