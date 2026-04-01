using System;
using AutoMapper;
using ChatApplication.DTOs.Auth;
using ChatApplication.DTOs.UserDTOs;
using ChatApplication.Models;

namespace ChatApplication.Services;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterRequest, User>();
        CreateMap<User,RegisteredResponseDTO>();

    }
}
