using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaProjectManagement.Models;

public class Project : BaseEntity
{
    [Required]
    public int ClientId { get; set; }

    [Required]
    public int ResponsibleEmployeeId { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Budget { get; set; } // Начальный бюджет клиента на проект

    [Required]
    public int StatusId { get; set; }

    [StringLength(1000)]
    public string? Description { get; set; }

    [ForeignKey("ClientId")]
    [InverseProperty("ClientProjects")]
    public User? Client { get; set; }

    [ForeignKey("ResponsibleEmployeeId")]
    [InverseProperty("ResponsibleProjects")]
    public User? ResponsibleEmployee { get; set; }

    [ForeignKey("StatusId")]
    public ProjectStatus? Status { get; set; }

    public ICollection<ProjectService>? ProjectServices { get; set; }
}