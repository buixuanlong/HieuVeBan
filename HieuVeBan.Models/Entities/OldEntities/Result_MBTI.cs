using System.ComponentModel.DataAnnotations.Schema;

namespace HieuVeBan.Models.Entities.OldEntities
{
    [Table("Result_MBTI")]
    public partial class Result_MBTI
    {
        public int Id { get; set; }
        public int FunctionalFactors_MBTI_Id { get; set; }
        public int Question_Id { get; set; }
        public int Answer_MBTI_Id { get; set; }
        public int Mark { get; set; }


    }
}
