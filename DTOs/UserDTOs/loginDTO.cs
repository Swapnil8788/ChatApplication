using System;
using System.ComponentModel.DataAnnotations;

namespace ChatApplication.DTOs.UserDTOs;

public class loginDTO
{

    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}
