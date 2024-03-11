using System.ComponentModel.DataAnnotations.Schema;

namespace HieuVeBan.Models.Entities.OldEntities
{
    [Table("Answer_HOLLAND")]
    public partial class Answer_HOLLAND
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Mark { get; set; }

    }
}
