using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SpaProjectManagement.Models;

/// <summary>
/// Service model class.
/// </summary>
[Index(nameof(Name), IsUnique = true)]
public class Service : BaseEntity
{
    /// <summary>
    /// Service type id of this service.
    /// </summary>
    [Required]
    [ForeignKey("ServiceType")]
    public int TypeId { get; set; }

    /// <summary>
    /// Name of service.
    /// </summary>
    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    /// <summary>
    /// Description of service.
    /// </summary>
    [StringLength(500)]
    public string? Description { get; set; }

    /// <summary>
    /// Service type of this service.
    /// </summary>
    public ServiceType? Type { get; set; }

    /// <summary>
    /// Collection of prices attached to this service.
    /// </summary>
    public ICollection<Price>? Prices { get; set; }

    /// <summary>
    /// Collection of project services attached to this service.
    /// </summary>
    public ICollection<ProjectService>? ProjectServices { get; set; }
}