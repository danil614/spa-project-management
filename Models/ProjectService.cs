using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace spa_project_management.Models;

public class ProjectService
{
    [Key] public int Id { get; set; }

    [Required] [ForeignKey("Service")] public int ServiceId { get; set; }

    [Required] public int Quantity { get; set; }

    [Required] [ForeignKey("Project")] public int ProjectId { get; set; }

    [Required] public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    [ForeignKey("User")] public int? AssignedEmployeeId { get; set; }

    [Required]
    [ForeignKey("ProjectStatus")]
    public int StatusId { get; set; }

    [StringLength(500)] public string? Description { get; set; }

    public Service? Service { get; set; }
    public Project? Project { get; set; }
    public User? AssignedEmployee { get; set; }
    public ProjectStatus? Status { get; set; }
}