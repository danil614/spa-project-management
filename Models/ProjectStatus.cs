using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SpaProjectManagement.Models;

/// <summary>
/// Project status model class.
/// </summary>
[Index(nameof(Name), IsUnique = true)]
public class ProjectStatus : BaseEntity
{
    /// <summary>
    /// Name of project status.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    /// <summary>
    /// Collection of projects with this status.
    /// </summary>
    public ICollection<Project>? Projects { get; set; }

    /// <summary>
    /// Collection of project services with this status.
    /// </summary>
    public ICollection<ProjectService>? ProjectServices { get; set; }
}