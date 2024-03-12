using HieuVeBan.Models.Abstractions.Entities;

namespace HieuVeBan.Models.Entities
{
    public class EducationProgram : BaseEntity<Guid>
    {
        public string Name { get; set; } = null!;
        public string? Link { get; set; }

        public Guid EducationProgramTypeId { get; set; }
        public EducationProgramType EducationProgramType { get; set; } = null!;
    }
}
