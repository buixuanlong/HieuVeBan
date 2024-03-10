using HieuVeBan.Models.Abstractions.Entities;
using HieuVeBan.Models.Enum;

namespace HieuVeBan.Models.Entities
{
    public class PersonalityAssessmentMethod : BaseEntity<Guid>
    {
        public string Name { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Note { get; set; } = null!;
        public MethodType Type { get; set; }

        public virtual ICollection<PersonalityAssessmentQuestion> PersonalityAssessmentQuestions { get; set; } = new List<PersonalityAssessmentQuestion>();
    }
}
