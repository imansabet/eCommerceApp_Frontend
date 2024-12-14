using System.ComponentModel.DataAnnotations;

namespace ClientLibrary.Models.Authentication;

public class AuthenticationBase
{
    [EmailAddress,Required]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
}
