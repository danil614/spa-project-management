using System.ComponentModel.DataAnnotations;

namespace spa_project_management.Models;

public class ProjectStatus
{
    [Key] public int Id { get; set; }

    [Required] [StringLength(50)] public required string Name { get; set; }

    public ICollection<Project>? Projects { get; set; }
    public ICollection<ProjectService>? ProjectServices { get; set; }
}