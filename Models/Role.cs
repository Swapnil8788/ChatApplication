using System;
using Microsoft.Identity.Client;

namespace ChatApplication.Models;

public class Role
{
    public int RoleId { get; set; }
    public string RoleName { get; set; } = string.Empty;
    public ICollection<UserRole>? UserRoles { get; set; }

}
