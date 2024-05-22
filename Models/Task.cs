using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace spa_project_management.Models;

public class Task
{
    [Key] public int TaskId { get; set; }

    [Required] [ForeignKey("Project")] public int ProjectId { get; set; }

    [Required] [StringLength(100)] public required string TaskName { get; set; }

    [Required] public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    [ForeignKey("User")] public int? AssignedEmployeeId { get; set; }

    [ForeignKey("Status")] public int? StatusId { get; set; }

    public Project? Project { get; set; }
    public User? AssignedEmployee { get; set; }
    public Status? Status { get; set; }
}