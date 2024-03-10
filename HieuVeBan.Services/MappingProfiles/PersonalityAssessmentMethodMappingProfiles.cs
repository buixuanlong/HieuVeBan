using AutoMapper;
using HieuVeBan.Models.DTOs;
using HieuVeBan.Models.Entities;

namespace HieuVeBan.Services.MappingProfiles
{
    public class PersonalityAssessmentMethodMappingProfiles : Profile
    {
        public PersonalityAssessmentMethodMappingProfiles()
        {
            CreateMap<PersonalityAssessmentMethod, MethodModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
