using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaProjectManagement.Models;

/// <summary>
/// Project model class.
/// </summary>
public class Project : BaseEntity
{
    /// <summary>
    /// Id of client attached to this project.
    /// </summary>
    [Required]
    public int ClientId { get; set; }

    /// <summary>
    /// Id of responsible employee for this project.
    /// </summary>
    [Required]
    public int ResponsibleEmployeeId { get; set; }

    /// <summary>
    /// Name of the project.
    /// </summary>
    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    /// <summary>
    /// Start date of the project.
    /// </summary>
    [Required]
    public DateTime StartDate { get; set; }

    /// <summary>
    /// End date of the project.
    /// </summary>
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// Preferred budget of the project.
    /// </summary>
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Budget { get; set; }

    /// <summary>
    /// Id of project status.
    /// </summary>
    [Required]
    public int StatusId { get; set; }

    /// <summary>
    /// Description of the project.
    /// </summary>
    [StringLength(1000)]
    public string? Description { get; set; }

    /// <summary>
    /// Client attached to this project.
    /// </summary>
    [ForeignKey("ClientId")]
    [InverseProperty("ClientProjects")]
    public User? Client { get; set; }

    /// <summary>
    /// Employee responsible for this project.
    /// </summary>
    [ForeignKey("ResponsibleEmployeeId")]
    [InverseProperty("ResponsibleProjects")]
    public User? ResponsibleEmployee { get; set; }

    /// <summary>
    /// Project status.
    /// </summary>
    [ForeignKey("StatusId")]
    public ProjectStatus? Status { get; set; }

    /// <summary>
    /// Services attached to this project.
    /// </summary>
    public ICollection<ProjectService>? ProjectServices { get; set; }
}