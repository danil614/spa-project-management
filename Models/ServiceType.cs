using System.ComponentModel.DataAnnotations;

namespace spa_project_management.Models;

public class ServiceType
{
    [Key] public int Id { get; set; }

    [Required] [StringLength(50)] public required string Name { get; set; }

    public ICollection<Service>? Services { get; set; }
}