using HieuVeBan.Models.Abstractions.Entities;

namespace HieuVeBan.Models.Entities
{
    public class MBTIAnswer : BaseEntity<Guid>
    {
        public string Name { get; set; } = null!;
        public Guid PersonalityAssessmentQuestionId { get; set; }

        public PersonalityAssessmentQuestion PersonalityAssessmentQuestion { get; set; } = null!;
    }
}
