using System.ComponentModel.DataAnnotations;

namespace spa_project_management.Models;

public class Status
{
    [Key] public int StatusId { get; set; }

    [Required] [StringLength(50)] public required string StatusName { get; set; }

    public ICollection<Project>? Projects { get; set; }
    public ICollection<Task>? Tasks { get; set; }
}