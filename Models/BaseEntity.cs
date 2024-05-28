using System.ComponentModel.DataAnnotations;

namespace SpaProjectManagement.Models;

public abstract class BaseEntity
{
    [Key] public int Id { get; set; }
}