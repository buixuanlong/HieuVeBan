using HieuVeBan.Models.Abstractions.Entities;

namespace HieuVeBan.Models.Entities
{
    public class MBTIResult : BaseEntity<Guid>
    {
        public Guid MBTIFunctionalFactorId { get; set; }
        public Guid PersonalityAssessmentQuestionId { get; set; }
        public Guid MBTIAnswerId { get; set; }
        public int Mark { get; set; }

        public MBTIFunctionalFactor MBTIFunctionalFactor { get; set; } = null!;
        public PersonalityAssessmentQuestion PersonalityAssessmentQuestion { get; set; } = null!;
        public MBTIAnswer MBTIAnswer { get; set; } = null!;
    }
}
