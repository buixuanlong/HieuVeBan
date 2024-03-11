using System.ComponentModel.DataAnnotations.Schema;

namespace HieuVeBan.Models.Entities.OldEntities
{
    [Table("PersonalityGroup_MBTI")]
    public partial class PersonalityGroup_MBTI
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Description { get; set; }

    }
}
