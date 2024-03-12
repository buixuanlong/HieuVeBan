using HieuVeBan.Abstraction.Interfaces;
using HieuVeBan.Models.Abstractions.Entities;

namespace HieuVeBan.Models.Entities
{
    public class UserHistory : BaseEntity<Guid>, ICreatedDateTime
    {
        public string Symbol { get; set; } = null!;
        public Guid UserId { get; set; }
        public Guid PersonalityAssessmentMethodId { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public User User { get; set; } = null!;
        public PersonalityAssessmentMethod PersonalityAssessmentMethod { get; set; } = null!;
    }
}
