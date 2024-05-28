using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SpaProjectManagement.Models;

[Index(nameof(Name), IsUnique = true)]
public class Role
{
    [Key] public int Id { get; set; }

    [Required] [StringLength(50)] public required string Name { get; set; }

    public ICollection<UserRole>? UserRoles { get; set; }
}