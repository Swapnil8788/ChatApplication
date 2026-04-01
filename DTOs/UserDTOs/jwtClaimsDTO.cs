using System;

namespace ChatApplication.DTOs.UserDTOs;

public class jwtClaimsDTO
{
    public string Email {get;set;}= string.Empty;
    public string Role{get;set;}=string.Empty;
}
