using System.ComponentModel.DataAnnotations;

namespace SpaProjectManagement.Models;

public class Role
{
    [Key] public int Id { get; set; }

    [Required] [StringLength(50)] public required string Name { get; set; }

    public ICollection<UserRole>? UserRoles { get; set; }
}