using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace spa_project_management.Models;

public class ProjectItem
{
    [Key] public int ProjectItemId { get; set; }

    [Required] [ForeignKey("Project")] public int ProjectId { get; set; }

    [Required] [ForeignKey("Item")] public int ItemId { get; set; }

    [Required] public int Quantity { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalCost { get; set; }

    public Project? Project { get; set; }
    public Item? Item { get; set; }
}