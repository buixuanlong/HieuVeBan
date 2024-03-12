using AutoMapper;
using HieuVeBan.Models.Commands;
using HieuVeBan.Models.DTOs;
using HieuVeBan.Models.Entities;

namespace HieuVeBan.Services.MappingProfiles;

public class UserInformationMappingProfiles : Profile
{
    public UserInformationMappingProfiles()
    {
        CreateMap<UserInformationCreateModel, User>();
        CreateMap<User, UserInformationModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
    }
}

