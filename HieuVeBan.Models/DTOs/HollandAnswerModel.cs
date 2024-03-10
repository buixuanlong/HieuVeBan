namespace HieuVeBan.Models.DTOs
{
    public class HollandAnswerModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ShortName { get; set; }
        public int Mark { get; set; }
    }
}
