using System;
using System.ComponentModel.DataAnnotations;

namespace ChatApplication.DTOs.Auth;

public class RegisterRequest
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
    [Required]
    [Compare("Password")]
    public string Confirm { get; set; } = string.Empty;
    [Required]
    public string Role { get; set; } = string.Empty;
}
