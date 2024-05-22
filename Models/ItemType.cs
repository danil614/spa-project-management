using System.ComponentModel.DataAnnotations;

namespace spa_project_management.Models;

public class ItemType
{
    [Key] public int ItemTypeId { get; set; }

    [Required] [StringLength(50)] public required string TypeName { get; set; }

    public ICollection<Item>? Items { get; set; }
}