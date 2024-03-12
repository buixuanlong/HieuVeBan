using System.ComponentModel.DataAnnotations.Schema;

namespace HieuVeBan.Models.Entities.OldEntities
{
    [Table("HobbyGroup_HOLLAND_Question")]
    public partial class HobbyGroup_HOLLAND_Question
    {
        public int Id { get; set; }
        public int HobbyGroup_HOLLAND_Id { get; set; }
        public int Question_Id { get; set; }
        public string? Note { get; set; }

    }
}
