using AutoMapper;
using HieuVeBan.Models.DTOs;
using HieuVeBan.Models.Entities;

namespace HieuVeBan.Services.MappingProfiles
{
    public class PersonalityAssessmentQuestionMappingProfiles : Profile
    {
        public PersonalityAssessmentQuestionMappingProfiles()
        {
            CreateMap<PersonalityAssessmentQuestion, MBTIQuestionModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.MethodId, opt => opt.MapFrom(src => src.PersonalityAssessmentMethodId));

            CreateMap<PersonalityAssessmentQuestion, QuestionModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.MethodId, opt => opt.MapFrom(src => src.PersonalityAssessmentMethodId));
        }
    }
}
