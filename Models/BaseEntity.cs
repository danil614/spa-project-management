using System.ComponentModel.DataAnnotations;

namespace SpaProjectManagement.Models;

/// <summary>
/// Base entity class with id property as primary key.
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Id of the entity. Used as primary key.
    /// </summary>
    [Key]
    public int Id { get; set; }
}