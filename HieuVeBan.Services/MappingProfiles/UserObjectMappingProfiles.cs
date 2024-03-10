using AutoMapper;
using HieuVeBan.Models.DTOs;
using HieuVeBan.Models.Entities;

namespace HieuVeBan.Services.MappingProfiles;

public class UserObjectMappingProfiles : Profile
{
    public UserObjectMappingProfiles()
    {
        CreateMap<UserObject, UserObjectModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
    }
}

