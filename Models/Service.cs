using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SpaProjectManagement.Models;

[Index(nameof(Name), IsUnique = true)]
public class Service : BaseEntity
{
    [Required]
    [ForeignKey("ServiceType")]
    public int TypeId { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }

    public ServiceType? Type { get; set; }
    public ICollection<Price>? Prices { get; set; }
    public ICollection<ProjectService>? ProjectServices { get; set; }
}