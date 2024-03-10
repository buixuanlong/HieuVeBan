using HieuVeBan.Models.Enum;

namespace HieuVeBan.Models.DTOs
{
    public class MethodModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Note { get; set; } = null!;
        public MethodType Type { get; set; }
    }
}
