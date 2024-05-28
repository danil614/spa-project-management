using System.ComponentModel.DataAnnotations;

namespace SpaProjectManagement.Models;

public class User
{
    [Key] public int Id { get; set; }

    [Required] [StringLength(100)] public required string Name { get; set; }

    [EmailAddress] [StringLength(50)] public string? Email { get; set; }

    [Phone] [StringLength(50)] public string? Phone { get; set; }

    [StringLength(500)] public string? Description { get; set; }

    public ICollection<UserRole>? UserRoles { get; set; }

    public ICollection<Project>? ClientProjects { get; set; }
    public ICollection<Project>? ResponsibleProjects { get; set; }

    public ICollection<ProjectService>? AssignedTasks { get; set; }
}