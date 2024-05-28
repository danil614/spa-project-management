using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaProjectManagement.Models;

public class Service
{
    [Key] public int Id { get; set; }

    [Required] [ForeignKey("ServiceType")] public int TypeId { get; set; }

    [Required] [StringLength(100)] public required string Name { get; set; }

    [StringLength(500)] public string? Description { get; set; }

    public ServiceType? Type { get; set; }
    public ICollection<Price>? Prices { get; set; }
    public ICollection<ProjectService>? ProjectServices { get; set; }
}