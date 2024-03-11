using System.ComponentModel.DataAnnotations.Schema;

namespace HieuVeBan.Models.Entities.OldEntities
{
    [Table("FunctionalFactors_MBTI")]
    public partial class FunctionalFactors_MBTI
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public int DichotomousPair_MBTI_Id { get; set; }
    }
}
