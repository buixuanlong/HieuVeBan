using AutoMapper;
using HieuVeBan.Models.DTOs;
using HieuVeBan.Models.Entities;

namespace HieuVeBan.Services.MappingProfiles;

public class ProvinceMappingProfiles : Profile
{
    public ProvinceMappingProfiles()
    {
        CreateMap<Province, ProvinceSummaryModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        CreateMap<Province, ProvinceModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
    }
}

