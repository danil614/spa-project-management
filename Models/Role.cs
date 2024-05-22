using System.ComponentModel.DataAnnotations;

namespace spa_project_management.Models;

public class Role
{
    [Key] public int RoleId { get; set; }

    [Required] [StringLength(50)] public required string RoleName { get; set; }

    public ICollection<User>? Users { get; set; }
}