using AutoMapper;
using HieuVeBan.Models.DTOs;
using HieuVeBan.Models.Entities;

namespace HieuVeBan.Services.MappingProfiles;

public class AnswerMappingProfiles : Profile
{
    public AnswerMappingProfiles()
    {
        CreateMap<MBTIAnswer, MBTIAnswerModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

        CreateMap<HollandAnswer, HollandAnswerModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
    }
}

