using HieuVeBan.Models.Abstractions.Entities;

namespace HieuVeBan.Models.Entities
{
    public sealed class PersonalityAssessmentQuestion : BaseEntity<Guid>
    {
        public int QuestionNumber { get; set; }
        public string QuestionName { get; set; } = null!;
        public Guid PersonalityAssessmentMethodId { get; set; }
        public PersonalityAssessmentMethod PersonalityAssessmentMethod { get; set; } = null!;
    }
}
