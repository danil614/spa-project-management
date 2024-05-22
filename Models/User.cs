using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace spa_project_management.Models;

public class User
{
    [Key] public int UserId { get; set; }

    [Required] [StringLength(100)] public required string Name { get; set; }

    [EmailAddress] public string? Email { get; set; }

    [Phone] public string? Phone { get; set; }

    [Required] [ForeignKey("Role")] public int RoleId { get; set; }

    [StringLength(500)] public string? Description { get; set; }

    public Role? Role { get; set; }

    public ICollection<Project>? Projects { get; set; } // Только для клиентов
    public ICollection<Task>? AssignedTasks { get; set; } // Только для сотрудников
}