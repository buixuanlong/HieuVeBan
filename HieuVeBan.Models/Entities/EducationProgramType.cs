using HieuVeBan.Models.Abstractions.Entities;

namespace HieuVeBan.Models.Entities
{
    public class EducationProgramType : BaseEntity<Guid>
    {
        public string Name { get; set; } = null!;
        public string? Link { get; set; }
        public string? Description { get; set; }
    }
}
