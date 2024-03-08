using HieuVeBan.Abstraction.Interfaces;
using HieuVeBan.Models.Abstractions.Entities;

namespace HieuVeBan.Models.Entities
{
    public sealed class PersonalityAssessmentMethod : BaseEntity<Guid>, ICreatedDateTime
    {
        public string Name { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Note { get; set; } = null!;

        public DateTime CreatedDateTime { get; set; }
    }
}
