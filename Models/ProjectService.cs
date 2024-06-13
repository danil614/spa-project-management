using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaProjectManagement.Models;

/// <summary>
/// Project service model class.
/// </summary>
public class ProjectService : BaseEntity
{
    /// <summary>
    /// Id of service attached to project.
    /// </summary>
    [Required]
    [ForeignKey("Service")]
    public int ServiceId { get; set; }

    /// <summary>
    /// Quantity of services attached to project.
    /// </summary>
    [Required]
    public int Quantity { get; set; }

    /// <summary>
    /// Id of project attached to service.
    /// </summary>
    [Required]
    [ForeignKey("Project")]
    public int ProjectId { get; set; }

    /// <summary>
    /// Start date of service.
    /// </summary>
    [Required]
    public DateTime StartDate { get; set; }

    /// <summary>
    /// End date of service.
    /// </summary>
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// Id of assigned employee.
    /// </summary>
    [ForeignKey("User")]
    public int? AssignedEmployeeId { get; set; }

    /// <summary>
    /// Id of project status.
    /// </summary>
    [Required]
    [ForeignKey("ProjectStatus")]
    public int StatusId { get; set; }

    /// <summary>
    /// Description of service.
    /// </summary>
    [StringLength(500)]
    public string? Description { get; set; }

    /// <summary>
    /// Service attached to project.
    /// </summary>
    public Service? Service { get; set; }

    /// <summary>
    /// Project attached to service.
    /// </summary>
    public Project? Project { get; set; }

    /// <summary>
    /// Employee assigned to service.
    /// </summary>
    public User? AssignedEmployee { get; set; }

    /// <summary>
    /// Project status attached to service.
    /// </summary>
    public ProjectStatus? Status { get; set; }
}