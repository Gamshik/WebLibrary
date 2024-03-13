using AutoMapper;
using Entities.DTOs.UserDTOs;
using Microsoft.AspNetCore.Identity;

namespace WebApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegistrationDto, IdentityUser<int>>();
        }
    }
}
