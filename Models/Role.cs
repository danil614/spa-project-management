using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SpaProjectManagement.Models;

/// <summary>
/// Role model class.
/// </summary>
[Index(nameof(Name), IsUnique = true)]
public class Role : BaseEntity
{
    /// <summary>
    /// Name of role.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    /// <summary>
    /// System name of role.
    /// </summary>
    [Required]
    public string SystemName { get; set; }

    /// <summary>
    /// Collection of user roles attached to this role.
    /// </summary>
    public ICollection<UserRole>? UserRoles { get; set; }
}