using System.ComponentModel.DataAnnotations.Schema;

namespace HieuVeBan.Models.Entities.OldEntities
{
    [Table("Images_MBTI")]
    public class Images_MBTI
    {
        public int Id { get; set; }
        public int PersonalityGroup_MBTI_Id { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public string ImageInfo { get; set; }
    }
}
