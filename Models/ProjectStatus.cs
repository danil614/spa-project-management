using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SpaProjectManagement.Models;

[Index(nameof(Name), IsUnique = true)]
public class ProjectStatus : BaseEntity
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    public ICollection<Project>? Projects { get; set; }
    public ICollection<ProjectService>? ProjectServices { get; set; }
}