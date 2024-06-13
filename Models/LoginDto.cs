using System.ComponentModel.DataAnnotations;

namespace SpaProjectManagement.Models;

/// <summary>
/// Login model class.
/// </summary>
public class LoginDto
{
    /// <summary>
    /// Login of user.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Login { get; set; }

    /// <summary>
    /// Password of user.
    /// </summary>
    [Required]
    [StringLength(50)]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    /// <summary>
    /// Id of user role.
    /// </summary>
    [Required]
    public int RoleId { get; set; }
}