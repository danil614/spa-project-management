using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace spa_project_management.Models;

public class Item
{
    [Key] public int ItemId { get; set; }

    [Required] [ForeignKey("ItemType")] public int ItemTypeId { get; set; }

    [Required] [StringLength(100)] public required string Name { get; set; }

    [StringLength(500)] public string? Description { get; set; }

    public ItemType? ItemType { get; set; }
    public ICollection<Price>? Prices { get; set; }
    public ICollection<ProjectItem>? ProjectItems { get; set; }
}