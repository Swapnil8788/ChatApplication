using System;
using System.ComponentModel.DataAnnotations;

namespace ChatApplication.DTOs.UserDTOs;

public class getRolesDTO
{
    [Required]
    public string token {get;set;} = string.Empty;

}
