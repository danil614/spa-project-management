using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaProjectManagement.Models;

public class Project
{
    [Key] public int Id { get; set; }

    [Required] [ForeignKey("User")] public int ClientId { get; set; }

    [Required] [ForeignKey("User")] public int ResponsibleEmployeeId { get; set; }

    [Required] [StringLength(100)] public required string Name { get; set; }

    [Required] public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Budget { get; set; } // Начальный бюджет клиента на проект

    [Required]
    [ForeignKey("ProjectStatus")]
    public int StatusId { get; set; }

    [StringLength(1000)] public string? Description { get; set; }

    public User? Client { get; set; }
    public User? ResponsibleEmployee { get; set; }
    public ProjectStatus? Status { get; set; }

    public ICollection<ProjectService>? ProjectServices { get; set; }
}