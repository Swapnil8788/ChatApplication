using System;

namespace ChatApplication.Models;

public class User
{
    public int Id { get; set; }
    public string Name{get;set;} = string.Empty;
    public string Email{get;set;} = string.Empty;
    public string Password{get;set;} = string.Empty;
    public string Confirm{get;set;} = string.Empty;
    public ICollection<UserRole>? UserRoles{get;set;}
}
