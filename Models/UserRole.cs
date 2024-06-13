using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SpaProjectManagement.Models;

/// <summary>
/// User role model class.
/// </summary>
[PrimaryKey(nameof(UserId), nameof(RoleId))]
public class UserRole : BaseEntity
{
    /// <summary>
    /// Id of user.
    /// </summary>
    [Key, Column(Order = 0)]
    [ForeignKey("User")]
    public int UserId { get; set; }

    /// <summary>
    /// Id of role.
    /// </summary>
    [Key, Column(Order = 1)]
    [ForeignKey("Role")]
    public int RoleId { get; set; }

    /// <summary>
    /// User of this user role.
    /// </summary>
    public User? User { get; set; }

    /// <summary>
    /// Role of this user role.
    /// </summary>
    public Role? Role { get; set; }
}