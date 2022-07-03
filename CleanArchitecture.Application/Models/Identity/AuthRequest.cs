using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.Models.Identity;

public class AuthRequest
{
    [Required]
    [DefaultValue("admin@localhost.com")]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    [DefaultValue("123456")]
    public string Password { get; set; } = string.Empty;
}