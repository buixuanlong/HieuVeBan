using AutoMapper;
using HieuVeBan.Models.DTOs;
using HieuVeBan.Models.Entities;

namespace HieuVeBan.Services.MappingProfiles;

public class UserMappingProfiles : Profile
{
    public UserMappingProfiles()
    {
        CreateMap<AppUser, IdentityModel>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.UserEmail))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));

        CreateMap<AppUser, UserModel>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.UserEmail))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));
    }
}

