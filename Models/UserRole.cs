using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace spa_project_management.Models;

[PrimaryKey(nameof(UserId), nameof(RoleId))]
public class UserRole
{
    [Key, Column(Order = 0)]
    [ForeignKey("User")]
    public int UserId { get; set; }

    [Key, Column(Order = 1)]
    [ForeignKey("Role")]
    public int RoleId { get; set; }

    public User? User { get; set; }
    public Role? Role { get; set; }
}