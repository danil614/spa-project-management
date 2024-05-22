using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace spa_project_management.Models;

public class Project
{
    [Key] public int ProjectId { get; set; }

    [Required] [ForeignKey("User")] public int ClientId { get; set; }

    [Required] [StringLength(100)] public required string ProjectName { get; set; }

    [Required] public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Budget { get; set; }

    [ForeignKey("Status")] public int? StatusId { get; set; }

    [StringLength(1000)] public string? Description { get; set; }

    public User? Client { get; set; }
    public Status? Status { get; set; }
    public ICollection<ProjectItem>? ProjectItems { get; set; }
}