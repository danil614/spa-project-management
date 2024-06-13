using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SpaProjectManagement.Models;

/// <summary>
/// Service type model class.
/// </summary>
[Index(nameof(Name), IsUnique = true)]
public class ServiceType : BaseEntity
{
    /// <summary>
    /// Name of service type.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    /// <summary>
    /// Collection of services attached to this service type.
    /// </summary>
    public ICollection<Service>? Services { get; set; }
}