using System.ComponentModel.DataAnnotations.Schema;

namespace HieuVeBan.Models.Entities.OldEntities
{
    [Table("DichotomousPair_MBTI")]
    public partial class DichotomousPair_MBTI
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
