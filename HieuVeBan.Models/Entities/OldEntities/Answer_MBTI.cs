using System.ComponentModel.DataAnnotations.Schema;

namespace HieuVeBan.Models.Entities.OldEntities
{
    [Table("Answer_MBTI")]
    public partial class Answer_MBTI
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Question_Id { get; set; }
    }
}
