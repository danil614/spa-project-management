using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SpaProjectManagement.Models;

/// <summary>
/// User model class. Allows to create users with different roles.
/// </summary>
[Index(nameof(Login), IsUnique = true)]
public class User : BaseEntity
{
    /// <summary>
    /// Login of user.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Login { get; set; }

    /// <summary>
    /// Password of user.
    /// </summary>
    [Required]
    [StringLength(50)]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    /// <summary>
    /// Name of user.
    /// </summary>
    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    /// <summary>
    /// Email address of user.
    /// </summary>
    [EmailAddress]
    [StringLength(50)]
    public string? Email { get; set; }

    /// <summary>
    /// Phone number of user.
    /// </summary>
    [Phone]
    [StringLength(50)]
    public string? Phone { get; set; }

    /// <summary>
    /// Additional information of user.
    /// </summary>
    [StringLength(500)]
    public string? Description { get; set; }

    /// <summary>
    /// Collection of user roles attached to this user.
    /// </summary>
    public ICollection<UserRole>? UserRoles { get; set; }

    /// <summary>
    /// Collection of projects attached to this user as client.
    /// </summary>
    public ICollection<Project>? ClientProjects { get; set; }

    /// <summary>
    /// Collection of projects that this user responsible for.
    /// </summary>
    public ICollection<Project>? ResponsibleProjects { get; set; }

    /// <summary>
    /// Collection of assigned tasks for this user.
    /// </summary>
    public ICollection<ProjectService>? AssignedTasks { get; set; }
}