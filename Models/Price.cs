using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace spa_project_management.Models;

public class Price
{
    [Key] public int PriceId { get; set; }

    [Required] [ForeignKey("Item")] public int ItemId { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }

    [Required] public DateTime EffectiveDate { get; set; } // Дата начала действия цены

    public Item? Item { get; set; }
}