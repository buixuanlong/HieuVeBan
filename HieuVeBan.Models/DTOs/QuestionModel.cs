using System.Text.Json.Serialization;

namespace HieuVeBan.Models.DTOs
{
    public class QuestionModel
    {
        [JsonPropertyOrder(-1)]
        public Guid Id { get; set; }
        [JsonPropertyOrder(-1)]
        public int QuestionNumber { get; set; }
        [JsonPropertyOrder(-1)]
        public string QuestionName { get; set; } = null!;
        [JsonPropertyOrder(-1)]
        public Guid MethodId { get; set; }
    }
}
